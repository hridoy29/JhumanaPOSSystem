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
using POSsible.Reports;
using System.Data.Common;


namespace POSsible.Reports
{
    public partial class frmReportExplorer : Form
    {
        int CusId = 0; int CollType = 0; bool FLD = false;

        bool loadDone = false;

        public frmReportExplorer()
        {
            InitializeComponent();
        }

        private void cmbReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStore.Visible = cmbStore.Visible = lblSupplier.Visible = cmbSupplier.Visible = false;
            lblCustomer.Visible = cmbCustomer.Visible = lblCategory.Visible = cmbCategory.Visible = false;
            lblItem.Visible = cmbItem.Visible = lblInvoice.Visible = cmbInvoice.Visible = cmbInvoiceRefund.Visible = false;
            lblUser.Visible = cmbUser.Visible = lblShift.Visible = cmbShift.Visible = false;
            lblSaleType.Visible = cmbSaleType.Visible = lblPayType.Visible = cmbPayType.Visible = false;
            lblSalesman.Visible = cmbSalesman.Visible = false;
            cmbSupplier.SelectedIndex = cmbCustomer.SelectedIndex = cmbSalesman.SelectedIndex = 0;
            chkShowPrvBal.Visible = chkShowRP.Visible = grpDate.Visible = false;
            lblOrderBy.Visible = cmbOrderBy.Visible = lblNoParam.Visible = false;
            lblMonth.Visible = cmbMonth.Visible = cmbYear.Visible = false;

            int index = cmbReportName.SelectedIndex;

