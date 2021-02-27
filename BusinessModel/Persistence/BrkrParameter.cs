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
    public class BrkrParameter : Broker {

        #region Fields

        #endregion

        #region Constructor

        public BrkrParameter()  : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisParameter";
        }

        protected override string GetPrimaryKey() {
            return "id";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((Parameter)obj).Id.ToString();
            row["code"] = ((Parameter)obj).Code;
            row["descr"] = ((Parameter)obj).Descr;
            row["type"] = Parameter.GetParTypeStr(((Parameter)obj).Type);
            row["value"] = ((Parameter)obj).Value.ToString();
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((Parameter)obj).Id = GetUlong(row["id"]);
            ((Parameter)obj).Code = row["code"].ToString();
            ((Parameter)obj).Descr = row["descr"].ToString();
            ((Parameter)obj).Type = Parameter.GetParType(row["type"].ToString());
            ((Parameter)obj).Value = Parameter.GetParValue(((Parameter)obj).Type, row["value"].ToString());
            ((Parameter)obj).Creation = ((DateTime)row["creation"]).Date;
        }

        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            Parameter obj;
            foreach (DataRow row in rows) {
                obj = new Parameter();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion

    }
}
