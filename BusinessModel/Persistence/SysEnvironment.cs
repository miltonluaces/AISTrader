#region Imports

using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Configuration;
using System.Resources;
using System.Reflection;
using System.Text;
using System.ComponentModel;
using System.Linq;

#endregion

namespace BusinessModel {

    public class SysEnvironment {

        #region Singleton

        private static SysEnvironment se;
        private Config config;
        private SysLog sysLog;

        private SysEnvironment() {
            config = new Config();
            config.Database = "Sys";
            sysLog = new SysLog();
        }

        public static SysEnvironment GetInstance() {
            if (se == null) { se = new SysEnvironment(); }
            return se;
        }

        #endregion

        #region Fields

        private bool test;
        private bool loggedOn;
        private Stock.CurrencyType currency;
        private Dictionary<string, Parameter> parameters;

        private Dictionary<string, Stock> stocks;
        private Dictionary<ulong, Client> clients;
        private Dictionary<Stock.CurrencyType, Dictionary<Stock.CurrencyType, double>> currencies;

        #endregion

        #region Properties

        public string DatabaseName {
            get { return config.Database; }
            set { config.Database = value; }
        }

        public Stock.CurrencyType Currency {
            get { return currency; }
            set { currency = value; }
        }

        public Dictionary<Stock.CurrencyType, Dictionary<Stock.CurrencyType, double>> Currencies {
            get { return currencies; }
            set { currencies = value; }
        }
        
        public double GetCurrency(Stock.CurrencyType currencyFrom, Stock.CurrencyType currencyTo) {
            return currencies[currencyTo][currencyFrom];
        }
        
        public Provider DatabaseProvider {
            get {
                switch (ConfigurationManager.ConnectionStrings[config.Database].ProviderName) {
                    case "System.Data.SqlClient": return Provider.SqlServer;
                    case "Oracle": return Provider.Oracle;
                    case "Postgre": return Provider.Postgre;
                    case "Access": return Provider.Access;
                    default: return Provider.SqlServer;
                }
                return Provider.SqlServer;
            }
        }

        public string DatabaseConnStr {
            get {
                if (ConfigurationManager.ConnectionStrings[config.Database] == null) { return ""; }
                return ConfigurationManager.ConnectionStrings[config.Database].ConnectionString;
            }
        }

        public bool Test {
            get { return test; }
            set { test = value; }
        }

        public bool LoggedOn {
            get { return loggedOn; }
            set { loggedOn = value; }
        }

        public SysLog SysLog {
            get { return sysLog; }
        }

        public Dictionary<string, string> GetMailList() {
            Dictionary<string, string> mails = new Dictionary<string, string>();
            string mailList = ConfigurationManager.AppSettings["mailList"];
            char sep1 = ';';
            char sep2 = ',';
            string[] members = mailList.Split(sep1);
            foreach (string member in members) {
                string[] tokens = member.Split(sep2);
                mails.Add(tokens[0], tokens[1]);
            }
            return mails;
        }

        public Dictionary<string, Stock> Stocks {
            get { return stocks; }
            set { stocks = value; }
        }

        public Dictionary<ulong, Client> Clients {
            get { return clients; }
            set { clients = value; }
        }
        
        #endregion

        #region Public Methods

        public Dictionary<string, Parameter> Parameters {
            get { return parameters; }
            set { parameters = value; }
        }

        public Parameter GetParameter(string code) {
            if (!parameters.ContainsKey(code)) { throw new Exception("Error"); }
            return parameters[code];
        }
        
        public DateTime GetDate(string dateStr) {
            if (dateStr == null || dateStr == "") { return new DateTime(1900, 1, 1); }
            DateTime date;
            try { date = Convert.ToDateTime(dateStr); }
            catch { date = new DateTime(1900, 1, 1); }
            return date;
        }

        public double GetDouble(object doubleStr) {
            if (doubleStr == null || doubleStr.ToString() == "") { return -1; }
            return Convert.ToDouble(doubleStr);
        }

        public int GetInt(object intStr) {
            if (intStr == null || intStr.ToString() == "") { return -1; }
            return (int)(intStr);
        }

        public ulong GetUlong(object ulongStr) {
            if (ulongStr == null || ulongStr.ToString() == "") { return 0; }
            return Convert.ToUInt64(ulongStr);
        }

        public bool GetBoolean(object boolStr) {
            int boolInt = GetInt(boolStr);
            return (boolInt == 1);
        }


        #endregion

        #region Public enum

        public enum Provider { SqlServer, Oracle, Postgre, Access };
       
        #endregion


    }
}
