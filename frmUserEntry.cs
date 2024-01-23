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
using System.Data.Common;
using POSsible.DAL;
using System.Linq;

namespace POSsible
{
    public partial class frmUserEntry : Form, IUserView
    {
        /// <summary>
        /// Reference of IUnitMeasurmentManager
        /// </summary>
        private IUserManager _UserManager;
        private int iRowIndex = 0;
        private int storeId = 0;
        bool loadDone = false;
        UsersDAO oUsersDAO = new UsersDAO();

        public CUser oUserLogin = new CUser();

        public frmUserEntry(CUser oUser)
        {
            InitializeComponent();
            //oUserLogin = oUser;
            //BindGrid();
            //AddMode();
        }

        public frmUserEntry()
        {
            InitializeComponent();
            //BindGrid();
            //AddMode();
        }

        private void cmbEmployeeBind()
        {
            DataTable employeeList = oUsersDAO.Employee_GetForDDL(storeId);
            cmbEmployee.DataSource = employeeList;
            cmbEmployee.DisplayMember = "EmployeeName";
            cmbEmployee.ValueMember = "EmployeeId";
            cmbEmployee.SelectedIndex = -1;
        }

        private void frmUserEntry_Load(object sender, EventArgs e)
        {
            rolesBind();
            cmbStoreBind();
            BindGrid();
            loadDone = true;
        }

        private void rolesBind()
        {
            List<Roles> rolesLst = new RolesDAO().Roles_GetAll();
            if (rolesLst.Count > 0)
            {
                cmbDesignation.DataSource = rolesLst;
                cmbDesignation.DisplayMember = "RoleName";
                cmbDesignation.ValueMember = "RoleId";
            }
        }

        private void cmbStoreBind()
        {
            List<Store> storeList = new StoreDAO().Store_GetAll();

            cmbStore.DataSource = storeList;
            cmbStore.DisplayMember = "StoreName";
            cmbStore.ValueMember = "StoreId";
            if (MDIParent.roleId != 2) //2 is ADMIN
            {
                cmbStore.SelectedValue = MDIParent.storeId;
                cmbStore.Enabled = false;
                cmbDesignation.SelectedValue = 4;
                cmbDesignation.Enabled = false;
            }
            else
                cmbStore.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "ADD")
            {
                bool bStatus;
                bStatus = this.SearchLoginName(txtLoginName.Text, Convert.ToInt32(cmbEmployee.SelectedValue));

                if (bStatus == true)
                    this.SaveData();
            }
            else
                this.SaveData();
        }

