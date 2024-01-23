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
    public partial class frmProductPromotion : Form
    {
        #region VARIABLES
        UserLogins oUser = new UserLogins();
        ProductPromotionDAO oProductPromotionDAO = new ProductPromotionDAO();
        int pId = 0;
        #endregion

        #region METHODS
        public frmProductPromotion()
        {
            InitializeComponent();
            cmbProductBind();
            cmbCategoryBind();
            bindGrid();
        }

        private void bindGrid()
        {
            dgvPromotion.Rows.Clear();

            List<ProductPromotion> PPList = oProductPromotionDAO.ProductPromotion_GetAll();
            if (PPList.Count > 0)
            {
                foreach (ProductPromotion item in PPList)
                {
                    dgvPromotion.Rows.Add("PPN/530" + item.PromoId, item.StartDate, item.EndDate, item.PromoChargeType, item.PromoId);
                }
            }
        }

        private void cmbCategoryBind()
        {

            List<ProductCategory> lstCategoryPromo = new ProductCategoryDAO().ProductCategory_GetAll();
            if (lstCategoryPromo.Count > 0)
            {
                cmbCategoryPromo.DataSource = lstCategoryPromo;
                cmbCategoryPromo.SelectedIndex = -1;
            }
        }

        private void cmbProductBind()
        {
            List<Product> lstProduction = new ProductDAO().Product_GetAll();
            if (lstProduction.Count > 0)
            {
                cmbProduct.DataSource = lstProduction;
                cmbProduct.SelectedIndex = -1;
            }

            List<Product> lstProductionPromo = new ProductDAO().Product_GetAll();
            if (lstProductionPromo.Count > 0)
            {
                cmbProductPromo.DataSource = lstProductionPromo;
                cmbProductPromo.SelectedIndex = -1;
            }
        }

        private bool checkValidity()
        {
            if (rbPOProduct.Checked && cmbProductPromo.SelectedIndex < 0)
            {
                Alert("Please Select Promotion Product");
                return false;
            }
            if (rbPOCatalogue.Checked && cmbCategoryPromo.SelectedIndex < 0)
            {
                Alert("Please Select Promotion Category.");
                return false;
            }
            if (dtpStartDate.Value == DateTime.MinValue)
            {
                Alert("Invalid Start date.");
                return false;
            }
            if (dtpEndDate.Value == DateTime.MinValue)
            {
                Alert("Invalid End date.");
                return false;
            }
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                Alert("End Date should be bigger than Start Date.");
                return false;
            }
            if (txtVariation.Text == "")
            {
                Alert("Enter Price/Percentage/Quantity.");
                return false;
            }
            if (rbPTFree.Checked)
            {
                if (txtFreeQty.Text == "")
                {
                    Alert("Enter Free Quantity.");
                    return false;
                }
                if (cmbProduct.SelectedIndex < 0)
                {
                    Alert("Please Select Product.");
                    return false;
                }
            }
            return true;
        }

        public void Alert(string sMsg)
        {
            MessageBox.Show(sMsg, "POSsible");
        }
        #endregion

        #region EVENTS
        private void rbPOProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPOProduct.Checked)
            {
                lblPromo.Text = "Product";
                cmbProductPromo.Visible = true;
                cmbCategoryPromo.Visible = false;
                cmbCategoryPromo.SelectedIndex = -1;
                cmbProductPromo.SelectedIndex = -1;
                rbPTFixed.Checked = true;
                rbPTPercentage.Checked = false;
                rbPTFixed.Enabled = true;
            }
            else
            {
                lblPromo.Text = "Category";
                cmbProductPromo.Visible = false;
                cmbCategoryPromo.Visible = true;
                cmbCategoryPromo.SelectedIndex = -1;
                cmbProductPromo.SelectedIndex = -1;
                rbPTFixed.Checked = false;
                rbPTPercentage.Checked = true;
                rbPTFixed.Enabled = false;
            }
        }

        private void rbPTFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPTFixed.Checked)
                lblVariation.Text = "Price";
            else if (rbPTPercentage.Checked)
                lblVariation.Text = "Percentage";
            else if (rbPTFree.Checked)
            {
                lblVariation.Text = "Sale Qty";

                label7.Visible = true;
                txtFreeQty.Visible = true;
                lblProduct.Visible = true;
                cmbProduct.Visible = true;

            }
            if (!rbPTFree.Checked)
            {
                label7.Visible = false;
                txtFreeQty.Visible = false;
                lblProduct.Visible = false;
                cmbProduct.Visible = false;
            }

        }

        private void rbPTPercentage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPTPercentage.Checked)
                lblVariation.Text = "Percentage";
            else if (rbPTFixed.Checked)
                lblVariation.Text = "Price";
            else if (rbPTFree.Checked)
            {
                lblVariation.Text = "Sale Qty";

                label7.Visible = true;
                txtFreeQty.Visible = true;
                lblProduct.Visible = true;
                cmbProduct.Visible = true;

            }
            if (!rbPTFree.Checked)
            {

                label7.Visible = false;
                txtFreeQty.Visible = false;
                lblProduct.Visible = false;
                cmbProduct.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkValidity()) return;

            #region Check For Duplicate Promotion
            if (rbPOProduct.Checked)
            {
                string where = "[PromoOnType]='Product' AND [PromoOnId]=" + cmbProductPromo.SelectedValue + " AND dbo.TrimTime([EndDate]) >= dbo.TrimTime('" + dtpStartDate.Value + "')";
                List<ProductPromotion> lstProCheck = oProductPromotionDAO.ProductPromotion_GetDynamic(where, "");
                if (lstProCheck.Count > 0)
                {
                    Alert("Same Product Promotion is running!"); return;
                }

                Product pro = new ProductDAO().Product_GetById(Convert.ToInt32(cmbProductPromo.SelectedValue));
                string where2 = "[PromoOnType]='Category' AND [PromoOnId]=" + pro.categorytId + " AND dbo.TrimTime([EndDate]) >= dbo.TrimTime('" + dtpStartDate.Value + "')";
                List<ProductPromotion> lstCatCheck = oProductPromotionDAO.ProductPromotion_GetDynamic(where2, "");
                if (lstCatCheck.Count > 0)
                {
                    Alert("Same Product Category Promotion is running!"); return;
                }
                
            }
            else
            {
                string where = "[PromoOnType]='Category' AND [PromoOnId]=" + cmbCategoryPromo.SelectedValue + " AND dbo.TrimTime([EndDate]) >= dbo.TrimTime('" + dtpStartDate.Value + "')";
                List<ProductPromotion> lstCatCheck = oProductPromotionDAO.ProductPromotion_GetDynamic(where, "");
                if (lstCatCheck.Count > 0)
                {
                    Alert("Same Category Promotion is running!"); return;
                }

                string where2 = "[PromoOnType]='Product' AND dbo.TrimTime([EndDate]) >= dbo.TrimTime('" + dtpStartDate.Value + "')";
                List<ProductPromotion> lstProCheck = oProductPromotionDAO.ProductPromotion_GetDynamic(where2, "");
                if (lstProCheck.Count > 0)
                {
                    foreach (ProductPromotion item in lstProCheck)
                    {
                        Product pro = new ProductDAO().Product_GetById(item.PromoOnId);
                        if (pro.categorytId == Convert.ToInt32(cmbCategoryPromo.SelectedValue))
                        {
                            Alert("A Product Promotion of same Category is running!"); return;                            
                        }
                    }
                }
            }
            #endregion

            try
            {
                #region DATA
                ProductPromotion PPEntity = new ProductPromotion();

                if (rbPTFixed.Checked)
                {
                    PPEntity.PromoChargeType = "Fixed";
                    PPEntity.Price = Convert.ToDouble(txtVariation.Text);
                }
                else if (rbPTPercentage.Checked)
                {
                    PPEntity.PromoChargeType = "Percentage";
                    PPEntity.Percentage = Convert.ToInt32(txtVariation.Text);
                }
                else if (rbPTFree.Checked)
                {
                    PPEntity.PromoChargeType = "Free";
                    PPEntity.SaleQty = Convert.ToInt32(txtVariation.Text);
                    PPEntity.FreeQty = Convert.ToInt32(txtFreeQty.Text);
                    PPEntity.FreeType = "Product";
                    PPEntity.FreeTypeId = Convert.ToInt32(cmbProduct.SelectedValue);
                }

                PPEntity.PromoOnId = (rbPOProduct.Checked) ? Convert.ToInt32(cmbProductPromo.SelectedValue) : Convert.ToInt32(cmbCategoryPromo.SelectedValue);
                PPEntity.StartDate = dtpStartDate.Value;
                PPEntity.EndDate = dtpEndDate.Value;
                PPEntity.CreatedBy = oUser.UserLoginId;
                PPEntity.PromoOnType = (rbPOProduct.Checked) ? "Product" : "Category";
                #endregion

                if (btnSave.Tag == "SAVE")
                {
                    pId = oProductPromotionDAO.Add(PPEntity);
                }
                else if (btnSave.Tag == "UPDATE")
                {
                    PPEntity.PromoId = pId;
                    oProductPromotionDAO.Update(PPEntity);
                }

                btnReset.PerformClick();
            }
            catch (Exception ex)
            {

                Alert("Save Error.\n " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rbPOProduct.Checked = true;
            dtpStartDate.Value = DateTime.Now.Date;
            dtpEndDate.Value = DateTime.Now.AddDays(7);
            rbPTFixed.Checked = true;
            txtVariation.Clear();
            cmbProductPromo.SelectedIndex = -1;
            cmbCategoryPromo.SelectedIndex = -1;
            txtFreeQty.Clear();

            btnSave.Tag = "SAVE";
            btnSave.Text = "SAVE";

            bindGrid();
        }

        private void dgvPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int promoId = Convert.ToInt32(dgvPromotion.Rows[e.RowIndex].Cells[4].Value);

            if (e.ColumnIndex == 6)   //DELETE
            {
                if (promoId < 1) return;

                DialogResult dg = MessageBox.Show("Are you sure you want to delete this Promotion Offer?", "Delete Promotion Offer", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                    try
                    {
                        oProductPromotionDAO.Delete(promoId);
                        dgvPromotion.Rows.RemoveAt(e.RowIndex);
                    }
                    catch (Exception)
                    {
                        Alert("Could not delete.");
                    }
            }

            if (e.ColumnIndex == 5) //EDIT
            {
                ProductPromotion PPEntity = oProductPromotionDAO.ProductPromotion_GetById(promoId);
                if (PPEntity == null) return;

                rbPOProduct.Checked = (PPEntity.PromoOnType == "Product") ? true : false;

                if (rbPOProduct.Checked)
                    cmbProductPromo.SelectedValue = PPEntity.PromoOnId;
                else
                    cmbCategoryPromo.SelectedValue = PPEntity.PromoOnId;

                dtpStartDate.Value = PPEntity.StartDate.Date;
                dtpEndDate.Value = PPEntity.EndDate.Date;

                if (PPEntity.PromoChargeType == "Fixed") rbPTFixed.Checked = true;
                else if (PPEntity.PromoChargeType == "Free") rbPTFree.Checked = true;
                else rbPTPercentage.Checked = true;


                if (PPEntity.PromoChargeType == "Fixed")
                {
                    lblVariation.Text = "Price";
                    txtVariation.Text = PPEntity.Price.ToString();
                }
                else if (PPEntity.PromoChargeType == "Percentage")
                {
                    lblVariation.Text = "Percentage";
                    txtVariation.Text = PPEntity.Percentage.ToString();
                }


                if (PPEntity.PromoChargeType == "Free")
                {
                    lblVariation.Text = "Sale Qty";
                    txtVariation.Text = PPEntity.SaleQty.ToString();
                    txtFreeQty.Text = PPEntity.FreeQty.ToString();


                }
                pId = PPEntity.PromoId;

                btnSave.Text = "UPDATE";
                btnSave.Tag = "UPDATE";
            }
        }

        private void txtFreeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyInt(sender, e);
        }

        private void txtVariation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbPTFixed.Checked)
                Helper.InputOnlyNumbers(sender, e, txtVariation.Text);
            else if (rbPTFree.Checked)
                Helper.InputOnlyInt(sender, e);
            else if (rbPTPercentage.Checked)
            {
                Helper.InputOnlyNumbers(sender, e, txtVariation.Text);
                try
                {
                    if (Convert.ToDouble(txtVariation.Text) > 100)
                    {
                        MessageBox.Show("Can't be more than 100 Percent.", "POSsible");
                        return;
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show("Invalid Entry.", "POSsible");
                }
            }
        }
        #endregion
    }
}
