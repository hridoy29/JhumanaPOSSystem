using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using POSsible.Views;
using POSsible.Factories;

namespace POSsible
{
    public partial class frmDamage : Form, IItemView
    {
        /// <summary>
        /// Reference of IProductManager
        /// </summary>
        IProductManager _productManager;
        private int iRowIndex = 0;
        private double dQtyInStock = 0;
        public CUser oUserLogin = new CUser();

        public frmDamage()
        {
            InitializeComponent();
        }

        public frmDamage(CUser oUser)
        {
            InitializeComponent();
            oUserLogin = oUser;
            _productManager = Factory.GetProductManager(this);
            GetItem();
            ResetAll();
        }

        /// <summary>
        /// Fill the combo with the supplier
        /// </summary>
        private void GetItem()
        {
            List<CProduct> lProductList = _productManager.getAllItems();
            cboItemSelect.DataSource = lProductList;
            cboItemSelect.DisplayMember = "ProductName";
            cboItemSelect.ValueMember = "ProductId";
            
        }

        /// <summary>
        /// Clear all controls
        /// </summary>
        private void ResetAll()
        {
            btnAdd.Tag = "ADD";
            btnDelete.Text = "Save";

            dtpEntryDate.Text = DateTime.Now.Date.ToShortDateString();
            rtxtRemark.Text = "";
            //cboItemSelect.SelectedIndex = 0;
            txtQuantity.Text = "";
            txtUnitCost.Text = "";
            txtDescription.Text = "";
            dgvItem.Rows.Clear();
            if (cboItemSelect.SelectedIndex != 1)
                cboItemSelect.SelectedIndex = 0;
            dgvItem.Rows[0].Selected = false;
            cboItemSelect.Focus();
        }

        /// <summary>
        /// Filter keypress of the Quantity textbox. Interger value is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;

            if (iCode == 13)
                txtDescription.Focus();

            if ((iCode < 48 && iCode != 8) || iCode > 57)
                e.Handled = true;
            else
                e.Handled = false;
        }

        /// <summary>
        /// Filter keypress of the Unitcost textbox. Double value is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;

            if (iCode == 13)
                SaveRowToGrid();

