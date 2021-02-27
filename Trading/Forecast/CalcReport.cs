#region Import

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Trading {

    public class CalcReport : ICalcReport {

        #region Fields

        private string processName;
        private Dictionary<string, string> repIssues;

        #endregion

        #region Constructor

        public CalcReport(string processName) {
            this.processName = processName;
            repIssues = new Dictionary<string, string>();
        }

        #endregion

        #region ICalcReport Members

        public string GetProcessName() {
            return processName;
        }

        public void AddRepIssue(string issue) {
            repIssues.Add(issue, issue);
        }

        public void AddRepIssue(IssueType issueType) {
            AddRepIssue(issueType.ToString());
        }

        public List<string> GetReport() {
            List<string> ressList = repIssues.Keys.ToList<string>();
            return ressList;
        }

        #endregion

        #region Public enum

        public enum IssueType { Ok, Error };

        #endregion
    }
}
