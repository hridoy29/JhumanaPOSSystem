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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.Common;

namespace POSsible
{
    public partial class frmItemNew : Form
    {
        Users oUsers;
        ProductDAO oProductDAO = new ProductDAO();
        TransactionDAO oTransactionDAO = new TransactionDAO();
        private long m_lImageFileLength = 0;
        public static byte[] m_barrImg;
        public static byte[] pM_barrImg;
        public static int pcItemId = 0;
        List<Product> lstProduct = new List<Product>();

        public frmItemNew()
        {
            InitializeComponent();
            oUsers = new Users();
        }

        private void frmItemNew_Load(object sender, EventArgs e)
        {
            cmbCategoryBind(); // SEARCH ALSO
            cmbMeasurementUnitBind();
            lstProduct = oProductDAO.Product_GetAll();
            cmbItemNameSearchBind();
            cmbItemBarcodeSearchBind();
            resetAll();
        }

        private void GetShortCode()
        {
            if (btnAdd.Text == "ADD")
            {
                List<Product> lstProductSC = lstProduct;
                txtShortcode.Text = lstProductSC.Count > 0 ? (Convert.ToInt32(lstProductSC.OrderByDescending(p => p.shortcode).FirstOrDefault().shortcode) + 1).ToString().PadLeft(5, '0') : "00001";
            }
        }

        private void cmbItemBarcodeSearchBind()
        {
            //List<Product> lstProduct = oProductDAO.Product_GetAll();
            if (lstProduct.Count > 0)
            {
                cmbItemBarcodeSearch.DataSource = lstProduct;
                cmbItemBarcodeSearch.SelectedIndex = -1;
            }
        }

        private void cmbItemNameSearchBind()
        {
            //List<Product> lstProduct = new ProductDAO().Product_GetAll();

            if (lstProduct.Count > 0)
            {
                cmbItemNameSearch.DataSource = lstProduct;
                cmbItemNameSearch.SelectedIndex = -1;
            }
        }

        private void cmbMeasurementUnitBind()
        {
            List<UnitMeasure> lstUnitMeasure = new UnitMeasureDAO().UnitMeasure_GetAll();
            if (lstUnitMeasure.Count > 0)
            {
                cmbMeasurementUnit.DataSource = lstUnitMeasure;
                cmbMeasurementUnit.SelectedIndex = -1;
            }
        }

        private void cmbCategoryBind()
        {
            List<ProductCategory> lstProductCategory = new ProductCategoryDAO().ProductCategory_GetAll();
            if (lstProductCategory.Count > 0)
            {
                cmbCategory.DataSource = lstProductCategory;
                cmbCategory.SelectedIndex = -1;
            }

            List<ProductCategory> lstSearchCategory = new ProductCategoryDAO().ProductCategory_GetAll();
            if (lstSearchCategory.Count > 0)
            {
                cmbSearchCategory.DataSource = lstSearchCategory;
                cmbSearchCategory.SelectedIndex = -1;
            }
        }

        private void BindGrid()
        {
            lstProduct = oProductDAO.Product_GetAll();
            List<Product> lstProductGrid = lstProduct;
            lstProductGrid = lstProductGrid.Where(x => x.qtyInStock != -3).ToList();
            lstProductGrid = lstProductGrid.OrderBy(x => x.name).ToList();
            if (lstProductGrid.Count > 0)
            {
                dgvItem.Rows.Clear();

                foreach (Product item in lstProductGrid)
                {
                    dgvItem.Rows.Add(item.name, item.shortcode, item.productId, item.weight + " Kg");
                }
            }
        }

        private void putManualBarcode(TextBox textBox)
        {
            textBox.Clear();
            string barcode = "";
            DateTime now = DateTime.Now;
            barcode += now.Year.ToString() + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0') + now.Minute.ToString().PadLeft(2, '0') + now.Second.ToString().PadLeft(2, '0');
            textBox.Text = barcode;
        }

