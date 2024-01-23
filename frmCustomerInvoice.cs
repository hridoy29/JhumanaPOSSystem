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


namespace POSsible
{
    public partial class frmCustomerInvoice : Form, ICustomerInvoiceView
    {
        private ICustomerInvoiceManager _CustomerInvoiceManager;
        private frmcustomerentry ofrmcustomerentry;
        private int iRowIndex = 0;
        public CUser oUserLogin = new CUser();

        public frmCustomerInvoice()
        {
            InitializeComponent();
        }

        public frmCustomerInvoice(frmcustomerentry ofrmcustomerentry1, CUser oUser)
        {
            InitializeComponent();
            oUserLogin = oUser;

            ofrmcustomerentry = new frmcustomerentry();
            ofrmcustomerentry = ofrmcustomerentry1;
            
            _CustomerInvoiceManager = Factory.GetCustomerInvoiceManager(this);
            //BindGrid();
            //AddMode();
        }

        private void BindGrid()
        {
            double dTotalPoint=0;
            dgvcustomer.Rows.Clear();
            List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();

            lCustomerInvoiceList = _CustomerInvoiceManager.getCustomerInvoiceList(txtCustomerBarcode.Text.Trim());

            for (int i = 0; i < lCustomerInvoiceList.Count; i++)
            {
                dgvcustomer.Rows.Add(lCustomerInvoiceList[i].InvoiceId.ToString(), lCustomerInvoiceList[i].PointsEarned);
                dTotalPoint = dTotalPoint + double.Parse(lCustomerInvoiceList[i].PointsEarned.ToString());
            }

            this.txtTotalPoint.Text = dTotalPoint.ToString();
        }

        private void EditOrDeleteMode()
        {
            btnAdd.Text = "UPDATE";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;

            txtCustomerInvoice.Text = "";
            txtPoint.Text = "";            
        }

        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "RITPOS");
        }

        private void frmCustomerInvoice_Load(object sender, EventArgs e)
        {
            this.txtCustomerBarcode.Text = ofrmcustomerentry.txtCode.Text;
            this.txtCustomerName.Text = ofrmcustomerentry.txtCustomerName.Text;
            this.BindGrid();
        }

        private void dgvcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtPoint.Text = "";
            this.txtCustomerInvoice.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvcustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvcustomer.Rows[iRowIndex];

                try
                {
                    if (ObjDGVRow.Cells[0].Value != null)
                    {                    
                        this.EditOrDeleteMode();
                        
                        this.txtCustomerInvoice.Text = ObjDGVRow.Cells[0].Value.ToString();
                        this.txtPoint.Text = ObjDGVRow.Cells[1].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "RITPOS");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }        

        private bool CheckValidity()
        {
            if (txtCustomerBarcode.Text == "")
            {
                Alert("Enter Bar Code of the customer.");
                txtCustomerBarcode.Focus();
                return false;
            }
            else if (txtCustomerName.Text == "")
            {
                Alert("Enter the name of the customer.");
                txtCustomerName.Focus();
                return false;
            }
            else if (txtCustomerInvoice.Text == "")
            {
                Alert("Select Invoice.");
                txtCustomerInvoice.Focus();
                return false;
            }

            else if (txtPoint.Text == "")
            {
                Alert("Enter the point.");
                txtPoint.Focus();
                return false;
            }
            else if (float.Parse(txtPoint.Text.Trim()) <= 0)
            {
                Alert("Zero point is not allowd.");
                txtPoint.Focus();
                return false;
            }

            else if (float.Parse(txtPoint.Text.Trim()) >= 99999)
            {
                Alert("You should less value.");
                txtPoint.Focus();
                return false;
            }


            return true;
        }

        private void SaveData()
        {
            try
            {
                if (CheckValidity())
                {
                    CCustomerInvoice oCCustomerInvoice = new CCustomerInvoice();
                    
                    oCCustomerInvoice.CustomerBarCode = txtCustomerBarcode.Text.Trim().ToString();
                    oCCustomerInvoice.InvoiceId = int.Parse(txtCustomerInvoice.Text.Trim());
                    oCCustomerInvoice.PointsEarned = float.Parse(txtPoint.Text.Trim().ToString());
                    oCCustomerInvoice.UpdatedBy = MDIParent.userId.ToString();

                    if (btnAdd.Text == "UPDATE")
                    {
                        _CustomerInvoiceManager.updateCustomerInvoice(oCCustomerInvoice);
                        BindGrid();
                    }
                    
                    //AddMode();
                }
            }
            catch (Exception ex)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert("Customer information did not updated successfully.");
                }
                else
                {
                    Alert("Customer information did not added successfully.");
                }
            }
        }

    }
}