#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessModel;
using Trading;

#endregion

namespace GUI {

    
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm {

        #region Fields

        private Dictionary<string, Stock> stocks;
        private Dictionary<ulong, Client> clients;
        private List<Client> clientsList;
        private Client client;
        private Portfolio portfolio;
        private Invest currInvest;
        private SysLog sysLog;
        private IfsSeriesChartCtrl.ChartTypeType chartType;
        private int showNPeriods;
        
        #endregion

        #region Constructor

        public MainForm() {
            InitializeComponent();
            portfolioCtrl.Visible = false;
            stockChartCtrl.Visible = false;
            opOpenCtrl.Visible = false;
            sysLog = SysEnvironment.GetInstance().SysLog;
            chartType = IfsSeriesChartCtrl.ChartTypeType.xyLines;
            showNPeriods = 91;
            LoadData();
        }

        #endregion

        #region Public Methods

        
        public void LoadData() {
            this.stocks = SysEnvironment.GetInstance().Stocks;
            this.stockMonitorCtrl.LoadData(this.stocks);
      
            this.clients = SysEnvironment.GetInstance().Clients;
            this.clientsList = new List<Client>();
            this.clientsList.AddRange(clients.Values);
            foreach (Client c in clients.Values) { barClients.Strings.Add(c.Name); }
            portfolioCtrl.AfterSelectRow += new EventHandler(portfolioCtrl_AfterSelectRow);
            stockMonitorCtrl.AfterSelectRow += new EventHandler(stockMonitorCtrl_AfterSelectRow);
            currInvest = new Invest();
            currInvest.Stock = this.stocks["MSFT"]; //TODO: corregir
            this.stockMonitorCtrl.Visible = false;
            this.portfolioCtrl.Visible = false;
            this.stockChartCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
            this.opCloseCtrl.Visible = false;
        }

        #endregion

        #region Events

        #region Selection 

        private void barClients_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e) {
            client = clientsList[e.Index];
            barPortfolios.Strings.Clear();
            foreach (Portfolio p in client.Portfolios) { barPortfolios.Strings.Add(p.Name); }

            Portfolio clientSummary = new Portfolio();
            clientSummary.Code = "SUMMARY";
            foreach (Portfolio p in client.Portfolios) {
                p.SetTotals(true);
                p.Total.Stock.Code = p.Code;
                clientSummary.AddInvest(p.Total);
            }
            ShowPortfolio(clientSummary);

        }

        void portfolioCtrl_AfterSelectRow(object sender, EventArgs e) {
            currInvest = portfolioCtrl.CurrInvest;
        }
        
