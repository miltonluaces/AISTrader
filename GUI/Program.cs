#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessModel;
using Trading;
using AutoTrading;
using System.Threading;
using IBApi;


#endregion

namespace GUI {

    public static class Program {

        [STAThread]
        static void Main() {

            Batch batch = new Batch();
            bool ok = batch.Closure();
            if (ok) {
                batch.SendMailReports();

                Console.WriteLine("8. Run the Application \n");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                #region IB Auto Trading
                /*
            //request market data
            IBTrader ibt = new IBTrader();
            ibt.ClientSocket.eConnect("127.0.0.1", 7496, 0);
            Contract c = new Contract();
            c.Symbol = "EUR";
            c.SecType = "CASH";
            c.Currency = "GBP";
            c.Exchange = "IDEALPRO";
            ibt.ClientSocket.reqMktData(1, c, "", false, null);
            Thread.Sleep(10000);
            ibt.ClientSocket.Close();

            //place order
            Contract cont = new Contract();
            cont.Symbol = "IBM";
            cont.SecType = "STK";
            cont.Exchange = "SMART";
            cont.Currency = "USD";
            Order ord = new Order();
            ord.OrderType = "MKT";
            ord.Action = "BUY";
            ord.TotalQuantity = 1;
            ord.Transmit = true;
            ord.Account = "DU74649";
            ibt.ClientSocket.placeOrder(ibt.NextOrderId, cont, ord);
            */

                #endregion

                MainForm mf = new MainForm();
                Application.Run(mf);
            }
        }
    }
}
