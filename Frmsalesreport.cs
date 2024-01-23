using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using POSsible.Factories;
using POSsible.Models;
using POSsible.Views;
using System.Data.SqlClient;
using POSsible.Reports;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible
{
    public partial class Frmsalesreport : Form
    {
        private static readonly string ritpos_sales_report = "ritpos_sales_report";
        public Frmsalesreport()
        {
            InitializeComponent();
            dpDate.Value = DateTime.Now;
            ShowprofitReport();
        }

        private void Frmsalesreport_Load(object sender, EventArgs e)
        {

        }
        public void ShowprofitReport()
        {
            try
            {

                DataSet DsSales = new DataSet();
                DsSales = getSalesinfo();
                foreach (DataRow drSales in DsSales.Tables[0].Rows)
                {
                    lblnoinvoice.Text = drSales["Noinvoice"].ToString();
                    lbltotalsales.Text =string.Format("{0:$###0.00}" ,Convert.ToDouble( drSales["totalprice"]));
                }
            }
            catch
            {
            }

        }
        public DataSet getSalesinfo()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            string SqlStr = "EXEC ritpos_sales_report";
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        public void ShowprofitReportbydate()
        {
            try
            {

                DataSet DsSales = new DataSet();
                DsSales = getSalesinfobydate();
                lblnoinvoice.Text = "0";
                lbltotalsales.Text = "0";
                foreach (DataRow drSales in DsSales.Tables[0].Rows)
                {
                    lblnoinvoice.Text = drSales["Noinvoice"].ToString();
                    lbltotalsales.Text = string.Format("{0:$###0.00}", Convert.ToDouble(drSales["totalprice"]));
                }
            }
            catch
            {
            }

        }
        public DataSet getSalesinfobydate()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            string SqlStr = "EXEC ritpos_sales_report_by_date '" + dpDate.Value.Date.ToString()+"'";
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            ShowprofitReportbydate();

        }

        private void Frmsalesreport_Load_1(object sender, EventArgs e)
        {

        }
    }
}