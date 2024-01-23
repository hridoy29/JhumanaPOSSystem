using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.DAL;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible
{
    public partial class frmStore : Form
    {
        int storeId = 0;
        int projectId = 0; //FOR EDITING PURPOSE
        LedgerGroup lg = new LedgerGroup();
        LedgerGroup lgSupplier = new LedgerGroup();

        public frmStore()
        {
            InitializeComponent();
            bindGrid();
            lg = new LedgerGroupDAO().LedgerGroup_GetByName("Receivable Parties");
            if (lg.LedgerGroupId < 1)
                MessageBox.Show("Ledger Group(Customer) Not Available.", "POSsible");

            lgSupplier = new LedgerGroupDAO().LedgerGroup_GetByName("Payable Parties");
            if (lgSupplier.LedgerGroupId < 1)
                MessageBox.Show("Ledger Group(Supplier) Not Available.", "POSsible");
        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtmobile.Text);
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtContactNumber.Text);
        }

        private bool frmValidation()
        {
            if (String.IsNullOrEmpty(txtStoreName.Text))
            {
                MessageBox.Show("Please Enter Store Name.");
                txtStoreName.Focus();
                return false;
            }

            else if (String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please Enter Store Address.");
                txtAddress.Focus();
                return false;
            }

            else if (String.IsNullOrEmpty(txtmobile.Text))
            {
                MessageBox.Show("Please Enter Store Phone No.");
                txtmobile.Focus();
                return false;
            }

            else if (String.IsNullOrEmpty(txtContactName.Text))
            {
                MessageBox.Show("Please Enter Store Contact Person's Name.");
                txtContactName.Focus();
                return false;
            }

            else if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Enter Store's Admin Password.");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (frmValidation())
            {
                DbTransaction trans = UtilsDAO.BeginTransaction();

                try
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    Store SE = new Store();

                    SE.StoreName = txtStoreName.Text;
                    SE.PhoneNo = txtmobile.Text;
                    SE.StoreAddress = txtAddress.Text;
                    SE.ContactPerson = txtContactName.Text;
                    SE.Mobile = txtContactNumber.Text;
                    SE.Email = txtemail.Text;
                    SE.CompanyId = 1;
                    SE.StoreCF1 = txtPassword.Text;
                    if (cmbCardAcLedger.SelectedIndex > -1)
                        SE.StoreCF2 = cmbCardAcLedger.SelectedValue.ToString();


                    if (btnAdd.Text == "UPDATE")
                    {
                        SE.StoreId = storeId;
                        SE.ProjectId = projectId;
                        new StoreDAO().Update(SE);
                    }
                    else
                    {
                        #region  Project Entry
                        ProjectInfo entity = new ProjectInfo();
                        entity.ProjectName = SE.StoreName;
                        entity.ProjectType = "POS Store";
                        entity.ProjectURL = " ";
                        entity.GroupName = " ";

                        entity.ContactNo = SE.PhoneNo;
                        entity.Address = SE.StoreAddress;
                        entity.EmailAdress = SE.Email;
                        entity.FaxNo = SE.Mobile; //Contact Person Mobile

                        entity.LedgerIdSeparator = String.Empty;
                        entity.Chairman = String.Empty;
                        entity.MD = String.Empty;
                        entity.Director = String.Empty;

                        entity.VoucherMode = 1;
                        entity.VoucherEntryMode = 1;
                        entity.CF1 = rb2.Checked ? "2" : "3";

                        SE.ProjectId = new ProjectInfoDAO().Add(entity);
                        #endregion

                        if (SE.ProjectId > 0)
                        {
                            storeId = new StoreDAO().Add(SE);
                            if (storeId > 0)
                                AddAccountLedger(SE.ProjectId);
                        }
                        else
                        {
                            MessageBox.Show("Project Entry error.", "POSsible");
                            return;
                        }
                    }
                    UtilsDAO.CommitTransaction(trans);
                    btnReset.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Store Could Not be Saved.", "POSsible");
                }
                finally
                {
                    if (DbProviderHelper.IsInTransaction)
                        UtilsDAO.RollbackTransaction(trans);
                }
                bindGrid();
                label7.Visible = rb2.Visible = rb3.Visible = true;
            }
        }

        private void bindGrid()
        {
            dgvStore.Rows.Clear();
            List<Store> lstStore = new StoreDAO().Store_GetAll();
            if (lstStore.Count > 0)
            {
                for (int i = 0; i < lstStore.Count; i++)
                {
                    dgvStore.Rows.Add(lstStore[i].StoreName, lstStore[i].PhoneNo, lstStore[i].ContactPerson, lstStore[i].Mobile, lstStore[i].StoreId, lstStore[i].CompanyId, lstStore[i].ProjectId);
                }
            }
        }

        private void dgvStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RI = e.RowIndex;
            int CI = e.ColumnIndex;
            if (CI == 7)
            {
                storeId = Convert.ToInt32(dgvStore.Rows[RI].Cells[4].Value);
                projectId = Convert.ToInt32(dgvStore.Rows[RI].Cells[6].Value);
                btnAdd.Text = "UPDATE";
                ShowData(storeId);
            }
        }

        private void ShowData(int storeId)
        {
            Store SE = new StoreDAO().Store_GetById(storeId);
            if (SE == null)
            {
                MessageBox.Show("Store Not Found.");
                return;
            }
            txtStoreName.Text = SE.StoreName;
            txtmobile.Text = SE.PhoneNo;
            txtAddress.Text = SE.StoreAddress;
            txtContactName.Text = SE.ContactPerson;
            txtContactNumber.Text = SE.Mobile;
            txtemail.Text = SE.Email;
            txtPassword.Text = SE.StoreCF1;
            if (!string.IsNullOrEmpty(SE.StoreCF2)) cmbCardAcLedger.SelectedValue = Convert.ToInt32(SE.StoreCF2);
            label7.Visible = rb2.Visible = rb3.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStoreName.Clear();
            txtmobile.Clear();
            txtAddress.Clear();
            txtContactName.Clear();
            txtContactNumber.Clear();
            txtemail.Clear();
            txtPassword.Clear();
            cmbCardAcLedger.SelectedIndex = -1;
            label7.Visible = rb2.Visible = rb3.Visible = true;
            btnAdd.Text = "ADD";
        }

        private int AddAccountLedger(int projectId)
        {
            try
            {
                int proId = projectId;

                #region Save Ledger Head Customer

                List<tblCustomer> lstCustomer = new CustomerDAO().Customer_GetAll();
                if (lstCustomer.Count < 1)
                {
                    return -1;
                }

                for (int i = 0; i < lstCustomer.Count; i++)
                {
                    AccountLedger acLedgerEntity = new AccountLedger();
                    acLedgerEntity.AccountLedgerNo = GetAcLedgerNo(lg.LedgerGroupId);
                    acLedgerEntity.AccountLedgerName = lstCustomer[i].Name;
                    acLedgerEntity.LedgerGroupId = lg.LedgerGroupId;
                    acLedgerEntity.AccTransTypeId = 3;
                    acLedgerEntity.BudgetEnable = true;
                    acLedgerEntity.OpeningBalanceOn = DateTime.Now;
                    acLedgerEntity.CF1 = proId.ToString();
                    acLedgerEntity.CF2 = "N";   // Opening Balance Entry Flag == CF2
                    acLedgerEntity.CF3 = lstCustomer[i].customerId.ToString();

                    new AccountLedgerDAO().Add(acLedgerEntity);
                }

                #endregion

                #region Save Ledger Head Supplier

                List<Supplier> lstSupplier = new SupplierDAO().Supplier_GetAll();
                if (lstSupplier.Count < 1)
                {
                    return -1;
                }

                for (int i = 0; i < lstSupplier.Count; i++)
                {
                    AccountLedger acLedgerEntity = new AccountLedger();
                    acLedgerEntity.AccountLedgerNo = GetAcLedgerNo(lgSupplier.LedgerGroupId);
                    acLedgerEntity.AccountLedgerName = lstSupplier[i].SupplierName;
                    acLedgerEntity.LedgerGroupId = lgSupplier.LedgerGroupId;
                    acLedgerEntity.AccTransTypeId = 3;
                    acLedgerEntity.BudgetEnable = true;
                    acLedgerEntity.OpeningBalanceOn = DateTime.Now;
                    acLedgerEntity.CF1 = proId.ToString();
                    acLedgerEntity.CF2 = "N";   // Opening Balance Entry Flag == CF2
                    acLedgerEntity.CF3 = lstSupplier[i].SupplierId.ToString();

                    new AccountLedgerDAO().Add(acLedgerEntity);
                }

                #endregion

                #region Common Ledger Accounts
                AccountLedger ALC = new AccountLedger();
                ALC.AccountLedgerName = "General Customer";
                ALC.AccountLedgerNo = GetAcLedgerNo(25); //ledger Group Id
                ALC.LedgerGroupId = 25;
                ALC.AccTransTypeId = 3;
                ALC.BudgetEnable = true;
                ALC.CF1 = proId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;

                new AccountLedgerDAO().Add(ALC);

                ALC = new AccountLedger();
                ALC.AccountLedgerName = "Sales Return";
                ALC.AccountLedgerNo = GetAcLedgerNo(37);
                ALC.LedgerGroupId = 37; //ledger Group Id
                ALC.AccTransTypeId = 3;
                ALC.BudgetEnable = true;
                ALC.CF1 = proId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;

                new AccountLedgerDAO().Add(ALC);

                ALC = new AccountLedger();
                ALC.AccountLedgerName = "Cash In Hand";
                ALC.AccountLedgerNo = GetAcLedgerNo(22);
                ALC.AccTransTypeId = 3;
                ALC.LedgerGroupId = 22;
                ALC.BudgetEnable = true;
                ALC.CF1 = proId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;

                new AccountLedgerDAO().Add(ALC);

                ALC = new AccountLedger();
                ALC.AccountLedgerName = "Purchase";
                ALC.LedgerGroupId = 26;
                ALC.AccountLedgerNo = GetAcLedgerNo(26);
                ALC.AccTransTypeId = 3;
                ALC.BudgetEnable = true;
                ALC.CF1 = proId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;

                new AccountLedgerDAO().Add(ALC);

                ALC = new AccountLedger();
                ALC.AccountLedgerName = "Purchase Return";
                ALC.LedgerGroupId = 26;
                ALC.AccountLedgerNo = GetAcLedgerNo(26);
                ALC.AccTransTypeId = 3;
                ALC.BudgetEnable = true;
                ALC.CF1 = proId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;

                new AccountLedgerDAO().Add(ALC);

                ALC = new AccountLedger();
                ALC.AccountLedgerName = "Sales";
                ALC.LedgerGroupId = 37;
                ALC.AccountLedgerNo = GetAcLedgerNo(37);
                ALC.AccTransTypeId = 3;
                ALC.BudgetEnable = true;
                ALC.CF1 = proId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;

                new AccountLedgerDAO().Add(ALC);

                #endregion
            }
            catch
            {
                MessageBox.Show("Error occured in Account Ledger.", "POSsible");
                return -1;
            }

            return 0;
        }

        private Int64 GetAcLedgerNo(int val)
        {
            string where = "";
            where = " AL.LedgerGroupId = '" + val + "' ";
            string sort = string.Empty;

            List<AccountLedger> lst = new AccountLedgerDAO().AccountLedger_GetDynamic(where, sort);
            Int64 accCode = 0;
            if (lst.Count > 0)
            {
                lst = lst.OrderByDescending(x => x.AccountLedgerNo).ToList();
                AccountLedger alEntity = lst.FirstOrDefault();
                accCode = alEntity.AccountLedgerNo + 1000;
            }
            else
            {
                LedgerGroup lgEntity = new LedgerGroupDAO().LedgerGroup_GetById(val);
                accCode = lgEntity.LedgerGroupNo + 101000;
            }
            return accCode;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmStore_Load(object sender, EventArgs e)
        {
            List<AccountLedger> lst =
                new AccountLedgerDAO().AccountLedger_GetDynamic("LG.[LedgerGroupName]='Cash and Bank Balance' AND AL.[AccountLedgerName]<>'Cash In Hand' AND AL.[CF1]='" + MDIParent.projectId + "'", "AL.[AccountLedgerName]");
            cmbCardAcLedger.DataSource = lst;
            cmbCardAcLedger.SelectedIndex = -1;
        }
    }
}
