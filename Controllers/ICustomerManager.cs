using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace POSsible.Controllers
{
    public interface ICustomerManager
    {
        List<Customer> getCustomerList(string sName);
        Customer getCustomerById(int iCustomerId);
        Customer getCustomerByBarCode(string sCustomerBarCode);

        /// <summary>
        /// For Cutomer entry Form
        /// </summary>
        int addCustomer(Customer oCustomer);
        int deleteCustomer(Customer oCustomer);
        void updateCustomer(Customer oCustomer);
    }
}
