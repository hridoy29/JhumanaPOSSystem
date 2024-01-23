using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;
using System.Data;

namespace POSsible.Controllers
{
    public interface ISalesManager
    {
        /// <summary>
        /// Used to Store the Shift information
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="dStartMoney"></param>
        /// <returns></returns>
        int storeShiftInformation(CUser oUser,double dStartMoney);

        /// <summary>
        /// Used to Update the Shift Information
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="dAmount"></param>
        void updateShiftInformation(CUser oUser, double dAmount);

        /// <summary>
        /// Used to Store the SafeDrop Information
        /// </summary>
        /// <param name="oUser"></param>
        /// <param name="dAmount"></param>
        void storeSafeDropInformation(CUser oUser, double dAmount);

        /// <summary>
        /// Used to create Invoice
        /// </summary>
        /// <param name="oInvoice"></param>
        int createInvoice(CInvoice oInvoice);

        void getInvoiceProductById(int iInvoiceId);

        void getInvoiceIdByDateTime(DateTime dtInvoiceDate);

        void createRefund(CInvoice oInvoice,CUser oLoginUser,CUser oAuthorizedUser); // Not using

        void storeRefund(List<CProduct> lstProducts, CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser);

        DataSet getDiscountInfo(string sDiscount);

        void updateNoSale(CUser loggedInUser);

        CInvoice getLastInvoice();

        List<CInvoice> getInvoicesByDTdiff(DateTime dt, TimeSpan tFrom,TimeSpan tTo);

        /// <summary>
        /// Method to check if the amount to be transferred is less than or equal to 
        /// </summary>
        /// <param name="damountgiven"></param>
        /// <param name="iShiftId"></param>
        /// <returns></returns>
        bool checkChashinDrawer(double damountgiven,int iShiftId);
    }
}
