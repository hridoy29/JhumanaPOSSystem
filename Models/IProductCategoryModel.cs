using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public interface IProductCategoryModel
    {
        //DataSet getProductCategoryList();
        DataSet getProductCategoryListLikeName(string sName);
        SqlDataReader getProductCategoryById(int iProductCategoryId);

        int addProductCategory(CDepartment oCDepartment);
        int deleteProductCategory(CDepartment oCDepartment);
        void updateProductCategory(CDepartment oCDepartment);
    }
}
