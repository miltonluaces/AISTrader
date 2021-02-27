#region Imports

using System;
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
using BusinessModel;
using System.Threading;

#endregion

namespace Trading {

    public class TSBuilder : DBJob {

        #region Fields

        private List<TSeries> timeSeries;
        private Parameter paramClosure;
        private bool trace;
        private DateTime iniDate;
        #endregion

        #region Constructor

        public TSBuilder() : base() {
            Initialize();
            iniDate = new DateTime(2013, 1, 1); //TODO: parameter
        }

        #endregion

        #region Properties

        public bool Trace {
            get { return trace; }
            set { trace = value; }
        }

        public List<TSeries> TimeSeries {
            get { return timeSeries; }
        }

        #endregion

        #region Public Methods

        public void Closure() {
            DataRowCollection rows = GetDataRowColDmds(iniDate);
            timeSeries = GenTimeSeries(rows);
            foreach (TSeries ts in timeSeries) { ts.SaveUpdate(); }
        }

        public TSeries Closure(Stock stock, DateTime lastClosure) {
            DataRowCollection rows = GetDataRowColDmds(stock, lastClosure);
            TSeries ts = GenTimeSerie(rows);
            ts.SaveUpdate();
            return ts;
        }

        #endregion

        #region Private Methods

        #region Build Methods

        //Lectura de Rows de demandas
        private DataRowCollection GetDataRowColDmds(DateTime iniDate) {
            set = new DataSet();
            string query = "SELECT * FROM AisMarketData WHERE date > " + GetDateStr(iniDate) + " ORDER BY stockId, date";
            try {
                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: adapter = new SqlDataAdapter(query, (SqlConnection)conn); break;
                    case SysEnvironment.Provider.Access: adapter = new OleDbDataAdapter(query, (OleDbConnection)conn); break;
                }
                conn.Open();
                adapter.Fill(set);
                if (set.Tables[0].Rows.Count == 0) { return null; }
                return set.Tables[0].Rows;
            }
            catch (Exception ex) { Console.WriteLine("Error" + ex.StackTrace); return null; }
            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        private DataRowCollection GetDataRowColDmds(Stock stock, DateTime lastDate) {
            set = new DataSet();
            string query = "SELECT * FROM AisMarketData WHERE stockId = " + stock.Id + " AND date > " + GetDateStr(lastDate) + " ORDER BY date";
            try {
                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: adapter = new SqlDataAdapter(query, (SqlConnection)conn); break;
                    case SysEnvironment.Provider.Access: adapter = new OleDbDataAdapter(query, (OleDbConnection)conn); break;
                }
                conn.Open();
                adapter.Fill(set);
                if (set.Tables[0].Rows.Count == 0) { return null; }
                return set.Tables[0].Rows;
            }
            catch (Exception ex) { Console.WriteLine("Error" + ex.StackTrace); return null; }
            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        //Generacion de Time series en base a las Rows de Demandas
        public List<TSeries> GenTimeSeries(DataRowCollection rows) {
            List<TSeries> tSeries = new List<TSeries>();
            TSeries ts = new TSeries();
            ts.Stock = new Stock(0);
            ulong stockId;
            DateTime date = DateTime.MinValue; 
            DateTime expNext = DateTime.MaxValue;
            double open, low, high, close;
            ulong volume;
            for (int i = 0; i <= rows.Count - 1; i++) {
                DataRow row = rows[i];
                stockId = Convert.ToUInt64(row["stockId"]);
                date = Convert.ToDateTime(row["date"]);
                open = Convert.ToDouble(row["openVal"]);
                low = Convert.ToDouble(row["low"]);
                high = Convert.ToDouble(row["high"]);
                close = Convert.ToDouble(row["closeVal"]);
                volume = Convert.ToUInt64(row["volume"]);
                if (stockId != ts.Stock.Id) {
                    if (i > 0) { Debug.WriteLine("Generada serie " + ts.Stock.Code + "\t(" + ts.IniHist.ToShortDateString() + " - " + ts.EndHist.ToShortDateString() + ")"); }
            
                    ts = new TSeries();
                    Stock stock = new Stock(stockId);
                    stock.Read();
                    ts.Id = stockId;
                    ts.Code = stock.Code;
                    ts.Stock = stock;
                    ts.Read("stockId", stockId);
                    ts.Stock = stock;
                    ts.Open = new List<double>();
                    ts.Low = new List<double>();
                    ts.High = new List<double>();
                    ts.Close = new List<double>();
                    ts.Volume = new List<ulong>();
                    ts.IniHist = date;
                    ts.EndHist = date;
                    ts.Open.Add(open);
                    ts.Low.Add(low);
                    ts.High.Add(high);
                    ts.Close.Add(close);
                    ts.Volume.Add(volume);
                    tSeries.Add(ts);
                    expNext = date.AddDays(1);
                }
                else {
                    while (date > expNext) {
                        ts.Open.Add(-1);
                        ts.Low.Add(-1);
                        ts.High.Add(-1);
                        ts.Close.Add(-1);
                        ts.Volume.Add(0);
                        expNext = expNext.AddDays(1); 
                    }
                    ts.Open.Add(open);
                    ts.Low.Add(low);
                    ts.High.Add(high);
                    ts.Close.Add(close);
                    ts.Volume.Add(volume);
                    ts.EndHist = date;
                    expNext = expNext.AddDays(1); 
                }
            }
            Debug.WriteLine("Generada serie " + ts.Stock.Code + "\t(" + ts.IniHist.ToShortDateString() + " - " + ts.EndHist.ToShortDateString() + ")");
            return tSeries;
        }

