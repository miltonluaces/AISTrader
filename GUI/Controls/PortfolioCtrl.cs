#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessModel;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid;
using System.Text.RegularExpressions;

#endregion

namespace GUI {

    public partial class PortfolioCtrl : UserControl {

        #region Fields & Events

        private Portfolio portfolio;
        private Invest currInvest;
        private Dictionary<ulong, Stock> stocks;
      
        public event EventHandler AfterSelectRow;

        #endregion

        #region Constructor

        public PortfolioCtrl() {
            InitializeComponent();
            currInvest = new Invest();
        }

        #endregion

        #region Properties

        public Invest CurrInvest {
            get { return currInvest; }
            set { currInvest = value; }
        }

        #endregion

        #region Public Methods

        public void LoadStocks(Dictionary<ulong, Stock> stocks) {
            this.stocks = stocks;
        }
        
        public void LoadData(Portfolio portfolio) {
            this.portfolio = portfolio;
            SetDataSource(portfolio);
        }

        public void ExportToXls(string fileName) {
            gridCtrl.ExportToXls(@"..\..\..\Documents\" + fileName + ".xls");
        }

        #endregion

        #region Private Methods

        private void Sort() {
            gridView.ClearSorting();
            gridView.Columns["Date"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }
        
        private void HideColumns() {
            string[] hideCols = { "Stock", "Portfolio", "Code", "Id", "Creation" };
            foreach (string colName in hideCols) {
                if (gridView.Columns[colName] != null) { gridView.Columns[colName].Visible = false; }
            }

            if (portfolio.Code == "SUMMARY") {
                string[] hideColsSummary = { "Date", "Type", "PurchValue", "CurrValue", "Name", "Qty", "StopLoss", "TakeProfit", "Per", "Ebitda", "Volume" };
                foreach (string colName in hideColsSummary) {
                    if (gridView.Columns[colName] != null) { gridView.Columns[colName].Visible = false; }
                }
            }
        }

        private void SetCaptions() {
            gridCtrl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            gridCtrl.LookAndFeel.UseDefaultLookAndFeel = false;
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            Font font = new System.Drawing.Font(FontFamily.GenericSansSerif, 4, FontStyle.Bold);
            gridView.Appearance.HeaderPanel.Font = Font;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.BackColor = Color.LightSteelBlue;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            gridView.Appearance.OddRow.BackColor = Color.LightBlue;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.Azure;
            SetCaption("StockCode", "Codigo", 0);
            SetCaption("Date", "Fecha", 1);
            SetCaption("Name", "Nombre", 2);
            SetCaption("Type", "Tipo", 3);
            SetCaption("Qty", "Cantidad", 4);
            SetCaption("PurchValue", "P.Compra", 5);
            SetCaption("CurrValue", "P.Actual", 6);
            SetCaption("PurchAmount", "T.Compra", 7);
            SetCaption("CurrAmount", "T.Actual", 8);
            SetCaption("CurrProfit", "Ganancia", 9);
            SetCaption("StopLoss", "Stop-Loss", 10);
            SetCaption("TakeProfit", "Stop-Profit", 11);
            SetCaption("LossAmount", "T.Loss", 12);
            SetCaption("ProfitAmount", "T.Profit", 13);
            SetCaption("PropAmount", "% Monto", 14);
            SetCaption("PropProfit", "% Ganan", 15);
            SetCaption("CurrProfitApproach", "% s/Compra", 16);
            SetCaption("StLossApproach", "% s/stLoss", 17);
            SetCaption("StProfitApproach", "% s/stProfit", 18);
            SetCaption("Per", "PER", 19);
            SetCaption("Ebitda", "EBITDA", 20);
            SetCaption("Volume", "Volumen", 21);

            StyleFormatCondition sfcTotal = new StyleFormatCondition();
            sfcTotal.Appearance.BackColor = Color.LightGray;
            Font headFont = new System.Drawing.Font("Tahoma", 10F, FontStyle.Bold);
            sfcTotal.Appearance.Font = headFont;
            sfcTotal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            sfcTotal.Appearance.Options.UseBackColor = true;
            sfcTotal.Appearance.Options.UseFont = true;
            sfcTotal.Condition = FormatConditionEnum.Expression;
            sfcTotal.Expression = "[StockCode] == 'TOTAL'";
            gridView.FormatConditions.Add(sfcTotal);

            HideData("TOTAL", "Ebitda", "0");
            HideData("TOTAL", "Per", "0");
            HideData("TOTAL", "Value", "0");
            HideData("TOTAL", "Volume", "0");
            HideData("TOTAL", "Qty", "0");
            HideData("TOTAL", "Type");
            HideData("TOTAL", "StopLoss", "0");
            HideData("TOTAL", "TakeProfit", "0");
            HideData("TOTAL", "PurchValue", "0");
            HideData("TOTAL", "CurrValue", "0");
            HideData("TOTAL", "Date");
        }

        private void HideData(string rowName, string colName, string value) {
            StyleFormatCondition sfcHideData = new StyleFormatCondition();
            sfcHideData.Column = gridView.Columns[colName];
            sfcHideData.Condition = FormatConditionEnum.Expression;
            sfcHideData.Expression = "[" + colName + "] == " + value + " AND [StockCode] == '" + rowName + "'";
            sfcHideData.Appearance.ForeColor = Color.LightGray;
            sfcHideData.Appearance.Options.UseForeColor = true;
            gridView.FormatConditions.Add(sfcHideData);
        }

        private void HideData(string rowName, string colName) {
            StyleFormatCondition sfcHideData = new StyleFormatCondition();
            sfcHideData.Column = gridView.Columns[colName];
            sfcHideData.Condition = FormatConditionEnum.Expression;
            sfcHideData.Expression = "[StockCode] == '" + rowName + "'";
            sfcHideData.Appearance.ForeColor = Color.LightGray;
            sfcHideData.Appearance.Options.UseForeColor = true;
            gridView.FormatConditions.Add(sfcHideData);
        }
        
        private void SetCaption(string name, string caption, int index) {
            gridView.Columns[name].Caption = caption;
            gridView.Columns[name].VisibleIndex = index;
            if (index > 3 && index < 21) {
                gridView.Columns[name].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView.Columns[name].DisplayFormat.FormatString = "0.00"; 
            }
        }

        #endregion

        #region Events

        #region Navigator

        private void SetDataSource(Portfolio portfolio) {
            if (portfolio.Invests == null) { return; }
            bool calcTotals = portfolio.Code != "SUMMARY";
            portfolio.SetTotals(calcTotals);
            gridCtrl.DataSource = null;
            gridCtrl.DataSource = portfolio.Invests.Values;
            SetCaptions();
            HideColumns();
            gridView.BestFitColumns();
            gridCtrl.Show();
        }

        #endregion

        #region Selection

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (gridView.GetRow(e.FocusedRowHandle) == null) { return; }
            currInvest = ((BusinessModel.Invest)(gridView.GetRow(e.FocusedRowHandle)));
            if (AfterSelectRow != null) { AfterSelectRow(this, e); }
        }

        internal void SelectPrev() {
            try {
                int index = gridView.GetSelectedRows()[0];
                gridView.UnselectRow(index);
                gridView.SelectRow(index - 1);
                ulong stockId = Convert.ToUInt64(gridView.GetFocusedDataRow()["stockId"]);
                //currStock = stocks[stockId];
                DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(index, index - 1);
                if (AfterSelectRow != null) { AfterSelectRow(this, e); }
            }
            catch { MessageBox.Show("No hay mas registros"); }
        }

        internal void SelectNext() {
            try {
                int index = gridView.GetSelectedRows()[0];
                gridView.UnselectRow(index);
                gridView.SelectRow(index + 1);
                ulong stockId = Convert.ToUInt64(gridView.GetFocusedDataRow()["stockId"]);
                //currStock = stocks[stockId];
                DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(index, index + 1);
                if (AfterSelectRow != null) { AfterSelectRow(this, e); }
            }
            catch { MessageBox.Show("No hay mas registros"); }
        }

        #endregion

        private void gridCtrl_DataSourceChanged(object sender, EventArgs e) {
            Sort();
        }


        #endregion

    }
}
