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

namespace POSsible
{
    public partial class frmItemLookUp : Form
    {
        frmMain ofrmMain;

        private int clickedRowIndex, iRow;
        private string sQuantityAddUnit;
        private double dbSubtotal = 0.0;
        private double dUnitPrice;
        private int catId = 0;
        private string catName = "";

        public frmItemLookUp()
        {
            InitializeComponent();
        }

        public frmItemLookUp(frmMain oFrmMain, string categoryName)
        {
            InitializeComponent();
            ofrmMain = new frmMain();
            ofrmMain = oFrmMain;
            this.catName = categoryName;
            //design
            lblItemSearch.Text = categoryName + " Search:";
        }

        private void frmItemLookUp_Load(object sender, EventArgs e)
        {
            List<Product> lstProduct = new List<Product>();
            this.catId = new ProductCategoryDAO().ProductCategory_GetByName(catName);

            if (catName == "All Items")
                lstProduct = new ProductDAO().Product_GetAll();
            else if (catId == -1)
                MessageBox.Show("Sorry Category not found.");
            else
                lstProduct = new ProductDAO().Product_GetDynamic("[categorytId] ='" + catId + "'", "name");

            if (lstProduct.Count > 0)
            {
                dGvAllLookUp.Rows.Clear();
                for (int i = 0; i < lstProduct.Count; i++)
                {
                    dGvAllLookUp.Rows.Add(lstProduct[i].name.ToString(), lstProduct[i].unitPrice.ToString(), lstProduct[i].UnitMeasureName.ToString(), lstProduct[i].productId.ToString(), lstProduct[i].categorytId.ToString());
                }
            }
        }

        private void dGvAllLookUp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickedRowIndex = e.RowIndex;
            frmWeightTaker oWeightTaker = new frmWeightTaker(this);
            oWeightTaker.ShowDialog();
        }

        public void getWeight(string sData)
        {
            ofrmMain.dgvItem.Invoke(new EventHandler(delegate
            {
                try
                {
                    Product oProduct = new Product();

                    sQuantityAddUnit = "";
                    dbSubtotal = 0.0;

                    if (dGvAllLookUp.Rows[clickedRowIndex].Cells[4].Value.ToString() != "")
                        oProduct.categorytId = Convert.ToInt32(dGvAllLookUp.Rows[clickedRowIndex].Cells[4].Value);

                    if (dGvAllLookUp.Rows[clickedRowIndex].Cells[2].Value.ToString() != "")
                        oProduct.UnitMeasureName = dGvAllLookUp.Rows[clickedRowIndex].Cells[2].Value.ToString();

                    if (dGvAllLookUp.Rows[clickedRowIndex].Cells[3].Value.ToString() != "")
                        oProduct.productId = Convert.ToInt16(dGvAllLookUp.Rows[clickedRowIndex].Cells[3].Value);

                    oProduct.weight = double.Parse(sData);

                    Transaction t = new TransactionDAO().Transaction_GetDynamic("T.[TransType]=0 AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + oProduct.productId, "").FirstOrDefault();
                    if (t != null)
                        if (t.TransDate > DateTime.Now.Date)
                        {
                            MessageBox.Show("Sale Date must be " + t.TransDate.ToString("dd/MM/yyyy") + " or Later.");
                            return;
                        }


                    double CurrentQty = new TransactionDAO().ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + Convert.ToInt32(oProduct.productId) + ")");
                    if (oProduct.weight > CurrentQty)
                    {
                        MessageBox.Show("Product Available : " + CurrentQty, "POSsible", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    ofrmMain.addRow(oProduct.productId, Convert.ToDouble(oProduct.weight), oProduct.UnitMeasureName, "REGULAR", oProduct.categorytId);
                    ofrmMain.dgvItem.Refresh();
                    #region get Image
                    //try
                    //{
                    //    POSsible.Controllers.IProductManager _ProductManager = new POSsible.Controllers.ProductManager(this);
                    //    byte[] imgRaw = _ProductManager.getImageByProductId(oProduct.ProductId);
                    //    if (imgRaw != null)
                    //    {
                    //        MemoryStream memory = new MemoryStream(imgRaw);
                    //        oFrmMainGlobal.picBxImageDisplay.Image = Image.FromStream(memory);
                    //    }
                    //    else
                    //    {
                    //        oFrmMainGlobal.picBxImageDisplay.Image = null;
                    //        oFrmMainGlobal.picBxImageDisplay.Invalidate();
                    //    }
                    //}
                    //catch (Exception excp)
                    //{
                    //    oFrmMainGlobal.picBxImageDisplay.Image = null;
                    //    oFrmMainGlobal.picBxImageDisplay.Invalidate();
                    //}
                    //MemoryStream memory = new MemoryStream(_ProductManager.getImageByProductId(oProduct.ProductId));
                    //oFrmMainGlobal.picBxImageDisplay.Image = Image.FromStream(memory);
                    #endregion
                }
                catch (Exception xcp)
                {
                    throw xcp;
                }

            }));
            //if (comport.IsOpen) comport.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string where = "1=1";
            this.catId = new ProductCategoryDAO().ProductCategory_GetByName(catName);

            if (catName != "All Items")
            {
                this.catId = new ProductCategoryDAO().ProductCategory_GetByName(catName);
                where += " AND [categorytId] =" + catId;
            }
            if (!string.IsNullOrEmpty(txtItemSearch.Text.Trim()))
                where += " AND name LIKE '%" + txtItemSearch.Text.Trim() + "%'";

            List<Product> lstProduct = new ProductDAO().Product_GetDynamic(where, "name");

            if (lstProduct.Count > 0)
            {
                dGvAllLookUp.Rows.Clear();
                for (int i = 0; i < lstProduct.Count; i++)
                {
                    dGvAllLookUp.Rows.Add(lstProduct[i].name.ToString(), lstProduct[i].unitPrice.ToString(), lstProduct[i].UnitMeasureName.ToString(), lstProduct[i].productId.ToString(), lstProduct[i].categorytId.ToString());
                }
            }
            else
                MessageBox.Show("No Product found!");
        }
    }
}
