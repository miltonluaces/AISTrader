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

    public partial class OperationsCtrl : UserControl {

        #region Fields & Events

        private List<Operation> operations;
      
        public event EventHandler AfterSelectRow;

        #endregion

        #region Constructor

        public OperationsCtrl() {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public void LoadData(List<Operation> operations) {
            this.operations = operations;
            foreach (Operation op in operations) { 
                op.Stock.Read();
                op.Portfolio.Read();
            }
            SetDataSource(operations);
        }

        public void ExportToXls(string fileName) {
            gridCtrl.ExportToXls(@"..\..\..\Documents\" + fileName + ".xls");
        }

        public void CloseOperations() {
            Operation op;
            foreach (int index in gridView.GetSelectedRows()) {
                op = ((BusinessModel.Operation)(gridView.GetRow(index)));
                op.Status = Operation.StatusType.Closed;
                op.SaveUpdate();
                this.operations.Remove(op);
            }
            gridCtrl.DataSource = operations;
            gridCtrl.RefreshDataSource();
        }
        
        #endregion

        #region Private Methods

        private void HideColumns() {
            string[] hideCols = { "Id", "Stock", "Code", "Creation" };
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
            gridView.Appearance.OddRow.BackColor = Color.WhiteSmoke;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.LightGray;

            SetCaption("Id", "Id", 0);
            SetCaption("StockCode", "Codigo", 1);
            SetCaption("PortfolioCode", "Portfolio", 2);
            SetCaption("StockName", "Valor", 3);
            SetCaption("BuyDate", "Compra", 4);
            SetCaption("SellDate", "Venta", 5);
            SetCaption("Type", "Tipo", 6);
            SetCaption("Qty", "Cantidad", 7);
            SetCaption("BuyValue", "Val.Compra", 8);
            SetCaption("SellValue", "Val.Venta", 9);
            SetCaption("BuyCom", "Com.Compra", 10);
            SetCaption("SellCom", "Com.Venta", 11);
            SetCaption("Profit", "Ganancia", 12);
            SetCaption("Status", "Estado", 13);
        }

        private void SetCaption(string name, string caption, int index) {
            gridView.Columns[name].Caption = caption;
            gridView.Columns[name].VisibleIndex = index;
        }

        private void SetDataSource(List<Operation> operations) {
            gridCtrl.DataSource = operations;
            gridCtrl.RefreshDataSource();
            HideColumns();
            SetCaptions();
            gridView.BestFitColumns();
            gridCtrl.Show();
        }

        #endregion

        #region Events

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (gridView.GetRow(e.FocusedRowHandle) == null) { return; }
            //currInvest.Stock = ((BusinessModel.Stock)(gridView.GetRow(e.FocusedRowHandle)));
            if (AfterSelectRow != null) { AfterSelectRow(this, e); }
        }

        internal void SelectPrev() {
            try {
                int index = gridView.GetSelectedRows()[0];
                gridView.UnselectRow(index);
                gridView.SelectRow(index - 1);
                string code = gridView.GetFocusedDataRow()["code"].ToString();
                //currInvest.Stock = stocks[code];
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
                //currInvest.Stock = stocks[code];
                DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(index, index + 1);
                if (AfterSelectRow != null) { AfterSelectRow(this, e); }
            }
            catch { MessageBox.Show("No hay mas registros"); }
        }

        #endregion

    }
}

