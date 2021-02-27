#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;
using MachineLearning;
using System.Diagnostics;

#endregion

namespace Trading {

    public class NNForecastCalc : IForecastCalc {

        #region Fields

        private Stock stock;
        private BusinessModel.TSeries ts;
        private int firstFcstPN;
        private int fcstHorizon;
        private CalcReport calcRep;
        private TDNN tdnn;
        private int movingWindow;
        private int epochs;
        private int nnTrendValues;
        private double nnTrendPerc;

        #endregion

        #region Constructor

        public NNForecastCalc() {
            firstFcstPN = 1;
            movingWindow = 10;
            fcstHorizon = 30;
            epochs = 200;
            nnTrendValues = 5;
            nnTrendPerc = 15;
            tdnn = new TDNN();
            calcRep = new CalcReport("Forecast");
        }

        #endregion

        #region Properties

        public Stock Stock {
            get { return stock; }
        }

        public int FirstFcstPN {
            get { return firstFcstPN; }
            set { firstFcstPN = value; }
        }

        public DateTime GetFirstHistDate() {
            return ts.IniHist;
        }

        public BusinessModel.TSeries Ts {
            get { return ts; }
        }

        public List<double> GetForecast() {
            return ts.Fcst;
        }

        #endregion

        #region IForecast Members

        public void LoadData(Stock stock) {
            LoadParameters();
            this.stock = stock;
            ts = new BusinessModel.TSeries();
            ts.Read("stockId", stock.Id);
        }

        public void LoadData(BusinessModel.TSeries ts) {
            LoadParameters();
            this.stock = ts.Stock;
            this.ts = ts;
        }

        public void Calculate() {
            List<double> hist = new List<double>(ts.Open);  //TODO: completar usando todo
            tdnn.LoadSerie(hist, firstFcstPN);
            Debug.WriteLine("Normalizing factor = " + (tdnn.NormFactor * 100) + "%");

            double[] fcst = tdnn.Process(epochs, fcstHorizon);
            ts.Open = new List<double>();
            for (int i = 0; i < fcst.Length; i++) { ts.Open.Add(Math.Round(fcst[i])); }
        }

        public List<double> GetFcst() {
            return ts.Open;
        }

        public List<double> GetValidForecast(int t) {
            List<double> fcst = new List<double>();
            return fcst;
        }

        public List<string> GetCalcReport() {
            return calcRep.GetReport();
        }

        public void Save() {
            ts.SaveUpdate();
        }

        #endregion

        #region Private Methods

        private void LoadParameters() {
            SysEnvironment sysEnv = SysEnvironment.GetInstance();
            movingWindow = Convert.ToInt32(sysEnv.GetParameter("nnMovWin").GetValue());
            epochs = Convert.ToInt32(sysEnv.GetParameter("nnEpochs").GetValue());
            nnTrendValues = Convert.ToInt32(sysEnv.GetParameter("nnTrendValues").GetValue());
            nnTrendPerc = Convert.ToDouble(sysEnv.GetParameter("nnTrendPerc").GetValue());

            tdnn.MovingWindow = movingWindow;
            tdnn.Epochs = epochs;
            tdnn.TrendValues = nnTrendValues;
            tdnn.TrendPerc = nnTrendPerc;
        }

        private void LoadHistTs(Stock stock) {
            ts = new BusinessModel.TSeries();
            ts.Stock = stock;
        }

        #endregion

    }
}
