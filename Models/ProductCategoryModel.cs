using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Models
{
    class ProductCategoryModel:IProductCategoryModel
    {

        // *******************************************************************
        // Attributes.
        // *******************************************************************

        #region Attributes.

        /// <summary>
        /// The SQL to add a supplier.
        /// </summary>
        private static readonly string SQL_ADD =
            "ritpos_add_product_category";

        /// <summary>
        /// The SQL to delete a supplier.
        /// </summary>
        private static readonly string SQL_DELETE =
            "ritpos_delete_product_category";

        /// <summary>
        /// The SQL to update a supplier.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_product_category";

        
        /// <summary>
        /// The SQL to find a supplier by id(primary key).
        /// </summary>
        private static readonly string SQL_FIND_BY_ID = "ritpos_product_category_find_by_id";

        /// <summary>
        /// The SQL to find suppliers like given name.
        /// </summary>
        private static readonly string SQL_FIND_BY_NAME =
            "ritpos_product_category_find_all";

        /// <summary>
        /// Various parameter names.
        /// </summary>
        /// deptName,description,enteredtime,enteredby,SacnNoScanStatus
        private static readonly string PARM_CATEGORY_ID = "@categoryId";
        private static readonly string PARM_DEPT_NAME = "@deptName";
        private static readonly string PARM_DESCRIPTION = "@description";
        private static readonly string PARM_SCAN_NON_SCAN_STATUS = "@ScanNonScanStatus";
        
        private static readonly string PARM_ENTERED_BY = "@enteredBy";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        #endregion

        // ******************************************************************
        // IProductCategoryManager implementation.
        // ******************************************************************
        #region Implementation of IProductCategoryManager Members

        /// <summary>
        /// Implementation of ISupplierModel.getSupplierById method
        /// </summary>
        public SqlDataReader getProductCategoryById(int iProductCategoryId)
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
					new SqlParameter(PARM_CATEGORY_ID, SqlDbType.Int),
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iProductCategoryId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_ID, parms);
        }

        /// <summary>
        /// Implementation of ISupplierModel.getSupplierListLikeName method
        /// </summary>
        public DataSet getProductCategoryListLikeName(string sName)
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
					new SqlParameter(PARM_DEPT_NAME, SqlDbType.VarChar, 50),
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
        /// Implementation of IProductCategoryModel.addProductCategory
        /// </summary>
        public int addProductCategory(CDepartment oCDepartment)
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
					new SqlParameter(PARM_DEPT_NAME, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_DESCRIPTION, SqlDbType.VarChar, 200),
                    new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
                    new SqlParameter(PARM_SCAN_NON_SCAN_STATUS, SqlDbType.Int),
					
					new SqlParameter(PARM_CATEGORY_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_CATEGORY_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_ADD, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCDepartment.DepartmentName;
            parms[1].Value = oCDepartment.Description;
            parms[2].Value = oCDepartment.EnteredBy;
            parms[3].Value = oCDepartment.ScanNonScanStatus;
                        
            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms);

            // Return the identity value.
            return (Int32)parms[4].Value;
        }

        /// <summary>
        /// Implementation of ISupplierModel.updateSupplier
        /// </summary>
        public void updateProductCategory(CDepartment oCDepartment)
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
					new SqlParameter(PARM_DEPT_NAME, SqlDbType.VarChar, 100),
					new SqlParameter(PARM_DESCRIPTION, SqlDbType.VarChar, 200),
                    new SqlParameter(PARM_UPDATED_BY, SqlDbType.Int),
                    new SqlParameter(PARM_SCAN_NON_SCAN_STATUS, SqlDbType.Int),
					new SqlParameter(PARM_CATEGORY_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCDepartment.DepartmentName;
            parms[1].Value = oCDepartment.Description;
            parms[2].Value = oCDepartment.UpdatedBy;
            parms[3].Value = oCDepartment.ScanNonScanStatus;
            parms[4].Value = oCDepartment.CategoryId;
            
            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }

        /// <summary>
        /// Implementation of ISupplierModel.deleteSupplier
        /// </summary>
        public int deleteProductCategory(CDepartment oCDepartment)
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
                    new SqlParameter(PARM_CATEGORY_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_DELETE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCDepartment.CategoryId;

            // Execute the SQL statement.
            returnval = Convert.ToInt16(SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_DELETE, parms));
            return returnval;
        }

        #endregion
    }
}
