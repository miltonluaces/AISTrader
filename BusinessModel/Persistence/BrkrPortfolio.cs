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

#endregion

namespace BusinessModel {

    public class BrkrPortfolio : Broker {

        #region Fields
        #endregion

        #region Constructor

        public BrkrPortfolio()
            : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisPortfolio";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((Portfolio)obj).Id.ToString();
            row["code"] = ((Portfolio)obj).Code;
            row["name"] = ((Portfolio)obj).Name;
            row["clientId"] = ((Portfolio)obj).Client.Id;
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((Portfolio)obj).Id = GetUlong(row["id"]);
            ((Portfolio)obj).Code = row["code"].ToString();
            ((Portfolio)obj).Name = row["name"].ToString();
            ulong clientId = GetUlong(row["clientId"]);
            ((Portfolio)obj).Client = new Client(clientId);
            ((Portfolio)obj).Creation = ((DateTime)row["creation"]).Date;
        }

        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            Portfolio obj;
            foreach (DataRow row in rows) {
                obj = new Portfolio();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion
    }
}
