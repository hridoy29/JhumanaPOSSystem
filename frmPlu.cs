using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using System.IO;

namespace POSsible
{
    public partial class frmPlu : Form, POSsible.Views.IPluView
    {
        frmMain oFrmMainGlobal;
        private POSsible.Controllers.IProductManager _ProductManager;
        private string sQuantityAddUnit;
        private double dbSubtotal;
        private double dUnitPrice;
        private int irow = 0;
        
        private CKeyboard keyboard;
        // Constructor
        public frmPlu()
        {
            InitializeComponent();
            _ProductManager = POSsible.Factories.Factory.GetProductManager(this);
        }

        /// <summary>
        /// Over loaded constructor
        /// Here ShallowCopy is used to update datagrid of the Main form
        /// </summary>
        /// <param name="oFrmMain"></param>
        public frmPlu(frmMain oFrmMain)
        {
            InitializeComponent();
            _ProductManager = POSsible.Factories.Factory.GetProductManager(this);
            //oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
        }

        public void displayProductList(CProduct oProductList)
        {
            // Do nothing
        }
        
        /// <summary>
        /// Used to Add the Department to the Department Combo box
        /// </summary>
        /// <param name="oLstDepartment"></param>
        public void putDepartmentList(List<CDepartment> oLstDepartment)
        {
            //for (int i = 0; i < oLstDepartment.Count; i++)
            //{
            //    cboDepartment.Items.Add(oLstDepartment[i].DepartmentName.ToString());                
            //}

            cboDepartment.DataSource = oLstDepartment;
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.ValueMember = "CategoryId";


        }

       /// <summary>
       /// Used to Update the Data Grid
       /// </summary>
       /// <param name="oLstProduct"></param>
        public void updateItemGrid(List<CProduct> oLstProduct)
        {
            
            if (dGvPlu.Rows.Count > 0) dGvPlu.Rows.Clear();
            if (oLstProduct.Count > 0)
            {
                
                foreach (CProduct product in oLstProduct)
                {
                    dGvPlu.Rows.Add(product.ProductName.ToString(), product.UnitPrice.ToString(), product.UnitMeasure.ToString(), product.PromoStartDate.ToString(), product.PromoEndDate.ToString(), product.PromoUnitPrice.ToString(), product.ProductId.ToString());
                }
            }
        }

        private void frmPlu_Load(object sender, EventArgs e)
        {
             _ProductManager.getDepartmentList(0);
        }

        /// <summary>
        /// This is used to fill up items to the grid
        /// </summary>
        /// <param name="oProduct"></param>
        public void fillItemsToGrid()
        {

            //int iDepartmentId = (int)cboDepartment.SelectedValue;
            //_ProductManager.getItemlist(iDepartmentId);
            int iCategoryId = 0;
            if (cboDepartment.SelectedValue.ToString() != "")
                iCategoryId = Int32.Parse(cboDepartment.SelectedValue.ToString());

            _ProductManager.getItemlist(iCategoryId);

        }

        private void dGvPlu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                irow = e.RowIndex;
                CProduct oProduct = new CProduct();
                double sQuantityvalue;

                sQuantityAddUnit = "";
                dbSubtotal = 0.0;
                bool isFound = false;
                DataGridViewRow ObjRow = dGvPlu.Rows[e.RowIndex];

                if (ObjRow.Cells.Count > 0)
                {
                    if (ObjRow.Cells[0].Value.ToString() != "")
                        oProduct.ProductName = ObjRow.Cells[0].Value.ToString();

                    if (ObjRow.Cells[1].Value.ToString() != "")
                        oProduct.UnitPrice = Convert.ToDouble(ObjRow.Cells[1].Value);

                    if (ObjRow.Cells[2].Value.ToString() != "")
                        oProduct.UnitMeasure = ObjRow.Cells[2].Value.ToString();

                    if (ObjRow.Cells[6].Value.ToString() != "")
                        oProduct.ProductId = Convert.ToInt16(ObjRow.Cells[6].Value);

                    if (ObjRow.Cells[3].Value.ToString() != "")
                        oProduct.PromoStartDate = Convert.ToDateTime(ObjRow.Cells[3].Value);

                    if (ObjRow.Cells[4].Value.ToString() != "")
                        oProduct.PromoEndDate = Convert.ToDateTime(ObjRow.Cells[4].Value);

                    if (ObjRow.Cells[5].Value.ToString() != "")
                        oProduct.PromoUnitPrice = Convert.ToDouble(ObjRow.Cells[5].Value);


                    oProduct.ProductWeight = 1; //In this case it shud be Number of Qty



                    if (DateTime.Now >= oProduct.PromoStartDate && DateTime.Now <= oProduct.PromoEndDate)
                    {
                        dUnitPrice = oProduct.PromoUnitPrice;
                    }
                    else
                    {
                        dUnitPrice = oProduct.UnitPrice;
                    }


                    sQuantityAddUnit = oProduct.ProductWeight.ToString() + oProduct.UnitMeasure.ToString() + "@" + dUnitPrice.ToString();
                    dbSubtotal = oProduct.ProductWeight * dUnitPrice;

                }

