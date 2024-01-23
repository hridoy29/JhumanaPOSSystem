using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public interface ICustomerInvoiceModel
    {
        DataSet getInvoiceListByCustomer(string sCustomerBarcode);
        void updateCustomerInvoice(CCustomerInvoice oCCustomerInvoice);
        DataSet getCustomerClaimPointList();
        DataSet getCustomerClaimPointList(int iSOption, string strSearchText);
        void createCustomerClaimPoint(List<CCustomerInvoice> oCCustomerInvoice);        
    }
}
