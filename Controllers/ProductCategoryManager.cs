using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using POSsible.Models;
using POSsible.Factories;
using POSsible.Views;


namespace POSsible.Controllers
{
    class ProductCategoryManager: IProductCategoryManager
    {
        private IProductCategoryModel _productCategoryModel;

        /// <summary>
        /// Reference to the ISupplierView
        /// </summary>
        private IProductCategoryView _productCategoryView;

        /// <summary>
        /// null constructor
        /// </summary>
        public ProductCategoryManager()
        {
            _productCategoryModel = Factory.GetProductCategoryModel();
        }

        /// <summary>
        /// Constructor to Supplier Manager for SupplierView
        /// </summary>
        /// <param name="_ReferenceForSupplierView"></param>
        public ProductCategoryManager(IProductCategoryView _ReferenceForProductCategoryView)
        {
            _productCategoryView = _ReferenceForProductCategoryView;
            _productCategoryModel = Factory.GetProductCategoryModel();
        }

        #region Implementation of IProductCategoryManager

        public CDepartment getProductCategoryId(int iProductCategory)
        {
            CDepartment oCDepartment = new CDepartment();

            
            try
            {
                SqlDataReader drProductCategory = _productCategoryModel.getProductCategoryById(iProductCategory);
                
                if(drProductCategory.Read())
                {
                    
                    oCDepartment.CategoryId = (int)drProductCategory["CategoryId"];
                    oCDepartment.DepartmentName = drProductCategory["deptName"].ToString();
                    oCDepartment.Description = drProductCategory["description"].ToString();

                    if (drProductCategory["ScanNonScanStatus"].ToString() == "0")
                    {
                        oCDepartment.ScanNonScanStatus = "Scan";
                    }
                    else if (drProductCategory["ScanNonScanStatus"].ToString() == "1")
                    {
                        oCDepartment.ScanNonScanStatus = "Non-Scan";
                    }

                    if (drProductCategory["EnteredTime"].ToString() != "")
                        oCDepartment.EnteredTime = DateTime.Parse(drProductCategory["EnteredTime"].ToString());
                    if (drProductCategory["EnteredBy"].ToString() != "")
                        oCDepartment.EnteredBy = Convert.ToString(drProductCategory["EnteredBy"]);
                    if (drProductCategory["UpdatedBy"].ToString() != "")
                        oCDepartment.UpdatedBy = Convert.ToString(drProductCategory["UpdatedBy"]);
                    if (drProductCategory["UpdatedTime"].ToString() != "")
                        oCDepartment.UpdatedTime = DateTime.Parse(drProductCategory["UpdatedTime"].ToString());
                    
                }
            }
            catch (Exception oEx)
            {
            }
            return oCDepartment;
        }

        /// <summary>
        /// Implementation of IProductCategoryManager.getSupplierList
        /// </summary>
        public List<CDepartment> getProductCategoryList(string sName)
        {
            List<CDepartment> lDepartmentList = new List<CDepartment>();
            DataSet dsProductCategory = new DataSet();

            try
            {
                //if (sName == "")
                    //dsProductCategory = _productCategoryModel.getSupplierList();
                //else
                    dsProductCategory = _productCategoryModel.getProductCategoryListLikeName(sName);

                foreach (DataRow drProductCategory in dsProductCategory.Tables[0].Rows)
                {
                    CDepartment oCDepartment = new CDepartment();

                    oCDepartment.CategoryId = (int)drProductCategory["CategoryId"];
                    oCDepartment.DepartmentName = drProductCategory["deptName"].ToString();
                    oCDepartment.Description = drProductCategory["description"].ToString();

                    if (drProductCategory["ScanNonScanStatus"].ToString() == "0")
                    {
                        oCDepartment.ScanNonScanStatus = "Scan";
                    }
                    else if (drProductCategory["ScanNonScanStatus"].ToString() == "1")
                    {
                        oCDepartment.ScanNonScanStatus = "Non-Scan";
                    }

                    //oCDepartment.ScanNonScanStatus = drProductCategory["SacnNoScanStatus"].ToString();
                    
                    if (drProductCategory["EnteredTime"].ToString() != "")
                        oCDepartment.EnteredTime = DateTime.Parse(drProductCategory["EnteredTime"].ToString());
                    if (drProductCategory["EnteredBy"].ToString() != "")
                        oCDepartment.EnteredBy = Convert.ToString(drProductCategory["EnteredBy"]);
                    if (drProductCategory["UpdatedBy"].ToString() != "")
                        oCDepartment.UpdatedBy = Convert.ToString(drProductCategory["UpdatedBy"]);
                    if (drProductCategory["UpdatedTime"].ToString() != "")
                        oCDepartment.UpdatedTime = DateTime.Parse(drProductCategory["UpdatedTime"].ToString());

                    lDepartmentList.Add(oCDepartment);
                }
            }
            catch (Exception oEx)
            {
            }
            return lDepartmentList;
        }

        //CDepartment getProductCategoryId(int iProductCategory)
        //{
 
        //}

        
        public int addProductCategory(CDepartment oCDepartment)
        {
            int iProductCategoryId = _productCategoryModel.addProductCategory(oCDepartment);
            _productCategoryView.Alert("Product Category added successfully.");
            return iProductCategoryId;
        }

        /// <summary>
        /// Implementation of IProductCategory.addProductCategory
        /// </summary>
        public int deleteProductCategory(CDepartment oCDepartment)
        {
            int returnval;
            returnval = _productCategoryModel.deleteProductCategory(oCDepartment);
            if (returnval != 547)
            {
                _productCategoryView.Alert("Product Category deleted successfully.");

            }
            else
            {
                _productCategoryView.Alert("You have no permission to delete this Product Category.");

            }
            return returnval;
        }

        public void updateProductCategory(CDepartment oCDepartment)
        {
            _productCategoryModel.updateProductCategory(oCDepartment);
            _productCategoryView.Alert("Product Category updated successfully.");
        }

        #endregion
    }
}
