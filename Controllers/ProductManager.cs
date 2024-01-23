using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;
using System.Windows.Forms;

namespace POSsible.Controllers
{
    #region  ProductManager
    /// <summary>
    /// The ProductManager class simply hooks up a view to a model.
    /// </summary>
    class ProductManager : IProductManager
    {
        /// <summary>refernce to the IVegetableLookUpView, passed in on 
        /// creation</summary>
        private POSsible.Views.IVegetableLookUpView _VegetableLookUpView;

        /// <summary>
        /// Get Product Category List
        /// </summary>
        private POSsible.Views.IProductCategoryView _ProductCategoryView;
        

        /// <summary>
        /// reference to the IProductModel, retrived 
        /// on creation from the factory
        /// </summary>
        private POSsible.Models.IProductModel _ProductModel;
        /// <summary>
        /// Default Constructor
        /// </summary>
        //public ProductManager()
        //{

        //}

        /// <summary>
        /// null constructor
        /// </summary>
        public ProductManager()
        {
            _ProductModel = Factories.Factory.GetProductModel();
        }

        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForVegetableLookUpView"></param>
        public ProductManager(POSsible.Views.IProductCategoryView _ReferenceForProductCategoryView)
        {
            _ProductCategoryView = _ReferenceForProductCategoryView;
            _ProductModel = POSsible.Factories.Factory.GetProductModel();
        }

        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForVegetableLookUpView"></param>
        public ProductManager(POSsible.Views.IVegetableLookUpView _ReferenceForVegetableLookUpView)
        {
           _VegetableLookUpView = _ReferenceForVegetableLookUpView;
           _ProductModel = POSsible.Factories.Factory.GetProductModel();
        }

        /// <summary>
        /// refernce to the IFruitLookUpView, passed in on creation
        /// </summary>
        private POSsible.Views.IFruitLookUpView _FruitLookUpview;

        /// <summary>
        /// Constructor of ProductManager
        /// </summary>
        /// <param name="_ReferenceForFruitLookUpView"></param>
        public ProductManager(POSsible.Views.IFruitLookUpView _ReferenceForFruitLookUpView)
        {
            _FruitLookUpview = _ReferenceForFruitLookUpView;
            _ProductModel = POSsible.Factories.Factory.GetProductModel();
        }



        /// <summary>
        /// refernce to the IMeatLookUpView, passed in on creation
        /// </summary>
        private POSsible.Views.IMeatLookUpView _MeatLookUpview;

        /// <summary>
        /// Constructor of ProductManager
        /// </summary>
        /// <param name="_ReferenceForMeatLookUpView"></param>
        public ProductManager(POSsible.Views.IMeatLookUpView _ReferenceForMeatLookUpView)
        {
            _MeatLookUpview = _ReferenceForMeatLookUpView;
            _ProductModel = POSsible.Factories.Factory.GetProductModel();
        }

        /// <summary>
        /// refernce to the IFishLookUpView, passed in on creation
        /// </summary>
        private POSsible.Views.IFishLookUpView _FishLookUpview;

        /// <summary>
        /// Constructor of ProductManager
        /// </summary>
        /// <param name="_ReferenceForMeatLookUpView"></param>
        public ProductManager(POSsible.Views.IFishLookUpView _ReferenceForFishLookUpView)
        {
            _FishLookUpview = _ReferenceForFishLookUpView;
            _ProductModel = POSsible.Factories.Factory.GetProductModel();
        }
     
        /// <summary>
        /// Reference to the IPluVeiw
        /// </summary>
        private POSsible.Views.IPluView _PluView;

        /// <summary>
        /// Constructor of ProductManager For Plu
        /// </summary>
        /// <param name="_ReferenceForPluView"></param>
        public ProductManager(POSsible.Views.IPluView _ReferenceForPluView)
        {
            _PluView = _ReferenceForPluView;
            _ProductModel = Factories.Factory.GetProductModel();
        
        }
       
        /// <summary>
        /// Reference to the IItemView
        /// </summary>
        private POSsible.Views.IItemView _ItemView;
      
        /// <summary>
        /// Constructor to Product Manager for ItemView
        /// </summary>
        /// <param name="_ReferenceForItemView"></param>
        public ProductManager(POSsible.Views.IItemView _ReferenceForItemView)
        {
            _ItemView = _ReferenceForItemView;
            _ProductModel = Factories.Factory.GetProductModel();
        }


        /// <summary>
        /// Reference to the IItemView
        /// </summary>
        private POSsible.Views.IMainView _IMainView;

        /// <summary>
        /// Constructor to Product Manager for ItemView
        /// </summary>
        /// <param name="_ReferenceForItemView"></param>
        public ProductManager(POSsible.Views.IMainView _ReferenceForMainView)
        {
            _IMainView = _ReferenceForMainView;
            _ProductModel = Factories.Factory.GetProductModel();
        }

