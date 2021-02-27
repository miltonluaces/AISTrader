#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Trading {

    interface ICalcReport {
        string GetProcessName();
        void AddRepIssue(string res);
        List<string> GetReport();
    }
}