        private void cbManualBarBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManualBarBox.Checked)
            {
                putManualBarcode(txtBarcode);
                txtName.Focus();
            }
            else
            {
                txtBarcode.Clear();
                txtBarcode.Focus();
            }
        }

        private void cbHasPiece_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHasPiece.Checked)
            {
                grpPiece.Visible = true;

                label11.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                label1.Visible = true;

                txtPBarcode.Visible = true;
                txtPName.Visible = true;
                txtPRetailPrice.Visible = true;
                txtPSpecPrice.Visible = true;
                txtPWSPrice.Visible = true;
                txtPweight.Visible = true;

                cbPBManual.Visible = true;

                txtPPicBox.Visible = true;
                btnPBrowse.Visible = true;
                pieceUpdate();

                cbVarWeight.Visible = true;

            }
            else
            {
                grpPiece.Visible = false;

                label11.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label1.Visible = false;

                txtPBarcode.Visible = false;
                txtPName.Visible = false;
                txtPRetailPrice.Visible = false;
                txtPSpecPrice.Visible = false;
                txtPWSPrice.Visible = false;
                txtPweight.Visible = false;

                txtPBarcode.Clear();
                txtPName.Clear();
                txtPRetailPrice.Clear();
                txtPWSPrice.Clear();
                txtPSpecPrice.Clear();
                txtPweight.Clear();

                cbPBManual.Visible = false;

                cbPBManual.Checked = false;

                PBPieceImage.Visible = false;
                txtPPicBox.Visible = false;
                btnPBrowse.Visible = false;

                cbVarWeight.Visible = false;
            }
        }

        private void cbPBManual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPBManual.Checked && btnAdd.Text == "ADD")
            {
                if (cbVarWeight.Checked)
                    txtPBarcode.Text = new ProductDAO().GetBarcodeForVariableWtProduct().ToString();
                else
                    putManualBarcode(txtPBarcode);
                txtPName.Focus();
            }
            else
            {
                txtPBarcode.Clear();
                txtPBarcode.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void resetAll()
        {
            txtBarcode.Clear();
            txtName.Clear();
            txtBrand.Clear();
            txtDescription.Clear();
            txtReorder.Clear();
            txtweight.Clear();
            chkGst.Checked = false;
            chkExpirable.Checked = false;
            txtPictureBox.Clear();
            txtRetailPrice.Clear();
            txtWSPrice.Clear();
            txtPWSPrice.Clear();
            txtPSpecPrice.Clear();
            txtPCBox.Clear();
            txtSpecPrice.Clear();
            cmbCategory.SelectedIndex = -1;

            cbHasPiece.Enabled = true;
            cbHasPiece.Checked = false;
            cbManualBarBox.Checked = false;
            cbVarWeight.Enabled = true;
            cbVarWeight.Checked = false;

            PBProduct.Image = null;
            PBPieceImage.Visible = false;
            PBProduct.Visible = false;
            PBPieceImage.Image = null;

            cmbSearchCategory.SelectedIndex = -1;
            cmbMeasurementUnit.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            cmbPriceType.SelectedIndex = 0;
            cmbMeasurementUnit.SelectedIndex = -1;
            cmbItemNameSearch.SelectedIndex = -1;
            cmbItemBarcodeSearch.SelectedIndex = -1;
            cmbSearchFilter.SelectedIndex = 0;
            cbPBManual.Enabled = cbManualBarBox.Enabled = true;
            btnAdd.Text = "ADD";
            BindGrid();
            GetShortCode();
            pcItemId = 0;
            btnOQEntry.Visible = false;
            txtExtraPercent.Clear();
            txtBarcode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //SAVE CLICK
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int productId = 0;

            DbTransaction trans = UtilsDAO.BeginTransaction();

            try
            {
                if (CheckValidity())
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    Product oProduct = new Product();

                    if (cbHasPiece.Checked)
                    {
                        oProduct.categorytId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
                        oProduct.barcodeNo = txtPBarcode.Text.Trim();
                        //if (cbVarWeight.Checked)
                        //    oProduct.name = txtPName.Text.Trim().Split('(')[0] + "1 Kg";
                        //else
                            oProduct.name = txtPName.Text.Trim();
                        oProduct.shortcode = string.Empty;
                        oProduct.description = txtDescription.Text.Trim();
                        oProduct.brand = txtBrand.Text.Trim();
                        oProduct.madeIn = cmbPriceType.Text;
                        oProduct.isGstItem = chkGst.Checked;
                        oProduct.isexpireable = chkExpirable.Checked;
                        oProduct.unitCost = Convert.ToDouble(txtPRetailPrice.Text);
                        oProduct.unitPrice = Convert.ToDouble(txtPWSPrice.Text);
                        oProduct.promoUnitPrice = Convert.ToDouble(txtPSpecPrice.Text);
                        oProduct.unitMeasureId = Int16.Parse(cmbMeasurementUnit.SelectedValue.ToString());
                        oProduct.ProductImage = pM_barrImg;
                        oProduct.minQty = 0;
                        oProduct.weight = Convert.ToDouble(txtPweight.Text);
                        oProduct.qtyInStock = -3; //FOR PIECE Product
                        if (cbVarWeight.Checked)
                        {
                            oProduct.ticketType = true;
                            oProduct.enteredby = string.IsNullOrEmpty(txtExtraPercent.Text.Trim()) ? 0 : Convert.ToInt32(txtExtraPercent.Text); //Extra Percent for Piece
                        }
                        else
                        {
                            oProduct.ticketType = false;
                            oProduct.enteredby = 0;
                        }
                        oProduct.updatedby = MDIParent.userId;

                        if (btnAdd.Text.Trim() == "ADD")
                        {
                            pcItemId = oProductDAO.Add(oProduct);
                        }
                        else
                        {
                            if (pcItemId > 0)
                            {
                                oProduct.productId = pcItemId;
                                oProductDAO.Update(oProduct);
                            }
                            else
                                Alert("Piece Item Update Error.");
                        }
                    }
                    //else
                    //    txtPCBox.Text = "1";

                    oProduct.categorytId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());//txtPCBox.Text.Trim()
                    oProduct.barcodeNo = txtBarcode.Text.Trim();
                    oProduct.name = txtName.Text.Trim(); //+" [" + txtPCBox.Text.Trim() + " X " + Convert.ToDouble(txtweight.Text.Trim()) / Convert.ToDouble(txtPCBox.Text) + " " + cmbMeasurementUnit.Text + "] (MC)";
                    oProduct.shortcode = txtShortcode.Text.Trim();
                    oProduct.description = txtDescription.Text.Trim();
                    oProduct.brand = txtBrand.Text.Trim();
                    oProduct.madeIn = cmbPriceType.Text;
                    oProduct.weight = string.IsNullOrEmpty(txtweight.Text.Trim()) ? 1 : Convert.ToDouble(txtweight.Text.Trim());
                    oProduct.isGstItem = chkGst.Checked;
                    oProduct.isexpireable = chkExpirable.Checked;
                    oProduct.unitCost = Convert.ToDouble(txtRetailPrice.Text);
                    oProduct.unitPrice = Convert.ToDouble(txtWSPrice.Text);
                    oProduct.promoUnitPrice = Convert.ToDouble(txtSpecPrice.Text);
                    oProduct.ProductImage = m_barrImg;
                    oProduct.unitMeasureId = Int16.Parse(cmbMeasurementUnit.SelectedValue.ToString());
                    oProduct.qtyInStock = pcItemId;
                    oProduct.qtyInOrder = string.IsNullOrEmpty(txtPCBox.Text.Trim()) ? 1 : Convert.ToDouble(txtPCBox.Text);
                    oProduct.minQty = string.IsNullOrEmpty(txtReorder.Text.Trim()) ? 1 : Convert.ToDouble(txtReorder.Text.Trim());
                    oProduct.ticketType = false;
                    oProduct.enteredby = 0;
                    oProduct.updatedby = MDIParent.userId;


                    try
                    {
                        //SAVE ITEM
                        if (btnAdd.Text.Trim() == "ADD")
                        {
                            int result = oProductDAO.Add(oProduct);
                            if (result > 0)
                                resetAll();
                            else
                                MessageBox.Show("Unable to Save.", "POSsible");
                        }
                        else if (btnAdd.Text == "UPDATE")
                        {
                            //UPDATE
                            if (txtProductId.Text.Trim() != "")
                                productId = Convert.ToInt32(txtProductId.Text.Trim());

                            if (productId > 0)
                            {

                                int result;
                                oProduct.productId = productId;
                                result = oProductDAO.Update(oProduct);
                                if (result > 0)
                                {
                                    btnAdd.Text = "ADD";
                                    MessageBox.Show("Product " + oProduct.name + " Updated.", "POSsible");
                                    resetAll();
                                }
                                else
                                {
                                    txtBarcode.Focus();
                                }

                            }
                            else
                                MessageBox.Show("Unable to update. Item ID is not found.", "POSsible");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error while saving data.", "POSsible");
                    }
                }
                UtilsDAO.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "\nCould not Save", "POSsible");
            }
            finally
            {
                if (DbProviderHelper.IsInTransaction)
                    UtilsDAO.RollbackTransaction(trans);
            }
            //BindGrid();
        }

        private bool CheckValidity()
        {
            if (txtBarcode.Text == "")
            {
                Alert("Enter Item Barcode");
                txtBarcode.Focus();
                return false;
            }

            if (txtShortcode.Text == "")
            {
                Alert("Enter Item Short Code");
                txtShortcode.Focus();
                return false;
            }

            if (txtShortcode.Text.Length < 5)
            {
                MessageBox.Show("Shortcode needs to be atleast 5 digits");
                txtShortcode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                Alert("Enter Item Name.");
                txtName.Focus();
                return false;
            }
            else
            {
                Product prod = new Product();
                if (btnAdd.Text == "ADD")
                    prod = lstProduct.Where(p => p.name.Trim().ToLower() == txtName.Text.Trim().ToLower()).FirstOrDefault();
                else
                    prod = lstProduct.Where(p => p.name.Trim().ToLower() == txtName.Text.Trim().ToLower() && p.productId != Convert.ToInt32(txtProductId.Text)).FirstOrDefault();

                if (prod != null && prod.productId > 0)
                {
                    Alert("Item Name already entered");
                    txtName.Focus();
                    return false;
                }
            }

            if (cmbCategory.SelectedIndex < 0)
            {
                Alert("Select Category");
                cmbCategory.Focus();
                return false;
            }

            if (cmbMeasurementUnit.SelectedIndex < 0)
            {
                Alert("Select Unit");
                cmbMeasurementUnit.Focus();
                return false;
            }

            if (txtRetailPrice.Text == "")
            {
                Alert("Enter Sell Price");
                txtRetailPrice.Focus();
                return false;
            }

            //if (txtBrand.Text == "")
            //{
            //    Alert("Enter Item Brand Name.");
            //    txtBrand.Focus();
            //    return false;
            //}

            //if (txtweight.Text == "")
            //{
            //    Alert("Enter weight.");
            //    txtweight.Focus();
            //    return false;
            //}

            //if (txtReorder.Text.Trim() == "")
            //{
            //    Alert("Please enter Reorder Level");
            //    txtReorder.Focus();
            //    return false;
            //}

            if (!string.IsNullOrEmpty(txtReorder.Text.Trim()) && !Regex.IsMatch(txtReorder.Text, "^(\\+|-)?\\d+(\\.\\d+)?$"))
            {
                Alert("Please enter valid Reorder Level");
                txtReorder.Focus();
                return false;
            }

            if (cmbPriceType.SelectedIndex < 0)
            {
                Alert("Please select Price Type");
                cmbPriceType.Focus();
                return false;
            }

            if (cbHasPiece.Checked && string.IsNullOrEmpty(txtPBarcode.Text.Trim()))
            {
                Alert("Please provide Piece Barcode");
                txtPBarcode.Focus();
                return false;
            }

            if (cbHasPiece.Checked && string.IsNullOrEmpty(txtPCBox.Text.Trim()))
            {
                Alert("Please provide Piece Per Box");
                txtPCBox.Focus();
                return false;
            }

            return true;
        }

        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "POSsible");
        }

        private byte[] LoadImage(PictureBox PB, TextBox txtPB, byte[] img)
        {
            try
            {
                this.OFDPicture.ShowDialog(this);
                string fileName = this.OFDPicture.FileName;
                if (fileName == "openFileDialog1") return img;
                PB.Image = Image.FromFile(fileName);
                txtPB.Text = fileName;
                FileInfo fileInfo = new FileInfo(fileName);
                this.m_lImageFileLength = fileInfo.Length;

                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                img = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                int iBytesRead = fs.Read(img, 0, Convert.ToInt32(this.m_lImageFileLength));
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return img;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            m_barrImg = LoadImage(PBProduct, txtPictureBox, m_barrImg);
            if (m_barrImg != null)
                PBProduct.Visible = true;
        }

        private void btnPBrowse_Click(object sender, EventArgs e)
        {
            pM_barrImg = LoadImage(PBPieceImage, txtPPicBox, pM_barrImg);
            if (pM_barrImg != null)
                PBPieceImage.Visible = true;
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogResult dg = MessageBox.Show("Are you sure you want to delete this Item?", "Delete Product", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                    try
                    {
                        oProductDAO.Delete(Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells[2].Value));
                        dgvItem.Rows.RemoveAt(e.RowIndex);
                        resetAll();
                    }
                    catch (Exception)
                    {
                        Alert("Item already in Use. Could not delete.");
                    }
            }
            else if (e.ColumnIndex == 4)
            {
                btnAdd.Text = "UPDATE";
                bool loadOK = loadControls(e.ColumnIndex, e.RowIndex);
                if (!loadOK)
                {
                    btnAdd.Text = "ADD";
                    return;
                }
                cbHasPiece.Enabled = false;
                cbVarWeight.Enabled = false;
            }


        }

        private bool loadControls(int CI, int RI)
        {
            txtProductId.Text = "0";
            txtPcsId.Text = "0";

            int productId = Convert.ToInt32(dgvItem.Rows[RI].Cells[2].Value);
            txtProductId.Text = productId.ToString();

            Product productEntity = oProductDAO.Product_GetById(productId);
            if (productEntity == null) return false;
            txtBarcode.Text = productEntity.barcodeNo;
            txtShortcode.Text = productEntity.shortcode;
            txtName.Text = Regex.Split(productEntity.name, "\\[")[0];
            txtBrand.Text = productEntity.brand;
            cmbCategory.SelectedValue = productEntity.categorytId;
            cmbMeasurementUnit.SelectedValue = productEntity.unitMeasureId;
            txtDescription.Text = productEntity.description;
            txtReorder.Text = productEntity.minQty.ToString();
            txtweight.Text = productEntity.weight.ToString();
            chkGst.Checked = productEntity.isGstItem.Value;
            chkExpirable.Checked = productEntity.isexpireable.Value;
            cmbPriceType.SelectedIndex = (productEntity.madeIn == "Fixed") ? 0 : 1;
            cbHasPiece.Checked = (productEntity.qtyInStock > 0) ? true : false;
            cbVarWeight.Checked = productEntity.ticketType.Value;
            txtPCBox.Text = productEntity.qtyInOrder.ToString();
            txtRetailPrice.Text = productEntity.unitCost.ToString();
            txtWSPrice.Text = productEntity.unitPrice.ToString();
            txtSpecPrice.Text = productEntity.promoUnitPrice.ToString();
            byte[] imgRaw = productEntity.ProductImage;
            if (imgRaw != null)
            {
                MemoryStream ms = new MemoryStream(imgRaw);
                PBProduct.Image = Image.FromStream(ms);
                PBProduct.Visible = true;
            }
            else
            {
                PBProduct.Image = null;
                PBProduct.Invalidate();
                PBProduct.Visible = false;
            }

            string where = "T.[TransType]=0 AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + productEntity.productId;

            if (productEntity.qtyInStock > 0)
            {
                pcItemId = Convert.ToInt32(productEntity.qtyInStock);
                txtPcsId.Text = pcItemId.ToString();

                chkGst.Checked = true;
                Product pieceProduct = oProductDAO.Product_GetById(Convert.ToInt32(productEntity.qtyInStock));
                if (pieceProduct != null)
                {
                    if (pieceProduct.ticketType.Value) txtExtraPercent.Text = pieceProduct.enteredby.ToString();
                    cbVarWeight.Checked = pieceProduct.ticketType.Value;

                    txtPBarcode.Text = pieceProduct.barcodeNo;
                    txtPName.Text = pieceProduct.name;
                    txtPweight.Text = pieceProduct.weight.ToString();
                    txtPRetailPrice.Text = String.Format("{00:00.00}", pieceProduct.unitCost);
                    txtPWSPrice.Text = String.Format("{00:00.00}", pieceProduct.unitPrice);
                    txtPSpecPrice.Text = String.Format("{00:00.00}", pieceProduct.promoUnitPrice);

                    imgRaw = pieceProduct.ProductImage;
                    if (imgRaw != null)
                    {
                        MemoryStream ms = new MemoryStream(imgRaw);
                        PBPieceImage.Image = Image.FromStream(ms);
                        PBPieceImage.Visible = true;
                    }
                    else
                    {
                        PBPieceImage.Image = null;
                        PBPieceImage.Invalidate();
                        PBPieceImage.Visible = false;
                    }
                    where = "T.[TransType]=0 AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + productEntity.productId + ", " + pieceProduct.productId + ")";
                }
            }
            else
                pcItemId = 0;

            pieceUpdate();
            cbPBManual.Enabled = cbManualBarBox.Enabled = false;
            btnOQEntry.Enabled = true;

            Transaction t = new TransactionDAO().Transaction_GetDynamic(where, "").FirstOrDefault();
            if (t != null) btnOQEntry.Visible = false;

            return true;
        }

        private void cmbSearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchFilter.SelectedIndex == 1)
            {
                //BARCODE SEARCH
                cmbItemNameSearch.Visible = false;
                cmbItemBarcodeSearch.Visible = true;
            }
            else
            {
                //NAME SEARCH
                cmbItemNameSearch.Visible = true;
                cmbItemBarcodeSearch.Visible = false;
            }
        }

        private void cmbItemBarcodeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvItem.Rows.Clear();
            Product entity = oProductDAO.Product_GetById(Convert.ToInt32(cmbItemBarcodeSearch.SelectedValue));
            if (entity != null)
                dgvItem.Rows.Add(entity.name, entity.shortcode, entity.productId);
        }

        private void cmbItemNameSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvItem.Rows.Clear();
            Product entity = oProductDAO.Product_GetById(Convert.ToInt32(cmbItemNameSearch.SelectedValue));
            if (entity != null)
                dgvItem.Rows.Add(entity.name, entity.shortcode, entity.productId);
        }

        private void btnItemNameSearch_Click(object sender, EventArgs e)
        {
            string query = "";

            if (cmbSearchCategory.SelectedIndex > -1 && cmbItemNameSearch.Text != "")
                query = "[name] LIKE '%" + cmbItemNameSearch.Text + "%' AND [categorytId] ='" + Convert.ToInt32(cmbSearchCategory.SelectedValue) + "'";

            else if (cmbSearchCategory.SelectedIndex > -1 && cmbItemNameSearch.Text == "")
                query = "[categorytId] ='" + Convert.ToInt32(cmbSearchCategory.SelectedValue) + "'";

            else if (cmbItemNameSearch.Text == "") { Alert("Nothing to Search."); return; }

            else
                query = "[name] LIKE '%" + cmbItemNameSearch.Text + "%'";

            List<Product> lstProductD = oProductDAO.Product_GetDynamic(query, "");
            lstProductD = lstProductD.Where(x => x.qtyInStock != -3).ToList();
            if (lstProductD.Count > 0)
            {
                dgvItem.Rows.Clear();
                foreach (Product item in lstProductD)
                {
                    dgvItem.Rows.Add(item.name, item.shortcode, item.productId, item.weight + " Kg");
                }
            }
            else
                Alert("Could not find anything.");
        }

        private void txtReorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void txtweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtweight.Text);
        }

        //private void txtQtyInStock_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    Helper.InputOnlyInt(sender, e);
        //    pieceUpdate();
        //}

        private void txtRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtRetailPrice.Text);
        }

        private void txtWSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtWSPrice.Text);
        }

        private void txtSpecPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtSpecPrice.Text);
        }

        private void txtPRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPRetailPrice.Text);
        }

        private void txtPWSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPWSPrice.Text);
        }

        private void txtPSpecPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPSpecPrice.Text);
        }

        //private void txtPQtyInStock_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    Helper.InputOnlyInt(sender, e);
        //}

        private void txtPROLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPRetailPrice.Text);
        }

        private void txtPweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtPweight.Text);
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text.Trim()))
            {
                Product P = oProductDAO.Product_GetDynamic("[barcodeNo]='" + txtBarcode.Text.Trim() + "'", "").FirstOrDefault();
                if (P != null)
                {
                    MessageBox.Show("The Barcode is already used.", "POSsible");
                    txtBarcode.Clear();
                    txtBarcode.Focus();
                    return;
                }
            }
        }

        private void btnDeptSearch_Click(object sender, EventArgs e)
        {
            frmProductCategory frmPC = new frmProductCategory();
            frmPC.ShowDialog();
            cmbCategoryBind();
        }

        private void btnUnitSearch_Click(object sender, EventArgs e)
        {
            frmUnitMeasurement frmUOM = new frmUnitMeasurement();
            frmUOM.ShowDialog();
            cmbMeasurementUnitBind();
        }

        private void pieceUpdate()
        {
            txtSpecPrice.Text = txtWSPrice.Text = txtRetailPrice.Text;
            if (!cbHasPiece.Checked) return;
            double pcBox = (string.IsNullOrEmpty(txtPCBox.Text)) ? 1 : Convert.ToDouble(txtPCBox.Text);
            double pWeight = (string.IsNullOrEmpty(txtweight.Text)) ? 1 : Convert.ToDouble(txtweight.Text);
            if (cmbPriceType.SelectedIndex == 0)
            {
                txtPName.Text = (string.IsNullOrEmpty(txtName.Text)) ? "" : txtName.Text;
                if (cbVarWeight.Checked)
                {
                    pcBox = pWeight;
                    double extPrcnt = (string.IsNullOrEmpty(txtExtraPercent.Text)) ? 0 : (Convert.ToDouble(txtExtraPercent.Text));
                    double pcPrice = (string.IsNullOrEmpty(txtRetailPrice.Text)) ? 0 : (Convert.ToDouble(txtRetailPrice.Text) / pcBox);
                    double pcPriceWithExtraPrcnt = extPrcnt > 0 ? (pcPrice + ((pcPrice * extPrcnt) / 100)) : (pcPrice);
                    txtPCBox.Text = pWeight.ToString();
                    txtPRetailPrice.Text = (string.IsNullOrEmpty(txtRetailPrice.Text)) ? "0" : String.Format("{00:00.00}", pcPriceWithExtraPrcnt);
                    txtPWSPrice.Text = (string.IsNullOrEmpty(txtRetailPrice.Text)) ? "0" : String.Format("{00:00.00}", pcPriceWithExtraPrcnt);
                    txtPSpecPrice.Text = (string.IsNullOrEmpty(txtRetailPrice.Text)) ? "0" : String.Format("{00:00.00}", pcPriceWithExtraPrcnt);
                }
                else
                {
                    txtPRetailPrice.Text = (string.IsNullOrEmpty(txtRetailPrice.Text)) ? "0" : String.Format("{00:00.00}", (Convert.ToDouble(txtRetailPrice.Text) / pcBox));
                    txtPWSPrice.Text = (string.IsNullOrEmpty(txtWSPrice.Text)) ? "0" : String.Format("{00:00.00}", (Convert.ToDouble(txtWSPrice.Text) / pcBox));
                    txtPSpecPrice.Text = (string.IsNullOrEmpty(txtSpecPrice.Text)) ? "0" : String.Format("{00:00.00}", (Convert.ToDouble(txtSpecPrice.Text) / pcBox)); 
                }
            }
            else if (cmbPriceType.SelectedIndex == 1)
            {
                txtPRetailPrice.Text = (string.IsNullOrEmpty(txtRetailPrice.Text)) ? "0" : String.Format("{00:00.00}", (Convert.ToDouble(txtRetailPrice.Text) / pcBox));
                txtPWSPrice.Text = (string.IsNullOrEmpty(txtWSPrice.Text)) ? "0" : String.Format("{00:00.00}", (Convert.ToDouble(txtWSPrice.Text) / pcBox));
                txtPSpecPrice.Text = (string.IsNullOrEmpty(txtSpecPrice.Text)) ? "0" : String.Format("{00:00.00}", (Convert.ToDouble(txtSpecPrice.Text) / pcBox)); 
            }
            txtPweight.Text = (string.IsNullOrEmpty(txtPCBox.Text)) ? "0" : (pWeight / pcBox).ToString();

            txtPName.Text = cbVarWeight.Checked ? (txtName.Text.Trim().Split('(')[0] + " 1 Kg") : (txtName.Text.Trim() + " " + txtPweight.Text + " Kg (Pcs)");
        }

        private void txtPCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void cmbPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pieceUpdate();
        }

        private void txtShortcode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtShortcode.Text.Trim()))
            {
                if (txtShortcode.Text.Length < 5)
                {
                    MessageBox.Show("Shortcode needs to be atleast 5 digits");
                    txtShortcode.Focus();
                    return;
                }

                Product P = oProductDAO.Product_GetDynamic("[shortcode]='" + txtShortcode.Text.Trim() + "'", "").FirstOrDefault();
                if (P != null)
                {
                    MessageBox.Show("The Shortcode is already used.", "POSsible");
                    txtShortcode.Clear();
                    txtShortcode.Focus();
                    return;
                }
            }
        }

        private void txtShortcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtShortcode.Text);
        }

        private void btnOQEntry_Click(object sender, EventArgs e)
        {
            OpeningQtyEntry frm = new OpeningQtyEntry();
            frm.ControlBox = false;
            OpeningQtyEntry.FromItemEntry = true;
            OpeningQtyEntry.CrtId = Convert.ToInt32(txtProductId.Text);
            OpeningQtyEntry.PcsId = Convert.ToInt32(txtPcsId.Text);
            frm.Show();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            pieceUpdate();
        }

        private void cbVarWeight_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVarWeight.Checked)
            {
                pieceUpdate();
                lblExtra.Visible = txtExtraPercent.Visible = false;
                cmbPriceType.Enabled = false;
                if (btnAdd.Text == "ADD")
                {
                    cbPBManual.Checked = true;
                    cbPBManual.Enabled = false;
                    cmbPriceType.SelectedIndex = 0;
                }
            }
            else
            {
                txtPCBox.Clear();
                cmbPriceType.Enabled = true;
                lblExtra.Visible = txtExtraPercent.Visible = false;
                if (btnAdd.Text == "ADD")
                {
                    cbPBManual.Checked = false;
                    cbPBManual.Enabled = true;
                    cmbPriceType.SelectedIndex = 0;
                }
            }
            cbPBManual_CheckedChanged(null, null);
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cmbCategory.SelectedIndex > -1 && btnAdd.Text == "ADD")
            //{
            //    List<Product> lstProductSC = lstProduct;
            //    txtShortcode.Text = lstProductSC.Count > 0 ? (Convert.ToInt32(lstProductSC.Where(p => p.categorytId == Convert.ToInt32(cmbCategory.SelectedValue)).OrderByDescending(p => p.shortcode).FirstOrDefault().shortcode) + 1).ToString().PadLeft(5, '0') : "00001";
            //}
        }
    }
}