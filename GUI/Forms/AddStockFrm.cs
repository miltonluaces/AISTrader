#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Trading;
using BusinessModel;

#endregion

namespace GUI {

    public partial class AddStockFrm : DevExpress.XtraEditors.XtraForm {

        #region Fields

        private Downloader down;
        private DataSaver ds;
        private TSBuilder tsb;
        private string[] markets;
        private string[] currencies;

        #endregion

        #region Constructor

        public AddStockFrm() {
            InitializeComponent();
            down = new Downloader();
            ds = new DataSaver();
            tsb = new TSBuilder();
            string[] markets = { "NYSE", "NASDAQ", "MC" }; this.markets = markets;
            string[] currencies = { "USD", "EUR", "MXN" }; this.currencies = currencies;
        }

        #endregion

        #region Events

        private void AddStockFrm_Load(object sender, EventArgs e) {
            comboMarket.Items.AddRange(markets);
            comboCurrency.Items.AddRange(currencies);
        }
        
        private void buttCancel_Click(object sender, EventArgs e) {
            txtCode.Text = "";
            txtName.Text = "";
            txtCode.Focus();
        }

        private void buttOk_Click(object sender, EventArgs e) {
            string code = txtCode.Text;
            string source = txtSource.Text;
            DateTime iniDate = DateTime.Now.AddYears(-2); //TODO corregir 3 años en vez de 2

            Stock stock = new Stock();
            stock.Code = code;
            stock.Name = txtName.Text;
            stock.Source = source;
            stock.Type = Stock.TypeType.Stock;
            switch(comboMarket.SelectedItem.ToString()) {
                case "NYSE": stock.Market = Stock.MarketType.NYSE; break;
                case "NASDAQ": stock.Market = Stock.MarketType.NASDAQ; break;
                case "MC": stock.Market = Stock.MarketType.MC; break;
            }
            switch (comboCurrency.SelectedItem.ToString()) {
                case "USD": stock.Currency = Stock.CurrencyType.USD; break;
                case "EUR": stock.Currency = Stock.CurrencyType.EUR; break;
                case "MXN": stock.Currency = Stock.CurrencyType.MXN; break;
            }
            stock.SaveUpdate();
            stock.Read("code = '" + code + "'");
            
            if (source == "Manual") {
                ExcelReader er = new ExcelReader();
                Dictionary<string, double> manualData = er.ReadManualData("Funds");
                try {
                    stock.Value = manualData[stock.Code];
                    stock.SaveUpdate();
                    Dispose();
                    MessageBox.Show("Valor " + code + " agregado Ok.");
                }
                catch (Exception ex) { Console.WriteLine("Error."); }
            }
            else {
                List<List<string>> marketData = down.ReadMarketData(stock);
                if (marketData == null || marketData.Count == 0) { MessageBox.Show("Error. Valor " + code + " no encontrado."); }
                try {
                    List<string> marketQueries = ds.GenMarketQueries(stock.Id, marketData);
                    ds.SaveMarketData(marketQueries);
                    TSeries ts = tsb.Closure(stock, iniDate);
                    stock.Value = ts.Close[ts.Close.Count - 1];
                    stock.Volume = ts.Volume[ts.Volume.Count - 1];
                    stock.SaveUpdate();
                    stock.TSeries = ts;
                    SysEnvironment.GetInstance().Stocks.Add(stock.Code, stock);
                    Dispose();
                    MessageBox.Show("Valor " + code + " agregado Ok.");
                }
                catch (Exception ex) { Console.WriteLine("Error."); }
            }

        }

        #endregion
    }
}