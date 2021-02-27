#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.IO;
using System.Text;

#endregion

namespace Trading {
    
    public class Batch {

        #region Fields

        private Dictionary<ulong, Client> clients;
        private Dictionary<ulong, Portfolio> portfolios;
        private Dictionary<string, Stock> stocks;
        private Dictionary<ulong, Stock> stocksById;
        private DateTime lastClosure;
        private Mailer mailer;
        private string debug = "";
        private SysLog sysLog;
        private DateTime now;

        #endregion

        #region Constructor

        public Batch() {
            clients = new Dictionary<ulong, Client>();
            portfolios = new Dictionary<ulong, Portfolio>();
            stocks = new Dictionary<string, Stock>();
            stocksById = new Dictionary<ulong, Stock>();
            mailer = new Mailer();
            sysLog = SysEnvironment.GetInstance().SysLog;
            now = DateTime.Now.AddYears(1); //TODO: corregir año
            Trace("Iniciando la aplicacion");
        }

        #endregion

        #region Properties

        public Dictionary<ulong, Client> Clients {
            get { return clients; }
        }
        
        public Dictionary<ulong, Portfolio> Portfolios {
            get { return portfolios; }
        }
        
        public Dictionary<string, Stock> Stocks {
            get { return stocks; }
        }
    
        #endregion

        #region Public Methods

        public bool Closure() {
            bool ok = LoadParameters();
            if (!ok) { return false; }
            LoadCurrencies();
            LoadClients();
            LoadPortfolios();
            LoadStocks();
            LoadInvests();
            LoadMarketData();
            LoadManualMarketData();
            SysEnvironment.GetInstance().Clients = this.clients;
            SysEnvironment.GetInstance().Stocks = this.stocks;
            return true;
        }

        public void SendMailReports() {
            Trace("8. Send Mail Reports \n");
            foreach (Client c in clients.Values) { SendMailReport(c); }
        }
        
        #endregion

        #region Private Methods

        private bool LoadParameters() {
            SysEnvironment sysEnv = SysEnvironment.GetInstance();
            Dictionary<string, Parameter> parameters = new Dictionary<string, Parameter>();
            List<DbObject> paramObjs = new List<DbObject>();
            new Parameter().ReadMany(paramObjs, "");
            if (paramObjs.Count == 0) { Console.WriteLine("\nDatabase Error.\n"); return false; }
            foreach (Parameter par in paramObjs) { parameters.Add(par.Code, par); }
            SysEnvironment.GetInstance().Parameters = parameters;
            lastClosure = ((DateTime)SysEnvironment.GetInstance().GetParameter("closure").Value).AddYears(1);  //TODO: corregir año
            debug = SysEnvironment.GetInstance().GetParameter("debug").Value.ToString();
            return true;
            Trace("\n1. Read Parameters \n");
            Trace("\tLast Closure : " + lastClosure.ToShortDateString() + " Today : " + DateTime.Now.ToShortDateString() + "\n");
        }

        private void LoadCurrencies() {
            Dictionary<Stock.CurrencyType, Dictionary<Stock.CurrencyType, double>> currencies = new Dictionary<Stock.CurrencyType, Dictionary<Stock.CurrencyType, double>>(); 
            CurrencyConverter cc = new CurrencyConverter();
            Currency currency;
         
            currencies.Add(Stock.CurrencyType.USD, new Dictionary<Stock.CurrencyType, double>());
            currency = new Currency("USD", "EUR");
            cc.GetCurrencyData(ref currency);
            currencies[Stock.CurrencyType.USD].Add(Stock.CurrencyType.EUR, currency.Rate);
            currency = new Currency("USD", "MXN");
            cc.GetCurrencyData(ref currency);
            currencies[Stock.CurrencyType.USD].Add(Stock.CurrencyType.MXN, currency.Rate);

            currencies.Add(Stock.CurrencyType.EUR, new Dictionary<Stock.CurrencyType, double>());
            currency = new Currency("EUR", "USD");
            cc.GetCurrencyData(ref currency);
            currencies[Stock.CurrencyType.EUR].Add(Stock.CurrencyType.USD, currency.Rate);
            currency = new Currency("EUR", "MXN");
            cc.GetCurrencyData(ref currency);
            currencies[Stock.CurrencyType.EUR].Add(Stock.CurrencyType.MXN, currency.Rate);
            
            SysEnvironment.GetInstance().Currencies = currencies;
        }
        
        private void LoadClients() {
            Trace("2. Read Clients \n");
            clients = new Dictionary<ulong, Client>();
            List<DbObject> clientObjs = new List<DbObject>();
            new Client().ReadMany(clientObjs, "1=1");
            foreach (Client c in clientObjs) { clients.Add(c.Id, c); }
            Trace("\t" + clients.Count + " clients read. \n");
        }
        
        private void LoadPortfolios() {
            Trace("3. Read Portfolios \n");
            List<DbObject> portfolioObjs = new List<DbObject>();
            new Portfolio().ReadMany(portfolioObjs, "1=1");
            portfolios = new Dictionary<ulong, Portfolio>();
            foreach (Portfolio p in portfolioObjs) {
                clients[p.Client.Id].AddPortfolio(p);
                portfolios.Add(p.Id, p);
            }
            Trace("\t" + portfolios.Count + " portfolios read.\n");
        }
        
        private void LoadStocks() {
            Trace("4. Read Stocks \n");
            List<DbObject> stockObjs = new List<DbObject>();
            new Stock().ReadMany(stockObjs, "1=1");
            stocks = new Dictionary<string, Stock>();
            foreach (Stock s in stockObjs) { 
                stocks.Add(s.Code, s);
                stocksById.Add(s.Id, s);
            }
            Trace("\t" + stocks.Count + " stocks read.\n");
        }

