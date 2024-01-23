using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Reports
{
    public partial class frmStockReport : Form
    {
        private static readonly string ritpos_report_item_stock = "ritpos_report_item_stock";

        public frmStockReport()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport(ritpos_report_item_stock);
        }

        public void ShowReport(string sProcedureName)
        {
            try
            {

                //DataSet Ds = new DataSet();
                //Ds = getSalesInfo(sProcedureName);

                //if (Ds.Tables[0].Rows.Count > 0)
                //{
                frmRptViewer objView = new frmRptViewer();

                //CrysStockReport oRpt = new CrysStockReport();
                //oRpt.SetDataSource(Ds.Tables[0]);
                //objView.CRV.ReportSource = oRpt;

                //objView.CRV.DisplayGroupTree = false;
                //objView.CRV.Zoom(100);
                //objView.MdiParent = this;
                objView.Show();
                //}
                //else
                //{
                //    MessageBox.Show("No data available");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataSet getSalesInfo(string sProcedureName)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(),
                CommandType.StoredProcedure,
                sProcedureName);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}