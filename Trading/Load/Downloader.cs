#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using BusinessModel;
using System.Data;
using System.Configuration;

#endregion

namespace Trading {

    public class Downloader {

        #region Fields

        private WebClient webClient;
    
        #endregion

        #region Constructor

        public Downloader() {
            webClient = new WebClient();
        }

        #endregion

        #region Public Methods

        public List<List<string>> ReadMarketData(Stock stock) {
            switch (stock.Source) {
                case "YFin": return ReadDataFromYFin(stock.Code, stock.Date);
                case "YCurr": return ReadDataFromYCurr(stock.Code);
                case "Eod": return ReadDataFromEod(stock.Code, stock.Date);
                case "Manual": return null;
                default: throw new Exception("Error. Source not found");
            }
        }
        
        #region Yahoo Finance

        public List<List<string>> ReadDataFromYFin(string stockCode, DateTime lastDate) {

            DateTime iniDate = lastDate.AddDays(1);
            DateTime endDate = DateTime.Now.AddYears(1);  //TODO: corregir año

            string urlTemplate = @"http://ichart.finance.yahoo.com/table.csv?s={0}&d={1}&e={2}&f={3}&g={4}&a={5}&b={6}&c={7}&&ignore=.csv";
            string url = string.Format(urlTemplate, stockCode, endDate.Month - 1, endDate.Day, endDate.Year, "d", iniDate.Month - 1, iniDate.Day, iniDate.Year);
       
            
            List<char> cs = new List<char>();
            char c;
            string s;
            List<List<string>> lines = new List<List<string>>();
            List<string> ss = new List<string>();
            byte[] stream = null;
            try { stream = webClient.DownloadData(url); }
            catch (Exception ex) { return null; }
            if (stream == null) { return null; }

            foreach (byte b in stream) {
                if (b == ',' || b == '\n') {
                    s = new string(cs.ToArray());
                    ss.Add(s);
                    cs.Clear();
                    if (b == '\n') {
                        lines.Add(ss);
                        ss = new List<string>();
                    }
                }
                else {
                    c = Convert.ToChar(b);
                    cs.Add(c);
                }
            }
            return lines;
        }

        public List<List<string>> ReadDataFromYCurr(string currencies) {

            string urlTemplate = @"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=l1";
            string url = string.Format(urlTemplate, currencies);

            List<char> cs = new List<char>();
            char c;
            string s;
            List<List<string>> lines = new List<List<string>>();
            List<string> ss = new List<string>();
            byte[] stream = null;
            try { stream = webClient.DownloadData(url); }
            catch (Exception ex) { return null; }
            if (stream == null) { return null; }

            foreach (byte b in stream) {
                if (b == ',' || b == '\n') {
                    s = new string(cs.ToArray());
                    ss.Add(s);
                    cs.Clear();
                    if (b == '\n') {
                        lines.Add(ss);
                        ss = new List<string>();
                    }
                }
                else {
                    c = Convert.ToChar(b);
                    cs.Add(c);
                }
            }
            return lines;
        }

        #endregion

        #region Eod

        public List<List<string>> ReadDataFromEod(string stockCode, DateTime lastDate) {
            //TODO: refactoring para eod

            DateTime iniDate = lastDate.AddDays(1);  
            DateTime endDate = DateTime.Now.AddYears(1);  //TODO: corregir año

            string urlTemplate = @"http://ichart.finance.yahoo.com/table.csv?s={0}&d={1}&e={2}&f={3}&g={4}&a={5}&b={6}&c={7}&&ignore=.csv";
            string url = string.Format(urlTemplate, stockCode, endDate.Month - 1, endDate.Day, endDate.Year, "d", iniDate.Month - 1, iniDate.Day, iniDate.Year);

            List<char> cs = new List<char>();
            char c;
            string s;
            List<List<string>> lines = new List<List<string>>();
            List<string> ss = new List<string>();
            byte[] stream = null;
            try {
                stream = webClient.DownloadData(url);
                Console.WriteLine(stockCode + " Data downloaded Ok");
            }
            catch { return null; }
            if (stream == null) { return null; }

            foreach (byte b in stream) {
                if (b == ',' || b == '\n') {
                    s = new string(cs.ToArray());
                    ss.Add(s);
                    cs.Clear();
                    if (b == '\n') {
                        lines.Add(ss);
                        ss = new List<string>();
                    }
                }
                else {
                    c = Convert.ToChar(b);
                    cs.Add(c);
                }
            }
            return lines;
        }

        #endregion

        #region Manual

        public Dictionary<string, double> ReadDataFromManual() {
            ExcelReader er = new ExcelReader();
            Dictionary<string, double> manualData = er.ReadManualData("Funds");
            return manualData;
        }

        private double GetDouble(string doubleStr) {
            double dou = -1;
            try { dou = Convert.ToDouble(doubleStr); }
            catch { dou = -1; }
            return dou;
        }

        #endregion

        #region Other downloads

        public Dictionary<Stock.CurrencyType, double> ReadCurrencies() {
            Dictionary<Stock.CurrencyType, double> currencies = new Dictionary<Stock.CurrencyType, double>();
            currencies.Add(Stock.CurrencyType.USD, 1);


            return currencies;
        }

        #endregion



        #endregion

    }
}
