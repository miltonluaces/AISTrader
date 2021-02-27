#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using Trading;

#endregion

namespace ConsoleApp {

    public class Program {
        static void Main(string[] args) {
            Console.WriteLine("AI Trader Sytem");

            SysEnvironment sysEnv = SysEnvironment.GetInstance();
            Dictionary<string, Parameter> parameters = new Dictionary<string, Parameter>();
            List<DbObject> paramObjs = new List<DbObject>();
            new Parameter().ReadMany(paramObjs, "");
            foreach (Parameter par in paramObjs) { parameters.Add(par.Code, par); }
            SysEnvironment.GetInstance().Parameters = parameters;
            DateTime lastClosure = (DateTime)SysEnvironment.GetInstance().GetParameter("closure").Value;
            if(lastClosure == DateTime.Now) { return; }

            Dictionary<string, Stock> stocks = new Dictionary<string, Stock>();
            Stock msft = new Stock(1, "MSFT"); stocks.Add(msft.Code, msft);

            List<List<string>> marketData;
            List<string> marketQueries;
            Downloader down = new Downloader();
            DataSaver ds = new DataSaver();
            foreach (string code in stocks.Keys) {
                marketData = down.ReadMarketData(stocks[code]);
                marketQueries = ds.GenMarketQueries(1, marketData);
                ds.SaveMarketData(marketQueries);
            }
            
            TSBuilder tsb = new TSBuilder();
            tsb.Closure();
        }
    }
}
