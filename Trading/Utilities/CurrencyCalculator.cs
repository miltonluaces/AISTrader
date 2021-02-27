#region Imports

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using BusinessModel;

#endregion

namespace Trading {
    
    public sealed class CurrencyConverter {

        #region Fields

        private const string urltemplate = "http://finance.yahoo.com/d/quotes.csv?{0}&f=sl1d1t1ba&e=.csv";  // put list of currencies like this: "s=CUR1CUR2=X&s=CUR3CUR4=X&..."
        private const string paretemplate = "s={0}{1}=X";
        private const string NA = "N/A";
        private WebProxy _proxy;
        private bool _ajustTime;
        private int _timeout = 30000;
        private int _readWriteTimeout = 30000;

        #endregion

        #region Constructor

        public CurrencyConverter() {
            _proxy = new WebProxy();
        }

        #endregion

        #region Properties
        
        //Set to true if you want to convert Trade Date/Time to your local value
        public bool AdjustToLocalTime {
            get { return _ajustTime; }
            set { _ajustTime = value; }
        }

        public WebProxy Proxy {
            get { return _proxy; }
            set { _proxy = value; }
        }

        public int Timeout {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public int ReadWriteTimeout {
            get { return _readWriteTimeout; }
            set { _readWriteTimeout = value; }
        }

        #endregion

        #region Public Methods

        public void GetCurrencyData(ref Currency data) {
            CheckParams(data);
            StringBuilder urlpart = new StringBuilder();
            urlpart.AppendFormat(CultureInfo.InvariantCulture, paretemplate, data.BaseCode, data.TargetCode);
            List<Currency> listData = GetData(new Uri(String.Format(CultureInfo.InvariantCulture, urltemplate, urlpart.ToString())));
            if ((listData != null) && (listData.Count > 0)) { data = listData[0]; }
        }

        public Currency GetCurrencyData(string source, string target) {
            Currency data = new Currency(source, target);
            GetCurrencyData(ref data);
            return data;
        }

        //Receive Currency data form multi currencies stored in ICollection
        //This example shows how to call GetCurrencyData with IList&lt;CurrencyData&gt; param
        //CurrencyConverter cc = new CurrencyConverter();
        //if(useProxy) cc.Proxy = new System.Net.WebProxy(proxyAddress, proxyPort);
        //IList&lt;CurrencyData&gt; list = new List&lt;CurrencyData&gt;(listViewRate.Items.Count);
        //list.Add(new CurrencyData("USD", "RUB"));
        //cc.GetCurrencyData(ref list);
        public void GetCurrencyData(ref IList<Currency> listData) {
            // Create the URL:
            StringBuilder urlpart = new StringBuilder();

            foreach (Currency cd in listData) {
                CheckParams(cd);
                if (urlpart.Length > 0) { urlpart.Append('&'); }
                urlpart.AppendFormat(CultureInfo.InvariantCulture, paretemplate, cd.BaseCode, cd.TargetCode);
            }

            string url = String.Format(CultureInfo.InvariantCulture, urltemplate, urlpart.ToString());
            Uri uri = new Uri(url);
            listData.Clear();
            listData = GetData(uri);
        }

        #endregion

        #region Private Methods

        private List<Currency> GetData(Uri url) {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Proxy = _proxy;
            req.Timeout = _timeout;
            req.ReadWriteTimeout = _readWriteTimeout;

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            try {
                Stream respStream = resp.GetResponseStream();
                try {
                    StreamReader respReader = new StreamReader(respStream, Encoding.ASCII);
                    try {
                        char[] trimchars = new char[] { '"', '\'' };

                        List<Currency> Result = new List<Currency>();

                        while (respReader.Peek() > 0) {
                            string[] fields = respReader.ReadLine().Split(new char[] { ',' });

                            if ((fields.Length == 0) || (fields[(int)DataFieldNames.TradeDate].Trim(trimchars).Equals(NA, StringComparison.InvariantCultureIgnoreCase)))
                                throw new UnauthorizedAccessException("The currency data is not available!");

                            if (fields[(int)DataFieldNames.CurrencyCodes].Trim(trimchars).Equals(NA, StringComparison.InvariantCultureIgnoreCase))
                                throw new ArgumentOutOfRangeException("These Currencies are not supported!");

                            string from = fields[(int)DataFieldNames.CurrencyCodes].Trim(trimchars).Substring(0, 3);
                            string to = fields[(int)DataFieldNames.CurrencyCodes].Trim(trimchars).Substring(3, 3);

                            Currency data = new Currency(from, to);

                            CultureInfo culture = new CultureInfo("en-US", false);
                            if (fields[(int)DataFieldNames.CurrentRate].Equals(NA, StringComparison.InvariantCultureIgnoreCase))
                                data.Rate = 0;
                            else
                                data.Rate = Double.Parse(fields[(int)DataFieldNames.CurrentRate], culture);

                            string datetime = String.Format(CultureInfo.InvariantCulture,
                                "{0} {1}", fields[(int)DataFieldNames.TradeDate].Trim(trimchars),
                                fields[(int)DataFieldNames.TradeTime].Trim(trimchars));
                            data.TradeDate = DateTime.Parse(datetime, culture);

                            if (AdjustToLocalTime) {
                                DateTime utcDateTime = DateTime.SpecifyKind(data.TradeDate.AddHours(5), DateTimeKind.Utc);
                                data.TradeDate = utcDateTime.ToLocalTime();
                                if (data.TradeDate.IsDaylightSavingTime()) {
                                    TimeSpan ts = new TimeSpan(1, 0, 0);
                                    data.TradeDate = data.TradeDate.Subtract(ts);
                                }
                            }

                            try {
                                if (fields[(int)DataFieldNames.MinPrice].Equals(NA, StringComparison.InvariantCultureIgnoreCase))
                                    data.Min = 0;
                                else
                                    data.Min = Double.Parse(fields[(int)DataFieldNames.MinPrice], culture);
                            }
                            catch (Exception) {
                                data.Min = 0;
                                throw;
                            }

                            try {
                                if (fields[(int)DataFieldNames.MaxPrice].Equals(NA, StringComparison.InvariantCultureIgnoreCase))
                                    data.Max = 0;
                                else
                                    data.Max = Double.Parse(fields[(int)DataFieldNames.MaxPrice], culture);
                            }
                            catch (Exception) {
                                data.Max = 0;
                                throw;
                            }

                            Result.Add(data);
                        }

                        return Result;
                    }
                    finally {
                        respReader.Close();
                    }
                }
                finally {
                    respStream.Close();
                }
            }
            finally {
                resp.Close();
            }
        }

        private void CheckParams(Currency data) {
            if (data.BaseCode.Length == 0)
                throw new ArgumentNullException("data.BaseCode", "Base currency code is not specified!");

            if (data.TargetCode.Length == 0)
                throw new ArgumentNullException("data.TargetCode", "Target currency code is not specified!");

            if (data.BaseCode.Equals(data.TargetCode))
                throw new ArgumentException("data.BaseCode, data.TargetCode", "Base currency code is equal to Target code!");
        }

        #endregion

        #region Enums

        private enum DataFieldNames : byte { CurrencyCodes = 0, CurrentRate, TradeDate, TradeTime, MinPrice, MaxPrice }

        #endregion

    }
}
