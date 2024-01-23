using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Text.RegularExpressions;
using POSsible.BusinessObjects;
using POSsible.DAL;


namespace POSsible
{
    public partial class frmDailyTransaction : Form
    {
        #region VARIABLES
        DailyTransactionDAO oDailyTransactionDAO = new DailyTransactionDAO();
        private bool FLD = false;
        #endregion

        #region METHODS
        public void LoadTransactionPurpose(string type)
        {
            List<TransactionPurpose> lst = new TransactionPurposeDAO().TransactionPurpose_GetAll();
            lst = lst.Where(p => p.TransactionType == type).ToList();
            cmbTrPurpose.DataSource = lst;
            cmbTrPurpose.SelectedIndex = -1;
        }

        private void BindSalesman()
        {
            List<Employee> lst = new EmployeeDAO().Employee_GetAll().Where(r => r.IsActive == true).ToList();
            cmbSalesman.DataSource = lst;
            cmbSalesman.DisplayMember = "EmployeeName";
            cmbSalesman.ValueMember = "EmployeeId";
        }

        private void ClearControls()
        {
            btnSave.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            btnVoid.Enabled = false;
            txtTransNarration.Clear();
            txtVoidReason.Clear();
            lblVoidReason.Visible = txtVoidReason.Visible = false;
            cmbTransType.SelectedIndex = 0;
            txtSearchTotal.Text = "0";
            cmbTransType_SelectedValueChanged(null, null);
            cmbTrPurpose.Select();
        }
        #endregion

        #region EVENTS
        public frmDailyTransaction()
        {
            InitializeComponent();
        }

        private void FrmDailyTransaction_Load(object sender, EventArgs e)
        {
            //this.cmbTrPurpose.KeyPress += new KeyPressEventHandler(this.cmbTrPurpose_KeyPress);
            btnSave.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            btnVoid.Enabled = false;
            FLD = true;
            cmbTransType.SelectedIndex = 0;
            cmbTrTypeSearch.SelectedIndex = 0;
            dtTransDate.MinDate = MDIParent.StoreOpeningDate;
            cmbTransType_SelectedValueChanged(null, null);
            BindSalesman();
            cmbTrPurpose.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Helper.ValidateNotEmpty(new List<Control>() { cmbTransType, cmbTrPurpose, txtTransCrAmt })) return;

