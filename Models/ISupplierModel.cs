using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;

namespace POSsible.Models
{
    /// <summary>
    /// Data ISupplierModel Interface
    /// </summary>
    public interface ISupplierModel
    {           
        //Supplier getProductList(Product oProductList);
        DataSet getSupplierList();
        DataSet getSupplierListLikeName(string sName);
        SqlDataReader getSupplierById(int iSupplierId);

         /// <summary>
         /// For Supplier entry Form
         /// </summary>
        int addSupplier(Supplier oSupplier);
        int deleteSupplier(Supplier oSupplier);
        void updateSupplier(Supplier oSupplier);
    }
}
