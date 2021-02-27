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

    public class BrkrClient : Broker {

        #region Fields
        #endregion

        #region Constructor

        public BrkrClient() : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisClient";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((Client)obj).Id.ToString();
            row["code"] = ((Client)obj).Code;
            row["name"] = ((Client)obj).Name;
            row["address"] = ((Client)obj).Address;
            row["city"] = ((Client)obj).City;
            row["phone"] = ((Client)obj).Phone;
            row["mail1"] = ((Client)obj).Mail1;
            row["mail2"] = ((Client)obj).Mail2;
            row["mail3"] = ((Client)obj).Mail3;
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((Client)obj).Id = GetUlong(row["id"]);
            ((Client)obj).Code = row["code"].ToString();
            ((Client)obj).Name = row["name"].ToString();
            ((Client)obj).Address = row["address"].ToString();
            ((Client)obj).City = row["city"].ToString();
            ((Client)obj).Phone = row["phone"].ToString();
            ((Client)obj).Mail1 = row["mail1"].ToString();
            ((Client)obj).Mail2 = row["mail2"].ToString();
            ((Client)obj).Mail3 = row["mail3"].ToString();
            ((Client)obj).Creation = ((DateTime)row["creation"]).Date;
        }

        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            Client obj;
            foreach (DataRow row in rows) {
                obj = new Client();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion
    }
}
