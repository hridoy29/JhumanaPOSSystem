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

namespace POSsible
{
    public partial class frmProductCategory : Form, IProductCategoryView
    {
        /// <summary>
        /// Reference of IProductCategoryManager
        /// </summary>
        //private IProductCategoryManager _ProdectCategoryManager;
        private int iRowIndex = 0;

        ProductCategoryDAO oProductCategoryDAO = new ProductCategoryDAO();

        public CUser oUserLogin = new CUser();

        public frmProductCategory()
        {
            InitializeComponent();
            BindGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Put Value for Status List
        /// </summary>
        public void putStatusList()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Select Category");
            cmbStatus.ValueMember = "Select Category";
            cmbStatus.Items.Add("Scan");
            cmbStatus.ValueMember = "0";
            cmbStatus.Items.Add("Non-Scan");
            cmbStatus.ValueMember = "1";
            cmbStatus.SelectedIndex = 0;
        }

        private void frmProductCategory_Load(object sender, EventArgs e)
        {
            //bind status
        }

        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "RITPOS");
        }


        /// <summary>
        /// Check Validity all of the check box
        /// </summary>
        /// <returns>True/False</returns>
        private bool CheckValidity()
        {
            if (txtCategoryName.Text == "")
            {
                Alert("Enter product category name.");
                txtCategoryName.Focus();
                return false;
            }
         
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void SaveData()
        {
            try
            {
                if (CheckValidity())
                {
                    ProductCategory oProductCategory = new ProductCategory();

                    oProductCategory.deptName = txtCategoryName.Text.Trim();
                    oProductCategory.description = (string.IsNullOrEmpty(txtCategoryDescription.Text)) ? " " : txtCategoryDescription.Text.Trim();

                    oProductCategory.CodePrefix = "Non-scan";

                    oProductCategory.enteredby = Convert.ToInt32(MDIParent.userId.ToString());
                    oProductCategory.updatedby = Convert.ToInt32(MDIParent.userId.ToString());

                    if (btnAdd.Text == "UPDATE")
                    {
                        oProductCategory.categoryId = int.Parse(txtProductCategoryID.Text);
                        oProductCategoryDAO.Update(oProductCategory);
                        BindGrid();
                    }
                    else if (btnAdd.Text == "ADD")
                    {
                        int iCategoryId = oProductCategoryDAO.Add(oProductCategory);
                        BindGrid();
                        ////dgvSupplier.Rows.Add(iSupplierId.ToString(), oSupplier.SupplierName, oSupplier.ContactPerson);
                        ////dgvSupplier.Sort(cname,ListSortDirection.Ascending);
                    }

                    AddMode();
                }
            }
            catch (Exception exc)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert(exc.Message + "Product Category information did not updated successfully.");
                }
                else
                {
                    Alert(exc.Message + "Product Category information did not added successfully.");
                }

            }
        }


        /// <summary>
        /// Load Product category to the grid
        /// </summary>
        private void BindGrid()
        {
            dgvProductCategory.Rows.Clear();
            List<ProductCategory> lProductCategoryList = new List<ProductCategory>();

            lProductCategoryList = oProductCategoryDAO.ProductCategory_GetAll();

            for (int i = 0; i < lProductCategoryList.Count; i++)
                dgvProductCategory.Rows.Add(lProductCategoryList[i].categoryId.ToString(), lProductCategoryList[i].deptName, lProductCategoryList[i].CodePrefix);
        }


        /// <summary>
        /// Situation before add a supplier
        /// </summary>
        private void AddMode()
        {
            btnAdd.Text = "ADD";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = false;
            btnExit.Enabled = true;

            txtProductCategoryID.Enabled = false;
            txtCategoryDescription.Text = "";
            txtCategoryName.Text = "";
            txtProductCategoryID.Text = "";
            cmbStatus.SelectedIndex = 0;



            if (dgvProductCategory.Rows.Count > 0)
                dgvProductCategory.Rows[0].Selected = false;
            txtProductCategoryID.Focus();
        }


        /// <summary>
        /// Situation before edit or delete a supplier
        /// </summary>
        private void EditOrDeleteMode()
        {
            btnAdd.Text = "UPDATE";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;

            txtProductCategoryID.Enabled = false;
            txtCategoryDescription.Text = "";
            txtCategoryName.Text = "";
            cmbStatus.SelectedIndex = 0;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
            AddMode();
        }

        private void dgvProductCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvProductCategory.Rows[iRowIndex];

                try
                {
                    if (ObjDGVRow.Cells[0].Value != null)
                    {
                        EditOrDeleteMode();
                        ProductCategory oCDepartment = oProductCategoryDAO.ProductCategory_GetById(Int32.Parse(ObjDGVRow.Cells[0].Value.ToString()));
                        ShowData(oCDepartment);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Show all information in textbox controls for a selected Product Category
        /// </summary>
        /// <param name="CDepartment"></param>
        private void ShowData(ProductCategory oCDepartment)
        {
            txtProductCategoryID.Text = oCDepartment.categoryId.ToString();
            txtCategoryName.Text = oCDepartment.deptName;
            txtCategoryDescription.Text = oCDepartment.description;

            if (oCDepartment.CodePrefix == "Scan")
                cmbStatus.SelectedIndex = 1;
            else
                cmbStatus.SelectedIndex = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductCategoryID.Text == "") { Alert("Please Select a Category first."); return; }
            DialogResult result;
            result = MessageBox.Show("Do you want to delete this Product Category?", "RITPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                int ret = oProductCategoryDAO.Delete(int.Parse(txtProductCategoryID.Text));
                if (ret > 0)
                {
                    dgvProductCategory.Rows.RemoveAt(iRowIndex);
                    BindGrid();
                    AddMode();
                }
            }
        }

        private void txtCategoryName_Leave(object sender, EventArgs e)
        {
            if (txtCategoryName.Text != null)
            {
                ProductCategory P = oProductCategoryDAO.ProductCategory_GetDynamic("[deptName]='" + txtCategoryName.Text + "'", "").FirstOrDefault();
                if (P != null)
                {
                    MessageBox.Show("This Category is already used.", "POSsible");
                    txtCategoryName.Clear();
                    txtCategoryName.Focus();
                    return;
                }
            }
        }
    }
}