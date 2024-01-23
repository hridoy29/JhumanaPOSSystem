using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using POSsible.Factories;
using POSsible.Models;
using POSsible.Views;
using System.Data.SqlClient;
using POSsible.Reports;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Reports
{
    public partial class frmProfitReport : Form//, IItemView
    {
       // private IProductManager _ProductManager;
        private static readonly string ritpos_product_profit_by_dept = "ritpos_product_profit_by_dept";

        public frmProfitReport()
        {
            InitializeComponent();
           // _ProductManager = Factory.GetProductManager(this);
           // LoadDepartment();
        }

        private void LoadDepartment()
        {
         //   _ProductManager.getDepartmentList();
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowprofitReport();
            //DataSet dsItems = new DataSet();
            //dsItems = _ProductManager.getProfitByDepartment(int.Parse(cboDepartment.SelectedValue.ToString()), DateTime.Parse(dtpFrom.Text), DateTime.Parse(dtpTo.Text));
            //rProfit cr = new rProfit();
            //cr.Refresh();
            //cr.SetDataSource(dsItems);
            //frmReportViewer objReportViewer = new frmReportViewer();
            //objReportViewer.crViewer.ReportSource = cr;
            //objReportViewer.Show();
        }

        public void ShowprofitReport()
        {
            try
            {

                DataSet Ds = new DataSet();
                Ds = getProfitlist();
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objView = new frmReportViewer();
                    CrptProfit oRpt = new CrptProfit();
                    oRpt.SetDataSource(Ds.Tables[0]);
                    objView.CRV.ReportSource = oRpt;
                    objView.CRV.DisplayGroupTree = false;
                    objView.CRV.Zoom(100);
                    objView.Show();
                }
            }
            catch
            {
            }

        }
        public DataSet getProfitlist()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            //SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), ritpos_product_profit_by_dept);
            //// Did we fail?
            //if (parms == null)
            //{
            //    // Create the parameters.
            //    parms = new SqlParameter[] 
            //    {
            //        new SqlParameter("from", SqlDbType.DateTime),
            //        new SqlParameter("to",SqlDbType.DateTime)
            //    };

            //    // Store the parameters in the cache.
            //    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), ritpos_product_profit_by_dept, parms);
            //} // End if we failed to load the parameters.

            //// Assign values to the parameters.
            
            //parms[0].Value = dtpFrom.Value;
            //parms[1].Value = dtpTo.Value; 
            // Execute the SQL statement.
            string SqlStr = "EXEC ritpos_product_profit_by_dept  '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "'";
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      /*  #region Implementation of IItemView methods
        public void Alert(string sMsg)
        {
            MessageBox.Show(sMsg);
        }

        public void updateItemGrid(List<CProduct> oProduct)
        {
        }

        public void ClearFormContent()
        {
        }

        public void FillUpFormContent(CProduct oProduct)
        {
        }

        public void putDepartmentList(List<CDepartment> oLstDepartment)
        {
            cboDepartment.DataSource = oLstDepartment;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "CategoryId";
        }
        public void putUnitMeasurementList(List<CUnitMeasurement> oLstMeasurementList)
        {
        }
        #endregion*/

    }
}