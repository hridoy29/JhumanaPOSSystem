using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.Controllers;
using POSsible.BusinessObjects;

namespace POSsible
{
    public partial class frmPrintPast : Form
    {
        private List<CInvoice> lstInvoice = new List<CInvoice>();
        private int iInvoiceListIndex ;
        public frmPrintPast()
        {
            InitializeComponent();
            showInvoice();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SalesManager salesmanager = new SalesManager();
            //DateTime dtFrom = dtpkrDate.Value.Date.Add(dtpkrTimeFrom.Value.TimeOfDay);
            //DateTime dtTo = dtpkrDate.Value.Date.Add(dtpkrTimeTo.Value.TimeOfDay);
            DateTime dt = dtpkrDate.Value.Date;
            TimeSpan tFrom = dtpkrTimeFrom.Value.TimeOfDay;
            TimeSpan tTo = dtpkrTimeTo.Value.TimeOfDay;
            try
            {
                lstInvoice = salesmanager.getInvoicesByDTdiff(dt, tFrom,tTo);
                lblInvoicecount.Text = lstInvoice.Count.ToString();
                
                showInvoice();
            }
            catch (Exception excp)
            {
                MessageBox.Show("Error occured !");
            }
            
        }

        private void showInvoice()
        {
            
            if (dgvPrintPast.Rows.Count > 0)
                dgvPrintPast.Rows.Clear();

            if (lstInvoice.Count > 0)
            {
                
                foreach (CProduct product in lstInvoice[iInvoiceListIndex].Product)
                {
                    dgvPrintPast.Rows.Add(product.ProductName, product.QtyInorder.ToString(), product.QtyInorder * product.UnitPrice);
                }
                lblGrandTotal.Text = lstInvoice[iInvoiceListIndex].TotalPrice.ToString();
                lblInvoiceId.Text = lstInvoice[iInvoiceListIndex].InvoiceId.ToString();
            }

            if (dgvPrintPast.Rows.Count > 0)
            {
                
                lblGrandTotal.Visible = true;
                lblInvoiceId.Visible = true;
              
            }
            else
            {
                lblGrandTotal.Text = "0";
                lblGrandTotal.Visible = false;

                lblInvoiceId.Text = "0";
                lblInvoiceId.Visible = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }

        

        private void frmPrintPast_Load(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour - 1;
            //dtpkrTimeFrom.Text = hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+ DateTime.Now.Second.ToString()+DateTime.Now.;
            DateTime dt = DateTime.Now.Subtract(TimeSpan.FromHours(1));
            dtpkrTimeFrom.Text = dt.ToShortTimeString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (iInvoiceListIndex < lstInvoice.Count - 1)
                iInvoiceListIndex++;

            //dgvPrintPast.Rows.Clear();
            
            showInvoice();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(iInvoiceListIndex > 0)
                iInvoiceListIndex--;
            
            showInvoice();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstInvoice != null && lstInvoice.Count > 0)
                {
                    CPrinter printer = new CPrinter();
                    printer.printbill(lstInvoice[iInvoiceListIndex]);
                }
                else
                    MessageBox.Show("Nothing to print !!");
            }
            catch (Exception xcp)
            {
                MessageBox.Show("An error has occured !!");
            }
        }

        private void dtpkrDate_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
