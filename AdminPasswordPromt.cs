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
    public partial class AdminPasswordPromt : Form
    {
        public AdminPasswordPromt()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string password = new StoreDAO().Store_GetById(MDIParent.storeId).StoreCF1;
                string enteredPassword = txtPassword.Text;
                if (string.Equals(password, enteredPassword))
                    MDIParent.gotAdminRight = true;
                else
                {
                    MDIParent.gotAdminRight = false;
                    MessageBox.Show("Wrong Password. You Don't have Admin Rights.", "Info", MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }

                this.Close();
            }
            if (e.KeyChar == (Char)Keys.Escape)
            {
                MDIParent.gotAdminRight = false;
                this.Close();
            }
        }
    }
}
