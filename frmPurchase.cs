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
using System.Data.Common;

namespace POSsible
{
    public partial class frmPurchase : Form
    {
        private int iRowIndex = 0;
        private int cboItemCount = 0;
        private int purchaseID = 0;
        int SupAcLgrId = -1;
        SupplierDAO oSupplierDAO = new SupplierDAO();
        PurchaseDAO oPurchaseDAO = new PurchaseDAO();
        PurchaseProductDAO oPurchaseProductDAO = new PurchaseProductDAO();
        TransactionDAO oTransactionDAO = new TransactionDAO();
        bool loadDone = false;
        private int PURAcLgrId = 0;
        private int CIHAcLgrId = 0;
        private double prvGrandTotal = 0;

        public frmPurchase()
        {
            InitializeComponent();
        }

        private void cmbSupplierBind()
        {
            List<Supplier> lSupplierList = oSupplierDAO.Supplier_GetAll();
            cmbSupplier.DataSource = lSupplierList;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierId";
            cmbSupplier.SelectedIndex = -1;

            List<Supplier> lSupplierSearchList = oSupplierDAO.Supplier_GetAll();
            cmbSupplierSearch.DataSource = lSupplierSearchList;
            cmbSupplierSearch.DisplayMember = "SupplierName";
            cmbSupplierSearch.ValueMember = "SupplierId";
            cmbSupplierSearch.SelectedIndex = -1;
        }

        private void ChangeSupplier()
        {
            if (cmbSupplier.SelectedIndex < 0 || loadDone == false) return;
            txtSupplierId.Text = cmbSupplier.SelectedValue.ToString();
            //AccountLedger ALS = new AccountLedgerDAO().AccountLedger_GetDynamic("AL.[AccountLedgerId]=(SELECT CAST([GLCode] AS INT) FROM [tblSupplier] WHERE [SupplierId]=" + cmbSupplier.SelectedValue + ")", "").FirstOrDefault();
            //if (ALS == null)
            //{
            //    Alert("Ledger Account not Found for this Supplier.");
            //    btnDelete.Enabled = false;
            //    return;
            //}
            //SupAcLgrId = ALS.AccountLedgerId;
            btnDelete.Enabled = true;
        }

