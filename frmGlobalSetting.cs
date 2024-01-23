using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;
using POSsible.Reports;

namespace POSsible
{
    /// <summary>
    /// Summary description for FrmGlobalSetting.
    /// </summary>
    public class frmGlobalSetting : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ToolBarButton tbtnDbSetting;
        private System.Windows.Forms.ToolBarButton tbtnItemEntry;
        private System.Windows.Forms.ToolBarButton tbtnPerchasEntry;
        private System.Windows.Forms.ToolBar tbarAdmin;
        private System.Windows.Forms.ToolBarButton tbtnExit;
        private ToolBarButton tbrDamage;
        private ToolBarButton tbtnPurchesEntry;
        private ImageList imageList1;
        private IContainer components;
        public CUser oUserLogin = new CUser();
        public DateTime dtLogin = DateTime.Now;
        private ToolBarButton tbtnSupplierEntry;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem ticketPrintToolStripMenuItem;
        private ToolStripMenuItem reorderListToolStripMenuItem;
        private ToolStripMenuItem profitReportToolStripMenuItem;
        private ToolBarButton tbtnUser;
        private ToolBarButton tbtnCustomerEntry;
        private ToolStripMenuItem salesReportToolStripMenuItem;
        private ToolStripMenuItem mnuSatup;
        private ToolStripMenuItem mnuSetupDepartment;
        private ToolStripMenuItem mnuSetupMeasurement;
        private ToolStripMenuItem mnuSetupCustomer;
        private ToolStripMenuItem mnuSetupSupplier;
        private ToolStripMenuItem mnuMainEntryForm;
        private ToolStripMenuItem mnuMainEntryFormPurches;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem mnuDBSetting;
        private ToolStripMenuItem mnuDBSettingDBSetting;
        private ToolStripMenuItem mnuDBSettingUpdateUserLoginInfo;
        private ToolStripMenuItem aboutUsToolStripMenuItem;
        private ToolStripMenuItem mnuReportStockReport;
        private ToolStripMenuItem mnuReporttotalDaySales;
        private ToolStripMenuItem ManuSetupCompanyInformation;
        private ToolStripMenuItem mnuSetupcustomerPointClaim;
        private ToolStripMenuItem purchaseReportToolStripMenuItem;
        private ToolStripMenuItem inventoryMovementToolStripMenuItem;
        private ToolStripMenuItem creditCollectionToolStripMenuItem;
        private ToolStripMenuItem productPromotionToolStripMenuItem;
        private ToolStripMenuItem reportExplorerToolStripMenuItem;
        private frmLogin m_loginfrmRef;
        private ToolStripMenuItem purchasePaymentToolStripMenuItem;
        private ToolStripMenuItem mnuMainEntryFormItem;
        private ToolStripMenuItem rolewisePermissionToolStripMenuItem;
        private ToolStripMenuItem mnuSettingUserEntry;
        private ToolStripMenuItem storeEntryToolStripMenuItem;
        private ToolStripMenuItem openingQuantityEntryToolStripMenuItem;
        private ToolStripMenuItem refundToolStripMenuItem;
        private ToolStripMenuItem bankEntryToolStripMenuItem;
        private ToolStripMenuItem salesRefundToolStripMenuItem;
        private ToolStripMenuItem expenseTypeEntryToolStripMenuItem;
        private ToolStripMenuItem expenseEntryToolStripMenuItem;
        private ToolStripMenuItem employeeEntryToolStripMenuItem;
        public frmOffice frmOffice = new frmOffice();

