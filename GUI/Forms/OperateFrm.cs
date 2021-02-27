#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessModel;

#endregion

namespace GUI {
    public partial class OperateFrm : Form {

        private Dictionary<string, Stock> stocks;
        private Portfolio port;
        private Invest inv;
        private double opQty;
        private double newQty;
        private bool isSell;
        private bool isNewStock;

        public OperateFrm(Dictionary<string, Stock> stocks, Portfolio port, Invest inv) {
            this.stocks = stocks;
            this.port = port;
            this.inv = inv;
            InitializeComponent();
            LoadData();
            this.opQty = 0;
            this.newQty = 0;
            this.isNewStock = false;
        }

        private void LoadData() {
            labCode.Text = inv.StockCode;
            labName.Text = inv.Stock.Name;
            txtQty.Text = "0";
            labOpAmount.Text = "0";
            isSell = false;
            toggleOper.IsOn = isSell;

            labCurrQty.Text = inv.Qty.ToString("0.00");
            labCurrValue.Text = inv.CurrValue.ToString("0.00");
            labCurrAmount.Text = inv.CurrAmount.ToString("0");
            labNewQty.Text = labCurrQty.Text;
            labNewValue.Text = labCurrValue.Text;
            labNewAmount.Text = labCurrAmount.Text;

            labCurrStopLoss.Text = inv.StopLoss.ToString("0");
            labCurrTakeProfit.Text = inv.TakeProfit.ToString("0");
            labNewStopLoss.Text = inv.StopLoss.ToString("0");
            labNewTakeProfit.Text = inv.TakeProfit.ToString("0");
        }

        private void txtQty_EditValueChanged(object sender, EventArgs e) {
            opQty = Convert.ToDouble(txtQty.Text);
            double opAmount = opQty * inv.CurrValue;
            labOpAmount.Text = opAmount.ToString("0.00");
            isSell = toggleOper.IsOn;
            if (isSell) { newQty = inv.Qty - opQty; }
            else { newQty = inv.Qty + opQty; }
            double newAmount = newQty * inv.CurrValue;
            labNewQty.Text = newQty.ToString("0.00");
            labNewAmount.Text = newAmount.ToString("0.00");
        }

        private void buttOk_Click(object sender, EventArgs e) {
            inv.Date = DateTime.Now.AddYears(1); //TODO: ajustar año
            inv.Qty = newQty;
            inv.SetAmounts();
            port.SetTotals(true);
            try {
                if (txtStopLoss.Text == "") { inv.StopLoss = -1; }
                else { inv.StopLoss = Convert.ToDouble(txtStopLoss.Text); }
                if (txtTakeProfit.Text == "") { inv.TakeProfit = -1; }
                else { inv.TakeProfit = Convert.ToDouble(txtTakeProfit.Text); }
            }
            catch {
                inv.StopLoss = -1;
                inv.TakeProfit = -1;
            }
            inv.SaveUpdate();
            if (inv.Qty == 0) {
                inv.Delete();
                port.Invests.Remove(inv.StockCode);
            }
            if (isNewStock) {
                port.Invests.Add(inv.StockCode, inv);
            }
            Operation op = new Operation(inv, opQty, GetOpType(isSell), Operation.StatusType.Open);  //TODO: add comissiones
            op.SaveUpdate();

            Dispose();
        }

        private Operation.OpType GetOpType(bool isSell) {
            if (isSell) { return Operation.OpType.Sell; }
            else { return Operation.OpType.Buy; }
        }

        private void labCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            string stockCode = labCode.Text;
            if (!stocks.ContainsKey(stockCode)) { MessageBox.Show("Error. Este valor no está siendo monitoreado. Ingréselo primero a la lista de valores y posteriormente al Portafolio"); return; }
            labName.Text = stocks[stockCode].Name;
            inv = new Invest();
            inv.Portfolio = port;
            inv.Stock = stocks[stockCode];
            isSell = false;
            toggleOper.IsOn = isSell;
            isNewStock = true;

            labCurrQty.Text = "0";
            labCurrValue.Text = inv.CurrValue.ToString("0.00");
            labCurrAmount.Text = "0";
            labNewQty.Text = "0";
            labNewValue.Text = labCurrValue.Text;
            labNewAmount.Text = "0";
        }

        private void txtStopLoss_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            labNewStopLoss.Text = txtStopLoss.Text;
        }

        private void txtTakeProfit_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData != Keys.Enter) { return; }
            labNewTakeProfit.Text = txtTakeProfit.Text;
        }

        private void toggleOper_Toggled(object sender, EventArgs e) {
            isSell = toggleOper.IsOn;
        }

        private void labCurrQty_MouseDown(object sender, MouseEventArgs e) {
            txtQty.Text = labCurrQty.Text;
            opQty = Convert.ToInt32(txtQty.Text);
            double opAmount = opQty * inv.CurrValue;
            labOpAmount.Text = opAmount.ToString("0.00");
            isSell = toggleOper.IsOn;
            if (isSell) { newQty = inv.Qty - opQty; }
            else { newQty = inv.Qty + opQty; }
            double newAmount = newQty * inv.CurrValue;
            labNewQty.Text = newQty.ToString("0");
            labNewAmount.Text = newAmount.ToString("0.00");
        }
    }
}
