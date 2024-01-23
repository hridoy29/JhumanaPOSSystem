using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;
using System.Data.Common;
using POSsible.Reports;

namespace POSsible
{
    public partial class frmSaleEdit : Form
    {
        public bool loadDone = false;
        Product ProductFromList = new Product();
        ProductDAO ProductDAO = new ProductDAO();
        InvoiceDAO invoiceDAO = new InvoiceDAO();
        InvoiceProductDAO invoiceProductDAO = new InvoiceProductDAO();
        TransactionDAO oTransactionDAO = new TransactionDAO();
        List<RemovedProductWithRefundQty> lstRPWRQ = new List<RemovedProductWithRefundQty>();

        public frmSaleEdit()
        {
            InitializeComponent();
        }

        private void cmbCustomerBind()
        {
            List<tblCustomer> lstCustomer = new CustomerDAO().Customer_GetAll();
            if (lstCustomer.Count > 0)
            {
                cmbCustomer.DataSource = lstCustomer;
                cmbCustomer.SelectedIndex = -1;
            }
        }

        private void BindItem()
        {
            List<Product> lProductList = ProductDAO.Product_GetDynamic("1=1", "name");
            cmbItem.DataSource = lProductList;
            cmbItem.SelectedIndex = -1;
        }

        private void frmSaleEdit_Load(object sender, EventArgs e)
        {
            cmbCustomerBind();
            BindItem();
            loadDone = true;
            dtFrom.Select();
        }

        private void Clear()
        {
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            dtSaleDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = -1;
            cmbCustomer.Text = string.Empty;
            txtInvoiceNo.Clear();
            dgvSearchResults.Rows.Clear();
            txtGrandTotal.Clear();
            txtTotalDiscount.Clear();
            dtFrom.Select();
        }

        private void ClearDetail()
        {
            cmbItem.SelectedIndex = -1;
            cmbItem.Text = string.Empty;
            txtSaleQty.Clear();
            txtUnitPrice.Clear();
            txtUnitDisc.Clear();
            dgvItem.Rows.Clear();
            lstRPWRQ = new List<RemovedProductWithRefundQty>();
        }

        private void CalculateGrandTotal()
        {
            double dGrandTotal = 0.0;
            for (int i = 0; i < dgvItem.Rows.Count; i++)
            {
                dGrandTotal = dGrandTotal + double.Parse(dgvItem.Rows[i].Cells[4].Value.ToString());
            }
            txtGrandTotal.Text = dGrandTotal.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Invoice> lstInvoice = new List<Invoice>();

            if (chkFattura.Checked)
            {
                lstInvoice = invoiceDAO.Fattura_GetForSync();
            }
            else
            {
                string from = dtFrom.Value.ToString("yyyy-MM-dd");
                string to = dtTo.Value.ToString("yyyy-MM-dd");
                string query = "dbo.TrimTime(I.invoiceDate) BETWEEN dbo.TrimTime('" + from + "') AND dbo.TrimTime('" + to + "')";
                if (cmbCustomer.SelectedIndex > -1)
                    query += " AND I.[customerId] = " + cmbCustomer.SelectedValue;
                if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
                    query += " AND I.[InvoiceNo] = '" + txtInvoiceNo.Text.Trim() + "'";

                lstInvoice = invoiceDAO.Invoice_GetDynamic(query, "invoiceDate");
            }

            if (lstInvoice.Count > 0)
            {
                dgvSearchResults.Rows.Clear();

                foreach (Invoice item in lstInvoice)
                {
                    dgvSearchResults.Rows.Add(item.invoiceId, item.InvoiceNo, item.invoiceDate, item.CustomerName, item.status, item.TotalPrice, item.invoiceDate, item.description, item.customerId, item.DiscountGiven);
                }

                dgvSearchResults.Columns[2].DefaultCellStyle.Format = "dd/MMM/yyyy";
                ClearDetail();
                dtSaleDate.Value = DateTime.Now;
                txtGrandTotal.Clear();
            }
            else
            {
                MessageBox.Show("No Sale Found");
            }
        }

        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                #region LOAD PRODUCT GRID
                int invoiceId = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                dtSaleDate.Value = Convert.ToDateTime(dgvSearchResults.Rows[e.RowIndex].Cells[6].Value);
                cmbCustomer.SelectedValue = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[8].Value);
                txtInvoiceNo.Text = dgvSearchResults.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTotalDiscount.Text = dgvSearchResults.Rows[e.RowIndex].Cells[9].Value.ToString();
                dgvItem.Rows.Clear();
                List<InvoiceProduct> iPList = new List<InvoiceProduct>();

