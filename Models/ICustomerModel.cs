using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace POSsible.Models
{
    public interface ICustomerModel
    {

        DataSet getCustomerList();
        DataSet getCustomerListLikeName(string sName);
        SqlDataReader getCustomerById(int iCustomerId);

        SqlDataReader getCustomerByBarCode(string iCustomerId);

        /// <summary>
        /// For Customer entry Form
        /// </summary>
        int addCustomer(Customer oCustomer);
        int deleteCustomer(Customer oCustomer);
        void updateCustomer(Customer oCustomer);
    }
}
