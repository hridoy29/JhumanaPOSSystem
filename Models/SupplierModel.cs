using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Models
{
    /// <summary>
    /// SupplierModel implementation.  To work with this use the Factory to 
    /// obtain an instantiated version of IProductModel
    /// </summary>
    class SupplierModel:ISupplierModel
    {
        // *******************************************************************
        // Attributes.
        // *******************************************************************

        #region Attributes.

        /// <summary>
        /// The SQL to add a supplier.
        /// </summary>
        private static readonly string SQL_ADD =
            "ritpos_add_supplier";

        /// <summary>
        /// The SQL to delete a supplier.
        /// </summary>
        private static readonly string SQL_DELETE =
            "ritpos_delete_supplier";

        /// <summary>
        /// The SQL to update a supplier.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_supplier";

        /// <summary>
        /// The SQL to find all supplier.
        /// </summary>
        private static readonly string SQL_FIND_ALL =
            "ritpos_find_all_supplier";

        /// <summary>
        /// The SQL to find a supplier by id(primary key).
        /// </summary>
        private static readonly string SQL_FIND_BY_ID =
            "ritpos_find_supplier_by_id";

        /// <summary>
        /// The SQL to find suppliers like given name.
        /// </summary>
        private static readonly string SQL_FIND_BY_NAME =
            "ritpos_find_supplier_by_name";

        /// <summary>
        /// Various parameter names.
        /// </summary>
        private static readonly string PARM_SUPPLIER_ID = "@supplierId";
        private static readonly string PARM_SUPPLIER_NAME = "@supplierName";
        private static readonly string PARM_TRADING_AS = "@tradingAs";
        private static readonly string PARM_ABN = "@abn";
        private static readonly string PARM_SUPPLIER_ADDRESS = "@supplierAddress";
        private static readonly string PARM_CONTACT_NAME = "@contactName";
        private static readonly string PARM_PHONE_NO = "@phoneNo";

        private static readonly string PARM_EMAIL = "@email";
        private static readonly string PARM_WEBADD = "@webadd";
        private static readonly string PARM_COMMENTS = "@comments";

        private static readonly string PARM_ENTERED_BY = "@enteredBy";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        #endregion

        
        // ******************************************************************
		// ISupplierManager implementation.
		// ******************************************************************

        #region Implementation of ISupplierManager Members
        public SupplierModel()
        {
        }

        /// <summary>
        /// Implementation of ISupplierModel.getSupplierList method
        /// </summary>
        public DataSet getSupplierList()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_ALL);
        }

        /// <summary>
        /// Implementation of ISupplierModel.getSupplierListLikeName method
        /// </summary>
        public DataSet getSupplierListLikeName(string sName)
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
					new SqlParameter(PARM_SUPPLIER_NAME, SqlDbType.VarChar, 50),
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
        /// Implementation of ISupplierModel.getSupplierById method
        /// </summary>
        public SqlDataReader getSupplierById(int iSupplierId)
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
					new SqlParameter(PARM_SUPPLIER_ID, SqlDbType.Int),
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iSupplierId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_ID, parms);
        }

        /// <summary>
        /// Implementation of ISupplierModel.addSupplier 
        /// </summary>
        public int addSupplier(Supplier oSupplier)
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
					new SqlParameter(PARM_SUPPLIER_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_TRADING_AS, SqlDbType.VarChar, 1000),
                    new SqlParameter(PARM_ABN, SqlDbType.VarChar, 250),
					new SqlParameter(PARM_SUPPLIER_ADDRESS, SqlDbType.VarChar, 200),
                    new SqlParameter(PARM_CONTACT_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_PHONE_NO, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_EMAIL, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_WEBADD, SqlDbType.VarChar, 250),
					new SqlParameter(PARM_COMMENTS, SqlDbType.VarChar, 250),
                    new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
					new SqlParameter(PARM_SUPPLIER_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_SUPPLIER_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_ADD, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oSupplier.SupplierName;
            parms[1].Value = oSupplier.TradingAs;
            parms[2].Value = oSupplier.ABN;
            parms[3].Value = oSupplier.SupplierAddress;
            parms[4].Value = oSupplier.ContactName;
            parms[5].Value = oSupplier.PhoneNo;
            parms[6].Value = oSupplier.email;
            parms[7].Value = oSupplier.webadd;
            parms[8].Value = oSupplier.comments;
            parms[9].Value = oSupplier.EnteredBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms);

            // Return the identity value.
            return (Int32)parms[10].Value;
        }

        /// <summary>
        /// Implementation of ISupplierModel.deleteSupplier
        /// </summary>
        public int deleteSupplier(Supplier oSupplier)
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
                    new SqlParameter(PARM_SUPPLIER_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_DELETE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oSupplier.SupplierId;

            // Execute the SQL statement.
            returnval=Convert.ToInt16( SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_DELETE, parms));
            return returnval;
        }

        /// <summary>
        /// Implementation of ISupplierModel.updateSupplier
        /// </summary>
        public void updateSupplier(Supplier oSupplier)
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
					new SqlParameter(PARM_SUPPLIER_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_TRADING_AS, SqlDbType.VarChar, 1000),
                    new SqlParameter(PARM_ABN, SqlDbType.VarChar, 250),
					new SqlParameter(PARM_SUPPLIER_ADDRESS, SqlDbType.VarChar, 200),
                    new SqlParameter(PARM_CONTACT_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_PHONE_NO, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_EMAIL, SqlDbType.VarChar, 100),
                    new SqlParameter(PARM_WEBADD, SqlDbType.VarChar, 250),
					new SqlParameter(PARM_COMMENTS, SqlDbType.VarChar, 250),
                    new SqlParameter(PARM_UPDATED_BY, SqlDbType.Int),
					new SqlParameter(PARM_SUPPLIER_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oSupplier.SupplierName;
            parms[1].Value = oSupplier.TradingAs;
            parms[2].Value = oSupplier.ABN;
            parms[3].Value = oSupplier.SupplierAddress;
            parms[4].Value = oSupplier.ContactName;
            parms[5].Value = oSupplier.PhoneNo;
            parms[6].Value = oSupplier.email;
            parms[7].Value = oSupplier.webadd;
            parms[8].Value = oSupplier.comments;
            parms[9].Value = oSupplier.UpdatedBy;

            parms[10].Value = oSupplier.SupplierId;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }
        #endregion
    }
}
