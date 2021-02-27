namespace GUI {

    partial class HelpFrm {

        #region Fields

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer;

        #endregion

        #region Initialization

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpFrm));
            this.pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfViewer
            // 
            this.pdfViewer.Location = new System.Drawing.Point(12, 21);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(802, 524);
            this.pdfViewer.TabIndex = 1;
            // 
            // HelpFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(832, 556);
            this.Controls.Add(this.pdfViewer);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda en Linea";
            this.Load += new System.EventHandler(this.HelpFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        #region Events

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

    }
}