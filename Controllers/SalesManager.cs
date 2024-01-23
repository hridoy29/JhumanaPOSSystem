using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;

namespace POSsible.Controllers
{
    public class SalesManager : ISalesManager
    {

        /// <summary>refernce to the IShiftStartView, passed in on 
        /// creation</summary>
        private POSsible.Views.IShiftStartView _ShiftStartView;


        /// <summary>refernce to the IShiftEndView, passed in on 
        /// creation</summary>
        private POSsible.Views.IShiftEndView _ShiftEndView;


        /// <summary>refernce to the ISafeFundView, passed in on 
        /// creation</summary>
        private POSsible.Views.ISafeFundView _SafeFundView;


        /// <summary>refernce to the IMainView, passed in on 
        /// creation</summary>
        private POSsible.Views.IMainView _MainView;

        /// <summary>refernce to the IRefundView, passed in on 
        /// creation</summary>
        private POSsible.Views.IRefundView _RefundView;

        


        /// <summary>
        /// reference to the ISalesModel, retrived 
        /// on creation from the factory
        /// </summary>
        private POSsible.Models.ISalesModel _SalesModel;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_ReferenceForShiftStartView"></param>
        public SalesManager()
        {
            _SalesModel = POSsible.Factories.Factory.GetSalesModel();
        }

        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForShiftStartView"></param>
        public SalesManager(POSsible.Views.IShiftStartView _ReferenceForShiftStartView)
        {
            _ShiftStartView = _ReferenceForShiftStartView;
            _SalesModel = POSsible.Factories.Factory.GetSalesModel();
        }


        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForShiftStartView"></param>
        public SalesManager(POSsible.Views.IShiftEndView _ReferenceForShiftEndView)
        {
            _ShiftEndView = _ReferenceForShiftEndView;
            _SalesModel = POSsible.Factories.Factory.GetSalesModel();
        }



        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForSafeFundView"></param>
        public SalesManager(POSsible.Views.ISafeFundView _ReferenceForSafeFundView)
        {
            _SafeFundView = _ReferenceForSafeFundView;
            _SalesModel = POSsible.Factories.Factory.GetSalesModel();
        }


        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForMainView"></param>
        public SalesManager(POSsible.Views.IMainView _ReferenceForMainView)
        {
            _MainView = _ReferenceForMainView;
            _SalesModel = POSsible.Factories.Factory.GetSalesModel();
        }




        public SalesManager(POSsible.Views.IRefundView _ReferenceForRefundView)
        {
            _RefundView = _ReferenceForRefundView;
            _SalesModel = POSsible.Factories.Factory.GetSalesModel();
        }

        #region ISalesManager Implementation

        /// <summary>
        /// Implementation of ISalesManager.storeShiftInformation
        /// </summary>
        /// <param name="oShift"></param>
        /// <returns></returns>
        public int storeShiftInformation(CUser oUser, double dStartMoney)
        {
            int iShiftId = _SalesModel.storeShiftInformation(oUser, dStartMoney);
            oUser.ShiftId = iShiftId;
            //_SalesModel.updateTblLogin4StartShift(oUser);
            return iShiftId;
        }


        /// <summary>
        /// Implementation of ISalesManager.updateShiftInformation
        /// </summary>
        /// <param name="oShift"></param>
        public void updateShiftInformation(CUser oUser, double dAmount)
        {
            try
            {
                int retval = _SalesModel.updateShiftInformation(oUser, dAmount);
                //if(retval==1)
                //    success
                //else
                //    unsuccess

            }
            catch(Exception xcp)
            {
            }
        }