                string[] sQuantity = new string[5];


                for (int i = 0; i < oFrmMainGlobal.dgvItem.Rows.Count; i++)
                {
                    if (oFrmMainGlobal.dgvItem.Rows[i].Cells[3].Value.ToString().Equals(oProduct.ProductId.ToString()))
                    {
                        string sUnitMeaure = oProduct.UnitMeasure;
                        char[] cSplit ={ sUnitMeaure[0] };

                        if (oFrmMainGlobal.dgvItem.Rows[i].Cells[1].Value.ToString() != "")
                            sQuantity = oFrmMainGlobal.dgvItem.Rows[i].Cells[1].Value.ToString().Split(cSplit);

                        sQuantityvalue = Convert.ToDouble(sQuantity[0]) + oProduct.ProductWeight;

                        sQuantityAddUnit = sQuantityvalue + oProduct.UnitMeasure.ToString() + "@" + dUnitPrice.ToString();

                        if (oProduct.ProductWeight.ToString() != "" && dUnitPrice.ToString() != "")
                            dbSubtotal = sQuantityvalue * dUnitPrice;

                        oFrmMainGlobal.dgvItem.Rows[i].Cells[1].Value = sQuantityAddUnit;
                        //oFrmMainGlobal.dgvItem.Rows[i].Cells[2].Value = dbSubtotal;
                        oFrmMainGlobal.dgvItem.Rows[i].Cells[2].Value = string.Format("{0:###0.00}",Convert.ToDouble(dbSubtotal));

                        oFrmMainGlobal.dTotalValue = oFrmMainGlobal.dTotalValue + dbSubtotal;
                        oFrmMainGlobal.lblTotalValue.Text = oFrmMainGlobal.dTotalValue.ToString();
                        isFound = true;
                    }

                }
                if (isFound.Equals(false))
                {
                    //oFrmMainGlobal.dgvItem.Rows.Add(oProduct.ProductName.ToString(), sQuantityAddUnit.ToString(), dbSubtotal, oProduct.ProductId.ToString());
                    oFrmMainGlobal.dgvItem.Rows.Add(oProduct.ProductName.ToString(), sQuantityAddUnit.ToString(), string.Format("{0:###0.00}", Convert.ToDouble(dbSubtotal)), oProduct.ProductId.ToString());
                    oFrmMainGlobal.iItemCount = oFrmMainGlobal.iItemCount + 1;
                    oFrmMainGlobal.lblItemValue.Text = oFrmMainGlobal.iItemCount.ToString();
                }

                if (oFrmMainGlobal.dgvItem.Rows.Count > 0)
                {
                    oFrmMainGlobal.dTotalValue = 0.0;
                    for (int i = 0; i < oFrmMainGlobal.dgvItem.Rows.Count; i++)
                    {
                        oFrmMainGlobal.dTotalValue = oFrmMainGlobal.dTotalValue + Convert.ToDouble(oFrmMainGlobal.dgvItem.Rows[i].Cells[2].Value);

                    }
                    oFrmMainGlobal.lblTotalValue.Text = string.Format("{0:###0.00}",oFrmMainGlobal.dTotalValue);
                }

