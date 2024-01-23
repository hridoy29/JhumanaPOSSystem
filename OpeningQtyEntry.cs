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

namespace POSsible
{
    public partial class OpeningQtyEntry : Form
    {
        int itemId = 0;
        int storeId = 0;
        int transId = 0;
        bool loadDone = false;
        public static bool FromItemEntry = false;
        public static int CrtId = 0;
        public static int PcsId = 0;

        public OpeningQtyEntry()
        {
            InitializeComponent();
        }

        private void OpeningQtyEntry_Load(object sender, EventArgs e)
        {
            LoadControls();
            loadDone = true;
        }

        private void LoadGrid()
        {
            List<Transaction> trnsList = new TransactionDAO().Transaction_GetAll();
            if (trnsList.Count > 0)
            {
                dgvItem.Rows.Clear();

                if (cmbStore.SelectedIndex > -1)
                {
                    trnsList = trnsList.Where(x => x.StoreId == storeId).ToList();
                    foreach (Transaction item in trnsList)
                    {
                        dgvItem.Rows.Add(item.pName, item.Quantity, item.TransDate, item.ProductId, item.StoreId, item.UnitPrice, item.TransId);
                    }
                }



            }
        }

        private void LoadControls()
        {
            //Store
            DataTable storeList = new UsersDAO().Store_GetAll();
            cmbStore.DataSource = storeList;
            cmbStore.DisplayMember = "StoreName";
            cmbStore.ValueMember = "StoreId";
            cmbStore.SelectedIndex = -1;

            //Item with Barcode
            List<Product> lProductList = new ProductDAO().Product_GetAll();

            if (FromItemEntry)
            {
                if (MDIParent.storeId > 0)
                {
                    cmbStore.SelectedValue = MDIParent.storeId;
                    cmbStore.Enabled = false;
                }

                if (CrtId > 0 && PcsId > 0)
                    lProductList = lProductList.Where(p => p.productId == CrtId || p.productId == PcsId).ToList();
                else if (CrtId > 0 && PcsId == 0)
                    lProductList = lProductList.Where(p => p.productId == CrtId).ToList();
                btnReset.Enabled = false;
            }

            cboItemSelect.DataSource = lProductList;
            cboItemSelect.DisplayMember = "Bar_Name";
            cboItemSelect.ValueMember = "ProductId";
            cboItemSelect.SelectedIndex = -1;
        }

        private void cboItemSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadDone) return;
            itemId = Convert.ToInt32(cboItemSelect.SelectedValue);