        private bool SearchLoginName(string iSender, int empId)
        {
            int status = 0;

            Users oUs = oUsersDAO.Users_GetDynamic("U.[Name]='" + iSender + "'", "").FirstOrDefault();
            if (oUs != null)
            {
                MessageBox.Show("This User Name already exist");
                this.txtLoginName.Focus();
                return false;
            }
            oUs = oUsersDAO.Users_GetDynamic("U.[FirstName]='" + empId + "'", "").FirstOrDefault();
            if (oUs != null)
            {
                MessageBox.Show("This Employee already has a Login.");
                this.cmbEmployee.SelectedIndex = -1;
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
            AddMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to delete this User?", "RITPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                int returnval = oUsersDAO.Delete(int.Parse(txtUserID.Text));

                if (returnval > 0)
                {
                    dgvUser.Rows.RemoveAt(iRowIndex);
                    BindGrid();
                    AddMode();
                }
            }
        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iRowIndex = e.RowIndex;
                DataGridViewRow ObjDGVRow = dgvUser.Rows[iRowIndex];

                try
                {
                    if (ObjDGVRow.Cells[0].Value != null)
                    {
                        EditOrDeleteMode();
                        Users oUser = oUsersDAO.Users_GetById(Convert.ToInt32(ObjDGVRow.Cells[3].Value));
                        ShowData(oUser);
                    }
                }
                catch
                {
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
                    Users oUser = new Users();

                    oUser.Name = txtLoginName.Text.Trim();
                    oUser.Password = txtPassword.Text.Trim();

                    oUser.HasDiscountRight = chkDiscount.Checked;
                    oUser.HasRefundright = chkRefund.Checked;
                    oUser.IsLoggedIn = false;

                    oUser.EnteredBy = MDIParent.userId;
                    oUser.UpdatedBy = storeId;

                    oUser.EnteredTime = DateTime.Now;
                    oUser.FirstName = cmbEmployee.SelectedValue.ToString();
                    oUser.LastName = cmbDesignation.SelectedValue.ToString();
                    oUser.Email = cmbStatus.SelectedItem.ToString();
                    DataTable storeE = oUsersDAO.Store_GetById(Convert.ToInt32(cmbStore.SelectedValue));

                    oUser.projectId = Convert.ToInt32(storeE.Rows[0][5].ToString());

                    if (btnAdd.Text == "UPDATE")
                    {
                        oUser.UserId = int.Parse(txtUserID.Text);
                        oUsersDAO.Update(oUser);
                        BindGrid();
                    }
                    else if (btnAdd.Text == "ADD")
                    {
                        int iUserId = oUsersDAO.Add(oUser);
                        BindGrid();
                    }

                    AddMode();
                }
            }
            catch (Exception exc)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert(exc.Message + "User information did not updated successfully.");
                }
                else
                {
                    Alert(exc.Message + "User information did not added successfully.");
                }

            }
        }

        /// <summary>
        /// Check Validity all of the check box
        /// </summary>
        /// <returns>True/False</returns>
        private bool CheckValidity()
        {
            if (txtLoginName.Text == "")
            {
                Alert("Enter the name of the Login Name/ID.");
                txtLoginName.Focus();
                return false;
            }
            else if (txtPassword.Text == "")
            {
                Alert("Enter the name of the Password.");
                txtPassword.Focus();
                return false;
            }
            else if (txtConfrimPassword.Text == "")
            {
                Alert("Enter the name of the Confirm Password.");
                txtConfrimPassword.Focus();
                return false;
            }
            else if (txtConfrimPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                Alert("Passwords does not match.");
                txtPassword.Focus();
                return false;
            }
            else if (cmbEmployee.SelectedIndex == -1)
            {
                Alert("Please Select an Employee.");
                return false;
            }
            else if (cmbDesignation.SelectedIndex == -1)
            {
                Alert("Please Select Designation.");
                return false;
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                Alert("Please Select status.");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Load user to the grid
        /// </summary>
        private void BindGrid()
        {
            dgvUser.Rows.Clear();
            List<Users> lUuserList = oUsersDAO.Users_GetAll();

            foreach (Users item in lUuserList)
            {
                dgvUser.Rows.Add(item.Name, item.EmployeeName, item.DesignationName, item.UserId.ToString(), item.Email);
            }

            foreach (DataGridViewRow myRow in dgvUser.Rows)
            {
                if (myRow.Cells[4].Value.ToString() == "Active")
                    myRow.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    myRow.DefaultCellStyle.BackColor = Color.LightGray;
            }
            if (dgvUser.Rows.Count > 0)
                dgvUser.Rows[0].Selected = false;
            cmbEmployee.Focus();

        }

        /// <summary>
        /// Situation before add a user
        /// </summary>
        private void AddMode()
        {
            btnAdd.Text = "ADD";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = false;
            btnExit.Enabled = true;
            cmbStore.Enabled = true;

            txtUserID.Enabled = false;
            txtUserID.Text = "";
            txtLoginName.Text = "";
            txtPassword.Text = "";
            txtConfrimPassword.Text = "";
            chkDiscount.Checked = false;
            chkRefund.Checked = false;
            cmbDesignation.SelectedIndex = -1;
            cmbEmployee.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            if (dgvUser.Rows.Count > 0)
                dgvUser.Rows[0].Selected = false;
            txtLoginName.Focus();
        }

        /// <summary>
        /// Situation before edit or delete a user
        /// </summary>
        private void EditOrDeleteMode()
        {
            btnAdd.Text = "UPDATE";
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;
            cmbStore.Enabled = false;

            txtUserID.Enabled = false;
            txtUserID.Text = "";
            txtLoginName.Text = "";
            txtPassword.Text = "";
            txtConfrimPassword.Text = "";
        }

        /// <summary>
        /// Show all information in textbox controls for a selected User
        /// </summary>
        /// <param name="CUnitMeasurement"></param>
        private void ShowData(Users oUser)
        {
            txtUserID.Text = oUser.UserId.ToString();
            txtLoginName.Text = oUser.Name;
            txtPassword.Text = oUser.Password;
            txtConfrimPassword.Text = oUser.Password;


            if (oUser.HasDiscountRight == true)
                chkDiscount.Checked = true;
            else
                chkDiscount.Checked = false;

            if (oUser.HasRefundright == true)
                chkRefund.Checked = true;
            else
                chkRefund.Checked = false;

            cmbStore.SelectedValue = oUser.UpdatedBy;
            cmbEmployee.SelectedValue = Convert.ToInt32(oUser.FirstName);
            cmbDesignation.SelectedValue = Convert.ToInt32(oUser.LastName);
            cmbStatus.SelectedItem = oUser.Email;


        }


        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "RITPOS");
        }

        private void txtConfrimPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblLoginName_Click(object sender, EventArgs e)
        {

        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStore.SelectedIndex > -1 && loadDone)
            {
                storeId = Convert.ToInt32(cmbStore.SelectedValue.ToString());
                cmbEmployeeBind();
            }

        }

        private void txtLoginName_Leave(object sender, EventArgs e)
        {
            if (txtLoginName.Text != null)
            {
                Users P = oUsersDAO.Users_GetDynamic("U.[Name]='" + txtLoginName.Text + "'", "").FirstOrDefault();
                if (P != null)
                {
                    MessageBox.Show("This User Name is already used.", "POSsible");
                    txtLoginName.Clear();
                    txtLoginName.Focus();
                    return;
                }
            }
        }




    }
}