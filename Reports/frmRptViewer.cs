using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSsible.Reports
{
    public partial class frmRptViewer : Form
    {
        int ReportId = 0;
        DateTime FromDate = new DateTime();
        DateTime ToDate = new DateTime();
        DateTime Date = new DateTime();
        //int CustomerId = 0;
        int InvoiceId = 0;
        int SaleType = 0;

        public frmRptViewer()
        {
            InitializeComponent();
        }

        public frmRptViewer(int _invId)
        {
            InvoiceId = _invId;
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            rptInvoiceForCreditSale rptCrInv = new rptInvoiceForCreditSale();
            rptCrInv.Refresh();
            Helper.SetDataBaseLogonForCrReport(rptCrInv);
            rptCrInv.SetParameterValue("@InvoiceId", InvoiceId);
            rptCrInv.SetParameterValue("@SaleType", "Yes");
            rptCrInv.SetParameterValue("@ShowRetailPrice", false);
            crystalReportViewer1.ReportSource = rptCrInv;
        }
    }
}
