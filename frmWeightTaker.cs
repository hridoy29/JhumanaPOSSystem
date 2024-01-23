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
    public partial class frmWeightTaker : Form, POSsible.Views.ISafeFundView
    {
        private CKeyboard keyboard;
        private frmItemLookUp oFrmAllItem;
        private frmMain oFrmMain;

        public frmWeightTaker()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Alternate constructor for called from meat lookup
        /// </summary>
        /// <param name="oFrm"></param>

        public frmWeightTaker(frmItemLookUp oFrm)
        {
            InitializeComponent();
            oFrmAllItem = oFrm;
        }

        public frmWeightTaker(frmMain oFrm)
        {
            InitializeComponent();
            oFrmMain = oFrm;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                double dWeight;
                if (double.TryParse(txtWeight.Text, out dWeight))
                {
                    if (oFrmAllItem != null)
                        oFrmAllItem.getWeight(txtWeight.Text);
                    else if (oFrmMain != null)
                        oFrmMain.weight = Convert.ToDouble(txtWeight.Text);
                    else
                        MessageBox.Show("An Error has occured");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid weight");
                    txtWeight.Focus();
                }

            }
            catch (Exception xcp)
            {
                MessageBox.Show("Error occured");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWeightTaker_Load(object sender, EventArgs e)
        {

        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyboard == null)
                {
                    keyboard = new CKeyboard();
                    keyboard.showKeyPad(this);
                    txtWeight.Focus();
                }
                else if (keyboard.process.HasExited)
                {
                    keyboard.showKeyPad(this);
                    txtWeight.Focus();
                }

                //else
                //keyboard.showHide(true);
            }
            catch (Exception excp)
            {

            }
        }

        private void frmWeightTaker_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            TextBox txtAmount = (TextBox)sender;

            double dResult;
            if (txtAmount.Text == "." || txtAmount.Text == "" || double.TryParse(txtAmount.Text, out dResult))
            {

            }
            else
            {
                MessageBox.Show("Invalid weight !!");
            }
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (btnClicked.Text == ".")
            {
                string sTotalValue = txtWeight.Text.ToString();
                int n = sTotalValue.IndexOf(".");
                if (n == -1)
                {
                    txtWeight.Text += ".";
                }
            }
            else
            {
                string sText = txtWeight.Text.Trim();
                if (sText.Length > 1)
                {
                    txtWeight.Text += btnClicked.Text.Trim();
                }
                else if (sText.Equals("0"))
                {
                    txtWeight.Text = btnClicked.Text.Trim();
                }
                else
                    txtWeight.Text += btnClicked.Text.Trim();
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtWeight.Text = "";
            txtWeight.Focus();
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnOk.PerformClick();
        }
    }
}