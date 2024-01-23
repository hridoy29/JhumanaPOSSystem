using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using POSsible.BusinessObjects;


namespace POSsible.Controllers
{
    public interface ICustomerInvoiceManager
    {
        List<CCustomerInvoice> getCustomerInvoiceList(string sCustomerBarcode);
        void updateCustomerInvoice(CCustomerInvoice oCCustomerInvoice);
        List<CCustomerInvoice> getCustomerPointClaimList();
        List<CCustomerInvoice> getCustomerPointClaimListSearch(int iSOption, string strSearchText);
        void createCustomerPointClaim(List<CCustomerInvoice> oCustomerInvoice);        
    }
}
