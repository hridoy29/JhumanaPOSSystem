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
    public partial class frmPurchasePayment : Form
    {
        public CUser oUserLogin = new CUser();
        SupplierDAO oSupplierDAO = new SupplierDAO();
        PurchaseDAO oPurchaseDAO = new PurchaseDAO();
        PurchasePaymentDAO oPurchasePaymentDAO = new PurchasePaymentDAO();

        bool saveMode = true;
        bool loadDone = false;
        double remBalance = 0;
        double outBalance = 0;
        double payAmount = 0;
        int PurchasePayId = 0;

        public frmPurchasePayment()
        {
            InitializeComponent();
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex < 0) return;
            //Load Invoice
            if (loadDone == false || cmbSupplier.SelectedIndex < 0) return;
            List<Purchase> purList = oPurchaseDAO.Purchase_GetDynamic("P.[supplierId]=" + cmbSupplier.SelectedValue, "");// AND P.[IsPaid] = 0", "");

            loadDone = false;
            cmbInvoiceNo.DataSource = purList;
            cmbInvoiceNo.DisplayMember = "description";
            cmbInvoiceNo.ValueMember = "purchaseId";
            cmbInvoiceNo.SelectedIndex = 0;
            //cmbInvoiceNo.Text = string.Empty;
            loadDone = true;
            txtInvoiceNo_SelectedIndexChanged(null, null);
        }

        private void txtInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadDone == false || cmbInvoiceNo.SelectedIndex < 0) return;

            dgvItem.Rows.Clear();
            txtChequeNo.Clear();
            dtChequeDate.Value = DateTime.Now.Date;
            int purId = Convert.ToInt32(cmbInvoiceNo.SelectedValue.ToString());
            Purchase purEntity = oPurchaseDAO.Purchase_GetById(purId);
            if (purEntity != null)
            {
                txtPurchaseType.Text = purEntity.status;
                dtpPurchaseDate.Value = Convert.ToDateTime(purEntity.orderDate);
                txtInvoiceAmt.Text = purEntity.totalCost.ToString();
                dtpPurchaseDate.Enabled = false;
                loadGrid(purId);
            }
            cmbPayType.Select();
        }

        private void loadGrid(int purId)
        {
            dgvItem.Rows.Clear();
            DataTable dtablePurchase = oPurchaseDAO.Purchase_GetPaymentByPurchaseId(purId);
            txtRemAmt.Text = dtablePurchase.Rows[0][5].ToString();
            txtOutBalance.Text = dtablePurchase.Rows[0][6].ToString();
            remBalance = Convert.ToDouble(txtRemAmt.Text);
            outBalance = Convert.ToDouble(txtOutBalance.Text);
            //Load Grid
            List<PurchasePayment> PPList = oPurchasePaymentDAO.PurchasePayment_GetDynamic("[PurchaseId] ='" + purId + "'", "");
            if (PPList.Count > 0)
            {
                foreach (PurchasePayment item in PPList)
                {
                    dgvItem.Rows.Add(item.MemoNumber, item.PaymentDate, item.PaymentType, item.PaidAmount, item.PurchasePaymentId, item.ChequeNo, item.ChequeDate, item.PaidBy, item.ReceivedBy, item.CF3, item.ChequeBank);
                }
            }
            this.dgvItem.Columns[1].DefaultCellStyle.Format = "dd/MM/yy";
            this.dgvItem.Columns[9].DisplayIndex = 0;
            this.dgvItem.Columns[10].DisplayIndex = 1;
            dgvItem.ClearSelection();
        }

        private void cmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayType.SelectedIndex == 1)
            {
                txtChequeNo.Visible = true;
                dtChequeDate.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label14.Visible = true;
                txtBank.Visible = true;
            }
            else
            {
                txtChequeNo.Visible = false;
                dtChequeDate.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label14.Visible = false;
                txtBank.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save Payment
            if (!CheckValidityForAddRow()) return;

            int proId = MDIParent.projectId;

            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                PurchasePayment PPEntity = new PurchasePayment();
                PPEntity.PurchaseId = Convert.ToInt32(cmbInvoiceNo.SelectedValue);
                PPEntity.PaymentDate = dtpPaymentDate.Value;
                PPEntity.PaymentType = cmbPayType.Text.ToString();
                PPEntity.ChequeNo = (cmbPayType.SelectedIndex == 0) ? string.Empty : txtChequeNo.Text;
                PPEntity.ChequeDate = (cmbPayType.SelectedIndex == 0) ? DateTime.Now : dtChequeDate.Value;
                PPEntity.ChequeBank = txtBank.Text.Trim();
                PPEntity.PaidAmount = Convert.ToDecimal(txtPayAmt.Text);
                PPEntity.DiscAmount = 0;
                PPEntity.RemAmount = Convert.ToDecimal(txtRemAmt.Text);
                PPEntity.DueBalance = Convert.ToDecimal(txtOutBalance.Text);
                PPEntity.MemoNumber = txtMemoNo.Text;
                //PPEntity.PaidBy = 1;
                PPEntity.ReceivedBy = txtReceivedBy.Text;
                PPEntity.Remarks = "PURCHASE PAYMENT";
                PPEntity.EnteredBy = oUserLogin.UserLoginId;
                PPEntity.EnteredTime = DateTime.Now;
                PPEntity.CF1 = MDIParent.storeId.ToString(); //STORE ID
                PPEntity.CF2 = MDIParent.shiftId.ToString();
                PPEntity.CF3 = txtPaidBy.Text.Trim();

                int PPEId = 0;
                if (saveMode)
                    PPEId = oPurchasePaymentDAO.Add(PPEntity);
                else
                {
                    cmbInvoiceNo.Enabled = true;
                    cmbSupplier.Enabled = true;
                    oPurchasePaymentDAO.Delete(PurchasePayId);
                    PPEId = oPurchasePaymentDAO.Add(PPEntity);
                    cmbInvoiceNo.SelectedIndex = -1;
                    cmbInvoiceNo.SelectedValue = Convert.ToInt32(PPEntity.PurchaseId);
                }

                if (Convert.ToDouble(txtRemAmt.Text) == 0.00)
                    oPurchaseDAO.Purchase_UpdateIsPaid(Convert.ToInt32(cmbInvoiceNo.SelectedValue), true);
                else
                    oPurchaseDAO.Purchase_UpdateIsPaid(Convert.ToInt32(cmbInvoiceNo.SelectedValue), false);

                Alert("Payment Saved Successfully.");
                loadGrid(Convert.ToInt32(PPEntity.PurchaseId));
                txtPayAmt.Clear();
                txtMemoNo.Clear();
                txtPaidBy.Clear();
                txtReceivedBy.Clear();
                cmbPayType.SelectedIndex = -1;
                cmbSupplierBind();
                txtChequeNo.Clear();
                txtBank.Clear();
                dtChequeDate.Value = DateTime.Now;
                cmbSupplier.Focus();
                UtilsDAO.CommitTransaction(trans);
            }
            catch (Exception)
            {
                Alert("Payment could not be saved.");
            }
            finally
            {
                if (DbProviderHelper.IsInTransaction)
                    UtilsDAO.RollbackTransaction(trans);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Reset All (New Load)
            resetAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close form
            this.Dispose();
        }

        private void cmbSupplierBind()
        {
            List<Supplier> lSupplierList = oSupplierDAO.Supplier_GetDynamic("[SupplierId] IN (SELECT [SupplierId] FROM TblPurchase WHERE IsPaid=0)", "[SupplierName]");
            cmbSupplier.DataSource = lSupplierList;
            cmbSupplier.SelectedIndex = -1;
            loadDone = true;
        }

        private void txtPayAmt_TextChanged(object sender, EventArgs e)
        {
            //Calculate value in Out B, Rem B, Invoice B

            double payAmt = (string.IsNullOrEmpty(txtPayAmt.Text)) ? 0 : Convert.ToDouble(txtPayAmt.Text);

            txtRemAmt.Text = (remBalance - payAmt).ToString();
            txtOutBalance.Text = (outBalance - payAmt).ToString();
        }

        private Boolean CheckValidityForAddRow()
        {

            if (cmbSupplier.SelectedIndex < 0)
            {
                Alert("Select Supplier.");
                return false;
            }

            if (cmbInvoiceNo.SelectedIndex < 0)
            {
                Alert("Please select Invoice No.");
                return false;
            }

            //if (txtMemoNo.Text.Trim() == "")
            //{
            //    Alert("Please enter Memo no.");
            //    txtMemoNo.Focus();
            //    return false;
            //}

            if (txtPayAmt.Text.Trim() == "")
            {
                Alert("Please enter Amount.");
                txtMemoNo.Focus();
                return false;
            }

            if (cmbPayType.SelectedIndex < 0)
            {
                Alert("Please Select Pay Type");
                return false;
            }

            if (txtChequeNo.Text.Trim() == "" && cmbPayType.Text == "Cheque")
            {
                Alert("Please enter Cheque no.");
                txtChequeNo.Focus();
                return false;
            }

            if (dtChequeDate.Value == DateTime.MinValue && cmbPayType.Text == "Cheque")
            {
                Alert("Please Select Cheque Date");
                return false;
            }

            if (cmbPayType.Text == "Cheque" && string.IsNullOrEmpty(txtBank.Text.Trim()))
            {
                Alert("Please type Bank Name.");
                return false;
            }

            //if (string.IsNullOrEmpty(txtPaidBy.Text.Trim()))
            //{
            //    Alert("Please type Paid By.");
            //    return false;
            //}

            //if (txtReceivedBy.Text.Trim() == "")
            //{
            //    Alert("Please enter Receiver name.");
            //    txtReceivedBy.Focus();
            //    return false;
            //}

            //if (Convert.ToDouble(txtPayAmt.Text) > remBalance)
            //{
            //    Alert("Payable amount can't be more than Remaining Balance.");
            //    txtPayAmt.Focus();
            //    return false;
            //}



            return true;
        }

        public void Alert(string sMsg)
        {
            MessageBox.Show(sMsg, "POSsible");
        }

        private void resetAll()
        {
            cmbSupplier.SelectedIndex = -1;
            cmbInvoiceNo.DataSource = null;
            txtPurchaseType.Clear();
            dtpPurchaseDate.Value = DateTime.Now;
            txtPayAmt.Clear();
            txtInvoiceAmt.Clear();
            txtRemAmt.Clear();
            txtOutBalance.Clear();
            txtMemoNo.Clear();
            cmbPayType.SelectedIndex = -1;
            txtChequeNo.Clear();
            dtChequeDate.Value = DateTime.Now;
            dgvItem.Rows.Clear();
            txtPaidBy.Clear();
            txtReceivedBy.Clear();
            dtpPurchaseDate.Enabled = true;

            cmbInvoiceNo.Enabled = true;
            cmbSupplier.Enabled = true;
        }

        private void txtPayAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPayAmt.Text);

            if (!string.IsNullOrEmpty(txtPayAmt.Text.Trim()) && e.KeyChar == 13)
            {
                txtPaidBy.Focus();
            }
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int purId = Convert.ToInt32(cmbInvoiceNo.SelectedValue);
            PurchasePayId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[4].Value);

            if (e.ColumnIndex == 13)
            {

                DialogResult dg = MessageBox.Show("Are you sure you want to delete this Purchase Payment?", "Delete Purchase Payment", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                    try
                    {
                        oPurchasePaymentDAO.Delete(PurchasePayId);
                        dgvItem.Rows.RemoveAt(e.RowIndex);
                        cmbInvoiceNo.SelectedIndex = -1;
                        cmbInvoiceNo.SelectedValue = purId;
                    }
                    catch (Exception)
                    {
                        Alert("Could not delete.");
                    }
            }
            else if (e.ColumnIndex == 11)
            {
                cmbInvoiceNo.Enabled = false;
                cmbSupplier.Enabled = false;
                cmbPayType.SelectedItem = dgvItem.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (cmbPayType.SelectedItem == "Cheque")
                {
                    txtChequeNo.Text = (string.IsNullOrEmpty(dgvItem.Rows[e.RowIndex].Cells[5].Value.ToString())) ? "CHQ NO." : dgvItem.Rows[e.RowIndex].Cells[5].Value.ToString();
                    dtChequeDate.Value = Convert.ToDateTime(dgvItem.Rows[e.RowIndex].Cells[6].Value).Date;
                    txtBank.Text = dgvItem.Rows[e.RowIndex].Cells[10].Value.ToString();
                }
                txtPaidBy.Text = dgvItem.Rows[e.RowIndex].Cells[9].Value == null ? string.Empty : dgvItem.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtReceivedBy.Text = dgvItem.Rows[e.RowIndex].Cells[8].Value == null ? string.Empty : dgvItem.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtMemoNo.Text = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPayAmt.Text = dgvItem.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpPaymentDate.Value = Convert.ToDateTime(dgvItem.Rows[e.RowIndex].Cells[1].Value.ToString()).Date;
                payAmount = Convert.ToDouble(txtPayAmt.Text);
                remBalance = remBalance + payAmount;
                outBalance = outBalance + payAmount;
                txtRemAmt.Text = remBalance.ToString();
                txtOutBalance.Text = outBalance.ToString();
                dgvItem.Rows.RemoveAt(e.RowIndex);
                saveMode = false;
            }
            else if (e.ColumnIndex == 12)
            {
                // PRINT MEMO
            }
        }

        private void frmPurchasePayment_Load(object sender, EventArgs e)
        {
            cmbSupplierBind();
            cmbPayType.SelectedItem = "Cash";
            cmbSupplier.Select();
            loadDone = true;
        }

        private void cmbPayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbPayType.SelectedIndex > -1 && e.KeyChar == 13)
            {
                txtPayAmt.Focus();
            }
        }

        private void txtPaidBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave.PerformClick();
            }
        }
    }
}