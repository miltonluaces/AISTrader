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

    public partial class StockMonitorCtrl : UserControl {

        #region Fields & Events

        private Dictionary<string, Stock> stocks;
        private Invest currInvest;
        
        public event EventHandler AfterSelectRow;

        #endregion

        #region Constructor

        public StockMonitorCtrl() {
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

        public void LoadData(Dictionary<string, Stock> stocks) {
            if (stocks == null || stocks.Count == 0) { return; }
            this.stocks = stocks;
            SetDataSource(stocks);
        }

        public void ExportToXls(string fileName) {
            gridCtrl.ExportToXls(@"..\..\..\Documents\" + fileName + ".xls");
        }
      
        #endregion

        #region Private Methods

        private void HideColumns( ) {
            string[] hideCols = { "TSeries", "Creation" };
            foreach (string colName in hideCols) {
                if (gridView.Columns[colName] != null) { gridView.Columns[colName].Visible = false; }
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
            gridView.Appearance.OddRow.BackColor = Color.LightYellow;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.PaleGoldenrod;

            SetCaption("Id", "Id", 0);
            SetCaption("Code", "Codigo", 1);
            SetCaption("Name", "Nombre", 2);
            SetCaption("Type", "Tipo", 3);
            SetCaption("Value", "Valor", 4);
            SetCaption("Volume", "Volumen", 5);
            SetCaption("Per", "PER", 6);
            SetCaption("Ebitda", "EBITDA", 7);
            SetCaption("Currency", "Moneda", 8);
            SetCaption("Market", "Mercado", 9);
            SetCaption("Source", "Fuente", 10);
        }

        private void SetCaption(string name, string caption, int index) {
            gridView.Columns[name].Caption = caption;
            gridView.Columns[name].VisibleIndex = index;
        }

        private void SetDataSource(Dictionary<string, Stock> stocks) {
            if (stocks == null) { return; }
            gridCtrl.DataSource = null;
            gridCtrl.DataSource = stocks.Values;
            HideColumns();
            SetCaptions();
            gridView.BestFitColumns();
            gridCtrl.Show();
        }
        
        #endregion

        #region Events

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (gridView.GetRow(e.FocusedRowHandle) == null) { return; }
            currInvest.Stock = ((BusinessModel.Stock)(gridView.GetRow(e.FocusedRowHandle)));
            if (AfterSelectRow != null) { AfterSelectRow(this, e); }
        }

        internal void SelectPrev() {
            try {
                int index = gridView.GetSelectedRows()[0];
                gridView.UnselectRow(index);
                gridView.SelectRow(index - 1);
                string code = gridView.GetFocusedDataRow()["code"].ToString();
                currInvest.Stock = stocks[code];
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
                string code = gridView.GetFocusedDataRow()["code"].ToString();
                currInvest.Stock = stocks[code];
                DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(index, index + 1);
                if (AfterSelectRow != null) { AfterSelectRow(this, e); }
            }
            catch { MessageBox.Show("No hay mas registros"); }
        }

        #endregion

    }
}

