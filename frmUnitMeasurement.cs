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
using POSsible.BusinessObjects;
using System.Linq;

namespace POSsible
{
    public partial class frmUnitMeasurement : Form, IUnitMeasurmentView
    {
        /// <summary>
        /// Reference of IUnitMeasurmentManager
        /// </summary>
        private IUnitMeasurmentManager _UnitMeasurmentManager;
        private int iRowIndex = 0;

        UnitMeasureDAO oUnitMeasureDAO = new UnitMeasureDAO();

        public CUser oUserLogin = new CUser();

        public frmUnitMeasurement()
        {
            InitializeComponent();
            BindGrid();
        }

        public frmUnitMeasurement(CUser oUser)
        {
            InitializeComponent();
            oUserLogin = oUser;
            _UnitMeasurmentManager = Factory.GetUnitMeasurmentManager(this);
            BindGrid();
            AddMode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
            AddMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUnitId.Text == "") { Alert("Select a Unit first"); return; }

            DialogResult result;
            result = MessageBox.Show("Do you want to delete this Unit Measurement?", "POSsible", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                UnitMeasure oCUnitMeasurement = new UnitMeasure();
                int returnval;
                oCUnitMeasurement.unitMeasureId = int.Parse(txtUnitId.Text);
                returnval = oUnitMeasureDAO.Delete(oCUnitMeasurement.unitMeasureId);
                if (returnval > 0)
                {
                    dgvUnit.Rows.RemoveAt(iRowIndex);
                    BindGrid();
                    AddMode();
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SaveData()
        {
            try
            {
                if (CheckValidity())
                {
                    UnitMeasure oUnitMeasure = new UnitMeasure();

                    oUnitMeasure.UnitMeasureName = txtUnitName.Text.Trim();

                    oUnitMeasure.enteredby = MDIParent.userId.ToString();
                    oUnitMeasure.updatedby = MDIParent.userId.ToString();

                    if (btnAdd.Text == "UPDATE")
                    {
                        oUnitMeasure.unitMeasureId = int.Parse(txtUnitId.Text);
                        oUnitMeasureDAO.Update(oUnitMeasure);
                        BindGrid();
                    }
                    else if (btnAdd.Text == "ADD")
                    {
                        int iUnitId = oUnitMeasureDAO.Add(oUnitMeasure);
                        BindGrid();
                    }

                    AddMode();
                }
            }
            catch (Exception exc)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert(exc.Message + "Unit Measurment information did not updated successfully.");
                }
                else
                {
                    Alert(exc.Message + "Unit Measurment information did not added successfully.");
                }

            }
        }

        /// <summary>
        /// Check Validity all of the check box
        /// </summary>
        /// <returns>True/False</returns>
        private bool CheckValidity()
        {
            if (txtUnitName.Text == "")
            {
                Alert("Enter the name of the Unit.");
                txtUnitName.Focus();
                return false;
            }

            if (txtUnitName.Text != null)
            {
                UnitMeasure P = oUnitMeasureDAO.UnitMeasure_GetDynamic("[UnitMeasureName]='" + txtUnitName.Text + "'", "").FirstOrDefault();
                if (P != null)
                {
                    MessageBox.Show("This UOM is already used.", "POSsible");
                    txtUnitName.Clear();
                    txtUnitName.Focus();
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Load Unit Measurment to the grid
        /// </summary>
        private void BindGrid()
        {
            dgvUnit.Rows.Clear();
            List<UnitMeasure> lUnitMeasumreentList = new List<UnitMeasure>();

            lUnitMeasumreentList = oUnitMeasureDAO.UnitMeasure_GetAll();

            for (int i = 0; i < lUnitMeasumreentList.Count; i++)
                dgvUnit.Rows.Add(lUnitMeasumreentList[i].unitMeasureId.ToString(), lUnitMeasumreentList[i].UnitMeasureName);
        }

        /// <summary>
        /// Situation before add a Unit 
        /// </summary>
        private void AddMode()
        {
            btnAdd.Text = "ADD";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = false;
            btnExit.Enabled = true;

            txtUnitId.Enabled = false;
            txtUnitId.Text = "";
            txtUnitName.Text = "";

            if (dgvUnit.Rows.Count > 0)
                dgvUnit.Rows[0].Selected = false;
            txtUnitName.Focus();
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

            txtUnitId.Enabled = false;
            txtUnitName.Text = "";
            txtUnitId.Text = "";
        }

        /// <summary>
        /// Show all information in textbox controls for a selected Unit Measurment
        /// </summary>
        /// <param name="CUnitMeasurement"></param>
        private void ShowData(UnitMeasure oCUnitMeasurement)
        {
            txtUnitId.Text = oCUnitMeasurement.unitMeasureId.ToString();
            txtUnitName.Text = oCUnitMeasurement.UnitMeasureName;
        }


        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "POSsible");
        }

        private void frmUnitMeasurement_Load(object sender, EventArgs e)
        {

        }

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvUnit.Rows[iRowIndex];

                try
                {
                    if (ObjDGVRow.Cells[0].Value != null)
                    {
                        EditOrDeleteMode();
                        UnitMeasure oUM = oUnitMeasureDAO.UnitMeasure_GetById(Int32.Parse(ObjDGVRow.Cells[0].Value.ToString()));
                        ShowData(oUM);
                    }
                }
                catch
                {
                }
            }
        }

    }
}