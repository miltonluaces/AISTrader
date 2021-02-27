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

#endregion

namespace BusinessModel {

    public class DBJob {

        #region Fields

        protected string connStr;
        protected string dbName;
        protected SysEnvironment.Provider dbProvider;
        protected string dbConnStr;
        protected DbConnection conn;
        protected DbCommand cmd;
        protected DbDataAdapter adapter;
        protected DataSet set;
        protected DbCommandBuilder builder;

        #endregion

        #region Constructor

        public DBJob() {
        }

        #endregion

        #region Public Methods


        public void Initialize() {
            SysEnvironment sysEnv = SysEnvironment.GetInstance();
            dbName = sysEnv.DatabaseName;
            dbProvider = sysEnv.DatabaseProvider;
            dbConnStr = sysEnv.DatabaseConnStr;
            set = new DataSet();
            try {
                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: conn = new SqlConnection(dbConnStr); break;
                    case SysEnvironment.Provider.Oracle: conn = new OleDbConnection(dbConnStr); break;
                    case SysEnvironment.Provider.Postgre: conn = new OleDbConnection(dbConnStr); break;
                    case SysEnvironment.Provider.Access: conn = new OleDbConnection(dbConnStr); break;
                }
            }

            catch (Exception ex) {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
            }
        }

        #endregion

    }
}
