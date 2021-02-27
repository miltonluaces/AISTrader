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

    public class BrkrStock : Broker {

        #region Fields
        #endregion

        #region Constructor

        public BrkrStock() : base() {
        }

        #endregion

        #region Public Virtual Methods

        public override DataSet GetSet() {
            return set;
        }

        protected override string GetTableName() {
            return "AisStock";
        }

        public override void ObjASet(DbObject obj, DataRow row) {
            row["id"] = ((Stock)obj).Id.ToString();
            row["code"] = ((Stock)obj).Code;
            row["name"] = ((Stock)obj).Name;
            row["type"] = ((Stock)obj).Type;
            switch (((Stock)obj).Type.ToString()) {
                case "total": row["type"] = 0; break;
                case "stock": row["type"] = 1; break;
                case "etf": row["type"] = 2; break;
                case "cfd": row["type"] = 3; break;
                case "future": row["type"] = 4; break;
                case "option": row["type"] = 5; break;
                case "fund": row["type"] = 6; break;
                default: row["type"] = 0; break;
            } 
            row["value"] = ((Stock)obj).Value;
            row["date"] = GetDate(((Stock)obj).Date);
            row["per"] = ((Stock)obj).Per;
            row["ebitda"] = ((Stock)obj).Ebitda;
            row["source"] = ((Stock)obj).Source;
            switch (((Stock)obj).Currency.ToString()) {
                case "usd": row["currency"] = 0; break;
                case "euro": row["currency"] = 1; break;
                case "mxn": row["currency"] = 2; break;
                default: row["currency"] = 0; break;
            }
            switch (((Stock)obj).Market.ToString()) {
                case "nyse": row["market"] = 0; break;
                case "nasdaq": row["market"] = 1; break;
                case "mc": row["market"] = 2; break;
                default: row["market"] = 0; break;
            }
            row["creation"] = (DateTime.Now).Date;
        }

        public override void SetAObj(DataRow row, DbObject obj) {
            ((Stock)obj).Id = GetUlong(row["id"]);
            ((Stock)obj).Code = row["code"].ToString();
            ((Stock)obj).Name = row["name"].ToString();
            switch (row["type"].ToString()) {
                case "0": ((Stock)obj).Type = Stock.TypeType.Total; break;
                case "1": ((Stock)obj).Type = Stock.TypeType.Stock; break;
                case "2": ((Stock)obj).Type = Stock.TypeType.ETF; break;
                case "3": ((Stock)obj).Type = Stock.TypeType.CFD; break;
                case "4": ((Stock)obj).Type = Stock.TypeType.Future; break;
                case "5": ((Stock)obj).Type = Stock.TypeType.Option; break;
                case "6": ((Stock)obj).Type = Stock.TypeType.Fund; break;
                case "7": ((Stock)obj).Type = Stock.TypeType.Index; break;
                case "8": ((Stock)obj).Type = Stock.TypeType.Forex; break;
                default: ((Stock)obj).Type = Stock.TypeType.Stock; break;
            }
            ((Stock)obj).Value = GetDouble(row["value"]);
            ((Stock)obj).Date = GetDate(row["date"]).Date;
            ((Stock)obj).Per = GetDouble(row["per"]);
            ((Stock)obj).Ebitda = GetDouble(row["ebitda"]);
            ((Stock)obj).Source = row["source"].ToString();
            ((Stock)obj).Creation = ((DateTime)row["creation"]).Date;
            switch (row["currency"].ToString()) {
                case "0": ((Stock)obj).Currency = Stock.CurrencyType.USD; break;
                case "1": ((Stock)obj).Currency = Stock.CurrencyType.EUR; break;
                case "2": ((Stock)obj).Currency = Stock.CurrencyType.MXN; break;
                default: ((Stock)obj).Currency = Stock.CurrencyType.USD; break;
            }
            switch (row["market"].ToString()) {
                case "0": ((Stock)obj).Market = Stock.MarketType.NYSE; break;
                case "1": ((Stock)obj).Market = Stock.MarketType.NASDAQ; break;
                case "2": ((Stock)obj).Market = Stock.MarketType.MC; break;
                default: ((Stock)obj).Market = Stock.MarketType.MC; break;
            }
        }

        public override void SetAObjs(DataRowCollection rows, List<DbObject> objs) {
            Stock obj;
            foreach (DataRow row in rows) {
                obj = new Stock();
                SetAObj(row, obj);
                objs.Add(obj);
            }
        }

        #endregion
    }
}
