#region Imports

using System;
using System.Collections;
using System.IO;
using System.Data;
using System.Collections.Generic;
using BusinessModel;
using MachineLearning;
using Maths;
using Statistics;
using MonteCarlo;
using System.Diagnostics;

#endregion

namespace Trading {

    public class StatForecastCalc : IForecastCalc {

        #region Fields

        private StatFcst stFcst;
        private Predictability predNoSup;

        private Stock stock;
        private List<double> history;
        private List<double> forecast;
        private List<double> variance;

        private int testSetSize;
        private double predictabilityThres = 0.4;
        private int lastHistIndex = 0;
        private int lastFcstIndex = 0;

        private int firstHistIndex = 0;
        private DateTime firstHistDate;
        public int fcstHorizon = 7;
        private bool filterOutliers = true;
        private BusinessModel.TSeries ts;
        private RepIssueType repIssue = RepIssueType.Ok;

        #endregion

        #region Constructor

        public StatForecastCalc() {
            testSetSize = 20;
        }

        #endregion

        #region Properties

        public Stock Stock {
            get { return stock; }
            set { stock = value; }
        }

        public int TestSetSize {
            get { return testSetSize; }
            set { testSetSize = value; }
        }

        public List<double> History {
            get { return history; }
            set { history = value; }
        }

        public List<double> Forecast {
            get { return forecast; }
            set { forecast = value; }
        }

        public List<double> Variance {
            get { return variance; }
            set { variance = value; }
        }

        public DateTime GetFirstHistDate() {
            return firstHistDate;
        }

        #endregion

        #region Public Methods

        public void LoadData(Stock stock) {
            this.stock = stock;
            ts = new BusinessModel.TSeries();
            ts.Read("stockId", stock.Id);
            LoadData(ts);
        }

        public void LoadData(BusinessModel.TSeries ts) {
            if (stock == null) { this.stock = ts.Stock; }
            if (ts == null) {
                ts = new BusinessModel.TSeries();
                ts.Read("stockId", stock.Id);
            }
            this.ts = ts;
            history = ts.Open; //TODO: completar
            forecast = ts.Fcst;
            firstHistDate = ts.IniHist;
            if (history.Count == 0) { throw new Exception("No hay historia"); }
            this.lastHistIndex = history.Count - 1;
            fcstHorizon = 1;  //TODO opciones
            this.firstHistIndex = 0;
            this.lastFcstIndex = lastHistIndex + fcstHorizon;
            this.LoadModel();
        }

        public void Calculate() {
            double[] fcstArr = stFcst.GetFcstsMean(fcstHorizon);
            forecast = new List<double>(fcstArr);
            ts.Fcst = forecast;
        }

        public List<double> GetForecast() {
            return forecast;
        }

        public List<double> GetValidForecast(int t) {
            double[] fcstArr = stFcst.GetRetroFcstMean(t);
            List<double> fcst = new List<double>(fcstArr);
            return fcst;
        }

        public List<string> GetCalcReport() {
            List<string> repIssues = new List<string>();
            repIssues.Add(repIssue.ToString());
            return repIssues;
        }

        public void Save() {
            stock.SaveUpdate();
            ts.SaveUpdate();
        }

        #endregion

        #region Private Methods

        #region Load Model

        private void LoadModel() {
            LoadHistory();
            LoadForecast();
        }

        private void LoadHistory() {
            stFcst = new StatFcst(testSetSize);
            stFcst.BuildModel(history);
        }

        private void LoadForecast() {
            lastFcstIndex = this.lastHistIndex + fcstHorizon;
            int lastPN = lastHistIndex;
        }

        #endregion

        #region Get Results

        private void GetModelFcst() {
            try {
                int pNum = lastHistIndex + 1;
                forecast = new List<double>(fcstHorizon);
                for (int i = 0; i < fcstHorizon; i++) {
                    forecast.Add(Math.Round(stFcst.GetFcstMean(pNum + i)));
                    variance[i] = stFcst.GetFcstVar(pNum + i);
                }
                lastFcstIndex = lastHistIndex + fcstHorizon;
                this.ts.Fcst = forecast;

            }
            catch { throw new Exception("Error"); }
        }


        #endregion


        #endregion

        #region Public Enums

        public enum RepIssueType { Ok, Outliers, Chaotic, FiniteJump, Error, PoorFcst, NoIniData, AllOutliers, DfError, Unpredictable, AllDeviations, AnyErrors, NoHistory, NonCalculated, VeryFewPeriods };

        #endregion

    }
}
