#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;

#endregion

namespace Trading {

    public interface IForecastCalc {
        void LoadData(Stock stock);
        void LoadData(TSeries ts);
        void Calculate();
        DateTime GetFirstHistDate();
        List<double> GetForecast();
        List<double> GetValidForecast(int t);
        List<string> GetCalcReport();
        void Save();
    }
}
