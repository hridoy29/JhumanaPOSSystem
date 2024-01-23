using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using POSsible.Views;
using POSsible.Factories;
using POSsible.Reports;

namespace POSsible
{
    public partial class frmCustomerPointClaim : Form, ICustomerInvoiceView
    {
        private ICustomerInvoiceManager _CustomerInvoiceManager;
        private int iRowIndex = 0;
        public CUser oUserLogin = new CUser();

        public frmCustomerPointClaim()
        {
            InitializeComponent();
        }

        public frmCustomerPointClaim(CUser oUser)
        {
            InitializeComponent();
            oUserLogin = oUser;            
            _CustomerInvoiceManager = Factory.GetCustomerInvoiceManager(this);
            BindGrid();
        }
        
        private void BindGrid()
        {
            try
            {
                //dgvCusClaimPoint.Rows.Clear();
                List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();

                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimList();

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, String.Format("{0:0.00}", lCustomerInvoiceList[i].InvoiceAmount), String.Format("{0:0.00}", lCustomerInvoiceList[i].PointsEarned), String.Format("{0:0.00}", (lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned)), false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<CCustomerInvoice> olCustomerInvoice = new List<CCustomerInvoice>();


            if (txtPoint.Text.Trim().ToString().Equals(string.Empty))
            {
                MessageBox.Show("Enter Claim Point");                
                txtPoint.Focus();
                return;
            }
            else if (float.Parse(txtPoint.Text.Trim()) <= 0)
            {
                MessageBox.Show("Enter Proper Claim Point");
                txtPoint.Text = "";
                txtPoint.Focus();
                return;
            }

            if (grpSelected.Checked == true)
            {
                if (CheckSelectedClaimedPoint() == false)
                {
                    MessageBox.Show(this, "Claim Point for selected customer's should not more than current balance.", "Roots POS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            if (dgvCusClaimPoint.Rows.Count > 0)
            {
                for (int i = 0; i < dgvCusClaimPoint.Rows.Count; i++)
                {
                    CCustomerInvoice oCustomerInvoice = new CCustomerInvoice();

                    if (grpGroup.Checked == true)
                    {
                        if (Convert.ToDouble(dgvCusClaimPoint.Rows[i].Cells[6].Value) >= Convert.ToDouble(txtPoint.Text.Trim()))
                        {
                            oCustomerInvoice.CustomerBarCode = dgvCusClaimPoint.Rows[i].Cells[0].Value.ToString();
                            oCustomerInvoice.PointsEarned = float.Parse(txtPoint.Text.Trim().ToString());
                            oCustomerInvoice.EnteredBy = MDIParent.userId.ToString();

                            olCustomerInvoice.Add(oCustomerInvoice);
                        }
                    }
                    else if (grpSelected.Checked == true)
                    {
                       DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvCusClaimPoint.Rows[i].Cells[7];

                       if (chk.Value != null)
                       {
                           if (dgvCusClaimPoint.Rows[i].Cells[7].Value.ToString().ToLower() == "true")
                           {
                               oCustomerInvoice.CustomerBarCode = dgvCusClaimPoint.Rows[i].Cells[0].Value.ToString();
                               oCustomerInvoice.PointsEarned = float.Parse(txtPoint.Text.Trim().ToString());
                               oCustomerInvoice.EnteredBy = MDIParent.userId.ToString();
                               olCustomerInvoice.Add(oCustomerInvoice);
                           }
                       }
                    }                    
                }

                _CustomerInvoiceManager.createCustomerPointClaim(olCustomerInvoice);


                this.bntSearch_Click(sender, e);
                this.dtpToTime.Value = DateTime.Now;
            }
        }

        private bool CheckSelectedClaimedPoint()
        {
            
            for (int i = 0; i < dgvCusClaimPoint.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvCusClaimPoint.Rows[i].Cells[7];
                
                if (chk.Value != null)
                {
                    if (dgvCusClaimPoint.Rows[i].Cells[7].Value.ToString().ToLower() == "true")
                    {
                        if (float.Parse(dgvCusClaimPoint.Rows[i].Cells[6].Value.ToString()) < float.Parse(txtPoint.Text.Trim()))
                        {
                            return false; 
                        }

                    }                    
                }
            }
            return true;
        }


        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "RITPOS");
        }

        private void frmCustomerPointClaim_Load(object sender, EventArgs e)
        {
            txtSearce.Enabled = false;

            cmbSearchOption.IsAccessible = false;
            
            cmbSearchOption.Items.Add("All");
            cmbSearchOption.Items.Add("Barcode");
            cmbSearchOption.Items.Add("Name");
            cmbSearchOption.Items.Add("Suburb");
            cmbSearchOption.Items.Add("Post Code");

            cmbSearchOption.SelectedIndex = 0;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            dgvCusClaimPoint.Rows.Clear();
            List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();
            
            if (cmbSearchOption.SelectedItem.ToString() == "All")
            {

                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimListSearch(0, txtSearce.Text.Trim().ToString());

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, lCustomerInvoiceList[i].InvoiceAmount, lCustomerInvoiceList[i].PointsEarned, lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned);
                }
            }
            if (cmbSearchOption.SelectedItem.ToString() == "Barcode")
            {
                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimListSearch(1, txtSearce.Text.Trim().ToString());

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, lCustomerInvoiceList[i].InvoiceAmount, lCustomerInvoiceList[i].PointsEarned, lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned);
                }
            }
            if (cmbSearchOption.SelectedItem.ToString() == "Name")
            {
                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimListSearch(2, txtSearce.Text.Trim().ToString());

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, lCustomerInvoiceList[i].InvoiceAmount, lCustomerInvoiceList[i].PointsEarned, lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned);
                }
            }
            if (cmbSearchOption.SelectedItem.ToString() == "Suburb")
            {
                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimListSearch(3, txtSearce.Text.Trim().ToString());

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, lCustomerInvoiceList[i].InvoiceAmount, lCustomerInvoiceList[i].PointsEarned, lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned);
                }
            }
            if (cmbSearchOption.SelectedItem.ToString() == "Post Code")
            {
                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimListSearch(4, txtSearce.Text.Trim().ToString());

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, lCustomerInvoiceList[i].InvoiceAmount, lCustomerInvoiceList[i].PointsEarned, lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned);
                }
            }
        }

        private void cmbSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpGroup.Checked = true;


            if (cmbSearchOption.SelectedItem.ToString() == "All")
            {
                dgvCusClaimPoint.Rows.Clear();
                List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();
                lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerPointClaimListSearch(0, txtSearce.Text.Trim().ToString());

                for (int i = 0; i < lCustomerInvoiceList.Count; i++)
                {
                    dgvCusClaimPoint.Rows.Add(lCustomerInvoiceList[i].CustomerBarCode.ToString(), lCustomerInvoiceList[i].Name, lCustomerInvoiceList[i].Address.ToString(), lCustomerInvoiceList[i].Mobile, lCustomerInvoiceList[i].InvoiceAmount, lCustomerInvoiceList[i].PointsEarned, lCustomerInvoiceList[i].InvoiceAmount - lCustomerInvoiceList[i].PointsEarned);
                }
                txtSearce.Enabled = false;
            }
            else
                txtSearce.Enabled = true;

            txtSearce.Text = "";
        }

        #region Report Section

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Plase Check From Date or To Date");
            }
            
            ShowReport("ritpos_report_customer_claim_point");

        }

        public void ShowReport(string sProcedureName)
        {
            //try
            //{
            //    DataSet Ds = new DataSet();
            //    Ds = getSalesInfo(sProcedureName);

            //    if (Ds.Tables[0].Rows.Count > 0)
            //    {
            //        frmReportViewer objView = new frmReportViewer();

            //        CrysCustomerClaimPoint oRpt = new CrysCustomerClaimPoint();

            //        oRpt.SetDataSource(Ds.Tables[0]);
            //        objView.CRV.ReportSource = oRpt;

            //        objView.CRV.DisplayGroupTree = false;
            //        objView.CRV.Zoom(100);
            //        objView.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("There is no data for Selected Date");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public DataSet getSalesInfo(string sProcedureName)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            System.Data.SqlClient.SqlParameter[] parms = Microsoft.ApplicationBlocks.Data.SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), sProcedureName);

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
                // Create the parameters.
                parms = new System.Data.SqlClient.SqlParameter[] 
                {
                    new System.Data.SqlClient.SqlParameter("invoice_from_date",SqlDbType.DateTime),
                    new System.Data.SqlClient.SqlParameter("invoice_to_date", SqlDbType.DateTime)                        
                };
                
                // Store the parameters in the cache.
                Microsoft.ApplicationBlocks.Data.SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), sProcedureName, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.

            parms[0].Value = dtpFromDate.Value.ToString("dd MMM yyyy") + " " + sFromTime;
            parms[1].Value = dtpToDate.Value.ToString("dd MMM yyyy") + " " + sToTime;

            
            // Execute the SQL statement.
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, sProcedureName, parms);
        }
        #endregion Report

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.grpGroup.Checked = true;
            this.txtPoint.Text = "";
            this.txtSearce.Text = "";
            cmbSearchOption.SelectedIndex = 0;            
        }

        private void dgvcustomerClaimPoint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grpSelected.Checked == false)
            {
                if (CheckSelectedClaimedPoint() == true)
                {
                    this.grpSelected.Checked = true;
                }
            }
        }        
    }
}