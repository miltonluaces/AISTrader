namespace GUI  {

    partial class IfsSeriesChartCtrl  {

        #region Fields

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraCharts.ChartControl chartCtrl;
 
        #endregion

        #region Initialization

        private void InitializeComponent()  {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.chartCtrl = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCtrl
            // 
            this.chartCtrl.AppearanceNameSerializable = "Chameleon";
            this.chartCtrl.BackColor = System.Drawing.Color.White;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartCtrl.Diagram = xyDiagram1;
            this.chartCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCtrl.Legend.Visible = false;
            this.chartCtrl.Location = new System.Drawing.Point(0, 0);
            this.chartCtrl.Name = "chartCtrl";
            this.chartCtrl.PaletteName = "ChartVisib";
            this.chartCtrl.PaletteRepository.Add("ChartVisib", new DevExpress.XtraCharts.Palette("ChartVisib", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(16)))), ((int)(((byte)(250))))), System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(16)))), ((int)(((byte)(250)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(141)))), ((int)(((byte)(53))))), System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(141)))), ((int)(((byte)(53)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(7)))), ((int)(((byte)(68))))), System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(7)))), ((int)(((byte)(68))))))}));
            pointOptions1.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            sideBySideBarSeriesLabel1.PointOptions = pointOptions1;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.Name = "Series 1";
            series2.Name = "Series 2";
            this.chartCtrl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartCtrl.Size = new System.Drawing.Size(782, 350);
            this.chartCtrl.TabIndex = 0;
            chartTitle1.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.chartCtrl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.chartCtrl.Enter += new System.EventHandler(this.chartCtrl_Enter);
            // 
            // IfsSeriesChartCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartCtrl);
            this.Name = "IfsSeriesChartCtrl";
            this.Size = new System.Drawing.Size(782, 350);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Events

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion


    }
}