        public frmGlobalSetting()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public frmGlobalSetting(frmOffice frmOfficeCon)
        {
            this.frmOffice = frmOfficeCon;
            InitializeComponent();
            frmOffice.Hide();
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGlobalSetting));
            this.tbarAdmin = new System.Windows.Forms.ToolBar();
            this.tbtnDbSetting = new System.Windows.Forms.ToolBarButton();
            this.tbtnItemEntry = new System.Windows.Forms.ToolBarButton();
            this.tbtnPurchesEntry = new System.Windows.Forms.ToolBarButton();
            this.tbrDamage = new System.Windows.Forms.ToolBarButton();
            this.tbtnSupplierEntry = new System.Windows.Forms.ToolBarButton();
            this.tbtnUser = new System.Windows.Forms.ToolBarButton();
            this.tbtnCustomerEntry = new System.Windows.Forms.ToolBarButton();
            this.tbtnExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuMainEntryForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainEntryFormPurches = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasePaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesRefundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSatup = new System.Windows.Forms.ToolStripMenuItem();
            this.ManuSetupCompanyInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.storeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetupCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetupcustomerPointClaim = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetupSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.bankEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetupMeasurement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetupDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainEntryFormItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingQuantityEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productPromotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseTypeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reorderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportStockReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReporttotalDaySales = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryMovementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingUserEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.rolewisePermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBSettingDBSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBSettingUpdateUserLoginInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbarAdmin
            // 
            this.tbarAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbarAdmin.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbtnDbSetting,
            this.tbtnItemEntry,
            this.tbtnPurchesEntry,
            this.tbrDamage,
            this.tbtnSupplierEntry,
            this.tbtnUser,
            this.tbtnCustomerEntry,
            this.tbtnExit});
            this.tbarAdmin.ButtonSize = new System.Drawing.Size(70, 48);
            this.tbarAdmin.DropDownArrows = true;
            this.tbarAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbarAdmin.ImageList = this.imageList1;
            this.tbarAdmin.Location = new System.Drawing.Point(0, 24);
            this.tbarAdmin.Name = "tbarAdmin";
            this.tbarAdmin.ShowToolTips = true;
            this.tbarAdmin.Size = new System.Drawing.Size(992, 61);
            this.tbarAdmin.TabIndex = 0;
            this.tbarAdmin.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbarAdmin_ButtonClick);
            // 
            // tbtnDbSetting
            // 
            this.tbtnDbSetting.ImageKey = "settings.png";
            this.tbtnDbSetting.Name = "tbtnDbSetting";
            this.tbtnDbSetting.ToolTipText = "DataBase settings for RITPOS";
            this.tbtnDbSetting.Visible = false;
            // 
            // tbtnItemEntry
            // 
            this.tbtnItemEntry.ImageKey = "item_entry.png";
            this.tbtnItemEntry.Name = "tbtnItemEntry";
            this.tbtnItemEntry.Tag = "8";
            this.tbtnItemEntry.ToolTipText = "Item Entry";
            // 
            // tbtnPurchesEntry
            // 
            this.tbtnPurchesEntry.ImageKey = "purchase.png";
            this.tbtnPurchesEntry.Name = "tbtnPurchesEntry";
            this.tbtnPurchesEntry.Tag = "3";
            this.tbtnPurchesEntry.ToolTipText = "Purchase Product";
            // 
            // tbrDamage
            // 
            this.tbrDamage.ImageKey = "damage.png";
            this.tbrDamage.Name = "tbrDamage";
            this.tbrDamage.ToolTipText = "Manage Damage Item";
            this.tbrDamage.Visible = false;
            // 
            // tbtnSupplierEntry
            // 
            this.tbtnSupplierEntry.ImageKey = "supplier.png";
            this.tbtnSupplierEntry.Name = "tbtnSupplierEntry";
            this.tbtnSupplierEntry.Tag = "13";
            this.tbtnSupplierEntry.ToolTipText = "Supplier Entry";
            // 
            // tbtnUser
            // 
            this.tbtnUser.ImageKey = "user.png";
            this.tbtnUser.Name = "tbtnUser";
            this.tbtnUser.ToolTipText = "User Login Status Change";
            this.tbtnUser.Visible = false;
            // 
            // tbtnCustomerEntry
            // 
            this.tbtnCustomerEntry.ImageKey = "customer.png";
            this.tbtnCustomerEntry.Name = "tbtnCustomerEntry";
            this.tbtnCustomerEntry.Tag = "12";
            this.tbtnCustomerEntry.ToolTipText = "Customer Entry";
            // 
            // tbtnExit
            // 
            this.tbtnExit.ImageKey = "exit_-130w-x-144h.png";
            this.tbtnExit.Name = "tbtnExit";
            this.tbtnExit.ToolTipText = "Exit";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "settings.png");
            this.imageList1.Images.SetKeyName(1, "item_entry.png");
            this.imageList1.Images.SetKeyName(2, "purchase.png");
            this.imageList1.Images.SetKeyName(3, "damage.png");
            this.imageList1.Images.SetKeyName(4, "supplier.png");
            this.imageList1.Images.SetKeyName(5, "user.png");
            this.imageList1.Images.SetKeyName(6, "customer.png");
            this.imageList1.Images.SetKeyName(7, "exit_-130w-x-144h.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainEntryForm,
            this.mnuSatup,
            this.reportsToolStripMenuItem,
            this.mnuDBSetting,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuMainEntryForm
            // 
            this.mnuMainEntryForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainEntryFormPurches,
            this.purchasePaymentToolStripMenuItem,
            this.creditCollectionToolStripMenuItem,
            this.salesRefundToolStripMenuItem,
            this.expenseEntryToolStripMenuItem});
            this.mnuMainEntryForm.Name = "mnuMainEntryForm";
            this.mnuMainEntryForm.Size = new System.Drawing.Size(107, 20);
            this.mnuMainEntryForm.Tag = "2";
            this.mnuMainEntryForm.Text = "&Main Entry Form";
            // 
            // mnuMainEntryFormPurches
            // 
            this.mnuMainEntryFormPurches.Name = "mnuMainEntryFormPurches";
            this.mnuMainEntryFormPurches.Size = new System.Drawing.Size(210, 22);
            this.mnuMainEntryFormPurches.Tag = "3";
            this.mnuMainEntryFormPurches.Text = "&Purchase Product";
            this.mnuMainEntryFormPurches.Click += new System.EventHandler(this.mnuMainEntryFormPurches_Click);
            // 
            // purchasePaymentToolStripMenuItem
            // 
            this.purchasePaymentToolStripMenuItem.Name = "purchasePaymentToolStripMenuItem";
            this.purchasePaymentToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.purchasePaymentToolStripMenuItem.Tag = "5";
            this.purchasePaymentToolStripMenuItem.Text = "Purchase Payment";
            this.purchasePaymentToolStripMenuItem.Click += new System.EventHandler(this.purchasePaymentToolStripMenuItem_Click_1);
            // 
            // creditCollectionToolStripMenuItem
            // 
            this.creditCollectionToolStripMenuItem.Name = "creditCollectionToolStripMenuItem";
            this.creditCollectionToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.creditCollectionToolStripMenuItem.Tag = "6";
            this.creditCollectionToolStripMenuItem.Text = "Credit Collection";
            this.creditCollectionToolStripMenuItem.Click += new System.EventHandler(this.creditCollectionToolStripMenuItem_Click);
            // 
            // salesRefundToolStripMenuItem
            // 
            this.salesRefundToolStripMenuItem.Name = "salesRefundToolStripMenuItem";
            this.salesRefundToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.salesRefundToolStripMenuItem.Tag = "1025";
            this.salesRefundToolStripMenuItem.Text = "Sales Refund";
            this.salesRefundToolStripMenuItem.Click += new System.EventHandler(this.salesRefundToolStripMenuItem_Click);
            // 
            // expenseEntryToolStripMenuItem
            // 
            this.expenseEntryToolStripMenuItem.Name = "expenseEntryToolStripMenuItem";
            this.expenseEntryToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.expenseEntryToolStripMenuItem.Tag = "1031";
            this.expenseEntryToolStripMenuItem.Text = "Expense Transaction Entry";
            this.expenseEntryToolStripMenuItem.Click += new System.EventHandler(this.expenseEntryToolStripMenuItem_Click);
            // 
            // mnuSatup
            // 
            this.mnuSatup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManuSetupCompanyInformation,
            this.storeEntryToolStripMenuItem,
            this.mnuSetupCustomer,
            this.mnuSetupcustomerPointClaim,
            this.mnuSetupSupplier,
            this.bankEntryToolStripMenuItem,
            this.mnuSetupMeasurement,
            this.mnuSetupDepartment,
            this.mnuMainEntryFormItem,
            this.openingQuantityEntryToolStripMenuItem,
            this.productPromotionToolStripMenuItem,
            this.refundToolStripMenuItem,
            this.expenseTypeEntryToolStripMenuItem,
            this.employeeEntryToolStripMenuItem});
            this.mnuSatup.Name = "mnuSatup";
            this.mnuSatup.Size = new System.Drawing.Size(73, 20);
            this.mnuSatup.Tag = "7";
            this.mnuSatup.Text = "&Setup Info";
            // 
            // ManuSetupCompanyInformation
            // 
            this.ManuSetupCompanyInformation.Name = "ManuSetupCompanyInformation";
            this.ManuSetupCompanyInformation.Size = new System.Drawing.Size(199, 22);
            this.ManuSetupCompanyInformation.Tag = "9";
            this.ManuSetupCompanyInformation.Text = "Company Information";
            this.ManuSetupCompanyInformation.Click += new System.EventHandler(this.ManuSetupCompanyInformation_Click);
            // 
            // storeEntryToolStripMenuItem
            // 
            this.storeEntryToolStripMenuItem.Name = "storeEntryToolStripMenuItem";
            this.storeEntryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.storeEntryToolStripMenuItem.Tag = "23";
            this.storeEntryToolStripMenuItem.Text = "Store Entry";
            this.storeEntryToolStripMenuItem.Click += new System.EventHandler(this.storeEntryToolStripMenuItem_Click);
            // 
            // mnuSetupCustomer
            // 
            this.mnuSetupCustomer.Name = "mnuSetupCustomer";
            this.mnuSetupCustomer.Size = new System.Drawing.Size(199, 22);
            this.mnuSetupCustomer.Tag = "12";
            this.mnuSetupCustomer.Text = "&Customer Entry";
            this.mnuSetupCustomer.Click += new System.EventHandler(this.mnuSetupCustomer_Click);
            // 
            // mnuSetupcustomerPointClaim
            // 
            this.mnuSetupcustomerPointClaim.Name = "mnuSetupcustomerPointClaim";
            this.mnuSetupcustomerPointClaim.Size = new System.Drawing.Size(199, 22);
            this.mnuSetupcustomerPointClaim.Text = "Customer Point Claim";
            this.mnuSetupcustomerPointClaim.Visible = false;
            this.mnuSetupcustomerPointClaim.Click += new System.EventHandler(this.mnuSetupcustomerPointClaim_Click);
            // 
            // mnuSetupSupplier
            // 
            this.mnuSetupSupplier.Name = "mnuSetupSupplier";
            this.mnuSetupSupplier.Size = new System.Drawing.Size(199, 22);
            this.mnuSetupSupplier.Tag = "13";
            this.mnuSetupSupplier.Text = "&Supplier Entry";
            this.mnuSetupSupplier.Click += new System.EventHandler(this.mnuSetupSupplier_Click);
            // 
            // bankEntryToolStripMenuItem
            // 
            this.bankEntryToolStripMenuItem.Name = "bankEntryToolStripMenuItem";
            this.bankEntryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bankEntryToolStripMenuItem.Tag = "1026";
            this.bankEntryToolStripMenuItem.Text = "Bank Entry";
            this.bankEntryToolStripMenuItem.Click += new System.EventHandler(this.bankEntryToolStripMenuItem_Click);
            // 
            // mnuSetupMeasurement
            // 
            this.mnuSetupMeasurement.Name = "mnuSetupMeasurement";
            this.mnuSetupMeasurement.Size = new System.Drawing.Size(199, 22);
            this.mnuSetupMeasurement.Tag = "11";
            this.mnuSetupMeasurement.Text = "&Unit of Measurement";
            this.mnuSetupMeasurement.Click += new System.EventHandler(this.mnuSetupMeasurement_Click);
            // 
            // mnuSetupDepartment
            // 
            this.mnuSetupDepartment.Name = "mnuSetupDepartment";
            this.mnuSetupDepartment.Size = new System.Drawing.Size(199, 22);
            this.mnuSetupDepartment.Tag = "10";
            this.mnuSetupDepartment.Text = "&Product Category";
            this.mnuSetupDepartment.Click += new System.EventHandler(this.mnuSetupDepartment_Click);
            // 
            // mnuMainEntryFormItem
            // 
            this.mnuMainEntryFormItem.Name = "mnuMainEntryFormItem";
            this.mnuMainEntryFormItem.Size = new System.Drawing.Size(199, 22);
            this.mnuMainEntryFormItem.Tag = "8";
            this.mnuMainEntryFormItem.Text = "Product Entry";
            this.mnuMainEntryFormItem.Click += new System.EventHandler(this.mnuMainEntryFormItem_Click_1);
            // 
            // openingQuantityEntryToolStripMenuItem
            // 
            this.openingQuantityEntryToolStripMenuItem.Name = "openingQuantityEntryToolStripMenuItem";
            this.openingQuantityEntryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openingQuantityEntryToolStripMenuItem.Tag = "24";
            this.openingQuantityEntryToolStripMenuItem.Text = "Opening Quantity Entry";
            this.openingQuantityEntryToolStripMenuItem.Click += new System.EventHandler(this.openingQuantityEntryToolStripMenuItem_Click);
            // 
            // productPromotionToolStripMenuItem
            // 
            this.productPromotionToolStripMenuItem.Name = "productPromotionToolStripMenuItem";
            this.productPromotionToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.productPromotionToolStripMenuItem.Tag = "14";
            this.productPromotionToolStripMenuItem.Text = "Product Promotion";
            this.productPromotionToolStripMenuItem.Click += new System.EventHandler(this.productPromotionToolStripMenuItem_Click);
            // 
            // refundToolStripMenuItem
            // 
            this.refundToolStripMenuItem.Name = "refundToolStripMenuItem";
            this.refundToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.refundToolStripMenuItem.Tag = "1025";
            this.refundToolStripMenuItem.Text = "Refund";
            this.refundToolStripMenuItem.Visible = false;
            // 
            // expenseTypeEntryToolStripMenuItem
            // 
            this.expenseTypeEntryToolStripMenuItem.Name = "expenseTypeEntryToolStripMenuItem";
            this.expenseTypeEntryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.expenseTypeEntryToolStripMenuItem.Tag = "1030";
            this.expenseTypeEntryToolStripMenuItem.Text = "Expense Purpose Entry";
            this.expenseTypeEntryToolStripMenuItem.Click += new System.EventHandler(this.expenseTypeEntryToolStripMenuItem_Click);
            // 
            // employeeEntryToolStripMenuItem
            // 
            this.employeeEntryToolStripMenuItem.Name = "employeeEntryToolStripMenuItem";
            this.employeeEntryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.employeeEntryToolStripMenuItem.Tag = "1032";
            this.employeeEntryToolStripMenuItem.Text = "Employee Entry";
            this.employeeEntryToolStripMenuItem.Click += new System.EventHandler(this.employeeEntryToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ticketPrintToolStripMenuItem,
            this.reorderListToolStripMenuItem,
            this.profitReportToolStripMenuItem,
            this.salesReportToolStripMenuItem,
            this.mnuReportStockReport,
            this.mnuReporttotalDaySales,
            this.purchaseReportToolStripMenuItem,
            this.inventoryMovementToolStripMenuItem,
            this.reportExplorerToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Tag = "18";
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // ticketPrintToolStripMenuItem
            // 
            this.ticketPrintToolStripMenuItem.Name = "ticketPrintToolStripMenuItem";
            this.ticketPrintToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ticketPrintToolStripMenuItem.Text = "Ticket Print";
            this.ticketPrintToolStripMenuItem.Visible = false;
            this.ticketPrintToolStripMenuItem.Click += new System.EventHandler(this.ticketPrintToolStripMenuItem_Click);
            // 
            // reorderListToolStripMenuItem
            // 
            this.reorderListToolStripMenuItem.Name = "reorderListToolStripMenuItem";
            this.reorderListToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.reorderListToolStripMenuItem.Text = "Reorder List";
            this.reorderListToolStripMenuItem.Visible = false;
            // 
            // profitReportToolStripMenuItem
            // 
            this.profitReportToolStripMenuItem.Name = "profitReportToolStripMenuItem";
            this.profitReportToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.profitReportToolStripMenuItem.Text = "Profit Report";
            this.profitReportToolStripMenuItem.Visible = false;
            this.profitReportToolStripMenuItem.Click += new System.EventHandler(this.profitReportToolStripMenuItem_Click);
            // 
            // salesReportToolStripMenuItem
            // 
            this.salesReportToolStripMenuItem.Name = "salesReportToolStripMenuItem";
            this.salesReportToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.salesReportToolStripMenuItem.Text = "&Sales Report";
            this.salesReportToolStripMenuItem.Visible = false;
            this.salesReportToolStripMenuItem.Click += new System.EventHandler(this.salesReportToolStripMenuItem_Click);
            // 
            // mnuReportStockReport
            // 
            this.mnuReportStockReport.Name = "mnuReportStockReport";
            this.mnuReportStockReport.Size = new System.Drawing.Size(185, 22);
            this.mnuReportStockReport.Text = "Stock Report";
            this.mnuReportStockReport.Visible = false;
            this.mnuReportStockReport.Click += new System.EventHandler(this.mnuReportStockReport_Click);
            // 
            // mnuReporttotalDaySales
            // 
            this.mnuReporttotalDaySales.Name = "mnuReporttotalDaySales";
            this.mnuReporttotalDaySales.Size = new System.Drawing.Size(185, 22);
            this.mnuReporttotalDaySales.Text = "Daily Total Sales";
            this.mnuReporttotalDaySales.Visible = false;
            this.mnuReporttotalDaySales.Click += new System.EventHandler(this.mnuReporttotalDaySales_Click);
            // 
            // purchaseReportToolStripMenuItem
            // 
            this.purchaseReportToolStripMenuItem.Name = "purchaseReportToolStripMenuItem";
            this.purchaseReportToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.purchaseReportToolStripMenuItem.Text = "Purchase Report";
            this.purchaseReportToolStripMenuItem.Visible = false;
            this.purchaseReportToolStripMenuItem.Click += new System.EventHandler(this.purchaseReportToolStripMenuItem_Click);
            // 
            // inventoryMovementToolStripMenuItem
            // 
            this.inventoryMovementToolStripMenuItem.Name = "inventoryMovementToolStripMenuItem";
            this.inventoryMovementToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.inventoryMovementToolStripMenuItem.Text = "Inventory Movement";
            this.inventoryMovementToolStripMenuItem.Visible = false;
            this.inventoryMovementToolStripMenuItem.Click += new System.EventHandler(this.inventoryMovementToolStripMenuItem_Click);
            // 
            // reportExplorerToolStripMenuItem
            // 
            this.reportExplorerToolStripMenuItem.Name = "reportExplorerToolStripMenuItem";
            this.reportExplorerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.reportExplorerToolStripMenuItem.Tag = "19";
            this.reportExplorerToolStripMenuItem.Text = "Report Explorer";
            this.reportExplorerToolStripMenuItem.Click += new System.EventHandler(this.reportExplorerToolStripMenuItem_Click);
            // 
            // mnuDBSetting
            // 
            this.mnuDBSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettingUserEntry,
            this.rolewisePermissionToolStripMenuItem,
            this.mnuDBSettingDBSetting,
            this.mnuDBSettingUpdateUserLoginInfo});
            this.mnuDBSetting.Name = "mnuDBSetting";
            this.mnuDBSetting.Size = new System.Drawing.Size(61, 20);
            this.mnuDBSetting.Tag = "20";
            this.mnuDBSetting.Text = "Security";
            // 
            // mnuSettingUserEntry
            // 
            this.mnuSettingUserEntry.Name = "mnuSettingUserEntry";
            this.mnuSettingUserEntry.Size = new System.Drawing.Size(195, 22);
            this.mnuSettingUserEntry.Tag = "21";
            this.mnuSettingUserEntry.Text = "User Entry";
            this.mnuSettingUserEntry.Click += new System.EventHandler(this.mnuSettingUserEntry_Click_1);
            // 
            // rolewisePermissionToolStripMenuItem
            // 
            this.rolewisePermissionToolStripMenuItem.Name = "rolewisePermissionToolStripMenuItem";
            this.rolewisePermissionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.rolewisePermissionToolStripMenuItem.Tag = "16";
            this.rolewisePermissionToolStripMenuItem.Text = "Rolewise Permission";
            this.rolewisePermissionToolStripMenuItem.Click += new System.EventHandler(this.rolewisePermissionToolStripMenuItem_Click_1);
            // 
            // mnuDBSettingDBSetting
            // 
            this.mnuDBSettingDBSetting.Name = "mnuDBSettingDBSetting";
            this.mnuDBSettingDBSetting.Size = new System.Drawing.Size(195, 22);
            this.mnuDBSettingDBSetting.Tag = "1029";
            this.mnuDBSettingDBSetting.Text = "&DB Backup";
            this.mnuDBSettingDBSetting.Click += new System.EventHandler(this.mnuDBSettingDBSetting_Click);
            // 
            // mnuDBSettingUpdateUserLoginInfo
            // 
            this.mnuDBSettingUpdateUserLoginInfo.Name = "mnuDBSettingUpdateUserLoginInfo";
            this.mnuDBSettingUpdateUserLoginInfo.Size = new System.Drawing.Size(195, 22);
            this.mnuDBSettingUpdateUserLoginInfo.Text = "Update User &Login Info";
            this.mnuDBSettingUpdateUserLoginInfo.Visible = false;
            this.mnuDBSettingUpdateUserLoginInfo.Click += new System.EventHandler(this.mnuDBSettingUpdateUserLoginInfo_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // frmGlobalSetting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(992, 478);
            this.Controls.Add(this.tbarAdmin);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGlobalSetting";
            this.Text = "Back Office";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGlobalSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmGlobalSetting_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private void tbarAdmin_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (tbarAdmin.Buttons.IndexOf(e.Button))
            {
                case 0:
                    //frmDbSettings oFrmDbSettings = new frmDbSettings(oUserLogin);
                    ////oFrmDbSettings.MaximizeBox = false;
                    ////oFrmDbSettings.MinimizeBox = false;
                    //oFrmDbSettings.MdiParent = this;
                    //oFrmDbSettings.Show();

                    break;
                case 1:
                    frmItemNew objfrmItem = new frmItemNew();
                    objfrmItem.MdiParent = this;
                    objfrmItem.Show();
                    break;

                case 2:
                    frmPurchase objfrmPurches = new frmPurchase();
                    objfrmPurches.MdiParent = this;
                    objfrmPurches.Show();
                    break;

                case 3:
                    //frmDamage objfrmDamage = new frmDamage(oUserLogin);
                    ////objfrmDamage.MaximizeBox = false;
                    ////objfrmDamage.MinimizeBox = false;
                    //objfrmDamage.MdiParent = this;
                    //objfrmDamage.Show();
                    break;
                case 4:
                    frmSupplierEntry objSupplier = new frmSupplierEntry();
                    objSupplier.MdiParent = this;
                    objSupplier.Show();
                    break;
                case 5:
                    //frmUserStatus objUsrStat = new frmUserStatus();
                    //objUsrStat.Show();
                    break;

                case 6:
                    frmcustomerentry o_frmcustomerEntry = new frmcustomerentry();
                    o_frmcustomerEntry.MdiParent = this;
                    o_frmcustomerEntry.Show();
                    break;

                case 7:
                    UserLogins UL = new UserLoginsDAO().UserLogins_GetById(MDIParent.CF2);
                    if (UL != null)
                    {
                        UL.UserLogoutTime = DateTime.Now;
                        new UserLoginsDAO().Update(UL);
                    }
                    MDIParent.userId = 0;
                    MDIParent.storeId = 0;
                    MDIParent.shiftId = 0;

                    Application.Exit();

                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        private void frmGlobalSetting_Load(object sender, EventArgs e)
        {
            if (MDIParent.roleId > 0)
            {
                List<RoleWisePermission> lstRolePermission = new RoleWisePermissionDAO().RoleWisePermission_GetByRoleId(MDIParent.roleId);
                //lstRolePermG = lstRolePermission;
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (item.Tag != null)
                    {
                        SetMenuPermission(item, lstRolePermission);
                    }
                }

                foreach (var item in tbarAdmin.Buttons)
                {
                    if (item is ToolBarButton)
                    {
                        ToolBarButton btn = item as ToolBarButton;
                        if (btn.Tag != null)
                        {
                            int pageId = Convert.ToInt32(btn.Tag);
                            RoleWisePermission rwp = lstRolePermission.Where(p => p.PageId == pageId).FirstOrDefault();
                            if (rwp != null && rwp.PermissionId > 0)
                                btn.Visible = rwp.CanSelect;
                        }
                    }
                }
            }
            #region FOR SMALL CHECKINGS
            //try
            //{
            //    POSsible.Reports.rptInvoiceForCreditSale report1 = new Reports.rptInvoiceForCreditSale();
            //    report1.SetParameterValue("@InvoiceId", 3);
            //    report1.SetParameterValue("@SaleType", "Credit");

            //    report1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            //    report1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            //    PrintDialog printDialog = new PrintDialog();

            //    DialogResult dgResult = printDialog.ShowDialog();

            //    if (dgResult == DialogResult.OK)
            //    {
            //        report1.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
            //        report1.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            //    }
                

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            #endregion
        }

        private void SetMenuPermission(ToolStripMenuItem item, List<RoleWisePermission> lstPrm)
        {
            int pageId = Convert.ToInt32(item.Tag);
            RoleWisePermission rwp = lstPrm.Where(p => p.PageId == pageId).FirstOrDefault();
            if (rwp != null && rwp.PermissionId > 0 && rwp.CanSelect)
            {
                item.Visible = true;
            }
            else
            {
                item.Visible = false;
            }

            if (item.Visible)
            {
                foreach (ToolStripItem tsi in item.DropDownItems)
                {
                    if (item.Tag != null)
                    {
                        if (tsi is ToolStripMenuItem)
                        {
                            SetMenuPermission((ToolStripMenuItem)tsi, lstPrm);
                        }
                    }
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ticketPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTicketReport objfrmticket = new frmTicketReport();
            //objfrmticket.ShowDialog();
        }

        private void profitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmProfitReport objfrmprofit = new frmProfitReport();
            //objfrmprofit.ShowDialog();
        }

        private void frmGlobalSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            //POSsible.Controllers.SecurityManager securitymanager = new POSsible.Controllers.SecurityManager();
            //securitymanager.updateLogin4LogOff(oUserLogin);
            UserLogins UL = new UserLoginsDAO().UserLogins_GetById(MDIParent.CF2);
            if (UL != null)
            {
                UL.UserLogoutTime = DateTime.Now;
                new UserLoginsDAO().Update(UL);
            }
            frmLogin login = new frmLogin();
            login.Show();
            this.Dispose();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSalesReport ofrmSalesReport = new frmSalesReport(oUserLogin);
            //ofrmSalesReport.MdiParent = this;
            //ofrmSalesReport.Show();
        }


        private void mnuSetupDBSetting_Click(object sender, EventArgs e)
        {
            frmDbSettings oFrmDbSettings = new frmDbSettings();
            //oFrmDbSettings.MaximizeBox = false;
            //oFrmDbSettings.MinimizeBox = false;
            oFrmDbSettings.MdiParent = this;
            oFrmDbSettings.Show();
        }

        private void mnuMainEntryFormItem_Click(object sender, EventArgs e)
        {
            frmItemNew objfrmItem = new frmItemNew();
            //frmSupplierEntry objfrmItem = new frmSupplierEntry();
            objfrmItem.MdiParent = this;
            objfrmItem.Show();
        }

        private void mnuMainEntryFormPurches_Click(object sender, EventArgs e)
        {
            frmPurchase objfrmPurches = new frmPurchase();
            objfrmPurches.MdiParent = this;
            objfrmPurches.Show();
        }


        private void mnuSetupCustomer_Click(object sender, EventArgs e)
        {
            frmcustomerentry o_frmcustomerEntry = new frmcustomerentry();
            o_frmcustomerEntry.MdiParent = this;
            o_frmcustomerEntry.Show();
        }

        private void mnuSetupItem_Click_1(object sender, EventArgs e)
        {
            frmItemNew objfrmItem = new frmItemNew();
            objfrmItem.MdiParent = this;
            objfrmItem.Show();

        }

        private void mnuSetupSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierEntry objSupplier = new frmSupplierEntry();
            //objSupplier.MaximizeBox = false;
            //objSupplier.MinimizeBox = false;
            objSupplier.MdiParent = this;
            objSupplier.Show();
        }

        private void mnuDBSettingUpdateUserLoginInfo_Click(object sender, EventArgs e)
        {
            frmUserStatus objUsrStat = new frmUserStatus();
            objUsrStat.Show();
        }

        private void mnuDBSettingDBSetting_Click(object sender, EventArgs e)
        {
            frmDBBackup oFrmDbSettings = new frmDBBackup();
            oFrmDbSettings.MdiParent = this;
            oFrmDbSettings.Show();
        }

        private void mnuSetupDepartment_Click(object sender, EventArgs e)
        {
            frmProductCategory objfrmProductCategory = new frmProductCategory();
            objfrmProductCategory.MdiParent = this;
            objfrmProductCategory.Show();
        }

        private void mnuSetupMeasurement_Click(object sender, EventArgs e)
        {
            frmUnitMeasurement objfrmUnitInfo = new frmUnitMeasurement();
            objfrmUnitInfo.MdiParent = this;
            objfrmUnitInfo.Show();
        }


        private void mnuReportStockReport_Click(object sender, EventArgs e)
        {
            frmStockReport ofrmStockReport = new frmStockReport();
            ofrmStockReport.ShowDialog();
        }

        private void mnuReporttotalDaySales_Click(object sender, EventArgs e)
        {
            Frmsalesreport oFrmsalesreport = new Frmsalesreport();
            oFrmsalesreport.ShowDialog();
        }

        private void ManuSetupCompanyInformation_Click(object sender, EventArgs e)
        {
            frmCompany ofrmCompany = new frmCompany();
            ofrmCompany.MdiParent = this;
            ofrmCompany.Show();
        }

        private void mnuSetupcustomerPointClaim_Click(object sender, EventArgs e)
        {
            frmCustomerPointClaim ofrmfrmCustomerPointClaim = new frmCustomerPointClaim();
            ofrmfrmCustomerPointClaim.MdiParent = this;
            ofrmfrmCustomerPointClaim.Show();
        }

        private void purchaseProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase ofrmPurchase = new frmPurchase();
            ofrmPurchase.Show();
        }

        private void customerEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcustomerentry oCustomer = new frmcustomerentry();
            oCustomer.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPurchase oPurchase = new frmRptPurchase();
            oPurchase.Show();
        }

        private void inventoryMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReportViewer rv = new frmReportViewer(this, 1);
            //rv.Show();
        }

        private void purchasePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasePayment PP = new frmPurchasePayment();
            PP.Show();
        }

        private void creditCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreditCollection CC = new frmCreditCollection();
            CC.Show();
        }

        private void productPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductPromotion PP = new frmProductPromotion();
            PP.Show();
        }

        private void reportExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportExplorer re = new frmReportExplorer();
            re.MdiParent = this;
            re.WindowState = FormWindowState.Maximized;
            re.Show();
        }

        private void mnuMainEntryFormItem_Click_1(object sender, EventArgs e)
        {
            frmItemNew objfrmItem = new frmItemNew();
            objfrmItem.MdiParent = this;
            objfrmItem.Show();
        }

        private void purchasePaymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPurchasePayment PPfrm = new frmPurchasePayment();
            PPfrm.MdiParent = this;
            PPfrm.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutfrm = new About();
            aboutfrm.MdiParent = this;
            aboutfrm.Show();
        }


        private void mnuSettingUserEntry_Click_1(object sender, EventArgs e)
        {
            frmUserEntry objfrmUserEntry = new frmUserEntry();
            objfrmUserEntry.MdiParent = this;
            objfrmUserEntry.Show();
        }

        private void rolewisePermissionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmRoleWisePermission frmRole = new frmRoleWisePermission();
            frmRole.MdiParent = this;
            frmRole.Show();
        }

        private void storeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStore frm = new frmStore();
            frm.MdiParent = this;
            frm.Show();
        }

        private void openingQuantityEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningQtyEntry frm = new OpeningQtyEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void refundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRefund frm = new frmRefund();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBank frm = new frmBank();
            frm.Show();
        }

        private void salesRefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRefund frm = new frmRefund();
            frm.MdiParent = this;
            frm.Show();
        }

        private void expenseTypeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactionPurpose frm = new frmTransactionPurpose();
            frm.MdiParent = this;
            frm.Show();
        }

        private void expenseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyTransaction frm = new frmDailyTransaction();
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