        private void cmbItemBind()
        {
            List<Product> lProductList = new ProductDAO().Product_GetDynamic("[qtyInStock] != -3", "name");
            cboItemSelect.DataSource = lProductList;
            cboItemSelect.DisplayMember = "name";
            cboItemSelect.ValueMember = "ProductId";
            cboItemSelect.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ResetAll()
        {
            btnAdd.Tag = "Add";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Text = "SAVE";
            btnExit.Enabled = true;

            dtpPurchaseDate.Text = DateTime.Now.Date.ToShortDateString();
            txtSupplierId.Text = "";
            txtReceiver.Text = "";
            //cmbReceiver.SelectedIndex = -1;
            //cmbReference.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            cmbSupplierSearch.SelectedIndex = -1;
            cboItemSelect.SelectedIndex = -1;
            txtSalesman.Clear();
            txtInvoiceNo.Clear();
            rbCash.Checked = true;
            txtInvoiceNoSearch.Clear();
            dtpExpireDate.Text = DateTime.Now.Date.ToShortDateString();
            dtFromSearch.Text = DateTime.Now.Date.ToShortDateString();
            dtToSearch.Text = DateTime.Now.Date.ToShortDateString();
            txtPurchaseQty.Text = "";
            txtUnitCost.Text = "";
            txtSubTotal.Text = "";
            txtGrandTotal.Text = "";
            dgvItem.Rows.Clear();

            //SEARCH CLEAR
            txtInvoiceNoSearch.Clear();
            cmbSupplierSearch.SelectedIndex = -1;
            dtToSearch.Value = DateTime.Now.Date;
            dtFromSearch.Value = DateTime.Now.Date;
            dgvSearchResults.Rows.Clear();

            txtMemoNo.Text = "MMN/" + DateTime.Now.DayOfYear + DateTime.Now.Millisecond;
            prvGrandTotal = 0;
            btnSupplierAdd.Enabled = cmbSupplier.Enabled = rbCash.Enabled = rbCredit.Enabled = true;
            txtSalesman.Select();
        }

        private void AddMode()
        {
            btnAdd.Tag = "Add";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Text = "SAVE";
            btnExit.Enabled = true;

            cboItemSelect.SelectedIndex = -1;
            dtpExpireDate.Text = DateTime.Now.Date.ToShortDateString();
            txtPurchaseQty.Text = "";
            txtUnitCost.Text = "";
            txtSubTotal.Text = "";

            dgvItem.Rows[0].Selected = false;
            cboItemSelect.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void txtPurchaseQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;

            if (iCode == 13)
                txtUnitCost.Focus();

            if ((iCode < 48 && iCode != 8) || iCode > 57)
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckValidityForAddRow())
            {
                try
                {
                    if (btnAdd.Tag == "Add")
                    {
                        for (int i = 0; i < dgvItem.Rows.Count; i++)
                        {
                            if (dgvItem.Rows[i].Cells[6].Value.ToString() == cboItemSelect.SelectedValue.ToString())
                            {
                                Alert("This Product already added");
                                return;
                            }
                        }

                        int itemId = Convert.ToInt32(cboItemSelect.SelectedValue);
                        Transaction t = new TransactionDAO().Transaction_GetDynamic("T.[TransType]=0 AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + itemId, "").FirstOrDefault();
                        if (t != null)
                        {
                            if (t.TransDate.Date > dtpPurchaseDate.Value)
                            {
                                Alert("Purchase Date must be " + t.TransDate.ToString("dd/MM/yyyy") + " or Later.");
                                return;
                            }
                        }

                        //string[] productName = Regex.Split(cboItemSelect.Text, "-- ");
                        dgvItem.Rows.Add(cboItemSelect.Text + " Lt:" + dtpExpireDate.Text, dtpExpireDate.Text, txtPurchaseQty.Text, lotNumber.Text, txtUnitCost.Text, txtSubTotal.Text, cboItemSelect.SelectedValue.ToString());
                    }

                    #region UPDATING PURCHASE

                    else
                    {
                        //check return & used qty AND VOUCHERS
                        int rowCount = dgvItem.Rows.Count;
                        string[] productName = Regex.Split(cboItemSelect.Text, "-- ");
                        dgvItem.Rows.Insert(rowCount, productName[1], dtpExpireDate.Text, txtPurchaseQty.Text, txtUnitCost.Text, txtSubTotal.Text, cboItemSelect.SelectedValue.ToString());
                    }

                    #endregion

                    CalculateGrandTotal();
                    dtpExpireDate.Value = DateTime.Now.Date;
                    txtPurchaseQty.Clear();
                    txtUnitCost.Clear();

                    cboItemSelect.SelectedIndex = -1;
                    //btnAdd.Tag = "Add";
                }
                catch
                {

                }
            }

            cboItemSelect.Focus();
        }

        private Boolean CheckValidityForAddRow()
        {
            bool bReturn = true;

            if (cboItemSelect.Text.Trim() == "")
            {
                Alert("Select item.");
                cboItemSelect.Focus();
                bReturn = false;
            }

            if (txtPurchaseQty.Text.Trim() == "")
            {
                Alert("Enter purchase quantity.");
                txtPurchaseQty.Focus();
                bReturn = false;
            }

            if (txtUnitCost.Text.Trim() == "")
            {
                Alert("Enter unit cost.");
                txtUnitCost.Focus();
                bReturn = false;
            }

            return bReturn;
        }

        private double CalculateGrandTotal()
        {
            double dGrandTotal = 0.0;
            for (int i = 0; i < dgvItem.Rows.Count; i++)
            {
                dGrandTotal = dGrandTotal + double.Parse(dgvItem.Rows[i].Cells[5].Value.ToString());
            }
            txtGrandTotal.Text = dGrandTotal.ToString();
            return dGrandTotal;
        }

        private void txtUnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;

            if (iCode == 13)
                btnAdd.PerformClick();

            if ((iCode < 48 && iCode != 8 && iCode != 46) || iCode > 57)
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchaseQty.Text.Trim() != "" || txtUnitCost.Text.Trim() != "")
            {
                int iQty = 0;
                double dCost = 0.0;

                if (txtPurchaseQty.Text.Trim() != "")
                    iQty = int.Parse(txtPurchaseQty.Text.Trim());

                if (txtUnitCost.Text.Trim() != "")
                    dCost = double.Parse(txtUnitCost.Text.Trim());

                double dSubtotal = iQty * dCost;
                txtSubTotal.Text = dSubtotal.ToString();
            }
        }

