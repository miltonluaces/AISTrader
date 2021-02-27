#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BusinessModel {
    
    public class Client: DbObject {

        #region Fields 

        protected string name;
	    protected string address;
	    protected string city;
	    protected string phone;
        protected string mail1;
        protected string mail2;
        protected string mail3;
        protected List<Portfolio> portfolios;

        #endregion

        #region Constructors
        
        public Client() : base() {
            portfolios = new List<Portfolio>();
	    }

        public Client(ulong id) : base(id)  {
            portfolios = new List<Portfolio>();
        }
        
        #endregion

        #region Properties

        public string Name {
		    get { return name; }
		    set { name = value; }
	    }

	    public string Address {
		    get { return address; }
		    set { address = value; }
	    }

	    public string City {
		    get { return city; }
		    set { city = value; }
	    }

	    public string Phone {
		    get { return phone; }
		    set { phone = value; }
	    }

        public string Mail1 {
            get { return mail1; }
            set { mail1 = value; }
        }

        public string Mail2 {
            get { return mail2; }
            set { mail2 = value; }
        }

        public string Mail3 {
            get { return mail3; }
            set { mail3 = value; }
        }
        
        public List<Portfolio> Portfolios {
            get { return portfolios; }
            set { portfolios = value; }
        }

        #endregion

        #region Public Methods

        public void AddPortfolio(Portfolio p) {
            portfolios.Add(p);
        }
        
        #endregion

        #region Persistence

        public override Broker GetBroker() { return BrkrMgr.GetInstance().GetBroker((Client)this); }

        #endregion
    }
}
