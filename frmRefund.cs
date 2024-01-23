using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;
using System.Linq;
using System.Data.Common;

namespace POSsible
{
    public partial class frmRefund : Form
    {
        TransactionDAO oTransactionDAO = new TransactionDAO();
        private double dTotal = 0;

        public frmRefund()
        {
            InitializeComponent();
            cboInvoiceId.Text = "Invoice";
            BindCustomer();
        }

        private void BindCustomer()
        {
            List<tblCustomer> lstCustomer = new CustomerDAO().Customer_GetAll();
            lstCustomer.Add(new tblCustomer(0, "General Customer", "0", "0", "No City", "0000", "00", "", "", "", false, "", null, null, null, null));
            if (lstCustomer.Count > 0)
            {
                cboCustomer.DisplayMember = "Name";
                cboCustomer.ValueMember = "customerId";
                cboCustomer.DataSource = lstCustomer;
                cboCustomer.SelectedIndex = -1;

                List<tblCustomer> lstCustomer2 = new CustomerDAO().Customer_GetAll();
                cmbCustomerNew.DisplayMember = "Name";
                cmbCustomerNew.ValueMember = "customerId";
                cmbCustomerNew.DataSource = lstCustomer2;
                cmbCustomerNew.SelectedIndex = -1;
            }
        }

        private void buttOk_Click(object sender, EventArgs e)
        {
            if (chkChangeCustomer.Checked)
            {
                if (cboInvoiceId.SelectedIndex < 0 || cmbCustomerNew.SelectedIndex < 0)
                {
                    MessageBox.Show("Both Invoice No. and New Customer must be selected", "POSsible");
                    return;
                }

                int uId = oTransactionDAO.ExecuteQuery("UPDATE [tblInvoice] SET [customerId]=" + cmbCustomerNew.SelectedValue + " WHERE [invoiceId]=" + cboInvoiceId.SelectedValue);
                if (uId > 0)
                {
                    MessageBox.Show("Customer Changed successfully", "POSsible");
                    clear_form();
                }
            }
            else
                SaveRefundData();
        }

