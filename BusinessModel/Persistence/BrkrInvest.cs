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

    public class BrkrInvest : Broker {

        #region Fields
        #endregion

        #region Constructor

        public BrkrInvest()
            : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisInvest";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((Invest)obj).Id.ToString();
            row["code"] = ((Invest)obj).Code;
            row["date"] = ((Invest)obj).Date;
            row["stockId"] = ((Invest)obj).Stock.Id;
            row["qty"] = ((Invest)obj).Qty;
            row["purchValue"] = ((Invest)obj).CurrValue;
            //row["proportion"] = ((Invest)obj).PropAmount;
            row["stopLoss"] = ((Invest)obj).StopLoss;
            row["takeProfit"] = ((Invest)obj).TakeProfit;
            row["portfolioId"] = GetUlong(((Invest)obj).Portfolio.Id);
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((Invest)obj).Id = GetUlong(row["id"]);
            ((Invest)obj).Code = row["code"].ToString();
            ((Invest)obj).Date = GetDate(row["date"]);
            ulong stockId = GetUlong(row["stockId"]);
            ((Invest)obj).Stock = new Stock(stockId);
            ((Invest)obj).Qty = GetDouble(row["qty"]);
            ((Invest)obj).PurchValue = GetDouble(row["purchValue"]);
            //((Invest)obj).PropAmount = GetDouble(row["proportion"]);
            ((Invest)obj).StopLoss = GetDouble(row["stopLoss"]);
            ((Invest)obj).TakeProfit = GetDouble(row["takeProfit"]);
            ulong portfolioId = GetUlong(row["portfolioId"]);
            ((Invest)obj).Portfolio = new Portfolio(portfolioId);
            ((Invest)obj).Creation = ((DateTime)row["creation"]).Date;
        }

        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            Invest obj;
            foreach (DataRow row in rows) {
                obj = new Invest();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion
    }
}
