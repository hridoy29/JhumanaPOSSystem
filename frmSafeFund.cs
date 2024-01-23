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
    public partial class frmSafeFund : Form,POSsible.Views.ISafeFundView
    {
        private POSsible.Controllers.ISalesManager _SalesManager;
        frmMain oFrmMainGlobal;

        private CKeyboard keyboard;
        
        public frmSafeFund()
        {
            InitializeComponent();
            _SalesManager = POSsible.Factories.Factory.GetSalesManager(this);
        }

        public frmSafeFund(frmMain oFrmMain)
        {
            InitializeComponent();
            oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
            _SalesManager = POSsible.Factories.Factory.GetSalesManager(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                double dAmount;
                if(double.TryParse(txtSafeFund.Text,out dAmount))
                {
                    if (_SalesManager.checkChashinDrawer(dAmount,oFrmMainGlobal.oUserLogin.ShiftId))
                    {
                        _SalesManager.storeSafeDropInformation(oFrmMainGlobal.oUserLogin, dAmount);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Given amount is greater than cash amount in drawer");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input!!");
                }
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSafeFund_Load(object sender, EventArgs e)
        {
            try
            {
                CPrinter printer = new CPrinter();
                printer.openChashDrawer();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message.ToString());
            }
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyboard == null)
                {
                    keyboard = new CKeyboard();
                    keyboard.showKeyPad(this);
                    txtSafeFund.Focus();
                }
                else if (keyboard.process.HasExited)
                {
                    keyboard.showKeyPad(this);
                    txtSafeFund.Focus();
                }

                //else
                //keyboard.showHide(true);
            }
            catch (Exception excp)
            {

            }
        }

        private void frmSafeFund_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtSafeFund_TextChanged(object sender, EventArgs e)
        {
            TextBox txtAmount = (TextBox)sender;
            double dResult;
            if (txtAmount.Text == "." || txtAmount.Text=="" || double.TryParse(txtAmount.Text, out dResult))
            {

            }
            else
            {
                MessageBox.Show("Invalid amount !!");
            }
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (btnClicked.Text == ".")
            {
                string sTotalValue = txtSafeFund.Text.ToString();
                int n = sTotalValue.IndexOf(".");
                if (n == -1)
                {
                    txtSafeFund.Text += ".";
                }
            }
            else
            {
                string sText = txtSafeFund.Text.Trim();
                if (sText.Length > 1)
                {
                    txtSafeFund.Text += btnClicked.Text.Trim();
                }
                else if (sText.Equals("0"))
                {
                    txtSafeFund.Text = btnClicked.Text.Trim();
                }
                else
                    txtSafeFund.Text += btnClicked.Text.Trim();
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtSafeFund.Text = "";
            txtSafeFund.Focus();

        }
    }
}