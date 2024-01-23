using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POSsible.Reports
{
    public partial class frmReportViewer : Form
    {
        public int ReportId = 0;
        public DateTime frmDate;
        public DateTime toDate;
        public int supplierId;
        public int StoreId;

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(frmRptPurchase rptPurchase, int rId, int supId, int storeId, DateTime fdt, DateTime tdt)
        {
            ReportId = rId;
            supplierId = supId;
            StoreId = storeId;
            frmDate = fdt;
            toDate = tdt;
            InitializeComponent();
        }

        public frmReportViewer(frmGlobalSetting frm, int rId)
        {
            ReportId = rId;
            InitializeComponent();
        }

        private void CRV_Load(object sender, EventArgs e)
        {
            switch (ReportId)
            {
                case 1:
                    rptInventoryMovement rpt = new rptInventoryMovement();
                    Helper.SetDataBaseLogonForCrReport(rpt);
                    rpt.SetParameterValue("@fdt", DateTime.Now);
                    rpt.SetParameterValue("@edt", DateTime.Now);
                    CRV.ReportSource = rpt;
                    break;
                case 2:
                    Purchase pur = new Purchase();
                    Helper.SetDataBaseLogonForCrReport(pur);
                    pur.SetParameterValue("@fdt", frmDate);
                    pur.SetParameterValue("@tdt", toDate);
                    pur.SetParameterValue("@storeId", StoreId);
                    pur.SetParameterValue("@supplierId", supplierId);
                    CRV.ReportSource = pur;
                    break;
                default:
                    break;
            }

        }
    }
}