            if ((iCode < 48 && iCode != 8 && iCode != 46) || iCode > 57)
                e.Handled = true;
            else
                e.Handled = false;
        }

        /// <summary>
        /// Filter keypress of the Description textbox. Interger value is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;

            if (iCode == 13)
            {
                SaveRowToGrid();
                
            }

        }

        /// <summary>
        /// Filter keypress of the Remark textbox. Interger value is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            int iCode = (int)e.KeyChar;
            
            //if (iCode == 13)
                //SaveRowToGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        /// <summary>
        /// Situation before add an item
        /// </summary>
        private void AddMode()
        {
            btnAdd.Tag = "ADD";
            btnDelete.Text = "Save";

            cboItemSelect.SelectedIndex = 0;
            txtQuantity.Text = "";
            txtUnitCost.Text = "";
            txtDescription.Text = "";

            dgvItem.Rows[0].Selected = false;
            cboItemSelect.Focus();
        }

        /// <summary>
        /// Situation before edit or delete an item
        /// </summary>
        private void EditOrDeleteMode()
        {
            btnAdd.Tag = "UPDATE";
            btnDelete.Text = "DELETE";
        }

        /// <summary>
        /// Method to add data to grid row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveRowToGrid()
        {
            try
            {
                if (cboItemSelect.SelectedIndex >= 0)
                    _productManager.getProductById(int.Parse(cboItemSelect.SelectedValue.ToString()));

                if (CheckValidityForAddRow()==true)
                {
                    // For Adding
                    if (btnAdd.Tag == "ADD")
                      
                        //dgvItem.Rows.Add("", "", txtQuantity.Text.Trim(), txtUnitCost.Text.Trim(), txtDescription.Text.Trim());
                    {
                        Boolean blupdate;
                        blupdate = false;
                        int irow=0;
                        for (int i = 0; i < dgvItem.Rows.Count - 1; i++)
                        {
                        if (dgvItem.Rows[i].Cells[0].Value.ToString() == cboItemSelect.SelectedValue.ToString())
                        {
                            blupdate = true;
                            irow = i;
                        }
                        }
                        if (blupdate == false)
                            dgvItem.Rows.Add(cboItemSelect.SelectedValue.ToString(), cboItemSelect.Text, txtQuantity.Text.Trim(), txtUnitCost.Text.Trim(), txtDescription.Text.Trim());
                        else
                        {
                            dgvItem.Rows.RemoveAt(irow);
                            dgvItem.Rows.Insert(irow, cboItemSelect.SelectedValue.ToString(), cboItemSelect.Text, txtQuantity.Text.Trim(), txtUnitCost.Text.Trim(), txtDescription.Text.Trim());
                        }
                    //end add

                    //For Updating
                    }
                    else if (btnAdd.Tag == "UPDATE")
                    {
                        dgvItem.Rows.RemoveAt(iRowIndex);
                        dgvItem.Rows.Insert(iRowIndex, cboItemSelect.SelectedValue.ToString(), cboItemSelect.Text, txtQuantity.Text.Trim(), txtUnitCost.Text.Trim(), txtDescription.Text.Trim());
                    }
                    //end update

                    // Change the for mode as addable
                    AddMode();
                    cboItemSelect.Focus();
                }
            }
            catch
            {

            }

            //cboItemSelect.Focus();
        }

        /// <summary>
        /// Click event of Add/Update button. It add an item to the grid or updates the values of selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveRowToGrid();
        }

        /// <summary>
        /// This is used to check required field validity for addint a item in the grid
        /// </summary>
        /// <returns>true/false</returns>
        private Boolean CheckValidityForAddRow()
        {
            if(cboItemSelect.SelectedIndex<0)
            {
                Alert("Select an item.");
                cboItemSelect.Focus();
                return false;
            }

            if (txtQuantity.Text.Trim() == "")
            {
                Alert("Enter damage quantity.");
                txtQuantity.Focus();
                return false;
            }

            else
            {
                if (dQtyInStock < Convert.ToDouble(txtQuantity.Text.Trim()))
                {
                    Alert("Damaged quantity cannot be greater than the quantity in stock.");
                    txtQuantity.Focus();
                    return false;
                }
            }

            if (txtUnitCost.Text.Trim() == "")
            {
                Alert("Enter unit cost.");
                txtUnitCost.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// SelectedIndexChanged event of Item combo. Its clears some controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboItemSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Do nothing ...
        }

        /// <summary>
        /// Click event of cells of grid. Is shows the values of the row in texboxes and allow the user to update or delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvItem.Rows[iRowIndex];

                if (ObjDGVRow.Cells[0].Value != null)
                {
                    //cboItemSelect.SelectedIndex = cboItemSelect.Items.IndexOf(dgvItem.Rows[iRowIndex].Cells[1].Value);
                    cboItemSelect.SelectedIndex = cboItemSelect.FindString(ObjDGVRow.Cells[1].Value.ToString());
                    txtQuantity.Text = ObjDGVRow.Cells[2].Value.ToString();
                    txtUnitCost.Text = ObjDGVRow.Cells[3].Value.ToString();
                    txtDescription.Text = ObjDGVRow.Cells[4].Value.ToString();
                    CProduct item = _productManager.getProductinfo(int.Parse(cboItemSelect.SelectedValue.ToString()));
                    //txtUnitCost.Text = item.UnitCost.ToString();
                    dQtyInStock = item.QtyInStock;
                    EditOrDeleteMode();
                }
                else
                {
                    AddMode();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "DELETE")
            {
                dgvItem.Rows.RemoveAt(iRowIndex);
                AddMode();
            }

            else if (btnDelete.Text == "Save")
            {
                if (CheckValidity())
                {
                    int iDamageId = _productManager.addDamageMain(rtxtRemark.Text.Trim(), DateTime.Now, MDIParent.userId);

                    for (int i = 0; i < dgvItem.Rows.Count - 1; i++)
                    {
                        _productManager.addDamageDetails(iDamageId, int.Parse(dgvItem.Rows[i].Cells[0].Value.ToString()), int.Parse(dgvItem.Rows[i].Cells[2].Value.ToString()), double.Parse(dgvItem.Rows[i].Cells[3].Value.ToString()), dgvItem.Rows[i].Cells[4].Value.ToString());
                    }

                    ResetAll();
                    Alert("Data added successfully.");
                }
            }
        }

        /// <summary>
        /// Validation check to add values in tables
        /// </summary>
        /// <returns>true/false</returns>
        private bool CheckValidity()
        {
            if (dgvItem.Rows.Count-1<1)
            {
                Alert("Enter some items.");
                return false;
            }

            return true;
        }

        #region Impletementation of IItemView method
        public void Alert(string sMsg)
        {
            MessageBox.Show(sMsg, "RITPOS");
        }
        public void updateItemGrid(List<CProduct> oProduct)
        {
        }
        public void ClearFormContent()
        {
        }
        public void FillUpFormContent(CProduct oProduct)
        {
           // dQtyInStock = oProduct.QtyInStock;
        }
        public void putDepartmentList(List<CDepartment> oLstDepartment)
        {
        }
        public void putUnitMeasurementList(List<CUnitMeasurement> oLstMeasurementList)
        {
        }
        #endregion

        private void cboItemSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboItemSelect_Leave(object sender, EventArgs e)
        {
            CProduct item = _productManager.getProductinfo(int.Parse(cboItemSelect.SelectedValue.ToString()));
            txtUnitCost.Text = item.UnitCost.ToString();
            dQtyInStock = item.QtyInStock;
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDamage_Load(object sender, EventArgs e)
        {

        }

    }
}
