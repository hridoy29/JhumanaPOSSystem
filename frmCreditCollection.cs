using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.DAL;
using POSsible.BusinessObjects;
using System.Text.RegularExpressions;
using System.Data.Common;
using POSsible.Reports;

namespace POSsible
{
    public partial class frmCreditCollection : Form
    {
        public CUser oUserLogin = new CUser();
        CustomerDAO oCustomerDAO = new CustomerDAO();
        CreditCollectionDAO oCreditCollectionDAO = new CreditCollectionDAO();
        InvoiceDAO oInvoiceDAO = new InvoiceDAO();

        bool saveMode = true;
        bool loadDone = false;
        double remBalance = 0;
        double outBalance = 0;
        double payAmount = 0;
        int CreditCollectionId = 0;

        public frmCreditCollection()
        {
            InitializeComponent();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadDone == false || cmbCustomer.SelectedIndex < 0) return;
            List<Invoice> invList = oInvoiceDAO.Invoice_GetDynamic("I.[customerId]=" + cmbCustomer.SelectedValue, ""); //1 for isPaid
            loadDone = false;
            cmbInvoiceNo.DataSource = invList;
            cmbInvoiceNo.DisplayMember = "InvoiceNo";
            cmbInvoiceNo.ValueMember = "invoiceId";
            cmbInvoiceNo.SelectedIndex = 0;
            cmbInvoiceNo.Text = string.Empty;
            loadDone = true;
            cmbInvoiceNo_SelectedIndexChanged(null, null);
        }

