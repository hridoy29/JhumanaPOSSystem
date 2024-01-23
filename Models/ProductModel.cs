using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;
using System.IO.Ports;
//using System.Data.SqlClient;

namespace POSsible.Models
{

    
    /// <summary>
    /// ProductModel implementation.  To work with this use the Factory to 
    /// obtain an instantiated version of IProductModel
    /// </summary>
    class ProductModel : IProductModel
    {
        #region Attributes
        /// <summary>
        /// The SQL to find all Departments.
        /// </summary>
        private static readonly string SQL_FIND_ALL_DEPT =
            "ritpos_department_find_all";

        /// <summary>
        /// The SQL to find all Measurements.
        /// </summary>
        private static readonly string SQL_FIND_ALL_MSRMENT =
            "ritpos_measurement_find_all";

        /// <summary>
        /// The SQL to find a Item by DepartmentId.
        /// </summary>
        private static readonly string SQL_FIND_BY_PK =
            "ritpos_find_itemlist";

        /// <summary>
        /// The SQL to find a Item by DepartmentId.
        /// </summary>
        private static readonly string SQL_FIND_BY_PRODUCT_ID =
            "ritpos_find_product";

        /// <summary>
        /// The SQL to add a Item.
        /// </summary>
        private static readonly string SQL_ADD =
            "ritpos_add_item";

        /// <summary>
        /// The SQL to delete a Item.
        /// </summary>
        private static readonly string SQL_DELETE =
            "ritpos_delete_product";

        /// <summary>
        /// The SQL to update a Item.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_item";


         /// <summary>
        /// The SQL to find ProductList.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_NAME_AND_DEPT =
            "ritpos_product_find_by_name_department";


        /// <summary>
        /// The SQL to find ProductList.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_BRAND_AND_DEPT =
            "ritpos_product_find_by_brand_department";

        /// <summary>
        /// The SQL to find ProductList.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_BARCODE_AND_DEPT =
            "ritpos_product_find_by_barcode_department";

        /// <summary>
        /// The SQL to find ProductList by Department ID.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_DEPARTMENT = "ritpos_product_find_by_department_id";


        /// <summary>
        /// The SQL to find ProductList by Department ID.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_DEPARTMENT_OR_NameofItem = "ritpos_product_find_by_name";

        /// <summary>
        /// The SQL to find ProductList by Barcode.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_BRACODE = "ritpos_product_find_by_barcode";

        /// <summary>
        /// The SQL to find all Items
        /// </summary>
        private static readonly string SQL_GET_ALL_ITEMS = "ritpos_product_get_all_items";

        /// <summary>
        /// The SQL to add purchase main
        /// </summary>
        private static readonly string SQL_ADD_PURCHASE_MAIN = "ritpos_product_add_purchase_main";

        /// <summary>
        /// The SQL to add purchase details
        /// </summary>
        private static readonly string SQL_ADD_PURCHASE_DETAILS = "ritpos_product_add_purchase_details";

        /// <summary>
        /// The SQL to add purchase main
        /// </summary>
        private static readonly string SQL_ADD_DAMAGE_MAIN = "ritpos_product_add_damage_main";

        /// <summary>
        /// The SQL to add purchase details
        /// </summary>
        private static readonly string SQL_ADD_DAMAGE_DETAILS = "ritpos_product_add_damage_details";

        /// <summary>
        /// The SQL to find ProductList.
        /// </summary>
        private static readonly string SQL_FIND_PRODUCT_BY_TICKET = "ritpos_product_find_by_ticket";

        /// <summary>
        /// The SQL to net profit.
        /// </summary>
        private static readonly string SQL_FIND_PROFIT_BY_DEPT = "ritpos_product_profit_by_dept";
        /// <summary>
        /// SP to collect the MAX +1 barcode for nonscan items
        /// </summary>
        private static readonly string SQL_GET_NONSCAN_ID = "ritpos_get_nonscan_id";