        #region IProductManager Members

        
        /// <summary>
        ///Implementation of IProductManager.getProductList 
        /// </summary>
        public void getProductList(CProduct oProductList)
        {
            try
            {
                _ProductModel.getProductList(oProductList);
                _PluView.displayProductList(oProductList);

            }
            catch (Exception oEx)
            { 
            
            }
        }

                      
        /// <summary>
        /// Implementation of IProductManager.getDepartmentList 
        /// </summary>
        public void getDepartmentList(int iScanNonScanStatus)
        {

            List<CDepartment> Listproducts = new List<CDepartment>();
            DataSet dsDepartmentList = _ProductModel.getDepartmentList(iScanNonScanStatus);

            DataTable dtDepartment = dsDepartmentList.Tables[0];

            if (dtDepartment.Rows.Count > 0)
            {
                CDepartment ointiDepartment = new CDepartment();
                ointiDepartment.DepartmentName = "Select Department";
                ointiDepartment.CategoryId = 0;
                ointiDepartment.Description = "";
                Listproducts.Add(ointiDepartment);
                for (int i = 0; i < dtDepartment.Rows.Count; i++)
                {
                    DataRow drDepartment = dtDepartment.Rows[i];
                    CDepartment oDepartment = new CDepartment();
                    if (drDepartment["deptName"].ToString() != "")
                        oDepartment.DepartmentName = drDepartment["deptName"].ToString();
                    if (drDepartment["categoryId"].ToString() != "")
                        oDepartment.CategoryId = Convert.ToInt16(drDepartment["categoryId"]);
                    if (drDepartment["description"].ToString() != "")
                        oDepartment.Description = drDepartment["description"].ToString();
                    
                    Listproducts.Add(oDepartment);
                }
            }
            if (_ItemView != null)
                _ItemView.putDepartmentList(Listproducts);
            else
                _PluView.putDepartmentList(Listproducts);

        }

        /// <summary>
        /// Implementation of IProductManager.getDepartmentList 
        /// </summary>
        public List<CDepartment> getProductCategoryList(int iScanNonScanStatus)
        {
            List<CDepartment> Listproducts = new List<CDepartment>();
            DataSet dsDepartmentList = _ProductModel.getDepartmentList(iScanNonScanStatus);

            DataTable dtDepartment = dsDepartmentList.Tables[0];

            if (dtDepartment.Rows.Count > 0)
            {
                CDepartment ointiDepartment = new CDepartment();
                //ointiDepartment.DepartmentName = "Select Department";
                //ointiDepartment.CategoryId = 0;
                //ointiDepartment.Description = "";
                //Listproducts.Add(ointiDepartment);
                for (int i = 0; i < dtDepartment.Rows.Count; i++)
                {
                    DataRow drDepartment = dtDepartment.Rows[i];
                    CDepartment oDepartment = new CDepartment();
                    if (drDepartment["deptName"].ToString() != "")
                        oDepartment.DepartmentName = drDepartment["deptName"].ToString();
                    if (drDepartment["categoryId"].ToString() != "")
                        oDepartment.CategoryId = Convert.ToInt16(drDepartment["categoryId"]);
                    if (drDepartment["description"].ToString() != "")
                        oDepartment.Description = drDepartment["description"].ToString();

                    Listproducts.Add(oDepartment);
                }
            }


            //if (_ItemView != null)
            //    _ItemView.putDepartmentList(Listproducts);
            //else
            //    _PluView.putDepartmentList(Listproducts);

            return Listproducts;

        }

        /// <summary>
        /// Implementation of IProductManager.getUnitMeasurementList 
        /// </summary>
        public void getUnitMeasurementList()
        {

            List<CUnitMeasurement> ListMeasurements = new List<CUnitMeasurement>();
            DataSet dsUnitMeasurementList = _ProductModel.getUnitMeasurementList();

            DataTable dtUnitMeasurement = dsUnitMeasurementList.Tables[0];
            //Select Measure of Unit;
            if (dtUnitMeasurement.Rows.Count > 0)
            {
                CUnitMeasurement ointiUnitMeasurement = new CUnitMeasurement();

                ointiUnitMeasurement.Name = "Select Measure of Unit";
                ointiUnitMeasurement.Id = 0;
                ointiUnitMeasurement.EnteredTime = DateTime.Now;
                ointiUnitMeasurement.EnteredBy = "0";
                ointiUnitMeasurement.UpdatedBy = "0";
                ointiUnitMeasurement.UpdatedTime = DateTime.Now;

                ListMeasurements.Add(ointiUnitMeasurement);
                for (int i = 0; i < dtUnitMeasurement.Rows.Count; i++)
                {
                    DataRow drUnitMeasurement = dtUnitMeasurement.Rows[i];
                    CUnitMeasurement oUnitMeasurement = new CUnitMeasurement();

                    oUnitMeasurement.Name = drUnitMeasurement["UnitMeasureName"].ToString();

                    if (drUnitMeasurement["unitMeasureId"].ToString() != "")
                        oUnitMeasurement.Id = Convert.ToInt16(drUnitMeasurement["unitMeasureId"]);

                    if (drUnitMeasurement["enteredtime"].ToString() != "")
                        oUnitMeasurement.EnteredTime = Convert.ToDateTime(drUnitMeasurement["enteredtime"]);
                    if (drUnitMeasurement["enteredby"].ToString() != "")
                        oUnitMeasurement.EnteredBy = drUnitMeasurement["enteredby"].ToString();
                    if (drUnitMeasurement["updatedby"].ToString() != "")
                        oUnitMeasurement.UpdatedBy = drUnitMeasurement["updatedby"].ToString();
                    if (drUnitMeasurement["updatedtime"].ToString() != "")
                        oUnitMeasurement.UpdatedTime = Convert.ToDateTime(drUnitMeasurement["updatedtime"]);

                    ListMeasurements.Add(oUnitMeasurement);
                }
            }
            _ItemView.putUnitMeasurementList(ListMeasurements);

        }

