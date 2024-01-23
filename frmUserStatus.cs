using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.Controllers;
using POSsible.BusinessObjects;

namespace POSsible
{
    public partial class frmUserStatus : Form
    {
        public frmUserStatus()
        {
            InitializeComponent();
        }

        private void frmUserStatus_Load(object sender, EventArgs e)
        {
            try
            {
                UserManager usercontroller = new UserManager();
                List<CUser> oLstUser = usercontroller.getAllUser();
                displayUserList(oLstUser);
            }
            catch (Exception xcp)
            {
                MessageBox.Show("Error occured while retriving user list","RITPOS-Alert");
            }
        }
        /// <summary>
        /// Display users on the Grid.
        /// </summary>
        /// <param name="lstUser"></param>
        private void displayUserList(List<CUser> lstUser)
        {
            foreach (CUser posUser in lstUser)
            {
                dgvUser.Rows.Add(posUser.UserName, posUser.IsLoggedIn.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserManager usercontroller = new UserManager();
                List<CUser> oLstUser = new List<CUser>();
                foreach(DataGridViewRow row in dgvUser.Rows)
                {
                    CUser posUser = new CUser();
                    posUser.UserName = row.Cells[0].Value.ToString();
                    posUser.IsLoggedIn = Convert.ToBoolean(row.Cells[1].Value);

                    oLstUser.Add(posUser);
                }

                if (usercontroller.updateUserList(oLstUser) != -1)
                {
                    lblMsg.Text = "User list updated successfully";
                }
            }
            catch (Exception xcp)
            {
                MessageBox.Show("Error occured", "RITPOS-Alert");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}