        /// <summary>
        /// Various parameter names.
        /// </summary>
        private static readonly string PARM_PRODUCT_ID = "@productId";
        private static readonly string PARM_CATEGORY_ID = "@categoryId";
        private static readonly string PARAM_NON_SCAN_STATUS = "@ScanNonScanStatus";
        private static readonly string PARAM_DEPARTMENT_ID = "@departmentId";
        private static readonly string PARAM_STATUS = "@status";
        private static readonly string PARM_BARCODE_NO = "@barcodeNo";
        private static readonly string PARM_TICKET_ID = "@ticketId";
        private static readonly string PARM_PRODUCT_NAME = "@name";
        private static readonly string PARM_PRODUCT_SHORTCODE = "@shortcode";
        private static readonly string PARM_PRODUCT_DESCRIPTION = "@description";
        private static readonly string PARM_PRODUCR_BRAND = "@brand";
        private static readonly string PARM_PRODUCT_MADEINN = "@madeInn";
        private static readonly string PARM_PRODUCT_WEIGHT = "@weight";
        private static readonly string PARM_ISGST_ITEM = "@isGstItem";
        private static readonly string PARM_UNIT_COST = "@unitCost";
        private static readonly string PARM_UNIT_PRICE = "@unitPrice";
        private static readonly string PARM_PROMO_UNITPRICE = "@promoUnitPrice";
        private static readonly string PARM_PROMO_STARTDATE = "@promoStartDate";
        private static readonly string PARM_PROMO_ENDDATE = "@promoEndDate";
        private static readonly string PARM_UNIT_MEASURE = "@unitMeasure";
        private static readonly string PARM_QUANTITY_INSTOCK = "@qtyInStock";
        private static readonly string PARM_QUANTITY_INORDER = "@qtyInOrder";
        private static readonly string PARM_MIN_QUANTITY = "@minQty";
        private static readonly string PARM_IMAGE_ID = "@imageId";
        private static readonly string PARM_ENTERED_TIME = "@enteredTime";
        private static readonly string PARM_ENTERED_BY = "@enteredBy";
        private static readonly string PARM_UPDATED_TIME = "@updatedTime";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        private static readonly string PARAM_SEARCH_TEXT="@searchText";
        private static readonly string PARAM_PRODUCT_BRAND = "@brand";
        
        private static readonly string PARAM_PRODUCT_BARCODE = "@barcodeNo";

        private static readonly string PARM_PURCHASE_STATUS = "@status";
        private static readonly string PARM_PURCHASE_DESCRIPTION = "@description";
        private static readonly string PARM_ORDER_DATE = "@orderDate";
        private static readonly string PARM_DELIVERY_DATE = "@deliveryDate";
        private static readonly string PARM_SHIPPING_METHOD = "@shippingMethod";
        private static readonly string PARM_SHIP_TO = "@shipTo";
        private static readonly string PARM_SUPPLIER_ID = "@supplierId";
        private static readonly string PARM_TOTAL_COST = "@totalCost";
        private static readonly string PARM_PURCHASE_ID = "@purchaseId";

        private static readonly string PARM_PURCHASE_QUANTITY = "@qty";
        private static readonly string PARM_EXPIRE_DATE = "@ExpireDate";

        private static readonly string PARM_DAMAGE_ID = "@damageId";
        private static readonly string PARM_DAMAGE_REMARKS = "@remarks";
        private static readonly string PARM_DAMAGE_QTY= "@qty";
        private static readonly string PARM_DAMAGE_DESCRIPTION = "@description";

        private static readonly string PARM_FROM = "@from";
        private static readonly string PARM_TO = "@to";
        


        #endregion

        public ProductModel()
        {

        }

        /// <summary>
        /// Implementation of IPluModel.getProductList method
        /// </summary>
        public CProduct getProductList(CProduct oProductList)
        {
            return oProductList;
        }

