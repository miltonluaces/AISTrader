#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace BusinessModel {

    public class TSeries : DbObject {

        #region Fields

        private Stock stock;
        private DateTime iniHist;
        private DateTime endHist;
        private List<double> open;
        private List<double> low;
        private List<double> high;
        private List<double> close;
        private List<double> fcst;
        private List<ulong> volume;
        private char separator;
        private string separatorStr;

        #endregion

        #region Constructors

        public TSeries() : base() {
            separator = ' ';
            separatorStr = " ";
        }

        public TSeries(Stock stock, DateTime iniHist) : base() {
            this.stock = stock;
            this.iniHist = iniHist;
            this.open = new List<double>();
            this.low = new List<double>();
            this.high = new List<double>();
            this.close = new List<double>();
            this.volume = new List<ulong>();
        }

        #endregion

        #region Properties

        public Stock Stock {
            get { return stock; }
            set { stock = value; }
        }

        public DateTime IniHist {
            get { return iniHist; }
            set { iniHist = value; }
        }

        public DateTime EndHist {
            get { return endHist; }
            set { endHist = value; }
        }

        public DateTime IniFcst {
            get { return endHist.AddDays(1); }
        }

        public DateTime EndFcst {
            get { return IniFcst.AddDays(fcst.Count - 1); }
        }

        public List<double> Open {
            get { return open; }
            set { open = value; }
        }

        public List<double> Low {
            get { return low; }
            set { low = value; }
        }

        public List<double> High {
            get { return high; }
            set { high = value; }
        }

        public List<double> Close {
            get { return close; }
            set { close = value; }
        }
        
        public List<double> Fcst {
            get { return fcst; }
            set { fcst = value; }
        }

        public List<ulong> Volume {
            get { return volume; }
            set { volume = value; }
        }
        
        #endregion

        #region Public Methods

        #region Getters

        public double GetOpen(int index) {  return open[index];  }
        public double GetLow(int index) { return low[index]; }
        public double GetHigh(int index) { return high[index]; }
        public double GetClose(int index) { return close[index]; }
        public ulong GetVolume(int index) {  return volume[index]; }

        public double GetOpen(DateTime date) {
            int index = date.Subtract(iniHist).Days;
            return open[index];
        }
        public double GetLow(DateTime date) {
            int index = date.Subtract(iniHist).Days;
            return low[index];
        }
        public double GetHigh(DateTime date) {
            int index = date.Subtract(iniHist).Days;
            return high[index];
        }
        public double GetClose(DateTime date) {
            int index = date.Subtract(iniHist).Days;
            return close[index];
        }
        public ulong GetVolume(DateTime date) {
            int index = date.Subtract(iniHist).Days;
            return volume[index];
        }

        public char Separator { get; set; }

        #endregion

        #region Main Methods

        #endregion

        #endregion

        #region Private Methods

        private List<double> SetSpanHist(List<double> hist, int span) {
            if (hist.Count == 0) { throw new Exception("Error. dayHist not loaded"); }

            double maxRatioForExtrap = 0.2;
            List<double> spanHist = new List<double>();
            int day = 0;
            double spanTot = 0.0;
            double val;
            int nonZero = 0;
            for (int i = hist.Count - 1; i >= 0; i--) {
                val = hist[i];
                spanTot += val;
                day++;
                if (day == span) {
                    spanHist.Insert(0, spanTot);
                    day = 0;
                    spanTot = 0;
                }
            }
            if (day > 0 && spanHist.Count > 0 && 1 / spanHist.Count > maxRatioForExtrap) {
                spanHist.Insert(0, spanTot * ((double)span / (double)(day)));
            }
            return spanHist;
        }
        
        #endregion

        #region Persistence

        public override Broker GetBroker() { return BrkrMgr.GetInstance().GetBroker((TSeries)this); }

        public string GetString(List<double> values) {
            if (values == null) { return ""; }
            StringBuilder dataStr = new StringBuilder();
            for (int i = 0; i < values.Count; i++) { dataStr.Append(values[i] + separatorStr); }
            return dataStr.ToString();
        }

        public List<double> GetValues(string valuesStr) {
            List<double> values = new List<double>();
            string[] tokens = valuesStr.Split(separator);
            double value;
            for (int i = 0; i < tokens.Length; i++) {
                if (tokens[i] == "") { continue; }
                value = Convert.ToDouble(tokens[i]);
                values.Add(value);
            }
            return values;
        }

        public string GetString(List<ulong> values) {
            if (values == null) { return ""; }
            StringBuilder dataStr = new StringBuilder();
            for (int i = 0; i < values.Count; i++) { dataStr.Append(values[i] + separatorStr); }
            return dataStr.ToString();
        }

        public List<ulong> GetUlongValues(string valuesStr) {
            List<ulong> values = new List<ulong>();
            string[] tokens = valuesStr.Split(separator);
            ulong value;
            for (int i = 0; i < tokens.Length; i++) {
                if (tokens[i] == "") { continue; }
                value = (ulong) Convert.ToUInt32(tokens[i]);
                values.Add(value);
            }
            return values;
        }


        #endregion

    }
}
