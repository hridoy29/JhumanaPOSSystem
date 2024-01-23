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
using POSsible.Views;
using POSsible.DAL;
using System.Linq;
using System.Data.Common;

namespace POSsible
{
    public partial class frmSupplierEntry : Form
    {
        /// <summary>
        /// Reference of ISupplierManager
        /// </summary>
        private int iRowIndex = 0;
        bool loadDone = false;
        SupplierDAO oSupplierDAO = new SupplierDAO();
        AccountLedgerDAO oAccountLedgerDAO = new AccountLedgerDAO();
        LedgerGroup lg = new LedgerGroup();

        public frmSupplierEntry()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
            AddMode();
        }

        private void AddMode()
        {
            btnAdd.Text = "ADD";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = false;
            btnExit.Enabled = true;

            txtSupplierID.Enabled = false;
            txtSupplierID.Text = "";
            txtSupplierName.Text = "";
            txtTradingAs.Text = "";
            txtABN.Text = "";
            txtAddress.Text = "";
            txtContactNumber.Text = "";
            txtContactName.Text = "";
            txtemail.Text = "";
            txtwebadd.Text = "";
            txtcomments.Text = "";
            txtSearchName.Text = "";

            if (dgvSupplier.Rows.Count > 0)
                dgvSupplier.Rows[0].Selected = false;
            if (chkNewAC.Checked)
                bindAccLedger();
            cboAccountLedger.SelectedIndex = -1;
            chkNewAC.Checked = false;
            txtSupplierName.Focus();
        }

