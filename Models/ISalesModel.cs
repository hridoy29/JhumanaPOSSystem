using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using POSsible.BusinessObjects;

namespace POSsible.Models
{
    public interface ISalesModel
    {
        /// <summary>
        /// Used to store the Shift Inforamtion into the Database
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="dStartMoney"></param>
        /// <returns></returns>
        int storeShiftInformation(CUser oUser, double dStartMoney);

        /// <summary>
        /// Used to update the login table after shift start
        /// </summary>
        /// <param name="oUser"></param>
        void updateTblLogin4StartShift(CUser oUser);

        /// <summary>
        /// Used to update the Shift informaton after shidt End
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="dEndMoney"></param>
        /// <returns></returns>
        int updateShiftInformation(CUser oUser, double dEndMoney);

        /// <summary>
        /// Used to Store SafeDrop information into the database
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="dAmount"></param>
        void storeSafeDropInformation(CUser oUser, double dAmount);

        /// <summary>
        /// Used to Create Invoice
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <returns></returns>
        int createInvoice(CInvoice oInvoice);

        /// <summary>
        /// Used To Create iInvoice Payment
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <param name="iInvoiceId"></param>
        void createInvoicePayment(CInvoice oInvoice, int iInvoiceId);

        /// <summary>
        /// Used To Create Invoice Product
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <param name="iInvoiceId"></param>
        void createInvoiceProduct(CInvoice oInvoice, int iInvoiceId);

        /// <summary>
        /// Used To Create Invoice Customer
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <param name="iInvoiceId"></param>
        void createCustomerInvoice(CInvoice oInvoice, int iInvoiceId);

        DataSet getInvoiceProductById(int iInvoiceId);
        DataSet getInvoiceById(int iInvoicId);
        DataSet getInvoicePaymentById(int iInvoiceId);
                

        //void bindRefundGrid(List<CInvoice> oLstInvoice);

        DataSet getInvoiceIdByDateTime(DateTime dtInvoiceDate, TimeSpan tsStartTime, TimeSpan tsEndTime);

        void createRefund(CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser);

        /// <summary>
        /// Used To store refund information
        /// </summary>
        /// <param name="List<CProduct> lstProducts"></param>
        /// <param name="CInvoice oInvoice"></param>
        /// <param name="CUser oLoginUser"></param>
        /// <param name="CUser oAuthorizedUser"></param>
        void storeRefund(List<CProduct> lstProducts, CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser);

        DataSet getDiscountInfo(string sDiscount);

        void updateNoSale(CUser loggedinuser);

        DataSet getLastInvoice();

        /// <summary>
        /// Gets the amount in drawer
        /// </summary>
        /// <param name="iShiftId"></param>
        /// <returns></returns>
        double getChashinDrawer(int iShiftId);
    }
}
