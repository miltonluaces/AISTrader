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
using System.Linq;
using System.Text;

#endregion

namespace BusinessModel {

    public abstract class Broker : DBJob {

        #region Fields

        protected int uFieldCount;

        #endregion

        #region Constructor

        public Broker() : base() {
            Initialize();
            uFieldCount = 0;
        }

        #endregion

        #region Properties

        public int UFieldCount {
            get { return uFieldCount; }
            set { uFieldCount = value; }
        }

        #endregion

        #region Public Methods

        public void Initialize() {
            SysEnvironment sysEnv = SysEnvironment.GetInstance();
            sysEnv.DatabaseName = "Sys";
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

        
        public void SaveUpdate(DbObject dbObj) {
            try {
                set = new DataSet();
                string tableName = this.GetTableName();
                string query = "SELECT * FROM " + tableName + " WHERE id = " + dbObj.Id;
                conn.Open();

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer:
                        adapter = new SqlDataAdapter();
                        adapter.SelectCommand = new SqlCommand(query, (SqlConnection)conn);
                        builder = new SqlCommandBuilder((SqlDataAdapter)adapter);
                        break;
                    case SysEnvironment.Provider.Access:
                        adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = new OleDbCommand(query, (OleDbConnection)conn);
                        builder = new OleDbCommandBuilder((OleDbDataAdapter)adapter);
                        break;
                }
                adapter.Fill(set, tableName);

                if (set.Tables[0].Rows.Count == 0) {
                    DataRow newRow = set.Tables[0].NewRow();
                    this.ObjASet(dbObj, newRow);
                    set.Tables[0].Rows.Add(newRow);
                }
                else if (set.Tables[0].Rows.Count == 1) {
                    this.ObjASet(dbObj, set.Tables[0].Rows[0]);
                }
                else {
                    throw new Exception("Error.");
                }
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(set, tableName);
            }

            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            finally {
                try {
                    conn.Close();
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        public void Read(DbObject dbObj) {
            try {
                //set = this.GetSet();
                set = new DataSet();
                string tableName = this.GetTableName();
                string query = "SELECT * FROM " + tableName + " WHERE id = " + dbObj.Id;

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: adapter = new SqlDataAdapter(query, (SqlConnection)conn); break;
                    case SysEnvironment.Provider.Access: adapter = new OleDbDataAdapter(query, (OleDbConnection)conn); break;
                }
                conn.Open();
                adapter.Fill(set);

                if (set.Tables[0].Rows.Count == 1) {
                    this.SetAObj(set.Tables[0].Rows[0], dbObj);
                }
                else {
                    throw new Exception("Error. Number of registers different from one : " + this.GetSet().Tables[0].Rows.Count);
                }

            }
            catch (Exception ex) { /*throw new Exception("Error", ex);*/ }
            finally {
                try {
                    conn.Close();
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        public void Read(DbObject dbObj, string fieldName, ulong id) {
            try {
                set = new DataSet();
                string tableName = this.GetTableName();
                string query = "SELECT * FROM " + tableName + " WHERE " + fieldName + "=" + id;

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: adapter = new SqlDataAdapter(query, (SqlConnection)conn); break;
                    case SysEnvironment.Provider.Access: adapter = new OleDbDataAdapter(query, (OleDbConnection)conn); break;
                }
                conn.Open();
                adapter.Fill(set);

                if (set.Tables[0].Rows.Count == 1) { this.SetAObj(set.Tables[0].Rows[0], dbObj); }
                else { throw new Exception("Error. Number of registers different from one : " + this.GetSet().Tables[0].Rows.Count); }

            }
            catch (Exception ex) { /*throw new Exception("Error", ex);*/ }
            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        public void Read(DbObject dbObj, string condition) {
            try {
                set = new DataSet();
                string tableName = this.GetTableName();
                string query = "SELECT * FROM " + tableName + " WHERE " + condition;

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: adapter = new SqlDataAdapter(query, (SqlConnection)conn); break;
                    case SysEnvironment.Provider.Access: adapter = new OleDbDataAdapter(query, (OleDbConnection)conn); break;
                }
                conn.Open();
                adapter.Fill(set);

                if (set.Tables[0].Rows.Count == 1) { this.SetAObj(set.Tables[0].Rows[0], dbObj); }
                else { throw new Exception("Error. Number of registers different from one : " + this.GetSet().Tables[0].Rows.Count); }

            }
            catch (Exception ex) { /*throw new Exception("Error", ex);*/ }
            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        public void Delete(DbObject dbObj) {
            try {
                string query = "DELETE FROM " + GetTableName() + " WHERE id=" + dbObj.Id;

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer:
                        cmd = new SqlCommand(query, (SqlConnection)conn); adapter = new SqlDataAdapter(); break;
                    case SysEnvironment.Provider.Access:
                        cmd = new OleDbCommand(query, (OleDbConnection)conn); adapter = new OleDbDataAdapter(); break;
                }
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }

            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        public void Delete(DbObject dbObj, string condition) {
            try {
                string query = "DELETE FROM " + GetTableName() + " WHERE " + condition;

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer:
                        cmd = new SqlCommand(query, (SqlConnection)conn); adapter = new SqlDataAdapter(); break;
                    case SysEnvironment.Provider.Access:
                        cmd = new OleDbCommand(query, (OleDbConnection)conn); adapter = new OleDbDataAdapter(); break;
                }
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }

            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }


        public void ReadMany(List<DbObject> objs, string condition) {
            if (condition == "") { condition = "1=1"; }
            try {
                set = new DataSet();
                string tableName = this.GetTableName();
                string query = "SELECT * FROM " + tableName + " WHERE " + condition;

                switch (dbProvider) {
                    case SysEnvironment.Provider.SqlServer: adapter = new SqlDataAdapter(query, (SqlConnection)conn); break;
                    case SysEnvironment.Provider.Access: adapter = new OleDbDataAdapter(query, (OleDbConnection)conn); break;
                }

                conn.Open();
                adapter.Fill(set);

                if (set.Tables[0].Rows.Count > 0) { this.SetAObjs(set.Tables[0].Rows, objs); }
            }
            catch (Exception ex) { /*throw new Exception("Error", ex);*/ }
            finally {
                try {
                    conn.Close();
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }

        #endregion

        #region Virtual Methods

        //metodos virtuales
        public void saveReferences(DbObject dbObj) { }
        public void readReferences(DbObject dbObj) { }

        //helpers
        public virtual void ObjASet(DbObject obj, DataRow row) { }
        public virtual void SetAObj(DataRow row, DbObject obj) { }
        public virtual void SetAObjs(DataRowCollection rows, List<DbObject> objs) { }
        public virtual DataSet GetSet() { return null; }
        protected virtual string GetTableName() { return null; }
        protected virtual string GetPrimaryKey() { return null; }

        #endregion

        #region Auxiliar Methods

        public DateTime GetDate(object dateObj) {
            if (dateObj == null || dateObj.ToString() == "") { return new DateTime(1900, 1, 1); }
            DateTime date;
            try { date = ((DateTime)dateObj).Date; }
            catch { date = new DateTime(1900, 1, 1); }
            return date;
        }

        public double GetDouble(object doubleObj) {
            if (doubleObj == null || doubleObj.ToString() == "") { return -1; }
            return Convert.ToDouble(doubleObj);
        }

        public int GetInt(object intObj) {
            if (intObj == null || intObj.ToString() == "") { return -1; }
            return (int)(intObj);
        }

        public ulong GetUlong(object ulongObj) {
            if (ulongObj == null || ulongObj.ToString() == "") { return 0; }
            return Convert.ToUInt64(ulongObj);
        }

        public bool GetBoolean(object boolObj) {
            int boolInt = GetInt(boolObj);
            return (boolInt == 1);
        }

        public string GetString(object strObj) {
            if (strObj == null) { return ""; }
            return strObj.ToString();
        }

        #endregion

    }
}