            switch (index)
            {
                case 0: //Current Stock
                    lblStore.Visible = cmbStore.Visible = lblSupplier.Visible = cmbSupplier.Visible = grpDate.Visible = true;
                    lblCategory.Visible = cmbCategory.Visible = lblItem.Visible = cmbItem.Visible = true;
                    break;
                case 1: //Inventory Movement
                    lblStore.Visible = cmbStore.Visible = grpDate.Visible = true;
                    break;
                case 2: //Sales Report
                    lblStore.Visible = cmbStore.Visible = grpDate.Visible = true;
                    lblCustomer.Visible = cmbCustomer.Visible = lblCategory.Visible = cmbCategory.Visible = lblItem.Visible = cmbItem.Visible = true;
                    break;
                case 3: //Shift Report
                    lblStore.Visible = cmbStore.Visible = grpDate.Visible = true;
                    lblUser.Visible = cmbUser.Visible = lblShift.Visible = cmbShift.Visible = true;
                    break;
                case 4: //PURCHASE PAYMENT
                    lblStore.Visible = cmbStore.Visible = lblSupplier.Visible = cmbSupplier.Visible = lblInvoice.Visible = cmbInvoice.Visible = grpDate.Visible = true;
                    break;
                case 5: //CREDIT COLLECTION
                    lblStore.Visible = cmbStore.Visible = lblCustomer.Visible = cmbCustomer.Visible = lblInvoice.Visible = cmbInvoice.Visible = grpDate.Visible = true;
                    //cmbSalesInvoiceBind();
                    break;
                case 6://Customer Transaction
                    lblStore.Visible = cmbStore.Visible = lblCustomer.Visible = cmbCustomer.Visible = grpDate.Visible = true;
                    break;
                case 7://SalesByType
                    lblSaleType.Visible = cmbSaleType.Visible = lblPayType.Visible = cmbPayType.Visible = grpDate.Visible = true;
                    break;
                case 8://Stock Financial
                    lblStore.Visible = cmbStore.Visible = lblCategory.Visible = cmbCategory.Visible = lblItem.Visible = cmbItem.Visible = true;
                    break;
                case 9://Sales Invoice
                    lblStore.Visible = cmbStore.Visible = lblCustomer.Visible = cmbCustomer.Visible = lblInvoice.Visible = cmbInvoice.Visible = chkShowPrvBal.Visible = chkShowRP.Visible = true;
                    break;
                case 10://Supplier Transaction
                    lblStore.Visible = cmbStore.Visible = lblSupplier.Visible = cmbSupplier.Visible = grpDate.Visible = true;
                    break;
                case 11://Sale Profit
                    lblStore.Visible = cmbStore.Visible = lblCategory.Visible = cmbCategory.Visible = lblItem.Visible = cmbItem.Visible = grpDate.Visible = lblCustomer.Visible = cmbCustomer.Visible = lblSalesman.Visible = cmbSalesman.Visible = true;
                    break;
                case 12://Customer Due
                    lblCustomer.Visible = cmbCustomer.Visible = lblOrderBy.Visible = cmbOrderBy.Visible = lblSalesman.Visible = cmbSalesman.Visible = true;
                    cmbOrderBy.Items[0] = "Customer Name";
                    break;
                case 13://Customer Due Detail
                    lblStore.Visible = cmbStore.Visible = lblCustomer.Visible = cmbCustomer.Visible = lblSalesman.Visible = cmbSalesman.Visible = grpDate.Visible = true;
                    break;
                case 14://Customer Due By Date
                    lblCustomer.Visible = cmbCustomer.Visible = lblOrderBy.Visible = cmbOrderBy.Visible = lblSalesman.Visible = cmbSalesman.Visible = grpDate.Visible = true;
                    cmbOrderBy.Items[0] = "Customer Name";
                    break;
                case 16://Product List
                    lblCategory.Visible = cmbCategory.Visible = true;
                    break;
                case 17://Supplier Due Detail
                    lblStore.Visible = cmbStore.Visible = lblSupplier.Visible = cmbSupplier.Visible = grpDate.Visible = true;
                    break;
                case 18://Supplier Due Summary
                    lblSupplier.Visible = cmbSupplier.Visible = lblOrderBy.Visible = cmbOrderBy.Visible = true;
                    cmbOrderBy.Items[0] = "Supplier Name";
                    break;
                case 19://Monthly Expense
                    lblMonth.Visible = cmbMonth.Visible = cmbYear.Visible = true;
                    break;
                case 20: //Sales By Salesman
                    lblStore.Visible = cmbStore.Visible = grpDate.Visible = lblSalesman.Visible = cmbSalesman.Visible = true;
                    lblCustomer.Visible = cmbCustomer.Visible = lblCategory.Visible = cmbCategory.Visible = lblItem.Visible = cmbItem.Visible = true;
                    break;
                case 21: //Salesman Salary
                    lblStore.Visible = cmbStore.Visible = grpDate.Visible = lblSalesman.Visible = cmbSalesman.Visible = true;
                    break;
                case 22://Customer Wise Statement
                    lblStore.Visible = cmbStore.Visible = lblCustomer.Visible = cmbCustomer.Visible = grpDate.Visible = true;
                    break;
                case 23://Refund Invoice
                    lblStore.Visible = cmbStore.Visible = lblCustomer.Visible = cmbCustomer.Visible = lblInvoice.Visible = cmbInvoiceRefund.Visible = true;
                    break;
                default:
                    break;
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                if (btnPreview.Enabled) btnPreview_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DateTime fdt = dtFromDate.Value.Date;
            DateTime tdt = dtToDate.Value.Date;
            int stoId = (cmbStore.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbStore.SelectedValue);
            int index = cmbReportName.SelectedIndex;
            int supId = (cmbSupplier.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbSupplier.SelectedValue);

            switch (index)
            {
                case 0: //Purchase Report
                    int categoryIdP = (cmbCategory.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);
                    int productIdP = (cmbItem.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbItem.SelectedValue);

                    Purchase rptPur = new Purchase();
                    rptPur.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptPur);
                    rptPur.SetParameterValue("@fdt", fdt);
                    rptPur.SetParameterValue("@tdt", tdt);
                    rptPur.SetParameterValue("@supplierId", supId);
                    rptPur.SetParameterValue("@storeId", stoId);
                    rptPur.SetParameterValue("@CategoryId", categoryIdP);
                    rptPur.SetParameterValue("@ItemId", productIdP);
                    crystalReportViewer1.ReportSource = rptPur;
                    break;
                case 1: //Inventory Movement
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    int storeId = Convert.ToInt32(cmbStore.SelectedValue);
                    rptInventoryMovement rptIM = new rptInventoryMovement();
                    rptIM.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptIM);
                    rptIM.SetParameterValue("@fdt", fdt);
                    rptIM.SetParameterValue("@edt", tdt);
                    rptIM.SetParameterValue("@StoreId", storeId);
                    crystalReportViewer1.ReportSource = rptIM;
                    break;
                case 2: //Sales Report
                    int customerId = (cmbCustomer.SelectedIndex < 1) ? -1 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    int categoryId = (cmbCategory.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);
                    int productId = (cmbItem.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbItem.SelectedValue);
                    string saleType = (cmbPayType.SelectedIndex < 1) ? string.Empty : cmbPayType.SelectedItem.ToString();
                    rptSales rptSales = new rptSales();
                    rptSales.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptSales);
                    rptSales.SetParameterValue("@fdt", fdt);
                    rptSales.SetParameterValue("@tdt", tdt);
                    rptSales.SetParameterValue("@customerId", customerId);
                    rptSales.SetParameterValue("@storeId", stoId);
                    rptSales.SetParameterValue("@CategoryId", categoryId);
                    rptSales.SetParameterValue("@ItemId", productId);
                    rptSales.SetParameterValue("@PaymentType", saleType);
                    crystalReportViewer1.ReportSource = rptSales;
                    break;
                case 3: //Shift
                    int userId = (cmbUser.SelectedIndex < 0) ? 1 : Convert.ToInt32(cmbUser.SelectedValue);
                    int shiftId = Convert.ToInt32(cmbShift.SelectedValue) < 1 ? 0 : Convert.ToInt32(cmbShift.SelectedValue);
                    rptShift rptShiftP = new rptShift();
                    rptShiftP.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptShiftP);
                    rptShiftP.SetParameterValue("@fdt", fdt);
                    rptShiftP.SetParameterValue("@tdt", tdt);
                    rptShiftP.SetParameterValue("@storeId", stoId);
                    rptShiftP.SetParameterValue("@shiftId", shiftId);
                    rptShiftP.SetParameterValue("@userId", userId);
                    crystalReportViewer1.ReportSource = rptShiftP;
                    break;
                case 4: //Purchase Payment
                    int invoiceId = Convert.ToInt32(cmbInvoice.SelectedValue) < 1 ? 0 : Convert.ToInt32(cmbInvoice.SelectedValue);
                    rptPurchasePayment rptPurP = new rptPurchasePayment();
                    rptPurP.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptPurP);
                    rptPurP.SetParameterValue("@fdt", fdt);
                    rptPurP.SetParameterValue("@tdt", tdt);
                    rptPurP.SetParameterValue("@storeId", stoId);
                    rptPurP.SetParameterValue("@supplierId", supId);
                    rptPurP.SetParameterValue("@invoiceId", invoiceId);
                    crystalReportViewer1.ReportSource = rptPurP;
                    break;
                case 5: //Credit Collection
                    int SalesInvoiceId = Convert.ToInt32(cmbInvoice.SelectedValue) < 1 ? 0 : Convert.ToInt32(cmbInvoice.SelectedValue);
                    int custId = (cmbCustomer.SelectedIndex == 1) ? 0 : ((cmbCustomer.SelectedIndex == 0) ? -1 : Convert.ToInt32(cmbCustomer.SelectedValue));
                    rptCreditCollection rptCC = new rptCreditCollection();
                    rptCC.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptCC);
                    rptCC.SetParameterValue("@fdt", fdt);
                    rptCC.SetParameterValue("@tdt", tdt);
                    rptCC.SetParameterValue("@storeId", stoId);
                    rptCC.SetParameterValue("@customerId", custId);
                    rptCC.SetParameterValue("@invoiceId", SalesInvoiceId);
                    crystalReportViewer1.ReportSource = rptCC;
                    break;
                case 6: //Customer Transaction
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    int cusId = (cmbCustomer.SelectedIndex == 1) ? 0 : ((cmbCustomer.SelectedIndex == 0) ? -1 : Convert.ToInt32(cmbCustomer.SelectedValue));
                    rptCustomerTransaction rptC = new rptCustomerTransaction();
                    rptC.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptC);
                    rptC.SetParameterValue("@fdt", fdt);
                    rptC.SetParameterValue("@tdt", tdt);
                    rptC.SetParameterValue("@storeId", stoId);
                    rptC.SetParameterValue("@customerId", cusId);
                    crystalReportViewer1.ReportSource = rptC;
                    break;
                case 7: //Sales Report By Type
                    string payType = (cmbPayType.SelectedIndex < 1) ? string.Empty : cmbPayType.SelectedItem.ToString();
                    string saleType7 = (cmbSaleType.SelectedIndex < 1) ? string.Empty : cmbSaleType.SelectedItem.ToString();
                    rptSalesByType rptSbT = new rptSalesByType();
                    rptSbT.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptSbT);
                    rptSbT.SetParameterValue("@storeId", stoId);
                    rptSbT.SetParameterValue("@PaymentType", payType);
                    rptSbT.SetParameterValue("@SaleType", saleType7);
                    rptSbT.SetParameterValue("@fdt", fdt);
                    rptSbT.SetParameterValue("@tdt", tdt);
                    crystalReportViewer1.ReportSource = rptSbT;
                    break;
                case 8: //Stock Financial
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    int categoryId8 = (cmbCategory.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);
                    int productId8 = (cmbItem.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbItem.SelectedValue);
                    rptStockFinancial rptSF = new rptStockFinancial();
                    rptSF.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptSF);
                    rptSF.SetParameterValue("@storeId", stoId);
                    rptSF.SetParameterValue("@CategoryId", categoryId8);
                    rptSF.SetParameterValue("@ItemId", productId8);
                    crystalReportViewer1.ReportSource = rptSF;
                    break;
                case 9: //Sales Invoice
                    if (cmbInvoice.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select Invoice");
                        return;
                    }
                    int invId = Convert.ToInt32(cmbInvoice.SelectedValue);
                    string showPV = chkShowPrvBal.Checked ? "Yes" : "No";
                    rptInvoiceForCreditSale rptCrInv = new rptInvoiceForCreditSale();
                    rptCrInv.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptCrInv);
                    rptCrInv.SetParameterValue("@InvoiceId", invId);
                    rptCrInv.SetParameterValue("@SaleType", showPV);
                    rptCrInv.SetParameterValue("@ShowRetailPrice", chkShowRP.Checked);
                    crystalReportViewer1.ReportSource = rptCrInv;
                    break;
                case 10: //Supplier Transaction
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    rptSupplierTransaction rptS = new rptSupplierTransaction();
                    rptS.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptS);
                    rptS.SetParameterValue("@fdt", fdt);
                    rptS.SetParameterValue("@tdt", tdt);
                    rptS.SetParameterValue("@supplierId", supId);
                    rptS.SetParameterValue("@storeId", stoId);
                    crystalReportViewer1.ReportSource = rptS;
                    break;
                case 11: //Sale Profit
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    int categoryId11 = (cmbCategory.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);
                    int productId11 = (cmbItem.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbItem.SelectedValue);
                    int cusId11 = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    int empId11 = (cmbSalesman.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    rptSalesProfit rptProfit = new rptSalesProfit();
                    rptProfit.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptProfit);
                    rptProfit.SetParameterValue("@fdt", fdt);
                    rptProfit.SetParameterValue("@tdt", tdt);
                    rptProfit.SetParameterValue("@storeId", stoId);
                    rptProfit.SetParameterValue("@CategoryId", categoryId11);
                    rptProfit.SetParameterValue("@ItemId", productId11);
                    rptProfit.SetParameterValue("@customerId", cusId11);
                    rptProfit.SetParameterValue("@SalesmanId", empId11);
                    crystalReportViewer1.ReportSource = rptProfit;
                    break;
                case 12: //All Customer Due
                    if (cmbOrderBy.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please Select Order By");
                        return;
                    }

                    int order = cmbOrderBy.SelectedIndex;
                    int cusId12 = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    int empId12 = (cmbSalesman.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    rptCustomer rptCd = new rptCustomer();
                    rptCd.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptCd);
                    rptCd.SetParameterValue("@customerId", cusId12);
                    rptCd.SetParameterValue("@OrderBy", order);
                    rptCd.SetParameterValue("@SalesmanId", empId12);
                    crystalReportViewer1.ReportSource = rptCd;
                    break;
                case 13: //Customer Due Detail
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    int cusId13 = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    int empId13 = (cmbSalesman.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    rptCustomerTranSummary rptCDD = new rptCustomerTranSummary();
                    rptCDD.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptCDD);
                    rptCDD.SetParameterValue("@fdt", fdt);
                    rptCDD.SetParameterValue("@tdt", tdt);
                    rptCDD.SetParameterValue("@storeId", stoId);
                    rptCDD.SetParameterValue("@customerId", cusId13);
                    rptCDD.SetParameterValue("@SalesmanId", empId13);
                    crystalReportViewer1.ReportSource = rptCDD;
                    break;
                case 14: //Customer Due By Date
                    if (cmbOrderBy.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please Select Order By");
                        return;
                    }

                    int order14 = cmbOrderBy.SelectedIndex;
                    int cusId14 = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    int empId14 = (cmbSalesman.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    rptCustomerDueByDate cusDueByDate = new rptCustomerDueByDate();
                    cusDueByDate.Refresh();
                    Helper.SetDataBaseLogonForCrReport(cusDueByDate);
                    cusDueByDate.SetParameterValue("@customerId", cusId14);
                    cusDueByDate.SetParameterValue("@FromDate", fdt);
                    cusDueByDate.SetParameterValue("@ToDate", tdt);
                    cusDueByDate.SetParameterValue("@OrderBy", order14);
                    cusDueByDate.SetParameterValue("@SalesmanId", empId14);
                    crystalReportViewer1.ReportSource = cusDueByDate;
                    break;
                case 15: //Customer List
                    rptCustomerList rptCusList = new rptCustomerList();
                    rptCusList.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptCusList);
                    crystalReportViewer1.ReportSource = rptCusList;
                    break;
                case 16: //Product List
                    int categoryIdP16 = (cmbCategory.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);
                    rptProductList rptProductList = new rptProductList();
                    rptProductList.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptProductList);
                    rptProductList.SetParameterValue("@CategoryId", categoryIdP16);
                    crystalReportViewer1.ReportSource = rptProductList;
                    break;
                case 17: //Supplier Due Detail
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    rptSupplierTranSummary rptSDD = new rptSupplierTranSummary();
                    rptSDD.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptSDD);
                    rptSDD.SetParameterValue("@fdt", fdt);
                    rptSDD.SetParameterValue("@tdt", tdt);
                    rptSDD.SetParameterValue("@storeId", stoId);
                    rptSDD.SetParameterValue("@supplierId", supId);
                    crystalReportViewer1.ReportSource = rptSDD;
                    break;
                case 18: //Supplier  Due Summary
                    if (cmbOrderBy.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please Select Order By");
                        return;
                    }

                    int order18 = cmbOrderBy.SelectedIndex;
                    rptSupplierDueSummary supDueSumry = new rptSupplierDueSummary();
                    supDueSumry.Refresh();
                    Helper.SetDataBaseLogonForCrReport(supDueSumry);
                    supDueSumry.SetParameterValue("@supplierId", supId);
                    supDueSumry.SetParameterValue("@OrderBy", order18);
                    crystalReportViewer1.ReportSource = supDueSumry;
                    break;
                case 19: //Monthly Expense
                    if (cmbMonth.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please Select Month");
                        return;
                    }
                    if (cmbYear.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please Select Year");
                        return;
                    }
                    frmMonthlyExpense frm = new frmMonthlyExpense();
                    frmMonthlyExpense.header = cmbMonth.Text + " " + cmbYear.Text;
                    frm.ShowDialog();
                    break;
                case 20: //Sale By Salesman
                    int salesmanId = (cmbSalesman.SelectedIndex < 1) ? -1 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    int customerId20 = (cmbCustomer.SelectedIndex < 1) ? -1 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    int categoryId20 = (cmbCategory.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);
                    int productId20 = (cmbItem.SelectedIndex < 1) ? 0 : Convert.ToInt32(cmbItem.SelectedValue);
                    rptSalesBySalesman rptSalesSalesman = new rptSalesBySalesman();
                    rptSalesSalesman.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptSalesSalesman);
                    rptSalesSalesman.SetParameterValue("@fdt", fdt);
                    rptSalesSalesman.SetParameterValue("@tdt", tdt);
                    rptSalesSalesman.SetParameterValue("@salesmanId", salesmanId);
                    rptSalesSalesman.SetParameterValue("@customerId", customerId20);
                    rptSalesSalesman.SetParameterValue("@storeId", stoId);
                    rptSalesSalesman.SetParameterValue("@categoryId", categoryId20);
                    rptSalesSalesman.SetParameterValue("@itemId", productId20);
                    crystalReportViewer1.ReportSource = rptSalesSalesman;
                    break;
                case 21: //Salesman Salary
                    int salesmanId21 = (cmbSalesman.SelectedIndex < 1) ? -1 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    rptEmployeeSalary salary = new rptEmployeeSalary();
                    salary.Refresh();
                    Helper.SetDataBaseLogonForCrReport(salary);
                    salary.SetParameterValue("@fdt", fdt);
                    salary.SetParameterValue("@tdt", tdt);
                    salary.SetParameterValue("@employeeId", salesmanId21);
                    salary.SetParameterValue("@storeId", stoId);
                    crystalReportViewer1.ReportSource = salary;
                    break;
                case 22: //Customer Wise Statement
                    if (cmbStore.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select a Store");
                        return;
                    }
                    if (cmbCustomer.SelectedIndex < 2)
                    {
                        MessageBox.Show("Please Select a Customer");
                        return;
                    }
                    int cusId22 = (cmbCustomer.SelectedIndex == 1) ? 0 : ((cmbCustomer.SelectedIndex == 0) ? -1 : Convert.ToInt32(cmbCustomer.SelectedValue));
                    rptCustomerWiseStatement CWS = new rptCustomerWiseStatement();
                    CWS.Refresh();
                    Helper.SetDataBaseLogonForCrReport(CWS);
                    CWS.SetParameterValue("@fdt", fdt);
                    CWS.SetParameterValue("@tdt", tdt);
                    CWS.SetParameterValue("@storeId", stoId);
                    CWS.SetParameterValue("@customerId", cusId22);
                    crystalReportViewer1.ReportSource = CWS;
                    break;
                case 23: //Refund Invoice
                    if (cmbInvoiceRefund.SelectedIndex < 1)
                    {
                        MessageBox.Show("Please Select Invoice");
                        return;
                    }
                    int invId23 = Convert.ToInt32(cmbInvoiceRefund.SelectedValue);
                    rptRefundProduct rptRefund = new rptRefundProduct();
                    rptRefund.Refresh();
                    Helper.SetDataBaseLogonForCrReport(rptRefund);
                    rptRefund.SetParameterValue("@InvoiceNo", invId23);
                    crystalReportViewer1.ReportSource = rptRefund;
                    break;
                default:
                    break;
            }
        }

        private void frmReportExplorer_Load(object sender, EventArgs e)
        {
            cmbStoreBind();
            BindEmployee();
            cmbSupplierBind();
            cmbCustomerBind();
            cmbCategoryBind();
            cmbItemBind();
            BindYear();
            cmbSaleType.SelectedIndex = 0;
            cmbPayType.SelectedIndex = 0;
            cmbOrderBy.SelectedIndex = 0;
            if (MDIParent.roleId != 2) //2 is ADMIN
            {
                cmbStore.SelectedValue = MDIParent.storeId;
                cmbStore.Enabled = false;
                cmbUserBind(MDIParent.storeId);
            }
           
            loadDone = true;
        }

        #region NEW CODE

        private void cmbStoreBind()
        {
            List<Store> lstStore = new StoreDAO().Store_GetAll();
            Store store = new Store();
            store.StoreId = 0;
            store.StoreName = "-- ALL --";
            lstStore.Add(store);
            lstStore = lstStore.OrderBy(s => s.StoreName).ToList();
            cmbStore.DataSource = lstStore;
            cmbStore.SelectedIndex = 1;
            if (MDIParent.roleId != 2) //2 is ADMIN
            {
                cmbStore.SelectedValue = MDIParent.storeId;
                cmbStore.Enabled = false;
            }
        }

        private void cmbSupplierBind()
        {
            List<Supplier> lstSup = new SupplierDAO().Supplier_GetAll();
            Supplier supplier = new Supplier();
            supplier.SupplierId = 0;
            supplier.SupplierName = "-- ALL --";
            lstSup.Add(supplier);
            lstSup = lstSup.OrderBy(s => s.SupplierName).ToList();
            cmbSupplier.DataSource = lstSup;
        }

        private void cmbCustomerBind()
        {
            List<tblCustomer> lstCustomer = new CustomerDAO().Customer_GetAll();
            tblCustomer cus = new tblCustomer();
            cus.customerId = -1;
            cus.Name = "-- ALL --";
            lstCustomer.Add(cus);
            tblCustomer cus2 = new tblCustomer();
            cus2.customerId = 0;
            cus2.Name = "-- GENERAL --";
            lstCustomer.Add(cus2);
            lstCustomer = lstCustomer.OrderBy(s => s.Name).ToList();
            cmbCustomer.DataSource = lstCustomer;
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "customerId";
        }

        private void cmbCategoryBind()
        {
            List<ProductCategory> lstCategory = new ProductCategoryDAO().ProductCategory_GetAll();
            ProductCategory category = new ProductCategory();
            category.categoryId = 0;
            category.deptName = "-- ALL --";
            lstCategory.Add(category);
            lstCategory = lstCategory.OrderBy(c => c.deptName).ToList();
            cmbCategory.DataSource = lstCategory;
        }

        private void cmbItemBind()
        {
            string where = "1=1";
            if (cmbCategory.SelectedIndex > -1 && Convert.ToInt32(cmbCategory.SelectedValue) > 0)
                where += " AND [categorytId] =" + Convert.ToInt32(cmbCategory.SelectedValue);
            List<Product> lstProduct = new ProductDAO().Product_GetDynamic(where, "name");
            Product product = new Product();
            product.productId = 0;
            product.name = "-- ALL --";
            lstProduct.Add(product);
            lstProduct = lstProduct.OrderBy(p => p.name).ToList();
            cmbItem.DataSource = lstProduct;
        }

        private void cmbPurchaseinvoiceBind()
        {
            BusinessObjects.Purchase pur = new BusinessObjects.Purchase();
            pur.purchaseId = 0;
            pur.description = "-- ALL --";
            List<BusinessObjects.Purchase> lstp = new List<BusinessObjects.Purchase>();
            if (cmbStore.SelectedIndex > 0 && cmbSupplier.SelectedIndex > 0)
                lstp = new PurchaseDAO().Purchase_GetDynamic("P.[StoreId] =" + cmbStore.SelectedValue + " AND P.[supplierId]=" + cmbSupplier.SelectedValue, "");
            lstp.Add(pur);
            lstp = lstp.OrderByDescending(i => i.purchaseId).ToList();
            cmbInvoice.DataSource = lstp;
            cmbInvoice.DisplayMember = "description";
            cmbInvoice.ValueMember = "purchaseId";
        }

        private void cmbSalesInvoiceBind()
        {
            Invoice inv = new Invoice();
            inv.invoiceId = 0;
            inv.InvoiceNo = "-- ALL --";
            List<Invoice> lstInv = new List<Invoice>();
            if (cmbStore.SelectedIndex > 0 && cmbCustomer.SelectedIndex > 0)
                lstInv = new InvoiceDAO().Invoice_GetDynamic("[StoreId] =" + cmbStore.SelectedValue + " AND I.[customerId]=" + cmbCustomer.SelectedValue, "");
            //lstInv.Add(inv);
            lstInv = lstInv.OrderByDescending(i => i.invoiceId).ToList();
            lstInv.Insert(0, inv);
            cmbInvoice.DataSource = lstInv;
            cmbInvoice.DisplayMember = "InvoiceNo";
            cmbInvoice.ValueMember = "invoiceId";
        }

        private void cmbSalesInvoiceRefundBind()
        {
            Invoice inv = new Invoice();
            inv.invoiceId = 0;
            inv.InvoiceNo = "-- ALL --";
            List<Invoice> lstInv = new List<Invoice>();
            if (cmbStore.SelectedIndex > 0 && cmbCustomer.SelectedIndex > 0)
                lstInv = new InvoiceDAO().Invoice_GetDynamic("[StoreId] =" + cmbStore.SelectedValue + " AND I.[customerId]=" + cmbCustomer.SelectedValue
                    + " AND I.invoiceId IN (SELECT DISTINCT invoiceId FROM dbo.tblRefund WITH(NOLOCK))", "");
            //lstInv.Add(inv);
            lstInv = lstInv.OrderByDescending(i => i.invoiceId).ToList();
            lstInv.Insert(0, inv);
            cmbInvoiceRefund.DataSource = lstInv;
            cmbInvoiceRefund.DisplayMember = "InvoiceNo";
            cmbInvoiceRefund.ValueMember = "invoiceId";
        }

        private void BindEmployee()
        {
            List<Employee> lst = new EmployeeDAO().Employee_GetAll();
            Employee emp = new Employee(0, "-- ALL --", true);
            lst.Add(emp);
            //Employee emp2 = new Employee(0, "1.No Salesman", true);
            //lst.Add(emp2);
            lst = lst.OrderBy(s => s.EmployeeName).ToList();
            cmbSalesman.DataSource = lst;
            //cmbSalesman.DisplayMember = "EmployeeName";
            //cmbSalesman.ValueMember = "EmployeeId";
        }

        private void BindYear()
        {
            List<Year> lst = new List<Year>();
            int curYear = DateTime.UtcNow.AddHours(6).Year;

            for (int i = curYear - 10; i < curYear + 1; i++)
            {
                Year se = new Year();
                se.YearId = i;
                se.YearName = i.ToString();
                lst.Add(se);
            }
            lst = lst.OrderByDescending(p => p.YearId).ToList();
            cmbYear.DataSource = lst;
            cmbYear.SelectedValue = curYear.ToString();
        }

        #endregion

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbItemBind();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shift shift = new Shift();
            shift.shiftId = 0;
            shift.shiftName = "-- ALL --";
            List<Shift> lstShift = new List<Shift>();
            if (cmbUser.SelectedIndex > 0)
                lstShift = new ShiftDAO().Shift_GetDynamic("[userId]=" + cmbUser.SelectedValue, "");
            lstShift.Add(shift);
            lstShift.OrderByDescending(s => s.shiftName).ToList();
            cmbShift.DataSource = lstShift;
        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbUserBind(Convert.ToInt32(cmbStore.SelectedValue));
            cmbPurchaseinvoiceBind();
            cmbSalesInvoiceBind();
            BindEmployee();
        }

        private void cmbUserBind(int StoreId)
        {
            string where = "U.[UpdatedBy] > 0";
            if (StoreId > 0) where += " AND U.[UpdatedBy]=" + StoreId;
            List<Users> lstU = new UsersDAO().Users_GetDynamic(where, "");
            Users user = new Users();
            user.UserId = 0;
            user.Name = "-- ALL --";
            lstU.Add(user);
            lstU = lstU.OrderBy(u => u.Name).ToList();
            cmbUser.DataSource = lstU;
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPurchaseinvoiceBind();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSalesInvoiceBind();
            cmbSalesInvoiceRefundBind();
        }
    }
}

public class Year
{
    public int YearId { get; set; }
    public string YearName { get; set; }
}
