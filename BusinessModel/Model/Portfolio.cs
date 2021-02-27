#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BusinessModel {

    public class Portfolio : DbObject {

        #region Fields

        private string name;
        private Client client;
        private Dictionary<string, Invest> invests;
        private Invest total;

        #endregion

        #region Constructor

       public Portfolio() : base() {
           invests = new Dictionary<string, Invest>();
           total = new Invest(0);
        }

       public Portfolio(ulong id) : base(id) {
           invests = new Dictionary<string, Invest>();
           total = new Invest(0);
       }
     
        #endregion

        #region Properties

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Client Client {
            get { return client; }
            set { client = value; }
        }

        public double CurrAmount {
            get { return total.CurrAmount; }
        }

        public double CurrProfit {
            get { return total.CurrProfit; }
        }

        public double PurchAmount {
            get { return total.PurchAmount; }
        }

        public double LossAmount {
            get { return total.LossAmount; }
        }

        public double ProfitAmount {
            get { return total.ProfitAmount; }
        }

        public Invest Total {
            get { return total; }
        }
        
        #endregion

        #region Public Methods

        public void AddInvest(Invest inv) {
            invests.Add(inv.Stock.Code, inv);
        }
        
        public void AddInvest(Stock stock, int qty) {
            if (!invests.ContainsKey(stock.Code)) {
                Invest inv = new Invest();
                inv.Stock = stock;
                inv.Qty = qty;
                invests.Add(inv.Stock.Code, inv);
            }
        }

        public Invest GetInvest(string stockCode) {
            if (!invests.ContainsKey(stockCode)) { throw new Exception("Error. Stock not found"); }
            return invests[stockCode];
        }

        public Dictionary<string, Invest> Invests {
            get { return invests; }
        }

        public double GetValue() {
            double value = 0;
            foreach (Invest inv in invests.Values) { value += inv.Stock.Value; }
            return value;
        }

        public void SetTotals(bool totalInvests) {
            total.Stock = new Stock(0);
            total.Date = DateTime.MaxValue;
            total.Stock.Code = "TOTAL";
            total.Stock.Type = Stock.TypeType.Total;

            total.CurrAmount = 0;
            total.PurchAmount = 0;
            total.LossAmount = 0;
            total.ProfitAmount = 0;

            foreach (Invest i in invests.Values) {
                if (i.StockCode == "TOTAL") { continue; }
                if (totalInvests) { i.SetAmounts(); }
                total.CurrAmount += i.CurrAmount;
                total.PurchAmount += i.PurchAmount;
                total.LossAmount += i.LossAmount;
                total.ProfitAmount += i.ProfitAmount;
            }
            total.PropAmount = 100;
            total.PropProfit = 100;
            
            foreach (Invest i in invests.Values) {
                i.PropAmount = Math.Round((i.CurrAmount / total.CurrAmount) * 100, 2);
                i.PropProfit = Math.Round((i.CurrProfit / total.CurrProfit) * 100, 2);
            }
            if (!invests.ContainsKey("TOTAL")) { invests.Add("TOTAL", total); }
            else { invests["TOTAL"] = total; }
        }

        #endregion

        #region Persistence

        public override Broker GetBroker() { return BrkrMgr.GetInstance().GetBroker((Portfolio)this); }

        #endregion

    }
}
