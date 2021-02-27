#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

#endregion

namespace BusinessModel {

    public class SysLog {

        private StreamWriter logFile;

        public SysLog() {
            string logFileStr = @"..\Documents\log.txt";
            logFile = new StreamWriter(logFileStr);
        }

        public void WriteLog(string txt) {
            DateTime date = DateTime.Now;
            logFile.WriteLine(date.ToShortDateString() + " " + date.ToShortTimeString() + ":\t " + txt);
        }

        public void CloseLog() {
            logFile.Close();
        }
    }
}
