#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BusinessModel {

    public class Stock: DbObject {

        #region Fields

        private string name;
        private TypeType type;
        private double val;
        private ulong volume;
        private DateTime date;
        private double per;
        private double ebitda;
        private TSeries tSeries;
        private string source;
        private CurrencyType currency;
        private MarketType market;
        
     
        #endregion

        #region Constructors

        public Stock() : base() {
            type = TypeType.Stock;
        }

        public Stock(ulong id) : base(id) {
            type = TypeType.Stock;
        }

        public Stock(ulong id, string code) : base(id) {
            this.code = code;
            type = TypeType.Stock;
        }

        #endregion

        #region Properties

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public TypeType Type {
            get { return type; }
            set { type = value; }
        }
        
        public double Value {
            get { return val;  }
            set { val = value; }
        }

        public DateTime Date {
            get { return date; }
            set { date = value; }
        }

        public ulong Volume {
            get { return volume; }
            set { volume = value; }
        }

        public double Per {
            get { return per; }
            set { per = value; }
        }

        public double Ebitda {
            get { return ebitda; }
            set { ebitda = value; }
        }

        public TSeries TSeries {
            get { return tSeries; }
            set { tSeries = value; }
        }

        public string Source {
            get { return source; }
            set { source = value; }
        }

        public CurrencyType Currency {
            get { return currency; }
            set { currency = value; }
        }

        public MarketType Market {
            get { return market; }
            set { market = value; }
        }
   
        #endregion

        #region Enums

        public enum TypeType { Total, Stock, ETF, Fund, CFD, Future, Option, Index, Forex };
        public enum CurrencyType { USD, EUR, MXN, ORI };
        public enum MarketType { NYSE, NASDAQ, MC };

        #endregion

        #region Persistence

        public override Broker GetBroker() { return BrkrMgr.GetInstance().GetBroker((Stock)this); }
        
        #endregion

    }
}