        //SAVE CLICK
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                DbTransaction trans = UtilsDAO.BeginTransaction();

                try
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    #region Purchase Master
                    Purchase MEntity = new Purchase();
                    MEntity.deliveryDate = null;
                    MEntity.description = txtInvoiceNo.Text.Trim();
                    MEntity.enteredBy = MDIParent.userId; // Convert.ToInt32(cmbReference.SelectedValue);
                    MEntity.enteredTime = DateTime.Now;
                    MEntity.status = (rbCash.Checked) ? "Cash" : "Credit";
                    MEntity.IsPaid = MEntity.status == "Cash" ? true : false;
                    MEntity.IsStored = true;
                    MEntity.orderDate = Convert.ToDateTime(dtpPurchaseDate.Value.ToString("yyyy-MM-dd"));
                    MEntity.shippingMethod = txtSalesman.Text.Trim();
                    MEntity.shipTo = txtReceiver.Text.Trim();
                    MEntity.supplierId = Convert.ToInt32(cmbSupplier.SelectedValue.ToString());
                    MEntity.totalCost = Convert.ToDouble(txtGrandTotal.Text);
                    MEntity.updatedBy = MDIParent.userId;
                    MEntity.updatedTime = DateTime.Now;
                    MEntity.StoreId = MDIParent.storeId;

                    int MasterData = -1;
                    int updateData = -1;
                    if (btnDelete.Text == "SAVE")
                    {
                        MasterData = oPurchaseDAO.Add(MEntity);
                        purchaseID = MasterData;
                    }
                    else
                    {
                        MEntity.purchaseId = purchaseID;
                        MasterData = MEntity.purchaseId;

                        string where = "T.[TransType]=1 AND T.[ParentId]=" + MasterData + " AND T.[ProductId] NOT IN (";
                        foreach (DataGridViewRow item in dgvItem.Rows)
                        {
                            int productId = Convert.ToInt32(item.Cells[6].Value.ToString());
                            double qty = Convert.ToDouble(item.Cells[2].Value.ToString());
                            Transaction t = new TransactionDAO().Transaction_GetDynamic("T.[TransType]=1 AND T.[ParentId]=" + MasterData + " AND T.[ProductId]=" + productId, "").FirstOrDefault();
                            if (t != null && t.UsedQty > qty)
                            {
                                Alert(t.UsedQty + " Qty already used of " + t.pName + "\nPurchase Qty cannot be less than Used Qty");
                                return;
                            }
                            where += (where == "T.[TransType]=1 AND T.[ParentId]=" + MasterData + " AND T.[ProductId] NOT IN (") ? productId.ToString() : ("," + productId);
                        }
                        where += ")";

                        List<Transaction> lstTrn = new TransactionDAO().Transaction_GetDynamic(where, "");
                        if (lstTrn.Count > 0)
                        {
                            foreach (Transaction trn in lstTrn)
                            {
                                if (trn.UsedQty > 0)
                                {
                                    Alert(trn.UsedQty + " Qty already used of " + trn.pName + "\nMust Purchase Minimum " + trn.UsedQty + " Qty");
                                    return;
                                }
                            }
                        }

                        updateData = oPurchaseDAO.Update(MEntity); //UPDATING MASTER
                        //oPurchaseProductDAO.PurchaseProduct_DeleteByPurchaseIdOnly(MasterData); //DELETING DETAIL
                        //oTransactionDAO.Transaction_DeleteByParentId(MasterData); //DELETING TRANSACTION
                    }
                    #endregion

