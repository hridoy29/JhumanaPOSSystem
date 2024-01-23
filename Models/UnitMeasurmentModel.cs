using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Models
{
    class UnitMeasurmentModel: IUnitMeasurmentModel
    {
        // *******************************************************************
        // Attributes.
        // *******************************************************************

        #region Attributes.

        /// <summary>
        /// The SQL to add a supplier.
        /// </summary>
        private static readonly string SQL_ADD =
            "ritpos_add_unit_measurment";

        /// <summary>
        /// The SQL to delete a supplier.
        /// </summary>
        private static readonly string SQL_DELETE =
            "ritpos_delete_unit_measurment";

        /// <summary>
        /// The SQL to update a supplier.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_unit_measurment";

        /// <summary>
        /// The SQL to find all supplier.
        /// </summary>
        private static readonly string SQL_FIND_ALL =
            "[ritpos_measurement_find_all]";

        /// <summary>
        /// The SQL to find a supplier by id(primary key).
        /// </summary>
        private static readonly string SQL_FIND_BY_ID = "ritpos_unit_measurment_find_by_id";

        /// <summary>
        /// The SQL to find suppliers like given name.
        /// </summary>
        private static readonly string SQL_FIND_BY_NAME =
            "ritpos_product_category_find_all";

        /// <summary>
        /// Various parameter names.
        /// </summary>        
        private static readonly string PARM_MEASUREMENT_ID = "@unitMeasureId";
        private static readonly string PARM_MEASUREMENT_NAME = "@UnitMeasureName";
        
        private static readonly string PARM_ENTERED_BY = "@enteredBy";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        #endregion

        // ******************************************************************
        // IUnitMeasurmentManager implementation.
        // ******************************************************************
        #region Implementation of IUnitMeasurment Manager Members

        /// <summary>
        /// Implementation of IUnitMeasurmentModel.getSupplierById method
        /// </summary>
        public SqlDataReader getUnitMeasurmentById(int iUnitMeasurmentId)
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
                    new SqlParameter(PARM_MEASUREMENT_ID, SqlDbType.Int),
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iUnitMeasurmentId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_ID, parms);
        }

        /// <summary>
        /// Implementation of IUnitMeasurmentModel.getUnitMeasurment method
        /// </summary>
        public DataSet getUnitMeasurmentList()
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_ALL);
        }
        /// <summary>
        /// Implementation of IProductCategoryModel.addProductCategory
        /// </summary>
        public int addUnitMeasurment(CUnitMeasurement oCUnitMeasurement)
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
					new SqlParameter(PARM_MEASUREMENT_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
                    
					new SqlParameter(PARM_MEASUREMENT_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_MEASUREMENT_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_ADD, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCUnitMeasurement.Name;            
            parms[1].Value = oCUnitMeasurement.EnteredBy;
            
            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms);

            // Return the identity value.
            return (Int32)parms[2].Value;
        }

        /// <summary>
        /// Implementation of IUnitMeasurmentModel.updateUnitMeasurment
        /// </summary>
        public void updateUnitMeasurment(CUnitMeasurement oCUnitMeasurement)
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
					new SqlParameter(PARM_MEASUREMENT_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_UPDATED_BY, SqlDbType.Int),
                    new SqlParameter(PARM_MEASUREMENT_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCUnitMeasurement.Name;
            parms[1].Value = oCUnitMeasurement.UpdatedBy;
            parms[2].Value = oCUnitMeasurement.Id;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }

        /// <summary>
        /// Implementation of IUnitMeasurment.deleteUnitMeasurment
        /// </summary>
        public int deleteUnitMeasurment(CUnitMeasurement oCUnitMeasurement)
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
                    new SqlParameter(PARM_MEASUREMENT_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_DELETE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCUnitMeasurement.Id;

            // Execute the SQL statement.
            returnval = Convert.ToInt16(SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_DELETE, parms));
            return returnval;
        }

        #endregion
    }
}