        private void SaveData()
        {
            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                if (CheckValidity())
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    Supplier oSupplier = new Supplier();
                    oSupplier.SupplierName = txtSupplierName.Text.Trim();
                    oSupplier.TradingAs = txtTradingAs.Text.Trim();
                    oSupplier.ABN = txtABN.Text.Trim();
                    oSupplier.SupplierAddress = txtAddress.Text.Trim();
                    oSupplier.ContactName = txtContactName.Text.Trim();
                    oSupplier.PhoneNo = txtContactNumber.Text.Trim();
                    oSupplier.email = txtemail.Text.Trim();
                    oSupplier.webadd = txtwebadd.Text.Trim();
                    oSupplier.comments = txtcomments.Text.Trim();
                    oSupplier.UpdatedBy = MDIParent.userId;
                    oSupplier.EnteredBy = MDIParent.userId;

                    if (btnAdd.Text == "UPDATE")
                    {
                        oSupplier.SupplierId = int.Parse(txtSupplierID.Text);
                        oSupplier.GLCode = "1"; //acLgId.ToString();
                        oSupplierDAO.Update(oSupplier);
                        BindGrid();
                        MessageBox.Show("Supplier " + oSupplier.SupplierName + " Updated", "POSsible");
                    }
                    else if (btnAdd.Text == "ADD")
                    {
                        int iSupplierId = 0;
                        oSupplier.GLCode = "1"; //acLgId.ToString();
                        iSupplierId = oSupplierDAO.Add(oSupplier);
                        if (iSupplierId > 0)
                        {
                            BindGrid();
                            MessageBox.Show("Supplier " + oSupplier.SupplierName + " Saved", "POSsible");
                        }
                    }

                    AddMode();
                    UtilsDAO.CommitTransaction(trans);
                }
            }
            catch (Exception exc)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert("Supplier information did not updated successfully.");
                }
                else
                {
                    Alert("Supplier information did not added successfully.");
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
                //    acLedgerEntity.AccountLedgerName = txtSupplierName.Text;
                //    acLedgerEntity.LedgerGroupId = lg.LedgerGroupId;
                //    acLedgerEntity.AccTransTypeId = 3;
                //    acLedgerEntity.BudgetEnable = true;
                //    acLedgerEntity.OpeningBalanceOn = DateTime.Now;
                //    acLedgerEntity.CF1 = lstStore[i].ProjectId.ToString();// Project Id == CF1
                //    acLedgerEntity.CF2 = "N";   // Opening Balance Entry Flag == CF2
                //    acLgId = oAccountLedgerDAO.Add(acLedgerEntity);
                //}

                AccountLedger acLedgerEntity = new AccountLedger();
                acLedgerEntity.AccountLedgerNo = GetAcLedgerNo();
                acLedgerEntity.AccountLedgerName = txtSupplierName.Text.Trim();
                acLedgerEntity.LedgerGroupId = lg.LedgerGroupId;
                acLedgerEntity.AccTransTypeId = 3;
                acLedgerEntity.BudgetEnable = true;
                acLedgerEntity.OpeningBalanceOn = DateTime.Now;
                acLedgerEntity.CF1 = MDIParent.projectId.ToString();
                acLedgerEntity.CF2 = "N";
                acLgId = oAccountLedgerDAO.Add(acLedgerEntity);
            }
            catch
            {
                MessageBox.Show("Error occured in Account Ledger.", "POSsible");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private bool CheckValidity()
        {
            if (txtSupplierName.Text == "")
            {
                Alert("Enter the name of the supplier.");
                txtSupplierName.Focus();
                return false;
            }

            if (txtContactName.Text == "")
            {
                Alert("Enter the name of the contact person.");
                txtContactName.Focus();
                return false;
            }

            if (txtContactNumber.Text == "")
            {
                Alert("Enter the contact no. of the supplier.");
                txtContactNumber.Focus();
                return false;
            }


            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierID.Text == "") { Alert("Please Select a Supplier first."); return; }
            DialogResult result;
            result = MessageBox.Show("Do you want to delete this supplier?", "RITPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Supplier oSupplier = new Supplier();
                int returnval;
                int suppId = int.Parse(txtSupplierID.Text);
                returnval = oSupplierDAO.Delete(suppId);
                if (returnval > 0)
                {
                    dgvSupplier.Rows.RemoveAt(iRowIndex);
                    //BindGrid();
                    AddMode();
                }
            }
        }

        private void EditOrDeleteMode()
        {
            btnAdd.Text = "UPDATE";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;

            txtSupplierID.Enabled = false;
            txtSupplierName.Text = "";
            txtTradingAs.Text = "";
            txtABN.Text = "";
            txtAddress.Text = "";
            txtContactNumber.Text = "";
            txtContactName.Text = "";
            txtemail.Text = "";
            txtwebadd.Text = "";
            txtcomments.Text = "";
            cboAccountLedger.SelectedIndex = -1;
            chkNewAC.Checked = false;
        }

        private void ShowData(Supplier oSupplier)
        {
            if (oSupplier.GLCode != null && Convert.ToInt32(oSupplier.GLCode) > 0)
                cboAccountLedger.SelectedValue = Convert.ToInt32(oSupplier.GLCode);
            txtSupplierID.Text = oSupplier.SupplierId.ToString();
            txtSupplierName.Text = oSupplier.SupplierName;
            txtTradingAs.Text = oSupplier.TradingAs;
            txtABN.Text = oSupplier.ABN;
            txtAddress.Text = oSupplier.SupplierAddress;
            txtContactNumber.Text = oSupplier.PhoneNo;
            txtContactName.Text = oSupplier.ContactName;
            txtcomments.Text = oSupplier.comments;
            txtemail.Text = oSupplier.email;
            txtwebadd.Text = oSupplier.webadd;
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvSupplier.Rows[iRowIndex];

                try
                {
                    if (ObjDGVRow.Cells[0].Value != null)
                    {
                        EditOrDeleteMode();
                        Supplier oSupplier = oSupplierDAO.Supplier_GetById(Int32.Parse(ObjDGVRow.Cells[0].Value.ToString()));
                        ShowData(oSupplier);
                    }
                }

                catch
                {

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchName.Text.Trim()))
            {
                MessageBox.Show("Please type part of Supplier Name", "POSsible");
                txtSearchName.Focus();
                return;
            }

            List<Supplier> lSupplierList = oSupplierDAO.Supplier_GetDynamic("SupplierName LIKE '%" + txtSearchName.Text.Trim() + "%'", "SupplierName");
            if (lSupplierList.Count > 0)
            {
                dgvSupplier.Rows.Clear();
                for (int i = 0; i < lSupplierList.Count; i++)
                    dgvSupplier.Rows.Add(lSupplierList[i].SupplierId.ToString(), lSupplierList[i].SupplierName, lSupplierList[i].ContactName);
                AddMode();
            }
            else
            {
                MessageBox.Show("No Supplier found", "POSsible");
            }

        }

        private void BindGrid()
        {
            dgvSupplier.Rows.Clear();
            List<Supplier> lSupplierList = oSupplierDAO.Supplier_GetAll();

            for (int i = 0; i < lSupplierList.Count; i++)
                dgvSupplier.Rows.Add(lSupplierList[i].SupplierId.ToString(), lSupplierList[i].SupplierName, lSupplierList[i].ContactName);
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSupplierEntry_Load(object sender, EventArgs e)
        {
            //lg = new LedgerGroupDAO().LedgerGroup_GetByName("Payable Parties");
            //if (lg.LedgerGroupId < 1)
            //    Alert("Ledger Group Not Available. Supplier will not be saved.");
            if (dgvSupplier.Rows.Count > 0)
                dgvSupplier.Rows[0].Selected = false;
            BindGrid();
            bindAccLedger();
            loadDone = true;
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtContactNumber.Text);
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            if (txtSupplierName.Text != null)
            {
                Supplier sup = new Supplier();
                if (btnAdd.Text == "ADD")
                    sup = oSupplierDAO.Supplier_GetDynamic("[SupplierName]='" + txtSupplierName.Text + "'", "").FirstOrDefault();
                else
                    sup = oSupplierDAO.Supplier_GetDynamic("[SupplierName]='" + txtSupplierName.Text + "' AND SupplierId <> " + txtSupplierID.Text, "").FirstOrDefault();

                if (sup != null)
                {
                    MessageBox.Show("This Supplier already entered.", "POSsible");
                    //txtSupplierName.Clear();
                    txtSupplierName.Focus();
                    return;
                }
            }
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, "POSsible");
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
            List<AccountLedger> lst = new AccountLedgerDAO().AccountLedger_GetDynamic("AL.[LedgerGroupId]=33 AND AL.[CF1] = '" + MDIParent.projectId + "'", "AccountLedgerName");
            cboAccountLedger.DataSource = lst;
            cboAccountLedger.SelectedIndex = -1;
        }
    }
}