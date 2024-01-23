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
    public partial class frmSalesReport : Form, IItemView    
    {
        //private static readonly string ritpos_product_find_by_ticket = "ritpos_product_find_by_ticket";
        private IProductManager _ProductManager;

        private static readonly string ritpos_report_sales_summary_by_department_date_to_date = "ritpos_report_sales_summary_by_department_date_to_date";
        private static readonly string ritpos_sales_report_date_to_date = "ritpos_sales_report_date_to_date";
        private static readonly string ritpos_sales_report_by_department_date_to_date = "ritpos_sales_report_by_department_date_to_date";

        public CUser oUserLogin = new CUser();

        public frmSalesReport(CUser oUser)
        {
            InitializeComponent();
            oUserLogin = oUser;
            _ProductManager = Factory.GetProductManager(this);
            
            LoadDepartment();
        }

        public frmSalesReport()
        {
            InitializeComponent();
            _ProductManager = Factory.GetProductManager(this);
            LoadDepartment();
        }

        private void LoadDepartment()
        {
            _ProductManager.getDepartmentList(0);
            SqlDataReader dr = GetLoginTime();

            if (dr.Read())            
            {
                DateTime dtLogin = DateTime.Parse(dr[0].ToString());
                DateTime dtLogout = DateTime.Parse(dr[1].ToString());

                dtpFromTime.Text = dtLogin.Hour + ":" + dtLogin.Minute + ":" + dtLogin.Second;                
            }
            
        }

        private SqlDataReader GetLoginTime()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            // Execute the SQL statement.
            return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, "ritpos_get_login_time");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (radAllDepartment.Checked == true)
            {
                ShowReport(ritpos_report_sales_summary_by_department_date_to_date);
                //ShowReport(ritpos_sales_report_date_to_date);
            }
            if (radDepartmentWise.Checked == true)
            {
                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    MessageBox.Show("Plase Check From Date or To Date");
                }
                if (cmbDepartment.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Plase Select a Department");
                    return; 
                }
                ShowReport(ritpos_sales_report_by_department_date_to_date, 2);
            }
        }

        public void ShowReport(string sProcedureName)
        {
            try
            {

                DataSet Ds = new DataSet();
                Ds = getSalesInfo(sProcedureName, 1);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objView = new frmReportViewer();

                    CrptSalesSummary oRpt = new CrptSalesSummary();
                    oRpt.SetDataSource(Ds.Tables[0]);
                    objView.CRV.ReportSource = oRpt;

                    objView.CRV.DisplayGroupTree = false;
                    objView.CRV.Zoom(100);
                    objView.Show();
                }
                else
                {
                    MessageBox.Show("There is no data for Selected Date or Department");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowReport(string sProcedureName,int iStatus)
        {
            try
            {
                DataSet Ds = new DataSet();
                Ds = getSalesInfo(sProcedureName, iStatus);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objView = new frmReportViewer();

                    CrptSalesReportByDepartmentWiseDateToDate oRpt = new CrptSalesReportByDepartmentWiseDateToDate();
                    
                    oRpt.SetDataSource(Ds.Tables[0]);
                    objView.CRV.ReportSource = oRpt;

                    objView.CRV.DisplayGroupTree = false;
                    objView.CRV.Zoom(100);
                    objView.Show();
                }
                else
                {
                    MessageBox.Show("There is no date for Selected Date or Department");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataSet getSalesInfo(string sProcedureName,int iStatus)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), sProcedureName);

            string sFromTime;

            sFromTime = dtpFromTime.Value.Hour.ToString();
            sFromTime = sFromTime + ":" + dtpFromTime.Value.Minute.ToString();
            sFromTime = sFromTime + ":" + dtpFromTime.Value.Second.ToString();

            string sToTime;

            sToTime = dtpToTime.Value.Hour.ToString();
            sToTime = sToTime + ":" + dtpToTime.Value.Minute.ToString();
            sToTime = sToTime + ":" + dtpToTime.Value.Second.ToString();


            
            // Did we fail?
            if (parms == null)
            {
                if (iStatus == 1)
                {
                        // Create the parameters.
                    parms = new SqlParameter[] 
                    {
                        new SqlParameter("invoice_from_date",SqlDbType.DateTime),
                        new SqlParameter("invoice_to_date", SqlDbType.DateTime),
                        new SqlParameter("CostOfSales", SqlDbType.Int),
                        new SqlParameter("UserName", SqlDbType.NVarChar)
                    };
                }

                else
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
                    {
                        new SqlParameter("invoice_from_date",SqlDbType.DateTime),
                        new SqlParameter("invoice_to_date", SqlDbType.DateTime),
                        new SqlParameter("deaprtment_id",SqlDbType.Int),                   
                        new SqlParameter("status", SqlDbType.Int)
                    };
                }

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), sProcedureName, parms);
            } // End if we failed to load the parameters.

            if (iStatus == 1)
            {                
                // Assign values to the parameters.

                parms[0].Value = dtpFromDate.Value.ToString("dd MMM yyyy") +" "+ sFromTime;


                parms[1].Value = dtpToDate.Value.ToString("dd MMM yyyy") + " " + sToTime;//.ToString("dd MMM yyyy HH:mm");                

                if (txtCostOfSales.Text.Trim() == string.Empty)
                {
                    parms[2].Value = 75;
                }
                else
                {
                    parms[2].Value = txtCostOfSales.Text.Trim();
                }
                parms[3].Value = oUserLogin.UserFirstName + " " + oUserLogin.UserLastName;
            }
            else
            {
                // Assign values to the parameters.
                parms[0].Value = dtpFromDate.Value.ToString("dd MMM yyyy") + " " + sFromTime;
                parms[1].Value = dtpToDate.Value.ToString("dd MMM yyyy") + " " + sToTime;//.ToString("dd MMM yyyy HH:mm");
                //parms[2].Value = cmbDepartment.ValueMember;
                parms[2].Value = int.Parse(cmbDepartment.SelectedValue.ToString());
                parms[3].Value = iStatus;
            }

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, sProcedureName, parms);
        }


        #region Implementation of IItemView methods
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

        public void putUnitMeasurementList(List<CUnitMeasurement> oLstMeasurementList)
        {
        }

        public void putDepartmentList(List<CDepartment> oLstDepartment)
        {
            cmbDepartment.DataSource = oLstDepartment;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "CategoryId";
        }

        #endregion
        
        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            cmbDepartment.Enabled = false;
            radAllDepartment.Checked = true;
            radDepartmentWise.Checked = false;
            
        }

        private void radAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (radAllDepartment.Checked == true)
            {
                radDepartmentWise.Checked = false;
                cmbDepartment.Enabled = false;
            }
        }

        private void radDepartmentWise_CheckedChanged(object sender, EventArgs e)
        {
            if (radDepartmentWise.Checked == true)
            {
                radAllDepartment.Checked = false;
                cmbDepartment.Enabled = true;
            }
        }

        /// <summary>
        /// The method allow only Numeric(Decimal) except any Letter
        /// </summary>
        /// <param name="str">Entry string</param>
        /// <returns>true or false</returns>
        public static bool Allow_All_Numeric(string str)
        {
            char ch;
            int i = 0;
            string str1 = str;
            while (str1.Length != 0)
            {
                ch = str1[i];
                switch (ch)
                {
                    case '0':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '1':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '2':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '3':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '4':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '5':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '6':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '7':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '8':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '9':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    case '.':
                        str1 = str1.Substring(i + 1, str1.Length - 1);
                        break;
                    default:
                        str1 = "";
                        i++;
                        return false;

                }
            }
            return true;
        }

        private void txtCostOfSales_TextChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < txtCostOfSales.Text.Trim().Length; j++)
            {
                if (Allow_All_Numeric(txtCostOfSales.Text.Trim().ToString()) == false)
                {
                    txtCostOfSales.Text = "";
                }                
            }
        }
    }
}