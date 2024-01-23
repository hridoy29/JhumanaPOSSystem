using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;


namespace POSsible.Controllers
{
    #region IProductManager
    /// <summary>
    /// This is the interface of IProductManager the View will use to communicate 
    /// with the Controller object using a simple Call Back Pattern.
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// Used to get the Product List and Display
        /// </summary>
        /// <param name="oProductList"></param>
        void  getProductList(CProduct oProductList);

        /// <summary>
        /// Used To get the Departmentlist and also display
        /// </summary>
        /// <returns></returns>
        void getDepartmentList(int iScanNonScanStatus);

        /// <summary>
        /// Used To get the Product Category List and also display
        /// </summary>
        /// <param name="iSacnNoScanStatus"></param>
        List<CDepartment> getProductCategoryList(int iScanNonScanStatus);

        /// <summary>
        /// Used To get the Unit Messurement List and also display
        /// </summary>
        /// <returns></returns>
        void getUnitMeasurementList();


        /// <summary>
        /// Used to entry the data into the database and clear the entry form
        /// </summary>
        /// <param name="oProduct"></param>
        int addItem(CProduct oProduct);

        /// <summary>
        /// Used to delete the data from the database and also from the grid
        /// </summary>
        /// <param name="oProduct"></param>
        int deleteItem(CProduct oProduct);

        /// <summary>
        /// Used to update the Data base using the ProductId
        /// Clear the Entry Form 
        /// </summary>
        /// <param name="oProduct"></param>
        int updateItem(CProduct oProduct);

        /// <summary>
        /// Used to get the Item List and fill up the data grid
        /// </summary>
        /// <param name="iCategoryId"></param>
        void getItemlist(int iCategoryId);

        /// <summary>
        /// Used to get the ProductList By ProductId and fill up the Entry form
        /// </summary>
        /// <param name="iProductId"></param>
        void getProductById(int iProductId);
        
        /// <summary>
        /// Used to get the Product List.
        /// </summary>
        /// 
         /// <param name="iProductId"></param>
        CProduct getProductinfo(int iProductId);
        
        /// <summary>
        /// Used to get the Product List.
        /// </summary>
        


        void getProductListByDepartmentNBarcode(string sSearchText,int iDepartmentId);

        /// <summary>
        /// Used to get the Product List.
        /// </summary>
        void getProductListByDepartmentNName(string sSearchText, int iDepartmentId);

        /// <summary>
        /// Get FruitLookUP List of Item by Department and Name wise
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentId"></param>
        void getFruitLookListByDepartmentNName(string sSearchText, int iDepartmentId);

        /// <summary>
        /// Get FruitLookUP List of Item by Department and Name wise
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentId"></param>
        void getFishLookListByDepartmentNName(string sSearchText, int iDepartmentId);

        /// <summary>
        /// Get MeatLookUP List of Item by Department and Name wise
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentId"></param>
        void getMeatLookListByDepartmentNName(string sSearchText, int iDepartmentId);

        /// <summary>
        /// Used to get the Product List.
        /// </summary>
        void getProductListByDepartmentNBrand(string sSearchText, int iDepartmentId);

        /// <summary>
        /// Used to get the getVegetableList By DepartmentId
        /// </summary>
        /// <param name="sCategory"></param>
        void getVegetableList(int iDepartmentId);

        /// <summary>
        /// Search Item List By Department and Item Name wise
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentId"></param>
        void getVegetableListByDepartmentNName(string sSearchText, int iDepartmentId);

        /// <summary>
        /// Used to get the getFruitList By DepartmentId
        /// </summary>
        /// <param name="iDepartmentId"></param>
        void getFruitList(int iDepartmentId);

        /// <summary>
        /// getProduct List by barcode
        /// </summary>
        /// <param name="sBarcode"></param>
        DataSet getProductListByBarcode(string sBarcode);

        /// <summary>
        /// Used to get all items
        /// </summary>
        /// <returns>list of all items</returns>
        List<CProduct> getAllItems();

        /// <summary>
        /// Get Particular Item or Item List By Category List or Particular Item
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCategory"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        void getItemsByCategoryItemName(int iStatus,int iCategory,string sName);

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

        /// <summary>
        /// Create a purchase
        /// </summary>
        /// <param name="sStatus"></param>
        /// <param name="sDescription"></param>
        /// <param name="dOrderDate"></param>
        /// <param name="dDeliveryDate"></param>
        /// <param name="sShippingMethod"></param>
        /// <param name="sShipTo"></param>
        /// <param name="iSupplierId"></param>
        /// <param name="dTotalCost"></param>
        /// <param name="dEnteredAt"></param>
        /// <param name="iEnteredBy"></param>
        /// <param name="dUpdatedAt"></param>
        /// <param name="iUpdatedBy"></param>
        /// <returns>purchase id</returns>
        int addPurchaseMain(DateTime dDeliveryDate, int iSupplierId, double dTotalCost, DateTime dEnteredAt, int iEnteredBy);

        /// <summary>
        /// Insert values in purchase details table
        /// </summary>
        /// <param name="iPurchaseId"></param>
        /// <param name="iProductId"></param>
        /// <param name="iQty"></param>
        /// <param name="dUnitPrice"></param>
        /// <param name="dExpireDate"></param>
        void addPurchaseDetails(int iPurchaseId, int iProductId, int iQty, double dUnitPrice, DateTime dExpireDate);

        int addDamageMain(string sRemarks, DateTime dEnteredAt, int iEnteredBy);
        void addDamageDetails(int iDamageId, int iProductId, int iQty, double dUnitCost, string sDescription);

        /// <summary>
        /// Returns an Image of the product for the producstId
        /// </summary>
        /// <param name="iProductId"></param>
        /// <returns></returns>
        byte[] getImageByProductId(int iProductId);
        

   }
    #endregion
}