        /// <summary>
        /// Implementation of IProductModel.addItem 
        /// </summary>
        public int addItem(CProduct oProduct)
        {
            // Read the runtime setup.
            POSConfiguration objPOSConfig = new POSConfiguration();

            // Declare the objects for database transaction and connection
            SqlTransaction objTrans = null;
            SqlConnection DataConnection = new SqlConnection(objPOSConfig.getConnectionstring());

            try
            {
                DataConnection.Open();
                // Begin the database transaction
                objTrans = DataConnection.BeginTransaction();

                // Attempt to load the parameters.
                SqlParameter[] ArrParam = new SqlParameter[23];
                // Assign values to the parameters.
                ArrParam[0] = new SqlParameter("@departmentId", oProduct.DepartmentId);
                ArrParam[1] = new SqlParameter("@barcodeNo", oProduct.BarcodeNo);
                ArrParam[2] = new SqlParameter("@name", oProduct.ProductName);
                ArrParam[3] = new SqlParameter("@shortcode", oProduct.ShortCode);
                ArrParam[4] = new SqlParameter("@description", oProduct.ProductDescription);
                ArrParam[5] = new SqlParameter("@brand", oProduct.ProductBrand);
                ArrParam[6] = new SqlParameter("@madeIn", oProduct.ProductMadeIn);
                ArrParam[7] = new SqlParameter("@weight", oProduct.ProductWeight);
                ArrParam[8] = new SqlParameter("@isGstItem", oProduct.IsGstItem);
                ArrParam[9] = new SqlParameter("@isexpireable", oProduct.IsExpirable);
                ArrParam[10] = new SqlParameter("@ticketType", oProduct.Ticket);
                ArrParam[11] = new SqlParameter("@unitCost", oProduct.UnitCost);
                ArrParam[12] = new SqlParameter("@unitPrice", oProduct.UnitPrice);
                ArrParam[13] = new SqlParameter("@promoUnitPrice", oProduct.PromoUnitPrice);

                if (oProduct.PromoStartDate!=DateTime.MinValue)
                    ArrParam[14] = new SqlParameter("@promoStartDate", oProduct.PromoStartDate);
                else
                    ArrParam[14] = new SqlParameter("@promoStartDate", System.DBNull.Value);

                if (oProduct.PromoEndDate != DateTime.MinValue)
                    ArrParam[15] = new SqlParameter("@promoEndDate", oProduct.PromoEndDate);
                else
                    ArrParam[15] = new SqlParameter("@promoEndDate", System.DBNull.Value);

                ArrParam[16] = new SqlParameter("@unitMeasure", oProduct.UnitMeasureId);
                ArrParam[17] = new SqlParameter("@qtyInStock", oProduct.QtyInStock);
                ArrParam[18] = new SqlParameter("@qtyInOrder", oProduct.QtyInorder);
                ArrParam[19] = new SqlParameter("@minQty", oProduct.MinQty);
                if (oProduct.Image != null)
                {
                    ArrParam[20] = new SqlParameter("@productImage", oProduct.Image);
                }
                else
                {
                    //byte[] imagedata=System.DBNull.Value;
                    ArrParam[20] = new SqlParameter("@productImage", SqlDbType.Image);
                    ArrParam[20].Value = DBNull.Value;
                    ArrParam[20].IsNullable = true;
                }
                ArrParam[21] = new SqlParameter("@enteredBy", oProduct.EnteredBy);
                //ArrParam[22] = new SqlParameter("@productId", 0);
                ArrParam[22] = new SqlParameter("@productId", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "@productId", DataRowVersion.Current, null);
                
                // Execute the SQL statement.
                int iResult = Convert.ToInt16( SqlHelper.ExecuteScalar(objPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, ArrParam));
                // Commit the transaction.
                oProduct.ProductId = (int)ArrParam[22].Value;
                objTrans.Commit();
                return iResult;
            }
            catch (Exception exp)
            {
                // Rollback the transaction if there is any error
                objTrans.Rollback();
                return 0;
            }
            finally
            {
                // Closing the database connection
                DataConnection.Close();
            }
        }

