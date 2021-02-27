namespace GUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            BusinessModel.Invest invest1 = new BusinessModel.Invest();
            BusinessModel.Stock stock1 = new BusinessModel.Stock();
            BusinessModel.Invest invest2 = new BusinessModel.Invest();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barClients = new DevExpress.XtraBars.BarListItem();
            this.barPortfolios = new DevExpress.XtraBars.BarListItem();
            this.barDatos = new DevExpress.XtraBars.BarButtonItem();
            this.barMonValues = new DevExpress.XtraBars.BarButtonItem();
            this.barMonData = new DevExpress.XtraBars.BarButtonItem();
            this.barOperate = new DevExpress.XtraBars.BarButtonItem();
            this.barLineChart = new DevExpress.XtraBars.BarButtonItem();
            this.barJapoChart = new DevExpress.XtraBars.BarButtonItem();
            this.barAddStock = new DevExpress.XtraBars.BarButtonItem();
            this.barParams = new DevExpress.XtraBars.BarButtonItem();
            this.barHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barQuit = new DevExpress.XtraBars.BarButtonItem();
            this.barPer1Month = new DevExpress.XtraBars.BarButtonItem();
            this.barPer3Months = new DevExpress.XtraBars.BarButtonItem();
            this.barPer6Months = new DevExpress.XtraBars.BarButtonItem();
            this.barPer1Year = new DevExpress.XtraBars.BarButtonItem();
            this.barPerAll = new DevExpress.XtraBars.BarButtonItem();
            this.barOpOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barMail = new DevExpress.XtraBars.BarButtonItem();
            this.barAbout = new DevExpress.XtraBars.BarButtonItem();
            this.barOpClose = new DevExpress.XtraBars.BarButtonItem();
            this.barCloseOp = new DevExpress.XtraBars.BarButtonItem();
            this.barUsd = new DevExpress.XtraBars.BarCheckItem();
            this.barEuro = new DevExpress.XtraBars.BarCheckItem();
            this.barMxn = new DevExpress.XtraBars.BarCheckItem();
            this.barOriginal = new DevExpress.XtraBars.BarCheckItem();
            this.ribInvestments = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgSelection = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgInvestment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgMonitor = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgCharts = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgPeriods = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgCurrency = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribRegisters = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgBitacor = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgUtils = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribAdmin = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pgAdm = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.portfolioCtrl = new GUI.PortfolioCtrl();
            this.stockChartCtrl = new GUI.IfsSeriesChartCtrl();
            this.stockMonitorCtrl = new GUI.StockMonitorCtrl();
            this.opOpenCtrl = new GUI.OperationsCtrl();
            this.opCloseCtrl = new GUI.OperationsCtrl();
            this.barRemoveStock = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barClients,
            this.barPortfolios,
            this.barDatos,
            this.barMonValues,
            this.barMonData,
            this.barOperate,
            this.barLineChart,
            this.barJapoChart,
            this.barAddStock,
            this.barParams,
            this.barHelp,
            this.barQuit,
            this.barPer1Month,
            this.barPer3Months,
            this.barPer6Months,
            this.barPer1Year,
            this.barPerAll,
            this.barOpOpen,
            this.barExcel,
            this.barMail,
            this.barAbout,
            this.barOpClose,
            this.barCloseOp,
            this.barUsd,
            this.barEuro,
            this.barMxn,
            this.barOriginal,
            this.barRemoveStock});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 37;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribInvestments,
            this.ribRegisters,
            this.ribAdmin});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1469, 144);
            // 
            // barClients
            // 
            this.barClients.Caption = "Clientes";
            this.barClients.Glyph = ((System.Drawing.Image)(resources.GetObject("barClients.Glyph")));
            this.barClients.Id = 5;
            this.barClients.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barClients.LargeGlyph")));
            this.barClients.Name = "barClients";
            this.barClients.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.barClients_ListItemClick);
            // 
            // barPortfolios
            // 
            this.barPortfolios.Caption = "Portafolios";
            this.barPortfolios.Glyph = ((System.Drawing.Image)(resources.GetObject("barPortfolios.Glyph")));
            this.barPortfolios.Id = 6;
            this.barPortfolios.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPortfolios.LargeGlyph")));
            this.barPortfolios.Name = "barPortfolios";
            this.barPortfolios.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.barPortfolios_ListItemClick);
            // 
            // barDatos
            // 
            this.barDatos.Caption = "Datos";
            this.barDatos.Glyph = ((System.Drawing.Image)(resources.GetObject("barDatos.Glyph")));
            this.barDatos.Id = 7;
            this.barDatos.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barDatos.LargeGlyph")));
            this.barDatos.Name = "barDatos";
            this.barDatos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barGrid_ItemClick);
            // 
            // barMonValues
            // 
            this.barMonValues.Caption = "Valores";
            this.barMonValues.Glyph = ((System.Drawing.Image)(resources.GetObject("barMonValues.Glyph")));
            this.barMonValues.Id = 9;
            this.barMonValues.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barMonValues.LargeGlyph")));
            this.barMonValues.Name = "barMonValues";
            this.barMonValues.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMonValues_ItemClick);
            // 
            // barMonData
            // 
            this.barMonData.Caption = "Información";
            this.barMonData.Glyph = ((System.Drawing.Image)(resources.GetObject("barMonData.Glyph")));
            this.barMonData.Id = 10;
            this.barMonData.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barMonData.LargeGlyph")));
            this.barMonData.Name = "barMonData";
            this.barMonData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMonData_ItemClick);
            // 
            // barOperate
            // 
            this.barOperate.Caption = "Operar";
            this.barOperate.Glyph = ((System.Drawing.Image)(resources.GetObject("barOperate.Glyph")));
            this.barOperate.Id = 11;
            this.barOperate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barOperate.LargeGlyph")));
            this.barOperate.Name = "barOperate";
            this.barOperate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barOperate_ItemClick);
            // 
            // barLineChart
            // 
            this.barLineChart.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barLineChart.Caption = "Lineas";
            this.barLineChart.Glyph = ((System.Drawing.Image)(resources.GetObject("barLineChart.Glyph")));
            this.barLineChart.Id = 12;
            this.barLineChart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barLineChart.LargeGlyph")));
            this.barLineChart.Name = "barLineChart";
            this.barLineChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLineChart_ItemClick);
            // 
            // barJapoChart
            // 
            this.barJapoChart.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barJapoChart.Caption = "Velas Japonesas";
            this.barJapoChart.Glyph = ((System.Drawing.Image)(resources.GetObject("barJapoChart.Glyph")));
            this.barJapoChart.Id = 13;
            this.barJapoChart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barJapoChart.LargeGlyph")));
            this.barJapoChart.Name = "barJapoChart";
            this.barJapoChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barJapoChart_ItemClick);
            // 
            // barAddStock
            // 
            this.barAddStock.Caption = "Agregar";
            this.barAddStock.Glyph = ((System.Drawing.Image)(resources.GetObject("barAddStock.Glyph")));
            this.barAddStock.Id = 14;
            this.barAddStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barAddStock.LargeGlyph")));
            this.barAddStock.Name = "barAddStock";
            this.barAddStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAddStock_ItemClick);
            // 
            // barParams
            // 
            this.barParams.Caption = "Parametros";
            this.barParams.Glyph = ((System.Drawing.Image)(resources.GetObject("barParams.Glyph")));
            this.barParams.Id = 15;
            this.barParams.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barParams.LargeGlyph")));
            this.barParams.Name = "barParams";
            this.barParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barParams_ItemClick);
            // 
            // barHelp
            // 
            this.barHelp.Caption = "Ayuda";
            this.barHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("barHelp.Glyph")));
            this.barHelp.Id = 16;
            this.barHelp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barHelp.LargeGlyph")));
            this.barHelp.Name = "barHelp";
            this.barHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHelp_ItemClick);
            // 
            // barQuit
            // 
            this.barQuit.Caption = "Salir";
            this.barQuit.Glyph = ((System.Drawing.Image)(resources.GetObject("barQuit.Glyph")));
            this.barQuit.Id = 17;
            this.barQuit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barQuit.LargeGlyph")));
            this.barQuit.Name = "barQuit";
            this.barQuit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barQuit_ItemClick);
            // 
            // barPer1Month
            // 
            this.barPer1Month.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barPer1Month.Caption = "1 mes";
            this.barPer1Month.Glyph = ((System.Drawing.Image)(resources.GetObject("barPer1Month.Glyph")));
            this.barPer1Month.Id = 18;
            this.barPer1Month.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPer1Month.LargeGlyph")));
            this.barPer1Month.Name = "barPer1Month";
            this.barPer1Month.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPer1Month_ItemClick);
            // 
            // barPer3Months
            // 
            this.barPer3Months.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barPer3Months.Caption = "3 meses";
            this.barPer3Months.Glyph = ((System.Drawing.Image)(resources.GetObject("barPer3Months.Glyph")));
            this.barPer3Months.Id = 19;
            this.barPer3Months.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPer3Months.LargeGlyph")));
            this.barPer3Months.Name = "barPer3Months";
            this.barPer3Months.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPer3Months_ItemClick);
            // 
            // barPer6Months
            // 
            this.barPer6Months.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barPer6Months.Caption = "6 meses";
            this.barPer6Months.Glyph = ((System.Drawing.Image)(resources.GetObject("barPer6Months.Glyph")));
            this.barPer6Months.Id = 20;
            this.barPer6Months.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPer6Months.LargeGlyph")));
            this.barPer6Months.Name = "barPer6Months";
            this.barPer6Months.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPer6Months_ItemClick);
            // 
            // barPer1Year
            // 
            this.barPer1Year.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barPer1Year.Caption = "1 año";
            this.barPer1Year.Glyph = ((System.Drawing.Image)(resources.GetObject("barPer1Year.Glyph")));
            this.barPer1Year.Id = 21;
            this.barPer1Year.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPer1Year.LargeGlyph")));
            this.barPer1Year.Name = "barPer1Year";
            this.barPer1Year.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPer1Year_ItemClick);
            // 
            // barPerAll
            // 
            this.barPerAll.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barPerAll.Caption = "3 años";
            this.barPerAll.Glyph = ((System.Drawing.Image)(resources.GetObject("barPerAll.Glyph")));
            this.barPerAll.Id = 22;
            this.barPerAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barPerAll.LargeGlyph")));
            this.barPerAll.Name = "barPerAll";
            this.barPerAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPerAll_ItemClick);
            // 
            // barOpOpen
            // 
            this.barOpOpen.Caption = "Operaciones Abiertas";
            this.barOpOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("barOpOpen.Glyph")));
            this.barOpOpen.Id = 23;
            this.barOpOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barOpOpen.LargeGlyph")));
            this.barOpOpen.Name = "barOpOpen";
            this.barOpOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barOpOpen_ItemClick);
            // 
            // barExcel
            // 
            this.barExcel.Caption = "Enviar a Excel";
            this.barExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("barExcel.Glyph")));
            this.barExcel.Id = 24;
            this.barExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barExcel.LargeGlyph")));
            this.barExcel.Name = "barExcel";
            this.barExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExcel_ItemClick);
            // 
            // barMail
            // 
            this.barMail.Caption = "Enviar Mail";
            this.barMail.Glyph = ((System.Drawing.Image)(resources.GetObject("barMail.Glyph")));
            this.barMail.Id = 25;
            this.barMail.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barMail.LargeGlyph")));
            this.barMail.Name = "barMail";
            this.barMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMail_ItemClick);
            // 
            // barAbout
            // 
            this.barAbout.Caption = "Acerca de...";
            this.barAbout.Glyph = ((System.Drawing.Image)(resources.GetObject("barAbout.Glyph")));
            this.barAbout.Id = 26;
            this.barAbout.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barAbout.LargeGlyph")));
            this.barAbout.Name = "barAbout";
            this.barAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAbout_ItemClick);
            // 
            // barOpClose
            // 
            this.barOpClose.Caption = "Operaciones Cerradas";
            this.barOpClose.Glyph = ((System.Drawing.Image)(resources.GetObject("barOpClose.Glyph")));
            this.barOpClose.Id = 27;
            this.barOpClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barOpClose.LargeGlyph")));
            this.barOpClose.Name = "barOpClose";
            this.barOpClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barOpClose_ItemClick);
            // 
            // barCloseOp
            // 
            this.barCloseOp.Caption = "Cerrar Operaciones";
            this.barCloseOp.Glyph = ((System.Drawing.Image)(resources.GetObject("barCloseOp.Glyph")));
            this.barCloseOp.Id = 28;
            this.barCloseOp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barCloseOp.LargeGlyph")));
            this.barCloseOp.Name = "barCloseOp";
            this.barCloseOp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseOp_ItemClick);
            // 
            // barUsd
            // 
            this.barUsd.Caption = "USD";
            this.barUsd.Glyph = ((System.Drawing.Image)(resources.GetObject("barUsd.Glyph")));
            this.barUsd.Id = 30;
            this.barUsd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barUsd.LargeGlyph")));
            this.barUsd.Name = "barUsd";
            this.barUsd.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barUsd_CheckedChanged);
            // 
            // barEuro
            // 
            this.barEuro.Caption = "Euro";
            this.barEuro.Glyph = ((System.Drawing.Image)(resources.GetObject("barEuro.Glyph")));
            this.barEuro.Id = 31;
            this.barEuro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barEuro.LargeGlyph")));
            this.barEuro.Name = "barEuro";
            this.barEuro.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barEuro_CheckedChanged);
            // 
            // barMxn
            // 
            this.barMxn.Caption = "MXN";
            this.barMxn.Glyph = ((System.Drawing.Image)(resources.GetObject("barMxn.Glyph")));
            this.barMxn.Id = 33;
            this.barMxn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barMxn.LargeGlyph")));
            this.barMxn.Name = "barMxn";
            this.barMxn.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barMxn_CheckedChanged);
            // 
            // barOriginal
            // 
            this.barOriginal.Caption = "Original";
            this.barOriginal.Glyph = ((System.Drawing.Image)(resources.GetObject("barOriginal.Glyph")));
            this.barOriginal.Id = 35;
            this.barOriginal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barOriginal.LargeGlyph")));
            this.barOriginal.Name = "barOriginal";
            this.barOriginal.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barOriginal_CheckedChanged);
            // 
            // ribInvestments
            // 
            this.ribInvestments.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pgSelection,
            this.pgInvestment,
            this.pgMonitor,
            this.pgCharts,
            this.pgPeriods,
            this.pgCurrency});
            this.ribInvestments.Name = "ribInvestments";
            this.ribInvestments.Text = "Inversiones";
            // 
            // pgSelection
            // 
            this.pgSelection.ItemLinks.Add(this.barClients);
            this.pgSelection.ItemLinks.Add(this.barPortfolios);
            this.pgSelection.Name = "pgSelection";
            this.pgSelection.Text = "Selección";
            // 
            // pgInvestment
            // 
            this.pgInvestment.ItemLinks.Add(this.barDatos);
            this.pgInvestment.ItemLinks.Add(this.barOperate);
            this.pgInvestment.Name = "pgInvestment";
            this.pgInvestment.Text = "Cartera";
            // 
            // pgMonitor
            // 
            this.pgMonitor.ItemLinks.Add(this.barMonValues);
            this.pgMonitor.ItemLinks.Add(this.barMonData);
            this.pgMonitor.ItemLinks.Add(this.barAddStock);
            this.pgMonitor.ItemLinks.Add(this.barRemoveStock);
            this.pgMonitor.Name = "pgMonitor";
            this.pgMonitor.Text = "Monitoreo";
            // 
            // pgCharts
            // 
            this.pgCharts.ItemLinks.Add(this.barLineChart);
            this.pgCharts.ItemLinks.Add(this.barJapoChart);
            this.pgCharts.Name = "pgCharts";
            this.pgCharts.Text = "Tipo de Gráfico";
            // 
            // pgPeriods
            // 
            this.pgPeriods.ItemLinks.Add(this.barPer1Month);
            this.pgPeriods.ItemLinks.Add(this.barPer3Months);
            this.pgPeriods.ItemLinks.Add(this.barPer6Months);
            this.pgPeriods.ItemLinks.Add(this.barPer1Year);
            this.pgPeriods.ItemLinks.Add(this.barPerAll);
            this.pgPeriods.Name = "pgPeriods";
            this.pgPeriods.Text = "Periodo a mostrar";
            // 
            // pgCurrency
            // 
            this.pgCurrency.ItemLinks.Add(this.barOriginal);
            this.pgCurrency.ItemLinks.Add(this.barUsd);
            this.pgCurrency.ItemLinks.Add(this.barEuro);
            this.pgCurrency.ItemLinks.Add(this.barMxn);
            this.pgCurrency.Name = "pgCurrency";
            this.pgCurrency.Text = "Moneda";
            // 
            // ribRegisters
            // 
            this.ribRegisters.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pgBitacor,
            this.pgUtils});
            this.ribRegisters.Name = "ribRegisters";
            this.ribRegisters.Text = "Registros";
            // 
            // pgBitacor
            // 
            this.pgBitacor.ItemLinks.Add(this.barOpOpen);
            this.pgBitacor.ItemLinks.Add(this.barOpClose);
            this.pgBitacor.ItemLinks.Add(this.barCloseOp);
            this.pgBitacor.Name = "pgBitacor";
            this.pgBitacor.Text = "Bitácora";
            // 
            // pgUtils
            // 
            this.pgUtils.ItemLinks.Add(this.barExcel);
            this.pgUtils.ItemLinks.Add(this.barMail);
            this.pgUtils.Name = "pgUtils";
            this.pgUtils.Text = "   Utilidades        ";
            // 
            // ribAdmin
            // 
            this.ribAdmin.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pgAdm});
            this.ribAdmin.Name = "ribAdmin";
            this.ribAdmin.Text = "Administración";
            // 
            // pgAdm
            // 
            this.pgAdm.ItemLinks.Add(this.barParams);
            this.pgAdm.ItemLinks.Add(this.barHelp);
            this.pgAdm.ItemLinks.Add(this.barAbout);
            this.pgAdm.ItemLinks.Add(this.barQuit);
            this.pgAdm.Name = "pgAdm";
            this.pgAdm.Text = "Administracion";
            // 
            // portfolioCtrl
            // 
            invest1.Code = null;
            invest1.Creation = new System.DateTime(2013, 11, 26, 9, 5, 28, 445);
            invest1.CurrAmount = 0D;
            invest1.Date = new System.DateTime(((long)(0)));
            invest1.Id = ((ulong)(0ul));
            invest1.LossAmount = 0D;
            invest1.Portfolio = null;
            invest1.ProfitAmount = 0D;
            invest1.PropAmount = 0D;
            invest1.PropProfit = 0D;
            invest1.PurchAmount = 0D;
            invest1.PurchValue = 0D;
            invest1.Qty = 0D;
            stock1.Code = null;
            stock1.Creation = new System.DateTime(2013, 11, 21, 13, 23, 49, 193);
            stock1.Currency = BusinessModel.Stock.CurrencyType.USD;
            stock1.Date = new System.DateTime(((long)(0)));
            stock1.Ebitda = 0D;
            stock1.Id = ((ulong)(0ul));
            stock1.Market = BusinessModel.Stock.MarketType.NYSE;
            stock1.Name = null;
            stock1.Per = 0D;
            stock1.Source = null;
            stock1.TSeries = null;
            stock1.Type = BusinessModel.Stock.TypeType.Stock;
            stock1.Value = 0D;
            stock1.Volume = ((ulong)(0ul));
            invest1.Stock = stock1;
            invest1.StopLoss = 0D;
            invest1.TakeProfit = 0D;
            this.portfolioCtrl.CurrInvest = invest1;
            this.portfolioCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portfolioCtrl.Location = new System.Drawing.Point(0, 144);
            this.portfolioCtrl.Name = "portfolioCtrl";
            this.portfolioCtrl.Size = new System.Drawing.Size(1469, 736);
            this.portfolioCtrl.TabIndex = 2;
            this.portfolioCtrl.Visible = false;
            // 
            // stockChartCtrl
            // 
            this.stockChartCtrl.ChartType = GUI.IfsSeriesChartCtrl.ChartTypeType.xyLines;
            this.stockChartCtrl.Fcst = false;
            this.stockChartCtrl.Hist = false;
            this.stockChartCtrl.Location = new System.Drawing.Point(12, 151);
            this.stockChartCtrl.Name = "stockChartCtrl";
            this.stockChartCtrl.Size = new System.Drawing.Size(1339, 725);
            this.stockChartCtrl.TabIndex = 5;
            // 
            // stockMonitorCtrl
            // 
            invest2.Code = null;
            invest2.Creation = new System.DateTime(2013, 11, 26, 18, 26, 41, 359);
            invest2.CurrAmount = -1D;
            invest2.Date = new System.DateTime(((long)(0)));
            invest2.Id = ((ulong)(0ul));
            invest2.LossAmount = -1D;
            invest2.Portfolio = null;
            invest2.ProfitAmount = -1D;
            invest2.PropAmount = 0D;
            invest2.PropProfit = 0D;
            invest2.PurchAmount = -1D;
            invest2.PurchValue = -1D;
            invest2.Qty = 0D;
            invest2.Stock = null;
            invest2.StopLoss = -1D;
            invest2.TakeProfit = -1D;
            this.stockMonitorCtrl.CurrInvest = invest2;
            this.stockMonitorCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockMonitorCtrl.Location = new System.Drawing.Point(0, 144);
            this.stockMonitorCtrl.Name = "stockMonitorCtrl";
            this.stockMonitorCtrl.Size = new System.Drawing.Size(1469, 736);
            this.stockMonitorCtrl.TabIndex = 8;
            // 
            // opOpenCtrl
            // 
            this.opOpenCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opOpenCtrl.Location = new System.Drawing.Point(0, 144);
            this.opOpenCtrl.Name = "opOpenCtrl";
            this.opOpenCtrl.Size = new System.Drawing.Size(1469, 736);
            this.opOpenCtrl.TabIndex = 11;
            // 
            // opCloseCtrl
            // 
            this.opCloseCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opCloseCtrl.Location = new System.Drawing.Point(0, 144);
            this.opCloseCtrl.Name = "opCloseCtrl";
            this.opCloseCtrl.Size = new System.Drawing.Size(1469, 736);
            this.opCloseCtrl.TabIndex = 14;
            // 
            // barRemoveStock
            // 
            this.barRemoveStock.Caption = "Eliminar";
            this.barRemoveStock.Glyph = ((System.Drawing.Image)(resources.GetObject("barRemoveStock.Glyph")));
            this.barRemoveStock.Id = 36;
            this.barRemoveStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barRemoveStock.LargeGlyph")));
            this.barRemoveStock.Name = "barRemoveStock";
            this.barRemoveStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barRemoveStock_ItemClick);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 880);
            this.Controls.Add(this.opCloseCtrl);
            this.Controls.Add(this.opOpenCtrl);
            this.Controls.Add(this.stockMonitorCtrl);
            this.Controls.Add(this.stockChartCtrl);
            this.Controls.Add(this.portfolioCtrl);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Trading System.  Sistema de Gestión automatizada de Inversiones";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribInvestments;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgSelection;
        private DevExpress.XtraBars.BarListItem barClients;
        private DevExpress.XtraBars.BarListItem barPortfolios;
        private DevExpress.XtraBars.BarButtonItem barDatos;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgInvestment;
        private PortfolioCtrl portfolioCtrl;
        private IfsSeriesChartCtrl stockChartCtrl;
        private DevExpress.XtraBars.BarButtonItem barMonValues;
        private DevExpress.XtraBars.BarButtonItem barMonData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgMonitor;
        private DevExpress.XtraBars.BarButtonItem barOperate;
        private DevExpress.XtraBars.BarButtonItem barLineChart;
        private DevExpress.XtraBars.BarButtonItem barJapoChart;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgCharts;
        private DevExpress.XtraBars.BarButtonItem barAddStock;
        private StockMonitorCtrl stockMonitorCtrl;
        private DevExpress.XtraBars.BarButtonItem barParams;
        private DevExpress.XtraBars.BarButtonItem barHelp;
        private DevExpress.XtraBars.BarButtonItem barQuit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgAdm;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgPeriods;
        private DevExpress.XtraBars.BarButtonItem barPer1Month;
        private DevExpress.XtraBars.BarButtonItem barPer3Months;
        private DevExpress.XtraBars.BarButtonItem barPer6Months;
        private DevExpress.XtraBars.BarButtonItem barPer1Year;
        private DevExpress.XtraBars.BarButtonItem barPerAll;
        private DevExpress.XtraBars.BarButtonItem barOpOpen;
        private OperationsCtrl opOpenCtrl;
        private DevExpress.XtraBars.BarButtonItem barExcel;
        private DevExpress.XtraBars.BarButtonItem barMail;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgUtils;
        private DevExpress.XtraBars.BarButtonItem barAbout;
        private DevExpress.XtraBars.BarButtonItem barOpClose;
        private OperationsCtrl opCloseCtrl;
        private DevExpress.XtraBars.BarButtonItem barCloseOp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgBitacor;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribRegisters;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribAdmin;
        private DevExpress.XtraBars.BarCheckItem barUsd;
        private DevExpress.XtraBars.BarCheckItem barEuro;
        private DevExpress.XtraBars.BarCheckItem barMxn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pgCurrency;
        private DevExpress.XtraBars.BarCheckItem barOriginal;
        private DevExpress.XtraBars.BarButtonItem barRemoveStock;
    }
}

