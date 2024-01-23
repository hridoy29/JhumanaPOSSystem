using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using POSsible.BusinessObjects;
using POSsible.DAL;
using System.Linq;
using System.Windows.Documents;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Data.Common;
using CrystalDecisions.Shared;
using System.Configuration;

namespace POSsible
{
    public partial class frmMain : Form, POSsible.Views.IMainView
    {
        public bool offerEffect = false;
        public int iItemCount = 0;
        public double dTotalValue = 0.0;
        private double dtotalDiscount = 0.0;
        private int irow = 0;
        public ArrayList listItem = new ArrayList();
        int resultInvoiceAdd = 0;
        string invoiceNo = "";
        string cusMobNo = "";
        string cusName = "";
        int ledgerId = 0;
        int ledgerIdCus = 0;
        int ledgerIdSales = 0;
        int ledgerIdCIH = 0;
        public double weight = 0.0;
        public int isThereADot = 0;
        public double totCashSale = 0; //SHIFT TOTAL
        public double totCardSale = 0; //SHIFT TOTAL
        public int shiftId = 0;
        public Product PEntityMain = new Product();
        public bool loadDone = false;
        public int Defaulter = 0;

        public CUser oUserLogin = new CUser();
        TransactionDAO oTransactionDAO = new TransactionDAO();
        ProductPromotionDAO oProductPromotionDAO = new ProductPromotionDAO();
        public DateTime dtLogin = DateTime.Now;

        private bool bCashCardClick = false;
        private bool bCashChangeClick = false;
        private bool bTotalBtn = false;
        private bool bNumberClick = false;

        frmOffice frmOffice = new frmOffice();
        frmLogin frmLogin = new frmLogin();
        public CInvoice oInvoice = new CInvoice();

        InvoiceDAO oInvoiceDAO = new InvoiceDAO();
        InvoiceProductDAO oInvoiceProductDAO = new InvoiceProductDAO();
        ProductDAO ProductDAO = new ProductDAO();
        private bool AddingFromList = false;
        private Product ProductFromList = new Product();
        List<InvoiceProduct> lstHold = new List<InvoiceProduct>();
        private int custHold = 0;
        private int sManHold = 0;
        private string saleTypeHold = string.Empty;
        private string payTypeHold = string.Empty;

        #region constructor
        public frmMain()
        {
            InitializeComponent();
            CheckShiftStartEnd();
            cmbCustomerBind();
            CheckShiftStartEnd();
        }

        public frmMain(frmOffice frmOfficeCon)
        {
            InitializeComponent();
            frmOffice = frmOfficeCon;
            cmbCustomerBind();
            CheckShiftStartEnd();
            frmOffice.Hide();
        }

        public frmMain(frmLogin frmLoginCon)
        {
            InitializeComponent();
            this.frmLogin = frmLoginCon;
            cmbCustomerBind();
            CheckShiftStartEnd();
            frmLogin.Hide();
        }

        #endregion

        private void btnFruitLookUpAtoZ_Click_1(object sender, EventArgs e)
        {
            Button catName = (Button)sender;

            frmItemLookUp ofrmFruitLookUp = new frmItemLookUp(this, catName.Text);
            ofrmFruitLookUp.ShowDialog();
            frm_refresh();
        }

        private void frm_refresh()
        {
            double amount = 0; double discnt = 0;

            txtNoOfItems.Text = Convert.ToString(dgvItem.Rows.GetRowCount(DataGridViewElementStates.Displayed));
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                amount += Convert.ToDouble(item.Cells["subtotal"].Value);
                discnt += (Convert.ToDouble(item.Cells["discount"].Value) * Convert.ToDouble(item.Cells["qty"].Value));
            }
            txtTotalAmt.Text = String.Format("{0:##0.00}", amount);
            txtDiscount.Text = String.Format("{0:##0.00}", discnt);
        }

        private void btnInstantDiscount_Click_1(object sender, EventArgs e)
        {
            frmAuthorization oFrmAuthorizitation = new frmAuthorization(this, "InstantDiscount");
            oFrmAuthorizitation.Show();
        }

        private void btnCancelSelected_Click_1(object sender, EventArgs e)
        {
            int iCount = dgvItem.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (iCount > 0)
            {
                int iIndex = dgvItem.SelectedRows[0].Index;

                #region Cancel Promoted Item
                //if (dgvItem.Rows[iIndex].Selected)
                dgvItem.Rows.RemoveAt(iIndex);

                //updateList();
                //offerEffect = false;
                #endregion

            }

            picBxImageDisplay.Image = null;
            picBxImageDisplay.Invalidate();
            frm_refresh();
            cmbItem.Focus();
        }

        private void btnVegeLookupAtoZ_Click_1(object sender, EventArgs e)
        {
            Button catName = (Button)sender;

            frmItemLookUp ofrmVegeLkUp = new frmItemLookUp(this, catName.Text);
            ofrmVegeLkUp.ShowDialog();
            frm_refresh();
        }

