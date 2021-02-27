#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Configuration;
using System.Resources;
using System.Reflection;
using System.Runtime.Serialization;
using System.Data.Sql;
using System.Data.SqlClient;

#endregion

namespace BusinessModel {

    public class BrkrTSeries : Broker {

        #region Fields

        #endregion

        #region Constructor

        public BrkrTSeries() : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisTSeries";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((TSeries)obj).Id.ToString();
            row["code"] = ((TSeries)obj).Code;
            row["stockId"] = ((TSeries)obj).Stock.Id;
            row["iniHist"] = ((TSeries)obj).IniHist;
            row["endHist"] = ((TSeries)obj).EndHist;
            row["openVal"] = ((TSeries)obj).GetString(((TSeries)obj).Open);
            row["low"] = ((TSeries)obj).GetString(((TSeries)obj).Low);
            row["high"] = ((TSeries)obj).GetString(((TSeries)obj).High);
            row["closeVal"] = ((TSeries)obj).GetString(((TSeries)obj).Close);
            row["volume"] = ((TSeries)obj).GetString(((TSeries)obj).Volume);
            row["fcst"] = ((TSeries)obj).GetString(((TSeries)obj).Fcst);
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((TSeries)obj).Id = GetUlong(row["id"]);
            ((TSeries)obj).Code = row["code"].ToString();
            ulong stockId = GetUlong(row["stockId"]);
            ((TSeries)obj).Stock = new Stock(stockId);
            ((TSeries)obj).IniHist = GetDate(row["iniHist"]);
            ((TSeries)obj).EndHist = GetDate(row["endHist"]);
            string openStr = row["openVal"].ToString();
            ((TSeries)obj).Open = ((TSeries)obj).GetValues(openStr);
            string lowStr = row["low"].ToString();
            ((TSeries)obj).Low = ((TSeries)obj).GetValues(lowStr);
            string highStr = row["high"].ToString();
            ((TSeries)obj).High = ((TSeries)obj).GetValues(highStr);
            string closeStr = row["closeVal"].ToString();
            ((TSeries)obj).Close = ((TSeries)obj).GetValues(closeStr);
            string volumeStr = row["volume"].ToString();
            ((TSeries)obj).Volume = ((TSeries)obj).GetUlongValues(volumeStr);
            string fcstStr = row["fcst"].ToString();
            ((TSeries)obj).Fcst = ((TSeries)obj).GetValues(fcstStr);
            ((TSeries)obj).Creation = ((DateTime)row["creation"]).Date;
        }


        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            TSeries obj;
            foreach (DataRow row in rows) {
                obj = new TSeries();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion
    }
}
