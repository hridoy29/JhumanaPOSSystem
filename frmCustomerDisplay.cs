using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POSsible
{
    public partial class frmCustomerDisplay : Form
    {
        public frmCustomerDisplay()
        {
            InitializeComponent();
        }

        private void lblItemValue_Click(object sender, EventArgs e)
        {

        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.Date.ToString("dddd, dd MMM yyyy") + Environment.NewLine + "Time: " + GetTime();
        }

        private void pnlInvoiceDisplay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlWish_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}