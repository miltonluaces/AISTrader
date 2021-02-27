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

    public class BrkrOperation : Broker {

        #region Fields
        #endregion

        #region Constructor

        public BrkrOperation() : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisOperation";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((Operation)obj).Id.ToString();
            row["code"] = ((Operation)obj).Code;
            row["portfolioId"] = ((Operation)obj).Portfolio.Id;
            row["buyDate"] = ((Operation)obj).BuyDate;
            row["sellDate"] = ((Operation)obj).SellDate;
            row["type"] = ((Operation)obj).Type;
            row["status"] = ((Operation)obj).Status;
            row["qty"] = ((Operation)obj).Qty;
            row["buyValue"] = ((Operation)obj).BuyValue;
            row["sellValue"] = ((Operation)obj).SellValue;
            row["buyCom"] = ((Operation)obj).BuyCom;
            row["sellCom"] = ((Operation)obj).SellCom;
            row["stockId"] = ((Operation)obj).Stock.Id;
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((Operation)obj).Id = GetUlong(row["id"]);
            ((Operation)obj).Code = row["code"].ToString();
            ulong portfolioId = GetUlong(row["portfolioId"]);
            ((Operation)obj).Portfolio = new Portfolio(portfolioId);
            ((Operation)obj).BuyDate = GetDate(row["buyDate"]);
            ((Operation)obj).SellDate = GetDate(row["sellDate"]);
            switch (row["type"].ToString()) {
                case "0": ((Operation)obj).Type = Operation.OpType.Buy; break;
                case "1": ((Operation)obj).Type = Operation.OpType.Sell; break;
                default: ((Operation)obj).Type = Operation.OpType.Buy; break;
            }
            switch (row["status"].ToString()) {
                case "0": ((Operation)obj).Status = Operation.StatusType.Open; break;
                case "1": ((Operation)obj).Status = Operation.StatusType.Closed; break;
                case "2": ((Operation)obj).Status = Operation.StatusType.Taxed; break;
                default: ((Operation)obj).Status = Operation.StatusType.Open; break;
            }
            ((Operation)obj).Qty = GetInt(row["qty"]);
            ((Operation)obj).BuyValue = GetDouble(row["buyValue"]);
            ((Operation)obj).SellValue = GetDouble(row["sellValue"]);
            ((Operation)obj).BuyCom = GetDouble(row["buyCom"]);
            ((Operation)obj).SellCom = GetDouble(row["sellCom"]);
            ulong stockId = GetUlong(row["stockId"]);
            ((Operation)obj).Stock = new Stock(stockId);
            ((Operation)obj).Creation = ((DateTime)row["creation"]).Date;
        }

        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            Operation obj;
            foreach (DataRow row in rows) {
                obj = new Operation();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion
    }
}
