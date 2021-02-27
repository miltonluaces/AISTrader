#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace GUI {

    public partial class HelpFrm : Form {

        #region Constructor

        public HelpFrm() {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void HelpFrm_Load(object sender, EventArgs e) {
            pdfViewer.LoadDocument(@"..\..\..\Documents\Manual.pdf");
        }

        #endregion
    }
}
