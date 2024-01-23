using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using System.Text;
using System.Windows.Forms;

namespace POSsible
{
    public partial class frmAuthorization : Form,POSsible.Views.IAuthorization
    {
        public frmMain oFrmMainGlobal;
        public CUser oAuthorizedUser;
        public string sGlobalFormName;

        private POSsible.Controllers.ISecurityManager _SecurityManager;
        //private POSsibleControllers.ISalesManager _SalesManager;

        private Control lastFocusedControl;
        private CKeyboard keyboard;
       

        public frmAuthorization()
        {
            InitializeComponent();
            _SecurityManager = POSsible.Factories.Factory.GetSecurityManager(this);
        }

        public frmAuthorization(frmMain oMain,string sFormName)
        {
            InitializeComponent();
            _SecurityManager = POSsible.Factories.Factory.GetSecurityManager(this);
      
            //oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oMain;
            sGlobalFormName = sFormName;
      
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AuthMe();
        }

        private void AuthMe()
        {
            try
            {
                string sUserName = txtUserName.Text.Trim();
                string sPassword = txtPassword.Text.Trim();

                if (sUserName != "" && sPassword != "")
                    _SecurityManager.Authenticate(sUserName, sPassword);
                else
                    MessageBox.Show("Please enter username and password");
            }
            catch (Exception xcp)
            {
                MessageBox.Show("RITPOSERROR-" + "0001");
            }
        }
        public void goToAuthorizationform(CUser oUser)
        {
            
           if (oUser != null)
            {
                try
                {
                    if (sGlobalFormName.Equals("refund"))
                    {
                        if (oUser.Refund.Equals(true))
                        {
                            this.Hide();
                            //oAuthorizedUser = new CUser();
                            //oAuthorizedUser = oUser;
                            //frmRefund oFrmRefund = new frmRefund(this);
                            //oFrmRefund.Show();
                            oFrmMainGlobal.doAuthorisedAction(oUser, "refund");
                            this.Close();

                        }
                        else
                        {
                            txtPassword.Text = "";
                            txtUserName.Text = "";
                            lblMsg.Text = "Not Authorised";
                        }
                    }
                    else if (sGlobalFormName.Equals("InstantDiscount"))
                    {
                        if (oUser.Discount.Equals(true))
                        {
                            oFrmMainGlobal.doAuthorisedAction(oUser, "InstantDiscount");
                            this.Close();
                        }
                        else
                        {
                            txtPassword.Text = "";
                            txtUserName.Text = "";
                            lblMsg.Text = "Not Authorised";
                        }
                    }

                    else if (sGlobalFormName.Equals("FuelDiscount"))
                    {
                        if (oUser.Discount.Equals(true))
                        {
                            oFrmMainGlobal.doAuthorisedAction(oUser, "FuelDiscount");
                            this.Close();

                        }
                        else
                        {
                            txtPassword.Text = "";
                            txtUserName.Text = "";
                            lblMsg.Text = "Not Authorised";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Not Authorised";
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Sorry, an error has ocurred !!");
                }
            }
            else
                lblMsg.Text = "Invalid username or password";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtPassword_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            int iKeyCode = (int)e.KeyChar;

            if (iKeyCode == 13)
                AuthMe();
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyboard == null)
                {
                    keyboard = new CKeyboard();
                    keyboard.showKeyPad(this);
                }
                else if (keyboard.process.HasExited)
                {
                    keyboard.showKeyPad(this);
                }

                //else
                //keyboard.showHide(true);
            }
            catch (Exception excp)
            {

            }
        }

        private void frmAuthorization_FormClosed(object sender, FormClosedEventArgs e)
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

        #endregion

       

        
    }
}
