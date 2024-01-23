using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;


namespace POSsible.Models
{
    class CustomerInvoiceModel: ICustomerInvoiceModel
    {
        // *******************************************************************
        // Attributes.
        // *******************************************************************

        #region Attributes.

        
        /// <summary>
        /// The SQL to update a customer invoice.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_customer_invoice";

        /// <summary>
        /// The SQL to Create Invoice Customer
        /// </summary>
        private static readonly string SQL_CREATE_CUSTOMER_INVOICE = "ritpos_create_customer_invoice";


        /// <summary>
        /// The SQL to find a customer claim point list.
        /// </summary>
        private static readonly string SQL_CUSTOMER_CLAIM_POINT_LIST =
            "ritpos_get_customer_claim_point";


        /// <summary>
        /// The SQL to find a customer invoice list by barcode.
        /// </summary>
        private static readonly string SQL_FIND_BY_CUSTOMERBARCODE = 
            "ritpos_get_customer_invoice_by_customerbarcode";

        /// <summary>
        /// The SQL to find a customer invoice/point/claimed point Search by barcode, name, postcode.
        /// </summary>
        private static readonly string SQL_FIND_CUSTOMER_POINT_BY_BARCODE_NAME =
            "ritpos_get_customer_point";


        /// <summary>
        /// Various parameter names.
        /// </summary>        
        private static readonly string PARM_CUSTOMER_BARCODE= "@CustomerIDBarCodeNo";
        private static readonly string PARM_INVOICE_ID = "@invoiceId";
        private static readonly string PARM_EARN_POINTS = "@pointsEarned";
        private static readonly string PARM_CUSTOMER_INVOICE_AMOUNT = "@invoiceAmount";
        private static readonly string PARM_CUSTOMER_INVOICE_CLAIMPOINT = "@claimPoint";
        private static readonly string PARM_CLAIM_POINT = "@claimPoint";
        private static readonly string PARM_SEARCH_OPTION = "@Searchoption";
        private static readonly string PARM_SEARCH_TEXT = "@SearchText";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        private static readonly string PARM_ENTERED_BY = "@enteredby";


        
        #endregion

        // ******************************************************************
        // ICustomer Invoice Manager implementation.
        // ******************************************************************
        #region Implementation of ICustomer Invoice Manage Members

        /// <summary>
        /// Implementation of ICustomerInvoiceModel.getInvoiceListByCustomer method
        /// </summary>
        public DataSet getInvoiceListByCustomer(string sCustomerBarcode)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_FIND_BY_CUSTOMERBARCODE);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
                {
                    new SqlParameter(PARM_CUSTOMER_BARCODE, SqlDbType.NVarChar,50),
                };

                // Store the parameters in the cache.
                //SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_CUSTOMERBARCODE, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = sCustomerBarcode;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_CUSTOMERBARCODE,parms);
        }

        /// <summary>
        /// Customer Point Claim list
        /// </summary>
        /// <returns></returns>
        public DataSet getCustomerClaimPointList()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
                        
            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_CUSTOMER_CLAIM_POINT_LIST);
        }
        
        /// <summary>
        /// Implementation of IUnitMeasurmentModel.updateUnitMeasurment
        /// </summary>
        public void updateCustomerInvoice(CCustomerInvoice oCCustomerInvoice)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_UPDATE);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
                {
                    new SqlParameter(PARM_INVOICE_ID, SqlDbType.Int),
                    new SqlParameter(PARM_EARN_POINTS, SqlDbType.Float),
                    new SqlParameter(PARM_CLAIM_POINT, SqlDbType.Float),
                    new SqlParameter(PARM_CUSTOMER_BARCODE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_UPDATED_BY, SqlDbType.Int)
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCCustomerInvoice.InvoiceId;
            parms[1].Value = oCCustomerInvoice.PointsEarned;
            parms[2].Value = 0;
            parms[3].Value = oCCustomerInvoice.CustomerBarCode;
            parms[4].Value = oCCustomerInvoice.UpdatedBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }



        /// <summary>
        /// Implementation of ICustomerInvoiceModel.getCustomerClaimPointList method
        /// </summary>
        public DataSet getCustomerClaimPointList(int iSOption, string strSearchText)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_FIND_BY_CUSTOMERBARCODE);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
                {
                    new SqlParameter(PARM_SEARCH_OPTION, SqlDbType.SmallInt),
                    new SqlParameter(PARM_SEARCH_TEXT, SqlDbType.NVarChar,50),
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_CUSTOMER_POINT_BY_BARCODE_NAME, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iSOption;
            parms[1].Value = strSearchText;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_CUSTOMER_POINT_BY_BARCODE_NAME, parms);
        }

        /// <summary>
        /// Customer Claim Point Insert
        /// </summary>
        /// <param name="oCCustomerInvoice"></param>
        public void createCustomerClaimPoint(List<CCustomerInvoice> oCCustomerInvoice)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_CREATE_CUSTOMER_INVOICE);

            for (int i = 0; i < oCCustomerInvoice.Count; i++)
            {
                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
                    new SqlParameter (PARM_INVOICE_ID,SqlDbType.Int), 
                    new SqlParameter (PARM_CUSTOMER_INVOICE_AMOUNT,SqlDbType.Float),                                                 
                    new SqlParameter (PARM_EARN_POINTS,SqlDbType.Float), 
                    new SqlParameter (PARM_CLAIM_POINT,SqlDbType.Float), 
                    new SqlParameter (PARM_CUSTOMER_BARCODE,SqlDbType.NVarChar,50),                    
                
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_CREATE_CUSTOMER_INVOICE, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = 0;
                parms[1].Value = 0;
                parms[2].Value = 0;
                parms[3].Value = oCCustomerInvoice[i].PointsEarned;
                parms[4].Value = oCCustomerInvoice[i].CustomerBarCode;
                
                // Execute the SQL statement.
                SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_CREATE_CUSTOMER_INVOICE, parms);
            }
        }

        #endregion
    }
}
