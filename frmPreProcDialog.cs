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
    public partial class frmPreProcDialog : Form
    {

        private Timer Clock;       
        public frmPreProcDialog(string strCash,string strChange,string strCard)
        {
            InitializeComponent();

            lblCashValue.Text = strCash;
            lblChangeValue.Text = strChange;
            lblCardValue.Text = strCard;
            //Clock = new Timer();
            //Clock.Interval = 2500;
            //Clock.Tick += new EventHandler(Clock_Tick);
        }
        
        private void frmPreProcDialog_Load(object sender, EventArgs e)
        {
            btnOk.Select();
            //Clock.Start();
            
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            //Clock.Stop();
            //this.Dispose();
        }

        private void lblChangeValue_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
     
        
    }
}