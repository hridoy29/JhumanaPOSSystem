using System;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Configuration;


namespace POSsible
{
    public partial class frmLogin : Form
    {
        //private POSsible.Controllers.ISecurityManager _SecurityManager;
        //private CUser m_loggedinUser;
        private bool m_showhide = true;
        //public frmCustomerDisplay o_screen2;

        private Control lastFocusedControl;

        private CKeyboard keyboard;

        public frmLogin()
        {
            InitializeComponent();
        }

        public void logOut(CUser user)
        {
            //m_loggedinUser = user;
            this.Show();
            txtUserName.Focus();
            lblMsg.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
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

            this.Close();
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            try
            {
                var expiryDate = ConfigurationManager.AppSettings.Get("ExpiryDate").ToString();
                if (DateTime.Now >= Convert.ToDateTime(expiryDate)) //SLA Exp: 28-Feb-2021
                {
                    Alert("Please Contact Vendor on 018 32 73 80 14");
                    return;
                }

                string sUserName = txtUserName.Text.Trim();
                string sUserpassword = txtUserPassword.Text.Trim();

                if (sUserName != "" && sUserpassword != "")
                {
                    #region Login(new)
                    Users oUser = new Users();
                    oUser = new UsersDAO().Users_GetDynamic("U.[Name]='" + sUserName + "' " + " AND U.[Password] ='" + sUserpassword + "'", string.Empty).FirstOrDefault();
                    if (oUser == null)
                    {
                        bool check = Regex.IsMatch(sUserName, @"[a-zA-z*!@#$%^&*().,`';\|]");
                        if (!check)
                            oUser = new UsersDAO().Users_GetDynamic("U.[UserId]='" + sUserName + "' " + " AND U.[Password] ='" + sUserpassword + "'", string.Empty).FirstOrDefault();
                        if (oUser == null)
                        {
                            Alert("Wrong Login Information. Try again.");
                            return;
                        }
                    }

                    UserLogins oUserLogins = new UserLogins();
                    oUserLogins.UserId = oUser.UserId;
                    oUserLogins.UserLoginTime = DateTime.Now;
                    oUserLogins.UserLogoutTime = null;
                    IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress[] addr = ipHost.AddressList;
                    //string ip = addr[2].ToString();

                    oUserLogins.UserTerminal = ipHost.HostName + ",IP: ";
                    oUserLogins.ShiftId = null;
                    try
                    {
                        int createLogin = new UserLoginsDAO().Add(oUserLogins);
                        if (createLogin < 0)
                        {
                            Alert("Error Occured.");
                            return;
                        }
                        MDIParent.userId = oUser.UserId;
                        MDIParent.userName = oUser.Name;
                        MDIParent.storeId = Convert.ToInt32(oUser.UpdatedBy);
                        MDIParent.shiftId = 0;
                        MDIParent.pcName = oUserLogins.UserTerminal;
                        MDIParent.CF2 = createLogin;
                        MDIParent.roleId = Convert.ToInt32(oUser.LastName);
                        MDIParent.StoreName = oUser.storeName;
                        MDIParent.projectId = oUser.projectId;
                        MDIParent.CardAmtLgId = oUser.CardAmtLgId;
                        MDIParent.EmpId = int.Parse(oUser.FirstName);
                        MDIParent.StoreOpeningDate = (DateTime)oUser.DeactivatedTime;

                        goToMainform(oUser);
                    }
                    catch (Exception e)
                    {

                    }
                    #endregion
                }
                else
                {
                    if (sUserName == "")
                    {
                        MessageBox.Show("Please enter your username");
                        txtUserName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please enter your password");
                        txtUserPassword.Focus();
                    }

                }
            }
            catch
            {
                Alert("Some error occured. Try Again.");
            }


        }

        public void notAuthenticated(string sMsg)
        {
            lblMsg.Text = sMsg;
            m_showhide = false;
            txtUserName.Text = "";
            txtUserPassword.Text = "";
        }

        public void goToMainform(Users oUser)
        {
            bool Admin = Convert.ToBoolean(oUser.HasAdminRight);

            Roles r = new RolesDAO().Roles_GetById(MDIParent.roleId);
            if (r == null)
                return;

            try
            {

                if (r.RoleName == "Store Operator")
                {
                    //System.Collections.Generic.List<RoleWisePermission> rwp = new RoleWisePermissionDAO().RoleWisePermission_GetByRoleId(MDIParent.roleId);
                    //RoleWisePermission rwp1 = rwp.Where(x => x.PageId == 22).FirstOrDefault();
                    //if (rwp1 == null || !rwp1.CanSelect)
                    //{
                    //    MessageBox.Show("You don't have permission to enter Sales.");
                    //    return;
                    //}
                    frmMain ofrmMain = new frmMain(this);
                    ofrmMain.Show();
                }
                else
                {
                    frmOffice ofrmOffice = new frmOffice(this);
                    ofrmOffice.ShowDialog();
                }
                m_showhide = true;
                //txtUserName.Text = "";
                //txtUserPassword.Text = "";

            }
            catch (Exception ex)
            {
                Alert(ex.ToString());
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserPassword.Text = "";
            txtUserName.Select();
        }

        private void txtUserName_OnEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUserPassword.Focus();
            }
        }

        private void txtPassword_OnEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DoLogin();
            }
        }

        private void frmLogin_VisibleChanged(object sender, EventArgs e)
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
                    else
                    {
                        keyboard = null;
                    }
                }
            }
            catch (Exception excp)
            {

            }

        }

        #region keypad related
        private void KeyPadkey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (lastFocusedControl != null)
            {
                TextBox txtWriteControl = (TextBox)lastFocusedControl;
                txtWriteControl.Focus();
                SendKeys.Send(btnClicked.Text);
            }
            else
            {
                MessageBox.Show("Got a problem !!");
            }

        }
        private void keypadOtherKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (lastFocusedControl != null)
            {
                TextBox txtWriteControl = (TextBox)lastFocusedControl;
                txtWriteControl.Focus();
                SendKeys.Send("{" + btnClicked.Tag + "}");
            }
            else
            {
                MessageBox.Show("Got a problem !!");
            }

        }

        private void Control_LeaveFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
                lastFocusedControl = (Control)sender;
            else
                lastFocusedControl = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TextBox txtWriteControl = (TextBox)lastFocusedControl;
            txtWriteControl.Text = "";
            txtWriteControl.Focus();

        }


        public bool IsNumeric(string strValToCheck)
        {
            bool bRetVal = false;

            try
            {
                int iCheck = Int32.Parse(strValToCheck);
                bRetVal = true;
            }
            catch
            {
                bRetVal = false;
            }
            return bRetVal;
        }


        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "POSsible");
        }

        #endregion

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}
