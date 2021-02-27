#region Imports

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;

#endregion

namespace BusinessModel {

    public struct Currency {

        #region Fields

        private string _baseCode;
        private string _targetCode;
        private DateTime _tradeDate;
        private double _rate;
        private double _min;
        private double _max;

        #endregion

        #region Constructor

        public Currency(string baseCode, string targetCode) {
            if (String.IsNullOrEmpty(baseCode))
                throw new ArgumentNullException("baseCode");

            if (String.IsNullOrEmpty(targetCode))
                throw new ArgumentNullException("targetCode");

            _baseCode = baseCode;
            _targetCode = targetCode;
            _tradeDate = DateTime.Now;
            _rate = 0;
            _min = 0;
            _max = 0;
        }

        #endregion

        #region Properties

        public DateTime TradeDate {
            get { return _tradeDate; }
            set { _tradeDate = value; }
        }

        public double Rate {
            get { return _rate; }
            set { _rate = value; }
        }

        //Minimal Bid price
        public double Min {
            get { return _min; }
            set { _min = value; }
        }

        //Maximal Ask price
        public double Max {
            get { return _max; }
            set { _max = value; }
        }

        //Three-chars Currency code to convert from
        public string BaseCode {
            get { return _baseCode; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException(BaseCode);
                _baseCode = value.Trim().ToUpper(CultureInfo.InvariantCulture);
            }
        }

        //Three-chars Currency code to conver to
        public string TargetCode {
            get { return _targetCode; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException(TargetCode);
                _targetCode = value.Trim().ToUpper(CultureInfo.InvariantCulture);
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(Currency leftCurrencyData, Currency rightCurrencyData) {
            return ((leftCurrencyData.BaseCode.Equals(rightCurrencyData.BaseCode)) &&
                (leftCurrencyData.TargetCode.Equals(rightCurrencyData.TargetCode)));
        }

        public static bool operator !=(Currency leftCurrencyData, Currency rightCurrencyData) {
            return ((!leftCurrencyData.BaseCode.Equals(rightCurrencyData.BaseCode)) ||
                (!leftCurrencyData.TargetCode.Equals(rightCurrencyData.TargetCode)));
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj) {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            Currency tmp = (Currency)obj;
            if ((!tmp.BaseCode.Equals(this.BaseCode)) || (!tmp.TargetCode.Equals(this.TargetCode)))
                return false;

            return true;
        }

        public override int GetHashCode() {
            return (CurrencyList.GetCodeIndex(this.BaseCode) ^ CurrencyList.GetCodeIndex(this.TargetCode));
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "From: {0}; To: {1}; Price: {2}; Trade date: {3}; Min: {4}; Max: {5}",
                this.BaseCode, this.TargetCode, this.Rate, this.TradeDate, this.Min, this.Max);
        }

        #endregion

    }
}
