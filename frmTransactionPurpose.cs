using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmTransactionPurpose : Form
    {
        #region VARIABLES
        TransactionPurposeDAO oTransactionPurposeDAO = new TransactionPurposeDAO();
        private String SaveMode = "";
        private bool ValueExists = false;
        private bool FLD = false;
        public static bool FromDailyTrans = false;
        public static int TrnsPurposeId = 0;
        public static int TransType = 0;
        #endregion

        public frmTransactionPurpose()
        {
            InitializeComponent();
        }

        private void frmExpenseType_Load(object sender, EventArgs e)
        {
            SaveMode = "NEW";
            btnSave.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            btnDelete.Enabled = false;
            txtTrPurposeName.Focus();
            LoadData();
            FLD = true;

            if (FromDailyTrans)
            {
                if (TransType == 1)
                    rbDeposit.Checked = true;
                else
                    rbWithdraw.Checked = true;
                chkActive.Enabled = false;
                btnSave.Enabled = btnClose.Enabled = true;
                btnDelete.Enabled = btnClear.Enabled = rbDeposit.Enabled = rbWithdraw.Enabled = dgv.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTrPurposeName.Text.Trim().ToLower() == "expense" || txtTrPurposeName.Text.Trim().ToLower() == "collection" || txtTrPurposeName.Text.Trim().ToLower() == "balance" || txtTrPurposeName.Text.Trim().ToLower() == "cash")
            {
                MessageBox.Show(txtTrPurposeName.Text + " is not allowed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTrPurposeName.Focus();
                return;
            }

            if (dgv.SelectedRows.Count > 0 && Convert.ToInt32(dgv.SelectedRows[0].Cells["TransactionPurposeId"].Value)==1)
            {
                MessageBox.Show("This Expense Purpose cannot be updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Helper.ValidateNotEmpty(new List<Control>() { txtTrPurposeName }))
            {
                CheckValuesExist();
                if (ValueExists)
                {
                    ValueExists = false;
                    return;
                }

                TransactionPurpose tp = new TransactionPurpose(0, txtTrPurposeName.Text.Trim().Replace(" ", string.Empty),
                    (rbDeposit.Checked ? "Deposit" : "Withdraw"), chkPurExp.Checked, chkActive.Checked, MDIParent.userId, DateTime.Now);
                int id = 0;

                if (SaveMode == "NEW")
                {
                    id = oTransactionPurposeDAO.Add(tp);
                    if (id > 0)
                    {
                        MessageBox.Show("Expense Purpose Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (FromDailyTrans)
                        {
                            TrnsPurposeId = id;
                            FromDailyTrans = false;
                            this.Close();
                        }
                    }
                }
                else
                {
                    tp.TransactionPurposeId = Convert.ToInt32(dgv.SelectedRows[0].Cells["TransactionPurposeId"].Value);
                    id = oTransactionPurposeDAO.Update(tp);
                    if (id > 0)
                        MessageBox.Show("Expense Purpose Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgv.DataSource = new DataTable();
                LoadData();
                btnClear.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure to delete this Expense Purpose?", "Delete Expense Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                int trnPurposeId = Convert.ToInt32(dgv.SelectedRows[0].Cells["TransactionPurposeId"].Value);
                try
                {
                    int del = oTransactionPurposeDAO.Delete(trnPurposeId);
                    if (del > 0)
                    {
                        MessageBox.Show("Expense Purpose Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveMode = "NEW";
                        dgv.DataSource = new DataTable();
                        LoadData();
                        btnClear.PerformClick();
                    }
                    else
                        MessageBox.Show("This Expense Purpose is already in use.\nCan't Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("This Expense Purpose is already in use.\nCan't Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SaveMode = "NEW";
            TrnsPurposeId = 0;
            txtTrPurposeName.Clear();
            chkActive.Checked = true;
            btnSave.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            btnDelete.Enabled = chkPurExp.Checked = false;
            txtTrPurposeName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvExpense_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!FromDailyTrans && dgv.SelectedRows.Count > 0 && FLD)
            {
                string trPurName = dgv.SelectedRows[0].Cells["TransactionPurposeName"].Value.ToString().ToLower();
                if (trPurName == "mobile")
                {
                    txtTrPurposeName.Clear();
                    chkPurExp.Checked = false;
                    chkActive.Checked = true;
                    btnClear.Enabled = btnClose.Enabled = true;
                    btnSave.Enabled = btnDelete.Enabled = false;
                    return;
                }

                if (dgv.SelectedRows[0].Cells["TransactionPurposeName"].Value != null)
                    txtTrPurposeName.Text = dgv.SelectedRows[0].Cells["TransactionPurposeName"].Value.ToString();
                else
                    txtTrPurposeName.Text = String.Empty;
                if (dgv.SelectedRows[0].Cells["TransactionType"].Value.ToString() == "Deposit")
                    rbDeposit.Checked = true;
                else
                    rbWithdraw.Checked = true;
                if (dgv.SelectedRows[0].Cells["IsAuto"].Value != null)
                    chkPurExp.Checked = Convert.ToBoolean(dgv.SelectedRows[0].Cells["IsAuto"].Value);
                else
                    chkActive.Checked = false;

                if (dgv.SelectedRows[0].Cells["IsActive"].Value != null)
                    chkActive.Checked = Convert.ToBoolean(dgv.SelectedRows[0].Cells["IsActive"].Value);
                else
                    chkActive.Checked = false;
                SaveMode = "EDIT";
                btnSave.Enabled = btnDelete.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            }
        }

        private void txtExpenseType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtTrPurposeName.Text))
            {
                btnSave.Focus();
                return;
            }

            if (e.KeyChar == '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar.Equals((char)Keys.Back) || e.KeyChar.Equals((char)Keys.Tab) || e.KeyChar.Equals((char)Keys.Delete))
            {
                e.Handled = false;
                return;
            }

            if (!Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (btnSave.Enabled) btnSave.PerformClick();
                return true;
            }

            else if (keyData == (Keys.Control | Keys.D))
            {
                if (btnDelete.Enabled) btnDelete.PerformClick();
                return true;
            }

            else if (keyData == (Keys.Control | Keys.C))
            {
                if (btnClear.Enabled) btnClear.PerformClick();
                return true;
            }

            else if (keyData == (Keys.Control | Keys.O))
            {
                if (btnClose.Enabled) btnClose.PerformClick();
                return true;
            }

            else if (keyData == Keys.Escape)
            {
                FromDailyTrans = false;
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv.ClearSelection();
        }

        private void CheckValuesExist()
        {
            string where = "[TransactionPurposeName]='" + txtTrPurposeName.Text.Trim() + "'";
            if (SaveMode != "NEW")
                where += " AND [TransactionPurposeId]<>" + dgv.SelectedRows[0].Cells["TransactionPurposeId"].Value;

            List<TransactionPurpose> lst = oTransactionPurposeDAO.TransactionPurpose_GetDynamic(where, string.Empty);
            if (lst.Count > 0)
            {
                MessageBox.Show("Transaction Purpose already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTrPurposeName.Focus();
                ValueExists = true;
            }
        }

        private void LoadData()
        {
            List<TransactionPurpose> lst = oTransactionPurposeDAO.TransactionPurpose_GetAll();
            if (lst.Count > 0)
            {
                lst = lst.Where(p => (p.TransactionPurposeName.ToLower() != "from cash to bank" & p.TransactionPurposeName.ToLower() != "from bank to cash" & p.TransactionPurposeName.ToLower() != "cash opening balance")).ToList();
                dgv.DataSource = lst;
                dgv.Columns["TransactionPurposeId"].Visible = dgv.Columns["IsAuto"].Visible = dgv.Columns["IsActive"].Visible = dgv.Columns["CreatorId"].Visible = dgv.Columns["CreateDate"].Visible = dgv.Columns["TransactionType"].Visible = false;
                dgv.Columns["TransactionPurposeName"].HeaderText = "Expense Purpose Name";
                //dgv.Columns["TransactionType"].HeaderText = " Tr Type";
                dgv.Columns["IsActiveString"].HeaderText = "Active?";
                dgv.Columns["SL"].HeaderText = "S/N";
                //dgv.Columns["TransactionType"].Width = 70;
                dgv.Columns["IsActiveString"].Width = 58;
                dgv.Columns["SL"].Width = 40;
                dgv.Columns["TransactionType"].DefaultCellStyle.Alignment = dgv.Columns["IsActiveString"].DefaultCellStyle.Alignment = dgv.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["TransactionPurposeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["SL"].DisplayIndex = 0;
                int loop = 1;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells["SL"].Value = loop; loop += 1;
                }
            }
        }

        private void txtTrPurposeName_Leave(object sender, EventArgs e)
        {
            if (txtTrPurposeName.Text.Trim().ToLower() == "expense" || txtTrPurposeName.Text.Trim().ToLower() == "collection" || txtTrPurposeName.Text.Trim().ToLower() == "balance" || txtTrPurposeName.Text.Trim().ToLower() == "cash")
            {
                MessageBox.Show(txtTrPurposeName.Text + " not allowed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTrPurposeName.Focus();
            }
        }
    }
}
