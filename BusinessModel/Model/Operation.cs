#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BusinessModel {
    
    public class Operation : DbObject {

        #region Fields

        private DateTime buyDate;
        private DateTime sellDate;
        private Stock stock;
        private Portfolio portfolio;
        private double buyValue;
        private double sellValue;
        private double qty;
        private OpType type;
        private StatusType status;
        private double buyCom;
        private double sellCom;

        #endregion

        #region Constructors

        public Operation() : base() { 
        
        }

        public Operation(ulong id) : base(id) { 
        
        }

        public Operation(Invest inv, double qty, OpType type, StatusType status) : base() {
            this.buyDate = inv.Date;
            this.sellDate = DateTime.Now.AddYears(1); // TODO: corregir año
            this.stock = inv.Stock;
            this.buyValue = inv.PurchValue;
            this.sellValue = inv.CurrValue;
            this.qty = qty;
            this.type = type;
            this.status = status;
        }

        public Operation(Invest inv, int qty, OpType type, StatusType status, double buyCom, double sellCom) : this(inv, qty, type, status) {
            this.buyCom = buyCom;
            this.sellCom = sellCom;
        }

        #endregion

        #region Properties

        public Portfolio Portfolio {
            get { return portfolio; }
            set { portfolio = value; }
        }
        
        public DateTime BuyDate {
            get { return buyDate; }
            set { buyDate = value; }
        }

        public DateTime SellDate {
            get { return sellDate; }
            set { sellDate = value; }
        }
        
        public Stock Stock {
            get { return stock; }
            set { stock = value; }
        }

        public string StockCode {
            get { return stock.Code; }
        }

        public string PortfolioCode {
            get { return portfolio.Code; }
        }

        public string StockName {
            get { return stock.Name; }
        }

        public double Qty {
            get { return qty; }
            set { qty = value; }
        }

        public OpType Type {
            get { return type; }
            set { type = value; }
        }

        public StatusType Status {
            get { return status; }
            set { status = value; }
        }
        
        public double BuyCom {
            get { return buyCom; }
            set { buyCom = value; }
        }

        public double SellCom {
            get { return sellCom; }
            set { sellCom = value; }
        }
        
        public double BuyValue {
            get { return buyValue; }
            set { buyValue = value; }
        }

        public double SellValue {
            get { return sellValue; }
            set { sellValue = value; }
        }

        public double Profit {
            get { return (sellValue - buyValue) * qty - buyCom - sellCom; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Enums

        public enum OpType { Buy, Sell };
        public enum StatusType { Open, Closed, Taxed };

        #endregion

        #region Persistence

        public override Broker GetBroker() { return BrkrMgr.GetInstance().GetBroker((Operation)this); }

        #endregion

    }
}
