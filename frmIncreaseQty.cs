using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmIncreaseQty : Form
    {
        private frmMain oFrmMainGlobal;

        public frmIncreaseQty()
        {
            InitializeComponent();
        }

        public frmIncreaseQty(frmMain oFrmMain)
        {
            InitializeComponent();
            oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtQty.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method to check whether a character is numeric or not
        /// </summary>
        /// <param name="strValToCheck"></param>
        /// <returns></returns>
        public bool IsNumeric(string strValToCheck)
        {
            bool bRetVal = false;

            try
            {
                double iCheck = Convert.ToDouble(strValToCheck);
                bRetVal = true;
            }
            catch
            {
                bRetVal = false;
            }
            return bRetVal;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                double dQty;
                if (double.TryParse(txtQty.Text, out dQty))
                {
                    int iCount = oFrmMainGlobal.dgvItem.Rows.GetRowCount(DataGridViewElementStates.Selected);

                    if (iCount > 0)
                    {
                        int iIndex = oFrmMainGlobal.dgvItem.SelectedRows[0].Index;

                        if (oFrmMainGlobal.dgvItem.Rows[iIndex].Selected)
                        {
                            char[] cSplit = { '@' };
                            string[] sQuantity = oFrmMainGlobal.dgvItem.Rows[iIndex].Cells[3].Value.ToString().Split(cSplit);
                            string[] qtyMUSp = sQuantity[0].Split(' ');
                            string UnitMeasureName = qtyMUSp[1];
                            double uPrice = Convert.ToDouble(sQuantity[1]);
                            int itemId = Convert.ToInt32(oFrmMainGlobal.dgvItem.Rows[iIndex].Cells[5].Value);

                            double qty = Convert.ToDouble(string.Format("{0:###0.00}", txtQty.Text));

                            double stockQty = Convert.ToDouble(string.Format("{0:###0.00}", (new TransactionDAO().ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + itemId + ")"))));
                            if (qty > stockQty)
                            {
                                MessageBox.Show("Not enough quantity in stock \nProduct Available : " + stockQty, "TEPOS");
                                return;
                            }

                            oFrmMainGlobal.dgvItem.Rows[iIndex].Cells[1].Value = (string.Format("{0:###0.00}", qty));
                            oFrmMainGlobal.dgvItem.Rows[iIndex].Cells[3].Value = (string.Format("{0:###0.00}", qty)) + " " + UnitMeasureName + "@" + (string.Format("{0:###0.00}", uPrice));
                            oFrmMainGlobal.dgvItem.Rows[iIndex].Cells[4].Value = string.Format("{0:###0.000}", uPrice * qty);
                        }
                    }

                    oFrmMainGlobal.picBxImageDisplay.Image = null;
                    oFrmMainGlobal.picBxImageDisplay.Invalidate();
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Quantity");
                    txtQty.Focus();
                }

            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message + "Error occured");
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txtAmount = (TextBox)sender;

            double dResult;

            if (txtAmount.Text == "." || txtAmount.Text == "" || double.TryParse(txtAmount.Text, out dResult))
            {
            }
            else
            {
                MessageBox.Show("Invalid Quantity!!");
                txtQty.Text = "";
            }
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            txtQty.Text += btnClicked.Text.Trim();
        }

        private void frmIncreaseQty_Load(object sender, EventArgs e)
        {

        }
    }
}