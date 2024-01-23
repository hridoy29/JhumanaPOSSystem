using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Models
{
    class CustomerModel:ICustomerModel
    {
        // *******************************************************************
        // Attributes.
        // *******************************************************************

        #region Attributes.

        /// <summary>
        /// The SQL to add a customer.
        /// </summary>
        private static readonly string SQL_ADD =
            "ritpos_add_customer";

        /// <summary>
        /// The SQL to delete a customer.
        /// </summary>
        private static readonly string SQL_DELETE =
            "ritpos_delete_customer";

        /// <summary>
        /// The SQL to update a customer.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_customer";

        /// <summary>
        /// The SQL to find all customer.
        /// </summary>
        private static readonly string SQL_FIND_ALL =
            "ritpos_find_all_customer";

        /// <summary>
        /// The SQL to find a customer by id(primary key).
        /// </summary>
        private static readonly string SQL_FIND_BY_ID =
            "ritpos_find_customer_by_id";
        
        /// <summary>
        /// The SQL to find a customer by id(primary key).
        /// </summary>
        private static readonly string SQL_FIND_BY_BarCode =
            "ritpos_find_customer_by_barcode";
        
        /// <summary>
        /// The SQL to find customer like given name.
        /// </summary>
        private static readonly string SQL_FIND_BY_NAME =
            "ritpos_find_customer_by_name";

        /// <summary>
        /// Various parameter names.
        /// </summary>
        private static readonly string PARM_CUSTOMER_ID = "@customerId";
        private static readonly string PARM_CUSTOMER_BarCodeNo = "@CustomerIDBarCodeNo";
        private static readonly string PARM_CUSTOMER_NAME = "@Name";
        private static readonly string PARM_STREET_NO = "@street_no";
        private static readonly string PARM_SUBURB = "@suburb";
        private static readonly string PARM_CITY = "@city";
        private static readonly string PARM_STATE = "@state";
        private static readonly string PARM_POSTCODE = "@postcode";
        private static readonly string PARM_COUNTRY = "@country";
        private static readonly string PARM_MOBILE = "@mobile";
        private static readonly string PARM_HOMEPHONE = "@homephone";
        private static readonly string PARM_SEX = "@sex";
        private static readonly string PARM_WORKPHONE = "@workphone";

        private static readonly string PARM_ENTERED_BY = "@enteredBy";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        #endregion

        
        // ******************************************************************
        // ICustomerManager implementation.
		// ******************************************************************

        #region Implementation of ICustomerModel Members
        public CustomerModel()
        {
        }

        /// <summary>
        /// Implementation of ICustomerModel.getCustomerList method
        /// </summary>
        public DataSet getCustomerList()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_ALL);
        }

        /// <summary>
        /// Implementation of ICustomerModel.getCustomerListLikeName method
        /// </summary>
        public DataSet getCustomerListLikeName(string sName)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_FIND_BY_NAME);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_CUSTOMER_NAME, SqlDbType.VarChar, 100),
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_NAME, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = sName;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_NAME, parms);
        }

        /// <summary>
        /// Implementation of ICustomerModel.getCustomerByBarCode method
        /// </summary>
        public SqlDataReader getCustomerByBarCode(string sCustomerBarCode)
        {
            try
            {
                // Read the runtime setup.
                POSConfiguration settings = new POSConfiguration();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_FIND_BY_BarCode);

                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_CUSTOMER_BarCodeNo, SqlDbType.NVarChar),
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_BarCode, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = sCustomerBarCode;

                // Execute the SQL statement.
                return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_BarCode, parms);
            }
            catch (Exception xcp)
            {
                return null;
            }
        }

        /// <summary>
        /// Implementation of ICustomerModel.getCustomerById method
        /// </summary>
        public SqlDataReader getCustomerById(int iCustomerId)
        {
            try
            {
                // Read the runtime setup.
                POSConfiguration settings = new POSConfiguration();

                // Attempt to load the parameters.
                SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID);

                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_CUSTOMER_ID, SqlDbType.Int),
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = iCustomerId;

                // Execute the SQL statement.
                return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_ID, parms);
            }
            catch (Exception xcp)
            {
                return null;
            }
        }

        /// <summary>
        /// Implementation of ICustomerModel.addCustomer
        /// </summary>
        public int addCustomer(Customer oCustomer)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_ADD);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                    new SqlParameter(PARM_CUSTOMER_BarCodeNo, SqlDbType.VarChar, 30),
					new SqlParameter(PARM_CUSTOMER_NAME, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_STREET_NO, SqlDbType.VarChar, 200),
                    new SqlParameter(PARM_SUBURB, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_STATE, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_POSTCODE, SqlDbType.VarChar, 100),
	                new SqlParameter(PARM_COUNTRY, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_MOBILE, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_HOMEPHONE, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_SEX, SqlDbType.Bit),
                    new SqlParameter(PARM_WORKPHONE, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
					new SqlParameter(PARM_CUSTOMER_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_CUSTOMER_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_ADD, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCustomer.CustomerBarCode;
            parms[1].Value = oCustomer.CustomerName;
            parms[2].Value = oCustomer.Street_no;
            parms[3].Value = oCustomer.Suburb;
            parms[4].Value = oCustomer.State;
            parms[5].Value = oCustomer.Postcode;

            parms[6].Value = oCustomer.Country;
            parms[7].Value = oCustomer.Mobile;
            parms[8].Value = oCustomer.Homephone;
            parms[9].Value = oCustomer.Sex;
            parms[10].Value = oCustomer.Workphone;
            parms[11].Value = oCustomer.EnteredBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms);

            // Return the identity value.
            return (Int32)parms[12].Value;
        }

        /// <summary>
        /// Implementation of ICustomerModel.deleteCustomer
        /// </summary>
        public int deleteCustomer(Customer oCustomer)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();
            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_DELETE);
            int returnval;
            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
                    new SqlParameter(PARM_CUSTOMER_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_DELETE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCustomer.CustomerId;

            // Execute the SQL statement.
            returnval=Convert.ToInt16( SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_DELETE, parms));
            return returnval;
        }

        /// <summary>
        /// Implementation of ICustomerModel.updateCustomer
        /// </summary>
        public void updateCustomer(Customer oCustomer)
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
                    
                    new SqlParameter(PARM_CUSTOMER_BarCodeNo, SqlDbType.VarChar, 30),
                    new SqlParameter(PARM_CUSTOMER_NAME, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_STREET_NO, SqlDbType.VarChar, 200),
                    new SqlParameter(PARM_SUBURB, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_STATE, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_POSTCODE, SqlDbType.VarChar, 100),
	                new SqlParameter(PARM_COUNTRY, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_MOBILE, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_HOMEPHONE, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_SEX, SqlDbType.Bit),
                    new SqlParameter(PARM_WORKPHONE, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_UPDATED_BY, SqlDbType.Int),
					new SqlParameter(PARM_CUSTOMER_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.

            parms[0].Value = oCustomer.CustomerBarCode;
            parms[1].Value = oCustomer.CustomerName;
            parms[2].Value = oCustomer.Street_no;
            parms[3].Value = oCustomer.Suburb;
            parms[4].Value = oCustomer.State;
            parms[5].Value = oCustomer.Postcode;

            parms[6].Value = oCustomer.Country;
            parms[7].Value = oCustomer.Mobile;
            parms[8].Value = oCustomer.Homephone;
            parms[9].Value = oCustomer.Sex;
            parms[10].Value = oCustomer.Workphone;
            parms[11].Value = oCustomer.UpdatedBy;
            parms[12].Value = oCustomer.CustomerId;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }
        #endregion

    }
}