        private void LoadInvests() {
            Trace("5. Read Invests \n");
            List<DbObject> investObjs = new List<DbObject>();
            new Invest().ReadMany(investObjs, "1=1");
            foreach (Invest i in investObjs) {
                i.Stock = stocksById[i.Stock.Id];
                portfolios[i.Portfolio.Id].AddInvest(i);
            }
            Trace("\t" + investObjs.Count + " invests read. \n");
        }
        
        private void LoadMarketData() {
            Trace("6. Read Market data \n");
            int smd = 0;
            int mLines = 0;
            DateTime now = DateTime.Now.AddYears(1); //TODO: corregir año
            
            List<List<string>> marketData;
            List<string> marketQueries;
            Downloader down = new Downloader();
            DataSaver ds = new DataSaver();
            foreach (Stock stock in stocks.Values) {
                if (stock.Date == now) { continue; }
                try { marketData = down.ReadMarketData(stock); }
                catch (Exception ex) { marketData = null; }
                smd++;
                if (marketData == null) { Console.WriteLine(stock +  " Error: Missed data."); continue; }
                Console.WriteLine(stock + " Data downloaded Ok. ");
                mLines += marketData.Count;
                marketQueries = ds.GenMarketQueries(stock.Id, marketData);
                ds.SaveMarketData(marketQueries);
            }
            Trace("\t" + smd + " stocks marketData with " + mLines + "registers read.\n");
                
            Trace("7. Build Time Series \n");
            TSBuilder tsb = new TSBuilder();
            tsb.Closure();
            foreach (TSeries ts in tsb.TimeSeries) { 
                stocksById[ts.Stock.Id].TSeries = ts;
                stocksById[ts.Stock.Id].Value = ts.Close[ts.Close.Count - 1];
                stocksById[ts.Stock.Id].Volume = ts.Volume[ts.Volume.Count - 1];
                stocksById[ts.Stock.Id].Date = ts.EndHist;
            }
            Trace("\t" + tsb.TimeSeries.Count + " time series read \n");
        }

        private void LoadMarketDataFromDB() {
            List<DbObject> tSeries = new List<DbObject>();
            new TSeries().ReadMany(tSeries, "1=1");
            foreach (TSeries ts in tSeries) {
                stocksById[ts.Stock.Id].TSeries = ts;
                stocksById[ts.Stock.Id].Value = ts.Close[ts.Close.Count - 1];
                stocksById[ts.Stock.Id].Volume = ts.Volume[ts.Volume.Count - 1];
            }
            Trace("\t" + tSeries.Count + " time series read \n");
        }

        private void LoadManualMarketData() {
            Trace("7. Read Manual Market data \n");
            Downloader down = new Downloader();
            Dictionary<string, double> manualData = down.ReadDataFromManual();
            foreach(Stock s in stocks.Values) {
                if (s.Source == "Manual" && manualData.ContainsKey(s.Code)) { 
                    s.Value = manualData[s.Code];
                    s.Date = now;
                }
            }

            foreach (Stock s in stocksById.Values) { s.SaveUpdate(); } 
        }

        private void SendMailReport(Client c) {
            string subject = "Reporte de Inversiones " + DateTime.Now.ToShortDateString();
            StringBuilder body = new StringBuilder();
            body.AppendLine("Reporte de Inversiones de " + c.Name);
            body.AppendLine("Fecha : " + DateTime.Now.ToShortDateString());
            body.AppendLine("--------------------------------------------");
            body.AppendLine("");
            foreach (Portfolio p in c.Portfolios) {
                body.AppendLine("Portafolio " + p.Name);
                body.AppendLine("--------------------------------------------");
                body.AppendLine("");
                body.AppendLine("Valor Compra\tValor actual\tGanancia");
                body.AppendLine(p.PurchAmount + "\t" + p.CurrAmount + "\t" + p.CurrProfit);
                body.AppendLine("");
                body.AppendLine("Valor Loss\tGanancia");
                body.AppendLine(p.PurchAmount + "\t" + p.CurrAmount + "\t" + p.CurrProfit);
                body.AppendLine("");
                body.AppendLine("Estimado cliente: en el archivo adjunto encontrará el detalle de cada uno");
                body.AppendLine("de los portafolios que administramos, junto con el detalle de los valores");
                body.AppendLine("de sus inversiones. ");
                body.AppendLine("");
                body.AppendLine("AI Financial & Logistics Systems");
                body.AppendLine("");
            }
            string attachFileName = @"..\..\..\Documents\" + c.Code + ".xls";
            GenerateCSV(c, attachFileName);

            mailer.Send(c.Name, c.Mail1, subject, body.ToString(), attachFileName);
            mailer.Send(c.Name, c.Mail2, subject, body.ToString(), attachFileName);
            mailer.Send(c.Name, c.Mail3, subject, body.ToString(), attachFileName);
        }

        private void GenerateCSV(Client c, string attachFileName) {
            StreamWriter sw = new StreamWriter(attachFileName);
            foreach (Portfolio p in c.Portfolios) {
                sw.WriteLine("Portfolio \t" + p.Name);
                foreach (Invest i in p.Invests.Values) {
                    sw.WriteLine("Valor Compra \tValor actual\tGanancia\tValor Loss\tGanancia");
                    sw.WriteLine(i.PurchAmount + "\t" + i.CurrAmount + "\t" + i.CurrProfit + "\t" + i.PurchAmount + "\t" + i.CurrAmount + "\t" + i.CurrProfit);
                }
            }
            sw.Close();
        } 
        
        private void Trace(string msg) {
            sysLog.WriteLog(msg);
            if (debug == "F") { Console.WriteLine(msg); }
        }

        #endregion
    }
}
