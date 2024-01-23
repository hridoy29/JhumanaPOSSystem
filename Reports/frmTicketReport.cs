using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using POSsible.Factories;
using POSsible.Models;
using POSsible.Views;
using Microsoft.ApplicationBlocks.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace POSsible.Reports
{
    public partial class frmTicketReport : Form,  IItemView     
    {
        private static readonly string ritpos_product_find_by_ticket = "ritpos_product_find_by_ticket";
        private IProductManager _ProductManager;
        public frmTicketReport()
        {
            InitializeComponent();
            _ProductManager = Factory.GetProductManager(this);
            LoadDepartment();
            cboTicketType.SelectedIndex = 0;
        }

        private void LoadDepartment()
        {
            _ProductManager.getDepartmentList(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
        public void ShowReport()
        {
            try
            {

                DataSet Ds = new DataSet();
                Ds = getListofproduct();
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objView = new frmReportViewer();
                    if (int.Parse(cboTicketType.SelectedIndex.ToString()) == 0)
                    {
                        CrptSelfTicket_ oRpt = new CrptSelfTicket_();
                        oRpt.SetDataSource(Ds.Tables[0]);
                        objView.CRV.ReportSource = oRpt;

                    }
                    else
                    {
                        CrptA5Ticket oRpt = new CrptA5Ticket();
                        oRpt.SetDataSource(Ds.Tables[0]);
                        objView.CRV.ReportSource = oRpt;

                    }

                    objView.CRV.DisplayGroupTree = false;
                    objView.CRV.Zoom(100);
                    objView.Show();
                }
            }
            catch
            {
            }

        }
        public DataSet getListofproduct()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), ritpos_product_find_by_ticket);
            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
                {
                    new SqlParameter("categoryId", SqlDbType.Int),
                    new SqlParameter("ticketId",SqlDbType.Bit)
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), ritpos_product_find_by_ticket, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = int.Parse(cboDepartment.SelectedValue.ToString());
            parms[1].Value = int.Parse(cboTicketType.SelectedIndex.ToString());
            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, ritpos_product_find_by_ticket, parms);
        }
        #region Implementation of IItemView methods
        public void Alert(string sMsg)
        {
            MessageBox.Show(sMsg);
        }

        public void updateItemGrid(List<CProduct> oProduct)
        {
        }

        public void ClearFormContent( )
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
        #endregion

        private void cboTicketType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}