                    if (MasterData > 0 || updateData > 0)
                    {
                        #region Purchase Detail
                        foreach (DataGridViewRow item in dgvItem.Rows)
                        {
                            PurchaseProduct DEntity = new PurchaseProduct();
                            DEntity.purchaseId = MasterData;
                            DEntity.unitCost = Convert.ToDouble(item.Cells[4].Value.ToString());
                            DEntity.qty = Convert.ToDouble(item.Cells[2].Value.ToString());
                            DEntity.productId = Convert.ToInt32(item.Cells[6].Value.ToString());
                            try
                            {
                                string[] dateExpr = Regex.Split(item.Cells[1].Value.ToString(), "/");
                                string ExpireDate = dateExpr[2] + "-" + dateExpr[1] + "-" + dateExpr[0];
                                DEntity.ExpireDate = Convert.ToDateTime(ExpireDate);
                            }
                            catch (Exception ex)
                            {
                                string[] dateExpr = Regex.Split(item.Cells[1].Value.ToString(), "/");
                                string ExpireDate = dateExpr[2] + "-" + dateExpr[1] + "-" + dateExpr[0];
                                DEntity.ExpireDate = Convert.ToDateTime(ExpireDate);
                                throw;
                            }

                            DEntity.lotNumber = item.Cells[3].Value.ToString();

                            Transaction t = new TransactionDAO().Transaction_GetDynamic("T.[TransType]=0 AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + DEntity.productId, "").FirstOrDefault();
                            if (t != null && t.TransDate > dtpPurchaseDate.Value)
                            {
                                Alert("Purchase Date must be " + t.TransDate.ToString() + " or Later."); return;
                            }

                            oPurchaseProductDAO.Add(DEntity);

                            #region Transaction

                            Transaction TransEntity = new Transaction();
                            TransEntity.EnteredBy = Convert.ToInt32(MEntity.enteredBy);
                            TransEntity.EnteredTime = Convert.ToDateTime(MEntity.enteredTime);
                            TransEntity.ParentId = MasterData;
                            TransEntity.ProductId = DEntity.productId;
                            TransEntity.Quantity = Convert.ToDouble(DEntity.qty);
                            TransEntity.UsedQty = 0;
                            TransEntity.TransDate = Convert.ToDateTime(dtpPurchaseDate.Value.ToString("yyyy-MM-dd"));
                            TransEntity.TransType = 1; // 1 FOR PURCHASE
                            TransEntity.UnitPrice = Convert.ToDouble(DEntity.unitCost);
                            TransEntity.StoreId = MDIParent.storeId;
                            TransEntity.EnteredBy = MDIParent.userId;
                            TransEntity.EnteredTime = DateTime.Now;
                            oTransactionDAO.Add(TransEntity);

                            #endregion
                        }
                        #endregion

                        if (MEntity.status == "Cash")
                        {
                            #region Supplier Payment
                            PurchasePayment PPEntity = new PurchasePayment();
                            PPEntity.PurchaseId = MasterData;
                            PPEntity.PaymentDate = Convert.ToDateTime(dtpPurchaseDate.Value.ToString("yyyy-MM-dd"));
                            PPEntity.MemoNumber = txtMemoNo.Text;
                            PPEntity.PaymentType = "Cash";
                            PPEntity.PaidAmount = Convert.ToDecimal(MEntity.totalCost);
                            PPEntity.DiscAmount = 0;
                            PPEntity.RemAmount = 0;
                            PPEntity.Remarks = "FROM PURCHASE";
                            PPEntity.EnteredBy = MDIParent.userId;
                            PPEntity.EnteredTime = DateTime.Now;
                            int PPResult = new PurchasePaymentDAO().Add(PPEntity);
                            #endregion
                        }

                        UtilsDAO.CommitTransaction(trans);
                        ResetAll();
                        Alert("Purchase Saved successfully");
                    }
                }
                catch (Exception ex)
                {
                    Alert("Purchase Could not be Saved.");
                }
                finally
                {
                    if (DbProviderHelper.IsInTransaction)
                        UtilsDAO.RollbackTransaction(trans);
                }


            }

        }

        private bool CheckValidity()
        {
            //if (cmbReceiver.SelectedIndex < 0)
            //{
            //    Alert("Please select Receiver.");
            //    cmbReceiver.Focus();
            //    return false;
            //}
            //if (cmbReference.SelectedIndex < 0)
            //{
            //    Alert("Please select Reference.");
            //    cmbReference.Focus();
            //    return false;
            //}
            if (cmbSupplier.SelectedIndex == -1)
            {
                Alert("Please select supplier.");
                cmbSupplier.Focus();
                return false;
            }
            //if (txtSalesman.Text.Trim() == "")
            //{
            //    Alert("Please enter the salesman's Name.");
            //    txtSalesman.Focus();
            //    return false;
            //}
            if (txtInvoiceNo.Text.Trim() == "")
            {
                Alert("Please enter Invoice No.");
                txtInvoiceNo.Focus();
                return false;
            }
            if (txtGrandTotal.Text.Trim() == "")
            {
                Alert("Grand total cannot be empty.");
                txtGrandTotal.Focus();
                return false;
            }
            if (dgvItem.Rows.Count < 1)
            {
                Alert("Please enter Items to save.");
                cboItemSelect.Focus();
                return false;
            }

            return true;
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSupplier();
        }

        private void dtpExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;

            if (iCode == 13)
            {
                txtPurchaseQty.Focus();
            }
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && dgvItem.Rows[e.RowIndex].Cells[6].Value != null)
            {
                dgvItem.Rows.RemoveAt(e.RowIndex);
                cboItemSelect.SelectedIndex = -1;
                CalculateGrandTotal();
            }
            else
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvItem.Rows[iRowIndex];
                if (ObjDGVRow.Cells[0].Value != null)
                {
                    cboItemSelect.SelectedValue = Convert.ToInt32(ObjDGVRow.Cells[6].Value);

                    string[] dateExpr = Regex.Split(ObjDGVRow.Cells[1].Value.ToString(), "/");
                    string ExpireDate = dateExpr[1] + "/" + dateExpr[0] + "/" + dateExpr[2];

                    dtpExpireDate.Value = Convert.ToDateTime(dateExpr[2] + "-" + dateExpr[1] + "-" + dateExpr[0]);
                    txtPurchaseQty.Text = ObjDGVRow.Cells[2].Value.ToString();
                    lotNumber.Text = ObjDGVRow.Cells[3].Value.ToString();
                    txtUnitCost.Text = ObjDGVRow.Cells[4].Value.ToString();
                    txtSubTotal.Text = ObjDGVRow.Cells[5].Value.ToString();
                    dgvItem.Rows.RemoveAt(iRowIndex);
                    //btnAdd.Tag = "Update";
                    CalculateGrandTotal();
                }
            }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            btnAdd.Tag = "Add";
            txtMemoNo.Text = "MMN/" + DateTime.Now.DayOfYear + DateTime.Now.Millisecond;
            cmbSupplierBind();
            cmbItemBind();
            EmployerBind();
            ResetAll();
            loadDone = true;
        }

        private void EmployerBind()
        {
            UsersDAO oUsersDAO = new UsersDAO();

            DataTable referenceList = oUsersDAO.Employee_GetForDDL(0);
            cmbReference.DataSource = referenceList;
            cmbReference.DisplayMember = "EmployeeName";
            cmbReference.ValueMember = "EmployeeId";
            cmbReference.SelectedValue = MDIParent.EmpId;

            DataTable employeeList = oUsersDAO.Employee_GetForDDL(MDIParent.storeId);
            cmbReceiver.DataSource = employeeList;
            cmbReceiver.DisplayMember = "EmployeeName";
            cmbReceiver.ValueMember = "EmployeeId";
            cmbReceiver.SelectedValue = MDIParent.EmpId;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearchResults.Rows.Clear();

            string from = dtFromSearch.Value.ToString("yyyy-MM-dd");
            string to = dtToSearch.Value.ToString("yyyy-MM-dd");

            string query = "dbo.TrimTime(P.[orderDate]) BETWEEN dbo.TrimTime('" + from + "') AND dbo.TrimTime('" + to + "')";
            if (!string.IsNullOrEmpty(txtInvoiceNoSearch.Text))
                query += " AND P.[description] = '" + txtInvoiceNoSearch.Text.Trim() + "'";
            if (cmbSupplierSearch.SelectedIndex > -1)
                query += " AND P.[supplierId] = " + cmbSupplierSearch.SelectedValue;

            PurchaseDAO oPurchaseDAO = new PurchaseDAO();
            List<Purchase> purchaseList = oPurchaseDAO.Purchase_GetDynamic(query, "");

            if (purchaseList.Count > 0)
            {
                foreach (Purchase item in purchaseList)
                {
                    dgvSearchResults.Rows.Add(item.purchaseId, item.description, item.orderDate, item.SupplierName, item.status, item.totalCost);
                }
                dgvSearchResults.Columns[2].DefaultCellStyle.Format = "dd/MMM/yyyy";
            }
            else
            {
                Alert("No Purchase Found");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            cboItemCount = cboItemSelect.Items.Count;
            frmItemNew frm = new frmItemNew();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                cmbItemBind();
                if (cboItemCount < cboItemSelect.Items.Count)
                    cboItemSelect.SelectedIndex = cboItemSelect.Items.Count - 1;
            }
        }

        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                #region LOAD PRODUCT GRID
                purchaseID = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                dgvItem.Rows.Clear();
                Purchase PEntity = oPurchaseDAO.Purchase_GetById(purchaseID);
                if (PEntity != null)
                {
                    txtReceiver.Text = PEntity.shipTo;
                    //cmbReference.SelectedValue = PEntity.enteredBy;
                    cmbSupplier.SelectedValue = PEntity.supplierId;
                    txtSalesman.Text = PEntity.shippingMethod;
                    txtInvoiceNo.Text = PEntity.description;
                    dtpPurchaseDate.Value = Convert.ToDateTime(PEntity.orderDate);
                    if (PEntity.status == "Cash")
                    {
                        rbCash.Checked = true;
                        txtMemoNo.Text = PEntity.MemoNumber;
                    }
                    else rbCredit.Checked = true;

                    btnSupplierAdd.Enabled = cmbSupplier.Enabled = rbCash.Enabled = rbCredit.Enabled = false;

                    List<PurchaseProduct> PPList = oPurchaseProductDAO.PurchaseProduct_GetDynamic("PP.[purchaseId] = '" + purchaseID + "'", "");
                    if (PPList.Count > 0)
                    {
                        foreach (PurchaseProduct item in PPList)
                        {
                            string[] dateExpr = Regex.Split(Convert.ToDateTime(item.ExpireDate).Date.ToShortDateString(), "/");
                            string ExpireDate = dateExpr[0] + "/" + dateExpr[1] + "/" + dateExpr[2];
                            //string ExpireDate = dateExpr[2] + "/" + dateExpr[1] + "/" + dateExpr[0]; ;
                            var lotNo = "N/A";
                            if (item.lotNumber != null)
                            {
                                lotNo = item.lotNumber;
                            }

                            dgvItem.Rows.Add(item.ProductName, ExpireDate, item.qty, lotNo, item.unitCost, (item.qty * item.unitCost), item.productId, item.usedQty);
                        }
                    }

                    btnAdd.Enabled = true;
                    btnReset.Enabled = true;
                    btnDelete.Text = "UPDATE";
                    btnExit.Enabled = true;
                    prvGrandTotal = CalculateGrandTotal();
                    txtGrandTotal.Text = prvGrandTotal.ToString();
                }
                #endregion
            }

            else if (e.ColumnIndex == 9)
            {
                #region DELETE PURCHASE
                DialogResult dg = MessageBox.Show("Are you sure you want to delete the Purchase?", "Delete Purchase", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    int deleteId = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                    try
                    {
                        //also check return
                        int result = oPurchaseDAO.Purchase_DeletePurchaseDetailTransById(deleteId);
                        if (result > 0)
                            dgvSearchResults.Rows.RemoveAt(e.RowIndex);
                        else
                            Alert("Products from this purchase already used.");

                    }
                    catch (Exception ex)
                    {
                        Alert("Purchase could not be deleted.");
                    }
                }
                #endregion
            }

            else if (e.ColumnIndex == 10)
            {
                #region RETURN PURCHASE
                frmPurchaseReturn frm = new frmPurchaseReturn();
                frm.ControlBox = false;
                frmPurchaseReturn.PurIdForReturn = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                frm.ShowDialog();
                #endregion
            }
        }

        private void dgvItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateGrandTotal();
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                label6.Visible = txtMemoNo.Visible = true;
            }
            else
            {
                label6.Visible = txtMemoNo.Visible = false;
            }
        }

        private void Alert(String msg)
        {
            MessageBox.Show(msg, "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            frmSupplierEntry frmSup = new frmSupplierEntry();
            frmSup.ShowDialog();
            cmbSupplierBind();
        }

        private void cboItemSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPurchaseQty.Select();
        }
    }
}