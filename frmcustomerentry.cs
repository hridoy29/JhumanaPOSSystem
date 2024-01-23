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
using POSsible.DAL;
using System.Linq;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace POSsible
{
    public partial class frmcustomerentry : Form, ICustomerView
    {
        private ICustomerManager _CustomerManager;
        private int iRowIndex = 0;
        bool loadDone = false;
        public CUser oUserLogin = new CUser();
        CustomerDAO oCustomerDAO = new CustomerDAO();
        AccountLedgerDAO oAccountLedgerDAO = new AccountLedgerDAO();
        EmployeeDAO oEmployeeDAO = new EmployeeDAO();
        LedgerGroup lg = new LedgerGroup();
        public static bool FromSaleForm = false;
        public static int CusId = 0;

        public frmcustomerentry()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtShortCode.Text != null)
            {
                string qry = "SELECT ShortName FROM v_Customer WHERE ShortName = '" + txtShortCode.Text + "' ";
                if (btnAdd.Text == "UPDATE")
                    qry += " AND [customerId]<>" + txtCustomerID.Text;
                string ShortCode = new TransactionDAO().ExecuteScalarString(qry);
                if (ShortCode != null)
                {
                    MessageBox.Show("Customer Name Should be Changed as Short Name " + txtShortCode.Text + " is not Available.", "POSsible");
                    txtCustomerName.Focus();
                    return;
                }
            }

            if (txtCustomerName.Text == "")
            {
                Alert("Enter the name of the customer.");
                txtCustomerName.Focus();
                return;
            }

            if (txtmobile.Text == "")
            {
                Alert("Please enter your Mobile No.");
                txtmobile.Focus();
                return;
            }
            if (cmbCustomerType.SelectedIndex == -1)
            {
                Alert("Please select Customer Type");
                return;
            }
            if (cmbReference.SelectedIndex == -1)
            {
                Alert("Please select Salesman");
                return;
            }
            if (cmbCustomerType.SelectedItem.ToString() == "Special")
            {
                if (txtAddressLine1.Text == "")
                {
                    Alert("Please enter Address");
                    txtAddressLine1.Focus();
                    return;
                }

                if (txtcountry.Text == "")
                {
                    Alert("Please enter County");
                    txtcountry.Focus();
                    return;
                }
                //if (txtCreditLimit.Text == "")
                //{
                //    Alert("Please enter Credit limit");
                //    txtCreditLimit.Focus();
                //    return;
                //}
                if (cmbDSaleType.SelectedIndex == -1)
                {
                    Alert("Please select Default Sale Type");
                    return;
                }
                if (cmbDefaulerType.SelectedIndex == -1)
                {
                    Alert("Please select Defaulter type");
                    return;
                }
                if (txtDays.Text == "" && cmbDefaulerType.SelectedItem == "Days")
                {
                    Alert("Please enter days");
                    txtDays.Focus();
                    return;
                }

                if (!optfemale.Checked && !optmale.Checked)
                {
                    Alert("Please select gender");
                    return;
                }
            }

            SaveData();
        }

        private void SaveData()
        {
            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                tblCustomer oCustomer = new tblCustomer();
                oCustomer.street_no = txtCode.Text.Trim(); //CUS CODE
                oCustomer.Name = txtCustomerName.Text.Trim();
                oCustomer.mobile = txtmobile.Text.Trim();
                oCustomer.country = "General";
                oCustomer.workphone = cmbCustomerType.SelectedItem.ToString(); //Cus Type
                oCustomer.postcode = cmbReference.SelectedValue.ToString(); //REFERENCE ID
                oCustomer.city = txtAddressLine1.Text.Trim() + "~" + txtAddressLine2.Text.Trim() + "~" + txtAddressLine3.Text.Trim() + "~" + txtcountry.Text.Trim();
                oCustomer.suburb = txtLicenceNo.Text.Trim(); //LICENCE NO

                //Special ONLY
                if (cmbCustomerType.SelectedItem == "Special")
                {
                    oCustomer.country = cmbDSaleType.Text;
                    oCustomer.homephone = (cmbDefaulerType.SelectedItem.ToString() == "Bill to bill") ? "0" : txtDays.Text.Trim();//Defaulter in DAYS
                    oCustomer.state = cmbDefaulerType.SelectedItem.ToString(); //Defaulter Type
                }

                oCustomer.sex = !optmale.Checked;
                oCustomer.enteredtime = DateTime.Now;
                oCustomer.updatedtime = DateTime.Now;

                if (!string.IsNullOrEmpty(txtPhoneNo.Text.Trim()))
                    oCustomer.enteredby = Convert.ToInt64(txtPhoneNo.Text); //Phone
                if (!string.IsNullOrEmpty(txtFaxNo.Text.Trim()))
                    oCustomer.updatedby = Convert.ToInt64(txtFaxNo.Text); //Fax

                int iCustomerId = 0;

                if (btnAdd.Text == "UPDATE")
                {
                    oCustomer.customerId = int.Parse(txtCustomerID.Text);
                    int result = oCustomerDAO.Update(oCustomer);
                    if (result > 0)
                    {
                        BindGrid(oCustomer.customerId);
                        MessageBox.Show("Customer " + oCustomer.Name + " Updated", "POSsible");
                    }
                }
                else if (btnAdd.Text == "ADD")
                {
                    iCustomerId = oCustomerDAO.Add(oCustomer);
                    if (iCustomerId > 0)
                    {
                        BindGrid(iCustomerId);
                        MessageBox.Show("Customer " + oCustomer.Name + " Saved", "POSsible");
                    }
                }

                UtilsDAO.CommitTransaction(trans);
                if (FromSaleForm)
                {
                    CusId = iCustomerId;
                    FromSaleForm = false;
                    this.Close();
                }
                AddMode();
            }
            catch (Exception ex)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert(ex.Message + "\nCustomer information could not update");
                }
                else
                {
                    Alert(ex.Message + "\nCustomer information could not save");
                }
            }
            finally
            {
                if (DbProviderHelper.IsInTransaction)
                    UtilsDAO.RollbackTransaction(trans);
            }
        }

        private int AddAccountLedger()
        {
            int acLgId = 0;
            try
            {
                List<Store> lstStore = new StoreDAO().Store_GetAll();
                if (lstStore.Count < 1)
                {
                    MessageBox.Show("No Store Found.", "POSsible");
                    return -1;
                }

                //for (int i = 0; i < lstStore.Count; i++)
                //{
                //    AccountLedger acLedgerEntity = new AccountLedger();
                //    acLedgerEntity.AccountLedgerNo = GetAcLedgerNo();
                //    acLedgerEntity.AccountLedgerName = txtCustomerName.Text;
                //    acLedgerEntity.LedgerGroupId = lg.LedgerGroupId;
                //    acLedgerEntity.AccTransTypeId = 3;
                //    acLedgerEntity.BudgetEnable = true;
                //    acLedgerEntity.OpeningBalanceOn = DateTime.Now;
                //    acLedgerEntity.CF1 = lstStore[i].ProjectId.ToString();
                //    acLedgerEntity.CF2 = "N";   // Opening Balance Entry Flag == CF2
                //    acLedgerEntity.CF3 = iCustomerId.ToString();
                //    oAccountLedgerDAO.Add(acLedgerEntity);
                //}

                AccountLedger acLedgerEntity = new AccountLedger();
                acLedgerEntity.AccountLedgerNo = GetAcLedgerNo();
                acLedgerEntity.AccountLedgerName = txtCustomerName.Text;
                acLedgerEntity.LedgerGroupId = lg.LedgerGroupId;
                acLedgerEntity.AccTransTypeId = 3;
                acLedgerEntity.BudgetEnable = true;
                acLedgerEntity.OpeningBalanceOn = DateTime.Now;
                acLedgerEntity.CF1 = MDIParent.projectId.ToString();
                acLedgerEntity.CF2 = "N";   // Opening Balance Entry Flag == CF2
                acLgId = oAccountLedgerDAO.Add(acLedgerEntity);

            }
            catch
            {
                Alert("Error occured in Account Ledger.");
                return -1;
            }
            return acLgId;
        }

        private Int64 GetAcLedgerNo()
        {
            string where = " AL.LedgerGroupId = '" + lg.LedgerGroupId + "' ";
            string sort = string.Empty;
            List<AccountLedger> lst = oAccountLedgerDAO.AccountLedger_GetDynamic(where, sort);
            Int64 accCode = 0;
            if (lst.Count > 0)
            {
                lst = lst.OrderByDescending(x => x.AccountLedgerNo).ToList();
                AccountLedger alEntity = lst.FirstOrDefault();
                accCode = alEntity.AccountLedgerNo + 1000;
            }
            else
            {
                LedgerGroup lgEntity = new LedgerGroupDAO().LedgerGroup_GetById(lg.LedgerGroupId);
                accCode = lgEntity.LedgerGroupNo + 101000;
            }
            return accCode;
        }

        private bool CheckValidity()
        {

            if (txtCustomerName.Text == "")
            {
                Alert("Enter the name of the customer.");
                txtCustomerName.Focus();
                return false;
            }

            else if (txtCode.Text == "")
            {
                Alert("Please enter your Civil Id");
                txtCode.Focus();
                return false;
            }
            else if (txtmobile.Text == "")
            {
                Alert("Please enter your Mobile No.");
                txtmobile.Focus();
                return false;
            }
            else if (cmbCustomerType.SelectedIndex == -1)
            {
                Alert("Please select Customer Type");
                return false;
            }
            else if (cmbCustomerType.SelectedItem.ToString() == "Special")
            {
                if (txtAddressLine1.Text == "")
                {
                    Alert("Please enter Address");
                    txtAddressLine1.Focus();
                    return false;
                }

                else if (txtcountry.Text == "")
                {
                    Alert("Please enter County");
                    txtcountry.Focus();
                    return false;
                }
                //else if (txtCreditLimit.Text == "")
                //{
                //    Alert("Please enter Credit limit");
                //    txtCreditLimit.Focus();
                //    return false;
                //}
                else if (cmbDefaulerType.SelectedIndex == -1)
                {
                    Alert("Please select Defaulter type");
                    return false;
                }
                else if (txtDays.Text == "" && cmbDefaulerType.SelectedItem == "Days")
                {
                    Alert("Please enter days");
                    txtDays.Focus();
                    return false;
                }

                else if (cmbReference.SelectedIndex == -1)
                {
                    Alert("Please select Salesman");
                    return false;
                }

                else if (!optfemale.Checked && !optmale.Checked)
                {
                    Alert("Please select gender");
                    return false;
                }

                if (lg.LedgerGroupId < 1)
                {
                    Alert("Ledger Group Not Available. Cannot save User.");
                    return false;
                }
            }
            return true;
        }

        private void resetAll()
        {
            btnAdd.Text = "ADD";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = false;
            btnExit.Enabled = true;

            txtCustomerID.Enabled = false;
            txtCustomerID.Text = txtCustomerName.Text = txtmobile.Text = txtPhoneNo.Text = txtFaxNo.Text = string.Empty;
            txtAddressLine1.Text = txtAddressLine2.Text = txtAddressLine3.Text = txtCode.Text = txtLicenceNo.Text = string.Empty;
            cmbCustomerType.SelectedIndex = 0;
            GeneralCustomer();
            cmbSearchFilter.SelectedIndex = 0;
            //cmbReference.SelectedIndex = 0;
            txtCreditLimit.Text = "";
            cmbDSaleType.SelectedIndex = 0;
            cmbDefaulerType.SelectedIndex = 0;
            txtcountry.Text = "";
            txtDays.Text = "";
            optmale.Checked = true;

            if (dgvcustomer.Rows.Count > 0)
                dgvcustomer.Rows[0].Selected = false;
            cboAccountLedger.SelectedIndex = -1;
            chkNewAC.Checked = false;
            txtCustomerName.Focus();
            txtDays.Visible = false;
        }

        private void AddMode()
        {
            resetAll();
        }

        private void BindGrid()
        {
            dgvcustomer.Rows.Clear();
            List<tblCustomer> lCustomerList = oCustomerDAO.Customer_GetAll();
            lCustomerList = lCustomerList.OrderBy(c => c.Name).ToList();
            for (int i = 0; i < lCustomerList.Count; i++)
                dgvcustomer.Rows.Add(lCustomerList[i].customerId.ToString(), lCustomerList[i].Name, lCustomerList[i].mobile, lCustomerList[i].street_no);
        }

        private void BindGrid(int customerId)
        {
            dgvcustomer.Rows.Clear();

            tblCustomer customerEntity = oCustomerDAO.Customer_GetById(customerId);

            dgvcustomer.Rows.Add(customerEntity.customerId.ToString(), customerEntity.Name, customerEntity.mobile, customerEntity.street_no);
        }

        private void BindGrid(string customerName)
        {
            dgvcustomer.Rows.Clear();
            if (cmbSearchFilter.SelectedItem.ToString() == "Name")
            {
                List<tblCustomer> customerList = oCustomerDAO.Customer_GetDynamic("[Name] LIKE '%" + customerName + "%'", "Name");
                if (customerList != null)
                    foreach (tblCustomer item in customerList)
                    {
                        dgvcustomer.Rows.Add(item.customerId.ToString(), item.Name, item.mobile, item.street_no);
                    }

            }
            else
            {
                List<tblCustomer> customerListCivil = oCustomerDAO.Customer_GetDynamic("[mobile] LIKE '%" + customerName + "%'", "Name");
                if (customerListCivil != null)
                    foreach (tblCustomer item in customerListCivil)
                    {
                        dgvcustomer.Rows.Add(item.customerId.ToString(), item.Name, item.mobile, item.street_no);
                    }

            }

        }

        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "POSsible");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to delete this customer?", "RITPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                loadDone = false;
                Customer oCustomer = new Customer();
                int returnval;
                oCustomer.CustomerId = int.Parse(txtCustomerID.Text);
                returnval = oCustomerDAO.Delete(oCustomer.CustomerId);
                if (returnval > 0)
                {
                    dgvcustomer.Rows.RemoveAt(iRowIndex);
                    BindGrid();
                    AddMode();
                }
                loadDone = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadDone = false;
            BindGrid();
            AddMode();
            loadDone = true;
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
                        EditOrDeleteMode();
                        tblCustomer oCustomer = oCustomerDAO.Customer_GetById(Int32.Parse(ObjDGVRow.Cells[0].Value.ToString()));
                        ShowData(oCustomer);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "POSsible");
                }
            }
        }

        private void ShowData(tblCustomer oCustomer)
        {
            //if (oCustomer.enteredby > -1)
            //    cboAccountLedger.SelectedValue = oCustomer.enteredby;
            txtCustomerID.Text = oCustomer.customerId.ToString();
            txtCustomerName.Text = isnull(oCustomer.Name.ToString());
            txtmobile.Text = isnull(oCustomer.mobile.ToString());
            if (oCustomer.enteredby != null)
                txtPhoneNo.Text = oCustomer.enteredby.ToString();
            if (oCustomer.updatedby != null)
                txtFaxNo.Text = oCustomer.updatedby.ToString();

            string[] addrss = Regex.Split(oCustomer.city, "~");
            txtAddressLine1.Text = addrss[0];
            txtAddressLine2.Text = addrss[1];
            txtAddressLine3.Text = addrss[2];
            txtcountry.Text = addrss[3];

            txtCode.Text = oCustomer.street_no;
            txtLicenceNo.Text = oCustomer.suburb;

            cmbCustomerType.SelectedItem = oCustomer.workphone.ToString();
            if (!string.IsNullOrEmpty(oCustomer.postcode) && Convert.ToInt32(oCustomer.postcode) > 0)
                cmbReference.SelectedValue = Convert.ToInt32(oCustomer.postcode);
            else
                cmbReference.SelectedIndex = -1;
            if (cmbCustomerType.SelectedItem == "Special")
            {

                cmbDSaleType.SelectedIndex = -1;
                cmbDSaleType.SelectedText = oCustomer.country;
                txtCreditLimit.Text = "999999999";
                cmbDefaulerType.SelectedItem = oCustomer.state.ToString();
                txtDays.Text = oCustomer.homephone.ToString();
                if (cmbDefaulerType.SelectedIndex == 0)
                    txtDays.Visible = true;
                if (Convert.ToInt16(oCustomer.sex) == 0)
                    optmale.Checked = true;
                else
                    optfemale.Checked = true;
            }
        }

        private string isnull(string Value)
        {
            if (Value == null)
                return "";
            else
                return Value;
        }

        private void EditOrDeleteMode()
        {
            btnAdd.Text = "UPDATE";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;

            txtCustomerID.Enabled = false;
            txtCustomerID.Clear();
            txtCode.Clear();
            txtCustomerName.Clear();
            txtmobile.Clear();
            //cmbCustomerType.SelectedIndex = -1;
            //    if (cmbCustomerType.SelectedItem == "Special")
            //   {
            txtCreditLimit.Clear();
            cmbDSaleType.SelectedIndex = 0;
            // cmbDefaulerType.SelectedIndex = -1;
            txtcountry.Clear();
            txtDays.Clear();
            cmbReference.SelectedIndex = -1;
            cboAccountLedger.SelectedIndex = -1;
            chkNewAC.Checked = false;
            //  }
        }

        private void frmcustomerentry_Load(object sender, EventArgs e)
        {
            if (dgvcustomer.Rows.Count > 0)
                dgvcustomer.Rows[0].Selected = false;
            BindGrid();
            cmbDSaleType.SelectedIndex = 0;
            cmbSearchFilter.SelectedIndex = 0;
            cmbReferenceBind();
            loadDone = true;

            if (FromSaleForm)
            {
                btnReset.Enabled = btnDelete.Enabled = dgvcustomer.Enabled = false;
            }
        }

        private void cmbReferenceBind()
        {
            List<Employee> lst = oEmployeeDAO.Employee_GetAll().Where(r => r.IsActive == true).ToList();
            cmbReference.DataSource = lst;
            cmbReference.DisplayMember = "EmployeeName";
            cmbReference.ValueMember = "EmployeeId";
            cmbReference.SelectedIndex = -1;
        }

        private void btnCustomerInvoice_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim().Length != 0)
            {
                frmCustomerInvoice objfrmCustomerInvoice = new frmCustomerInvoice(this, oUserLogin);
                objfrmCustomerInvoice.ShowDialog();
            }
            else
                Alert("Please Select a Customer from List");
        }

        private void SpecialCustomer()
        {
            //LABELS
            label2.Visible = true;
            label3.Visible = true;
            //lblCrLimit.Visible = true;
            label8.Visible = true;
            //lblRef.Visible = true;
            label12.Visible = true;
            label5.Visible = true;
            //FIELDS
            txtAddressLine1.Visible = true;
            txtcountry.Visible = true;
            //txtCreditLimit.Visible = true;
            cmbDefaulerType.Visible = true;
            //cmbReference.Visible = true;
            optmale.Visible = true;
            optfemale.Visible = true;
            cmbDSaleType.Visible = true;
            cmbDSaleType.Focus();
        }

        private void GeneralCustomer()
        {
            //LABELS
            label2.Visible = true;
            label3.Visible = false;
            lblCrLimit.Visible = false;
            label8.Visible = false;
            //lblRef.Visible = false;
            label12.Visible = false;
            label5.Visible = false;

            //FIELDS
            txtAddressLine1.Visible = true;
            txtcountry.Visible = false;
            txtCreditLimit.Visible = false;
            cmbDefaulerType.Visible = false;
            //cmbReference.Visible = false;
            optmale.Visible = false;
            optfemale.Visible = false;
            txtDays.Visible = false;
            cmbDSaleType.Visible = false;
            btnAdd.Focus();
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadDone)
            {
                if (cmbCustomerType.SelectedItem.ToString() == "Special")
                    SpecialCustomer();
                else
                    GeneralCustomer();
            }
        }

        private void cmbDefaulerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDefaulerType.SelectedItem.ToString() != null && cmbDefaulerType.SelectedItem.ToString() == "Days")
                txtDays.Visible = true;
            else
                txtDays.Visible = false;
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchFilter.SelectedIndex > -1)
            {
                BindGrid(txtSearchName.Text.Trim());
                //AddMode();
            }
        }

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtCreditLimit.Text);
        }

        //private void txtCivilId_Leave(object sender, EventArgs e)
        //{
        //    if (txtCivilId.Text != null)
        //    {
        //        tblCustomer C = oCustomerDAO.Customer_GetDynamic("[street_no]='" + txtCivilId.Text + "'", "").FirstOrDefault();
        //        if (C != null)
        //        {
        //            MessageBox.Show("The CivilID is already used.", "POSsible");
        //            txtCivilId.Clear();
        //            txtCivilId.Focus();
        //            return;
        //        }
        //    }
        //}

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                txtShortCode.Text = "";
                return;
            }

            string[] CN = Regex.Split(txtCustomerName.Text, " ");
            string SC = "";

            for (int i = 0; i < CN.Length; i++)
            {
                if (CN[i].Length > 0)
                    SC += CN[i][0];
            }

            txtShortCode.Text = SC.ToUpper();
        }

        private void cboAccountLedger_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loadDone && cboAccountLedger.SelectedIndex > -1)
            {
                chkNewAC.Checked = false;
            }
        }

        private void chkNewAC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewAC.Checked) cboAccountLedger.SelectedIndex = -1;
        }

        private void bindAccLedger()
        {
            List<AccountLedger> lst = new AccountLedgerDAO().AccountLedger_GetDynamic("AL.[LedgerGroupId]=25 AND AL.[CF1] = '" + MDIParent.projectId + "'", "AccountLedgerName");
            cboAccountLedger.DataSource = lst;
            cboAccountLedger.SelectedIndex = -1;
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.ControlBox = false;
            frmEmployee.FromCustomerEntry = true;
            frm.ShowDialog();

            if (frmEmployee.EmployeeID > 0)
            {
                cmbReferenceBind();
                cmbReference.SelectedValue = frmEmployee.EmployeeID;
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != null)
            {
                tblCustomer cus = new tblCustomer();
                if (btnAdd.Text == "ADD")
                    cus = new CustomerDAO().Customer_GetDynamic("[Name]='" + txtCustomerName.Text + "'", "").FirstOrDefault();
                else
                    cus = new CustomerDAO().Customer_GetDynamic("[Name]='" + txtCustomerName.Text + "' AND customerId <> " + txtCustomerID.Text, "").FirstOrDefault();
                if (cus != null)
                {
                    MessageBox.Show("This Customer is already entered.", "POSsible");
                    //txtCustomerName.Clear();
                    txtCustomerName.Focus();
                    return;
                }
            }
        }
    }
}