        private void barPortfolios_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e) {
            portfolio = client.Portfolios[e.Index];
            ShowPortfolio(portfolio);
        }

        #endregion

        #region Portfolio

        private void barGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.portfolioCtrl.Visible = true;
            this.stockChartCtrl.Visible = false;
            this.stockMonitorCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
            this.opCloseCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
        }

        private void barOperate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
           OperateFrm frm = new OperateFrm(this.stocks, portfolio, currInvest); 
           frm.ShowDialog();
           ShowPortfolio(portfolio);
           this.portfolioCtrl.LoadData(portfolio);
        }

        #endregion

        #region Monitor

        void stockMonitorCtrl_AfterSelectRow(object sender, EventArgs e) {
            currInvest = stockMonitorCtrl.CurrInvest;
        }
        
        private void barMonValues_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            portfolioCtrl.Visible = false;
            stockChartCtrl.Visible = false;
            stockMonitorCtrl.Visible = true;
            opOpenCtrl.Visible = false;
        }

        private void barMonData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void barAddStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddStockFrm asf = new AddStockFrm();
            asf.ShowDialog();
            this.stockMonitorCtrl.Refresh();
            this.stockMonitorCtrl.Show();
        }

        private void barRemoveStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            SysEnvironment sysEnv = SysEnvironment.GetInstance();
            try { currInvest.Stock.Delete(); }
            catch { Console.WriteLine("Error"); return; }
            sysEnv.Stocks.Remove(currInvest.StockCode);
            stockMonitorCtrl.LoadData(sysEnv.Stocks);
           
        }
        
        #endregion

        #region Charts

        private void barLineChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            chartType = IfsSeriesChartCtrl.ChartTypeType.xyLines;
            barJapoChart.Down = false;
            ShowChart();

        }

        private void barJapoChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            chartType = IfsSeriesChartCtrl.ChartTypeType.candleStick;
            barLineChart.Down = false;
            ShowChart();
        }

        #endregion

        #region Show Periods

        private void barPer1Month_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barPer1Month.Down) { return; }
            showNPeriods = 30;
            barPer3Months.Down = false;
            barPer6Months.Down = false;
            barPer1Year.Down = false;
            barPerAll.Down = false;
            ShowChart();
        }

        private void barPer3Months_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barPer3Months.Down) { return; }
            showNPeriods = 91;
            barPer1Month.Down = false;
            barPer6Months.Down = false;
            barPer1Year.Down = false;
            barPerAll.Down = false;
            ShowChart();
        }

        private void barPer6Months_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barPer6Months.Down) { return; }
            showNPeriods = 182;
            barPer1Month.Down = false;
            barPer3Months.Down = false;
            barPer1Year.Down = false;
            barPerAll.Down = false;
            ShowChart();
        }

        private void barPer1Year_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barPer1Year.Down) { return; }
            showNPeriods = 365;
            barPer1Month.Down = false;
            barPer3Months.Down = false;
            barPer6Months.Down = false;
            barPerAll.Down = false;
            ShowChart();
        }

        private void barPerAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barPerAll.Down) { return; }
            showNPeriods = 1095;
            barPer1Month.Down = false;
            barPer3Months.Down = false;
            barPer6Months.Down = false;
            barPer1Year.Down = false;
            ShowChart();
        }

        #endregion

        #region Bitacora

        private void barOpOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            List<Operation> operations = new List<Operation>();
            List<DbObject> operationsObj = new List<DbObject>();
            foreach (Portfolio p in client.Portfolios) {
                new Operation().ReadMany(operationsObj, "status=0 AND portfolioId=" + p.Id);
                foreach (Operation op in operationsObj) { operations.Add(op); }
            }
            opOpenCtrl.LoadData(operations);
            opOpenCtrl.Refresh();
            opOpenCtrl.Show();
            this.portfolioCtrl.Visible = false;
            this.stockChartCtrl.Visible = false;
            this.stockMonitorCtrl.Visible = false;
            this.opOpenCtrl.Visible = true;
            this.opCloseCtrl.Visible = false;
        }

        private void barOpClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            List<Operation> operations = new List<Operation>();
            List<DbObject> operationsObj = new List<DbObject>();
            foreach (Portfolio p in client.Portfolios) {
                new Operation().ReadMany(operationsObj, "status=1 AND portfolioId=" + p.Id);
                foreach (Operation op in operationsObj) { operations.Add(op); }
            }
            opCloseCtrl.LoadData(operations);
            opCloseCtrl.Refresh();
            this.portfolioCtrl.Visible = false;
            this.stockChartCtrl.Visible = false;
            this.stockMonitorCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
            this.opCloseCtrl.Visible = true;
        }

        private void barCloseOp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.opOpenCtrl.CloseOperations();
        }
        
        #endregion

        #region Currency

        private void barOriginal_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barOriginal.Checked) { return; }
            SysEnvironment.GetInstance().Currency = Stock.CurrencyType.ORI;
            barUsd.Checked = false;
            barEuro.Checked = false;
            barMxn.Checked = false;
            portfolioCtrl.LoadData(portfolio);
        }
   
        private void barUsd_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barUsd.Checked) { return; }
            SysEnvironment.GetInstance().Currency = Stock.CurrencyType.USD;
            barOriginal.Checked = false;
            barEuro.Checked = false;
            barMxn.Checked = false;
            portfolioCtrl.LoadData(portfolio);
        }

        private void barEuro_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barEuro.Checked) { return; }
            SysEnvironment.GetInstance().Currency = Stock.CurrencyType.EUR;
            barOriginal.Checked = false;
            barUsd.Checked = false;
            barMxn.Checked = false;
            portfolioCtrl.LoadData(portfolio);
        }

        private void barMxn_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (!barMxn.Checked) { return; }
            SysEnvironment.GetInstance().Currency = Stock.CurrencyType.MXN;
            barOriginal.Checked = false;
            barUsd.Checked = false;
            barEuro.Checked = false;
            portfolioCtrl.LoadData(portfolio);
        }

        #endregion

        #region Utils

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (this.portfolioCtrl.Visible == true) {
                portfolioCtrl.ExportToXls("Portfolio");
            }
            else if (this.stockChartCtrl.Visible == true) { 
                
            }
            else if (this.stockMonitorCtrl.Visible == true) {
                stockMonitorCtrl.ExportToXls("StockMonitor");
            }
            else if (this.opOpenCtrl.Visible == true) {
                opOpenCtrl.ExportToXls("Operations");
            }
            else { 
            
            }
        }

        private void barMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //MailFrm mf = new MailFrm();
            //mf.ShowDialog();
            //MessageBox.Show("Enviado mail de portfolio");
     
        }

        #endregion

        #region Administration

        private void barParams_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
        
        private void barHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            HelpFrm frm = new HelpFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AboutBoxFrm abf = new AboutBoxFrm();
            abf.Show();
        }
        
        private void barQuit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            sysLog.CloseLog();
            Dispose();
        }

        #endregion
        
        #endregion

        #region Helper Methods

        private void ShowPortfolio(Portfolio portfolio) {
            if (portfolio == null || portfolio.Invests == null || portfolio.Invests.Count == 0) { return; }
            portfolioCtrl.CurrInvest = portfolio.Invests.Values.ElementAt<Invest>(0);
            portfolioCtrl.LoadData(portfolio);
            this.portfolioCtrl.Visible = true;
            this.stockChartCtrl.Visible = false;
            this.stockMonitorCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
            this.opCloseCtrl.Visible = false;
        }

        private void ShowChart() {
            switch (this.chartType) {
                case IfsSeriesChartCtrl.ChartTypeType.xyLines: ShowLineChart(this.showNPeriods); break;
                case IfsSeriesChartCtrl.ChartTypeType.candleStick: ShowCandlestickChart(this.showNPeriods); break;

            }
        }

        private void ShowLineChart(int nPeriods) {
            this.portfolioCtrl.Visible = false;
            this.stockChartCtrl.Visible = true;
            this.stockMonitorCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
            this.opCloseCtrl.Visible = false;
            this.stockChartCtrl.ChartType = IfsSeriesChartCtrl.ChartTypeType.xyLines;
            this.stockChartCtrl.LoadTSeries(currInvest.Stock);
            this.stockChartCtrl.ShowSeries(nPeriods);
        }

        private void ShowCandlestickChart(int nPeriods) {
            this.portfolioCtrl.Visible = false;
            this.stockChartCtrl.Visible = true;
            this.stockMonitorCtrl.Visible = false;
            this.opOpenCtrl.Visible = false;
            this.opCloseCtrl.Visible = false;
            this.stockChartCtrl.ChartType = IfsSeriesChartCtrl.ChartTypeType.candleStick;
            this.stockChartCtrl.LoadTSeries(currInvest.Stock);
            this.stockChartCtrl.ShowCandleStickSeries(nPeriods);
        }
        
        #endregion

        #region Enums

        public enum ChartTypeType { Lines, Candlestick };
        public enum ShowPeriodType { Month1, Month3, Month6, Year1, All };

        #endregion

    }
}