            if (cmbTrPurpose.Text.ToLower() == "salary" && cmbSalesman.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Salesman", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dg = MessageBox.Show("Are you sure to Save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg == DialogResult.Yes)
            {
                DailyTransaction trn = new DailyTransaction();
                trn.TransactionPurposeId = Convert.ToInt32(cmbTrPurpose.SelectedValue);
                trn.WarehouseId = MDIParent.storeId;
                string date = dtTransDate.Value.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                trn.TransactionDate = Convert.ToDateTime(date);
                trn.TransactionType = "Manual";
                trn.Narration = txtTransNarration.Text.Trim();
                trn.DrAmt = 0;
                trn.CrAmt = Convert.ToDecimal(txtTransCrAmt.Text.Trim());
                trn.BalanceAmt = 0;
                if (cmbSalesman.SelectedIndex > -1)
                    trn.BankId = Convert.ToInt32(cmbSalesman.SelectedValue);
                trn.CreatorId = MDIParent.userId;
                trn.CreateDate = DateTime.Now;
                trn.IsVoid = false;
                trn.VoucherType = trn.DrAmt > 0 ? "Receipt" : "Payment";
                trn.ChequeNo = "N/A";

                DbTransaction trans = UtilsDAO.BeginTransaction();

                try
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    Int64 id = oDailyTransactionDAO.Add(trn);

                    if (id > 0)
                    {
                        MessageBox.Show("Expense Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UtilsDAO.CommitTransaction(trans);
                        ClearControls();
                    }
                }
                catch (Exception ex)
                {
                    UtilsDAO.RollbackTransaction(trans);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (DbProviderHelper.IsInTransaction)
                    {
                        UtilsDAO.RollbackTransaction(trans);
                    }
                }
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (!Helper.ValidateNotEmpty(new List<Control>() {txtVoidReason})) return;

            if (DialogResult.Yes ==
                MessageBox.Show("Are you sure to void this transaction?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                DailyTransaction trn = new DailyTransaction();
                trn.TransactionId = Convert.ToInt64(dgv.SelectedRows[0].Cells["TransactionId"].Value);
                trn.IsVoid = true;
                trn.VoidReson = txtVoidReason.Text.Trim();
                trn.VoidDate = DateTime.Now;
                trn.VoidBy = MDIParent.userId;

                DbTransaction trans = UtilsDAO.BeginTransaction();

                try
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    Int32 vId = oDailyTransactionDAO.UpdateIsVoid(trn);

                    if (vId > 0)
                    {
                        MessageBox.Show("Expense voided successfully", "Voided", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UtilsDAO.CommitTransaction(trans);
                        dgv.DataSource = new DataTable();
                        ClearControls();
                    }
                }
                catch (Exception ex)
                {
                    UtilsDAO.RollbackTransaction(trans);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (DbProviderHelper.IsInTransaction)
                    {
                        UtilsDAO.RollbackTransaction(trans);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
            dgv.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string from = dtSearchFrom.Value.ToString("yyyy-MM-dd");
            string to = dtSearchTo.Value.ToString("yyyy-MM-dd");

            string where = "T.TransactionType='Manual' AND T.IsVoid=0 AND T.WarehouseId=" + 1 + " AND dbo.TrimTime(T.TransactionDate) BETWEEN dbo.TrimTime('" + from + "') AND dbo.TrimTime('" + to + "')";
            //where = string.IsNullOrEmpty(cmbTrTypeSearch.Text) ? where : where + " AND P.[TransactionType] = '" + cmbTrTypeSearch.Text + "'";

            List<DailyTransaction> lst = oDailyTransactionDAO.DailyTransaction_GetDynamic(where, "T.TransactionDate");

            if (lst.Count > 0)
            {
                dgv.DataSource = lst;
                dgv.Columns["TransactionId"].Visible = dgv.Columns["TransactionPurposeId"].Visible = dgv.Columns["WarehouseId"].Visible = dgv.Columns["TransactionType"].Visible = dgv.Columns["BalanceAmt"].Visible = dgv.Columns["SalesId"].Visible = dgv.Columns["PurchaseId"].Visible = dgv.Columns["SalesCollectionId"].Visible = dgv.Columns["PurchasePaymentId"].Visible = dgv.Columns["CustomerId"].Visible = dgv.Columns["SupplierId"].Visible = dgv.Columns["BankId"].Visible = dgv.Columns["BranchId"].Visible = dgv.Columns["ChequeDate"].Visible = dgv.Columns["CreatorId"].Visible = dgv.Columns["CreateDate"].Visible = dgv.Columns["IsVoid"].Visible = dgv.Columns["VoidBy"].Visible = dgv.Columns["VoidDate"].Visible = dgv.Columns["VoidReson"].Visible = dgv.Columns["VoucherType"].Visible = false;
                dgv.Columns["DrAmt"].Visible = dgv.Columns["ChequeNo"].Visible = dgv.Columns["Bank"].Visible = dgv.Columns["Branch"].Visible = false;
                dgv.Columns["TransactionDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["TransactionDate"].Width = dgv.Columns["DrAmt"].Width = dgv.Columns["CrAmt"].Width = 80;
                dgv.Columns["SL"].Width = 50;
                dgv.Columns["TransactionPurposeName"].Width = 200;
                dgv.Columns["Narration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["SL"].HeaderText = "  S/N";
                dgv.Columns["TransactionDate"].HeaderText = "Trn. Date";
                dgv.Columns["TransactionPurposeName"].HeaderText = "                  Purpose";
                dgv.Columns["DrAmt"].HeaderText = "      DrAmt";
                dgv.Columns["CrAmt"].HeaderText = "   Amount";
                dgv.Columns["VoucherNo"].HeaderText = "  Voucher No";
                dgv.Columns["ChequeNo"].HeaderText = "  Cheque No";
                dgv.Columns["SL"].DefaultCellStyle.Alignment = dgv.Columns["TransactionDate"].DefaultCellStyle.Alignment = dgv.Columns["VoucherNo"].DefaultCellStyle.Alignment = dgv.Columns["TransactionPurposeName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DrAmt"].DefaultCellStyle.Alignment = dgv.Columns["CrAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["SL"].DisplayIndex = 0;
                dgv.Columns["TransactionDate"].DisplayIndex = 1;
                dgv.Columns["TransactionPurposeName"].DisplayIndex = 2;
                int loop = 1;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells["SL"].Value = loop; loop += 1;
                }
                dgv.ClearSelection();

                txtSearchTotal.Text = lst.Sum(x => x.CrAmt).ToString();
            }
            else
            {
                txtSearchTotal.Text = "0";
                dgv.DataSource = new DataTable();
                MessageBox.Show("No Expense found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddTrPurpose_Click(object sender, EventArgs e)
        {
            frmTransactionPurpose frm = new frmTransactionPurpose();
            frm.ControlBox = false;
            frmTransactionPurpose.FromDailyTrans = true;
            if (cmbTransType.Text == "Deposit") frmTransactionPurpose.TransType = 1;
            else frmTransactionPurpose.TransType = 2;
            frm.ShowDialog();

            if (frmTransactionPurpose.TrnsPurposeId > 0)
            {
                if (cmbTransType.Text == "Deposit") LoadTransactionPurpose("Deposit");
                else LoadTransactionPurpose("Withdraw");
                cmbTrPurpose.SelectedValue = frmTransactionPurpose.TrnsPurposeId;
                txtTransNarration.Focus();
            }
        }

        private void cmbTransType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTransType.SelectedIndex > -1)
            {
                if (cmbTransType.Text == "Deposit")
                {
                    txtTransDrAmt.Enabled = true;
                    txtTransCrAmt.Enabled = false;
                }
                else
                {
                    txtTransDrAmt.Enabled = false;
                    txtTransCrAmt.Enabled = true;
                }

                cmbTrPurpose.Enabled = btnNewPurpose.Enabled = true;
                //List<TransactionPurpose> lst = new TransactionPurposeDAO().TransactionPurpose_GetAll();
                //cmbTrPurpose.DataSource = lst;
                //cmbTrPurpose.SelectedIndex = -1;
                LoadTransactionPurpose(cmbTransType.Text);
            }
            else
            {
                txtTransDrAmt.Enabled = txtTransCrAmt.Enabled = cmbTrPurpose.Enabled = btnNewPurpose.Enabled = false;
            }

            cmbTrPurpose.SelectedIndex = -1;
            txtTransDrAmt.Clear();
            txtTransCrAmt.Clear();
        }

        private void txtTransDrAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputNumberWith2DecimalPlace(sender, e, txtTransDrAmt);
        }

        private void txtTransCrAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputNumberWith2DecimalPlace(sender, e, txtTransCrAmt);

            if (!string.IsNullOrEmpty(txtTransCrAmt.Text) && e.KeyChar == 13)
            {
                btnSave.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (btnSave.Enabled) btnSave.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                if (btnVoid.Enabled) btnVoid.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                if (btnClear.Enabled) btnClear.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                if (btnClose.Enabled) btnClose.PerformClick();
                return true;
            }
            if (keyData == Keys.Tab && (txtTransDrAmt.Focused || txtTransCrAmt.Focused))
            {
                if (txtVoidReason.Visible) txtVoidReason.Focus();
                else btnSave.Focus();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                ClearControls();
                btnVoid.Enabled = btnClear.Enabled = btnClose.Enabled = true;
                btnSave.Enabled = false;
                lblVoidReason.Visible = txtVoidReason.Visible = true;
                txtVoidReason.Focus();
            }
        }
        #endregion

        private void txtTransNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTransCrAmt.Focus();
            }
        }

        private void cmbTrPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbTrPurpose.SelectedIndex > -1 && FLD && e.KeyCode == Keys.Enter)
            {
                txtTransNarration.Focus();
            }
        }

        private void cmbTrPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSalesman.SelectedIndex = -1;

            if (cmbTrPurpose.Text.ToLower() == "salary")
            {
                lblSalesman.Visible = true;
                cmbSalesman.Visible = true;
            }
            else
            {
                lblSalesman.Visible = false;
                cmbSalesman.Visible = false;
            }
        }
    }
}