        /// <summary>
        /// Method to check if the amount to be transferred is less than or equal to 
        /// </summary>
        /// <param name="damountgiven"></param>
        /// <param name="iShiftId"></param>
        /// <returns></returns>
        public bool checkChashinDrawer(double dAmountgiven,int iShiftId)
        {
            double dCashinDrawer;
            try
            {
                dCashinDrawer = _SalesModel.getChashinDrawer(iShiftId);
                if (dCashinDrawer >= dAmountgiven)
                    return true;
                //else if (dCashinDrawer == -1)
                //{
                //    throw new Exception("Error occured");
                //}
                else
                {
                    return false;
                }
            }
            catch (Exception oExcp)
            {
                //throw new Exception("Error occured");
                return false;
                
            }
        }
        /// <summary>
        /// Implementation of ISalesManager.storeSafeDropInformation
        /// </summary>
        /// <param name="oShift"></param>
        /// <param name="dtSafeDrop"></param>
        /// <param name="dAmount"></param>
        /// <param name="iShiftIdSafefund"></param>
        public void storeSafeDropInformation(CUser oUser, double dAmount)
        {
            try
            {
                _SalesModel.storeSafeDropInformation(oUser, dAmount);
            }
            catch (Exception oEx)
            {

            }
        }


        /// <summary>
        /// Implementation of ISalesManager.createInvoice
        /// </summary>
        /// <param name="oInvoice"></param>
        public int createInvoice(CInvoice oInvoice)
        {
            int iInvoiceId = 0;
            try
            {
                 iInvoiceId = _SalesModel.createInvoice(oInvoice);
                _SalesModel.createInvoicePayment(oInvoice, iInvoiceId);
                _SalesModel.createInvoiceProduct(oInvoice, iInvoiceId);

                if (oInvoice.CustomerBarCode.Trim().Length > 0)
                {
                    _SalesModel.createCustomerInvoice(oInvoice, iInvoiceId);
                }
            }
            catch (Exception oEx)
            {
                //iInvoiceId = 0;
            }
            return iInvoiceId;
        }

