using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmShiftPass : Form
    {
        frmMain oFrmMainGlobal;
        DialogResult dr = DialogResult.Cancel;

        public frmShiftPass(frmMain oFrmMain)
        {
            InitializeComponent();
            oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            string sText = "";
            sText = txtShiftPass.Text.Trim();
            txtShiftPass.Text += btnClicked.Text.Trim();

        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtShiftPass.Clear();
            txtShiftPass.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sUserpassword = txtShiftPass.Text.Trim();

            if (txtShiftPass.Text != "")
            {

                Users oUser = new Users();
                oUser = new UsersDAO().Users_GetDynamic("U.[Name]='" + MDIParent.userName + "' " + " AND U.[Password] ='" + sUserpassword + "'", string.Empty).FirstOrDefault();
                if (oUser == null)
                {
                    MessageBox.Show("Wrong Passcode!! Try again.", "POSsible");
                    return;

                }

                this.Close();
                dr = System.Windows.Forms.DialogResult.OK;
                DialogResult = dr;

                if (oFrmMainGlobal.btnStartShift.Text.Equals("END SHIFT"))
                {
                    frmPreProcMsg oFrmStartShift = new frmPreProcMsg(oFrmMainGlobal);
                    oFrmStartShift.ShowDialog();
                }
                else
                {
                    frmEndShift oFrmEndShift = new frmEndShift(oFrmMainGlobal, oFrmMainGlobal.totCashSale, oFrmMainGlobal.totCardSale);
                    oFrmEndShift.ShowDialog();
                }
            }
        }

        private void frmShiftPass_Load(object sender, EventArgs e)
        {
            txtShiftPass.Select();
        }

        private void txtShiftPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                btnOk.PerformClick();
        }

        private void frmShiftPass_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}
