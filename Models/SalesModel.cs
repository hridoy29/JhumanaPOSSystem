using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public class SalesModel : ISalesModel
    {
        #region ProductModel attributes
        /// <summary>
        /// The SQL to store Shift Information.
        /// </summary>
        private static readonly string SQL_STORE_SHIFT_INFORMATION =
            "ritpos_store_shift_information";

        /// <summary>
        /// The SQL to update Shift Information.
        /// </summary>
        private static readonly string SQL_UPDATE_SHIFT_INFORMATION =
            "ritpos_update_shift_information";

        /// <summary>
        /// The SQL to update LoginTable.
        /// </summary>
        private static readonly string SQL_UPDATE_LOGIN = "ritpos_update_login";

        /// <summary>
        /// The SQL to Store SafeDrop Information
        /// </summary>
        private static readonly string SQL_STORE_SAFEDROP_INFORMATION = "ritpos_store_safedrop_information";

        /// <summary>
        /// The SQL to Create Invoice
        /// </summary>
        private static readonly string SQL_CREATE_INVOICE = "ritpos_create_invoice";

        /// <summary>
        /// The SQL to Create Invoice Payment
        /// </summary>
        private static readonly string SQL_CREATE_INVOICE_PAYMENT = "ritpos_create_invoice_payment";

        /// <summary>
        /// The SQL to Create Invoice Product
        /// </summary>
        private static readonly string SQL_CREATE_INVOICE_PRODUCT = "ritpos_create_invoice_product";

        /// <summary>
        /// The SQL to Create Invoice Customer
        /// </summary>
        private static readonly string SQL_CREATE_CUSTOMER_INVOICE = "ritpos_create_customer_invoice";


        private static readonly string SQL_FIND_PRODUCTS_BY_INVOICE_ID = "ritpos_Invoice_Poducts_find_by_InvoiceId";
        private static readonly string SQL_FIND_INVOICE_BY_INVOICE_ID = "ritpos_Invoice_find_by_InvoiceId";

        private static readonly string SQL_FIND_INVOICE_ID_BY_DATETIME = "ritpos_Invoice_find_by_datetime";
        private static readonly string SQL_GET_LAST_INVOICE = "ritpos_get_last_invoice";

        //private static readonly string SQL_GET_INVOICE_AND_PAYMENT_BY_DATE_DIFF = "ritpos_get_invoice_and_payment_by_datediff";

        private static readonly string SQL_INVOICE_PAYMENT_BY_INVOICE_ID = "ritpos_invoice_payment_by_invoice_id";

        private static readonly string SQL_STORE_REFUND = "ritpos_store_refund";

        private static readonly string SQL_GET_INFO_FROM_GLOBAL = "ritpos_get_info_from_global";
        private static readonly string SQL_UPDATE_NOSALE = "ritpos_update_NoSales";
        private static readonly string SQL_GET_CASH_IN_DRAWER = "ritpos_shift_cashindrawer";                   
        
        /// <summary>
        /// Various parameter names.
        /// </summary>
        private static readonly string PARM_SHIFT_NAME = "@shiftName";
        private static readonly string PARM_USER_ID = "@userId";
        //private static readonly string PARM_START_TIME = "@startTime";
        //private static readonly string PARM_END_TIME = "@sndTime";
        private static readonly string PARM_START_MONEY = "@startMoney";
        private static readonly string PARM_END_MONEY = "@EndMoney";
        private static readonly string PARM_SHIFT_ID = "@shiftId";
        private static readonly string PARM_USER_LOGIN_ID = "@UserLoginId";
        private static readonly string PARM_USER_TERMINAL = "@UserTerminal";
        // private static readonly string PARM_SAFEDROP_TIME = "@safeDropTime";
        private static readonly string PARM_SAFEDROP_AMOUNT = "@safeDropMoney";

        private static readonly string PARM_INVOICE_ID = "@invoiceId";
        private static readonly string PARM_CUSTOMER_BARCODE = "@CustomerIDBarCodeNo";
        private static readonly string PARM_CUSTOMER_INVOICE_AMOUNT = "@invoiceAmount";        
        private static readonly string PARM_CUSTOMER_INVOICE_POINTEARNED = "@pointsEarned";
        private static readonly string PARM_CUSTOMER_INVOICE_CLAIMPOINT = "@claimPoint";

        private static readonly string PARM_CUSTOMER_ID = "@customerId";        
        private static readonly string PARM_INVOICE_DATE = "@invoiceDate";

        private static readonly string PARM_TOTAL_PRICE = "@totalPrice";
        private static readonly string PARM_TOATL_GST = "@totalGst";
        private static readonly string PARM_CHANGE_GIVEN = "@changeGiven";
        private static readonly string PARM_DISCOUNT_GIVEN = "@discountGiven";
        private static readonly string PARM_DISCOUNT_AUTHORIZED_ID = "@disCountAuthorizedId";
        private static readonly string PARM_INVOICE_DESCRIPTION = "@description";
        private static readonly string PARM_INVOICE_STATUS = "@status";
        private static readonly string PARM_INVOICE_UPDATED_TIME = "@updatedTime";
        private static readonly string PARM_INVOICE_UPDATED_BY = "@updatedBy";


        private static readonly string PARM_PAYMENT_TYPE = "@paymentType";
        private static readonly string PARM_CASH_AMOUNT = "@cashAmount";
        private static readonly string PARM_CARD_AMOUNT = "@cardAmount";
        private static readonly string PARM_PAYMENT_METHOD_ID = "@paymentMethodId";
        private static readonly string PARM_INVOICE_ENTERED_TIME = "@enteredTime";

        private static readonly string PARM_PRODUCT_ID = "@productId";
        private static readonly string PARM_PRODUCT_QUANTITY = "@productQuantity";
        private static readonly string PARM_PRODUCT_UNIT_PRICE = "@unitPrice";

        private static readonly string PARAM_INVOICE_ID = "@invoiceId";
        private static readonly string PARAM_INVOICE_DATETIME = "@FindDate";
        private static readonly string PARAM_INVOICE_STARTTIME = "@StartTime";
        private static readonly string PARAM_INVOICE_ENDTIME = "@EndTime";

        private static readonly string PARM_AUTHORIZED_BY = "@authorizedBy";
        private static readonly string PARM_REFUNDED_BY = "@refundedBy";
        private static readonly string PARM_REFUNDED_METHOD = "@refundedMethod";
        private static readonly string PARM_UPDATED_TIME = "@updatedTime";
        private static readonly string PARM_ENTERED_TIME = "@enteredTime";
        private static readonly string PARM_REFUND_ID = "@refundid";


        private static readonly string PARAM_DISCOUNT_TEXT = "@discountText";
        #endregion

        public SalesModel()
        { }


        /// <summary>
        /// Implementation of ISalesModel.storeShiftInformation
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        public int storeShiftInformation(CUser oUser, double dStartMoney)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_STORE_SHIFT_INFORMATION);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                        new SqlParameter (PARM_SHIFT_NAME,SqlDbType.VarChar,100),
                        new SqlParameter (PARM_USER_ID,SqlDbType.Int),                                                                     
                        new SqlParameter (PARM_START_MONEY,SqlDbType.Float),
                        new SqlParameter (PARM_USER_LOGIN_ID,SqlDbType.Int),
                        new SqlParameter (PARM_USER_TERMINAL,SqlDbType.VarChar,200)
                        
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_STORE_SHIFT_INFORMATION, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = "";
            parms[1].Value = oUser.UserID;
            parms[2].Value = dStartMoney;
            parms[3].Value = oUser.UserLoginId;
            parms[4].Value = oUser.userTerminal;


            // Execute the SQL statement.
            object objShiftId = 5;//SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_STORE_SHIFT_INFORMATION, parms);
            int iShiftId = Int32.Parse(objShiftId.ToString());
            //SqlDataReader reader = SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_STORE_SHIFT_INFORMATION, parms);
            //reader.Read();
            //int iShiftId = (int)reader["ShifId"];
            return iShiftId;
        }

        /// <summary>
        /// Implementation of ISalesModel.updateShiftInformation
        /// </summary>
        /// <param name="oShift"></param>
        /// <returns></returns>
        public int updateShiftInformation(CUser oUser, double dAmount)
        {
            try
            {
                // Read the runtime setup.
                POSConfiguration settings = new POSConfiguration();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_UPDATE_SHIFT_INFORMATION);

                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
                        new SqlParameter (PARM_SHIFT_ID,SqlDbType.VarChar,100),
                        new SqlParameter (PARM_USER_ID,SqlDbType.Int),                                                                                               
                        new SqlParameter (PARM_END_MONEY,SqlDbType.Float)
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE_SHIFT_INFORMATION, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = oUser.ShiftId;
                parms[1].Value = oUser.UserID;
                parms[2].Value = dAmount;


                // Execute the SQL statement.
                return SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE_SHIFT_INFORMATION, parms);

            }
            catch (Exception xcp)
            {
                return -1;
            }
        }

        /// <summary>
        /// Implementation of ISalesModel.updateTblLogin4StartShift
        /// </summary>
        /// <param name="oShift"></param>
        /// <param name="iShiftId"></param>
        public void updateTblLogin4StartShift(CUser oUser)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_UPDATE_LOGIN);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                          new SqlParameter (PARM_USER_ID,SqlDbType.Int), 
                          new SqlParameter (PARM_SHIFT_ID,SqlDbType.Int)
                          
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE_LOGIN, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oUser.UserID;
            parms[1].Value = oUser.ShiftId;



            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE_LOGIN, parms);


        }

        /// <summary>
        /// Implementation of ISalesModel.storeSafeDropInformation 
        /// </summary>
        /// <param name="oShift"></param>
        /// <param name="dtSafeDrop"></param>
        /// <param name="dAmount"></param>
        /// <param name="iShiftIdSafefund"></param>
        public void storeSafeDropInformation(CUser oUser, double dAmount)
        {
            // Read the runtime setup.
            try
            {
                POSConfiguration settings = new POSConfiguration();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_STORE_SAFEDROP_INFORMATION);

                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
                        new SqlParameter (PARM_SHIFT_ID,SqlDbType.Int),
                        new SqlParameter (PARM_USER_ID,SqlDbType.Int),                        
                                        
                        new SqlParameter (PARM_SAFEDROP_AMOUNT,SqlDbType.Float)
                        
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_STORE_SAFEDROP_INFORMATION, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = oUser.ShiftId;
                parms[1].Value = oUser.UserID;
                parms[2].Value = dAmount;


                // Execute the SQL statement.
                SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_STORE_SAFEDROP_INFORMATION, parms);
            }
            catch (Exception oEx)
            { 
            }

        }

        /// <summary>
        /// Implementation of ISalesModel.createInvoice 
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <returns></returns>
        public int createInvoice(CInvoice oInvoice)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_CREATE_INVOICE);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                    new SqlParameter (PARM_SHIFT_ID,SqlDbType.Int),
                    new SqlParameter (PARM_USER_ID,SqlDbType.Int),                                                                     
                    new SqlParameter (PARM_CUSTOMER_ID,SqlDbType.Int),
                    new SqlParameter (PARM_INVOICE_DATE,SqlDbType.DateTime), 
                    new SqlParameter ( PARM_TOTAL_PRICE,SqlDbType.Float),
                    new SqlParameter ( PARM_TOATL_GST,SqlDbType.Float),
                    new SqlParameter (PARM_CHANGE_GIVEN,SqlDbType.Float),
                    new SqlParameter ( PARM_DISCOUNT_GIVEN,SqlDbType.Float),
                    new SqlParameter (PARM_DISCOUNT_AUTHORIZED_ID,SqlDbType.Int),
                    new SqlParameter (PARM_INVOICE_DESCRIPTION,SqlDbType.VarChar,100),
                    new SqlParameter (PARM_INVOICE_STATUS,SqlDbType.VarChar,100),
                    new SqlParameter(PARM_INVOICE_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_INVOICE_ID, DataRowVersion.Current, null)
		
                    //new SqlParameter (PARM_INVOICE_UPDATED_TIME,SqlDbType.DateTime),
                    //new SqlParameter (PARM_INVOICE_UPDATED_BY,SqlDbType.Int),
                    //new SqlParameter (PARM_PAYMENT_TYPE,SqlDbType.Int),
                    
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_CREATE_INVOICE, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oInvoice.ShiftId;
            parms[1].Value = oInvoice.UserId;
            parms[2].Value = oInvoice.CustomerId;
            parms[3].Value = oInvoice.InvoiceDate;
            parms[4].Value = oInvoice.TotalPrice;
            parms[5].Value = oInvoice.TotalGst;
            parms[6].Value = oInvoice.ChangeGiven;
            parms[7].Value = oInvoice.DiscountGiven;
            parms[8].Value = oInvoice.DisCountAuthorizedId;
            parms[9].Value = oInvoice.Description;
            parms[10].Value = oInvoice.Status;
            //parms[11].Value = oInvoice.UpdatedTime;
            //parms[11].Value = oInvoice.UpdatedBy;

            // Execute the SQL statement.
            int retval = SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_CREATE_INVOICE, parms);
            int iInvoiceId = int.Parse(parms[11].Value.ToString());
            return iInvoiceId;

        }

        /// <summary>
        /// Implementation of ISalesModel.createInvoicePayment 
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <param name="iInvoiceId"></param>
        public void createInvoicePayment(CInvoice oInvoice, int iInvoiceId)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_CREATE_INVOICE_PAYMENT);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                    
                    new SqlParameter (PARM_INVOICE_ID,SqlDbType.Int),                                                                     
                    new SqlParameter (PARM_PAYMENT_TYPE,SqlDbType.Int),
                    new SqlParameter (PARM_CARD_AMOUNT,SqlDbType.Float), 
                    new SqlParameter (PARM_CASH_AMOUNT,SqlDbType.Float),
                    new SqlParameter (PARM_SHIFT_ID,SqlDbType.Int),
                   // new SqlParameter (PARM_INVOICE_ENTERED_TIME,SqlDbType.DateTime),
                    //new SqlParameter (PARM_INVOICE_UPDATED_TIME,SqlDbType.DateTime),
                    
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_CREATE_INVOICE_PAYMENT, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            //parms[0].Value = oInvoice.PaymentMethodId;
            parms[0].Value = iInvoiceId;
            parms[1].Value = oInvoice.PaymentType;
            parms[2].Value = oInvoice.CardAmount;
            parms[3].Value = oInvoice.CashAmount;
            parms[4].Value = oInvoice.ShiftId;

            //parms[5].Value = oInvoice.EnteredTime;                     
            //parms[6].Value = oInvoice.UpdatedTime;

            // Execute the SQL statement.
            SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_CREATE_INVOICE_PAYMENT, parms);

        }

        /// <summary>
        /// Implementation of ISalesModel.createInvoiceCustomer 
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <param name="iInvoiceId"></param>
        public void createCustomerInvoice(CInvoice oInvoice, int iInvoiceId)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_CREATE_CUSTOMER_INVOICE);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
			    {                
                new SqlParameter (PARM_INVOICE_ID,SqlDbType.Int), 
                new SqlParameter (PARM_CUSTOMER_INVOICE_AMOUNT,SqlDbType.Float),                                                 
                new SqlParameter (PARM_CUSTOMER_INVOICE_POINTEARNED,SqlDbType.Float), 
                new SqlParameter (PARM_CUSTOMER_INVOICE_CLAIMPOINT,SqlDbType.Float), 
                new SqlParameter ( PARM_CUSTOMER_BARCODE,SqlDbType.NVarChar,50),                    
                
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_CREATE_CUSTOMER_INVOICE, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iInvoiceId;
            parms[1].Value = oInvoice.TotalPrice;
            parms[2].Value = 1 * oInvoice.TotalPrice;
            parms[3].Value = 0;
            parms[4].Value = oInvoice.CustomerBarCode;
            

            // Execute the SQL statement.
            SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_CREATE_CUSTOMER_INVOICE, parms);
            
        }

        /// <summary>
        /// Implementation of ISalesModel.createInvoiceProduct 
        /// </summary>
        /// <param name="oInvoice"></param>
        /// <param name="iInvoiceId"></param>
        public void createInvoiceProduct(CInvoice oInvoice, int iInvoiceId)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_CREATE_INVOICE_PRODUCT);

            for (int i = 0; i < oInvoice.Product.Count; i++)
            {
                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
                    
                    new SqlParameter (PARM_INVOICE_ID,SqlDbType.Int), 
                    new SqlParameter (PARM_PRODUCT_ID,SqlDbType.Int),                                                 
                    new SqlParameter (PARM_PRODUCT_QUANTITY,SqlDbType.Float),
                    new SqlParameter (PARM_PRODUCT_UNIT_PRICE,SqlDbType.Float),
                    new SqlParameter (PARM_TOATL_GST,SqlDbType.Float),
                    new SqlParameter ( PARM_INVOICE_STATUS,SqlDbType.VarChar,100),
                    //new SqlParameter ( PARM_INVOICE_ENTERED_TIME,SqlDbType.DateTime),
                    //new SqlParameter (PARM_INVOICE_UPDATED_TIME,SqlDbType.DateTime)
                    
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_CREATE_INVOICE_PRODUCT, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = iInvoiceId;
                parms[1].Value = oInvoice.Product[i].ProductId;
                parms[2].Value = oInvoice.Product[i].QtyInorder;
                parms[3].Value = oInvoice.Product[i].UnitPrice;
                // MinQty use Just for GST Per Item
                parms[4].Value = oInvoice.Product[i].MinQty;
                parms[5].Value = oInvoice.Status;                

                // Execute the SQL statement.
                SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_CREATE_INVOICE_PRODUCT, parms);
            }
        }

        public DataSet getInvoiceProductById(int iInvoicId)
        {
            DataSet rtDataSet = new DataSet();

            try
            {
                // Read the runtime setup.
                POSConfiguration oPosConnection = new POSConfiguration();
                //oPosConnection.getConnectionstring();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_FIND_PRODUCTS_BY_INVOICE_ID
                    );

                // Did we fail?
                if (parms == null)
                {

                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_INVOICE_ID, SqlDbType.VarChar, 50),
                
			
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(
                        oPosConnection.getConnectionstring(),
                        SQL_FIND_PRODUCTS_BY_INVOICE_ID,
                        parms
                        );

                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = iInvoicId;

                // Execute the SQL statement.
                rtDataSet = SqlHelper.ExecuteDataset(
                    oPosConnection.getConnectionstring(),
                    CommandType.StoredProcedure,
                    SQL_FIND_PRODUCTS_BY_INVOICE_ID,
                    parms
                    );
            }
            catch (Exception ex)
            {
            }

            return rtDataSet;
        }

        public DataSet getInvoiceById(int iInvoicId)
        {
            DataSet rtDataSet = new DataSet();

            try
            {
                // Read the runtime setup.
                POSConfiguration oPosConnection = new POSConfiguration();
                //oPosConnection.getConnectionstring();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_FIND_INVOICE_BY_INVOICE_ID
                    );

                // Did we fail?
                if (parms == null)
                {

                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
					new SqlParameter(PARAM_INVOICE_ID, SqlDbType.VarChar, 50),
                
			
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(
                        oPosConnection.getConnectionstring(),
                        SQL_FIND_INVOICE_BY_INVOICE_ID,
                        parms
                        );

                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = iInvoicId;

                // Execute the SQL statement.
                rtDataSet = SqlHelper.ExecuteDataset(
                    oPosConnection.getConnectionstring(),
                    CommandType.StoredProcedure,
                    SQL_FIND_INVOICE_BY_INVOICE_ID,
                    parms
                    );
            }
            catch (Exception ex)
            {
            }

            return rtDataSet;
        }

        public DataSet getInvoiceIdByDateTime(DateTime dtInvoiceDate, TimeSpan tsStartTime, TimeSpan tsEndTime)
        {
            DataSet rtDataSet = new DataSet();
            try
            {
                // Read the runtime setup.
                POSConfiguration oPosConnection = new POSConfiguration();
                //oPosConnection.getConnectionstring();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_FIND_INVOICE_ID_BY_DATETIME
                    );

                // Did we fail?
                if (parms == null)
                {

                    // Create the parameters.
                    parms = new SqlParameter[] 
				    {
					    new SqlParameter(PARAM_INVOICE_DATETIME, SqlDbType.DateTime),
                        new SqlParameter(PARAM_INVOICE_STARTTIME, SqlDbType.DateTime),
			            new SqlParameter(PARAM_INVOICE_ENDTIME, SqlDbType.DateTime),
				    };

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(
                        oPosConnection.getConnectionstring(),
                        SQL_FIND_INVOICE_ID_BY_DATETIME,
                        parms
                        );

                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                //tsStartTime = new TimeSpan(0, 0, 0);
                //tsEndTime = new TimeSpan(23, 59, 59);

                parms[0].Value = dtInvoiceDate;
                parms[1].Value = dtInvoiceDate.Add(tsStartTime);
                parms[2].Value = dtInvoiceDate.Add(tsEndTime);

                // Execute the SQL statement.
                rtDataSet = SqlHelper.ExecuteDataset(
                    oPosConnection.getConnectionstring(),
                    CommandType.StoredProcedure,
                    SQL_FIND_INVOICE_ID_BY_DATETIME,
                    parms
                    );
            }
            catch (Exception ex)
            {
                rtDataSet = null;
            }

            return rtDataSet;
        }

        public void createRefund(CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_STORE_REFUND);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                    new SqlParameter (PARM_INVOICE_ID,SqlDbType.Int),
                    new SqlParameter (PARM_AUTHORIZED_BY,SqlDbType.Int),                                                                                          
                    new SqlParameter (PARM_REFUNDED_BY,SqlDbType.Int),
                    new SqlParameter (PARM_REFUNDED_METHOD,SqlDbType.VarChar,50),
                    new SqlParameter (PARM_REFUND_ID,SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_STORE_REFUND, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oInvoice.InvoiceId;
            parms[1].Value = oAuthorizedUser.UserID;
            parms[2].Value = oLoginUser.UserID;
            parms[3].Value = oInvoice.RefundMethod;
            parms[4].Value = 0;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_STORE_REFUND, parms);


        }

        public void storeRefund(List<CProduct> lstProducts, CInvoice oInvoice, CUser oLoginUser, CUser oAuthorizedUser)
        {
            // Read the runtime setup.
            POSConfiguration objPOSConfig = new POSConfiguration();

            // Declare the objects for database transaction and connection
            SqlTransaction objTrans = null;
            SqlConnection DataConnection = new SqlConnection(objPOSConfig.getConnectionstring());

            try
            {
                int iResult = 0;
                DataConnection.Open();
                // Begin the database transaction
                objTrans = DataConnection.BeginTransaction();

                // Let's store the refund information

                // Attempt to load the parameters.
                //SqlParameter[] ArrParam = new SqlParameter[5];

                SqlParameter[] ArrParam = new SqlParameter[] 
				{
                    new SqlParameter (PARM_INVOICE_ID,SqlDbType.Int),
                    new SqlParameter (PARM_AUTHORIZED_BY,SqlDbType.Int),                                                                                          
                    new SqlParameter (PARM_REFUNDED_BY,SqlDbType.Int),
                    new SqlParameter (PARM_REFUNDED_METHOD,SqlDbType.VarChar,50),
                    new SqlParameter (PARM_REFUND_ID,SqlDbType.Int)
				};

                // Assign values to the parameters.
                ArrParam[0].Value = oInvoice.InvoiceId;
                ArrParam[1].Value = oAuthorizedUser.UserID;
                ArrParam[2].Value = oLoginUser.UserID;
                ArrParam[3].Value = oInvoice.RefundMethod;
                
                ArrParam[4].Value = 0;
                ArrParam[4].Direction = ParameterDirection.Output;

                // Execute the SQL statement.

                iResult = SqlHelper.ExecuteNonQuery(objPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_STORE_REFUND, ArrParam);
                
                // End of storing the refund information

                if (lstProducts.Count > 0 && iResult == 1)
                {
                    // Let's store the refund products information

                    foreach (CProduct ObjProject in lstProducts)
                    {
                        // Attempt to load the parameters.
                        //SqlParameter[] aParams = new SqlParameter[6];

                        SqlParameter[] aParams = new SqlParameter[] 
				        {
                            new SqlParameter ("@RefundId",SqlDbType.Int),
                            new SqlParameter ("@productId",SqlDbType.Int),                                                                                          
                            new SqlParameter ("@qty",SqlDbType.Int),
                            new SqlParameter ("@UnitPrice",SqlDbType.Float),
                            new SqlParameter ("@description",SqlDbType.VarChar,200),
                            new SqlParameter ("@enteredby",SqlDbType.Int)
				        };

                        // Assign values to the parameters.
                        aParams[0].DbType = DbType.Int32;
                        aParams[0].Value = (Int32)ArrParam[4].Value;

                        aParams[1].Value = ObjProject.ProductId;
                        aParams[2].Value = ObjProject.QtyInorder;
                        aParams[3].Value = ObjProject.UnitPrice;
                        aParams[4].Value = "";
                        aParams[5].Value = oLoginUser.UserID;

                        // Execute the SQL statement.

                        iResult = SqlHelper.ExecuteNonQuery(objPOSConfig.getConnectionstring(), CommandType.StoredProcedure, "ritpos_store_refund_product", aParams);

                        aParams = null;
                        // End of storing the refund products information
                    }
                    // Commit the transaction.
                    objTrans.Commit();
                }
                else
                {
                    // Rollback the transaction if there is any error
                    objTrans.Rollback();
                }
            }
            catch (Exception exp)
            {
                // Rollback the transaction if there is any error
                objTrans.Rollback();
            }
            finally
            {
                // Closing the database connection
                DataConnection.Close();
            }
        }

        public DataSet getDiscountInfo(string sDiscount)
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();

            // Execute the SQL statement.
            DataSet dsGlobal = SqlHelper.ExecuteDataset(
                oPosConnection.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_GET_INFO_FROM_GLOBAL

                );
            return dsGlobal;
        }

        public void updateNoSale(CUser loggedinuser)
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                oPosConnection.getConnectionstring(),
                SQL_UPDATE_NOSALE
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_USER_LOGIN_ID, SqlDbType.VarChar, 50),
                
			
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_UPDATE_NOSALE,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = loggedinuser.UserLoginId;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(
                oPosConnection.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_UPDATE_NOSALE,
                parms
                );


        }

        public DataSet getLastInvoice()
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                 oPosConnection.getConnectionstring(),
                 CommandType.StoredProcedure,
                 SQL_GET_LAST_INVOICE

                 );


        }

        public DataSet getInvoicePaymentById(int iInvoiceId)
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                oPosConnection.getConnectionstring(),
                SQL_INVOICE_PAYMENT_BY_INVOICE_ID
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_INVOICE_ID, SqlDbType.VarChar, 50),
                
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_INVOICE_PAYMENT_BY_INVOICE_ID,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iInvoiceId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                    oPosConnection.getConnectionstring(),
                    CommandType.StoredProcedure,
                    SQL_INVOICE_PAYMENT_BY_INVOICE_ID,
                    parms
                    );

        }
        /// <summary>
        /// Get Cash amount in drawer
        /// </summary>
        /// <returns></returns>
        public double getChashinDrawer(int iShifId)
        {
            try
            {
                // Read the runtime setup.
                POSConfiguration oPosConnection = new POSConfiguration();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_GET_CASH_IN_DRAWER
                    );

                // Did we fail?
                if (parms == null)
                {

                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_SHIFT_ID, SqlDbType.Int),
                
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(
                        oPosConnection.getConnectionstring(),
                        SQL_GET_CASH_IN_DRAWER,
                        parms
                        );

                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = iShifId;

                // Execute the SQL statement.
                return Convert.ToDouble(
                                        SqlHelper.ExecuteScalar(
                                        oPosConnection.getConnectionstring(),
                                        CommandType.StoredProcedure,
                                        SQL_GET_CASH_IN_DRAWER,parms)
                                        );

            }
            catch (Exception xcp)
            {
                return -1;
            }
        }
    }
}