        private void btnPlu_Click(object sender, EventArgs e)
        {
            frmPlu ofrmPlu = new frmPlu(this);
            ofrmPlu.ShowDialog();
        }
        //TOTAL CLICK
        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select customer", "Required");
                cmbCustomer.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                MessageBox.Show("Please give Invoice #", "Required");
                txtInvoiceNo.Focus();
                return;
            }

            try
            {
                if (dgvItem.Rows.Count > 0)
                {
                    int proId = MDIParent.projectId;
                    if (offerEffect)
                    {
                        DialogResult dg = MessageBox.Show("Product List Updated for Promotion. Do you want to checkout the Changes?", "POSsible", MessageBoxButtons.YesNo);
                        if (dg == DialogResult.Yes)
                        {
                            offerEffect = false;
                            return;
                        }
                    }

                    pnlBankNote.Visible = true;
                    pnlBankNote.Enabled = true;

                    pnlLeftBottomBankNote.Visible = true;
                    pnlLeftBottomBankNote.Enabled = true;

                    pnlLeftBottomOriginal.Visible = false;
                    pnlOriginalForm.Visible = false;
                    pnlOriginalForm.Enabled = false;
                    pnlLeftBottomOriginal.Enabled = false;

                    pnlPaymentDisplay.Enabled = true;
                    pnlPaymentDisplay.Visible = true;

                    btnEnter.Visible = false;
                    txtDiscount.ReadOnly = true;
                    txtSpDiscount.ReadOnly = false;

                    //Finalization for an Item total
                    int itemCount = dgvItem.RowCount;
                    txtNoOfItems.Text = itemCount.ToString();
                    if (oInvoice != null && dtotalDiscount > 0)
                    {
                        //oInvoice.DiscountGiven = Convert.ToDouble(lblTotalValue.Text) * oInvoice.DiscountGiven;
                        oInvoice.DiscountGiven = Convert.ToDouble(lblTotalValue.Text.Trim()) * dtotalDiscount;
                        lblTotalValue.Text = string.Format("{0:###0.00}", (Convert.ToDouble(lblTotalValue.Text.Trim()) - oInvoice.DiscountGiven));
                    }

                    txtBarcode.TextAlign = HorizontalAlignment.Right;
                    //bTotalBtn = true;
                    //txtTotal.Text = "0".ToString();
                    txtBarcode.Text = "";
                    //changes 1/13
                    txtAmount.Visible = true;
                    txtBarcode.Visible = false;
                    txtAmount.Focus();
                    bTotalBtn = true;
                    if (txtBarcode.Text == "")
                        calculateforPaymentDisplay();

                    if (string.IsNullOrEmpty(txtDiscount.Text))
                        txtDiscount.Text = "0";

                    groupBox1.Visible = false;
                    groupBox2.Visible = false;

                    if (rbCash.Checked)
                    {
                        pnlPaymentDisplay.Visible = true;
                        txtDiscount_TextChanged(null, null);
                    }
                    else if (rbCredit.Checked)
                        pnlCreditDisplay.Visible = true;

                    if (rbCredit.Checked)
                    {
                        txtDiscount_TextChanged(null, null);
                        double crNetAmt = string.IsNullOrEmpty(txtCreditNetAmt.Text.Trim()) ? 0 : Convert.ToDouble(txtCreditNetAmt.Text);
                        double prvBal = string.IsNullOrEmpty(txtCreditPrevBalance.Text.Trim()) ? 0 : Convert.ToDouble(txtCreditPrevBalance.Text);
                        double crFigure = string.IsNullOrEmpty(lblCrFigure.Text.Trim()) ? 0 : Convert.ToDouble(lblCrFigure.Text);
                        txtCreditNewBalance.Text = (crNetAmt + prvBal).ToString();
                        txtCreditBalance.Text = (crFigure - Convert.ToDouble(txtCreditNewBalance.Text)).ToString();
                    }

                    AddMode(false);
                }
                else
                {
                    MessageBox.Show("Item list is Empty;Please select some items to create invoice for.");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnCancelCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItem.Rows.Count > 0)
                {
                    dgvItem.Rows.Clear();
                    txtNoOfItems.Clear();
                    lblTotalValue.Text = "";

                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                }

                iItemCount = 0;
                dTotalValue = 0.00;
                oInvoice = null;
                oInvoice = new CInvoice();
                txtBarcode.Clear();
                txtTotalAmt.Clear();
                txtNoOfItems.Clear();
                txtDiscount.Clear();
                cmbItem.SelectedIndex = -1;
                cmbItem.Text = string.Empty;
                txtSaleQty.Clear();
                txtUnitPrice.Clear();
                txtUnitDisc.Clear();
                ProductFromList = new Product();
                AddingFromList = false;
                cmbItem.Focus();
            }
            catch (Exception xcp)
            {

            }
            //frm_refresh();
            //cmbItem.Focus();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStartShift.Text == "START SHIFT")
                {
                    UserLogins UL = new UserLoginsDAO().UserLogins_GetById(MDIParent.CF2);
                    if (UL != null)
                    {
                        UL.UserLogoutTime = DateTime.Now;
                        new UserLoginsDAO().Update(UL);
                    }
                    frmLogin frmLog = new frmLogin();
                    frmLog.ShowDialog();
                    MDIParent.userId = 0;
                    MDIParent.storeId = 0;
                    MDIParent.shiftId = 0;
                    this.Dispose();
                }
                else
                {
                    DialogResult dg = MessageBox.Show("You have to end your shift before logging off. Do you want to end your shift?", "End Shift", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        btnStartShift.PerformClick();
                        btnLogOff.PerformClick();
                    }
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show("Error occured.");
            }
        }
        //SAVE
        private void btnProcess_Click(object sender, EventArgs e)
        {
            double prvBal = string.IsNullOrEmpty(txtCreditBalance.Text.Trim()) ? 0 : Convert.ToDouble(txtCreditBalance.Text);
            if (rbCredit.Checked && prvBal < 0)
            {
                DialogResult dr = MessageBox.Show("Net Amount crossed the Customers Credit Limit. Do you want to use Admin rights? \n\nClick 'Yes' for Admin. 'No' to go back and change Invoice.", "POSsible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Form admin = new AdminPasswordPromt();
                    admin.ShowDialog(this);
                    if (!MDIParent.gotAdminRight)
                        return;
                    else
                        MDIParent.gotAdminRight = false;
                }
                else
                    return;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                txtAmount.Text = "0";
            }

            double dTotalGst = 0;
            double dTotalGivenAmount = 0;
            double cashAmt = (string.IsNullOrEmpty(txtCashAmountValue.Text)) ? 0 : Convert.ToDouble(txtCashAmountValue.Text.Trim());
            double cardAmt = ((string.IsNullOrEmpty(txtCardAmountValue.Text)) ? 0 : Convert.ToDouble(txtCardAmountValue.Text.Trim()));

            double cashNetAmt = ((string.IsNullOrEmpty(txtCashNetAmt.Text.Trim())) ? 0 : Convert.ToDouble(txtCashNetAmt.Text.Trim()));
            double CreditNetAmt = ((string.IsNullOrEmpty(txtCreditNetAmt.Text.Trim())) ? 0 : Convert.ToDouble(txtCreditNetAmt.Text.Trim()));

            double totalAmt = (rbCash.Checked) ? cashNetAmt : CreditNetAmt;

            if (rbCredit.Checked)
                dTotalGivenAmount = totalAmt;
            else
                dTotalGivenAmount = cashAmt + cardAmt;

            List<InvoiceProduct> lst = new List<InvoiceProduct>();
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                oInvoiceProduct.EnteredTime = DateTime.Now;
                oInvoiceProduct.productId = Convert.ToInt32(item.Cells["ItemId"].Value);
                oInvoiceProduct.qty = Convert.ToDouble(String.Format("{00:00.00}", item.Cells["qty"].Value));
                oInvoiceProduct.unitPrice = Convert.ToDouble(String.Format("{00:00.00}", item.Cells["price"].Value));
                oInvoiceProduct.Status = (String.Format("{00:00.00}", item.Cells["discount"].Value));
                oInvoiceProduct.PcItemId = Convert.ToInt32(item.Cells["PcItemId"].Value);
                if (oInvoiceProduct.PcItemId != -3)
                    oInvoiceProduct.PcsPerCrtn = Convert.ToDouble(item.Cells["PcsPerCrtn"].Value);
                oInvoiceProduct.Updatedatime = DateTime.Now;
                oInvoiceProduct.StoreId = MDIParent.storeId;
                lst.Add(oInvoiceProduct);
            }



            if (Convert.ToDouble(dTotalGivenAmount) >= totalAmt && Convert.ToDouble(txtCashChangeValue.Text) >= 0)
            {
                DbTransaction trans = UtilsDAO.BeginTransaction();

                try
                {
                    DbProviderHelper.Trans = trans;
                    DbProviderHelper.IsInTransaction = true;

                    #region Invoice
                    DateTime now = DateTime.Now;
                    Invoice oInvoice = new Invoice();
                    oInvoice.InvoiceNo = txtInvoiceNo.Text.Trim();
                    invoiceNo = oInvoice.InvoiceNo;
                    //if (rbCredit.Checked)
                        //oInvoice.InvoiceNo = "INV/" + now.Day + now.Month + now.Millisecond + "(Credit)";
                    oInvoice.shiftId = MDIParent.shiftId;
                    oInvoice.userId = MDIParent.userId;//oUserLogin.UserID;
                    oInvoice.customerId = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                    oInvoice.DiscountAthorizedId = (cmbSalesman.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSalesman.SelectedValue);
                    oInvoice.StoreId = MDIParent.storeId;
                    oInvoice.invoiceDate = dtSaleDate.Value;
                    oInvoice.SaleType = (rbRetail.Checked) ? "Retail" : (rbWS.Checked) ? "Wholesale" : "Special";
                    oInvoice.TotalPrice = totalAmt;
                    oInvoice.TotalGST = dTotalGst;
                    oInvoice.CashAmt = (rbCash.Checked) ? Convert.ToDouble(txtCashAmountValue.Text) : 0;
                    oInvoice.CardAmt = (rbCash.Checked) ? (!string.IsNullOrEmpty(txtCardAmountValue.Text)) ? Convert.ToDouble(txtCardAmountValue.Text) : 0 : 0;
                    double dChangeGiven = txtCashChangeValue.Text == "" ? 0 : Convert.ToDouble(txtCashChangeValue.Text);
                    oInvoice.changeGiven = dChangeGiven;
                    oInvoice.DiscountGiven = string.IsNullOrEmpty(txtSpDiscount.Text) ? "0.00" : txtSpDiscount.Text;
                    oInvoice.description = "desc";
                    oInvoice.status = (rbCash.Checked) ? "Cash" : "Credit";
                    oInvoice.updatedTime = DateTime.Now;
                    oInvoice.updatedBy = MDIParent.userId;
                    oInvoice.CardType = "American Express";
                    oInvoice.CardNo = "Card No.";
                    oInvoice.CardHolderName = "Name";
                    oInvoice.CusPrevBalance = (string.IsNullOrEmpty(txtCreditPrevBalance.Text)) ? 0 : Convert.ToDouble(txtCreditPrevBalance.Text);
                    oInvoice.CF1 = cusMobNo;
                    oInvoice.CF2 = "1";
                    oInvoice.CF3 = "1"; //cmbSalesman.SelectedValue.ToString();
                    if (rbCredit.Checked) oInvoice.CF2 = "0";

                    //oInvoice.CustomerName = cusName;
                    //oInvoice.SaleAcLgId = ledgerIdSales;
                    //oInvoice.CusAcLgId = ledgerIdCus;
                    //oInvoice.CIHAcLgId = ledgerIdCIH;
                    //oInvoice.BankAcLgId = MDIParent.CardAmtLgId;
                    //oInvoice.ProjectId = MDIParent.projectId.ToString();

                    resultInvoiceAdd = oInvoiceDAO.Add(oInvoice);
                    if (resultInvoiceAdd < 0) throw new Exception();
                    #endregion

                    if (rbCash.Checked)
                    {
                        CreditCollection CCEntity = new CreditCollection();
                        CCEntity.SaleId = resultInvoiceAdd;
                        CCEntity.CollectionDate = (DateTime)oInvoice.invoiceDate;
                        CCEntity.CollectionType = "Cash";
                        CCEntity.ChequeNo = string.Empty;
                        CCEntity.ChequeBank = string.Empty;
                        CCEntity.ChequeDate = oInvoice.invoiceDate;
                        CCEntity.PaidAmount = (double)oInvoice.TotalPrice;
                        CCEntity.DiscAmount = 0;
                        CCEntity.RemAmount = 0;
                        CCEntity.DueBalance = 0;
                        CCEntity.MemoNo = "";
                        CCEntity.PaidBy = "";
                        CCEntity.MRBookNo = MDIParent.userName;
                        CCEntity.ReceivedBy = 1;
                        CCEntity.Remarks = "Sale Collection";
                        CCEntity.EnteredBy = MDIParent.userId;
                        CCEntity.EnteredTime = DateTime.Now;
                        CCEntity.CF1 = MDIParent.storeId.ToString(); //STORE ID
                        CCEntity.CF2 = MDIParent.shiftId.ToString();
                        new CreditCollectionDAO().Add(CCEntity);
                    }

                    foreach (InvoiceProduct item in lst)
                    {
                        item.invoiceId = resultInvoiceAdd;
                        oInvoiceProductDAO.Add(item);
                    }

                    UtilsDAO.CommitTransaction(trans);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured. \nSale could not be saved.", "POSsible-Error Message");
                }
                finally
                {
                    if (DbProviderHelper.IsInTransaction)
                    {
                        UtilsDAO.RollbackTransaction(trans);
                    }
                }

                if (rbCash.Checked)
                {
                    totCashSale += (!String.IsNullOrEmpty(txtCashAmountValue.Text)) ? Convert.ToDouble(txtCashAmountValue.Text) : 0;
                    totCardSale += (!String.IsNullOrEmpty(txtCardAmountValue.Text)) ? Convert.ToDouble(txtCardAmountValue.Text) : 0;
                    PrintText();
                }

                if (rbCredit.Checked)
                {
                    DialogResult result;
                    result = MessageBox.Show("Print invoice with Previous Balance?\nYes:With PV, No:Without PV, Cancel:Don't Print", "POSsible", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes || result == DialogResult.No)
                    {
                        try
                        {
                            string showPV = (result == DialogResult.Yes) ? "Yes" : "No";
                            Reports.rptInvoiceForCreditSale report1 = new Reports.rptInvoiceForCreditSale();
                            Helper.SetDataBaseLogonForCrReport(report1);
                            DataTable dt = oInvoiceDAO.Report_InvoiceForCreditSale(resultInvoiceAdd, showPV, chkShowRP.Checked);
                            report1.SetDataSource(dt);
                            report1.SetParameterValue("@InvoiceId", resultInvoiceAdd);
                            report1.SetParameterValue("@SaleType", showPV);
                            report1.SetParameterValue("@ShowRetailPrice", chkShowRP.Checked);

                            report1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            report1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

                            PrintDialog printDialog = new PrintDialog();

                            DialogResult dgResult = printDialog.ShowDialog();

                            if (dgResult == DialogResult.OK)
                            {
                                report1.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                report1.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Credit Sale saved. Cannot Print Invoice", "Message");
                        }
                    }

                }
                //Show PreProcessor Dialog for some times
                if (rbCash.Checked)
                {
                    frmPreProcDialog o_preprocdialog = new frmPreProcDialog((string.IsNullOrEmpty(txtCashAmountValue.Text)) ? "0" : (txtCashAmountValue.Text), (string.IsNullOrEmpty(txtCashChangeValue.Text)) ? "0" : (txtCashChangeValue.Text), (string.IsNullOrEmpty(txtCardAmountValue.Text)) ? "0" : (txtCardAmountValue.Text));
                    o_preprocdialog.ShowDialog();
                }

                //Prepare POS Main for next Invoice
                gotoProductSelect("PROCESS");
            }
            else
            {
                MessageBox.Show("You need to pay more", "POSsible");
                txtAmount.Focus();
            }
            frm_refresh();
            rbCredit.Checked = true;
            rbRetail.Checked = true;
            cmbCustomer.SelectedIndex = -1;
            cmbSalesman.SelectedIndex = -1;
            txtInvoiceNo.Clear();
            dtSaleDate.Value = DateTime.Now;
            cmbCustomer.Focus();
        }

        private void btnPrintPast_Click(object sender, EventArgs e)
        {
            frmPrintPast objPrntPast = new frmPrintPast();
            objPrntPast.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            cmbItem.Focus();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmOffice.Hide();
            pnlPaymentDisplay.Visible = false;
            pnlPaymentDisplay.Enabled = false;

            groupBox2.Visible = false;
            lblUserName.Text = MDIParent.userName;
            rbRetail.Checked = true;
            BindItem();
            BindEmployee();
            if (MDIParent.roleId > 3) btnPurchase.Visible = false;
            btnStartShift.Select();
        }

        private void BindEmployee()
        {
            List<Employee> lst = new EmployeeDAO().Employee_GetAll().Where(r => r.IsActive == true).ToList();
            foreach (Employee item in lst)
            {
                item.EmployeeName = item.EmployeeName + " - " + item.ShortName;   
            }
            cmbSalesman.DataSource = lst;
            //cmbSalesman.DisplayMember = "EmployeeName";
            //cmbSalesman.ValueMember = "EmployeeId";
            cmbSalesman.SelectedIndex = -1;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (txtBarcode.TextLength > 0)
            {
                txtBarcode.Text = txtBarcode.Text.Remove(txtBarcode.TextLength - 1);
            }

        }

        public void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                irow = e.RowIndex;
                int id = int.Parse(dgvItem.Rows[irow].Cells["ItemId"].Value.ToString());
                Product P = ProductDAO.Product_GetById(id);
                byte[] imgRaw = P.ProductImage;

                frmIncreaseQty ofrmIncreaseQty = new frmIncreaseQty(this);
                ofrmIncreaseQty.ShowDialog();
                frm_refresh();

                if (imgRaw != null)
                {
                    MemoryStream memory = new MemoryStream(imgRaw);
                    this.picBxImageDisplay.Image = Image.FromStream(memory);
                }
                else
                {
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                }

                //updateList();
                offerEffect = false;
            }
            catch (Exception excp)
            {
                picBxImageDisplay.Image = null;
                picBxImageDisplay.Invalidate();
            }
        }

        private void btnOriginalRefund_Click(object sender, EventArgs e)
        {
            frmRefund oFrmRefund = new frmRefund();
            oFrmRefund.Show();

        }

        private void btnStartShift_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnStartShift.Text.Equals("START SHIFT"))
                {
                    this.btnStartShift.Text = "END SHIFT";
                    frmShiftPass frm = new frmShiftPass(this);
                    DialogResult dr = frm.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.Cancel) { this.btnStartShift.Text = "START SHIFT"; return; }
                    totCashSale = 0;
                    totCardSale = 0;
                    dtSaleDate.Focus();

                    #region Category
                    List<Button> lstButton = new List<Button>(5);
                    lstButton.Add(btnVegeLookupAtoZ);
                    lstButton.Add(btnFruitLookUpAtoZ);
                    lstButton.Add(btnFishLookup);
                    lstButton.Add(btnMeatLookup);
                    lstButton.Add(btnCat5);

                    List<ProductCategory> PClist = new ProductCategoryDAO().ProductCategory_GetAll();
                    if (PClist.Count > 0)
                    {
                        PClist = PClist.Take(5).ToList();
                        for (int i = 0; i < PClist.Count; i++)
                        {
                            lstButton[i].Text = PClist[i].deptName;
                            lstButton[i].Enabled = true;
                        }
                    }
                    #endregion

                }
                else
                {
                    this.btnStartShift.Text = "START SHIFT";
                    frmShiftPass frm = new frmShiftPass(this);
                    DialogResult dr = frm.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.Cancel) { this.btnStartShift.Text = "END SHIFT"; return; }
                    MDIParent.shiftId = 0;
                    AddMode(false);
                }

                loadDone = true;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message + "Shift Start/End Error");
            }
        }

        private void btnOriginalSafeDrop_Click(object sender, EventArgs e)
        {
            //frmSafeFund oFrmSafeFund = new frmSafeFund(this);
            //oFrmSafeFund.ShowDialog();
            if (btnOriginalSafeDrop.Text == "HOLD")
            {
                if (dgvItem.RowCount < 1)
                {
                    return;
                }

                custHold = (cmbCustomer.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue);
                sManHold = (cmbSalesman.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSalesman.SelectedValue);
                saleTypeHold = rbRetail.Checked ? "RT" : (rbWS.Checked ? "WS" : "SP");
                payTypeHold = rbCash.Checked ? "Cash" : "Credit";

                lstHold = new List<InvoiceProduct>();
                foreach (DataGridViewRow item in dgvItem.Rows)
                {
                    InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                    oInvoiceProduct.productName = Convert.ToString(item.Cells["name"].Value);
                    oInvoiceProduct.productId = Convert.ToInt32(item.Cells["ItemId"].Value);
                    oInvoiceProduct.qty = Convert.ToDouble(String.Format("{00:00.00}", item.Cells["qty"].Value));
                    oInvoiceProduct.unitPrice = Convert.ToDouble(String.Format("{00:00.00}", item.Cells["price"].Value));
                    oInvoiceProduct.Status = (String.Format("{00:00.00}", item.Cells["discount"].Value));
                    oInvoiceProduct.categorytId = Convert.ToInt32(item.Cells["categoryId"].Value);
                    oInvoiceProduct.PcItemId = Convert.ToInt32(item.Cells["PcItemId"].Value);
                    oInvoiceProduct.PcsPerCrtn = Convert.ToDouble(item.Cells["PcsPerCrtn"].Value);
                    string[] arr = Convert.ToString(item.Cells["quantity"].Value).Split('@');
                    oInvoiceProduct.UnitMeasureName = arr[0];
                    lstHold.Add(oInvoiceProduct);
                }

                txtNoOfItems.Clear();
                txtDiscount.Clear();
                txtTotalAmt.Clear();
                rbCash.Checked = true;
                rbRetail.Checked = true;
                cmbCustomer.SelectedIndex = -1;
                cmbSalesman.SelectedIndex = -1;
                dgvItem.Rows.Clear();
                groupBox2.Visible = false;
                btnOriginalSafeDrop.Text = "UNHOLD";
            }
            else
            {
                if (dgvItem.RowCount > 0)
                {
                    return;
                }

                if (custHold > 0)
                {
                    cmbCustomer.SelectedValue = custHold;
                    groupBox2.Visible = true;
                }
                else groupBox2.Visible = false;
                if (sManHold > 0) cmbSalesman.SelectedValue = sManHold;
                if (saleTypeHold == "RT") rbRetail.Checked = true;
                else if (saleTypeHold == "WS") rbWS.Checked = true;
                else if (saleTypeHold == "SP") rbSpecial.Checked = true;
                if (payTypeHold == "Cash") rbCash.Checked = true;
                else if (payTypeHold == "Credit") rbCredit.Checked = true;

                int rowIndx = 0;
                foreach (InvoiceProduct invoiceProduct in lstHold)
                {
                    dgvItem.Rows.Insert(rowIndx, invoiceProduct.productName, (string.Format("{0:###0.00}", invoiceProduct.qty)), (string.Format("{0:##0.00}", invoiceProduct.unitPrice)),
                        (string.Format("{0:###0.00}", invoiceProduct.qty)) + " " + invoiceProduct.UnitMeasureName + "@" + (string.Format("{0:##0.00}", invoiceProduct.unitPrice)),
                        string.Format("{0:##0.00}", invoiceProduct.unitPrice * invoiceProduct.qty), invoiceProduct.productId, invoiceProduct.categorytId, invoiceProduct.Status, invoiceProduct.PcItemId, invoiceProduct.PcsPerCrtn);
                }
                frm_refresh();

                custHold = 0;
                sManHold = 0;
                saleTypeHold = string.Empty;
                payTypeHold = string.Empty;
                lstHold = new List<InvoiceProduct>();
                btnOriginalSafeDrop.Text = "HOLD";
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBarcode.Text.Length == 6 && txtBarcode.Text[0] == '.')
            {
                #region Shortcode Check
                string sCode = txtBarcode.Text.Remove(0, 1);
                Product P = ProductDAO.Product_GetDynamic("[shortcode]='" + sCode + "'", "").FirstOrDefault();

                if (P != null)
                {
                    int qty = 1;
                    if (Convert.ToBoolean(P.ticketType))
                    {
                        weight = 0;
                        frmWeightTaker frmWT = new frmWeightTaker(this);
                        frmWT.ShowDialog();
                        qty = Convert.ToInt32(weight);
                    }

                    double CurrentQty = oTransactionDAO.ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + Convert.ToInt32(P.productId) + ")");
                    if (qty > CurrentQty)
                    {
                        MessageBox.Show("Product Available : " + CurrentQty, "POSsible");
                        return;
                    }

                    addRow(P.productId, qty, P.UnitMeasureName, "General", P.categorytId);

                    if (P.ProductImage != null)
                    {
                        MemoryStream memory = new MemoryStream(P.ProductImage);
                        picBxImageDisplay.Image = Image.FromStream(memory);
                    }
                    else
                    {
                        picBxImageDisplay.Image = null;
                        picBxImageDisplay.Invalidate();
                    }
                    //updateList();
                    txtBarcode.Text = "";
                    cmbItem.Focus();
                    frm_refresh();

                }
                else
                {
                    MessageBox.Show("No product found for this Shortcode", "POSsible: Message");
                    txtBarcode.Text = "";
                    cmbItem.Focus();
                }
                #endregion
            }

            #region Barcode CHekc
            else if (txtBarcode.Text != string.Empty)
            {
                if ((txtBarcode.Text.IndexOf('.') == 0) && (e.KeyCode == Keys.Enter))
                {
                    if (isThereADot == 0) txtBarcode.Clear();
                    cmbItem.Focus();
                }
                if (bTotalBtn.Equals(false))
                {
                    if (e.KeyData.ToString() == "Return")
                    {
                        try
                        {
                            string sBarcode = txtBarcode.Text.Trim();

                            if (isThereADot == 1)
                            {
                                //int a = sBarcode.IndexOf('.');
                                sBarcode = sBarcode.Remove(0, 1);
                            }


                            Product PE = ProductDAO.Product_GetDynamic("[barcodeNo]='" + sBarcode + "'", "").FirstOrDefault();
                            if (PE != null)
                            {
                                double qty = 1;
                                if (Convert.ToBoolean(PE.ticketType))
                                {
                                    weight = 0;
                                    frmWeightTaker frmWT = new frmWeightTaker(this);
                                    frmWT.ShowDialog();
                                    qty = Convert.ToDouble(weight);
                                }

                                double CurrentQty = oTransactionDAO.ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + Convert.ToInt32(PE.productId) + ")");
                                if (qty > CurrentQty)
                                {
                                    MessageBox.Show("Product Available : " + CurrentQty, "POSsible");
                                    return;
                                }

                                addRow(PE.productId, qty, PE.UnitMeasureName, "General", PE.categorytId);

                                if (PE.ProductImage != null)
                                {
                                    MemoryStream memory = new MemoryStream(PE.ProductImage);
                                    picBxImageDisplay.Image = Image.FromStream(memory);
                                }
                                else
                                {
                                    picBxImageDisplay.Image = null;
                                    picBxImageDisplay.Invalidate();
                                }
                                //updateList();
                                txtBarcode.Text = "";
                                cmbItem.Focus();
                                frm_refresh();

                            }
                            else
                            {
                                MessageBox.Show("No product found for this BarCode", "POSsible: Message");
                                txtBarcode.Text = "";
                                cmbItem.Focus();
                            }
                        }
                        catch (Exception xcp)
                        {
                            MessageBox.Show("Error occured:" + xcp.Message.ToString());
                        }
                        isThereADot = 0;
                    }

                }
            }
            #endregion

        } //BARCODE & SHORTCODE

        private void txtBarcode1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e != null && e.KeyCode == Keys.Enter) || AddingFromList)
                {
                    Product product = new Product();
                    double qty = 1;
                    double uPrice = 0;
                    double uDisc = 0;
                    int rowIndex = dgvItem.Rows.Count;

                    if (AddingFromList)
                    {
                        product = ProductFromList;
                        qty = Convert.ToDouble(string.Format("{0:###0.00}", txtSaleQty.Text));
                        uPrice = Convert.ToDouble(string.Format("{0:##0.00}", txtUnitPrice.Text));
                        uDisc = Convert.ToDouble(string.Format("{0:##0.00}", txtUnitDisc.Text));
                    }
                    else
                    {
                        string type = "Barcode";
                        string code = txtBarcode.Text.Trim();
                        string where = "[barcodeNo]='" + code + "'";

                        if (txtBarcode.Text[0] == '.')
                        {
                            type = "Shortcode";
                            code = code.Remove(0, 1);
                            where = "[shortcode]='" + code + "'";
                        }

                        product = ProductDAO.Product_GetDynamic(where, string.Empty).FirstOrDefault();

                        if (product == null)
                        {
                            MessageBox.Show("No product found for this " + type, "POSsible: Message");
                            txtBarcode.Text = string.Empty;
                            cmbItem.Focus();
                            return;
                        }
                        else
                            product.name += " [" + product.UnitMeasureName + "]";
                    }

                    if (product.ticketType.Value)
                    {
                        
                        if (!AddingFromList)
                        {
                            frmWeightTaker frmWT = new frmWeightTaker(this);
                            frmWT.ShowDialog();
                            qty = Convert.ToDouble(string.Format("{0:###0.00}", weight));
                        }
                    }

                    for (int i = 0; i < dgvItem.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dgvItem.Rows[i].Cells["ItemId"].Value.ToString()) == product.productId)
                        {
                            double currQty = Convert.ToDouble(dgvItem.Rows[i].Cells["qty"].Value.ToString());
                            qty += currQty;
                            rowIndex = i;
                            //if (!AddingFromList)
                            //{
                            uPrice = Convert.ToDouble(dgvItem.Rows[i].Cells["price"].Value);
                            uDisc = Convert.ToDouble(dgvItem.Rows[i].Cells["discount"].Value);
                            //}
                            dgvItem.Rows.RemoveAt(i);
                        }
                    }

                    double stockQty = Convert.ToDouble(string.Format("{0:###0.00}", (oTransactionDAO.ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + product.productId + ")"))));
                    if (qty > stockQty)
                    {
                        MessageBox.Show("Not enough quantity in stock \nProduct Available : " + stockQty, "POSsible");
                        AddingFromList = false;
                        ProductFromList = new Product();
                        return;
                    }


                    if (uPrice == 0 && uDisc == 0)
                    {
                        if (product.madeIn == "Fixed")
                        {
                            uPrice = Convert.ToDouble(string.Format("{0:##0.00}", product.unitCost));
                            if (rbRetail.Checked) uDisc = 0;
                            else if (rbWS.Checked) uDisc = Convert.ToDouble(string.Format("{0:##0.00}", (product.unitCost - product.unitPrice)));
                            else if (rbSpecial.Checked) uDisc = Convert.ToDouble(string.Format("{0:##0.00}", (product.unitCost - product.promoUnitPrice)));
                        }
                        else
                        {
                            Transaction trn = new Transaction();

                            if (product.qtyInStock == 0)
                            {
                                trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + product.productId, "").LastOrDefault();
                                if (trn == null)
                                {
                                    MessageBox.Show("No quantity in stock", "POSsible");
                                    AddingFromList = false;
                                    ProductFromList = new Product();
                                    return;
                                }
                            }
                            else if (product.qtyInStock > 0)
                            {
                                trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + product.productId + ", " + product.qtyInStock + ")", "").LastOrDefault();

                                if (trn == null)
                                {
                                    MessageBox.Show("No quantity in stock", "POSsible");
                                    AddingFromList = false;
                                    ProductFromList = new Product();
                                    return;
                                }

                                if (trn.ProductId == product.qtyInStock)
                                    trn.UnitPrice = trn.UnitPrice * (double)product.qtyInOrder;
                            }
                            else if (product.qtyInStock == -3)
                            {
                                trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + product.productId + ", (SELECT [productId] FROM [tblProduct] WHERE [qtyInStock]=" + product.productId + "))", "").LastOrDefault();

                                if (trn == null)
                                {
                                    MessageBox.Show("No quantity in stock", "POSsible");
                                    AddingFromList = false;
                                    ProductFromList = new Product();
                                    return;
                                }

                                if (trn.ProductId != product.productId)
                                {
                                    double pcsPerCrtn = oTransactionDAO.ExecuteScalar("SELECT [qtyInOrder] FROM [tblProduct] WHERE [productId]=" + trn.ProductId);
                                    trn.UnitPrice = trn.UnitPrice / pcsPerCrtn;
                                }
                            }

                            double wsPrice = (trn.UnitPrice + product.unitPrice.Value);
                            double spPrice = (trn.UnitPrice + product.promoUnitPrice.Value);
                            uPrice = (trn.UnitPrice + product.unitCost.Value);

                            if (rbRetail.Checked) uDisc = 0;
                            else if (rbWS.Checked) uDisc = (uPrice - wsPrice);
                            else if (rbSpecial.Checked) uDisc = (uPrice - spPrice);
                        }
                    }

                    dgvItem.Rows.Insert(rowIndex, product.name, (string.Format("{0:###0.00}", qty)), (string.Format("{0:##0.00}", uPrice)),
                        (string.Format("{0:###0.00}", qty)) + " " + product.UnitMeasureName + "@" + (string.Format("{0:##0.00}", uPrice)),
                        string.Format("{0:##0.00}", uPrice * qty), product.productId, product.categorytId, uDisc, product.qtyInStock, product.qtyInOrder);

                    if (product.ProductImage != null)
                    {
                        MemoryStream memory = new MemoryStream(product.ProductImage);
                        picBxImageDisplay.Image = Image.FromStream(memory);
                    }
                    else
                    {
                        picBxImageDisplay.Image = null;
                        picBxImageDisplay.Invalidate();
                    }

                    txtBarcode.Clear();
                    cmbItem.Focus();
                    frm_refresh();
                    cmbItem.SelectedIndex = -1;
                    cmbItem.Text = string.Empty;
                    txtSaleQty.Clear();
                    txtUnitPrice.Clear();
                    txtUnitDisc.Clear();
                    AddingFromList = false;
                    ProductFromList = new Product();
                    lblStockQty.Text = lblWP.Text = lblSP.Text = lblPurPrice.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nCould not add product", "POSsible");
            }
        }

        private void dgvItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvItem.FirstDisplayedScrollingRowIndex = dgvItem.RowCount - 1;
            dgvItem.Rows[dgvItem.RowCount - 1].Selected = true;
            if (dgvItem.Rows.Count > 0)
            {
                groupBox1.Enabled = false;
                btnNewCustomer.Enabled = false;
                cmbCustomer.Enabled = true;
            }
        }

        private void btnNoSale_Click(object sender, EventArgs e)
        {
            try
            {
                POSsible.Controllers.SalesManager salesmanager = new POSsible.Controllers.SalesManager();
                salesmanager.updateNoSale(oUserLogin);

                CPrinter printer = new CPrinter();
                printer.openChashDrawer();
            }
            catch (Exception excp)
            {
                MessageBox.Show("Got some problem", "RITPOS : Alert");
            }
        }

        private void btnPrintLast_Click(object sender, EventArgs e)
        {
            CInvoice lastInvoice = new CInvoice();
            POSsible.Controllers.SalesManager salesmanager = new POSsible.Controllers.SalesManager();
            try
            {
                lastInvoice = salesmanager.getLastInvoice();
                lastInvoice.UserName = oUserLogin.UserName;
                CPrinter printer = new CPrinter();
                printer.printbill(lastInvoice);

                MessageBox.Show("Printing Last Invoice ...", "RITPOS: Print");
            }
            catch (Exception excp)
            {
                MessageBox.Show("Got some problem", "RITPOS: Alert");
            }
        }

        private void btnDayEnd_Click(object sender, EventArgs e)
        {
            try
            {
                CPrinter printer = new CPrinter();
                printer.printendEndoftheDay();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Sorry, An Error ocurred !");
            }
        }

        private void btnKeyPadKey_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (btnClicked.Text == ".")
            {
                string sTotalValue = txtAmount.Text.ToString();
                int n = sTotalValue.IndexOf(".");
                if (n == -1)
                {
                    txtAmount.Text += ".";
                }
            }
            else
            {
                string sText = txtAmount.Text.Trim();
                if (sText.Length > 1)
                {
                    txtAmount.Text += btnClicked.Text.Trim();
                }
                else if (sText.Equals("0"))
                {
                    txtAmount.Text = btnClicked.Text.Trim();
                }
                else
                    txtAmount.Text += btnClicked.Text.Trim();
            }
        }

        private void btnBankNote_Click(object sender, EventArgs e)
        {
            Button btnBankNoteCliked = (Button)sender;
            if (txtBarcode.Text == "")
                txtBarcode.Text = "0";
            txtBarcode.Text = Convert.ToString(Convert.ToDouble(txtBarcode.Text) + Convert.ToDouble(btnBankNoteCliked.Tag));
            calculateforPaymentDisplay();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarcode.Text.Trim() == "") txtBarcode.Text = "0";
                if (Convert.ToDouble(txtBarcode.Text.Trim()) > 0 && Convert.ToDouble(txtBarcode.Text.Trim()) < Convert.ToDouble(lblTotalValue.Text.Trim()))
                    //lblDisplayCardAmountValue.Text = Convert.ToString(Convert.ToDouble(lblTotalValue.Text) - Convert.ToDouble(lblDisplayCashAmountValue.Text));
                    txtCardAmountValue.Text = string.Format("{0:###0.00}", (Convert.ToDouble(lblTotalValue.Text.Trim()) - Convert.ToDouble(txtCashAmountValue.Text.Trim())));
                else if (Convert.ToDouble(txtBarcode.Text) == 0)
                    txtCardAmountValue.Text = string.Format("{0:###0.00}", Convert.ToDouble(lblTotalValue.Text.Trim()));


            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message + "Sorry, An Error ocurred !");
            }
        }

        private void btnMeatlookup_Click(object sender, EventArgs e)
        {
            Button catName = (Button)sender;

            frmItemLookUp o_meatLookup = new frmItemLookUp(this, catName.Text);
            o_meatLookup.ShowDialog();
            frm_refresh();
        }

        private void btnFishLookup_Click(object sender, EventArgs e)
        {
            Button catName = (Button)sender;

            frmItemLookUp o_fishlookup = new frmItemLookUp(this, catName.Text);
            o_fishlookup.ShowDialog();
            frm_refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            gotoProductSelect("BACK");
            pnlCreditDisplay.Visible = false;
            pnlPaymentDisplay.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            AddMode(true);
            cmbItem.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.IndexOf('.') != -1) //if there is NOT no '.' in the string
            {
                createandlistNonListedProduct();
                txtBarcode.Text = "";
                cmbItem.Focus();
            }
            else
            {
                KeyEventArgs key = new KeyEventArgs(Keys.Enter);
                this.txtBarcode_KeyDown(sender, key);
            }

        }

        #region Public Methods
        /// <summary>
        /// method used to maintain logoff situation after End of shift
        /// </summary>
        /// <param name="sender"></param>
        public void logoffOnShiftEnd(object sender)
        {
            //EventArgs e = new EventArgs();
            //this.btnLogOff_Click(sender, e);
        }
        /// <summary>
        /// Perform the authorised actions
        /// </summary>
        /// <param name="authUser"></param>
        /// <param name="action"></param>
        public void doAuthorisedAction(CUser authUser, string action)
        {
            try
            {
                switch (action)
                {
                    case "refund":
                        frmRefund oFrmRefund = new frmRefund();
                        oFrmRefund.Show();
                        break;
                    case "InstantDiscount":
                        POSsible.Controllers.SalesManager salesmanagerForDiscount = new POSsible.Controllers.SalesManager();
                        DataSet dsGlobalDiscount = salesmanagerForDiscount.getDiscountInfo("InstantDiscount");
                        oInvoice.DisCountAuthorizedId = authUser.UserID;
                        //oInvoice.DiscountGiven += oInvoice.TotalPrice * Convert.ToDouble(dsGlobalDiscount.Tables[0].Rows[0]["InstantDiscount"]) / 100;
                        //oInvoice.DiscountGiven += Convert.ToDouble(dsGlobalDiscount.Tables[0].Rows[0]["InstantDiscount"]) / 100;
                        dtotalDiscount += Convert.ToDouble(dsGlobalDiscount.Tables[0].Rows[0]["InstantDiscount"]) / 100;

                        break;
                    case "FuelDiscount":
                        POSsible.Controllers.SalesManager salesmanagerForFuelDiscount = new POSsible.Controllers.SalesManager();
                        DataSet dsGlobalFuelDiscount = salesmanagerForFuelDiscount.getDiscountInfo("FuelDiscount");
                        oInvoice.DisCountAuthorizedId = authUser.UserID;
                        //oInvoice.DiscountGiven += oInvoice.TotalPrice * Convert.ToDouble(dsGlobalFuelDiscount.Tables[0].Rows[0]["FuelDiscount"]) / 100;
                        //oInvoice.DiscountGiven += Convert.ToDouble(dsGlobalFuelDiscount.Tables[0].Rows[0]["FuelDiscount"]) / 100;
                        dtotalDiscount += Convert.ToDouble(dsGlobalFuelDiscount.Tables[0].Rows[0]["FuelDiscount"]) / 100;

                        break;
                    default:
                        break;
                }
            }
            catch (Exception xcp)
            {

            }

        }
        /// <summary>
        /// updateting Customer Screen for differnt state
        /// </summary>
        /// <param name="stateMsg"></param>

        /// <summary>
        /// Method to check shift start and end and enable disable controls accordingly
        /// </summary>
        public void CheckShiftStartEnd()
        {

            if (this.btnStartShift.Text.Equals("START SHIFT"))
            {
                this.btnAmericanExpress.Enabled = false;
                this.btnBankNoteBackSpace.Enabled = false;
                this.btnBankNoteClear.Enabled = false;
                this.btnFishLookup.Enabled = false;
                this.btnPrintLast1.Enabled = false;
                this.btnBankNoteSafeDrop.Enabled = false;
                this.btnCancelCurrent.Enabled = false;
                this.btnCancelSelected.Enabled = false;
                this.btnDot.Enabled = false;
                this.btnDoubleZero.Enabled = false;
                this.btnEftPos.Enabled = false;
                this.btnEight.Enabled = false;
                this.btnDayEnd.Enabled = true;
                this.btnFiftyNote.Enabled = false;
                this.btnFive.Enabled = false;
                this.btnFiveNote.Enabled = false;
                this.btnFour.Enabled = false;
                this.btnHundredNote.Enabled = false;
                this.btnCat5.Enabled = false;

                this.btnMasterCard.Enabled = false;
                this.btnNine.Enabled = false;
                this.btnNoSale.Enabled = false;
                this.btnOne.Enabled = false;
                this.btnOriginalBackSpace.Enabled = false;
                this.btnOriginalClear.Enabled = false;
                this.btnBack.Enabled = false;
                this.btnPrintPast2.Enabled = false;
                this.btnPrintPast2.Enabled = false;
                this.btnOriginalRefund.Enabled = false;
                this.btnOriginalSafeDrop.Enabled = false;
                this.btnOthers.Enabled = false;
                this.btnPrintPast1.Enabled = false;
                this.btnProcess.Enabled = false;

                this.btnSeven.Enabled = false;
                this.btnSix.Enabled = false;
                this.btnTenNote.Enabled = false;
                this.btnThree.Enabled = false;
                this.btnTotal.Enabled = false;
                this.btnTwentyNote.Enabled = false;
                this.btnTwo.Enabled = false;
                this.btnVisa.Enabled = false;
                this.btnZero.Enabled = false;
                this.btnPrintLast2.Enabled = false;
                this.lblItem.Enabled = false;
                this.txtNoOfItems.Enabled = false;
                this.lblTotal.Enabled = false;
                this.lblTotalValue.Enabled = false;
                this.dgvItem.Enabled = false;
                this.txtBarcode.Enabled = false;
                this.btnEnter.Enabled = false;
                this.btnDayEnd.Enabled = false;

                this.btnAllItems.Enabled = false;
                this.btnNewCustomer.Enabled = false;
                cmbCustomer.Enabled = true;
                this.label3.Enabled = false;
                groupBox1.Enabled = false;
                this.btnCreditCollection.Enabled = false;
                this.btnPPayment.Enabled = false;
                this.btnVegeLookupAtoZ.Enabled = false;
                this.btnFruitLookUpAtoZ.Enabled = false;
                this.btnMeatLookup.Enabled = false;
                btnPaymentVoucher.Enabled = false;
                btnPurchase.Enabled = false;
                AddMode(false);
            }
            else
            {
                this.btnAmericanExpress.Enabled = true;
                this.btnBankNoteBackSpace.Enabled = true;
                this.btnBankNoteClear.Enabled = true;
                //this.btnFishLookup.Enabled = true;
                //this.btnPrintLast1.Enabled = true;
                //this.btnBankNoteSafeDrop.Enabled = true;
                this.btnCancelCurrent.Enabled = true;
                this.btnCancelSelected.Enabled = true;
                this.btnDot.Enabled = true;
                this.btnDoubleZero.Enabled = true;
                this.btnEftPos.Enabled = true;
                this.btnEight.Enabled = true;
                this.btnDayEnd.Enabled = false;
                this.btnFiftyNote.Enabled = true;
                this.btnFive.Enabled = true;
                this.btnFiveNote.Enabled = true;
                this.btnFour.Enabled = true;
                //this.btnFruitLookUpAtoZ.Enabled = true;
                this.btnHundredNote.Enabled = true;

                this.btnMasterCard.Enabled = true;
                this.btnNine.Enabled = true;
                //this.btnNoSale.Enabled = true;
                this.btnOne.Enabled = true;
                this.btnOriginalBackSpace.Enabled = true;
                this.btnOriginalClear.Enabled = true;
                this.btnBack.Enabled = true;
                //this.btnPrintPast2.Enabled = true;
                //this.btnPrintPast2.Enabled = true;
                this.btnOriginalRefund.Enabled = true;
                this.btnOriginalSafeDrop.Enabled = true;
                this.btnOthers.Enabled = true;
                //this.btnPrintPast1.Enabled = true;
                this.btnProcess.Enabled = true;

                this.btnSeven.Enabled = true;
                this.btnSix.Enabled = true;
                this.btnTenNote.Enabled = true;
                this.btnThree.Enabled = true;
                this.btnTotal.Enabled = true;
                this.btnTwentyNote.Enabled = true;
                this.btnTwo.Enabled = true;
                //this.btnVegeLookupAtoZ.Enabled = true;
                this.btnVisa.Enabled = true;
                this.btnZero.Enabled = true;
                //this.btnMeatLookup.Enabled = true;
                //this.btnPrintLast2.Enabled = true;
                this.lblItem.Enabled = true;
                this.txtNoOfItems.Enabled = true;
                this.lblTotal.Enabled = true;
                this.lblTotalValue.Enabled = true;
                this.dgvItem.Enabled = true;
                this.txtBarcode.Enabled = true;
                this.cmbItem.Focus();
                this.btnEnter.Enabled = true;
                //this.btnDayEnd.Enabled = true;

                this.btnAllItems.Enabled = true;
                this.cmbCustomer.Enabled = btnNewCustomer.Enabled = true;
                this.label3.Enabled = true;
                groupBox1.Enabled = true;
                this.btnCreditCollection.Enabled = true;
                this.btnPPayment.Enabled = true;
                btnPaymentVoucher.Enabled = true;
                btnPurchase.Enabled = true;
                AddMode(true);
            }
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
                int iCheck = Int32.Parse(strValToCheck);
                bRetVal = true;
            }
            catch
            {
                bRetVal = false;
            }
            return bRetVal;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Method is utilized to implement logic to find the amount
        /// of change that customer should be returned.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private double changeToGive(double amount)
        {
            string stramount;
            int lastdigit;
            double damount;
            double iamount;
            double ramount = 0;
            int mod;
            stramount = string.Format("{0:$###0.00}", amount);
            lastdigit = Convert.ToInt16(stramount.Substring(stramount.Length - 1, 1));
            Math.DivRem(lastdigit, 5, out mod);

            damount = Convert.ToDouble(".0" + mod);
            iamount = Convert.ToDouble(".0" + (5 - mod));
            switch (mod)
            {
                case 0:
                case 1:
                case 2:
                    ramount = amount - damount;
                    break;
                case 3:
                case 4:
                    ramount = amount + iamount;
                    break;

            }
            return ramount;
        }

        /// <summary>
        /// Method to calculate change and others
        /// </summary>
        private void calculateforPaymentDisplay()
        {
            txtCashAmountValue.Text = txtAmount.Text;
            double amt = (string.IsNullOrEmpty(txtCashNetAmt.Text)) ? 0 : Convert.ToDouble(txtCashNetAmt.Text);
            double givenAmt = (string.IsNullOrEmpty(txtAmount.Text)) ? 0 : Convert.ToDouble(txtAmount.Text);
            double dis = (string.IsNullOrEmpty(txtDiscount.Text)) ? 0 : Convert.ToDouble(txtDiscount.Text);
            double change = changeToGive(amt - dis - givenAmt);
            if (change >= 0)
            {
                txtCashChangeValue.Text = "0";
            }
            else
            {
                txtCashChangeValue.Text = change.ToString();
            }
        }

        /// <summary>
        /// Method to manage set resetting controls for Process and Back button action 
        /// </summary>
        /// <param name="strState"></param>
        private void gotoProductSelect(string strState)
        {
            if (strState == "BACK")
            {
                pnlLeftBottomOriginal.Visible = true;
                pnlOriginalForm.Visible = true;
                pnlOriginalForm.Enabled = true;
                pnlLeftBottomOriginal.Enabled = true;

                pnlBankNote.Visible = false;
                pnlBankNote.Enabled = false;

                pnlLeftBottomBankNote.Visible = false;
                pnlLeftBottomBankNote.Enabled = false;

                // btnEnter.Visible = true;
                txtBarcode.Visible = true;
                txtAmount.Visible = false;
                txtAmount.Clear();

                bCashCardClick = false;
                bCashChangeClick = false;
                bTotalBtn = false;

                //Payment display Portion
                pnlPaymentDisplay.Enabled = false;
                pnlPaymentDisplay.Visible = false;

                txtBarcode.TextAlign = HorizontalAlignment.Left;
                txtBarcode.Text = "";
                lblTotalValue.Text = string.Format("{0:###0.00}", dTotalValue);

                //if (m_loginfrmRef.o_screen2 != null)
                //    m_loginfrmRef.o_screen2.lblTotalValue.Text = lblTotalValue.Text;
            }
            else if (strState == "PROCESS")
            {
                txtBarcode.Text = "0".ToString();
                pnlLeftBottomOriginal.Visible = true;
                pnlOriginalForm.Visible = true;
                pnlOriginalForm.Enabled = true;
                pnlLeftBottomOriginal.Enabled = true;

                pnlBankNote.Visible = false;
                pnlBankNote.Enabled = false;

                pnlLeftBottomBankNote.Visible = false;
                pnlLeftBottomBankNote.Enabled = false;

                //btnEnter.Visible = true;

                bCashCardClick = false;
                bCashChangeClick = false;
                bTotalBtn = false;

                //Payment display Portion
                pnlPaymentDisplay.Enabled = false;
                pnlPaymentDisplay.Visible = false;


                txtBarcode.TextAlign = HorizontalAlignment.Left;
                lblTotalValue.Text = "";
                txtNoOfItems.Text = "";
                txtBarcode.Text = "";
                txtAmount.Clear();
                txtAmount.Visible = false;
                txtBarcode.Visible = true;
                dTotalValue = 0.00;
                iItemCount = 0;
                dtotalDiscount = 0.00;
                picBxImageDisplay.Image = null;
                picBxImageDisplay.Invalidate();
                dgvItem.Rows.Clear();


                oInvoice = null;
                cmbCustomer.SelectedIndex = -1; cmbSalesman.SelectedIndex = -1;
                txtDiscount.Clear();
                txtSpDiscount.Clear();
                groupBox1.Visible = true;
                txtTotalAmt.Clear();
                pnlCreditDisplay.Visible = false;
                AddMode(true);
                cmbCustomer.Focus();
            }
            txtSpDiscount.ReadOnly = true;
        }

        /// <summary>
        /// Non listed product creation
        /// </summary>
        private void createandlistNonListedProduct()
        {
            try
            {
                POSsible.Controllers.ProductManager productmanager = new POSsible.Controllers.ProductManager();
                CProduct nonscanproduct = new CProduct();

                frmNonScanItemInfo ofrmNonScanItemInfo = new frmNonScanItemInfo(this, nonscanproduct);
                ofrmNonScanItemInfo.ShowDialog();

                if ((nonscanproduct.ProductName == string.Empty) || (nonscanproduct.ProductName == null))
                {
                    return;
                }

                //nonscanproduct.ProductName = "Non Scan Item";
                nonscanproduct.getNonScanId();  //Get the barcode
                nonscanproduct.ShortCode = "Anonymous";
                nonscanproduct.ProductBrand = "Anonymous";

                //nonscanproduct.DepartmentId = 11;
                nonscanproduct.UnitMeasureId = 3;

                nonscanproduct.EnteredBy = MDIParent.userId;
                nonscanproduct.ProductDescription = "Non Scan Item";
                nonscanproduct.UnitPrice = Convert.ToDouble(txtBarcode.Text);
                nonscanproduct.UnitCost = Convert.ToDouble(txtBarcode.Text);
                nonscanproduct.QtyInStock = 1;
                nonscanproduct.MinQty = 1;
                nonscanproduct.ProductWeight = 0;
                nonscanproduct.IsGstItem = false;
                nonscanproduct.IsExpirable = false;
                nonscanproduct.Ticket = false;

                int retval = productmanager.addItem(nonscanproduct);

                if (retval != 0)
                {
                    MessageBox.Show("Error occured product entry ");
                }
                else
                {
                    dgvItem.Rows.Add(nonscanproduct.ProductName, "1Each@" + nonscanproduct.UnitPrice, string.Format("{0:###0.00}", nonscanproduct.UnitPrice), nonscanproduct.ProductId);
                    txtNoOfItems.Text = dgvItem.Rows.Count.ToString();
                    iItemCount = int.Parse(txtNoOfItems.Text);
                    lblTotalValue.Text = string.Format("{0:###0.00}", (Convert.ToDouble(lblTotalValue.Text == "" ? "0.00" : lblTotalValue.Text) + nonscanproduct.UnitPrice));
                    dTotalValue = Convert.ToDouble(lblTotalValue.Text);
                }

            }
            catch (Exception xcp)
            {
                MessageBox.Show("An Error occured");
            }

        }
        #endregion

        private void btnup_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count != 0)
            {
                if (irow != 0)
                {
                    dgvItem.FirstDisplayedScrollingRowIndex = irow - 1;
                    dgvItem.Rows[irow - 1].Selected = true;
                    irow = irow - 1;
                }
                else
                {
                    dgvItem.Rows[0].Selected = true;
                }

                int id = int.Parse(dgvItem.Rows[irow].Cells["ItemId"].Value.ToString());
                Product P = ProductDAO.Product_GetById(id);
                byte[] imgRaw = P.ProductImage;

                if (imgRaw != null)
                {
                    MemoryStream memory = new MemoryStream(imgRaw);
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                    this.picBxImageDisplay.Image = Image.FromStream(memory);
                }
                else
                {
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                }

            }
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count != 0)
            {
                if (irow != dgvItem.Rows.Count - 1)
                {
                    dgvItem.FirstDisplayedScrollingRowIndex = irow + 1;
                    dgvItem.Rows[irow + 1].Selected = true;
                    irow = irow + 1;
                }
                else
                {
                    dgvItem.Rows[dgvItem.Rows.Count - 1].Selected = true;
                }

                //POSsible.Controllers.IProductManager _ProductManager = new POSsible.Controllers.ProductManager(this);
                //byte[] imgRaw = _ProductManager.getImageByProductId(int.Parse(dgvItem.Rows[irow].Cells["ItemId"].Value.ToString()));
                int id = int.Parse(dgvItem.Rows[irow].Cells["ItemId"].Value.ToString());
                Product P = ProductDAO.Product_GetById(id);
                byte[] imgRaw = P.ProductImage;
                if (imgRaw != null)
                {
                    MemoryStream memory = new MemoryStream(imgRaw);
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                    this.picBxImageDisplay.Image = Image.FromStream(memory);
                }
                else
                {
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                }

            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //dgvItem.Focus();

            if (e.KeyCode == Keys.PageDown)
            {
                if (dgvItem.Rows.Count != 0)
                {
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                    if (irow != dgvItem.Rows.Count - 1)
                    {
                        dgvItem.FirstDisplayedScrollingRowIndex = irow + 1;
                        dgvItem.Rows[irow + 1].Selected = true;
                        irow = irow + 1;
                    }
                    else
                    {
                        dgvItem.Rows[dgvItem.Rows.Count - 1].Selected = true;
                    }
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                if (dgvItem.Rows.Count != 0)
                {
                    picBxImageDisplay.Image = null;
                    picBxImageDisplay.Invalidate();
                    if (irow != 0)
                    {
                        dgvItem.FirstDisplayedScrollingRowIndex = irow - 1;
                        dgvItem.Rows[irow - 1].Selected = true;
                        irow = irow - 1;
                    }
                    else
                    {
                        dgvItem.Rows[0].Selected = true;
                    }
                }
            }
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
            lblDate.Text = dtSaleDate.Value.ToString("dddd, dd MMM yyyy");
            lblTime.Text = "Time: " + GetTime();
        }

        #region Print Invoice or Report

        private void PrintInvoice(string sInvoiceID)
        {
            ShowReport("ritpos_invoice_print", sInvoiceID);
        }

        public void ShowReport(string sProcedureName, string sInvoiceID)
        {
            //try
            //{

            //    DataSet Ds = new DataSet();
            //    Ds = getSalesInfo(sProcedureName, sInvoiceID);

            //    if (Ds.Tables[0].Rows.Count > 0)
            //    {
            //        POSsible.Reports.frmReportViewer objView = new POSsible.Reports.frmReportViewer();

            //        POSsible.Reports.CrysInvoice oRpt = new POSsible.Reports.CrysInvoice();



            //        oRpt.SetDataSource(Ds.Tables[0]);
            //        objView.CRV.ReportSource = oRpt;

            //        objView.CRV.PrintReport();

            //        //.PrintToPrinter(1, true, 0, 0);
            //        //reportDocument1.SetParameterValue("@Company_Code", "''");
            //        //reportDocument1.SetParameterValue("@RO", ro);

            //        //crystalReportViewer1.ReportSource = reportDocument1;
            //        //crystalReportViewer1.PrintReport();
            //        //reportDocument1.PrintOptions.PrinterName = "";
            //        //reportDocument1.PrintToPrinter(1, true, 1, 1);

            //        objView.CRV.DisplayGroupTree = false;
            //        objView.CRV.Zoom(100);
            //        objView.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("There is no data for Invoice");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public DataSet getSalesInfo(string sProcedureName, string sInvoiceID)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            System.Data.SqlClient.SqlParameter[] parms = Microsoft.ApplicationBlocks.Data.SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), sProcedureName);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new System.Data.SqlClient.SqlParameter[] 
                    {
                        new System.Data.SqlClient.SqlParameter("IID", SqlDbType.NVarChar)
                    };

                // Store the parameters in the cache.
                Microsoft.ApplicationBlocks.Data.SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), sProcedureName, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.

            parms[0].Value = sInvoiceID;

            // Execute the SQL statement.
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, sProcedureName, parms);
        }

        #endregion

        private void btnAllItems_Click(object sender, EventArgs e)
        {
            Button catName = (Button)sender;
            frmItemLookUp oFrmItem = new frmItemLookUp(this, catName.Text);
            oFrmItem.ShowDialog();

            frm_refresh();
        }

        private void PrintText()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintReceipt); //add an event handler that will do the printing

                //string pName = ConfigurationManager.AppSettings["ThermalPrinterName"];

                //printDocument.PrinterSettings.PrinterName = pName;
                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
                printDocument.Print();
                //DialogResult result = printDialog.ShowDialog();

                //if (result == DialogResult.OK)
                //{
                //    printDocument.Print();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "\nCould not Print. Sale Saved.", "Message");
            }

        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Store store = new StoreDAO().Store_GetById(MDIParent.storeId);
            Company com = new CompanyDAO().Company_GetAll().FirstOrDefault();
            Invoice InvoiceEntity = new InvoiceDAO().Invoice_GetById(resultInvoiceAdd);
            string cusName = (cmbCustomer.SelectedIndex < 0) ? "General Customer" : cmbCustomer.Text;
            cusName = (cmbCustomer.SelectedIndex > -1 && !string.IsNullOrEmpty(cusMobNo)) ? cusName + " (" + cusMobNo + ")" : cusName;

            Graphics graphics = e.Graphics;
            Font font10 = new Font("Lekton", 8);
            Font font12 = new Font("Lekton", 10);
            Font font14 = new Font("Lekton", 13);

            float leading = 4;
            float lineheight10 = font10.GetHeight() + leading;
            float lineheight12 = font12.GetHeight() + leading;
            float lineheight14 = font14.GetHeight() + leading;

            float startX = 0;
            float startY = leading;
            float Offset = 0;

            StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatCenter = new StringFormat(formatLeft);
            StringFormat formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            SizeF layoutSize = new SizeF(284 - Offset * 2, lineheight14);
            RectangleF layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            Brush brush = new SolidBrush(Color.Black);

            graphics.DrawString(com.CompanyName, font14, brush, layout, formatCenter);
            Offset = Offset + lineheight14;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString(store.StoreName, font12, brush, layout, formatCenter);
            Offset = Offset + lineheight12;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString(store.StoreAddress, font10, brush, layout, formatCenter);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Tel:" + store.PhoneNo + ", Email:" + store.Email, font10, brush, layout, formatCenter);
            Offset = Offset + lineheight10 - 10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("".PadRight(44, '_'), font10, brush, layout, formatLeft);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Invoice # ".PadRight(12) + InvoiceEntity.InvoiceNo, font12, brush, layout, formatLeft);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Customer: ".PadRight(10) + cusName, font12, brush, layout, formatLeft);
            Offset = Offset + lineheight12;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Cashier: ".PadRight(12) + MDIParent.userName, font12, brush, layout, formatLeft);
            Offset = Offset + lineheight12;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Date: ".PadRight(14) + String.Format("{0:dd-MMM-yyyy hh:mm tt}", InvoiceEntity.invoiceDate), font12, brush, layout, formatLeft);
            Offset = Offset + lineheight10 - 5;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("".PadRight(44, '_'), font10, brush, layout, formatLeft);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Description                                        Rate               Value", font10, new SolidBrush(Color.Black), layout, formatLeft);
            Offset = Offset + lineheight10;

            Font font = new Font("Lekton", 8, FontStyle.Regular);
            float fontHeight = font.GetHeight();
            List<InvoiceProduct> lst = new InvoiceProductDAO().InvoiceProduct_GetDynamic("[invoiceId]='" + resultInvoiceAdd + "'", "");
            double total = 0;
            int itemSpace = 186;
            bool multiline = false;
            foreach (InvoiceProduct item in lst)
            {
                int productNameLength = item.productName.Length;
                string productDescription = item.productName;
                if (multiline) itemSpace += 15;
                multiline = false;
                if (productNameLength > 34)
                {
                    productDescription = productDescription.Insert(32, Convert.ToString((Char)0x0A));
                    productDescription = productDescription.Insert(33, "   -");
                    multiline = true;
                }
                string productTotal = Convert.ToDouble(item.qty).ToString();
                double unitPrice = Convert.ToDouble(item.unitPrice);
                double productPrice = unitPrice * Convert.ToDouble(item.qty);
                total += productPrice;

                string QtyPrice = String.Format("{00:00.00}", productTotal) + "@" + String.Format("{00:00.00}", unitPrice);

                graphics.DrawString(productDescription, font, new SolidBrush(Color.Black), startX, itemSpace);
                graphics.DrawString(QtyPrice, font, new SolidBrush(Color.Black), 170, itemSpace);
                graphics.DrawString(String.Format("{00:0.00}", productPrice), font, new SolidBrush(Color.Black), 240, itemSpace);
                itemSpace += 15;
                Offset = Offset + (int)fontHeight + 5;
            }

            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 5);
            graphics.DrawString("TOTAL(EU):".PadLeft(26) + String.Format("{0:0.00}", total).PadLeft(30), new Font("Lekton", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX, itemSpace + 17);
            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 35);

            double totDiscount = Convert.ToDouble(InvoiceEntity.DiscountGiven);
            if (totDiscount > 0)
            {
                itemSpace += 3;
                graphics.DrawString("Discount:".PadLeft(29) + String.Format("{0:0.00}", totDiscount).PadLeft(51), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
                itemSpace += 15;
                graphics.DrawString("NET(EU):".PadLeft(28) + String.Format("{0:0.00}", total - totDiscount).PadLeft(49), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
                itemSpace += 15;
            }

            graphics.DrawString("CASH(EU):".PadLeft(29) + String.Format("{0:0.00}", InvoiceEntity.CashAmt + InvoiceEntity.changeGiven).PadLeft(47), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
            if (InvoiceEntity.CardAmt > 0)
            {
                itemSpace += 15;
                graphics.DrawString("CARD(EU):".PadLeft(29) + String.Format("{0:0.00}", InvoiceEntity.CardAmt).PadLeft(47), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
            }

            graphics.DrawString("                    BALANCE(EU):" + String.Format("{0:0.00}", InvoiceEntity.changeGiven).PadLeft(40), font, new SolidBrush(Color.Black), startX, itemSpace + 60);
            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 70);
            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 75);
            graphics.DrawString("Thank You for shopping with us, please come back soon", font, new SolidBrush(Color.Black), startX, itemSpace + 90);

            font10.Dispose(); font12.Dispose(); font14.Dispose();
        }

        private void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region POSsible Receipt

            List<InvoiceProduct> lst = oInvoiceProductDAO.InvoiceProduct_GetDynamic("[invoiceId]='" + resultInvoiceAdd + "'", "");
            Company com = new CompanyDAO().Company_GetAll().FirstOrDefault();

            Invoice InvoiceEntity = oInvoiceDAO.Invoice_GetById(resultInvoiceAdd);
            double totDiscount = Convert.ToDouble(InvoiceEntity.DiscountGiven);
            double cashAmt = Double.Parse(InvoiceEntity.CashAmt.ToString());
            double cardAmt = Double.Parse(InvoiceEntity.CardAmt.ToString());
            double total = 0;
            double change = Convert.ToDouble(InvoiceEntity.changeGiven);
            string cusName = (cmbCustomer.SelectedIndex < 0) ? "General Customer" : cmbCustomer.Text;
            cusName = (cmbCustomer.SelectedIndex > -1 && !string.IsNullOrEmpty(cusMobNo)) ? cusName + " (" + cusMobNo + ")" : cusName;

            Graphics graphic = e.Graphics;
            //Courier New
            Font font = new Font("Lekton", 8, FontStyle.Regular); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 0;
            int startY = 0;
            int offset = 40;

            string company = "### " + com.CompanyName + " ###\n";
            string store = MDIParent.StoreName;

            graphic.DrawString(company, new Font("Courier Sans New", 13), new SolidBrush(Color.Black), (115 - com.CompanyName.Length) / 2, startY);
            graphic.DrawString(store, new Font("Courier Sans New", 11), new SolidBrush(Color.Black), (210 - MDIParent.StoreName.Length) / 2, startY + 20);
            graphic.DrawString(store, new Font("Courier Sans New", 9), new SolidBrush(Color.Black), (210 - MDIParent.StoreName.Length) / 2, startY + 40);
            graphic.DrawString(store, new Font("Courier Sans New", 9), new SolidBrush(Color.Black), (210 - MDIParent.StoreName.Length) / 2, startY + 60);

            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 40);
            string top = "Invoice No.    ";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + 50);
            graphic.DrawString("|   " + invoiceNo, font, new SolidBrush(Color.Black), 100, startY + 50);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 60);
            graphic.DrawString("Customer Name  ", font, new SolidBrush(Color.Black), startX, startY + 70);
            graphic.DrawString("|   " + cusName, font, new SolidBrush(Color.Black), 100, startY + 70);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 80);
            graphic.DrawString("Cashier        ", font, new SolidBrush(Color.Black), startX, startY + 90);
            graphic.DrawString("|   " + MDIParent.userName, font, new SolidBrush(Color.Black), 100, startY + 90);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 100);
            graphic.DrawString("Date & Time    ", font, new SolidBrush(Color.Black), startX, startY + 110);
            graphic.DrawString("|   " + String.Format("{0:dd MM yyyy}", DateTime.Now.ToString()), font, new SolidBrush(Color.Black), 100, startY + 110);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 120);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 125);
            graphic.DrawString("Description", font, new SolidBrush(Color.Black), startX, startY + 135);
            graphic.DrawString("Qty.", font, new SolidBrush(Color.Black), 150, startY + 135);
            graphic.DrawString("Amount", font, new SolidBrush(Color.Black), 222, startY + 135);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + 145);


            offset = offset + (int)fontHeight + 5; //make the spacing consistent
            int itemSpace = 170;
            bool multiline = false;
            foreach (InvoiceProduct item in lst)
            {
                //create the string to print on the reciept
                int productNameLength = item.productName.Length;
                string productDescription = item.productName;
                if (multiline) itemSpace += 15;
                multiline = false;
                if (productNameLength > 24)
                {
                    //productDescription = productDescription.Remove(24);
                    productDescription = productDescription.Insert(22, Convert.ToString((Char)0x0A));
                    productDescription = productDescription.Insert(23, "     -");
                    multiline = true;
                    //productDescription += (Char)0x0A;
                }
                string productTotal = Convert.ToInt32(item.qty).ToString();
                double unitPrice = Convert.ToDouble(item.unitPrice);
                double productPrice = unitPrice * Convert.ToInt32(item.qty);
                total += productPrice;
                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);
                string QtyPrice = productTotal + " @ " + String.Format("{00:00.00}", unitPrice);
                string productLine = productDescription.PadRight(productDescription.Length + 1 - productDescription.Length) + QtyPrice.PadRight(10) + String.Format("{00:0.000}", productPrice).PadLeft(32 - QtyPrice.Length);

                graphic.DrawString(productDescription, font, new SolidBrush(Color.Black), startX, itemSpace);
                graphic.DrawString(QtyPrice, font, new SolidBrush(Color.Black), 140, itemSpace);
                graphic.DrawString(String.Format("{00:0.000}", productPrice), font, new SolidBrush(Color.Black), 235, itemSpace);
                //graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, itemSpace);
                itemSpace += 15;
                offset = offset + (int)fontHeight + 5; //make the spacing consistent
            }
            #endregion

            change = Convert.ToDouble(InvoiceEntity.changeGiven);

            //when we have drawn all of the items add the total
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 15);

            //offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("TOTAL(KD):".PadLeft(26) + String.Format("{0:0.000}", total).PadLeft(28), new Font("Lekton", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX, itemSpace + 30);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 45);

            //offset = offset + 30; //make some room so that the total stands out.
            if (!string.IsNullOrEmpty(txtDiscount.Text) && Convert.ToDouble(txtDiscount.Text) > 0)
            {
                itemSpace += 5;
                graphic.DrawString("Discount:".PadLeft(29) + String.Format("{0:0.000}", totDiscount).PadLeft(46), font, new SolidBrush(Color.Black), startX, itemSpace + 55);
                itemSpace += 15;
                graphic.DrawString("NET(KD):".PadLeft(29) + String.Format("{0:0.000}", total - totDiscount).PadLeft(44), font, new SolidBrush(Color.Black), startX, itemSpace + 55);
            }
            if (itemSpace == 205) itemSpace += 15;
            graphic.DrawString("CASH(KD):".PadLeft(29) + String.Format("{0:0.000}", cashAmt).PadLeft(42), font, new SolidBrush(Color.Black), startX, itemSpace + 55);
            if (cardAmt > 0)
            {
                itemSpace += 15;
                graphic.DrawString("CARD(KD):".PadLeft(29) + String.Format("{0:0.000}", cardAmt).PadLeft(40), font, new SolidBrush(Color.Black), startX, itemSpace + 55);
            }

            graphic.DrawString("                    BALANCE(KD):" + String.Format("{0:0.000}", change).PadLeft(32), font, new SolidBrush(Color.Black), startX, itemSpace + 70);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 80);
            graphic.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 85);

            graphic.DrawString("     Thank You for Shopping With Us.", font, new SolidBrush(Color.Black), startX, itemSpace + 105);

            graphic.DrawString("         Please come back soon!", font, new SolidBrush(Color.Black), startX, itemSpace + 125);

            graphic.DrawString("   ", font, new SolidBrush(Color.Black), startX, itemSpace + 135);

        }

        public void getWeight(string sData)
        {
            weight = double.Parse(sData);
            isThereADot = 1;
        }

        public void addRow(int itemId, double qty, string UOMName, string pType, int categoryId)
        {
            int rowCount = dgvItem.Rows.Count;
            Product PE = ProductDAO.Product_GetById(itemId);
            double currDisc = 0;
            #region X
            //string where = "[EndDate] > dbo.TrimTime('" + DateTime.Now + "') AND ([PromoOnType] = 'Product' AND [PromoOnId] =" + itemId + ")";
            //ProductPromotion PP = new ProductPromotionDAO().ProductPromotion_GetDynamic(where, "").FirstOrDefault();

            //if (PP != null)
            //{
            //    if (PP.PromoChargeType == "Fixed")
            //    {
            //        PE.unitPrice = Convert.ToDouble(PP.Price);
            //    }
            //    else if (PP.PromoChargeType == "Percentage")
            //    {
            //        PE.unitPrice = Convert.ToDouble(PE.unitPrice) * (Convert.ToDouble(100 - PP.Percentage) / 100);
            //    }
            //    else
            //    { //FREE
            //        if (PP.SaleQty <= qty)
            //        {
            //            //ADD PRODUCT
            //            double freeQty = Math.Floor(qty / Convert.ToDouble(PP.SaleQty));
            //            freeQty = Convert.ToDouble(PP.FreeQty) * freeQty;
            //            addRow(Convert.ToInt32(PP.FreeTypeId), freeQty, "FREE", "FREE", 0);
            //        }

            //    }
            //}
            //if (PP == null)
            //{
            //    where = "[EndDate] > dbo.TrimTime('" + DateTime.Now + "') AND  ( [PromoOnType] = 'Category' AND [PromoOnId] =" + categoryId + ")";
            //    PP = new ProductPromotionDAO().ProductPromotion_GetDynamic(where, "").FirstOrDefault();
            //}
            #endregion

            #region PROMOTION
            if (pType == "FREE")
            {
                PE.unitPrice = 0.00;
                PE.categorytId = 0;
                for (int i = 0; i < dgvItem.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvItem.Rows[i].Cells["ItemId"].Value.ToString()) == itemId)
                    {
                        string[] qtyPrice = Regex.Split(dgvItem.Rows[i].Cells["quantity"].Value.ToString(), " ");
                        string[] freeCheck = Regex.Split(qtyPrice[1], "@");
                        if (freeCheck[0] == "FREE")
                        {
                            //int currentQty = Int32.Parse(qtyPrice[0]);
                            dgvItem.Rows.RemoveAt(i);
                            rowCount = i;
                            //qty += currentQty;
                        }
                    }
                }
            }
            #endregion

            else
            {
                for (int i = 0; i < dgvItem.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvItem.Rows[i].Cells["ItemId"].Value.ToString()) == itemId)
                    {
                        string[] qtyPrice = Regex.Split(dgvItem.Rows[i].Cells["quantity"].Value.ToString(), " ");
                        string[] freeCheck = Regex.Split(qtyPrice[1], "@");
                        if (freeCheck[0] != "FREE") //UOM
                        {
                            double currentQty = Double.Parse(qtyPrice[0]);
                            currDisc = Convert.ToDouble(dgvItem.Rows[i].Cells["discount"].Value);
                            dgvItem.Rows.RemoveAt(i);
                            rowCount = i;
                            qty += currentQty;
                        }
                    }
                }
            }

            double price = 0; double disc = 0;
            if (rbWS.Checked)
            {
                price = PE.unitPrice.Value;
                disc = PE.unitCost.Value - PE.unitPrice.Value + currDisc;
            }
            else if (rbSpecial.Checked)
            {
                price = PE.promoUnitPrice.Value;
                disc = PE.unitCost.Value - PE.promoUnitPrice.Value + currDisc;
            }

            qty = Convert.ToDouble(String.Format("{00:00.00}", qty));
            PE.unitCost = Convert.ToDouble(String.Format("{00:00.00}", PE.unitCost));

            if (PE != null)
            {
                if (pType == "FREE")
                {
                    if (PE.qtyInStock == -3 && PE.ticketType.Value)
                    {
                        dgvItem.Rows.Insert(rowCount, PE.name + " (" + UOMName + ")", qty, string.Format("{0:##0.00}", PE.unitCost), qty + " " + UOMName + "@" + PE.unitCost,
                        string.Format("{0:##0.00}", PE.unitCost * qty), PE.productId, PE.categorytId, 0);
                    }
                    else
                    {
                        dgvItem.Rows.Insert(rowCount, PE.name, qty, string.Format("{0:##0.00}", PE.unitCost), qty + " " + UOMName + "@" + PE.unitCost,
                        string.Format("{0:##0.00}", PE.unitCost * qty), PE.productId, PE.categorytId, 0);
                    }
                }
                else
                {
                    if (PE.qtyInStock == -3 && PE.ticketType.Value)
                    {
                        dgvItem.Rows.Insert(rowCount, PE.name + " (" + UOMName + ")", qty, string.Format("{0:##0.00}", PE.unitCost), qty + " " + UOMName + "@" + PE.unitCost,
                        string.Format("{0:##0.00}", PE.unitCost * qty), PE.productId, PE.categorytId, disc);
                    }
                    else
                    {
                        dgvItem.Rows.Insert(rowCount, PE.name, qty, string.Format("{0:##0.00}", PE.unitCost), qty + " " + UOMName + "@" + PE.unitCost,
                        string.Format("{0:##0.00}", PE.unitCost * qty), PE.productId, PE.categorytId, disc);
                    }
                }
            }

        }

        private void cmbCustomerBind()
        {
            List<tblCustomer> lstCustomer = new CustomerDAO().Customer_GetAll();
            if (lstCustomer.Count > 0)
            {
                cmbCustomer.DataSource = lstCustomer;
                cmbCustomer.SelectedIndex = -1;
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex < 0 || !loadDone) return;

            int cusId = Convert.ToInt32(cmbCustomer.SelectedValue);
            tblCustomer CEntity = new CustomerDAO().Customer_GetById(cusId);
            if (CEntity.workphone == "Special")
            {
                groupBox2.Visible = true;
                txtCreditPrevBalance.Text = CEntity.DueBalance.ToString();
                txtCreditBalance.Text = (999999999 - CEntity.DueBalance).ToString();
                txtCreditNewBalance.Text = (CEntity.DueBalance).ToString();
                lblCrFigure.Text = "999999999";

                if (CEntity.country == "General")
                    rbRetail.Checked = true;
                else if (CEntity.country == "Wholesale")
                    rbWS.Checked = true;
                else if (CEntity.country == "Special")
                    rbSpecial.Checked = true;

                Defaulter = oTransactionDAO.ExecuteScalarInt("SELECT dbo.[CustomerDueDays](" + cusId + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')");

                if (Defaulter > 0)
                {
                    MessageBox.Show("Credit Sale not allowed for " + CEntity.Name + " as he is a defaulter.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rbCash.Checked = true;
                    rbCredit.Enabled = false;
                }
                else
                    rbCredit.Enabled = true;

            }
            else
            {
                groupBox2.Visible = true;
                txtCreditPrevBalance.Text = CEntity.DueBalance.ToString();
                rbCredit.Checked = true;
                //rbWS.Visible = false;
                //rbSpecial.Visible = false;
                rbRetail.Checked = true;
            }
            cusMobNo = CEntity.mobile;
            cusName = cmbCustomer.Text;

            
            try
            {
                cmbSalesman.SelectedValue = Convert.ToInt32(CEntity.postcode);
            }
            catch
            {
                
            }

            txtInvoiceNo.Text = GetInvoiceNo();
            cmbItem.Focus();
        }

        private string GetInvoiceNo()
        {
            string smanShort = cmbSalesman.Text.Split('-')[1].Trim();
            string qry = "SELECT ('" + smanShort + "-' + CAST((ISNULL(MAX(CAST(SUBSTRING(InvoiceNo,4,10) AS INT)), 0) + 1) AS VARCHAR(8))) FROM dbo.tblInvoice WHERE YEAR(invoiceDate) = YEAR(GETDATE()) AND InvoiceNo LIKE '" + smanShort + "-%'";
            string invNo = new TransactionDAO().ExecuteScalarString(qry);
            return invNo;
        }

        private void dgvItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvItem.Rows.Count > 0)
                return;
            else
            {
                groupBox1.Enabled = true;
                cmbCustomer.Enabled = btnNewCustomer.Enabled = true;
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float payAmt = (string.IsNullOrEmpty(txtAmount.Text)) ? 0 : float.Parse(txtAmount.Text);
                float discount = ((string.IsNullOrEmpty(txtDiscount.Text)) ? 0 : float.Parse(txtDiscount.Text)) + ((string.IsNullOrEmpty(txtSpDiscount.Text)) ? 0 : float.Parse(txtSpDiscount.Text));
                float cardAmount = string.IsNullOrEmpty(txtCardAmountValue.Text) ? 0 : float.Parse(txtCardAmountValue.Text);
                float TAmount = float.Parse(txtTotalAmt.Text);
                float NAmount = TAmount - discount;
                txtCashNetAmt.Text = String.Format("{0:##0.00}", NAmount);
                txtCreditNetAmt.Text = String.Format("{0:##0.00}", NAmount);
                if (NAmount < 0)
                {
                    MessageBox.Show("Discount can't be more than total Amount.", "POSsible");
                    //txtDiscount.Clear();
                    return;
                }
                if (NAmount - cardAmount < 0)
                {
                    MessageBox.Show("You can't charge more than the Total Amount.", "POSsible");
                    txtCardAmountValue.Focus();
                    //txtCardAmountValue.Text = String.Format("{0:##0.00}", NAmount);
                    return;
                }

                if (rbCash.Checked)
                {
                    if (!string.IsNullOrEmpty(txtAmount.Text))// && payAmt >= NAmount)
                    {
                        float cashAmount = NAmount - cardAmount;
                        float changeAmount = payAmt - cashAmount;
                        txtCashAmountValue.Text = String.Format("{0:##0.00}", cashAmount);
                        //txtCardAmountValue.Text = cardAmount.ToString();
                        txtCashChangeValue.Text = String.Format("{0:##0.00}", changeAmount);
                    }
                    else
                    {
                        if (sender != null)
                        {
                            TextBox txt = (TextBox)sender;
                            if (txt.Name == "txtCardAmountValue")
                            {
                                txtCashAmountValue.Text = (string.IsNullOrEmpty(txtCashAmountValue.Text) ? 0 : Convert.ToDouble(txtCashAmountValue.Text) + 0).ToString();
                                txtCashChangeValue.Text = (string.IsNullOrEmpty(txtCashChangeValue.Text) ? 0 : Convert.ToDouble(txtCashChangeValue.Text) + 0).ToString();
                                return;
                            }
                            txtCashAmountValue.Clear();
                            txtCashChangeValue.Clear();
                            txtCardAmountValue.Clear();
                        }
                    }
                }
                else
                {
                    double crdtPrevBal = string.IsNullOrEmpty(txtCreditPrevBalance.Text.Trim()) ? 0 : Convert.ToDouble(txtCreditPrevBalance.Text);
                    txtCreditNewBalance.Text = String.Format("{0:##0.00}", (crdtPrevBal + NAmount));
                }

            }
            catch (Exception ex)
            {
                if (!groupBox1.Visible)
                    MessageBox.Show("Error Occured in Payment." + ex.Message, "POSsible");
            }
        }

        private void rbCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCredit.Checked)
            {
                txtAmount.Visible = false;
                lblCrFigure.Visible = false;
                lblCrtLimit.Visible = false;
                chkShowRP.Visible = true;
            }
            else
            {
                txtAmount.Visible = true;
                lblCrFigure.Visible = false;
                lblCrtLimit.Visible = false;
                chkShowRP.Visible = false;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtAmount.Text);
            if (e.KeyChar == (Char)Keys.Enter)
                btnProcess.PerformClick();
            else if (e.KeyChar == (Char)Keys.B)
                btnBack.PerformClick();
        }

        private void txtCardAmountValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtCardAmountValue.Text);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtDiscount.Text);
        }

        //private bool updateList()
        //{
        //    //offerEffect = false;
        //    int rowCount = dgvItem.Rows.Count;
        //    if (rowCount < 1)
        //        return offerEffect;

        //    foreach (DataGridViewRow item in dgvItem.Rows)
        //    {
        //        if (Convert.ToInt32(item.Cells["categoryId"].Value) == 0)
        //        {
        //            dgvItem.Rows.Remove(item);
        //        }
        //    }

        //    string where = "[EndDate] > dbo.TrimTime('" + DateTime.Now + "')";
        //    List<ProductPromotion> PPlist = new ProductPromotionDAO().ProductPromotion_GetDynamic(where, "");
        //    if (PPlist.Count > 0)
        //    {
        //        List<ProductPromotion> PPlistC = PPlist.Where(x => x.PromoOnType == "Category").ToList();
        //        #region Category
        //        if (PPlistC.Count > 0)
        //        {
        //            foreach (ProductPromotion item in PPlistC)
        //            {
        //                if (item.PromoChargeType == "Percentage")
        //                {
        //                    foreach (DataGridViewRow row in dgvItem.Rows)
        //                    {
        //                        int catId = Convert.ToInt32(row.Cells["categoryId"].Value);
        //                        if (catId == item.PromoOnId)
        //                        {
        //                            //Price Update in Row
        //                            int index = row.Index;
        //                            string[] qtyPrice = Regex.Split(row.Cells["quantity"].Value.ToString(), " ");
        //                            string[] umPrice = Regex.Split(qtyPrice[1], "@");
        //                            double qty = Convert.ToInt32(qtyPrice[0]);
        //                            double uPrice = Convert.ToDouble(qtyPrice[1]);
        //                            double newPrice = uPrice - Convert.ToDouble(uPrice * (item.Percentage / 100));

        //                            double price = Convert.ToDouble(row.Cells["price"].Value);
        //                            double disc = Convert.ToDouble(row.Cells["discount"].Value);
        //                            double dedtc = Convert.ToDouble(price * (item.Percentage / 100));
        //                            double nprice = price - dedtc;
        //                            double ndisc = disc == 0 ? 0 : disc - dedtc;

        //                            dgvItem.Rows[index].Cells["quantity"].Value = Convert.ToString(qty + " " + umPrice[0] + "@" + newPrice.ToString());
        //                            dgvItem.Rows[index].Cells["subtotal"].Value = (newPrice * qty).ToString();
        //                            dgvItem.Rows[index].Cells["price"].Value = nprice.ToString();
        //                            dgvItem.Rows[index].Cells["discount"].Value = ndisc.ToString();
        //                            offerEffect = true;
        //                        }
        //                    }
        //                }
        //                else if (item.PromoChargeType == "Free")
        //                {
        //                    double catQtyCount = 0;

        //                    foreach (DataGridViewRow row in dgvItem.Rows)
        //                    {
        //                        int catId = Convert.ToInt32(row.Cells["categoryId"].Value);
        //                        if (catId == item.PromoOnId)
        //                        {
        //                            string[] qtyPrice = Regex.Split(row.Cells["quantity"].Value.ToString(), " ");
        //                            //string[] freeCheck = Regex.Split(qtyPrice[1], "@");
        //                            double currentQty = Double.Parse(qtyPrice[0]);
        //                            catQtyCount += currentQty;
        //                            offerEffect = true;
        //                        }
        //                    }

        //                    if (catQtyCount >= item.SaleQty)
        //                    {
        //                        //ADD PRODUCT
        //                        double freeQty = Math.Floor(catQtyCount / Convert.ToDouble(item.SaleQty));
        //                        freeQty = Convert.ToDouble(item.FreeQty) * freeQty;
        //                        addRow(Convert.ToInt32(item.FreeTypeId), freeQty, "FREE", "FREE", 0);
        //                        offerEffect = true;
        //                    }


        //                }
        //            }
        //        }
        //        #endregion

        //        List<ProductPromotion> PPlistP = PPlist.Where(x => x.PromoOnType == "Product").ToList();
        //        #region Product
        //        if (PPlistP.Count > 0)
        //        {
        //            foreach (ProductPromotion item in PPlistP)
        //            {
        //                if (item.PromoChargeType == "Fixed")
        //                {
        //                    foreach (DataGridViewRow row in dgvItem.Rows)
        //                    {
        //                        int prodId = Convert.ToInt32(row.Cells["ItemId"].Value);
        //                        if (prodId == item.PromoOnId)
        //                        {
        //                            int index = row.Index;
        //                            string[] qtyPrice = Regex.Split(row.Cells["quantity"].Value.ToString(), " ");
        //                            string[] umPrice = Regex.Split(qtyPrice[1], "@");
        //                            double qty = Convert.ToInt32(qtyPrice[0]);
        //                            dgvItem.Rows[index].Cells["quantity"].Value = Convert.ToString(qty.ToString() + " " + umPrice[0] + "@" + item.Price.ToString());
        //                            dgvItem.Rows[index].Cells["subtotal"].Value = (item.Price * qty).ToString();
        //                            dgvItem.Rows[index].Cells["price"].Value = item.Price.ToString();
        //                            dgvItem.Rows[index].Cells["discount"].Value = "0";
        //                            offerEffect = true;
        //                        }
        //                    }
        //                }
        //                else if (item.PromoChargeType == "Percentage")
        //                {
        //                    foreach (DataGridViewRow row in dgvItem.Rows)
        //                    {
        //                        int prodId = Convert.ToInt32(row.Cells["ItemId"].Value);
        //                        if (prodId == item.PromoOnId)
        //                        {
        //                            //Update Row
        //                            int index = row.Index;
        //                            string[] qtyPrice = Regex.Split(row.Cells["quantity"].Value.ToString(), " ");
        //                            string[] umPrice = Regex.Split(qtyPrice[1], "@");
        //                            double qty = Convert.ToInt32(qtyPrice[0]);
        //                            double uPrice = Convert.ToDouble(qtyPrice[1]);
        //                            double newPrice = uPrice - Convert.ToDouble(uPrice * (item.Percentage / 100));

        //                            double price = Convert.ToDouble(row.Cells["price"].Value);
        //                            double disc = Convert.ToDouble(row.Cells["discount"].Value);
        //                            double dedtc = Convert.ToDouble(price * (item.Percentage / 100));
        //                            double nprice = price - dedtc;
        //                            double ndisc = disc == 0 ? 0 : disc - dedtc;

        //                            dgvItem.Rows[index].Cells["quantity"].Value = Convert.ToString(qty.ToString() + " " + umPrice[0] + "@" + newPrice.ToString());
        //                            dgvItem.Rows[index].Cells["subtotal"].Value = (newPrice * qty).ToString();
        //                            dgvItem.Rows[index].Cells["price"].Value = nprice.ToString();
        //                            dgvItem.Rows[index].Cells["discount"].Value = ndisc.ToString();
        //                            offerEffect = true;
        //                        }
        //                    }
        //                }
        //                else if (item.PromoChargeType == "Free")
        //                {
        //                    foreach (DataGridViewRow row in dgvItem.Rows)
        //                    {
        //                        int prodId = Convert.ToInt32(row.Cells["ItemId"].Value);
        //                        if (prodId == item.PromoOnId)
        //                        {
        //                            string[] qtyPrice = Regex.Split(row.Cells["quantity"].Value.ToString(), " ");
        //                            double currentQty = Double.Parse(qtyPrice[0]);
        //                            if (currentQty >= item.SaleQty)
        //                            {
        //                                //ADD PRODUCT
        //                                double freeQty = Math.Floor(currentQty / Convert.ToDouble(item.SaleQty));
        //                                freeQty = Convert.ToDouble(item.FreeQty) * freeQty;
        //                                addRow(Convert.ToInt32(item.FreeTypeId), freeQty, "FREE", "FREE", 0);
        //                                offerEffect = true;
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //        }
        //        #endregion

        //    }
        //    else
        //        offerEffect = false;

        //    frm_refresh();
        //    return offerEffect;
        //}

        private void btnCat5_Click(object sender, EventArgs e)
        {
            Button catName = (Button)sender;
            frmItemLookUp oFrmItem = new frmItemLookUp(this, catName.Text);
            oFrmItem.ShowDialog();
            frm_refresh();
        }

        private void btnCreditCollection_Click(object sender, EventArgs e)
        {
            frmCreditCollection CC = new frmCreditCollection();
            CC.Show();
        }

        private void btnPPayment_Click(object sender, EventArgs e)
        {
            frmPurchasePayment PPfrm = new frmPurchasePayment();
            PPfrm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (string.Equals((sender as Button).Name, @"CloseButton"))
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.btnStartShift.Text.Equals("END SHIFT"))
                {
                    MessageBox.Show("Exit the Application using the 'Log Off' Button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                    this.Dispose();
            }

        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmcustomerentry frm = new frmcustomerentry();
            frm.ControlBox = false;
            frmcustomerentry.FromSaleForm = true;
            frm.ShowDialog();

            if (frmcustomerentry.CusId > 0)
            {
                cmbCustomerBind();
                cmbCustomer.SelectedValue = frmcustomerentry.CusId;
            }
        }

        private void btnPaymentVoucher_Click(object sender, EventArgs e)
        {
            frmSaleEdit frm = new frmSaleEdit();
            frm.ShowDialog();
        }

        private void AddMode(bool mode)
        {
            cmbItem.Enabled = txtSaleQty.Enabled = txtUnitPrice.Enabled = txtUnitDisc.Enabled = btnAdd.Enabled = mode;
            cmbItem.SelectedIndex = -1;
            cmbItem.Text = string.Empty;
            txtSaleQty.Clear();
            txtUnitPrice.Clear();
            txtUnitDisc.Clear();
        }

        private void BindItem()
        {
            List<Product> lProductList = ProductDAO.Product_GetDynamic("1=1", "name");
            cmbItem.DataSource = lProductList;
            cmbItem.SelectedIndex = -1;
        }

        private void cmbItem_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex > -1 && loadDone && btnAdd.Enabled)
            {
                int productId = Convert.ToInt32(cmbItem.SelectedValue);
                int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
                ProductFromList = ProductDAO.Product_GetByIdAndCustomer(productId, customerId);

                double stockQty = Convert.ToDouble(string.Format("{0:###0.00}", (oTransactionDAO.ExecuteScalar("SELECT dbo.CurrentStockByStore(" + MDIParent.storeId + "," + ProductFromList.productId + ")"))));
                if (stockQty <= 0)
                {
                    MessageBox.Show("No quantity in stock", "POSsible");
                    return;
                }

                double uPrice = 0; double uDisc = 0; double wsPrice = 0; double spPrice = 0; Transaction trn = new Transaction();

                if (ProductFromList.qtyInStock == 0)
                {
                    trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId]=" + ProductFromList.productId, "").LastOrDefault();
                }
                else if (ProductFromList.qtyInStock > 0)
                {
                    trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + ProductFromList.productId + ", " + ProductFromList.qtyInStock + ")", "").LastOrDefault();

                    if (trn.ProductId == ProductFromList.qtyInStock)
                    {
                        trn.UnitPrice = trn.UnitPrice * (double)ProductFromList.qtyInOrder;
                    }
                }
                else if (ProductFromList.qtyInStock == -3)
                {
                    trn = oTransactionDAO.Transaction_GetDynamic("T.[TransType] IN (0, 1) AND ((T.[Quantity]-T.[UsedQty])>0) AND T.[StoreId]=" + MDIParent.storeId + " AND T.[productId] IN (" + ProductFromList.productId + ", (SELECT [productId] FROM [tblProduct] WHERE [qtyInStock]=" + ProductFromList.productId + "))", "").LastOrDefault();
                    if (trn != null && trn.ProductId != ProductFromList.productId)
                    {
                        double pcsPerCrtn = oTransactionDAO.ExecuteScalar("SELECT [qtyInOrder] FROM [tblProduct] WHERE [productId]=" + trn.ProductId);
                        trn.UnitPrice = trn.UnitPrice / pcsPerCrtn;
                    }
                }

                if (ProductFromList.madeIn == "Fixed")
                {
                    uPrice = ProductFromList.unitCost.Value;
                    wsPrice = ProductFromList.unitPrice.Value;
                    spPrice = ProductFromList.promoUnitPrice.Value;
                }
                else
                {
                    uPrice = (trn.UnitPrice + ProductFromList.unitCost.Value);
                    wsPrice = (trn.UnitPrice + ProductFromList.unitPrice.Value);
                    spPrice = (trn.UnitPrice + ProductFromList.promoUnitPrice.Value);
                }

                if (rbRetail.Checked) uDisc = 0;
                else if (rbWS.Checked) uDisc = (uPrice - wsPrice);
                else if (rbSpecial.Checked) uDisc = (uPrice - spPrice);

                DataTable dt = new PurchaseDAO().Purchase_GetPurchasePriceForSale(ProductFromList.productId);

                if (dt != null)
                    lblPurPrice.Text = dt.Rows[0][0].ToString();

                txtUnitPrice.Text = string.Format("{0:##0.00}", uPrice);
                txtUnitDisc.Text = string.Format("{0:##0.00}", uDisc);
                txtSaleQty.Text = "1";
                lblStockQty.Text = stockQty.ToString();
                lblWP.Text = wsPrice.ToString();
                lblSP.Text = spPrice.ToString();
                txtSaleQty.Focus();
            }
        }

        private void txtSaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtSaleQty.Text);
            if (e.KeyChar == 13)
                txtUnitPrice.Focus();
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtUnitPrice.Text);
            if (e.KeyChar == 13 && txtUnitDisc.Enabled)
                txtUnitDisc.Focus();
        }

        private void txtUnitDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtUnitDisc.Text);
            if (e.KeyChar == 13 && btnAdd.Enabled)
                btnAdd.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Helper.ValidateNotEmpty(new List<Control>() { cmbItem, txtSaleQty, txtUnitPrice, txtUnitDisc }))
            {
                if (!ProductFromList.ticketType.Value && txtSaleQty.Text.Contains('.'))
                {
                    MessageBox.Show("Fractional Quantity not allowed for Non Variable Weight Product", "POSsible");
                    txtSaleQty.Focus();
                    return;
                }
                if (Convert.ToDouble(txtUnitDisc.Text) > Convert.ToDouble(txtUnitPrice.Text))
                {
                    MessageBox.Show("Unit Discount cannot be more than Unit Price", "POSsible");
                    txtUnitDisc.Focus();
                    return;
                }

                AddingFromList = true;
                txtBarcode1_KeyDown(null, null);
                cmbItem.Focus();
            }
        }

        private void rbRetail_CheckedChanged(object sender, EventArgs e)
        {
            if (loadDone)
            {
                cmbItem.SelectedIndex = -1;
                cmbItem.Text = string.Empty;
                txtSaleQty.Clear();
                txtUnitPrice.Clear();
                txtUnitDisc.Clear();
                ProductFromList = new Product();
                cmbItem.Focus();
            }
        }

        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbItem.SelectedIndex > -1 && loadDone && btnAdd.Enabled && e.KeyChar == 13)
            {
                txtSaleQty.Focus();
            }
            else if (e.KeyChar == (char)(Keys.T))
            {
                btnTotal.PerformClick();
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();
            frm.ShowDialog();
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                if (e.KeyChar == (char)(Keys.T))
                {
                    btnTotal.PerformClick();
                }
                else if (cmbItem.Enabled && e.KeyChar == 13)
                {
                    cmbItem.Focus();
                }
            }
        }

        private void dtSaleDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbCustomer.Enabled && e.KeyChar == 13)
            {
                cmbCustomer.Focus();
            }
        }

        private void cmbCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbCustomer.SelectedIndex > -1 && loadDone && txtInvoiceNo.Enabled && e.KeyChar == 13)
            {
                txtSaleQty.Focus();
            }
        }

        private void txtSpDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.InputOnlyNumbers(sender, e, txtSpDiscount.Text);
        }

         

        //private void cmbSalesman_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbSalesman.SelectedIndex < 0 || !loadDone) return;
        //    txtInvoiceNo.Focus();
        //    cmbSalesman.SelectionLength = 0;
        //}
    }
}