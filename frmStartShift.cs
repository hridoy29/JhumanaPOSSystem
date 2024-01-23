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
    public partial class frmPreProcMsg : Form
    {
        frmMain oFrmMainGlobal;
        //private POSsible.Controllers.ISalesManager _SalesManager;

       
        private CKeyboard keyboard;

        public frmPreProcMsg()
        {
            InitializeComponent();
            //_SalesManager = POSsible.Factories.Factory.GetSalesManager(this);

        }

        public frmPreProcMsg(frmMain oFrmMain)
        {
            InitializeComponent();
            //_SalesManager = POSsible.Factories.Factory.GetSalesManager(this);
            oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtStartShiftCash.Text, "^(\\+|-)?\\d+(\\.\\d+)?$"))
            {
                try
                {
                    double dAmount = Convert.ToDouble(txtStartShiftCash.Text);
                    Shift oShift = new Shift();
                    int iShiftId = 0;
                    if (oFrmMainGlobal.btnStartShift.Text.Equals("END SHIFT"))
                    {
                        oShift.StartMoney = dAmount;
                        oShift.StartTime = DateTime.Now;
                        oShift.userId = MDIParent.userId;
                        oShift.TotalDVDSale =MDIParent.storeId; //STORE ID
                        iShiftId = new ShiftDAO().Add(oShift);
                        MDIParent.shiftId = iShiftId;
                        oFrmMainGlobal.CheckShiftStartEnd();
                    }
                    else
                    {

                        oFrmMainGlobal.btnStartShift.Text = "START SHIFT";
                        oFrmMainGlobal.CheckShiftStartEnd();
                       
                    }

                    this.Dispose();
                }
                catch (Exception xcp)
                {
                    MessageBox.Show("Error occured");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Valid Number");
                txtStartShiftCash.Focus();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (oFrmMainGlobal.btnStartShift.Text.Equals("START SHIFT"))
            {
                oFrmMainGlobal.btnStartShift.Text = "END SHIFT";
                oFrmMainGlobal.CheckShiftStartEnd();
            }
            else
            {
                oFrmMainGlobal.btnStartShift.Text = "START SHIFT";
                oFrmMainGlobal.CheckShiftStartEnd();
            }
            this.Dispose();
        }

        private void txtStartShiftCash_TextChanged(object sender, EventArgs e)
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
        }

        private void lblStartShiftCash_Click(object sender, EventArgs e)
        {

        }

        private void txtStartShiftCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dInputText = Convert.ToDouble(Regex.IsMatch(txtStartShiftCash.Text, "^(\\+|-)?\\d+(\\.\\d+)?$"));
            if (e.KeyChar == 13)
            {
                btnOk.PerformClick();
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
                    txtStartShiftCash.Focus();
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

        private void frmStartShift_FormClosed(object sender, FormClosedEventArgs e)
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

        private void frmStartShift_Load(object sender, EventArgs e)
        {
            try
            {
                //CPrinter printer = new CPrinter();
                //printer.openChashDrawer();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (btnClicked.Text == ".")
            {
                string sTotalValue = txtStartShiftCash.Text.ToString();
                int n = sTotalValue.IndexOf(".");
                if (n == -1)
                {
                    txtStartShiftCash.Text += ".";
                }
            }
            else
            {
                string sText = txtStartShiftCash.Text.Trim();
                if (sText.Length > 1)
                {
                    txtStartShiftCash.Text += btnClicked.Text.Trim();
                }
                else if (sText.Equals("0"))
                {
                    txtStartShiftCash.Text = btnClicked.Text.Trim();
                }
                else
                    txtStartShiftCash.Text += btnClicked.Text.Trim();
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtStartShiftCash.Text = "";
            txtStartShiftCash.Focus();
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
    }
}
