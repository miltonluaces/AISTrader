#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Trading {

    public class TechLevel {

        #region Fields

        private LevelType type;
        private double level;
        private double lowLimit;
        private double highLimit;
        private double confidence;
        
        #endregion

        #region Constructor

        public TechLevel(LevelType type) {
            this.type = type;
        }

        #endregion

        #region Properties

        public LevelType Type {
            get { return type; }
            set { type = value;}
        }

        public double Level {
            get { return level; }
            set { level = value;}
        }

        public double LowLimit {
            get { return lowLimit; }
            set { lowLimit = value;}
        }

        public double HighLimit {
            get { return highLimit; }
            set { highLimit = value;}
        }

        public double Confidence {
            get { return confidence; }
            set { confidence = value; }
        }

        #endregion

        #region Public Methods

        public double GetLowPerc() {
            return Math.Round(((level - lowLimit) / level) * 100, 2);
        }

        public double GetHighPerc() {
            return Math.Round(((highLimit - level) / level) * 100, 2);
        }

        public double GetStopLoss(double sweep) {
            return level - sweep;
        }
        
        #endregion

        #region Enums

        public enum LevelType { booleanFcst, oneStepFcst, supportLevel, ressistanceLevel };
   
        #endregion
    }
}