        /// <summary>
        /// Implementation of IProductModel.deleteItem 
        /// </summary>
        public int deleteItem(CProduct oProduct)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();
            SqlConnection sqlCon = new SqlConnection(oPOSConfig.getConnectionstring());
            try
            {
                int returnval;
                sqlCon.Open();
                SqlParameter[] ArrParam = new SqlParameter[1];
                ArrParam[0] = new SqlParameter(PARM_PRODUCT_ID, oProduct.ProductId);
                returnval=Convert.ToInt16( SqlHelper.ExecuteScalar(sqlCon, CommandType.StoredProcedure, SQL_DELETE, ArrParam));
                return returnval;
               
            }
            catch(Exception oEx)
            {
                return 0;
            }
            finally
            {
                sqlCon.Close();

            }
 
        }

        /// <summary>
        /// Implementation of IProductModel.updateItem 
        /// </summary>
        public int updateItem(CProduct oProduct)
        {

            // Read the runtime setup.
            POSConfiguration objPOSConfig = new POSConfiguration();

            // Declare the objects for database transaction and connection
            SqlTransaction objTrans = null;
            SqlConnection DataConnection = new SqlConnection(objPOSConfig.getConnectionstring());

            try
            {
                // Open the database connection
                DataConnection.Open();
                // Begin the database transaction
                objTrans = DataConnection.BeginTransaction();

                // Attempt to load the parameters.
                SqlParameter[] ArrParam = new SqlParameter[23];
                // Assign values to the parameters.
                ArrParam[0] = new SqlParameter("@departmentId", oProduct.DepartmentId);
                ArrParam[1] = new SqlParameter("@barcodeNo", oProduct.BarcodeNo);
                ArrParam[2] = new SqlParameter("@name", oProduct.ProductName);
                ArrParam[3] = new SqlParameter("@ticketType", oProduct.Ticket);
                ArrParam[4] = new SqlParameter("@shortcode", oProduct.ShortCode);
                ArrParam[5] = new SqlParameter("@description", oProduct.ProductDescription);
                ArrParam[6] = new SqlParameter("@brand", oProduct.ProductBrand);
                ArrParam[7] = new SqlParameter("@madeIn", oProduct.ProductMadeIn);
                ArrParam[8] = new SqlParameter("@weight", oProduct.ProductWeight);
                ArrParam[9] = new SqlParameter("@isGstItem", oProduct.IsGstItem);
                ArrParam[10] = new SqlParameter("@isexpireable", oProduct.IsExpirable);
                ArrParam[11] = new SqlParameter("@unitCost", oProduct.UnitCost);
                ArrParam[12] = new SqlParameter("@unitPrice", oProduct.UnitPrice);
                ArrParam[13] = new SqlParameter("@promoUnitPrice", oProduct.PromoUnitPrice);

                if (oProduct.PromoStartDate != DateTime.MinValue)
                    ArrParam[14] = new SqlParameter("@promoStartDate", oProduct.PromoStartDate);
                else
                    ArrParam[14] = new SqlParameter("@promoStartDate", System.DBNull.Value);

                if (oProduct.PromoEndDate != DateTime.MinValue)
                    ArrParam[15] = new SqlParameter("@promoEndDate", oProduct.PromoEndDate);
                else
                    ArrParam[15] = new SqlParameter("@promoEndDate", System.DBNull.Value);

                ArrParam[16] = new SqlParameter("@unitMeasure", oProduct.UnitMeasureId);
                ArrParam[17] = new SqlParameter("@qtyInStock", oProduct.QtyInStock);
                ArrParam[18] = new SqlParameter("@qtyInOrder", oProduct.QtyInorder);
                ArrParam[19] = new SqlParameter("@minQty", oProduct.MinQty);
                if (oProduct.Image != null)
                {
                    ArrParam[20] = new SqlParameter("@productImage", oProduct.Image);
                }
                else
                {
                    //byte[] imagedata=System.DBNull.Value;
                    ArrParam[20] = new SqlParameter("@productImage", SqlDbType.Image);
                    ArrParam[20].Value = DBNull.Value;
                    ArrParam[20].IsNullable = true;
                } 
                ArrParam[21] = new SqlParameter("@updatedBy", oProduct.UpdatedBy);
                ArrParam[22] = new SqlParameter("@productId", oProduct.ProductId);

                // Execute the SQL statement.
                int iResult =Convert.ToInt16( SqlHelper.ExecuteScalar(objPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, ArrParam));
                // Commit the transaction.
                objTrans.Commit();
                return iResult;
            }
            catch (Exception exp)
            {
                // Rollback the transaction if there is any error
                objTrans.Rollback();
                return 0;
            }
            finally
            {
                // Closing the database connection
                DataConnection.Close();
            }
        }

