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
    public partial class frmCustomerLookUp : Form,POSsible.Views.ICustomerView
    {
        private POSsible.Controllers.ICustomerManager _CustomerManager;
        frmMain oFrmMainGlobal;
        private CKeyboard keyboard;
        private string sCustomerId;
        public frmCustomerLookUp()
        {
            InitializeComponent();
            _CustomerManager = POSsible.Factories.Factory.GetCustomerManager(this);
        }

        public frmCustomerLookUp(frmMain oFrmMain)
        {
            InitializeComponent();
            oFrmMainGlobal = oFrmMain;
            _CustomerManager = POSsible.Factories.Factory.GetCustomerManager(this);
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                KeyEventArgs key = new KeyEventArgs(Keys.Enter);
                this.txtCustomerId_KeyDown(sender, key);
                oFrmMainGlobal.oInvoice.CustomerBarCode = sCustomerId;

                if (sCustomerId.Trim().Length != 0)
                    this.Close();
                else
                    MessageBox.Show("Enter a customer id.");                
            }
            catch(Exception xcp)
            {
                MessageBox.Show(xcp.Message + "Error occured");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oFrmMainGlobal.oInvoice.CustomerId = 0;
            this.Close();
        }

        private void frmCustomerLookUp_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    CPrinter printer = new CPrinter();
            //    printer.openChashDrawer();
            //}
            //catch (Exception excep)
            //{
            //    MessageBox.Show(excep.Message.ToString());
            //}
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyboard == null)
                {
                    keyboard = new CKeyboard();
                    keyboard.showKeyPad(this);
                    txtCustomerId.Focus();
                }
                else if (keyboard.process.HasExited)
                {
                    keyboard.showKeyPad(this);
                    txtCustomerId.Focus();
                }

                //else
                //keyboard.showHide(true);
            }
            catch (Exception excp)
            {

            }
        }

        private void frmCustomerLookUp_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            //TextBox txtAmount = (TextBox)sender;
            //int iResult;
            //if (int.TryParse(txtAmount.Text, out iResult))
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Invalid input !!");
            //}
        }

        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustomerId.Text !="")
            {
                try
                {
                   Customer o_customer = _CustomerManager.getCustomerByBarCode(txtCustomerId.Text.Trim());
                   
                    if (o_customer != null)
                   {
                       lblMsg.Text = "S/He is a valuable customer";
                       sCustomerId = txtCustomerId.Text.Trim();
                   }
                   else
                   {
                       lblMsg.Text = "No customer found with this Id";
                       txtCustomerId.Text = "";
                       txtCustomerId.Focus();
                   }
                }
                catch
                {
                    MessageBox.Show("An error has occured.");
                }
            }
        }

        public void Alert(string msg)
        {
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {

            Button btnClicked = (Button)sender;
            txtCustomerId.Text += btnClicked.Text.Trim();
            
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtCustomerId.Text = "";
            sCustomerId = "0";
            lblMsg.Text = "";
            txtCustomerId.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            KeyEventArgs key = new KeyEventArgs(Keys.Enter);
            this.txtCustomerId_KeyDown(sender, key);
        }
    }
}