                try
                {
                    POSsible.Controllers.IProductManager _ProductManager = new POSsible.Controllers.ProductManager(this);
                    byte[] imgRaw = _ProductManager.getImageByProductId(oProduct.ProductId);
                    if (imgRaw != null)
                    {
                        MemoryStream memory = new MemoryStream(imgRaw);
                        oFrmMainGlobal.picBxImageDisplay.Image = Image.FromStream(memory);
                    }
                    else
                    {
                        oFrmMainGlobal.picBxImageDisplay.Image = null;
                        oFrmMainGlobal.picBxImageDisplay.Invalidate();
                    }
                }
                catch (Exception excp)
                {
                    oFrmMainGlobal.picBxImageDisplay.Image = null;
                    oFrmMainGlobal.picBxImageDisplay.Invalidate();
                }

                //MemoryStream memory = new MemoryStream(_ProductManager.getImageByProductId(oProduct.ProductId));
                //oFrmMainGlobal.picBxImageDisplay.Image = Image.FromStream(memory);
                oFrmMainGlobal.dgvItem.Refresh();
            }
            catch (Exception xcp)
            {

            }

        }

        private void btnOK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CProduct oProductList = new CProduct();
                string sSearchText = "";
                sSearchText = txtSearchText.Text.ToString();
                int iDepartmentId = (int)cboDepartment.SelectedValue;

                if (opt_barcode.Checked.Equals(true))
                {
                    _ProductManager.getProductListByDepartmentNBarcode(sSearchText, iDepartmentId);
                }
                else if (opt_brand.Checked.Equals(true))
                {
                    _ProductManager.getProductListByDepartmentNBrand(sSearchText, iDepartmentId);
                }
                else if (opt_name.Checked.Equals(true))
                {
                    _ProductManager.getProductListByDepartmentNName(sSearchText, iDepartmentId);
                }
                else
                {
                    _ProductManager.getItemlist(iDepartmentId);
                }

            }
            catch (Exception excp)
            {

            }

        }
        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int iCategoryId = 0;
                if (cboDepartment.SelectedValue.ToString() != "")
                    iCategoryId = Int32.Parse(cboDepartment.SelectedValue.ToString());

                _ProductManager.getItemlist(iCategoryId);
                txtSearchText.Focus();
            }
            catch (Exception excp)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       public void Alert(string msg)
       {


       }
     
        
        private void cboDepartment_Change(object sender, EventArgs e)
        {
            // Call the function where all items are retrieved 
            //fillItemsToGrid();
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyboard == null)
                {
                    keyboard = new CKeyboard();
                    keyboard.showKeyPad(this);
                }
                else if (keyboard.process.HasExited)
                {
                    keyboard.showKeyPad(this);
                }

                //else
                //keyboard.showHide(true);
            }
            catch (Exception excp)
            {

            }
        }

        private void frmPlu_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (keyboard != null)
                {
                    if (!keyboard.process.HasExited)
                    {
                        keyboard.closeKeyPad();
                        keyboard = null;
                    }

                }

            }
            catch (Exception exc)
            {

            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnup_Click(object sender, EventArgs e)
        {
            if (dGvPlu.Rows.Count != 0)
            {
                if (irow != 0)
                {
                    dGvPlu.FirstDisplayedScrollingRowIndex = irow - 1;
                    dGvPlu.Rows[irow - 1].Selected = true;
                    irow = irow - 1;
                }
                else
                {
                    dGvPlu.Rows[0].Selected = true;
                }
            }
        }

        private void btndown_Click_1(object sender, EventArgs e)
        {
            if (dGvPlu.Rows.Count != 0)
            {

                if (irow != dGvPlu.Rows.Count - 1)
                {
                    dGvPlu.FirstDisplayedScrollingRowIndex = irow + 1;
                    dGvPlu.Rows[irow + 1].Selected = true;
                    irow = irow + 1;
                }
                else
                {
                    dGvPlu.Rows[dGvPlu.Rows.Count - 1].Selected = true;
                }
            }
        }

        #region keypad related
        private void KeyPadkey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            txtSearchText.Focus();
            SendKeys.Send(btnClicked.Text);
            
        }
        private void keypadOtherKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            txtSearchText.Focus();
            SendKeys.Send("{" + btnClicked.Tag + "}");
            
        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchText.Text = "";
            txtSearchText.Focus();

        }

        #endregion

       

        
    }
}
