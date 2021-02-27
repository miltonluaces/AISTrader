#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BusinessModel {

    public class Invest: DbObject {

        #region Fields

        private DateTime date;
        private Stock stock;
        private double qty;
        private double purchValue;
        private double currAmount;
        private double purchAmount;
        private double lossAmount;
        private double profitAmount;
        private double propAmount;
        private double propProfit;
        private double stopLoss;
        private double takeProfit;
        private Portfolio portfolio;
        private Dictionary<Stock.CurrencyType, Dictionary<Stock.CurrencyType, double>> currencies;
           
        #endregion

        #region Constructor

        public Invest() : base() {
           currencies = SysEnvironment.GetInstance().Currencies;
      
        }

        public Invest(ulong id) : base(id) {
           currencies = SysEnvironment.GetInstance().Currencies;
      
        }
  
        #endregion

        #region Properties

        public DateTime Date {
            get { return date; }
            set { date = value; }
        }
        
        public Stock Stock {
            get { return stock; }
            set { stock = value; }
        }

        public double Qty {
            get { return qty; }
            set { qty = value; }
        }

        public string Name {
            get { return stock.Name; }
        }

        public string Type {
            get { return stock.Type.ToString(); }
        }

        public double PurchValue {
            get { return GetCurrencyValue(purchValue); }
            set { purchValue = value; }
        }

        public double CurrValue {
            get { return GetCurrencyValue(stock.Value); }
        }

        public double PurchAmount {
            get { return GetCurrencyValue(purchAmount); }
            set { purchAmount = value; }
        }
        
        public double CurrAmount {
            get { return GetCurrencyValue(currAmount); }
            set { currAmount = value; }
        }

        public double PropAmount {
            get { return propAmount; }
            set { propAmount = value; }
        }

        public double CurrProfit {
            get { return Math.Round(GetCurrencyValue(currAmount - purchAmount), 2); }
        }

        public double CurrProfitApproach {
            get { return Math.Round(GetCurrencyValue(((currAmount - purchAmount)/purchAmount) * 100), 2); }
        }
  
        public double PropProfit {
            get { return propProfit; }
            set { propProfit = value; }
        }
        
        public double StopLoss {
            get { return GetCurrencyValue(stopLoss); }
            set { stopLoss = value; }
        }

        public double TakeProfit {
            get { return GetCurrencyValue(takeProfit); }
            set { takeProfit = value; }
        }
        
        public double LossAmount {
            get { return GetCurrencyValue(lossAmount); }
            set { lossAmount = value; }
        }

        public double ProfitAmount {
            get { return GetCurrencyValue(profitAmount); }
            set { profitAmount = value; }
        }

        public double StLossApproach {
            get { return Math.Round(GetCurrencyValue(((currAmount - lossAmount) / CurrAmount)*100), 2); }
        }

        public double StProfitApproach {
            get { return Math.Round(GetCurrencyValue(((profitAmount - CurrAmount) / CurrAmount) * 100), 2); }
        }
     
        public Portfolio Portfolio {
            get { return portfolio; }
            set { portfolio = value; }
        }

        public string StockCode {
            get { return stock.Code; }
        }

        public ulong Volume {
            get { return stock.Volume; }
        }

        public double Per {
            get { return stock.Per; }
        }

        public double Ebitda {
            get { return GetCurrencyValue(stock.Ebitda); }
        }

        #endregion

        #region Public Methods

        public void SetAmounts() {
            currAmount = CurrValue * qty;
            purchAmount = purchValue * qty;
            lossAmount = stopLoss * qty;
            profitAmount = takeProfit * qty;
        }


        private double GetCurrencyValue(double val) {
            if (stock == null) { return -1; }
            Stock.CurrencyType currency = SysEnvironment.GetInstance().Currency;
            if (currency == Stock.CurrencyType.ORI || currency == stock.Currency) { return val; }
            return val * currencies[currency][stock.Currency];
        }
        
        #endregion

        #region Persistence

        public override Broker GetBroker() { return BrkrMgr.GetInstance().GetBroker((Invest)this); }

        #endregion
    }
}