        private void SaveRefundData()
        {
            #region NEW REFUND
            if (!string.IsNullOrEmpty(txtTotal.Text) && Convert.ToDouble(txtTotal.Text) <= 0)
            {
                MessageBox.Show("Nothing to return!", "POSsible");
                return;
            }
            foreach (DataGridViewRow item in dgvRefund.Rows)
            {
                DataGridViewCheckBoxCell chk = item.Cells[0] as DataGridViewCheckBoxCell;
                double returnQty = string.IsNullOrEmpty(item.Cells[5].Value.ToString()) ? Convert.ToDouble(item.Cells[2].Value.ToString()) : Convert.ToDouble(item.Cells[5].Value.ToString());
                if (Convert.ToBoolean(chk.Value) && ((Convert.ToDouble(item.Cells[4].Value.ToString()) + returnQty) > Convert.ToDouble(item.Cells[2].Value.ToString())))
                {
                    //item.Cells[4].Value = item.Cells[2].Value.ToString();
                    MessageBox.Show("Can't return more than Sale Qty!", "POSsible");
                    return;
                }
            }

            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                if (dgvRefund.Rows.Count > 0)
                {
                    //MASTER
                    Refund RefundEntity = new Refund();
                    RefundEntity.AuthorizedBy = MDIParent.userId; // Needs to change later. Not sure.
                    RefundEntity.EnteredTime = DateTime.Now;
                    RefundEntity.invoiceId = Convert.ToInt32(cboInvoiceId.SelectedValue.ToString());
                    RefundEntity.refundDate = dpRefundDate.Value;
                    RefundEntity.RefundedBy = MDIParent.userId;
                    RefundEntity.RefundMethod = "CASH"; // Card not added yet.
                    RefundEntity.UpdatedTime = DateTime.Now;

                    int masterId = new RefundDAO().Add(RefundEntity);

                    if (masterId > 0)
                    {
                        //Detail
                        foreach (DataGridViewRow item in dgvRefund.Rows)
                        {
                            DataGridViewCheckBoxCell chk = item.Cells[0] as DataGridViewCheckBoxCell;
                            if (Convert.ToBoolean(chk.Value))
                            {
                                RefundProduct ProductEntity = new RefundProduct();

                                ProductEntity.description = "Description";
                                ProductEntity.EnteredBy = MDIParent.userId;
                                ProductEntity.EnteredTime = DateTime.Now;
                                ProductEntity.productId = Int32.Parse(item.Cells[7].Value.ToString());
                                ProductEntity.qty = Double.Parse(item.Cells[5].Value.ToString());
                                ProductEntity.Refundid = masterId;
                                ProductEntity.UnitPrice = Double.Parse(item.Cells[3].Value.ToString());
                                ProductEntity.UpdatedBy = MDIParent.userId;
                                ProductEntity.UpdatedTime = DateTime.Now;
                                ProductEntity.PcItemId = Int32.Parse(item.Cells[8].Value.ToString());

                                int detailId = new RefundProductDAO().Add(ProductEntity);
                                //if (detailId < 1)
                                //{
                                //    MessageBox.Show("POSsible", "Error Occured.");
                                //    throw new Exception();
                                //}

                                #region REVERSE USED/USEDUP
                                double retQty = ProductEntity.qty;
                                List<Transaction> lstTrn = new List<Transaction>();

                                if (ProductEntity.PcItemId >= 0)
                                {
                                    lstTrn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND (T.[UsedQty]>0) AND T.[StoreId]=" + MDIParent.storeId
                                        + " AND T.[productId]=" + ProductEntity.productId, "T.[TransDate] DESC, T.TransId DESC");
                                    foreach (Transaction trn in lstTrn)
                                    {
                                        if (retQty > 0)
                                        {
                                            if (retQty > trn.UsedQty)
                                            {
                                                retQty -= trn.UsedQty;
                                                oTransactionDAO.ExecuteQuery("UPDATE [Transaction] SET [UsedQty]=0 WHERE [TransId]=" + trn.TransId);
                                            }
                                            else
                                            {
                                                oTransactionDAO.ExecuteQuery("UPDATE [Transaction] SET [UsedQty]=([UsedQty] - " + retQty + ") WHERE [TransId]=" + trn.TransId);
                                                retQty = 0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lstTrn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND (T.[UsedQty]>0) AND T.[StoreId]=" + MDIParent.storeId
                                        + " AND T.[productId]=" + ProductEntity.productId, "T.[TransDate] DESC, T.TransId DESC");

                                    foreach (Transaction trn in lstTrn)
                                    {
                                        if (retQty > 0)
                                        {
                                            if (trn.ProductId == ProductEntity.productId)
                                            {
                                                if (retQty > trn.UsedQty)
                                                {
                                                    retQty -= trn.UsedQty;
                                                    oTransactionDAO.ExecuteQuery("UPDATE [Transaction] SET [UsedQty]=0 WHERE [TransId]=" + trn.TransId);
                                                }
                                                else
                                                {
                                                    oTransactionDAO.ExecuteQuery("UPDATE [Transaction] SET [UsedQty]=([UsedQty] - " + retQty + ") WHERE [TransId]=" + trn.TransId);
                                                    retQty = 0;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                double pcsPerCrtn = oTransactionDAO.ExecuteScalar("SELECT [qtyInOrder] FROM [tblProduct] WHERE [productId]=" + trn.ProductId);
                                                double crtnretQty = Convert.ToDouble(string.Format("{0:###0.00}", (retQty / pcsPerCrtn)));

                                                if (crtnretQty > trn.UsedQty)
                                                {
                                                    retQty -= trn.UsedQty * pcsPerCrtn;
                                                    oTransactionDAO.ExecuteQuery("UPDATE [Transaction] SET [UsedQty]=0 WHERE [TransId]=" + trn.TransId);
                                                }
                                                else
                                                {
                                                    oTransactionDAO.ExecuteQuery("UPDATE [Transaction] SET [UsedQty]=([UsedQty] - " + crtnretQty + ") WHERE [TransId]=" + trn.TransId);
                                                    retQty = 0;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion

                                #region Transaction
                                Transaction TransEntity = new Transaction();
                                TransEntity.EnteredBy = MDIParent.userId;
                                TransEntity.EnteredTime = Convert.ToDateTime(RefundEntity.UpdatedTime);
                                TransEntity.ParentId = masterId;
                                TransEntity.ProductId = ProductEntity.productId;
                                TransEntity.Quantity = Convert.ToDouble(ProductEntity.qty);
                                TransEntity.TransDate = RefundEntity.refundDate.Value;
                                TransEntity.TransType = 3; // 3 FOR REFUND
                                TransEntity.UnitPrice = Convert.ToDouble(ProductEntity.UnitPrice);
                                TransEntity.StoreId = MDIParent.storeId;
                                oTransactionDAO.Add(TransEntity);
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("POSsible", "Error Occured.");
                        return;
                    }
                    MessageBox.Show("Refunded successfully", "POSsible");
                    clear_form();
                }
                else
                    MessageBox.Show("Nothing Added to Refunded List", "POSsible");

                UtilsDAO.CommitTransaction(trans);
            }
            catch
            {
                MessageBox.Show("Error while refund", "POSsible: Error");
            }
            finally
            {
                if (DbProviderHelper.IsInTransaction)
                {
                    UtilsDAO.RollbackTransaction(trans);
                }
            }

            #endregion
        }

        public void bindRefundGrid(int InvoiceId)
        {
            List<InvoiceProduct> lst = new InvoiceProductDAO().InvoiceProduct_GetDynamic("IP.[invoiceId] ='" + InvoiceId + "'", String.Empty);

            dgvRefund.Rows.Clear();
            dTotal = 0;
            int noOfRows = 0;

            foreach (InvoiceProduct item in lst)
            {
                if (item.ReturnedQty < item.qty)
                {
                    double dSubTotal = 0;
                    dgvRefund.Rows.Add(false, item.productName, item.qty.ToString(), item.unitPrice.ToString(), item.ReturnedQty, "", dSubTotal.ToString(), item.productId, item.PcItemId);
                    noOfRows += 1;
                }
            }

            txtTotal.Text = dTotal.ToString();

            if (noOfRows == 0)
                MessageBox.Show("No Product Found!", "POSsible");
        }

        public void bindInvoiceCombo(int cusId)
        {
            List<Invoice> lst;

            if (cusId > 0)
                lst = new InvoiceDAO().Invoice_GetDynamic("I.[customerId]='" + cusId + "'", "");
            else
                lst = new InvoiceDAO().Invoice_GetAll();

            if (lst.Count > 0)
            {
                cboInvoiceId.DataSource = lst;
                cboInvoiceId.SelectedIndex = -1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dpRefundDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dtRefundDate = dpRefundDate.Value;
            }
            catch (Exception xcp)
            {
                MessageBox.Show("An Error has occured");
            }

        }

        private void cboInvoiceId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvRefund.Rows.Clear();
            if (cboInvoiceId.SelectedIndex > -1)
            {
                int iInvoiceId = Convert.ToInt32(cboInvoiceId.SelectedValue);
                Invoice inv = new InvoiceDAO().Invoice_GetById(iInvoiceId);
                if (cboCustomer.SelectedIndex < 0)
                    cboCustomer.SelectedValue = inv.customerId;
                bindRefundGrid(iInvoiceId);

                chkChangeCustomer.Checked = false;
                chkChangeCustomer.Visible = true;
            }
        }

        private void frmRefund_Load(object sender, EventArgs e)
        {

        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            cboInvoiceId.DataSource = new List<Invoice>();
            dgvRefund.Rows.Clear();
            try
            {
                List<Invoice> lstInvoice;
                string date = dtPurchaseDate.Value.Date.ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(cboCustomer.Text.Trim()))
                    lstInvoice = new InvoiceDAO().Invoice_GetDynamic("dbo.TrimTime([invoiceDate]) = '" + date + "'", "");
                else
                    lstInvoice = new InvoiceDAO().Invoice_GetDynamic("dbo.TrimTime([invoiceDate]) = '" + date + "' AND I.[customerId]='" + cboCustomer.SelectedValue.ToString() + "'", "");

                if (lstInvoice.Count > 0)
                {
                    cboInvoiceId.DataSource = lstInvoice;
                    cboInvoiceId.DisplayMember = "InvoiceNo";
                    cboInvoiceId.ValueMember = "invoiceId";
                    cboInvoiceId.SelectedIndex = -1;
                    cboInvoiceId.Text = string.Empty;
                    chkChangeCustomer.Checked = false;
                    chkChangeCustomer.Visible = false;
                    MessageBox.Show(lstInvoice.Count + " Invoice No. loaded in Invoice No. Combo Box", "POSsible");
                }
                else
                    MessageBox.Show("No Invoice found!", "POSsible");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:::" + ex.ToString());
            }
        }

        private void clear_form()
        {
            cboInvoiceId.SelectedIndex = -1;
            cboCustomer.SelectedIndex = -1;
            dtPurchaseDate.Value = DateTime.Today;
            dgvRefund.Rows.Clear();
            txtTotal.Text = "0";
            chkChangeCustomer.Checked = false;
            chkChangeCustomer.Visible = false;
            cmbCustomerNew.SelectedIndex = -1;
        }

        private void dgvRefund_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calTotal();
        }

        private double calTotal()
        {
            double total = 0;
            foreach (DataGridViewRow item in dgvRefund.Rows)
            {
                if (item.Cells[0].Value.Equals(true))
                {
                    double retQty;
                    try
                    {
                        retQty = (string.IsNullOrEmpty(item.Cells[5].Value.ToString())) ? Convert.ToDouble(item.Cells[2].Value.ToString()) : Convert.ToDouble(item.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        retQty = 0;
                    }
                    item.Cells[5].Value = retQty;

                    if (string.IsNullOrEmpty(item.Cells[3].Value.ToString()))
                        item.Cells[3].Value = 0;

                    double sTotal = retQty * Convert.ToDouble(item.Cells[3].Value);
                    item.Cells[6].Value = sTotal;
                    total += sTotal;
                }
            }
            txtTotal.Text = total.ToString();
            return total;
        }

        private void dgvRefund_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRefund.IsCurrentCellDirty)
            {
                dgvRefund.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void chkChangeCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangeCustomer.Checked)
            {
                dgvRefund.Visible = false;
                lblTotal.Visible = false;
                txtTotal.Visible = false;
            }
            else
            {
                dgvRefund.Visible = true;
                lblTotal.Visible = true;
                txtTotal.Visible = true;
            }
        }
    }
}