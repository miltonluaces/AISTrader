#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using Maths;
using Statistics;

#endregion

namespace Trading {

    public class ForecastCalculator {

        #region Fields

        private IForecastCalc nnFcstCalc;
        private IForecastCalc statFcstCalc;

        #endregion

        #region Constructor

        public ForecastCalculator() { 
            nnFcstCalc = new NNForecastCalc();
            statFcstCalc = new StatForecastCalc();
        }

        #endregion

        #region Public Methods

        #region Load Data

        public void LoadData(Stock stock) { 
            //checar si tiene las tseries cargadas, sino cargarlas
        }

        #endregion

        #region Technical Forecasts

        public TechLevel CalcOneStepFcst() {
            TechLevel oneStepFcst = new TechLevel(TechLevel.LevelType.oneStepFcst);
            return oneStepFcst;
        }

        public TechLevel CalcBooleanFcst() {
            TechLevel booleanFcst = new TechLevel(TechLevel.LevelType.booleanFcst);
            return booleanFcst;
        }
        
        #endregion

        #region Technical Levels

        public TechLevel CalcSupport() {
            TechLevel support = new TechLevel(TechLevel.LevelType.supportLevel);
            return support;
        }

        public TechLevel CalcRessistance() {
            TechLevel ressistance = new TechLevel(TechLevel.LevelType.ressistanceLevel);
            return ressistance;
        }

        #endregion
        
        #endregion
    }
}
