namespace GUI {

    partial class AddStockFrm {

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton buttOk;
        private DevExpress.XtraEditors.SimpleButton buttCancel; 
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {  components.Dispose();  }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStockFrm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.buttOk = new DevExpress.XtraEditors.SimpleButton();
            this.buttCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtSource = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboMarket = new System.Windows.Forms.ComboBox();
            this.comboCurrency = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Código:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(55, 27);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(64, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(215, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(312, 20);
            this.txtName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(168, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Nombre:";
            // 
            // buttOk
            // 
            this.buttOk.Image = ((System.Drawing.Image)(resources.GetObject("buttOk.Image")));
            this.buttOk.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttOk.Location = new System.Drawing.Point(707, 17);
            this.buttOk.Name = "buttOk";
            this.buttOk.Size = new System.Drawing.Size(40, 40);
            this.buttOk.TabIndex = 17;
            this.buttOk.Click += new System.EventHandler(this.buttOk_Click);
            // 
            // buttCancel
            // 
            this.buttCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttCancel.Image")));
            this.buttCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttCancel.Location = new System.Drawing.Point(661, 17);
            this.buttCancel.Name = "buttCancel";
            this.buttCancel.Size = new System.Drawing.Size(40, 40);
            this.buttCancel.TabIndex = 18;
            this.buttCancel.Click += new System.EventHandler(this.buttCancel_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(55, 70);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(99, 20);
            this.txtSource.TabIndex = 20;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "Fuente:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(168, 73);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Mercado:";
            // 
            // comboMarket
            // 
            this.comboMarket.FormattingEnabled = true;
            this.comboMarket.Location = new System.Drawing.Point(233, 70);
            this.comboMarket.Name = "comboMarket";
            this.comboMarket.Size = new System.Drawing.Size(102, 21);
            this.comboMarket.TabIndex = 22;
            // 
            // comboCurrency
            // 
            this.comboCurrency.FormattingEnabled = true;
            this.comboCurrency.Location = new System.Drawing.Point(425, 70);
            this.comboCurrency.Name = "comboCurrency";
            this.comboCurrency.Size = new System.Drawing.Size(102, 21);
            this.comboCurrency.TabIndex = 24;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(360, 73);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Moneda:";
            // 
            // AddStockFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 117);
            this.Controls.Add(this.comboCurrency);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.comboMarket);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.buttCancel);
            this.Controls.Add(this.buttOk);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.Name = "AddStockFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar un Valor al Monitoreo";
            this.Load += new System.EventHandler(this.AddStockFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSource.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSource;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox comboMarket;
        private System.Windows.Forms.ComboBox comboCurrency;
        private DevExpress.XtraEditors.LabelControl labelControl5;

        
    }
}