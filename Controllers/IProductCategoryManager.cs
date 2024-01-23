using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using POSsible.BusinessObjects;

namespace POSsible.Controllers
{
    /// <summary>
    /// This is the interface of IProduct Category Manager the View will use to communicate 
    /// with the Controller object using a simple Call Back Pattern.
    /// </summary>
    public interface IProductCategoryManager
    {
        //List<CDepartment> getProductCategoryList();
        List<CDepartment> getProductCategoryList(string sName);
        CDepartment getProductCategoryId(int iProductCategory);

        /// <summary>
        /// For Product Category entry Form
        /// </summary>
        int addProductCategory(CDepartment oCDepartment);
        int deleteProductCategory(CDepartment oCDepartment);
        void updateProductCategory(CDepartment oCDepartment);
    }
    
}
