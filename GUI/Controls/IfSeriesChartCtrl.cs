#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using BusinessModel;
using System.Diagnostics;

#endregion


namespace GUI {

    public partial class IfsSeriesChartCtrl : UserControl {

        #region Fields

        private TSeries ts;
        private DataTable dtSeries;

        private bool hist;
        private bool fcst;
        private bool update = false;
        private ConstantLine todayLine;
        private Stock stock;
        private ConstantLine firstHistLine;
        private int span;
        private double minValue = 0;
        private double maxValue = double.MaxValue;
        private ChartTypeType chartType;

        #endregion

        #region Constructor

        public IfsSeriesChartCtrl() {
            InitializeComponent();
            CreateDataTable();
            chartType = IfsSeriesChartCtrl.ChartTypeType.xyLines;
        }

        public bool Hist {
            get { return hist; }
            set { hist = value; }
        }

        public bool Fcst {
            get { return fcst; }
            set { fcst = value; }
        }

        private void CreateDataTable() {
            dtSeries = new DataTable("Series");
            dtSeries.Columns.Add("Serie", typeof(String));
            dtSeries.Columns.Add("Date", typeof(DateTime));
            dtSeries.Columns.Add("Value", typeof(Double));
        }

        #endregion

        #region Properties

        public TSeries TS {
            get { return ts; }
        }

        public ChartTypeType ChartType {
            get { return chartType; }
            set { chartType = value; }
        }

        #endregion

        #region Load Methods


        internal void LoadData(Stock stock) {
            this.stock = stock;
            ts = new TSeries();
            try { ts.Read("stockId", stock.Id); }
            catch(Exception ex) { Console.WriteLine("Error en lectura de Sku para Grafico Pronostico" + ex.StackTrace); }
        }

        public void LoadTSeries(Stock stock) {
            this.stock = stock;
            ts = stock.TSeries;
        }
        
        public void ClearSelection() {
            hist = true;
            fcst = false;
        }

        public void Clear() {
            hist = true;
            span = 1;
            dtSeries.Clear();
            chartCtrl.DataSource = null;
            chartCtrl.SeriesTemplate.View = new LineSeriesView();
            chartCtrl.ClearSelection();
            chartCtrl.RefreshData();
            chartCtrl.Show();
        }

        public void ShowSeries(int nPeriods) {
            chartCtrl.Titles[0].Text = stock.Name + " (" + stock.Code + ")";

            if (ts == null || ts.Id == 0) {
                this.Visible = false;
                return; 
            }
            Clear();

            chartCtrl.Series.Clear();
            Series hist = new Series("Hist", ViewType.CandleStick);
            hist.ArgumentScaleType = ScaleType.DateTime;
            chartCtrl.Series.Add(hist);
            Series fcst = new Series("Fcst", ViewType.CandleStick);
            fcst.ArgumentScaleType = ScaleType.DateTime;
            chartCtrl.Series.Add(fcst);
              
      
            FillDataTable(nPeriods);

            //XY titles           
            XYDiagram xyDiagram = (XYDiagram)this.chartCtrl.Diagram;
            //xyDiagram.AxisX.Title.Text = xTitle;

            //xyDiagram.AxisY.Title.Text = yTitle;
            SeriesPoint simPoint = new SeriesPoint(20);
            //xyDiagram.AxisY.VisualRange.Auto = false;
            //xyDiagram.AxisY.VisualRange.SetMinMaxValues(minValue, maxValue);
            xyDiagram.AxisY.WholeRange.Auto = false;
            xyDiagram.AxisY.WholeRange.SetMinMaxValues(minValue, maxValue);
            xyDiagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
       
            // Specify the template's series view.
            LineSeriesView lsv = new LineSeriesView();
            chartCtrl.SeriesTemplate.View = lsv;
            lsv.LineStyle.Thickness = 3;
            lsv.AxisY.WholeRange.Auto = false;
            lsv.AxisY.WholeRange.SetMinMaxValues(minValue, maxValue);
            lsv.AxisY.WholeRange.AutoSideMargins = false;
            lsv.AxisY.WholeRange.SideMarginsValue = 1;
            lsv.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            
            chartCtrl.DataSource = dtSeries;
            DataColumn[] primaryKey = { dtSeries.Columns["Serie"], dtSeries.Columns["Date"] };
            dtSeries.PrimaryKey = primaryKey;
            // Specify data members to bind the chart's series template.
            chartCtrl.SeriesDataMember = "Serie";
            chartCtrl.SeriesTemplate.ArgumentDataMember = "Date";
            chartCtrl.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            // Specify the template's series view.
            this.chartCtrl.SeriesTemplate.View = new LineSeriesView();
                 
            // Specify the template's name prefix.
            chartCtrl.SeriesNameTemplate.BeginText = "Serie: ";
            chartCtrl.RefreshData();
            chartCtrl.Show();
            // Dock the chart into its parent, and add it to the current form.
            //chartCtrl.Dock = DockStyle.Fill;
        }

