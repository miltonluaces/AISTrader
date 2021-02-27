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
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace Trading {

    public class DataSaver : DBJob {

        #region Fields

        #endregion

        #region Constructor

        public DataSaver() {
        }

        #endregion

        #region Public Methods

        public List<string> GenMarketQueries(ulong stockId, List<List<string>> marketData) {
            List<string> queries = new List<string>();
            string query;
            for (int i = 1; i < marketData.Count; i++) {
                query = "INSERT INTO AisMarketData (stockId, date, openVal, high, low, closeVal, volume, adjClose) VALUES (" +
                stockId + ",'" + FixDate(marketData[i][0]) + "'," + marketData[i][1] + "," + marketData[i][2] + "," + marketData[i][3] + "," + marketData[i][4] + "," + marketData[i][5] + "," + marketData[i][6] + ")";
                queries.Add(query);
            }
            return queries;
        }

        private string FixDate(string date) {
            string fixedDate = date.Replace("-", "");
            return fixedDate;
        }

        public void SaveMarketData(List<string> queries) {
            Console.WriteLine("Saving Market data...");
            this.Initialize();

            try {
                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: conn = new SqlConnection(dbConnStr); break;
                    case SysEnvironment.Provider.Oracle: conn = new OleDbConnection(dbConnStr); break;
                    case SysEnvironment.Provider.Postgre: conn = new OleDbConnection(dbConnStr); break;
                    case SysEnvironment.Provider.Access: conn = new OleDbConnection(dbConnStr); break;
                }
            }
            catch (Exception ex) { Console.WriteLine("Could not create connection" + ex.StackTrace); return; }

            try {
                conn.Open();
                foreach (string query in queries) {
                    switch (dbProvider) {
                        case SysEnvironment.Provider.SqlServer: cmd = new SqlCommand(query, (SqlConnection)conn); break;
                        case SysEnvironment.Provider.Oracle: cmd = new OleDbCommand(query, (OleDbConnection)conn); break;
                        case SysEnvironment.Provider.Postgre: cmd = new OleDbCommand(query, (OleDbConnection)conn); break;
                        case SysEnvironment.Provider.Access: cmd = new OleDbCommand(query, (OleDbConnection)conn); break;
                    }
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Market data saved");
            }

            catch (Exception ex) { Console.WriteLine("Error. Could not create database" + ex.StackTrace); }
            finally { if (conn.State == ConnectionState.Open) { conn.Close(); } }
        }
        
        #endregion

    }
}