        private void loadGrid(int invId)
        {
            dgvItem.Rows.Clear();
            DataTable dtablePurchase = oInvoiceDAO.Invoice_GetPaymentByInvoiceId(invId);
            txtRemAmt.Text = dtablePurchase.Rows[0][5].ToString();
            txtOutBalance.Text = dtablePurchase.Rows[0][6].ToString();
            remBalance = Convert.ToDouble(txtRemAmt.Text);
            outBalance = Convert.ToDouble(txtOutBalance.Text);
            //Load Grid
            List<CreditCollection> CCList = oCreditCollectionDAO.CreditCollection_GetDynamic("[SaleId] ='" + invId + "'", "");
            if (CCList.Count > 0)
            {
                foreach (CreditCollection item in CCList)
                {
                    dgvItem.Rows.Add(item.MemoNo, item.CollectionDate, item.CollectionType, item.PaidAmount, item.CreditCollectionId, item.ChequeNo, item.ChequeDate, item.ReceivedBy, item.PaidBy, item.MRBookNo, item.ChequeBank);
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

            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                int proId = MDIParent.projectId;

                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                CreditCollection CCEntity = new CreditCollection();
                CCEntity.SaleId = Convert.ToInt32(cmbInvoiceNo.SelectedValue);
                CCEntity.CollectionDate = dtpCollectionDate.Value;
                CCEntity.CollectionType = cmbPayType.Text.ToString();
                CCEntity.ChequeNo = (cmbPayType.SelectedIndex == 0) ? string.Empty : txtChequeNo.Text;
                CCEntity.ChequeBank = (cmbPayType.SelectedIndex == 0) ? string.Empty : txtBank.Text;
                CCEntity.ChequeDate = dtChequeDate.Value;
                if (cmbPayType.SelectedIndex != 0)
                    CCEntity.ChequeDate = dtChequeDate.Value;
                CCEntity.PaidAmount = Convert.ToDouble(txtPayAmt.Text);
                CCEntity.DiscAmount = 0;
                CCEntity.RemAmount = Convert.ToDouble(txtRemAmt.Text);
                CCEntity.DueBalance = Convert.ToDouble(txtOutBalance.Text);
                CCEntity.MemoNo = txtMemoNo.Text;
                CCEntity.PaidBy = txtPaidBy.Text;
                CCEntity.MRBookNo = txtReceivedBy.Text;
                CCEntity.ReceivedBy = 1;
                CCEntity.Remarks = "Credit Collection";
                CCEntity.EnteredBy = MDIParent.userId;
                CCEntity.EnteredTime = DateTime.Now;
                CCEntity.CF1 = MDIParent.storeId.ToString(); //STORE ID
                CCEntity.CF2 = MDIParent.shiftId.ToString();
                int CCId = 0;
                if (saveMode)
                    CCId = oCreditCollectionDAO.Add(CCEntity);
                else
                {
                    cmbInvoiceNo.Enabled = true;
                    cmbCustomer.Enabled = true;
                    oCreditCollectionDAO.Delete(CreditCollectionId);
                    CCId = oCreditCollectionDAO.Add(CCEntity);
                    cmbInvoiceNo.SelectedIndex = -1;
                    cmbInvoiceNo.SelectedValue = Convert.ToInt32(CCEntity.SaleId);
                }

                if (CCEntity.RemAmount == 0)
                    oInvoiceDAO.UpdateIsPaid(CCEntity.SaleId);

                Alert("Credit Collection Saved Successfully.");
                loadGrid(Convert.ToInt32(CCEntity.SaleId));
                txtPayAmt.Clear();
                txtMemoNo.Clear();
                cmbPayType.SelectedIndex = 0;
                txtChequeNo.Clear();
                txtBank.Clear();
                dtChequeDate.Value = DateTime.Now;
                txtReceivedBy.Clear();
                txtPaidBy.Clear();
                cmbCustomer.Focus();
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

        private void cmbCustomerBind()
        {
            List<tblCustomer> lCustomerList = oCustomerDAO.Customer_GetDynamic("T.customerId IN (SELECT DISTINCT customerId FROM [tblInvoice] WHERE [status]='Credit') AND T.customerId<>0", "T.Name");
            if (lCustomerList.Count > 0)
            {
                cmbCustomer.DataSource = lCustomerList;
                cmbCustomer.SelectedIndex = -1;
            }
            loadDone = true;
        }

        private void txtPayAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double payAmt = (string.IsNullOrEmpty(txtPayAmt.Text)) ? 0 : Convert.ToDouble(txtPayAmt.Text);

                txtRemAmt.Text = (remBalance - payAmt).ToString();
                txtOutBalance.Text = (outBalance - payAmt).ToString();
            }
            catch (Exception)
            {
                Alert("Please type correct Pay Amount");
            }

            
        }

        private Boolean CheckValidityForAddRow()
        {

            if (cmbCustomer.SelectedIndex < 0)
            {
                Alert("Please select Customer.");
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
                txtPayAmt.Focus();
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

            if (string.IsNullOrEmpty(txtReceivedBy.Text.Trim()))
            {
                Alert("Please type Received By.");
                return false;
            }

            //if (txtPaidBy.Text.Trim() == "")
            //{
            //    Alert("Please enter Payee's name.");
            //    txtPaidBy.Focus();
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
            cmbCustomer.SelectedIndex = -1;
            cmbInvoiceNo.DataSource = null;
            txtSaleType.Clear();
            dtpSaleDate.Value = DateTime.Now;
            txtPayAmt.Clear();
            txtInvoiceAmt.Clear();
            txtRemAmt.Clear();
            txtOutBalance.Clear();
            txtMemoNo.Clear();
            cmbPayType.SelectedIndex = -1;
            txtChequeNo.Clear();
            dtChequeDate.Value = DateTime.Now;
            dgvItem.Rows.Clear();
            txtReceivedBy.Clear();
            txtPaidBy.Clear();
            dtpSaleDate.Enabled = true;

            cmbInvoiceNo.Enabled = true;
            cmbCustomer.Enabled = true;
        }

        private void txtPayAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (!(sender as TextBox).Text.Contains(".") && (sender as TextBox).Text.Length == 18 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d\d") && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int saleId = Convert.ToInt32(cmbInvoiceNo.SelectedValue);
            CreditCollectionId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[4].Value);

            if (e.ColumnIndex == 13)
            {

                DialogResult dg = MessageBox.Show("Are you sure you want to delete this Credit Collection?", "Delete Credit Collection", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                    try
                    {
                        oCreditCollectionDAO.Delete(CreditCollectionId);
                        dgvItem.Rows.RemoveAt(e.RowIndex);
                        cmbInvoiceNo.SelectedIndex = -1;
                        cmbInvoiceNo.SelectedValue = saleId;
                    }
                    catch (Exception)
                    {
                        Alert("Could not delete.");
                    }
            }
            else if (e.ColumnIndex == 11)
            {
                cmbInvoiceNo.Enabled = false;
                cmbCustomer.Enabled = false;
                cmbPayType.SelectedItem = dgvItem.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (cmbPayType.SelectedItem == "Cheque")
                {
                    txtChequeNo.Text = (string.IsNullOrEmpty(dgvItem.Rows[e.RowIndex].Cells[5].Value.ToString())) ? "CHQ NO." : dgvItem.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtBank.Text = dgvItem.Rows[e.RowIndex].Cells[10].Value.ToString();
                    dtChequeDate.Value = Convert.ToDateTime(dgvItem.Rows[e.RowIndex].Cells[6].Value).Date;
                }
                txtReceivedBy.Text = dgvItem.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtPaidBy.Text = dgvItem.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtMemoNo.Text = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPayAmt.Text = dgvItem.Rows[e.RowIndex].Cells[3].Value.ToString();
                payAmount = Convert.ToDouble(txtPayAmt.Text);
                remBalance = remBalance + payAmount;
                outBalance = outBalance + payAmount;
                txtRemAmt.Text = remBalance.ToString();
                txtOutBalance.Text = outBalance.ToString();
                dtpCollectionDate.Value = Convert.ToDateTime(dgvItem.Rows[e.RowIndex].Cells[1].Value.ToString()).Date;
                dgvItem.Rows.RemoveAt(e.RowIndex);
                saveMode = false;
            }
            else if (e.ColumnIndex == 12)
            {
                // PRINT MEMO
            }
        }

        private void cmbInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadDone == false || cmbInvoiceNo.SelectedIndex < 0) return;

            dgvItem.Rows.Clear();
            txtChequeNo.Clear();
            dtChequeDate.Value = DateTime.Now.Date;
            int invoiceId = Convert.ToInt32(cmbInvoiceNo.SelectedValue.ToString());
            Invoice invEntity = oInvoiceDAO.Invoice_GetById(invoiceId);
            if (invEntity != null)
            {
                txtSaleType.Text = invEntity.status;
                dtpSaleDate.Value = Convert.ToDateTime(invEntity.invoiceDate);
                txtInvoiceAmt.Text = invEntity.TotalPrice.ToString();
                dtpSaleDate.Enabled = false;
                loadGrid(invoiceId);
            }
            cmbPayType.Select();
        }