        /// <summary>
        /// Implementation of IProductManager.addItem 
        /// </summary>
        public int addItem(CProduct oProduct)
        {
            try
            {
                int result;
                result=_ProductModel.addItem(oProduct);
                if (_ItemView != null)
                {
                    if (result != 2627)
                    {
                        _ItemView.ClearFormContent();
                        _ItemView.Alert("Item Added Succesfully.");
                    }
                    else
                    {
                        _ItemView.Alert("Cannot add item with duplicate barcode no.");
                    }
                }

                return result;
            }
            catch (Exception oEx)
            {
                return 0;
            }
        }

        /// <summary>
       /// Implementation of IProductManager.deleteItem 
       /// </summary>
       /// <param name="oProduct"></param>
        public int deleteItem(CProduct oProduct)
        {

            try
            {
                int returnval;
                returnval=_ProductModel.deleteItem(oProduct);
                if (returnval != 547)
                {
                    _ItemView.Alert("Data Deleted Successfully");
                    _ItemView.ClearFormContent();
                }
                else
                {
                    _ItemView.Alert("You have no permission to delete this item.");
                }
                return returnval;
            }
            catch(Exception oEx)
            {
                return 0;
            }
        }
   
        /// <summary>
        ///  Implementation of IProductManager.updateItem 
        /// </summary>
        /// <param name="oProduct"></param>
        public int updateItem(CProduct oProduct)
        {
            try
            {
                int result;
                result = _ProductModel.updateItem(oProduct);
                if (result != 2627)
                {
                    _ItemView.ClearFormContent();
                    _ItemView.Alert("Data Updated Successfully");
                }
                else
                {
                    _ItemView.Alert("Cannot update item with duplicate barcode no.");
                }
                return result;
            }
            catch (Exception oEx)
            {
                return 0;
            }
        }

        /// <summary>
        /// Implementation of IProductManager.getItemlist
        /// </summary>
        /// <param name="iCategoryId"></param>
        /// <returns></returns>
        public void getItemlist(int iCategoryId)
        {
            try
            {

#region removable
                //DataSet dsProduct = _ProductModel.getItemlist(iCategoryId);
                //DataTable dtProduct=dsProduct.Tables[0];

                //List<CProduct> oLstProduct = new List<CProduct>();

                //if (dtProduct.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtProduct.Rows.Count; i++)
                //    {
                //        DataRow drProduct = dtProduct.Rows[i];
                //        CProduct oProduct = new CProduct();

                //        oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());
                //        oProduct.ProductName = drProduct["name"].ToString();
                //        oProduct.ShortCode = drProduct["shortcode"].ToString();

                //        if (drProduct["unitPrice"].ToString() != "")
                //            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"].ToString());
                //        else
                //            oProduct.UnitPrice = 0.00;

                //        if (drProduct["isGstItem"].ToString() != "")
                //            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"].ToString());
                //        else
                //            oProduct.IsGstItem = false;

                //        if (oProduct.IsGstItem.ToString() != "")
                //        {
                //            if (oProduct.IsGstItem.Equals(true))
                //            {
                //                oProduct.ProductName = oProduct.ProductName + "*";
                //            }
                //        }

                //        oLstProduct.Add(oProduct);
#endregion
                DataSet dsProductList = _ProductModel.getItemlist(iCategoryId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {                       
                            DataRow drProduct = dtProduct.Rows[i];
                            CProduct oProduct = new CProduct();
                            if (drProduct["name"].ToString() != "")
                                oProduct.ProductName = drProduct["name"].ToString();
                            if (drProduct["shortcode"].ToString() != "")
                                oProduct.ShortCode = drProduct["shortcode"].ToString();

                            if (drProduct["productId"].ToString() != "")
                                oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                            if (drProduct["unitPrice"].ToString() != "")
                                oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                            if (drProduct["promoUnitPrice"].ToString() != "")
                                oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                            if (drProduct["promoStartDate"].ToString() != "")
                                oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                            if (drProduct["promoEndDate"].ToString() != "")
                                oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                            if (drProduct["UnitMeasureName"].ToString() != "")
                                oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                            if (drProduct["isGstItem"].ToString() != "")
                                oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                            if (oProduct.IsGstItem.Equals(true))
                            {
                                oProduct.ProductName = "*" + oProduct.ProductName ;
                            }
                            //if (drProduct["ProductImage"].ToString() != "")
                            //    oProduct.Image = (byte[])drProduct["ProductImage"];   
                            
                        oLstProduct.Add(oProduct);

                    }
                }

                if (_ItemView != null)
                {
                    if (oLstProduct.Count != 0)
                    {
                        _ItemView.updateItemGrid(oLstProduct);
                        _ItemView.ClearFormContent();
                    }
                }
                else if (_PluView != null)
                {
                    //if (oLstProduct.Count != 0)
                    //{
                        _PluView.updateItemGrid(oLstProduct);
                    //}
                }
                else if (_MeatLookUpview != null)
                {
                    if (oLstProduct.Count != 0)
                    {
                    _MeatLookUpview.DisplayMeatList(oLstProduct);
                    }
                }
                else if (_FishLookUpview != null)
                {
                    if (oLstProduct.Count != 0)
                    {
                        _FishLookUpview.DisplayFishList(oLstProduct);
                    }
                }
            }
            catch(Exception exp)
            {
                if (_ItemView != null)
                {
                    _ItemView.Alert("Error while retrieving data.");
                }
                else if (_PluView != null)
                {
                    _PluView.Alert("Error while retrieving data.");
                }
                else if (_MeatLookUpview != null)
                {
                    _MeatLookUpview.Alert("Error while retrieving data.");
                }

                   
            }
        }