        //Generacion de Time series en base a las Rows de Demandas
        public TSeries GenTimeSerie(DataRowCollection rows) {
            TSeries ts = new TSeries();
            bool firstLine = true;
            ulong stockId;
            DateTime date;
            DateTime expNext = DateTime.MaxValue;
            double open, low, high, close;
            ulong volume;
            for (int i = 0; i <= rows.Count - 1; i++) {
                DataRow row = rows[i];
                stockId = Convert.ToUInt64(row["stockId"]);
                date = Convert.ToDateTime(row["date"]);
                open = Convert.ToDouble(row["openVal"]);
                low = Convert.ToDouble(row["low"]);
                high = Convert.ToDouble(row["high"]);
                close = Convert.ToDouble(row["closeVal"]);
                volume = Convert.ToUInt64(row["volume"]);
                if (firstLine) {
                    ts = new TSeries();
                    Stock stock = new Stock(stockId);
                    stock.Read();
                    ts.Id = stockId;
                    ts.Code = stock.Code;
                    ts.Stock = stock;
                    ts.Read("stockId", stockId);
                    ts.Open = new List<double>();
                    ts.Low = new List<double>();
                    ts.High = new List<double>();
                    ts.Close = new List<double>();
                    ts.Volume = new List<ulong>();
                    ts.IniHist = date;
                    ts.EndHist = DateTime.Now;
                    ts.Open.Add(open);
                    ts.Low.Add(low);
                    ts.High.Add(high);
                    ts.Close.Add(close);
                    ts.Volume.Add(volume);
                    expNext = date.AddDays(1);
                    firstLine = false;
                    Debug.WriteLine("Generada serie " + ts.Stock);
                }
                else {
                    while (date > expNext) {
                        ts.Open.Add(-1);
                        ts.Low.Add(-1);
                        ts.High.Add(-1);
                        ts.Close.Add(-1);
                        ts.Volume.Add(0);
                        expNext = expNext.AddDays(1);
                    }
                    ts.Open.Add(open);
                    ts.Low.Add(low);
                    ts.High.Add(high);
                    ts.Close.Add(close);
                    ts.Volume.Add(volume);
                    expNext = expNext.AddDays(1);
                }
            }
            return ts;
        }

        #endregion

        #region Auxiliar Methods

        private string GetDateStr(DateTime date) {
            return "'" + date.Year + (date.Month.ToString().Length == 1 ? "0" : "") + date.Month + (date.Day.ToString().Length == 1 ? "0" : "") + date.Day + "'";
        }

        internal string GetTimeStr(DateTime date) {
            return "'" + date.Hour + ":" + date.Minute + "'";
        }

        private void WriteLog(string log) {
            if (trace) { Console.WriteLine(log); }
        }

        #endregion

        #endregion

    }
}
