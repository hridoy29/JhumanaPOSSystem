using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using System.Text.RegularExpressions;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmEndShift : Form
    {
        frmMain oFrmMainGlobal;
        private POSsible.Controllers.ISalesManager _SalesManager;
        public double tCashS = 0;
        public double tCardS = 0;
        private CKeyboard keyboard;

        public frmEndShift()
        {
            InitializeComponent();
            //_SalesManager = POSsible.Factories.Factory.GetSalesManager(this);
        }

        public frmEndShift(frmMain oFrmMain, double totCashSale, double totCardSale)
        {
            InitializeComponent();
            oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
            tCashS = totCashSale;
            tCardS = totCardSale;
            // _SalesManager = POSsible.Factories.Factory.GetSalesManager(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtCashEndShift.Text, "^(\\+|-)?\\d+(\\.\\d+)?$"))
            {
                try
                {
                    double dAmount = Convert.ToDouble(txtCashEndShift.Text);
                    Shift oShift = new Shift();
                    if (oFrmMainGlobal.btnStartShift.Text.Equals("START SHIFT"))
                    {
                        oFrmMainGlobal.btnStartShift.Text = "START SHIFT";
                        oFrmMainGlobal.CheckShiftStartEnd();
                        oShift.EndMoney = dAmount;
                        oShift.EndTime = DateTime.Now;
                        oShift.shiftId = MDIParent.shiftId;
                        oShift.TotalCashSale = tCashS;
                        oShift.TotalPhoneCardSale = tCardS;
                        oShift.TotalSale = tCashS + tCardS;
                        oShift.TotalDVDSale = MDIParent.storeId; //STORE Id
                        oShift.UpdatedTime = DateTime.Now;
                        new ShiftDAO().Update(oShift);
                    }
                    else
                    {

                        oFrmMainGlobal.btnStartShift.Text = "END SHIFT";
                    }
                    this.Close();
                }
                catch (Exception excp)
                {
                    MessageBox.Show("Sorry Error ocurred");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Valid Number");
                txtCashEndShift.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (oFrmMainGlobal.btnStartShift.Text.Equals("START SHIFT"))
            {
                oFrmMainGlobal.btnStartShift.Text = "END SHIFT";
            }
            else
            {
                oFrmMainGlobal.btnStartShift.Text = "START SHIFT";
            }
            this.Close();
        }

        private void lblEndShiftCashInDrawer_Click(object sender, EventArgs e)
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
                    txtCashEndShift.Focus();
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

        private void frnEndShift_FormClosed(object sender, FormClosedEventArgs e)
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

        private void frnEndShift_Load(object sender, EventArgs e)
        {
        }


        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (btnClicked.Text == ".")
            {
                string sTotalValue = txtCashEndShift.Text.ToString();
                int n = sTotalValue.IndexOf(".");
                if (n == -1)
                {
                    txtCashEndShift.Text += ".";
                }
            }
            else
            {
                string sText = txtCashEndShift.Text.Trim();
                if (sText.Length > 1)
                {
                    txtCashEndShift.Text += btnClicked.Text.Trim();
                }
                else if (sText.Equals("0"))
                {
                    txtCashEndShift.Text = btnClicked.Text.Trim();
                }
                else
                    txtCashEndShift.Text += btnClicked.Text.Trim();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.Date.ToString("dddd, dd MMM yyyy");
            lblTime.Text = "Time: " + GetTime();
        }

        private string GetTime()
        {
            string TimeInString = "";
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            TimeInString = (hour < 10) ? "0" + hour.ToString() : hour.ToString();
            TimeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
            TimeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            return TimeInString;
        }

        private void txtCashEndShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtAmount = (TextBox)sender;
            double dResult;
            if (txtAmount.Text == "." || txtAmount.Text == "" || double.TryParse(txtAmount.Text, out dResult))
            {

            }
            else
            {
                MessageBox.Show("Invalid amount !!");
            }
            if (e.KeyChar == 13)
                btnOk.PerformClick();
        }
    }
}
