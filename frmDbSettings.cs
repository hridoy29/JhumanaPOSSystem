using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;

namespace POSsible
{
    public partial class frmDbSettings : Form,POSsible.Views.IDBSettingsView
    {
        private POSsible.Controllers.ISecurityManager _SecurityManager;
        //private Form o_Form;
        public CUser oUserLogin = new CUser();

        public frmDbSettings()
        {
            InitializeComponent();
            _SecurityManager = POSsible.Factories.Factory.GetSecurityManager(this);
        }

        public frmDbSettings(CUser oUser)
        {
            InitializeComponent();
            oUserLogin = oUser;
            _SecurityManager = POSsible.Factories.Factory.GetSecurityManager(this);
        }

        private void txtDatabaseServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string sDatabaseUser = txtDatabaseUser.Text.Trim();
            string sPassword = txtPassword.Text.Trim();
            string sServer = txtDatabaseServer.Text.Trim();
            string sDatabaseName = txtDatabaseName.Text.Trim();
            string sTerminalIP = txtTerminalIP.Text.Trim();
            string sPrinterName = txtPrinterName.Text.Trim();
            string sScalePort = txtScalePort.Text.Trim();
            
            bool bgetRegistry;

            if (sDatabaseName != "" && sPassword != "" && sServer != "" && sDatabaseUser != "" && sTerminalIP != "" && sPrinterName != "" && sScalePort != "")
            {
                try
                {
                    //frmMain oFrmMain = new frmMain();
                    bgetRegistry = _SecurityManager.setRegistryValue(sDatabaseUser, sPassword, sServer, sDatabaseName,sTerminalIP,sPrinterName,sScalePort);

                    if (bgetRegistry.Equals(true))
                    {
                        //frmMain oFrmMain = new frmMain();
                        //oFrmMain.Show();
                        this.Close();
                    }
                   
                }
                catch (Exception xcp)
                {
                    MessageBox.Show("Sorry, an error ocurred while setting registry ");
                }
               
            }
            else
            {
                lblMsg.Text = "Please enter proper Information";
                txtDatabaseName.Text = "";
                txtDatabaseServer.Text = "";
                txtDatabaseUser.Text = "";
                txtPassword.Text = "";
             
            }

            //Do something and Success or unsccess message
            
        }

        public void Alert(string sMsg)
        {
            lblMsg.Text = sMsg;
            //txtDatabaseName.Text = "";
            //txtDatabaseServer.Text = "";
            //txtDatabaseUser.Text = "";
            //txtPassword.Text = "";
             
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (oUserLogin != null)
                this.Close();
            else
                Application.Exit();

        }
    }
}
