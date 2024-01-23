using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;
using System.Linq;

namespace POSsible
{
    public partial class frmOffice : Form
    {
        public CUser oUserLogin = new CUser();
        frmLogin frmLogin = new frmLogin();
        public frmCustomerDisplay o_screen2;


        public frmOffice()
        {
            InitializeComponent();
        }

        public frmOffice(frmLogin frmLoginCon)
        {
            InitializeComponent();
            frmLogin = frmLoginCon;
        }

        //public frmOffice(CUser oUser, frmLogin loginfrm)
        //{
        //    InitializeComponent();
        //    oUserLogin = oUser;
        //    m_loginfrmRef = loginfrm;            
        //}


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin ofrmLogin = new frmLogin();
            ofrmLogin.Show();
        }

        private void btnBackOffice_Click(object sender, EventArgs e)
        {
            frmGlobalSetting ofrmMain = new frmGlobalSetting(this);
            ofrmMain.Show();

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            List<RoleWisePermission> rwp = new RoleWisePermissionDAO().RoleWisePermission_GetByRoleId(MDIParent.roleId);
            RoleWisePermission rwp1 = rwp.Where(x => x.PageId == 22).FirstOrDefault();
            if (rwp1 == null || !rwp1.CanSelect)
            {
                MessageBox.Show("You don't have permission to enter Sales.");
                return;
            }
            frmMain ofrmMain = new frmMain(this);
            ofrmMain.ShowDialog();
        }

        private void frmOffice_Load(object sender, EventArgs e)
        {
            frmLogin.Hide();
        }
    }
}