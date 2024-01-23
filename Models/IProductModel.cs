using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;

namespace POSsible.Models
{
    #region IProductModel
    /// <summary>
    /// Data IProductModel Interface
    /// </summary>
    public interface IProductModel
    {
        /// <summary>
        /// Used to get the Productlist
        /// </summary>
        /// <param name="oProductList"></param>
        /// <returns></returns>
        CProduct getProductList(CProduct oProductList);

        /// <summary>
        /// Used to Entry the data into the database
        /// </summary>
        /// <param name="oProduct"></param>
        int addItem(CProduct oProduct);

        /// <summary>
        /// Used to delete the data from the database
        /// </summary>
        /// <param name="oProduct"></param>
        int deleteItem(CProduct oProduct);

        /// <summary>
        /// Used to update the database
        /// </summary>
        /// <param name="oProduct"></param>
        int updateItem(CProduct oProduct);

        /// <summary>
        /// used to get the Department List
        /// </summary>
        /// <returns></returns>
        DataSet getDepartmentList(int i);

        /// <summary>
        /// used to get the Measurement List
        /// </summary>
        /// <returns></returns>
        DataSet getUnitMeasurementList();

        /// <summary>
        /// Used to get the ItemList using the CategoryId
        /// </summary>
        /// <param name="iCategoryId"></param>
        /// <returns></returns>
        DataSet getItemlist(int iCategoryId);


        /// <summary>
        /// Used to get the ItemList using the CategoryId for particular Department or Name for All Product
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCategoryId"></param>
        /// <param name="sName"></param>
        /// <returns>DataSet</returns>
        DataSet getItemlistBy_Category_ItemName(int iStatus, int iCategoryId,string sName);

        /// <summary>
        /// Used to get the productList using the Product Id
        /// </summary>
        /// <param name="iProductId"></param>
        /// <returns></returns>
        DataSet getProductById(int iProductId);

        /// <summary>
        /// Used to get the ProductList 
        /// </summary>
        DataSet getProductListByDepartmentNBarcode(string sSearchText,int iDepartmentId);

        /// <summary>
        /// Used to get the ProductList 
        /// </summary>
        DataSet getProductListByDepartmentNName(string sSeachText, int iDepartmentId);

        /// <summary>
        /// Used to get the ProductList 
        /// </summary>
        DataSet getProductListByDepartmentNBrand(string sSearchText, int iDepartmentId);
        
        /// <summary>
        /// Used o get Product List By DepartmentId
        /// </summary>
        /// <param name="sCategory"></param>
        /// <returns></returns>
        DataSet getVegetableList(int iDepartmentId);

        /// <summary>
        /// Used o get Product List By DepartmentId
        /// </summary>
        /// <param name="sCategory"></param>
        /// <returns></returns>
        DataSet getFruitList(int iDepartmentId);

        /// <summary>
        /// Used to get ProductList by Barcode
        /// </summary>
        /// <param name="sBarcode"></param>
        /// <returns></returns>
         DataSet getProductListByBarcode(string sBarcode);

         /// <summary>
         /// Used to get list of all items
         /// </summary>
         /// <returns></returns>
         DataSet getAllItems();

         /// <summary>
         /// Used to get list of all items according to its ticket
         /// </summary>
         /// <returns></returns>
         DataSet getItemsByTicket(bool bTicket, int iCategoryId);

         /// <summary>
         /// Used to get Department wise gross net profit
         /// </summary>
         /// <returns></returns>
         DataSet getProfitByDepartment(int iDeptId, DateTime dFrom, DateTime dTo);

         int addPurchaseMain(DateTime dDeliveryDate, int iSupplierId, double dTotalCost, DateTime dEnteredAt, int iEnteredBy);
         void addPurchaseDetails(int iPurchaseId, int iProductId, int iQty, double dUnitPrice, DateTime dExpireDate);

         int addDamageMain(string sRemarks, DateTime dEnteredAt, int iEnteredBy);
         void addDamageDetails(int iDamageId, int iProductId, int iQty, double dUnitCost, string sDescription);

        
        
      }
    #endregion
}
