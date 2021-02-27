#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

#endregion

namespace Trading {
    
    public class ExcelReader: DBJob {

        #region Fields

        private string fileName;
        private string sheetName;
        private string connStr;

        #endregion

        #region Constructor

        public ExcelReader() { 
            fileName = @"..\..\..\Documents\ManualData.xls";
            sheetName = "Funds";
            //connStr = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties=Excel 12.0;";
            connStr = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + fileName + "';Extended Properties=Excel 8.0;";
            conn = new OleDbConnection(connStr);
        }

        #endregion

        #region Public Methods

        public object Read(string sheetName, int row, int col) {
            conn.Open();
            string query = "SELECT * FROM [" + sheetName + "$]";
            cmd = new OleDbCommand(query, (OleDbConnection)conn);
            adapter = new OleDbDataAdapter(query, (OleDbConnection)conn);
            set = new DataSet();
            adapter.Fill(set);
            //Console.WriteLine(set.Tables[0].Rows[1][2]); //Santander
            //Console.WriteLine(set.Tables[0].Rows[5][2]); //Dws
            conn.Close();
            return set.Tables[0].Rows[row][col];
        }

        public double ReadValue(string sheetName, int row, int col) {
            conn.Open();
            string query = "SELECT * FROM [" + sheetName + "$]";
            cmd = new OleDbCommand(query, (OleDbConnection)conn);
            adapter = new OleDbDataAdapter(query, (OleDbConnection)conn);
            set = new DataSet();
            adapter.Fill(set);
            conn.Close();
            string valStr = set.Tables[0].Rows[row][col].ToString().Replace('.', ',');
            return Convert.ToDouble(valStr);
        }

        public Dictionary<string, double> ReadManualData(string sheetName) {
            conn.Open();
            string query = "SELECT * FROM [" + sheetName + "$]";
            cmd = new OleDbCommand(query, (OleDbConnection)conn);
            adapter = new OleDbDataAdapter(query, (OleDbConnection)conn);
            set = new DataSet();
            adapter.Fill(set);
            conn.Close();
            Dictionary<string, double> manualData = new Dictionary<string, double>();
            int col = 2;
            string code, valStr;
            for (int row = 0; row < set.Tables[0].Rows.Count; row++) {
                code = set.Tables[0].Rows[row][0].ToString();
                if (code != "") {
                    valStr = set.Tables[0].Rows[row][col].ToString().Replace('.', ',');
                    manualData.Add(code, Convert.ToDouble(valStr));
                }
            }
            return manualData;
        }
 
        #endregion

    }
}
