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
using System.Text.RegularExpressions;
using POSsible.BusinessObjects;
using System.Data.Common;

namespace POSsible
{
    public partial class frmPaymentVoucher : Form
    {
        #region VARIABLES
        private int DrAccLgId = 0;
        private int CIHAcLgId = 0;
        private bool FLD = false;
        private double TotalAmt = 0;
        private ACCTransactionDAO oACCTransactionDAO = new ACCTransactionDAO();
        private PaymentVoucherDetailDAO oPaymentVoucherDetailDAO = new PaymentVoucherDetailDAO();
        #endregion

        #region METHODS
        private void EnableDisableAddButton()
        {
            if (cmbAcLedger.SelectedIndex > -1 && !string.IsNullOrEmpty(txtPayTo.Text) &&
                !string.IsNullOrEmpty(txtPayAmt.Text) && !string.IsNullOrEmpty(txtNarration.Text))
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void PopulateDebitAcc()
        {
            List<AccountLedger> lst = new AccountLedgerDAO().AccountLedger_GetDynamic("LG.[LedgerGroupName]<>'Payable Parties' AND AL.[CF1]='" + MDIParent.projectId + "'", "AL.[AccountLedgerName]");

            AccountLedger alCIH = lst.FirstOrDefault(p => (p.AccountLedgerName.ToLower() == "cash in hand"));
            if (alCIH == null)
            {
                Alert("Ledger Account 'Cash In Hand' not Found."); return;
            }

            CIHAcLgId = alCIH.AccountLedgerId;

            lst = lst.Where(p => (p.AccountLedgerName.ToLower() != "cash in hand")).ToList();
            cmbAcLedger.DataSource = lst;
            cmbAcLedger.SelectedIndex = -1;
        }

        public void Alert(string sMsg)
        {
            MessageBox.Show(sMsg, "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetAll()
        {
            ResetDetail();
            txtPayTo.Clear();
            dtPayDate.Value = DateTime.Now;
            dgv.Rows.Clear();
            txtTotal.Clear();
            btnSave.Enabled = false;
            txtPayTo.Select();
        }

        private void ResetDetail()
        {
            cmbAcLedger.SelectedIndex = -1;
            txtPayAmt.Clear();
            txtNarration.Clear();
        }
        #endregion

        #region EVENTS
        public frmPaymentVoucher()
        {
            InitializeComponent();
        }

        private void frmPaymentVoucher_Load(object sender, EventArgs e)
        {
            PopulateDebitAcc();
            FLD = true;
            txtPayTo.Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["AccountLedgerId"].Value.ToString() == cmbAcLedger.SelectedValue.ToString())
                    {
                        Alert("This Ledger Account already add to list!");
                        return;
                    }
                }
            }

            dgv.Rows.Add();
            int RowIndex = dgv.RowCount - 1;
            DataGridViewRow R = dgv.Rows[RowIndex];
            R.Cells["AccountLedgerId"].Value = DrAccLgId.ToString();
            R.Cells["AccountLedgerName"].Value = cmbAcLedger.Text;
            R.Cells["Narration"].Value = txtNarration.Text.Trim();
            R.Cells["Amount"].Value = String.Format("{00:00.00}", txtPayAmt.Text);
            TotalAmt += Convert.ToDouble(txtPayAmt.Text);
            txtTotal.Text = String.Format("{00:00.00}", TotalAmt);
            ResetDetail();
            btnSave.Enabled = true;
            cmbAcLedger.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new TransactionDAO().Transaction_GetBalanceByHead(CIHAcLgId);
            double vouAmt = Convert.ToDouble(txtTotal.Text);
            double balAmt = Convert.ToDouble(dt.Rows[0][0]);
            if (vouAmt > balAmt)
            {
                MessageBox.Show("Not enough Cash in hand. Current Cash:" + String.Format("{0: #,#0.000}", (balAmt))); return;
            }

            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                #region Save Payment Voucher Main
                PaymentVoucherMain PVMEntity = new PaymentVoucherMain();
                PVMEntity.PaymentVoucherMode = "Manual";
                PVMEntity.PaymentVoucherNo = 1;
                PVMEntity.PaymentVoucherDate = dtPayDate.Value;
                PVMEntity.CreateDate = DateTime.Now;
                PVMEntity.CreatorId = MDIParent.userId;
                PVMEntity.CF1 = MDIParent.projectId.ToString();
                PVMEntity.CF3 = "New";
                Int64 PVMId = new PaymentVoucherMainDAO().Add(PVMEntity);
                #endregion

                if (PVMId > 0)
                {
                    #region Save Transaction Credit
                    ACCTransaction trEntity1 = new ACCTransaction();
                    trEntity1.AccountLedgerId = CIHAcLgId;
                    trEntity1.Narration = "~Payment Voucher from POS => Paid Cash to " + txtPayTo.Text.Trim();
                    trEntity1.DrAmt = 0;
                    trEntity1.CrAmt = vouAmt;
                    trEntity1.TransactionDate = PVMEntity.PaymentVoucherDate;
                    trEntity1.VoucherNo = PVMEntity.PaymentVoucherNo.ToString();
                    trEntity1.ChequeNo = "";
                    trEntity1.IsVoid = false;
                    trEntity1.CreateDate = DateTime.Now;
                    trEntity1.CreatorId = PVMEntity.CreatorId;
                    trEntity1.CustomField4 = PVMEntity.CF1;
                    trEntity1.SalesId = MDIParent.shiftId;
                    trEntity1.CustomField5 = "Payment";
                    trEntity1.VoucherId = PVMId;
                    Int64 trId1 = oACCTransactionDAO.Add(trEntity1);
                    #endregion

                    if (trId1 > 0)
                    {
                        #region Save Payment Voucher Detail Credit
                        PaymentVoucherDetail pvdEntity1 = new PaymentVoucherDetail();
                        pvdEntity1.PaymentVoucherId = PVMId;
                        pvdEntity1.TransactionId = trId1;
                        pvdEntity1.AccountLedgerId = trEntity1.AccountLedgerId;
                        pvdEntity1.Narration = trEntity1.Narration;
                        pvdEntity1.DrAmt = trEntity1.DrAmt;
                        pvdEntity1.CrAmt = trEntity1.CrAmt;
                        pvdEntity1.CCCode = 0;
                        Int64 pvdId1 = oPaymentVoucherDetailDAO.Add(pvdEntity1);
                        #endregion

                        if (pvdId1 > 0)
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                #region Save Transaction Debit
                                ACCTransaction trEntity2 = new ACCTransaction();
                                trEntity2.AccountLedgerId = Convert.ToInt32(row.Cells["AccountLedgerId"].Value);
                                trEntity2.Narration = "~Payment Voucher from POS => " + row.Cells["Narration"].Value;
                                trEntity2.DrAmt = Convert.ToDouble(row.Cells["Amount"].Value);
                                trEntity2.CrAmt = 0;
                                trEntity2.TransactionDate = trEntity1.TransactionDate;
                                trEntity2.VoucherNo = trEntity1.VoucherNo;
                                trEntity2.ChequeNo = "";
                                trEntity2.IsVoid = false;
                                trEntity2.CreateDate = trEntity1.CreateDate;
                                trEntity2.CreatorId = trEntity1.CreatorId;
                                trEntity2.CustomField4 = trEntity1.CustomField4;
                                trEntity2.SalesId = trEntity1.SalesId;
                                trEntity2.CustomField5 = "Payment";
                                trEntity2.VoucherId = PVMId;
                                trEntity2.CustomField1 = CIHAcLgId.ToString();
                                trEntity2.CustomField3 = trEntity1.Narration;
                                Int64 trId2 = oACCTransactionDAO.Add(trEntity2);
                                #endregion

                                if (trId2 > 0)
                                {
                                    #region Save Payment Voucher Detail Debit
                                    PaymentVoucherDetail pvdEntity2 = new PaymentVoucherDetail();
                                    pvdEntity2.PaymentVoucherId = PVMId;
                                    pvdEntity2.TransactionId = trId2;
                                    pvdEntity2.AccountLedgerId = trEntity2.AccountLedgerId;
                                    pvdEntity2.Narration = trEntity2.Narration;
                                    pvdEntity2.DrAmt = trEntity2.DrAmt;
                                    pvdEntity2.CrAmt = trEntity2.CrAmt;
                                    pvdEntity2.CCCode = 0;
                                    Int64 pvdId2 = oPaymentVoucherDetailDAO.Add(pvdEntity2);
                                    #endregion
                                }
                            }

                            Alert("Payment Voucher Saved Successfully");
                            ResetAll();
                            UtilsDAO.CommitTransaction(trans);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UtilsDAO.RollbackTransaction(trans);
                Alert(ex.Message);
            }
            finally
            {
                if (DbProviderHelper.IsInTransaction)
                {
                    UtilsDAO.RollbackTransaction(trans);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPayAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPayAmt.Text);
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4) return;
            double amt = Convert.ToDouble(dgv.SelectedRows[0].Cells["Amount"].Value);
            TotalAmt -= amt;
            txtTotal.Text = String.Format("{00:00.00}", TotalAmt);
            dgv.Rows.RemoveAt(e.RowIndex);
            btnSave.Enabled = dgv.RowCount > 0;
            cmbAcLedger.Focus();
        }

        private void cmbAcLedger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAcLedger.SelectedIndex > -1 && FLD)
            {
                DrAccLgId = Convert.ToInt32(cmbAcLedger.SelectedValue);
                EnableDisableAddButton();
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            EnableDisableAddButton();
        }
        #endregion
    }
}