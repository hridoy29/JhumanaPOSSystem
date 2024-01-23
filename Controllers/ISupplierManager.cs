using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using POSsible.BusinessObjects;

namespace POSsible.Controllers
{
    /// <summary>
    /// This is the interface of IProductManager the View will use to communicate 
    /// with the Controller object using a simple Call Back Pattern.
    /// </summary>
    public interface ISupplierManager
    {
        //Supplier getProductList(Product oProductList);
        List<Supplier> getSupplierList(string sName);
        Supplier getSupplierById(int iSupplierId);

        /// <summary>
        /// For Supplier entry Form
        /// </summary>
        int addSupplier(Supplier oSupplier);
        int deleteSupplier(Supplier oSupplier);
        void updateSupplier(Supplier oSupplier);
    }
}