            if (btnAdd.Tag == "Add")
            {
                txtOPQty.Clear();
            }
        }

        private void txtOPQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValidity())
            {

                try
                {
                    Transaction transEntity = new Transaction();
                    transEntity.TransType = 0; //FOR OPENING QTY
                    transEntity.UsedQty = 0;
                    transEntity.TransDate = dtpOpeningDate.Value;
                    transEntity.Quantity = Convert.ToDouble(txtOPQty.Text);
                    transEntity.UnitPrice = Convert.ToDouble(txtUnitCost.Text);
                    transEntity.ParentId = 0;
                    transEntity.ProductId = itemId;
                    transEntity.EnteredBy = MDIParent.userId;
                    transEntity.EnteredTime = DateTime.Now;
                    transEntity.StoreId = Convert.ToInt32(cmbStore.SelectedValue);

                    if (btnAdd.Text == "ADD")
                        new TransactionDAO().Add(transEntity);
                    else if (btnAdd.Text == "UPDATE")
                    {
                        transEntity.TransId = transId;
                        new TransactionDAO().Update(transEntity);
                    }

                    MessageBox.Show("Saved Successfully.", "POSsible");
                    resetALL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured.", "POSsible");
                    return;
                }
            }
        }

        private bool checkValidity()
        {
            if (cmbStore.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Store.", "POSsible");
                return false;
            }

            if (cboItemSelect.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Product.", "POSsible");
                return false;
            }

            if (dtpOpeningDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("Please Select Valid Date.", "POSsible");
                return false;
            }

            Transaction tr = new TransactionDAO().Transaction_GetDynamic("T.[ProductId]=" + itemId + " AND T.[StoreId]='" + cmbStore.SelectedValue + "'", "").FirstOrDefault();
            if (tr != null)
            {
                if (tr.TransType == 0 && btnAdd.Text == "ADD")
                {
                    MessageBox.Show("Opening Qunatity for this Product is Already Entered. Please try to Update", "POSsible");
                    return false;
                }
                else if (tr.TransType == 0 && btnAdd.Text == "UPDATE")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Cannot Enter Opening Quantity. This Product is Already Used in this Store.", "POSsible");
                    return false;
                }
            }

            return true;
        }

        private void txtUnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtUnitCost.Text);
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                //EDIT
                itemId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[3].Value);
                storeId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[4].Value);
                cboItemSelect.SelectedValue = itemId;
                dtpOpeningDate.Value = Convert.ToDateTime(dgvItem.Rows[e.RowIndex].Cells[2].Value);
                cmbStore.SelectedValue = storeId;
                txtOPQty.Text = dgvItem.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUnitCost.Text = dgvItem.Rows[e.RowIndex].Cells[5].Value.ToString();
                transId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[6].Value);
                btnAdd.Text = "UPDATE";
            }
            if (e.ColumnIndex == 8)
            {
                //DELETE
                Transaction tr = new TransactionDAO().Transaction_GetDynamic("T.[ProductId]=" + itemId + " AND T.[TransType]<>0 AND T.[StoreId]='" + cmbStore.SelectedValue + "'", "").FirstOrDefault();
                if (tr != null)
                {
                    MessageBox.Show("Cannot Delete. Already in Use.", "POSsible");
                    return;
                }

                Transaction tr2 = new TransactionDAO().Transaction_GetDynamic("T.[TransId]=" + transId, "").FirstOrDefault();
                if (tr2 == null || (tr2.UsedQty > 0))
                {
                    MessageBox.Show("Cannot Delete. Already in Use.", "POSsible");
                    return;
                }

                new TransactionDAO().Delete(tr.TransId);
                resetALL();
            }
        }

        private void resetALL()
        {
            cmbStore.SelectedIndex = -1;
            dtpOpeningDate.Value = DateTime.Now;
            cboItemSelect.SelectedIndex = -1;
            txtOPQty.Clear();
            txtUnitCost.Clear();
            itemId = 0;
            storeId = 0;
            FromItemEntry = false;
            CrtId = 0;
            PcsId = 0;
        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadDone) return;
            storeId = Convert.ToInt32(cmbStore.SelectedValue);
            cmbCategoryBind();

            List<Product> lProductList = new ProductDAO().Product_GetDynamic("T.[productId] NOT IN (SELECT ProductId FROM [Transaction] WHERE ParentId=0 AND TransType=0 AND StoreId=" + storeId + ")", string.Empty);
            cboItemSelect.DataSource = lProductList;
            cboItemSelect.DisplayMember = "Bar_Name";
            cboItemSelect.ValueMember = "ProductId";
            cboItemSelect.SelectedIndex = -1;
        }

        private void cmbCategoryBind()
        {

            List<ProductCategory> lstSearchCategory = new ProductCategoryDAO().ProductCategory_GetAll();
            if (lstSearchCategory.Count > 0)
            {
                cmbSearchCategory.DataSource = lstSearchCategory;
                cmbSearchCategory.SelectedIndex = -1;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetALL();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FromItemEntry = false;
            this.Close();
        }

        private void cmbItemBarcodeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStore.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Store first.", "POSsible");
                return;
            }
            if (cmbItemBarcodeSearch.SelectedIndex < 0) return;
            int itemIdS = Convert.ToInt32(cmbItemBarcodeSearch.SelectedValue);
            dgvItem.Rows.Clear();

            if (cmbStore.SelectedIndex > -1)
            {
                Transaction t = new TransactionDAO().Transaction_GetDynamic("T.[StoreId]=" + storeId + " AND T.[productId]=" + itemIdS, "").FirstOrDefault();
                if (t != null)
                    dgvItem.Rows.Add(t.pName, t.Quantity, t.TransDate, t.ProductId, t.StoreId, t.UnitPrice, t.TransId);

            }
        }

        private void cmbItemBarcodeSearchBind()
        {
            List<Product> lstProduct = new ProductDAO().Product_GetAll();
            if (lstProduct.Count > 0)
            {
                cmbItemBarcodeSearch.DataSource = lstProduct;
                cmbItemBarcodeSearch.SelectedIndex = -1;
            }
        }

        private void cmbItemNameSearchBind()
        {
            List<Product> lstProduct = new ProductDAO().Product_GetAll();

            if (lstProduct.Count > 0)
            {
                cmbItemNameSearch.DataSource = lstProduct;
                cmbItemNameSearch.SelectedIndex = -1;
            }
        }

        private void cmbSearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStore.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Store first.", "POSsible");
                return;
            }
            if (cmbSearchFilter.SelectedIndex == 1)
            {
                //BARCODE SEARCH
                cmbItemBarcodeSearchBind();
                cmbItemBarcodeSearch.SelectedIndex = -1;

                cmbItemNameSearch.Visible = false;
                cmbItemBarcodeSearch.Visible = true;
            }
            else
            {
                //NAME SEARCH
                cmbItemNameSearch.Visible = true;
                cmbItemBarcodeSearch.Visible = false;

                cmbItemNameSearchBind();
                cmbItemNameSearch.SelectedIndex = -1;
            }
        }

        private void cmbItemNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStore.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Store first.", "POSsible");
                return;
            }   
            if (cmbItemNameSearch.SelectedIndex < 0) return;
            int itemIdS = Convert.ToInt32(cmbItemNameSearch.SelectedValue);
            dgvItem.Rows.Clear();

            if (cmbStore.SelectedIndex > -1)
            {
                Transaction t = new TransactionDAO().Transaction_GetDynamic("T.[StoreId]=" + storeId + " AND T.[productId]=" + itemIdS, "").FirstOrDefault();
                if (t != null)
                    dgvItem.Rows.Add(t.pName, t.Quantity, t.TransDate, t.ProductId, t.StoreId, t.UnitPrice, t.TransId);

            }
        }

        private void cmbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dgvItem.Rows.Clear();
            int deptId = Convert.ToInt32(cmbSearchCategory.SelectedValue);
            if (storeId < 1) return;
            List<Transaction> lstTr = new TransactionDAO().Transaction_GetDynamic("P.[categorytId]=" + deptId + " AND T.[StoreId]=" + storeId, "");
            if (lstTr.Count > 0)
            {                
                foreach (Transaction item in lstTr)
                {
                    dgvItem.Rows.Add(item.pName, item.Quantity, item.TransDate, item.ProductId, item.StoreId, item.UnitPrice, item.TransId);
                }

            }
        }
    }
}