        public void getInvoiceProductById(int iInvoiceId)
        {
            //CInvoice oLstInvoice=new CInvoice();

            try
            {
                CInvoice oInvoice = new CInvoice();

                DataSet dsInvoice = _SalesModel.getInvoiceById(iInvoiceId);
                DataTable dtInvoice = dsInvoice.Tables[0];
                if (dtInvoice.Rows.Count > 0)
                {
                    DataRow drInvoice = dtInvoice.Rows[0];
                    // Let's fill the properties of invoice object

                    oInvoice.InvoiceId = int.Parse(drInvoice["invoiceId"].ToString());

                    if (drInvoice["Paymenttype"].ToString() != "")
                        oInvoice.PaymentType = int.Parse(drInvoice["Paymenttype"].ToString());

                    if (drInvoice["CardAmount"].ToString() != "")
                        oInvoice.CardAmount = double.Parse(drInvoice["CardAmount"].ToString());

                    if (drInvoice["CashAmount"].ToString() != "")
                        oInvoice.CashAmount = double.Parse(drInvoice["CashAmount"].ToString());

                    if (drInvoice["PaymentMethodId"].ToString() != "")
                        oInvoice.PaymentMethodId = int.Parse(drInvoice["PaymentMethodId"].ToString());

                    if (drInvoice["invoiceDate"].ToString() != "")
                        oInvoice.InvoiceDate = DateTime.Parse(drInvoice["invoiceDate"].ToString());

                    if (drInvoice["changeGiven"].ToString() != "")
                        oInvoice.ChangeGiven = double.Parse(drInvoice["changeGiven"].ToString());

                    if (drInvoice["customerId"].ToString() != "")
                        oInvoice.CustomerId = int.Parse(drInvoice["customerId"].ToString());

                    if (drInvoice["discountGiven"].ToString() != "")
                        oInvoice.DiscountGiven = double.Parse(drInvoice["discountGiven"].ToString());

                    if (drInvoice["DiscountAthorizedId"].ToString() != "")
                        oInvoice.DisCountAuthorizedId = int.Parse(drInvoice["DiscountAthorizedId"].ToString());

                    if (drInvoice["shiftId"].ToString() != "")
                        oInvoice.ShiftId = int.Parse(drInvoice["shiftId"].ToString());

                    oInvoice.Status = drInvoice["status"].ToString();
                    oInvoice.Description = drInvoice["description"].ToString();

                    //if (drInvoice["TotalGST"].ToString() != "")
                    //    oInvoice.TotalGst = int.Parse(drInvoice["TotalGST"].ToString());

                    if (drInvoice["TotalPrice"].ToString() != "")
                        oInvoice.TotalPrice = Convert.ToDouble(drInvoice["TotalPrice"]);

                    if (drInvoice["UserId"].ToString() != "")
                        oInvoice.UserId = int.Parse(drInvoice["UserId"].ToString());
                }

                dtInvoice.Clear();
                dsInvoice.Clear();
                dtInvoice.Dispose();
                dsInvoice.Dispose();

                DataSet dsProductList = _SalesModel.getInvoiceProductById(iInvoiceId);
                DataTable dtProductList = dsProductList.Tables[0];
                List<CProduct> lstProduct = new List<CProduct>();

                if (dtProductList.Rows.Count > 0)
                {
                    foreach (DataRow drProductList in dtProductList.Rows)
                    {
                        CProduct oProduct = new CProduct();

                        if (drProductList["productId"].ToString() != "")
                            oProduct.ProductId = Int32.Parse(drProductList["productId"].ToString());
                        if (drProductList["name"].ToString() != "")
                            oProduct.ProductName = drProductList["name"].ToString();
                        if (drProductList["qty"].ToString() != "")
                            oProduct.QtyInorder = Convert.ToDouble(drProductList["qty"].ToString());
                        if (drProductList["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProductList["unitPrice"].ToString());

                        lstProduct.Add(oProduct);
                    }
                }

                oInvoice.Product = lstProduct;
                _RefundView.bindRefundGrid(oInvoice);

                dtProductList.Clear();
                dsProductList.Clear();
                dtProductList.Dispose();
                dsProductList.Dispose();
            }
            catch (Exception oEx)
            {

            }
        }

        public void getInvoiceIdByDateTime(DateTime dtInvoiceDate)
        {
            List<CInvoice> oLstInvoice = new List<CInvoice>();
            try
            {
                TimeSpan tsStartTime = new TimeSpan(0, 0, 0);
                TimeSpan tsEndTime = new TimeSpan(23, 59, 59);

                DataSet dsInvoiceId = _SalesModel.getInvoiceIdByDateTime(dtInvoiceDate, tsStartTime, tsEndTime);
                DataTable dtInvoiceId = dsInvoiceId.Tables[0];

                if (dtInvoiceId.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInvoiceId.Rows.Count; i++)
                    {
                        DataRow drInvoiceId = dtInvoiceId.Rows[i];
                        CInvoice oInvoice = new CInvoice();
                        oInvoice.InvoiceId = Convert.ToInt16(drInvoiceId["invoiceId"]);

                        oLstInvoice.Add(oInvoice);
                    }
                }
                _RefundView.bindInvoiceCombo(oLstInvoice);
            }
            catch (Exception oEx)
            {

            }
        }

        public void createRefund(CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser)
        {
            try
            {
                _SalesModel.createRefund(oInvoice, oLoginUser, oAuthorizedUser);
            }
            catch (Exception oEx)
            { 
            
            }
        }

        public void storeRefund(List<CProduct> lstProducts, CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser)
        {
            try
            {
                _SalesModel.storeRefund(lstProducts, oInvoice, oLoginUser, oAuthorizedUser);
            }
            catch (Exception oEx)
            {

            }
        }

        public DataSet getDiscountInfo(string sDiscount)
        {
            DataSet dsDiscountAmount = new DataSet();
            try 
            {
                dsDiscountAmount = _SalesModel.getDiscountInfo(sDiscount);                
            }
            catch(Exception oEx)
            {

            }

            return dsDiscountAmount;
        }

        public void updateNoSale(CUser loggedInUser)
        {
            _SalesModel.updateNoSale(loggedInUser);
        }

        public CInvoice getLastInvoice()
        {
            CInvoice lastInvoice = new CInvoice();
            DataSet dsInvoice = _SalesModel.getLastInvoice();
            DataTable dtInvoice = dsInvoice.Tables[0];

            if (dtInvoice.Rows.Count > 0)
            {
                DataRow drInvoice = dtInvoice.Rows[0];

                if (drInvoice["InvoiceId"] != null)
                    lastInvoice.InvoiceId = (int)drInvoice["InvoiceId"];

                if (drInvoice["invoiceDate"] != null)
                    lastInvoice.InvoiceDate = Convert.ToDateTime(drInvoice["invoiceDate"]);

                if (drInvoice["TotalPrice"] != null)
                    lastInvoice.TotalPrice = Convert.ToDouble(drInvoice["TotalPrice"]);

                if (drInvoice["TotalGST"] != null)
                    lastInvoice.TotalGst = Convert.ToDouble(drInvoice["TotalGST"]);
                if (drInvoice["DiscountGiven"] != null)
                    lastInvoice.TotalGst = Convert.ToDouble(drInvoice["DiscountGiven"]);

                List<CProduct> productList = new List<CProduct>();

                foreach (DataRow row in dtInvoice.Rows)
                {
                    CProduct invoiceProduct = new CProduct();

                    if (row["ProductId"] != null)
                        invoiceProduct.ProductId = (int)row["ProductId"];
                    if (row["name"] != null)
                        invoiceProduct.ProductName = row["name"].ToString();
                    //if (row["isGstItem"] != null)
                    //    invoiceProduct.ProductName = "*" + invoiceProduct.ProductName;
                    if (row["qty"] != null)
                        invoiceProduct.QtyInorder = Convert.ToDouble(row["qty"]);

                    if (row["unitPrice"] != null)
                        invoiceProduct.UnitPrice = Convert.ToDouble(row["unitPrice"]);

                    if (row["UnitMeasureName"] != null)
                        invoiceProduct.UnitMeasure = row["UnitMeasureName"].ToString();

                    productList.Add(invoiceProduct);
                }

                lastInvoice.Product = productList;
                //DataSet dsInvoicePayment =_SalesModel.getInvoicePaymentById(lastInvoice.InvoiceId);

                if (drInvoice["Paymenttype"] != null)
                    lastInvoice.PaymentType = (int)drInvoice["Paymenttype"];

                if (drInvoice["CardAmount"] != null)
                    lastInvoice.CardAmount = Convert.ToDouble(drInvoice["CardAmount"]);

                if (drInvoice["CashAmount"] != null)
                    lastInvoice.CashAmount = Convert.ToDouble(drInvoice["CashAmount"]);
            }

            return lastInvoice;

        }

        public List<CInvoice> getInvoicesByDTdiff(DateTime dt, TimeSpan tFrom,TimeSpan tTo)
        {
            
            List<CInvoice> lstInvoices = new List<CInvoice>();
            DataSet dsInvoices = _SalesModel.getInvoiceIdByDateTime(dt,tFrom,tTo);

            foreach (DataRow row in dsInvoices.Tables[0].Rows)
            {
                CInvoice invoice = new CInvoice();
                invoice.InvoiceId = (int)row["InvoiceId"];
                invoice.InvoiceDate = Convert.ToDateTime(row["invoiceDate"]);
                invoice.TotalPrice = Convert.ToDouble(row["TotalPrice"]);
                invoice.TotalGst = Convert.ToDouble(row["TotalGST"]);
                
                invoice.PaymentType = (int)row["Paymenttype"];
                invoice.CardAmount = Convert.ToDouble(row["CardAmount"]);
                invoice.CashAmount = Convert.ToDouble(row["CashAmount"]);

                List<CProduct> lstProduct = new List<CProduct>();
                
                DataSet dsProduct = _SalesModel.getInvoiceProductById(invoice.InvoiceId);
                foreach (DataRow rowProduct in dsProduct.Tables[0].Rows)
                {
                    CProduct product = new CProduct();
                    product.ProductId = (int)rowProduct["ProductId"];
                    product.ProductName = rowProduct["name"].ToString();
                    product.QtyInorder = Convert.ToDouble(rowProduct["qty"]);
                    product.UnitPrice = Convert.ToDouble(rowProduct["unitPrice"]);
                    product.UnitMeasure = rowProduct["UnitMeasureName"].ToString();

                    lstProduct.Add(product);

                }

                invoice.Product = lstProduct;
                
                lstInvoices.Add(invoice); 
            }

            return lstInvoices;
        }
        
       #endregion
   }
    
}
