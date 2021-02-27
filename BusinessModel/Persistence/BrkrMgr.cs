#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;

#endregion

namespace BusinessModel {

    public class BrkrMgr {

        #region Singleton

        private static BrkrMgr bm;

        private BrkrMgr() {
            brkrParameter = new BrkrParameter();
            brkrClient = new BrkrClient();
            brkrStock = new BrkrStock();
            brkrInvest = new BrkrInvest();
            brkrPortfolio = new BrkrPortfolio();
            brkrTSeries = new BrkrTSeries();
            brkrOperation = new BrkrOperation();
        }

        public static BrkrMgr GetInstance() {
            if (bm == null) { bm = new BrkrMgr(); }
            return bm;
        }

        public static void Initialize() {
            bm = new BrkrMgr();
        }

        #endregion

        #region Broker Fields

        private Broker broker;
        private Broker brkrParameter;
        private Broker brkrClient;
        private Broker brkrStock;
        private Broker brkrInvest;
        private Broker brkrPortfolio;
        private Broker brkrTSeries;
        private Broker brkrOperation;
                
        #endregion

        #region Broker accessors

        public BrkrParameter GetBroker(Parameter obj) { return (BrkrParameter)brkrParameter; }
        public BrkrClient GetBroker(Client obj) { return (BrkrClient)brkrClient; }
        public BrkrStock GetBroker(Stock obj) { return (BrkrStock)brkrStock; }
        public BrkrInvest GetBroker(Invest obj) { return (BrkrInvest)brkrInvest; }
        public BrkrPortfolio GetBroker(Portfolio obj) { return (BrkrPortfolio)brkrPortfolio; }
        public BrkrTSeries GetBroker(TSeries obj) { return (BrkrTSeries)brkrTSeries; }
        public BrkrOperation GetBroker(Operation obj) { return (BrkrOperation)brkrOperation; }
        
        #endregion

        #region Static virtual Methods

        public void ReadMany(List<Client> objs, string condition) {
            List<DbObject> dbObjs = new List<DbObject>();
            ((BrkrClient)brkrClient).ReadMany(dbObjs, condition);
            foreach (Client obj in dbObjs) { objs.Add(obj); }
        }

        public void ReadMany(List<Stock> objs, string condition) {
            List<DbObject> dbObjs = new List<DbObject>();
            ((BrkrStock)brkrStock).ReadMany(dbObjs, condition);
            foreach (Stock obj in dbObjs) { objs.Add(obj); }
        }

        public void ReadMany(List<Invest> objs, string condition) {
            List<DbObject> dbObjs = new List<DbObject>();
            ((BrkrInvest)brkrInvest).ReadMany(dbObjs, condition);
            foreach (Invest obj in dbObjs) { objs.Add(obj); }
        }

        public void ReadMany(List<Portfolio> objs, string condition) {
            List<DbObject> dbObjs = new List<DbObject>();
            ((BrkrPortfolio)brkrPortfolio).ReadMany(dbObjs, condition);
            foreach (Portfolio obj in dbObjs) { objs.Add(obj); }
        }

        public void ReadMany(List<TSeries> objs, string condition) {
            List<DbObject> dbObjs = new List<DbObject>();
            ((BrkrTSeries)brkrTSeries).ReadMany(dbObjs, condition);
            foreach (TSeries obj in dbObjs) { objs.Add(obj); }
        }

        public void ReadMany(List<Operation> objs, string condition) {
            List<DbObject> dbObjs = new List<DbObject>();
            ((BrkrOperation)brkrOperation).ReadMany(dbObjs, condition);
            foreach (Operation obj in dbObjs) { objs.Add(obj); }
        }

        #endregion

        #region Extended Read Methods

        //public void Read(TimeSeries ts, Sku sku) { GetBroker(ts).Read(sku); }

        #endregion

    }
}
