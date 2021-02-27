namespace GUI {

    partial class OperateFrm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperateFrm));
            this.grQty = new DevExpress.XtraEditors.GroupControl();
            this.buttOk = new DevExpress.XtraEditors.SimpleButton();
            this.grTechLev = new System.Windows.Forms.GroupBox();
            this.txtTakeProfit = new DevExpress.XtraEditors.TextEdit();
            this.txtStopLoss = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labOpAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.toggleOper = new DevExpress.XtraEditors.ToggleSwitch();
            this.labName = new DevExpress.XtraEditors.TextEdit();
            this.labCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labNewAmount = new DevExpress.XtraEditors.TextEdit();
            this.labNewValue = new DevExpress.XtraEditors.TextEdit();
            this.labNewQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labCurrAmount = new DevExpress.XtraEditors.TextEdit();
            this.labCurrValue = new DevExpress.XtraEditors.TextEdit();
            this.labCurrQty = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labCurrTakeProfit = new DevExpress.XtraEditors.TextEdit();
            this.labNewTakeProfit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labCurrStopLoss = new DevExpress.XtraEditors.TextEdit();
            this.labNewStopLoss = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grQty)).BeginInit();
            this.grQty.SuspendLayout();
            this.grTechLev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTakeProfit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopLoss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labOpAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleOper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrTakeProfit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewTakeProfit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrStopLoss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewStopLoss.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grQty
            // 
            this.grQty.Controls.Add(this.buttOk);
            this.grQty.Controls.Add(this.grTechLev);
            this.grQty.Controls.Add(this.labelControl5);
            this.grQty.Controls.Add(this.labOpAmount);
            this.grQty.Controls.Add(this.txtQty);
            this.grQty.Controls.Add(this.labelControl4);
            this.grQty.Controls.Add(this.toggleOper);
            this.grQty.Controls.Add(this.labName);
            this.grQty.Controls.Add(this.labCode);
            this.grQty.Controls.Add(this.labelControl1);
            this.grQty.Location = new System.Drawing.Point(6, 6);
            this.grQty.Name = "grQty";
            this.grQty.Size = new System.Drawing.Size(423, 157);
            this.grQty.TabIndex = 0;
            this.grQty.Text = "Operación";
            // 
            // buttOk
            // 
            this.buttOk.Image = ((System.Drawing.Image)(resources.GetObject("buttOk.Image")));
            this.buttOk.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttOk.Location = new System.Drawing.Point(349, 105);
            this.buttOk.Name = "buttOk";
            this.buttOk.Size = new System.Drawing.Size(40, 40);
            this.buttOk.TabIndex = 16;
            this.buttOk.Click += new System.EventHandler(this.buttOk_Click);
            // 
            // grTechLev
            // 
            this.grTechLev.Controls.Add(this.txtTakeProfit);
            this.grTechLev.Controls.Add(this.txtStopLoss);
            this.grTechLev.Controls.Add(this.labelControl10);
            this.grTechLev.Controls.Add(this.labelControl9);
            this.grTechLev.Location = new System.Drawing.Point(22, 99);
            this.grTechLev.Name = "grTechLev";
            this.grTechLev.Size = new System.Drawing.Size(316, 47);
            this.grTechLev.TabIndex = 16;
            this.grTechLev.TabStop = false;
            this.grTechLev.Text = "Niveles Técnicos";
            // 
            // txtTakeProfit
            // 
            this.txtTakeProfit.Location = new System.Drawing.Point(242, 18);
            this.txtTakeProfit.Name = "txtTakeProfit";
            this.txtTakeProfit.Size = new System.Drawing.Size(65, 20);
            this.txtTakeProfit.TabIndex = 15;
            this.txtTakeProfit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTakeProfit_KeyDown);
            // 
            // txtStopLoss
            // 
            this.txtStopLoss.Location = new System.Drawing.Point(92, 18);
            this.txtStopLoss.Name = "txtStopLoss";
            this.txtStopLoss.Size = new System.Drawing.Size(56, 20);
            this.txtStopLoss.TabIndex = 13;
            this.txtStopLoss.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStopLoss_KeyDown);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(178, 21);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(56, 13);
            this.labelControl10.TabIndex = 16;
            this.labelControl10.Text = "Take Profit:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(35, 21);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(51, 13);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Stop-Loss:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(136, 74);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Monto:";
            // 
            // labOpAmount
            // 
            this.labOpAmount.Location = new System.Drawing.Point(176, 71);
            this.labOpAmount.Name = "labOpAmount";
            this.labOpAmount.Properties.ReadOnly = true;
            this.labOpAmount.Size = new System.Drawing.Size(60, 20);
            this.labOpAmount.TabIndex = 14;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(75, 71);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(55, 20);
            this.txtQty.TabIndex = 1;
            this.txtQty.EditValueChanged += new System.EventHandler(this.txtQty_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 74);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Cantidad:";
            // 
            // toggleOper
            // 
            this.toggleOper.Location = new System.Drawing.Point(262, 67);
            this.toggleOper.Name = "toggleOper";
            this.toggleOper.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.toggleOper.Properties.Appearance.Options.UseFont = true;
            this.toggleOper.Properties.OffText = " Compra   ";
            this.toggleOper.Properties.OnText = " Venta";
            this.toggleOper.Size = new System.Drawing.Size(137, 26);
            this.toggleOper.TabIndex = 3;
            this.toggleOper.Toggled += new System.EventHandler(this.toggleOper_Toggled);
            // 
            // labName
            // 
            this.labName.Location = new System.Drawing.Point(136, 39);
            this.labName.Name = "labName";
            this.labName.Properties.ReadOnly = true;
            this.labName.Size = new System.Drawing.Size(253, 20);
            this.labName.TabIndex = 2;
            // 
            // labCode
            // 
            this.labCode.Location = new System.Drawing.Point(75, 39);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(55, 20);
            this.labCode.TabIndex = 13;
            this.labCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.labCode_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Valor:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Posterior:";
            // 
            // labNewAmount
            // 
            this.labNewAmount.Location = new System.Drawing.Point(200, 79);
            this.labNewAmount.Name = "labNewAmount";
            this.labNewAmount.Properties.ReadOnly = true;
            this.labNewAmount.Size = new System.Drawing.Size(68, 20);
            this.labNewAmount.TabIndex = 10;
            // 
            // labNewValue
            // 
            this.labNewValue.Location = new System.Drawing.Point(132, 79);
            this.labNewValue.Name = "labNewValue";
            this.labNewValue.Properties.ReadOnly = true;
            this.labNewValue.Size = new System.Drawing.Size(66, 20);
            this.labNewValue.TabIndex = 9;
            // 
            // labNewQty
            // 
            this.labNewQty.Location = new System.Drawing.Point(76, 79);
            this.labNewQty.Name = "labNewQty";
            this.labNewQty.Properties.ReadOnly = true;
            this.labNewQty.Size = new System.Drawing.Size(55, 20);
            this.labNewQty.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Actual:";
            // 
            // labCurrAmount
            // 
            this.labCurrAmount.Location = new System.Drawing.Point(200, 53);
            this.labCurrAmount.Name = "labCurrAmount";
            this.labCurrAmount.Properties.ReadOnly = true;
            this.labCurrAmount.Size = new System.Drawing.Size(68, 20);
            this.labCurrAmount.TabIndex = 6;
            // 
            // labCurrValue
            // 
            this.labCurrValue.Location = new System.Drawing.Point(132, 53);
            this.labCurrValue.Name = "labCurrValue";
            this.labCurrValue.Properties.ReadOnly = true;
            this.labCurrValue.Size = new System.Drawing.Size(66, 20);
            this.labCurrValue.TabIndex = 5;
            // 
            // labCurrQty
            // 
            this.labCurrQty.Location = new System.Drawing.Point(75, 53);
            this.labCurrQty.Name = "labCurrQty";
            this.labCurrQty.Properties.ReadOnly = true;
            this.labCurrQty.Size = new System.Drawing.Size(55, 20);
            this.labCurrQty.TabIndex = 4;
            this.labCurrQty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labCurrQty_MouseDown);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labCurrTakeProfit);
            this.groupControl1.Controls.Add(this.labNewTakeProfit);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.labCurrStopLoss);
            this.groupControl1.Controls.Add(this.labNewStopLoss);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labCurrQty);
            this.groupControl1.Controls.Add(this.labCurrValue);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labCurrAmount);
            this.groupControl1.Controls.Add(this.labNewAmount);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labNewValue);
            this.groupControl1.Controls.Add(this.labNewQty);
            this.groupControl1.Location = new System.Drawing.Point(6, 168);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(423, 118);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Situación actual y posterior:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(344, 34);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(56, 13);
            this.labelControl12.TabIndex = 20;
            this.labelControl12.Text = "Take Profit:";
            // 
            // labCurrTakeProfit
            // 
            this.labCurrTakeProfit.Location = new System.Drawing.Point(340, 53);
            this.labCurrTakeProfit.Name = "labCurrTakeProfit";
            this.labCurrTakeProfit.Properties.ReadOnly = true;
            this.labCurrTakeProfit.Size = new System.Drawing.Size(68, 20);
            this.labCurrTakeProfit.TabIndex = 18;
            // 
            // labNewTakeProfit
            // 
            this.labNewTakeProfit.Location = new System.Drawing.Point(340, 79);
            this.labNewTakeProfit.Name = "labNewTakeProfit";
            this.labNewTakeProfit.Properties.ReadOnly = true;
            this.labNewTakeProfit.Size = new System.Drawing.Size(68, 20);
            this.labNewTakeProfit.TabIndex = 19;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(278, 34);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(51, 13);
            this.labelControl11.TabIndex = 17;
            this.labelControl11.Text = "Stop-Loss:";
            // 
            // labCurrStopLoss
            // 
            this.labCurrStopLoss.Location = new System.Drawing.Point(270, 53);
            this.labCurrStopLoss.Name = "labCurrStopLoss";
            this.labCurrStopLoss.Properties.ReadOnly = true;
            this.labCurrStopLoss.Size = new System.Drawing.Size(68, 20);
            this.labCurrStopLoss.TabIndex = 15;
            // 
            // labNewStopLoss
            // 
            this.labNewStopLoss.Location = new System.Drawing.Point(270, 79);
            this.labNewStopLoss.Name = "labNewStopLoss";
            this.labNewStopLoss.Properties.ReadOnly = true;
            this.labNewStopLoss.Size = new System.Drawing.Size(68, 20);
            this.labNewStopLoss.TabIndex = 16;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(206, 34);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(59, 13);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Monto total:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(137, 34);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Valor actual:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(80, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Cantidad:";
            // 
            // OperateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 292);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grQty);
            this.Location = new System.Drawing.Point(1000, 600);
            this.Name = "OperateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OperateFrm";
            ((System.ComponentModel.ISupportInitialize)(this.grQty)).EndInit();
            this.grQty.ResumeLayout(false);
            this.grQty.PerformLayout();
            this.grTechLev.ResumeLayout(false);
            this.grTechLev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTakeProfit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopLoss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labOpAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleOper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrTakeProfit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewTakeProfit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labCurrStopLoss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labNewStopLoss.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grQty;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit labNewAmount;
        private DevExpress.XtraEditors.TextEdit labNewValue;
        private DevExpress.XtraEditors.TextEdit labNewQty;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit labCurrAmount;
        private DevExpress.XtraEditors.TextEdit labCurrValue;
        private DevExpress.XtraEditors.TextEdit labCurrQty;
        private DevExpress.XtraEditors.ToggleSwitch toggleOper;
        private DevExpress.XtraEditors.TextEdit labName;
        private DevExpress.XtraEditors.TextEdit labCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton buttOk;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit labOpAmount;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.GroupBox grTechLev;
        private DevExpress.XtraEditors.TextEdit txtTakeProfit;
        private DevExpress.XtraEditors.TextEdit txtStopLoss;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit labCurrTakeProfit;
        private DevExpress.XtraEditors.TextEdit labNewTakeProfit;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit labCurrStopLoss;
        private DevExpress.XtraEditors.TextEdit labNewStopLoss;
    }
}