        public enum ChartTypeType { xyLines, candleStick };

        public void ShowCandleStickSeries(int nPeriods) {
            if (nPeriods > ts.Open.Count) { nPeriods = ts.Open.Count; }
            chartCtrl.Series.Clear();

            chartCtrl.Titles[0].Text = stock.Name + " (" + stock.Code + ")";
            
            Series stockSerie = new Series("Stock Prices", ViewType.CandleStick);
            stockSerie.ArgumentScaleType = ScaleType.DateTime;
            double[] vals;
            minValue = double.MaxValue;
            maxValue = double.MinValue;
            int ini = ts.Open.Count - nPeriods;
            DateTime date = ts.EndHist.AddDays(-nPeriods-1).AddYears(1); //TODO: corregir año
            for(int i=ini;i<ts.Open.Count;i++) {
                if (ts.Low[i] >= 0) {
                    vals = new double[4];
                    vals[0] = ts.Low[i];
                    vals[1] = ts.High[i];
                    vals[2] = ts.Open[i];
                    vals[3] = ts.Close[i];
                    if (vals[1] < minValue) { minValue = ts.Low[i]; }
                    if (vals[2] > maxValue) { maxValue = ts.High[i]; }
                    stockSerie.Points.Add(new SeriesPoint(date, vals));
                }
                date = date.AddDays(1);
            }
            minValue = minValue * 0.9; if (minValue < 0) { minValue = 0; }
            maxValue = maxValue * 1.1;
            
            chartCtrl.Series.Add(stockSerie);
            CandleStickSeriesView csView = new CandleStickSeriesView();
            csView.ReductionOptions.Level = StockLevel.Open;
            csView.ReductionOptions.Visible = true;

            XYDiagram xyDiagram = (XYDiagram)this.chartCtrl.Diagram;
            xyDiagram.AxisY.WholeRange.Auto = false;
            xyDiagram.AxisY.WholeRange.SetMinMaxValues(minValue, maxValue);
            xyDiagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
            chartCtrl.SeriesTemplate.View = csView;
            csView.LineThickness = 1;
            csView.LevelLineLength = 0.25;
            csView.AxisY.WholeRange.Auto = false;
            csView.AxisY.WholeRange.SetMinMaxValues(minValue, maxValue);
            csView.AxisY.WholeRange.AutoSideMargins = false;
            csView.AxisY.WholeRange.SideMarginsValue = 1;
    
            chartCtrl.Show();
        }
        
        private void FillDataTable(int nPeriods) {
            minValue = double.MaxValue;
            maxValue = double.MinValue;
            foreach (double val in ts.Close) {
                if (val < 0) { continue; }
                if (val < minValue) { minValue = val; }
                if (val > maxValue) { maxValue = val; }
            }
            minValue = minValue * 0.9; if (minValue < 0) { minValue = 0; }
            maxValue = maxValue * 1.1;

            DateTime histDate = new DateTime(1900, 1, 1);
            DateTime fcstDate = new DateTime(1900, 1, 1);
            List<double> serieHist = new List<double>();
            List<double> serieFcst = new List<double>();
            List<double> serieOver = new List<double>();
            if (hist) {
                serieHist = ts.Close;
                histDate = ts.IniHist;
            }
            if (fcst && ts.Fcst != null) {
                serieFcst = ts.Fcst;
                serieFcst.Insert(0, ts.Close[ts.Close.Count - 1]);
                fcstDate = ts.IniHist.AddDays(ts.Close.Count - 1);
                int serieCount = Math.Min(serieFcst.Count, serieOver.Count);
                for (int i = 0; i < serieCount; i++) { serieOver[i] += serieFcst[i]; }
            }
            if (hist) {
                FillDataTable("Hist", histDate, serieHist, nPeriods);
            }
            if (fcst) {
                if (!hist) {
                    FillDataTable("Fcst", ts.EndHist, serieFcst);
                }
                FillDataTable("Fcst", fcstDate, serieFcst);
                if (ts.Close == null || ts.Close.Count == 0) { return; }
                DateTime today = fcstDate;
                //if (stock != null) { DrawFirstHistLine(ts.FirstHistDate); }
                DrawTodayLine(today);
                chartCtrl.Show();
            }
        }