        /// <summary>
        /// Implementation of IProductModel.getDepartmentList
        /// Gets all the department in a store
        /// Returns a DataSet
        /// </summary>
        /// <returns>A DataSet containing all the department in a store</returns>
        public DataSet getDepartmentList(int SacnNoScanStatus)
        {

            // Read the runtime setup.
            POSConfiguration setting = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                setting.getConnectionstring(),
                SQL_FIND_ALL_DEPT
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_NON_SCAN_STATUS, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    setting.getConnectionstring(),
                    SQL_FIND_ALL_DEPT,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = SacnNoScanStatus;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                setting.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_ALL_DEPT, parms
                );
        }

        /// <summary>
        /// Implementation of IProductModel.getUnitMeasurementList
        /// Gets all the department in a store
        /// Returns a DataSet
        /// </summary>
        /// <returns>A DataSet containing all the measurement in a store</returns>
        public DataSet getUnitMeasurementList()
        {

            // Read the runtime setup.
            POSConfiguration setting = new POSConfiguration();
            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                setting.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_ALL_MSRMENT
                );
        }

        /// <summary>
        ///  Implementation of IProductModel.getItemlist 
        /// </summary>
        /// <param name="iCategoryId"></param>
        /// <returns></returns>
        public DataSet getItemlist(int iCategoryId)
        {
            // Read the runtime setup.
            POSConfiguration setting = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                setting.getConnectionstring(),
                SQL_FIND_PRODUCT_BY_DEPARTMENT
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_DEPARTMENT_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    setting.getConnectionstring(),
                    SQL_FIND_PRODUCT_BY_DEPARTMENT,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iCategoryId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                setting.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_PRODUCT_BY_DEPARTMENT,
                parms
                );

        }

        /// <summary>
        /// Implementation of IProductModel.getItemlistBy_Category_ItemName 
        /// </summary>
        /// <param name="iStatus"></param>
        /// <param name="iCategoryId"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        public DataSet getItemlistBy_Category_ItemName(int iStatus, int iCategoryId, string sName)
        {
            // Read the runtime setup.
            POSConfiguration setting = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                setting.getConnectionstring(),
                SQL_FIND_PRODUCT_BY_DEPARTMENT_OR_NameofItem
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_STATUS, SqlDbType.Int),
                    new SqlParameter(PARAM_DEPARTMENT_ID, SqlDbType.Int),
			        new SqlParameter(PARM_PRODUCT_NAME, SqlDbType.VarChar, 30)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    setting.getConnectionstring(),
                    SQL_FIND_PRODUCT_BY_DEPARTMENT_OR_NameofItem,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iStatus;
            parms[1].Value = iCategoryId;
            parms[2].Value = sName;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                setting.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_PRODUCT_BY_DEPARTMENT_OR_NameofItem,
                parms
                );
        }

        /// <summary>
        ///  Implementation of IProductModel.getAllItems 
        /// </summary>
        /// <param name="iCategoryId"></param>
        /// <returns></returns>
        public DataSet getAllItems()
        {
            // Read the runtime setup.
            POSConfiguration setting = new POSConfiguration();

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(setting.getConnectionstring(), CommandType.StoredProcedure, SQL_GET_ALL_ITEMS);
        }

        /// <summary>
        /// Implementation of IProductModel.getProductById
        /// </summary>
        /// <param name="iProductId"></param>
        /// <returns></returns>
        public DataSet getProductById(int iProductId)
        {
            // Read the runtime setup.
            POSConfiguration setting = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                setting.getConnectionstring(),
                SQL_FIND_BY_PRODUCT_ID
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_PRODUCT_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    setting.getConnectionstring(),
                    SQL_FIND_BY_PRODUCT_ID,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iProductId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                setting.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_BY_PRODUCT_ID,
                parms
                );

        }

        /// <summary>
        /// Implementation of IProductModel.getProductListByDepartmentNBarcode
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentID"></param>
        /// <returns></returns>
        public DataSet getProductListByDepartmentNBarcode(string sSearchText,int iDepartmentId)
        { 
            // Read the runtime setup.
			POSConfiguration oPosConnection=new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Attempt to load the parameters.
			SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
				oPosConnection.getConnectionstring(),
				SQL_FIND_PRODUCT_BY_BARCODE_AND_DEPT
				);

			// Did we fail?
			if (parms == null)
			{

				// Create the parameters.
				parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_PRODUCT_BARCODE, SqlDbType.VarChar, 50),
                    new SqlParameter(PARAM_DEPARTMENT_ID, SqlDbType.VarChar, 50)
			
				};

				// Store the parameters in the cache.
				SqlHelperParameterCache.CacheParameterSet(
					oPosConnection.getConnectionstring(),
                    SQL_FIND_PRODUCT_BY_BARCODE_AND_DEPT, 
					parms
					);

			} // End if we failed to load the parameters.

			// Assign values to the parameters.
			parms[0].Value = sSearchText;
            parms[1].Value=iDepartmentId;

			// Execute the SQL statement.
			return SqlHelper.ExecuteDataset(
                oPosConnection.getConnectionstring(),
				CommandType.StoredProcedure,
                SQL_FIND_PRODUCT_BY_BARCODE_AND_DEPT, 
				parms
				);
		}

        /// <summary>
        ///  Implementation of IProductModel.getProductListByDepartmentNName
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentId"></param>
        /// <returns></returns>
        public DataSet getProductListByDepartmentNName(string sSearchText,int iDepartmentId)
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                oPosConnection.getConnectionstring(),
                SQL_FIND_PRODUCT_BY_NAME_AND_DEPT
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
				new SqlParameter(PARAM_DEPARTMENT_ID, SqlDbType.VarChar, 50),
                new SqlParameter(PARM_PRODUCT_NAME, SqlDbType.VarChar, 50)
			
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_FIND_PRODUCT_BY_NAME_AND_DEPT,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iDepartmentId;
            parms[1].Value = sSearchText;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                oPosConnection.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_PRODUCT_BY_NAME_AND_DEPT,
                parms
                );
        }
        
        /// <summary>
        /// Implementation of IProductModel.getProductListByDepartmentNBrand
        /// </summary>
        /// <param name="sSearchText"></param>
        /// <param name="iDepartmentId"></param>
        /// <returns></returns>
        public DataSet getProductListByDepartmentNBrand(string sSearchText,int iDepartmentId)
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                oPosConnection.getConnectionstring(),
                SQL_FIND_PRODUCT_BY_BRAND_AND_DEPT
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_PRODUCT_BRAND, SqlDbType.VarChar, 50),
                    new SqlParameter(PARAM_DEPARTMENT_ID, SqlDbType.VarChar, 50)
			
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_FIND_PRODUCT_BY_BRAND_AND_DEPT,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = sSearchText;
            parms[1].Value = iDepartmentId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
               oPosConnection.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_PRODUCT_BY_BRAND_AND_DEPT,
                parms
                );
        
        }

        /// <summary>
        /// Implementation of IProductModel.getVegetableList
        /// </summary>
        /// <param name="iDepartmentId"></param>
        /// <returns></returns>
        public DataSet getVegetableList(int  iDepartmentId)
        {
            DataSet dsReturn = new DataSet();

            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();
            SqlConnection DataConnection = new SqlConnection(oPOSConfig.getConnectionstring());

            try
            {
                DataConnection.Open();
                SqlParameter[] ArrParam = new SqlParameter[1];
                // Assign values to the parameters.
                ArrParam[0] = new SqlParameter(PARAM_DEPARTMENT_ID, iDepartmentId);

                // Execute the SQL statement.
                dsReturn = SqlHelper.ExecuteDataset(DataConnection, CommandType.StoredProcedure, SQL_FIND_PRODUCT_BY_DEPARTMENT, ArrParam);
            }
            catch
            {
                dsReturn = null;
            }
            finally
            {
                DataConnection.Close();
            }
            return dsReturn;
        }

        /// <summary>
        /// Implementation of IProductModel.getFruitList
        /// </summary>
        /// <param name="iDepartmentId"></param>
        /// <returns></returns>
        public DataSet getFruitList(int iDepartmentId)
        {
            DataSet dsFruitList;

            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            SqlConnection sqlCon = new SqlConnection(oPOSConfig.getConnectionstring());

            try
            {
                sqlCon.Open();
                SqlParameter[] ArrParam = new SqlParameter[1];
                ArrParam[0] = new SqlParameter(PARAM_DEPARTMENT_ID, iDepartmentId);
                dsFruitList = SqlHelper.ExecuteDataset(sqlCon, CommandType.StoredProcedure, SQL_FIND_PRODUCT_BY_DEPARTMENT, ArrParam);
            }
            catch
            {
                dsFruitList = null;
            }
            finally
            {
                sqlCon.Close();
            
            }
            return dsFruitList;
        }

        /// <summary>
        /// Implementation of IProductModel.getProductListByBarcode
        /// </summary>
        /// <param name="sBarcode"></param>
        /// <returns></returns>
        public DataSet getProductListByBarcode(string sBarcode)
        {
            
            
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                oPOSConfig.getConnectionstring(),
                SQL_FIND_PRODUCT_BY_BRACODE
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_PRODUCT_BARCODE, SqlDbType.VarChar, 50)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    oPOSConfig.getConnectionstring(),
                    SQL_FIND_PRODUCT_BY_BRACODE,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value =sBarcode;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
               oPOSConfig.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_PRODUCT_BY_BRACODE,
                parms
                );
        }

        /// <summary>
        /// Implementation of IProductModel.addPurchaseMain
        /// Used to insert values in purchase main table
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
        /// <returns>purchase id</returns>
        public int addPurchaseMain(DateTime dDeliveryDate, int iSupplierId, double dTotalCost, DateTime dEnteredAt, int iEnteredBy)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_PURCHASE_MAIN);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_DELIVERY_DATE, SqlDbType.SmallDateTime),
					new SqlParameter(PARM_SUPPLIER_ID, SqlDbType.Int),
                    new SqlParameter(PARM_TOTAL_COST, SqlDbType.Float),
					new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
					new SqlParameter(PARM_PURCHASE_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_PURCHASE_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_PURCHASE_MAIN, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = dDeliveryDate;
            parms[1].Value = iSupplierId;
            parms[2].Value = dTotalCost;
            parms[3].Value = iEnteredBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD_PURCHASE_MAIN, parms);

            // Return the identity value.
            return int.Parse(parms[4].Value.ToString());
        }

        /// <summary>
        /// Implementation of IProductModel.addPurchaseDetails
        /// Used to insert values in purchase details table
        /// </summary>
        /// <param name="iPurchaseId"></param>
        /// <param name="iProductId"></param>
        /// <param name="iQty"></param>
        /// <param name="dUnitPrice"></param>
        /// <param name="dExpireDate"></param>
        public void addPurchaseDetails(int iPurchaseId, int iProductId, int iQty, double dUnitPrice, DateTime dExpireDate)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_PURCHASE_DETAILS);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_PURCHASE_ID, SqlDbType.Int),
					new SqlParameter(PARM_PRODUCT_ID, SqlDbType.Int),
					new SqlParameter(PARM_PURCHASE_QUANTITY, SqlDbType.Int),
					new SqlParameter(PARM_UNIT_COST, SqlDbType.Float),
					new SqlParameter(PARM_EXPIRE_DATE, SqlDbType.DateTime)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_PURCHASE_DETAILS, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iPurchaseId;
            parms[1].Value = iProductId;
            parms[2].Value = iQty;
            parms[3].Value = dUnitPrice;
            parms[4].Value = dExpireDate;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD_PURCHASE_DETAILS, parms);
        }

        public int addDamageMain(string sRemarks, DateTime dEnteredAt, int iEnteredBy)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_DAMAGE_MAIN);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_DAMAGE_REMARKS, SqlDbType.VarChar, 200),
					new SqlParameter(PARM_ENTERED_TIME, SqlDbType.DateTime),
					new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
					new SqlParameter(PARM_DAMAGE_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_DAMAGE_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_DAMAGE_MAIN, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = sRemarks;
            parms[1].Value = dEnteredAt;
            parms[2].Value = iEnteredBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD_DAMAGE_MAIN, parms);

            // Return the identity value.
            return (int)parms[3].Value;
        }

        public void addDamageDetails(int iDamageId, int iProductId, int iQty, double dUnitCost, string sDescription)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_DAMAGE_DETAILS);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_DAMAGE_ID, SqlDbType.Int),
					new SqlParameter(PARM_PRODUCT_ID, SqlDbType.Int),
					new SqlParameter(PARM_DAMAGE_QTY, SqlDbType.Int),
					new SqlParameter(PARM_UNIT_COST, SqlDbType.Float),
					new SqlParameter(PARM_DAMAGE_DESCRIPTION, SqlDbType.VarChar, 200)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_ADD_DAMAGE_DETAILS, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iDamageId;
            parms[1].Value = iProductId;
            parms[2].Value = iQty;
            parms[3].Value = dUnitCost;
            parms[4].Value = sDescription;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD_DAMAGE_DETAILS, parms);
        }

        /// <summary>
        /// Used to get list of all items according to its ticket
        /// </summary>
        /// <returns></returns>
        public DataSet getItemsByTicket(bool bTicket, int iCategoryId)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_FIND_PRODUCT_BY_TICKET);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_CATEGORY_ID, SqlDbType.Int),
                    new SqlParameter(PARM_TICKET_ID, SqlDbType.Bit)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_FIND_PRODUCT_BY_TICKET, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iCategoryId;
            parms[1].Value = bTicket;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_PRODUCT_BY_TICKET, parms);
        }

        /// <summary>
        /// Used to get Department wise gross net profit
        /// </summary>
        /// <returns></returns>
        public DataSet getProfitByDepartment(int iDeptId, DateTime dFrom, DateTime dTo)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_FIND_PROFIT_BY_DEPT);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_DEPARTMENT_ID, SqlDbType.Int),
                    new SqlParameter(PARM_FROM, SqlDbType.DateTime),
                	new SqlParameter(PARM_TO, SqlDbType.DateTime)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_FIND_PROFIT_BY_DEPT, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iDeptId;
            parms[1].Value = dFrom;
            parms[2].Value = dTo;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_PROFIT_BY_DEPT, parms);
        }
        /// <summary>
        /// Returns the generated Barcode for non scan Item
        /// </summary>
        /// <returns></returns>
        public string getNonScanId()
        {
            string sNonscanId;
            try
            {
                // Read the runtime setup.
                POSConfiguration oPOSConfig = new POSConfiguration();
                // Execute the SQL statement.
                sNonscanId = SqlHelper.ExecuteScalar(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_GET_NONSCAN_ID).ToString();
            }
            catch (Exception xcp)
            {
                sNonscanId = null;
            }
            return sNonscanId;
        }

    }
}