        /// <summary>
        /// Implementation of IProductManager.getItemsByCategoryItemName
        /// </summary>
        /// <param name="iCategoryId"></param>
        /// <returns></returns>
        public void getItemsByCategoryItemName(int iStatus, int iCategory, string sName)
        {
            try
            {             
                DataSet dsProductList = _ProductModel.getItemlistBy_Category_ItemName(iStatus,iCategory,sName);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();
                        if (drProduct["shortcode"].ToString() != "")
                            oProduct.ShortCode = drProduct["shortcode"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }
                        //if (drProduct["ProductImage"].ToString() != "")
                        //    oProduct.Image = (byte[])drProduct["ProductImage"];   

                        oLstProduct.Add(oProduct);

                    }
                }

                if (_ItemView != null)
                {
                    if (oLstProduct.Count != 0)
                    {
                        _ItemView.updateItemGrid(oLstProduct);                        
                    }
                }                
            }
            catch (Exception exp)
            {
                if (_ItemView != null)
                {
                    _ItemView.Alert(exp.Message + "Error while retrieving data.");
                }
            }
        }

        /// <summary>
        /// Implementation of IProductManager.getProductById
        /// </summary>
        /// <param name="iProductId"></param>
        /// <returns></returns>
        public void getProductById(int iProductId)
        {
            DataSet dsProduct = _ProductModel.getProductById(iProductId);
            DataTable dtProduct = dsProduct.Tables[0];
            CProduct oProduct = new CProduct();

            if (dtProduct.Rows.Count > 0)
            {
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    DataRow drProduct = dtProduct.Rows[i];

                    if (drProduct["productId"].ToString() != "")
                        oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());

                    oProduct.ProductName = drProduct["name"].ToString();
                    oProduct.ShortCode = drProduct["shortcode"].ToString();
                    oProduct.BarcodeNo = drProduct["barcodeNo"].ToString();
                    oProduct.ProductBrand = drProduct["brand"].ToString();

                    if (drProduct["categorytId"].ToString() != "")
                        oProduct.DepartmentId = Convert.ToInt16(drProduct["categorytId"].ToString());

                    if (drProduct["unitMeasureId"].ToString()!="")
                        oProduct.UnitMeasure = drProduct["unitMeasureId"].ToString();

                    oProduct.ProductDescription = drProduct["description"].ToString();

                    if (drProduct["unitPrice"].ToString() != "")
                        oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                    if (drProduct["unitCost"].ToString() != "")
                        oProduct.UnitCost = Convert.ToDouble(drProduct["unitCost"]);
                    if (drProduct["QtyInOrder"].ToString() != "")
                        oProduct.QtyInorder = Convert.ToDouble(drProduct["QtyInOrder"]);
                    if (drProduct["weight"].ToString() != "")
                        oProduct.ProductWeight = Convert.ToDouble(drProduct["weight"]);

                    if (drProduct["isGstItem"].ToString() != "")
                        oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"].ToString());
                    if (drProduct["isexpireable"].ToString() != "")
                        oProduct.IsExpirable = Convert.ToBoolean(drProduct["isexpireable"].ToString());
                    if (drProduct["promoUnitPrice"].ToString() != "")
                        oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"].ToString());
                    if (drProduct["promoStartDate"].ToString() != "")
                        oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"].ToString());
                    if (drProduct["promoEndDate"].ToString() != "")
                        oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"].ToString());
                    if (drProduct["qtyInStock"].ToString() != "")
                        oProduct.QtyInStock = Convert.ToDouble(drProduct["qtyInStock"].ToString());
                    if (drProduct["minQty"].ToString() != "")
                        oProduct.MinQty = Convert.ToDouble(drProduct["minQty"]);

                    if (drProduct["ticketType"].ToString() != "")
                        oProduct.Ticket = Convert.ToBoolean(drProduct["ticketType"].ToString());

                    if (drProduct["ProductImage"].ToString() != "")
                        oProduct.Image = (byte[])drProduct["ProductImage"];

                    //if (oProduct.IsGstItem.Equals(true))
                    //{
                    //    oProduct.ProductName = oProduct.ProductName + "*";
                    //}
                }

            }
            _ItemView.FillUpFormContent(oProduct);
        }

        public CProduct getProductinfo(int iProductId)
        {
            DataSet dsProduct = _ProductModel.getProductById(iProductId);
            DataTable dtProduct = dsProduct.Tables[0];
            CProduct oProduct = new CProduct();

            if (dtProduct.Rows.Count > 0)
            {
                for (int i = 0; i < dtProduct.Rows.Count; i++)
                {
                    DataRow drProduct = dtProduct.Rows[i];

                    if (drProduct["productId"].ToString() != "")
                        oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());

                    oProduct.ProductName = drProduct["name"].ToString();
                    oProduct.ShortCode = drProduct["shortcode"].ToString();
                    oProduct.BarcodeNo = drProduct["barcodeNo"].ToString();
                    oProduct.ProductBrand = drProduct["brand"].ToString();

                    if (drProduct["categorytId"].ToString() != "")
                        oProduct.DepartmentId = Convert.ToInt16(drProduct["categorytId"].ToString());

                    if (drProduct["unitMeasureId"].ToString() != "")
                        oProduct.UnitMeasure = drProduct["unitMeasureId"].ToString();

                    oProduct.ProductDescription = drProduct["description"].ToString();

                    if (drProduct["unitPrice"].ToString() != "")
                        oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                    if (drProduct["unitCost"].ToString() != "")
                        oProduct.UnitCost = Convert.ToDouble(drProduct["unitCost"]);
                    if (drProduct["QtyInOrder"].ToString() != "")
                        oProduct.QtyInorder = Convert.ToDouble(drProduct["QtyInOrder"]);

                    if (drProduct["isGstItem"].ToString() != "")
                        oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"].ToString());
                    if (drProduct["isexpireable"].ToString() != "")
                        oProduct.IsExpirable = Convert.ToBoolean(drProduct["isexpireable"].ToString());
                    if (drProduct["promoUnitPrice"].ToString() != "")
                        oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"].ToString());
                    if (drProduct["promoStartDate"].ToString() != "")
                        oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"].ToString());
                    if (drProduct["promoEndDate"].ToString() != "")
                        oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"].ToString());
                    if (drProduct["qtyInStock"].ToString() != "")
                        oProduct.QtyInStock = Convert.ToDouble(drProduct["qtyInStock"].ToString());
                    if (drProduct["minQty"].ToString() != "")
                        oProduct.MinQty = Convert.ToDouble(drProduct["minQty"]);

                    if (drProduct["ticketType"].ToString() != "")
                        oProduct.Ticket = Convert.ToBoolean(drProduct["ticketType"].ToString());

                    if (drProduct["ProductImage"].ToString() != "")
                        oProduct.Image = (byte[])drProduct["ProductImage"];

                    //if (oProduct.IsGstItem.Equals(true))
                    //{
                    //    oProduct.ProductName = oProduct.ProductName + "*";
                    //}
                }
                
            }
            return oProduct;
        }
       
        /// <summary>
        /// Implementation of IProductManager.getProductListByDepartmentNBarcode
        /// </summary>
        /// <param name="sSerchText"></param>
        /// <param name="iDepartmentId"></param>
        public void getProductListByDepartmentNBarcode(string sSerchText,int iDepartmentId)
        {
            try
            {
                DataSet dsProductList=_ProductModel.getProductListByDepartmentNBarcode(sSerchText,iDepartmentId);                                
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        //DataRow drProduct = dtProduct.Rows[i];
                        //CProduct oProduct = new CProduct();

                        //if (drProduct["productId"].ToString() != "")
                        //    oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());

                        //oProduct.ProductName = drProduct["name"].ToString();
                        //oProduct.ShortCode = drProduct["shortcode"].ToString();

                        //if (drProduct["unitPrice"].ToString() != "")
                        //    oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        //if (drProduct["isGstItem"].ToString() != "")
                        //    oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);

                        //if (oProduct.IsGstItem.ToString() != "")
                        //{
                        //    if (oProduct.IsGstItem.Equals(true))
                        //    {
                        //        oProduct.ProductName = oProduct.ProductName + "*";
                        //    }
                        //}

                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();
                        if (drProduct["shortcode"].ToString() != "")
                            oProduct.ShortCode = drProduct["shortcode"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }


                        oLstProduct.Add(oProduct);
                    }

                }
                _PluView.updateItemGrid(oLstProduct);
            }
            catch (Exception oEx)
            { 
            
            }
        }

        /// <summary>
        /// Implementation of IProductManager.getProductListByDepartmentNName
        /// </summary>
        /// <param name="sSerchText"></param>
        /// <param name="iDepartment"></param>
        public void getProductListByDepartmentNName(string sSerchText, int iDepartmentId)
        {
            try
            {
                //DataSet dsProductList = _ProductModel.getProductListByDepartmentNBarcode(sSerchText, iDepartmentId);
                DataSet dsProductList = _ProductModel.getProductListByDepartmentNName(sSerchText, iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        //DataRow drProduct = dtProduct.Rows[i];
                        //CProduct oProduct = new CProduct();

                        //if (drProduct["productId"].ToString() != "")
                        //    oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());

                        //oProduct.ProductName = drProduct["name"].ToString();
                        //oProduct.ShortCode = drProduct["shortcode"].ToString();

                        //if (drProduct["unitPrice"].ToString() != "")
                        //    oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        //if (drProduct["isGstItem"].ToString()!= "")
                        //    oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);

                        //if (oProduct.IsGstItem.ToString() != "")
                        //{
                        //    if (oProduct.IsGstItem.Equals(true))
                        //    {
                        //        oProduct.ProductName = oProduct.ProductName + "*";
                        //    }
                        //}


                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();
                        if (drProduct["shortcode"].ToString() != "")
                            oProduct.ShortCode = drProduct["shortcode"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }


                        oLstProduct.Add(oProduct);
                    }

                }
                _PluView.updateItemGrid(oLstProduct);

            }
            catch (Exception oEx)
            {

            }
        
        }

        /// <summary>
        /// Implementation of IProductManager.getProductListByDepartmentNBrand
        /// </summary>
        /// <param name="sSerchText"></param>
        /// <param name="iDepartment"></param>
        public void getProductListByDepartmentNBrand(string sSerchText, int iDepartmentId)
        {
            try
            {
               DataSet dsProductList = _ProductModel.getProductListByDepartmentNBarcode(sSerchText, iDepartmentId);
               DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        //DataRow drProduct = dtProduct.Rows[i];
                        //CProduct oProduct = new CProduct();

                        //if (drProduct["productId"].ToString() != "")
                        //    oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());

                        //oProduct.ProductName = drProduct["name"].ToString();
                        //oProduct.ShortCode = drProduct["shortcode"].ToString();

                        //if (drProduct["unitPrice"].ToString()!="")
                        //oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        //if (drProduct["isGstItem"].ToString()!="")
                        //oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);

                        //if (oProduct.IsGstItem.Equals(true))
                        //{
                        //    oProduct.ProductName = oProduct.ProductName + "*";
                        //}

                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();
                        if (drProduct["shortcode"].ToString() != "")
                            oProduct.ShortCode = drProduct["shortcode"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName ;
                        }

                        oLstProduct.Add(oProduct);
                    }

                }
                _PluView.updateItemGrid(oLstProduct);
            }
            
            catch (Exception oEx)
            {

            }
        
        }

        /// <summary>
        /// Implementation of IProductManager.getVegetableList
        /// </summary>
        /// <param name="iDepartmentId"></param>
        public void getVegetableList(int iDepartmentId)
        {
             try
            {
                DataSet dsProductList = _ProductModel.getVegetableList(iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {                       
                            DataRow drProduct = dtProduct.Rows[i];
                            CProduct oProduct = new CProduct();
                            if (drProduct["name"].ToString() != "")
                                oProduct.ProductName = drProduct["name"].ToString();

                            if (drProduct["productId"].ToString() != "")
                                oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                            if (drProduct["unitPrice"].ToString() != "")
                                oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                            if (drProduct["promoUnitPrice"].ToString() != "")
                                oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                            if (drProduct["promoStartDate"].ToString() != "")
                                oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                            if (drProduct["promoEndDate"].ToString() != "")
                                oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                            if (drProduct["UnitMeasureName"].ToString() != "")
                                oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                            if (drProduct["isGstItem"].ToString() != "")
                                oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                            if (oProduct.IsGstItem.Equals(true))
                            {
                                oProduct.ProductName = "*" + oProduct.ProductName;
                            }
                            //if (drProduct["ProductImage"].ToString() != "")
                            //    oProduct.Image = (byte[])drProduct["ProductImage"];   
                            
                        oLstProduct.Add(oProduct);
                        }

                }
                _VegetableLookUpView.DisplayVegetableList(oLstProduct);


            }
            catch (Exception oEx)
            {

            }
        }

        /// <summary>
        /// Implementation of IProductManager.get Fish by Deapartment and Item Name
        /// </summary>
        /// <param name="iDepartmentId"></param>
        public void getMeatLookListByDepartmentNName(string sSearchText, int iDepartmentId)
        {
            try
            {
                DataSet dsProductList = _ProductModel.getProductListByDepartmentNName(sSearchText, iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }
                        //if (drProduct["ProductImage"].ToString() != "")
                        //    oProduct.Image = (byte[])drProduct["ProductImage"];   

                        oLstProduct.Add(oProduct);
                    }

                }
                _MeatLookUpview.DisplayMeatList(oLstProduct);
            }
            catch (Exception oEx)
            {

            }
        }

        /// <summary>
        /// Implementation of IProductManager.get Fish by Deapartment and Item Name
        /// </summary>
        /// <param name="iDepartmentId"></param>
        public void getFishLookListByDepartmentNName(string sSearchText, int iDepartmentId)
        {
            try
            {
                DataSet dsProductList = _ProductModel.getProductListByDepartmentNName(sSearchText, iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }
                        //if (drProduct["ProductImage"].ToString() != "")
                        //    oProduct.Image = (byte[])drProduct["ProductImage"];   

                        oLstProduct.Add(oProduct);
                    }

                }
                _FishLookUpview.DisplayFishList(oLstProduct);
            }
            catch (Exception oEx)
            {

            }
        }

        /// <summary>
        /// Implementation of IProductManager.getVegetableList by Deapartment and Item Name
        /// </summary>
        /// <param name="iDepartmentId"></param>
        public void getFruitLookListByDepartmentNName(string sSearchText, int iDepartmentId)
        {
            try
            {
                DataSet dsProductList = _ProductModel.getProductListByDepartmentNName(sSearchText, iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }
                        //if (drProduct["ProductImage"].ToString() != "")
                        //    oProduct.Image = (byte[])drProduct["ProductImage"];   

                        oLstProduct.Add(oProduct);
                    }

                }
                _FruitLookUpview.DisplayFruitList(oLstProduct);
            }
            catch (Exception oEx)
            {

            }
        }

        /// <summary>
        /// Implementation of IProductManager.getVegetableList by Deapartment and Item Name
        /// </summary>
        /// <param name="iDepartmentId"></param>
        public void getVegetableListByDepartmentNName(string sSearchText, int iDepartmentId)
        {
            try
            {
                DataSet dsProductList = _ProductModel.getProductListByDepartmentNName(sSearchText, iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {

                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();
                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);
                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);
                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);
                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);
                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();
                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);
                        if (oProduct.IsGstItem.Equals(true))
                        {
                            oProduct.ProductName = "*" + oProduct.ProductName;
                        }
                        
                        oLstProduct.Add(oProduct);
                    }
                }
                _VegetableLookUpView.DisplayVegetableList(oLstProduct);
            }
            catch (Exception oEx)
            {
            }
        }

        /// <summary>
        /// Implementation of IProductManager.getFruitList
        /// </summary>
        /// <param name="iDepartmentId"></param>
        public void getFruitList(int iDepartmentId)
        {
            try
            {
                DataSet dsProductList = _ProductModel.getFruitList(iDepartmentId);
                DataTable dtProduct = dsProductList.Tables[0];

                List<CProduct> oLstProduct = new List<CProduct>();

                if (dtProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        DataRow drProduct = dtProduct.Rows[i];
                        CProduct oProduct = new CProduct();

                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt32(drProduct["productId"].ToString());

                        if (drProduct["name"].ToString() != "")
                            oProduct.ProductName = drProduct["name"].ToString();
                        if (drProduct["productId"].ToString() != "")
                            oProduct.ProductId = Convert.ToInt16(drProduct["productId"]);

                        if (drProduct["unitPrice"].ToString() != "")
                            oProduct.UnitPrice = Convert.ToDouble(drProduct["unitPrice"]);

                        if (drProduct["promoUnitPrice"].ToString() != "")
                            oProduct.PromoUnitPrice = Convert.ToDouble(drProduct["promoUnitPrice"]);

                        if (drProduct["promoStartDate"].ToString() != "")
                            oProduct.PromoStartDate = Convert.ToDateTime(drProduct["promoStartDate"]);

                        if (drProduct["promoEndDate"].ToString() != "")
                            oProduct.PromoEndDate = Convert.ToDateTime(drProduct["promoEndDate"]);

                        if (drProduct["UnitMeasureName"].ToString() != "")
                            oProduct.UnitMeasure = drProduct["UnitMeasureName"].ToString();

                        if (drProduct["isGstItem"].ToString() != "")
                            oProduct.IsGstItem = Convert.ToBoolean(drProduct["isGstItem"]);

                        if (oProduct.IsGstItem.Equals(true))
                            oProduct.ProductName = "*" + oProduct.ProductName ;



                        oLstProduct.Add(oProduct);
                    }

                }
                _FruitLookUpview.DisplayFruitList(oLstProduct);


            }
            catch (Exception oEx)
            {

            }
        }

        /// <summary>
        /// Implementation of IProductManager.getProductListByBarcode
        /// </summary>
        /// <param name="sBarcode"></param>
        public DataSet getProductListByBarcode(string sBarcode)
        {            
            DataSet dsProductList = _ProductModel.getProductListByBarcode(sBarcode);
            return dsProductList; 
        }

        /// <summary>
        /// Implementation of IProductManager.getAllItems 
        /// </summary>
        public List<CProduct> getAllItems()
        {

            List<CProduct> lProductList = new List<CProduct>();
            DataSet dsItem = _ProductModel.getAllItems();

            foreach (DataRow drItem in dsItem.Tables[0].Rows)
            {
                CProduct oProduct = new CProduct();

                if (drItem["productId"].ToString() != "")
                    oProduct.ProductId = Convert.ToInt32(drItem["productId"].ToString());

                oProduct.DepartmentId = Convert.ToInt32(drItem["categorytId"].ToString());
                oProduct.BarcodeNo = drItem["barcodeNo"].ToString();
                oProduct.ProductName = drItem["name"].ToString();
                oProduct.ProductDescription = drItem["description"].ToString();
                oProduct.ProductBrand = drItem["brand"].ToString();
                oProduct.ProductMadeIn = drItem["madeIn"].ToString();
                oProduct.ProductWeight = Convert.ToDouble(drItem["weight"].ToString());
                if (drItem["isGstItem"].ToString()!="")
                    oProduct.IsGstItem = Convert.ToBoolean(drItem["isGstItem"].ToString());
                if (drItem["isexpireable"].ToString()!="")
                oProduct.IsExpirable = Convert.ToBoolean(drItem["isexpireable"].ToString());
                oProduct.Ticket = Convert.ToBoolean(drItem["ticketType"].ToString());
                if (drItem["unitCost"].ToString() != "")
                    oProduct.UnitCost = Convert.ToDouble(drItem["unitCost"].ToString());
                if (drItem["unitPrice"].ToString() != "")
                    oProduct.UnitPrice = Convert.ToDouble(drItem["unitPrice"].ToString());
                if (drItem["promoUnitPrice"].ToString() != "")
                    oProduct.PromoUnitPrice = Convert.ToDouble(drItem["promoUnitPrice"].ToString());
                if (drItem["promoStartDate"].ToString() != "")
                    oProduct.PromoStartDate = DateTime.Parse(drItem["promoStartDate"].ToString());
                if (drItem["promoEndDate"].ToString() != "")
                    oProduct.PromoEndDate = DateTime.Parse(drItem["promoEndDate"].ToString());
                if (drItem["unitMeasureId"].ToString() != "")
                    oProduct.UnitMeasure = drItem["unitMeasureId"].ToString();

                if (drItem["qtyInStock"].ToString() != "")
                    oProduct.QtyInStock = Convert.ToDouble(drItem["qtyInStock"].ToString());
                if (drItem["qtyInOrder"].ToString() != "")
                    oProduct.QtyInorder = Convert.ToDouble(drItem["qtyInOrder"].ToString());
                if (drItem["minQty"].ToString() != "")
                    oProduct.MinQty = Convert.ToDouble(drItem["minQty"].ToString());
                if (drItem["enteredtime"].ToString() != "")
                    oProduct.Enteredtime = DateTime.Parse(drItem["enteredtime"].ToString());
                if (drItem["enteredby"].ToString() != "")
                    oProduct.EnteredBy = Convert.ToInt32(drItem["enteredby"].ToString());
                if (drItem["updatedtime"].ToString() != "")
                    oProduct.UpdatedTime = DateTime.Parse(drItem["updatedtime"].ToString());
                if (drItem["updatedby"].ToString() != "")
                    oProduct.UpdatedBy = Convert.ToInt32(drItem["updatedby"].ToString());

                lProductList.Add(oProduct);
            }

            return lProductList;
        }

        public int addPurchaseMain(DateTime dDeliveryDate, int iSupplierId, double dTotalCost, DateTime dEnteredAt, int iEnteredBy)
        {
            int iPurchaseId = 0;
            try
            {
                iPurchaseId=_ProductModel.addPurchaseMain(dDeliveryDate, iSupplierId, dTotalCost, dEnteredAt, iEnteredBy);
            }
            catch (Exception oEx)
            {
            }
            return iPurchaseId;
        }

        public void addPurchaseDetails(int iPurchaseId, int iProductId, int iQty, double dUnitPrice, DateTime dExpireDate)
        {
            try
            {
                _ProductModel.addPurchaseDetails(iPurchaseId, iProductId, iQty, dUnitPrice, dExpireDate);
            }
            catch (Exception oEx)
            {
            }
        }

        public int addDamageMain(string sRemarks, DateTime dEnteredAt, int iEnteredBy)
        {
            int iDamageId = 0;
            try
            {
                iDamageId = _ProductModel.addDamageMain(sRemarks, dEnteredAt, iEnteredBy);
            }
            catch (Exception oEx)
            {
            }
            return iDamageId;
        }

        public void addDamageDetails(int iDamageId, int iProductId, int iQty, double dUnitCost, string sDescription)
        {
            try
            {
                _ProductModel.addDamageDetails(iDamageId, iProductId, iQty, dUnitCost, sDescription);
            }
            catch (Exception oEx)
            {
            }
        }
        public byte[] getImageByProductId(int iProductId)
        {
            byte[] productImage = null;
            try
            {
               DataSet dsProduct = _ProductModel.getProductById(iProductId);
                if(dsProduct.Tables[0].Rows[0]["ProductImage"].ToString()!="")
               productImage = (byte[])dsProduct.Tables[0].Rows[0]["ProductImage"];
            }
            catch (Exception exp)
            {

            }

            return productImage;
        }

        /// <summary>
        /// Used to get list of all items according to its ticket
        /// </summary>
        /// <returns></returns>
        public DataSet getItemsByTicket(bool bTicket, int iCategoryId)
        {
            return _ProductModel.getItemsByTicket(bTicket, iCategoryId);
        }

        /// <summary>
        /// Used to get Department wise gross net profit
        /// </summary>
        /// <returns></returns>
        public DataSet getProfitByDepartment(int iDeptId, DateTime dFrom, DateTime dTo)
        {
            return _ProductModel.getProfitByDepartment(iDeptId, dFrom, dTo);
        }

        #endregion
    }
    #endregion

}