                if (dgvSearchResults.Rows[e.RowIndex].Cells[7].Value.ToString() == "Fattura")
                    iPList = invoiceProductDAO.FatturaDetail_GetForSync(Convert.ToInt64(invoiceId));
                else
                    iPList = invoiceProductDAO.InvoiceProduct_GetDynamic("IP.[invoiceId]= " + invoiceId, "");

                if (iPList.Count > 0)
                {
                    foreach (InvoiceProduct item in iPList)
                    {
                        dgvItem.Rows.Add(item.productName, (string.Format("{0:###0.00}", item.qty)), (string.Format("{0:##0.00}", item.unitPrice)),
                        (string.Format("{0:###0.00}", item.qty)) + "@" + (string.Format("{0:##0.00}", item.unitPrice)),
                        string.Format("{0:##0.00}", item.unitPrice * item.qty), item.productId, item.categorytId, item.Status, item.PcItemId, item.PcsPerCrtn, item.ReturnedQty);
                    }
                }

                CalculateGrandTotal();
                #endregion
            }

            else if (e.ColumnIndex == 11)
            {
                #region DELETE SALE
                string invType = dgvSearchResults.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (dgvSearchResults.Rows[e.RowIndex].Cells[7].Value.ToString() == "Fattura")
                {
                    MessageBox.Show("Cannot Delete Fattura Invoices", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string invNo = dgvSearchResults.Rows[e.RowIndex].Cells[1].Value.ToString();
                DialogResult dg = MessageBox.Show("Are you sure you want to delete Invoice " + invNo + "?", "Delete Sale", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    int deleteId = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                    try
                    {
                        List<Refund> lstRefund = new RefundDAO().Refund_GetDynamic("[invoiceId]=" + deleteId, string.Empty);
                        if (lstRefund.Count > 0)
                        {
                            MessageBox.Show("Cannot Delete as Products Refunded from this Sale", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        int result = invoiceDAO.Delete(deleteId);
                        if (result > 0)
                        {
                            dgvSearchResults.Rows.RemoveAt(e.RowIndex);
                            ClearDetail();
                            MessageBox.Show("Sale Deleted Successfully", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Sale could not be Deleted", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ". Sale could not be Deleted", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
            }

            else if (e.ColumnIndex == 12)
            {
                int invoiceId = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                new frmRptViewer(invoiceId).ShowDialog();
            }
        }

        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbItem.SelectedIndex > -1 && loadDone && btnAdd.Enabled && e.KeyChar == 13)
            {
                txtSaleQty.Focus();
            }
        }

        private void cmbItem_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex > -1 && loadDone && btnAdd.Enabled)
            {
                int productId = Convert.ToInt32(cmbItem.SelectedValue);
                int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
                ProductFromList = ProductDAO.Product_GetByIdAndCustomer(productId, customerId);

                double uPrice = 0; Transaction trn = new Transaction();

                if (ProductFromList.qtyInStock == 0)
                {
                    trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + ProductFromList.productId, "").LastOrDefault();
                }
                else if (ProductFromList.qtyInStock > 0)
                {
                    trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + ProductFromList.productId + ", " + ProductFromList.qtyInStock + ")", "").LastOrDefault();

                    if (trn.ProductId == ProductFromList.qtyInStock)
                    {
                        trn.UnitPrice = trn.UnitPrice * (double)ProductFromList.qtyInOrder;
                    }
                }
                else if (ProductFromList.qtyInStock == -3)
                {
                    trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + ProductFromList.productId + ", (SELECT [productId] FROM [tblProduct] WHERE [qtyInStock]=" + ProductFromList.productId + "))", "").LastOrDefault();
                    if (trn != null && trn.ProductId != ProductFromList.productId)
                    {
                        double pcsPerCrtn = oTransactionDAO.ExecuteScalar("SELECT [qtyInOrder] FROM [tblProduct] WHERE [productId]=" + trn.ProductId);
                        trn.UnitPrice = trn.UnitPrice / pcsPerCrtn;
                    }
                }

                if (ProductFromList.madeIn == "Fixed")
                {
                    uPrice = ProductFromList.unitCost.Value;
                }
                else
                {
                    try
                    {
                        uPrice = (trn.UnitPrice + ProductFromList.unitCost.Value);
                    }
                    catch (Exception)
                    {
                        uPrice = 0;
                    }
                }

                txtUnitPrice.Text = string.Format("{0:##0.00}", uPrice);
                txtUnitDisc.Text = string.Format("{0:##0.00}", 0);
                txtSaleQty.Text = "1";
                txtSaleQty.Focus();
            }
        }

        private void txtSaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtSaleQty.Text);
            if (e.KeyChar == 13)
                txtUnitPrice.Focus();
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtUnitPrice.Text);
            if (e.KeyChar == 13 && txtUnitDisc.Enabled)
                txtUnitDisc.Focus();
        }

        private void txtUnitDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtUnitDisc.Text);
            if (e.KeyChar == 13 && btnAdd.Enabled)
                btnAdd.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Helper.ValidateNotEmpty(new List<Control>() { cmbItem, txtSaleQty, txtUnitPrice, txtUnitDisc }))
            {
                ProductFromList = ProductDAO.Product_GetDynamic("[productId]=" + cmbItem.SelectedValue, "").FirstOrDefault();
                //double stockQty = Convert.ToDouble(string.Format("{0:###0.00}", (oTransactionDAO.ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + ProductFromList.productId + ")"))));
                //if (stockQty <= 0)
                //{
                //    MessageBox.Show("No quantity in stock", "POSsible");
                //    return;
                //}

                for (int i = 0; i < dgvItem.Rows.Count; i++)
                {
                    if (dgvItem.Rows[i].Cells[5].Value.ToString() == cmbItem.SelectedValue.ToString())
                    {
                        MessageBox.Show("This Product already added");
                        return;
                    }
                }

                //if (!ProductFromList.ticketType.Value && txtSaleQty.Text.Contains('.'))
                //{
                //    MessageBox.Show("Fractional Quantity not allowed for Non Variable Weight Product", "POSsible");
                //    txtSaleQty.Focus();
                //    return;
                //}
                if (Convert.ToDouble(txtUnitDisc.Text) > Convert.ToDouble(txtUnitPrice.Text))
                {
                    MessageBox.Show("Unit Discount cannot be more than Unit Price", "POSsible");
                    txtUnitDisc.Focus();
                    return;
                }

                Product product = new Product();
                double qty = 1;
                double uPrice = 0;
                double uDisc = 0;
                int rowIndex = dgvItem.Rows.Count;

                product = ProductFromList;
                qty = Convert.ToDouble(string.Format("{0:###0.00}", txtSaleQty.Text));
                uPrice = Convert.ToDouble(string.Format("{0:##0.00}", txtUnitPrice.Text));
                uDisc = Convert.ToDouble(string.Format("{0:##0.00}", txtUnitDisc.Text));

                if (product.ticketType.Value)
                {
                    product.name += " (" + product.UnitMeasureName + ")";
                }

                for (int i = 0; i < dgvItem.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvItem.Rows[i].Cells["ItemId"].Value.ToString()) == product.productId)
                    {
                        double currQty = Convert.ToDouble(dgvItem.Rows[i].Cells["qty"].Value.ToString());
                        qty += currQty;
                        rowIndex = i;
                        uPrice = Convert.ToDouble(dgvItem.Rows[i].Cells["price"].Value);
                        uDisc = Convert.ToDouble(dgvItem.Rows[i].Cells["discount"].Value);
                        dgvItem.Rows.RemoveAt(i);
                    }
                }

                double stockQty = Convert.ToDouble(string.Format("{0:###0.00}", (oTransactionDAO.ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + product.productId + ")"))));
                if (qty > stockQty)
                {
                    MessageBox.Show("Not enough quantity in stock \nProduct Available : " + stockQty, "POSsible");
                    ProductFromList = new Product();
                    return;
                }

                if (uPrice == 0 && uDisc == 0)
                {
                    if (product.madeIn == "Fixed")
                    {
                        uPrice = Convert.ToDouble(string.Format("{0:##0.00}", product.unitCost));
                    }
                    else
                    {
                        Transaction trn = new Transaction();

                        if (product.qtyInStock == 0)
                        {
                            trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + product.productId, "").LastOrDefault();
                            if (trn == null)
                            {
                                MessageBox.Show("No quantity in stock", "POSsible");
                                ProductFromList = new Product();
                                return;
                            }
                        }
                        else if (product.qtyInStock > 0)
                        {
                            trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + product.productId + ", " + product.qtyInStock + ")", "").LastOrDefault();

                            if (trn == null)
                            {
                                MessageBox.Show("No quantity in stock", "POSsible");
                                ProductFromList = new Product();
                                return;
                            }

                            if (trn.ProductId == product.qtyInStock)
                                trn.UnitPrice = trn.UnitPrice * (double)product.qtyInOrder;
                        }
                        else if (product.qtyInStock == -3)
                        {
                            trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + product.productId + ", (SELECT [productId] FROM [tblProduct] WHERE [qtyInStock]=" + product.productId + "))", "").LastOrDefault();

                            if (trn == null)
                            {
                                MessageBox.Show("No quantity in stock", "POSsible");
                                ProductFromList = new Product();
                                return;
                            }

                            if (trn.ProductId != product.productId)
                            {
                                double pcsPerCrtn = oTransactionDAO.ExecuteScalar("SELECT [qtyInOrder] FROM [tblProduct] WHERE [productId]=" + trn.ProductId);
                                trn.UnitPrice = trn.UnitPrice / pcsPerCrtn;
                            }
                        }

                        double wsPrice = (trn.UnitPrice + product.unitPrice.Value);
                        double spPrice = (trn.UnitPrice + product.promoUnitPrice.Value);
                        uPrice = (trn.UnitPrice + product.unitCost.Value);
                    }
                }

                dgvItem.Rows.Insert(rowIndex, product.name, (string.Format("{0:###0.00}", qty)), (string.Format("{0:##0.00}", uPrice)),
                    (string.Format("{0:###0.00}", qty)) + " " + product.UnitMeasureName + "@" + (string.Format("{0:##0.00}", uPrice)),
                    string.Format("{0:##0.00}", uPrice * qty), product.productId, product.categorytId, uDisc, product.qtyInStock, product.qtyInOrder);

                cmbItem.SelectedIndex = -1;
                cmbItem.Text = string.Empty;
                txtSaleQty.Clear();
                txtUnitPrice.Clear();
                txtUnitDisc.Clear();
                CalculateGrandTotal();
                ProductFromList = new Product();
                cmbItem.Focus();
            }
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                string itemName = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                DialogResult dg = MessageBox.Show("Are you sure you want to remove product " + itemName + "?", "Remove", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    if (Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[10].Value) > 0)
                    {
                        RemovedProductWithRefundQty obj = new RemovedProductWithRefundQty();
                        obj.ProductId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[5].Value);
                        obj.SoldQty = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[1].Value);
                        obj.ReturnedQty = Convert.ToDouble(dgvItem.Rows[e.RowIndex].Cells[10].Value);
                        obj.ProductName = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString(); ;
                        lstRPWRQ.Add(obj);
                    }
                    dgvItem.Rows.RemoveAt(e.RowIndex);
                    CalculateGrandTotal();
                }
            }
            else
            {
                //int iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvItem.Rows[e.RowIndex];
                if (ObjDGVRow.Cells[0].Value != null)
                {
                    cmbItem.SelectedValue = Convert.ToInt32(ObjDGVRow.Cells[5].Value);
                    txtSaleQty.Text = ObjDGVRow.Cells[1].Value.ToString();
                    txtUnitPrice.Text = ObjDGVRow.Cells[2].Value.ToString();
                    txtUnitDisc.Text = string.Format("{0:##0.00}", ObjDGVRow.Cells[7].Value);
                    dgvItem.Rows.RemoveAt(e.RowIndex);
                    CalculateGrandTotal();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count == 0 || dgvSearchResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Product to Save", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            double totalAmt = default(double);
            int invoiceId = Convert.ToInt32(dgvSearchResults.SelectedRows[0].Cells[0].Value);
            DateTime saleDate = dtSaleDate.Value;
            List<InvoiceProduct> lstProducts = new List<InvoiceProduct>();

            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                oInvoiceProduct.invoiceId = invoiceId;
                oInvoiceProduct.productId = Convert.ToInt32(item.Cells["ItemId"].Value);
                oInvoiceProduct.qty = Convert.ToDouble(String.Format("{00:00.00}", item.Cells["qty"].Value));
                oInvoiceProduct.unitPrice = Convert.ToDouble(String.Format("{00:00.00}", item.Cells["price"].Value));
                oInvoiceProduct.Status = (String.Format("{00:00.00}", item.Cells["discount"].Value));
                oInvoiceProduct.EnteredTime = DateTime.Now;
                oInvoiceProduct.Updatedatime = DateTime.Now;
                lstProducts.Add(oInvoiceProduct);
                totalAmt += (double)oInvoiceProduct.qty * (double)oInvoiceProduct.unitPrice;
            }

            foreach (RemovedProductWithRefundQty item in lstRPWRQ)
            {
                InvoiceProduct chkInvoiceProduct = lstProducts.FirstOrDefault(p => p.productId == item.ProductId);
                if (chkInvoiceProduct == null)
                {
                    MessageBox.Show("Product " + item.ProductName + " must be in list as it has Returned Qty", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (chkInvoiceProduct.qty < item.ReturnedQty)
                {
                    MessageBox.Show("Product " + item.ProductName + ": Sale Qty (" + chkInvoiceProduct.qty + ") cannot be less than Returned Qty(" + item.ReturnedQty + ")", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                DbProviderHelper.Trans = trans;
                DbProviderHelper.IsInTransaction = true;

                if (dgvSearchResults.SelectedRows[0].Cells[7].Value.ToString() == "Fattura")
                {
                    Invoice oInvoice = new Invoice();
                    oInvoice.InvoiceNo = dgvSearchResults.SelectedRows[0].Cells[1].Value.ToString();
                    oInvoice.shiftId = MDIParent.shiftId;
                    oInvoice.userId = MDIParent.userId;
                    oInvoice.customerId = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    oInvoice.StoreId = MDIParent.storeId;
                    oInvoice.invoiceDate = dtSaleDate.Value;
                    oInvoice.SaleType = "Retail";
                    oInvoice.TotalPrice = totalAmt;
                    oInvoice.TotalGST = 0;
                    oInvoice.CashAmt = 0;
                    oInvoice.CardAmt = 0;
                    oInvoice.changeGiven = 0;
                    oInvoice.DiscountGiven = "0.00";
                    oInvoice.description = "desc";
                    oInvoice.status = "Credit";
                    oInvoice.updatedTime = DateTime.Now;
                    oInvoice.updatedBy = MDIParent.userId;
                    oInvoice.CardType = "American Express";
                    oInvoice.CardNo = "Card No.";
                    oInvoice.CardHolderName = "Name";
                    oInvoice.CusPrevBalance = 0;
                    oInvoice.CF1 = "";
                    oInvoice.CF2 = "1";
                    oInvoice.CF3 = "1";
                    oInvoice.CF4 = invoiceId.ToString();

                    int newId = invoiceDAO.Add(oInvoice);

                    if (newId > 0)
                    {
                        foreach (InvoiceProduct item in lstProducts)
                        {
                            item.invoiceId = newId;
                            invoiceProductDAO.Add(item);
                        }
                    }
                }
                else
                {
                    string disc = string.IsNullOrEmpty(txtTotalDiscount.Text) ? "0.00" : txtTotalDiscount.Text;
                    int uId = invoiceDAO.UpdateTotalPrice(invoiceId, totalAmt, saleDate, txtInvoiceNo.Text.Trim(), disc);
                    if (uId > 0)
                    {
                        int delId = invoiceProductDAO.DeleteByInvoiceId(invoiceId);
                        if (delId > 0)
                        {
                            foreach (InvoiceProduct item in lstProducts)
                            {
                                invoiceProductDAO.Add(item);
                            }

                            if (dgvSearchResults.SelectedRows[0].Cells[4].Value.ToString() == "Cash")
                            {
                                new CreditCollectionDAO().UpdatePaidAmount(invoiceId, totalAmt, saleDate);
                            }
                        }
                    }
                }

                UtilsDAO.CommitTransaction(trans);

                ClearDetail();
                Clear();
                MessageBox.Show("Sale Updated Successfully", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    string showPV = "Yes";
                    Reports.rptInvoiceForCreditSale report1 = new Reports.rptInvoiceForCreditSale();
                    Helper.SetDataBaseLogonForCrReport(report1);
                    DataTable dt = invoiceDAO.Report_InvoiceForCreditSale(invoiceId, "Yes", false);
                    report1.SetDataSource(dt);
                    report1.SetParameterValue("@InvoiceId", invoiceId);
                    report1.SetParameterValue("@SaleType", showPV);
                    report1.SetParameterValue("@ShowRetailPrice", false);

                    report1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    report1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

                    PrintDialog printDialog = new PrintDialog();

                    DialogResult dgResult = printDialog.ShowDialog();

                    if (dgResult == DialogResult.OK)
                    {
                        report1.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                        report1.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Cannot Print Invoice", "Message");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured. \nCould not Edit Sale", "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ClearDetail();
            Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class RemovedProductWithRefundQty
    {
        public int ProductId { get; set; }
        public Nullable<Double> SoldQty { get; set; }
        public double ReturnedQty { get; set; }
        public String ProductName { get; set; }
    }
}
