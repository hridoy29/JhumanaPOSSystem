using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmPurchaseReturn : Form
    {
        public static int PurIdForReturn = 0;
        public int SupId = 0;

        public frmPurchaseReturn()
        {
            InitializeComponent();
        }

        private void frmPurchaseReturn_Load(object sender, EventArgs e)
        {
            if (PurIdForReturn < 1) return;
            Purchase PEntity = new PurchaseDAO().Purchase_GetDynamic("P.[purchaseId]=" + PurIdForReturn, "").FirstOrDefault();

            if (PEntity != null)
            {
                txtInvoiceNo.Text = PEntity.description;
                txtSupplier.Text = PEntity.SupplierName;
                txtPurDate.Text = String.Format("{0:dd/MM/yyyy}", PEntity.orderDate);
                txtPurType.Text = PEntity.status;
                SupId = PEntity.supplierId.Value;

                List<PurchaseProduct> PPList = new PurchaseProductDAO().PurchaseProduct_GetDynamic("PP.[purchaseId]=" + PurIdForReturn, "");
                if (PPList.Count > 0)
                {
                    dgvItem.DataSource = PPList;
                    dgvItem.Columns["purchaseDtlId"].Visible = dgvItem.Columns["purchaseId"].Visible = dgvItem.Columns["productId"].Visible = dgvItem.Columns["ExpireDate"].Visible = dgvItem.Columns["ReturnQty"].Visible = false;
                    dgvItem.Columns["qty"].ReadOnly = dgvItem.Columns["unitCost"].ReadOnly = dgvItem.Columns["ProductName"].ReadOnly = dgvItem.Columns["usedQty"].ReadOnly = dgvItem.Columns["ReturnedQty"].ReadOnly = true;
                    dgvItem.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvItem.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvItem.Columns["ProductName"].HeaderText = "Product";
                    dgvItem.Columns["unitCost"].HeaderText = "   Unit Price";
                    dgvItem.Columns["qty"].HeaderText = "Purchase Qty";
                    dgvItem.Columns["usedQty"].HeaderText = "    Used Qty";
                    dgvItem.Columns["ReturnedQty"].HeaderText = "Returned Qty";
                    dgvItem.Columns["ProductName"].DisplayIndex = 0;
                    dgvItem.Columns["unitCost"].DisplayIndex = 1;
                    dgvItem.Columns["qty"].DisplayIndex = 2;
                    dgvItem.Columns["usedQty"].DisplayIndex = 3;
                    dgvItem.Columns["ReturnedQty"].DisplayIndex = 4;
                    dgvItem.Columns["unitCost"].DefaultCellStyle.Format = "#,#0.000";

                    //if (PEntity.status == "Cash")
                    //    MessageBox.Show("Only Cash is Accepted for Cash Purchase Return", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSaveRet_Click(object sender, EventArgs e)
        {
            //AccountLedger supAcLg = new AccountLedgerDAO().AccountLedger_GetDynamic("AL.[AccountLedgerId]=(SELECT CAST([GLCode] AS INT) FROM [tblSupplier] WHERE [SupplierId]=" + SupId + ")", "").FirstOrDefault();
            //if (supAcLg == null)
            //{
            //    MessageBox.Show("Supplier Account Ledger not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //AccountLedger purRetAcLg = new AccountLedgerDAO().AccountLedger_GetDynamic("AL.[AccountLedgerName] = 'Purchase Return' AND AL.[CF1]='" + MDIParent.projectId + "'", "").FirstOrDefault();
            //if (purRetAcLg == null)
            //{
            //    MessageBox.Show("Purchase Return Account Ledger not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //AccountLedger CIHAcLg = new AccountLedger();
            bool paidOff = false;
            if (txtPurType.Text == "Cash")
            {
                //CIHAcLg = new AccountLedgerDAO().AccountLedger_GetDynamic("AL.[AccountLedgerName] = 'Cash In Hand' AND AL.[CF1]='" + MDIParent.projectId + "'", "").FirstOrDefault();
                //if (CIHAcLg == null)
                //{
                //    MessageBox.Show("Cash In Hand Account Ledger not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
            }

            else
            {
                DataTable dtablePurchase = new PurchaseDAO().Purchase_GetPaymentByPurchaseId(PurIdForReturn);
                if (Convert.ToDouble(txtTotalRet.Text) > Convert.ToDouble(dtablePurchase.Rows[0][5]))
                {
                    MessageBox.Show("Cannot Return more than Due Amount for Credit Purchase", "Cannot Return",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Convert.ToDouble(txtTotalRet.Text) == Convert.ToDouble(dtablePurchase.Rows[0][5]))
                    paidOff = true;
            }

            PurchaseReturn purRet = new PurchaseReturn();
            purRet.StoreId = MDIParent.storeId;
            purRet.PurchaseId = PurIdForReturn;
            purRet.ReturnDate = dtReturnDate.Value;
            purRet.Remarks = txtRemarks.Text;
            purRet.TotReturnAmt = Convert.ToDouble(txtTotalRet.Text);
            purRet.ShiftId = MDIParent.shiftId;
            purRet.CreatorId = MDIParent.userId;
            purRet.CreateDate = DateTime.Now;
            purRet.UpdatorId = MDIParent.userId;
            purRet.UpdateDate = DateTime.Now;

            Int64 id = 0;
            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                id = new PurchaseReturnDAO().Add(purRet);
                if (id > 0)
                {
                    foreach (DataGridViewRow row in dgvItem.Rows)
                    {
                        int rtnQty = 0;
                        try { rtnQty = Convert.ToInt32(dgvItem["cRetQty", row.Index].Value); }
                        catch { rtnQty = 0; }

                        if (rtnQty > 0)
                        {
                            PurchaseReturnDetail returnDetail = new PurchaseReturnDetail();
                            returnDetail.ReturnId = id;
                            returnDetail.ProductId = Convert.ToInt32(row.Cells["productId"].Value);
                            returnDetail.ReturnQty = Convert.ToInt32(row.Cells["cRetQty"].Value);
                            returnDetail.ReturnPrice = Convert.ToDouble(row.Cells["unitCost"].Value);
                            returnDetail.ReturnAmount = Convert.ToDouble(row.Cells["ReturnAmt"].Value);
                            returnDetail.PurchaseId = PurIdForReturn;
                            new PurchaseReturnDetailDAO().Add(returnDetail);
                        }
                    }

                    

                    if (txtPurType.Text == "Credit")
                    {
                        if (paidOff)
                            new PurchaseDAO().Purchase_UpdateIsPaid(PurIdForReturn, true);
                    }
                    else
                    {
                        
                    }

                    UtilsDAO.CommitTransaction(trans);
                    SupId = 0;
                    MessageBox.Show("Purchase Return Saved", "Return Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Return Could not Save", "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DbProviderHelper.IsInTransaction)
                    UtilsDAO.RollbackTransaction(trans);
            }
        }

        private void dgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItem.Rows.Count > 0)
            {
                int purQty = 0;
                int usedQty = 0;
                int rtnedQty = 0;
                int rtnQty = 0;
                decimal uPrice = 0;
                decimal totRetAmt = 0;

                try { purQty = Convert.ToInt32(dgvItem["qty", dgvItem.CurrentRow.Index].Value); }
                catch { purQty = 0; }
                try { usedQty = Convert.ToInt32(dgvItem["usedQty", dgvItem.CurrentRow.Index].Value); }
                catch { usedQty = 0; }
                try { rtnedQty = Convert.ToInt32(dgvItem["ReturnedQty", dgvItem.CurrentRow.Index].Value); }
                catch { rtnedQty = 0; }
                try { rtnQty = Convert.ToInt32(dgvItem["cRetQty", dgvItem.CurrentRow.Index].Value); }
                catch { rtnQty = 0; }
                try { uPrice = Convert.ToDecimal(dgvItem["unitCost", dgvItem.CurrentRow.Index].Value); }
                catch { uPrice = 0; }

                if ((usedQty + rtnedQty + rtnQty) > purQty)
                {
                    dgvItem["cRetQty", dgvItem.CurrentRow.Index].Value = 0;
                    MessageBox.Show("Cannot Return more than available quantity", "Invalid Return Qty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rtnQty = 0;
                }

                dgvItem["ReturnAmt", dgvItem.CurrentRow.Index].Value = String.Format("{0: #,#0.000}", uPrice * rtnQty);

                foreach (DataGridViewRow dRow in dgvItem.Rows)
                {
                    totRetAmt += Convert.ToDecimal(dRow.Cells["ReturnAmt"].Value);
                }

                txtTotalRet.Text = String.Format("{0: #,#0.000}", totRetAmt);
                btnSaveRet.Enabled = totRetAmt > 0;
            }
        }

        private void dgvItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItem.IsCurrentCellDirty)
            {
                dgvItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