        public void FillDataTable(string name, DateTime firstDate, List<double> serie, int nPeriods) {
            if (nPeriods > ts.Open.Count) { nPeriods = ts.Open.Count; }
            //Debug.WriteLine("\n" + name + ":");
            if (serie == null || serie.Count == 0) { return; }
            //DateTime date = ts.EndHist.AddDays(-nPeriods - 1);
            DateTime date = ts.EndHist.AddDays(-nPeriods+1);
            for (int i = serie.Count - nPeriods; i < serie.Count; i++) {
                if (serie[i] >= 0) { dtSeries.Rows.Add(new object[] { name, date, serie[i] }); }
                //Debug.WriteLine(date + "\t" + serie[i]);
                date = date.AddDays(1);
            }
        }
        
        public void FillDataTable(string name, DateTime firstDate, List<double> serie) {
            //Debug.WriteLine("\n" + name + ":");
            if (serie == null || serie.Count == 0) { return; }
            DateTime date = firstDate;
            for (int i = 0; i < serie.Count; i++) {
                if (serie[i] >= 0) { dtSeries.Rows.Add(new object[] { name, date, serie[i] }); }
                //Debug.WriteLine(date + "\t" + serie[i]);
                date = date.AddDays(1);
            }
        }

        public void UpdateFcst(string serieName, List<double> values) {
            ts.Fcst = values;
            DateTime date = ts.IniFcst;
            DataRow row;
            for (int i = 0; i < values.Count; i++) {
                row = dtSeries.Rows.Find(new object[] { serieName, date });
                if (row != null && Convert.ToDouble(row.ItemArray[2]) != values[i]) {
                    row.ItemArray = new object[] { serieName, date, values[i] };
                }
                date = date.AddDays(1);
            }
            chartCtrl.DataSource = dtSeries;
            chartCtrl.RefreshData();
            chartCtrl.Refresh();
            //DrawFirstHistLine(stock.FirstHistDate);
        }

        public void ValidFcst(List<double> validFcst) {
            List<double> serieValid = new List<double>();
            for (int i = 0; i < ts.Open.Count - validFcst.Count; i++) { serieValid.Add(ts.Open[i]); }
            for (int i = 0; i < validFcst.Count; i++) { serieValid.Add(validFcst[i]); }
            FillDataTable("ValidFcst", ts.EndHist, serieValid);
            chartCtrl.Refresh();
        }

        #endregion

        #region Lines

        private void DrawTodayLine(DateTime today) {
            if (chartCtrl.Diagram == null) { return; }
            if (todayLine != null) {
                ((XYDiagram)chartCtrl.Diagram).AxisX.ConstantLines.Remove(todayLine);
            }
            todayLine = new ConstantLine("Constant Line 1");
            todayLine.Visible = true;
            todayLine.ShowInLegend = false;
            todayLine.ShowBehind = false;
            todayLine.Title.Visible = false;
            todayLine.Color = Color.Black;
            todayLine.LineStyle.DashStyle = DashStyle.Solid;
            todayLine.LineStyle.Thickness = 2;

            todayLine.AxisValue = today;
            ((XYDiagram)chartCtrl.Diagram).AxisX.ConstantLines.Add(todayLine);
        }

        private void DrawFirstHistLine(DateTime firstHistDate) {
            if (chartCtrl.Diagram == null) { return; }
            if (firstHistLine != null) {
                ((XYDiagram)chartCtrl.Diagram).AxisX.ConstantLines.Remove(firstHistLine);
            }
            firstHistLine = new ConstantLine("Constant Line 1");
            firstHistLine.Visible = true;
            firstHistLine.ShowInLegend = false;
            firstHistLine.ShowBehind = false;
            firstHistLine.Title.Visible = false;
            firstHistLine.Color = Color.Red;
            firstHistLine.LineStyle.DashStyle = DashStyle.DashDot;
            firstHistLine.LineStyle.Thickness = 2;

            firstHistLine.AxisValue = firstHistDate;
            ((XYDiagram)chartCtrl.Diagram).AxisX.ConstantLines.Add(firstHistLine);
        }

        #endregion

        #region Events

        private void chartCtrl_Enter(object sender, EventArgs e) {
            Clear();
        }

        #endregion
    }
}