        private void txtPayAmt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPayAmt.Text);

            if (!string.IsNullOrEmpty(txtPayAmt.Text.Trim()) && e.KeyChar == 13)
            {
                txtReceivedBy.Focus();
            }
        }

        private void frmCreditCollection_Load(object sender, EventArgs e)
        {
            cmbCustomerBind();
            cmbPayType.Text = "Cash";
            cmbCustomer.Select();
            loadDone = true;
        }

        private void cmbInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbInvoiceNo.SelectedIndex > -1 && e.KeyChar == 13)
            {
                cmbPayType.Focus();
            }
        }

        private void cmbPayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbPayType.SelectedIndex > -1 && e.KeyChar == 13)
            {
                txtPayAmt.Focus();
            }
        }

        private void txtReceivedBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave.PerformClick();
            }
        }

        private void cmbCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbCustomer.SelectedIndex > -1 && e.KeyChar == 13)
            {
                cmbPayType.Focus();
            }
        }

        private void btnLastInReport_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex < 0)
            {
                Alert("Please select Customer.");
                return;
            }

            int invId = new TransactionDAO().ExecuteScalarInt("SELECT TOP 1 invoiceId FROM tblInvoice WHERE customerId=" + cmbCustomer.SelectedValue + " ORDER BY invoiceDate DESC");
            new frmRptViewer(invId).ShowDialog();
        }
    }
}
