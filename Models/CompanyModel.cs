using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Models
{
    class CompanyModel: ICompanyModel
    {
        // *******************************************************************
        // Attributes.
        // *******************************************************************

        #region Attributes.

        /// <summary>
        /// The SQL to add a supplier.
        /// </summary>
        private static readonly string SQL_ADD =
            "ritpos_add_company_info";

        /// <summary>
        /// The SQL to delete a supplier.
        /// </summary>
        private static readonly string SQL_DELETE =
            "ritpos_delete_unit_measurment";

        /// <summary>
        /// The SQL to update a supplier.
        /// </summary>
        private static readonly string SQL_UPDATE =
            "ritpos_update_company_info";
                
        /// <summary>
        /// The SQL to find a supplier by id(primary key).
        /// </summary>
        private static readonly string SQL_FIND_BY_ID = "ritpos_get_company_info_by_id";
                
        /// <summary>
        /// Various parameter names.
        /// </summary>        
        private static readonly string PARM_COMPANY_CODE = "@Companycode";
        private static readonly string PARM_COMPANY_NAME = "@CompanyName";
        private static readonly string PARM_ABN = "@ABN";
        private static readonly string PARM_ADDRESS_LINE1 = "@AddressLine1";
        private static readonly string PARM_ADDRESS_LINE2 = "@AddressLine2";
        private static readonly string PARM_CITY = "@City";
        private static readonly string PARM_STATE = "@State";
        private static readonly string PARM_COUNTRY_NAME = "CountryName";
        private static readonly string PARM_POST_CODE = "@PostCode";
        private static readonly string PARM_PHONE = "@Phone";
        private static readonly string PARM_FAX = "@Fax";
        private static readonly string PARM_EMAIL = "@Email";
        private static readonly string PARM_WEB = "@Web";
        private static readonly string PARM_MISSIONSTATEMENT = "@MissionStatement";
        private static readonly string PARM_LOGO = "@Logo";


        private static readonly string PARM_ENTERED_BY = "@enteredBy";
        private static readonly string PARM_UPDATED_BY = "@updatedBy";
        #endregion

        // ******************************************************************
        // ICompany Manager implementation.
        // ******************************************************************
        #region Implementation of ICompany Manager Members

        /// <summary>
        /// Implementation of ICompany.getCompanyById method
        /// </summary>
        public SqlDataReader getCompanyById(int iCompanyId)
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
                    new SqlParameter(PARM_COMPANY_CODE, SqlDbType.TinyInt),
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iCompanyId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_ID, parms);
        }

        
        /// <summary>
        /// Implementation of ICompany.addCompany
        /// </summary>
        public int addCompany(CCompany oCCompany)
        {
            // Read the runtime setup.
            POSConfiguration settings = new POSConfiguration();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_ADD);

            try
            {
                // Did we fail?
                if (parms == null)
                {
                    // Create the parameters.
                    parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_COMPANY_NAME, SqlDbType.NVarChar, 75),
					new SqlParameter(PARM_ABN, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_ADDRESS_LINE1, SqlDbType.NVarChar,250),
                    new SqlParameter(PARM_ADDRESS_LINE2, SqlDbType.NVarChar,250),
                    new SqlParameter(PARM_CITY, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_STATE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_COUNTRY_NAME, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_POST_CODE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_PHONE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_FAX, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_EMAIL, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_WEB, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_MISSIONSTATEMENT, SqlDbType.NVarChar,150),
                    new SqlParameter(PARM_LOGO, SqlDbType.Image),
                    new SqlParameter(PARM_ENTERED_BY, SqlDbType.Int),
                    
					new SqlParameter(PARM_COMPANY_CODE, SqlDbType.TinyInt, 0, ParameterDirection.Output, false, 0, 0, PARM_COMPANY_CODE, DataRowVersion.Current, null)
				};

                    // Store the parameters in the cache.
                    SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_ADD, parms);
                } // End if we failed to load the parameters.

                // Assign values to the parameters.
                parms[0].Value = oCCompany.CompanyName;
                parms[1].Value = oCCompany.ABN;
                parms[2].Value = oCCompany.AddressLine1;
                parms[3].Value = oCCompany.AddressLine2;
                parms[4].Value = oCCompany.City;
                parms[5].Value = oCCompany.State;
                parms[6].Value = oCCompany.CountryName;
                parms[7].Value = oCCompany.PostCode;
                parms[8].Value = oCCompany.Phone;
                parms[9].Value = oCCompany.Fax;
                parms[10].Value = oCCompany.Email;
                parms[11].Value = oCCompany.Web;
                parms[12].Value = oCCompany.MissionStatement;
                parms[13].Value = oCCompany.Image;
                parms[14].Value = oCCompany.EnteredBy;

                //parms[1].Value = oCUnitMeasurement.EnteredBy;

                // Execute the SQL statement.
                //SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms);
                int iResult = Convert.ToInt16(SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms));
                // Commit the transaction.
                //oProduct.ProductId = (int)ArrParam[22].Value;
                //objTrans.Commit();
                return iResult;
            }
            catch (Exception exp)
            {
                // Rollback the transaction if there is any error
                ///objTrans.Rollback();
                return 0;
            }
            finally
            {
                // Closing the database connection
                //DataConnection.Close();
            }

        }

        /// <summary>
        /// Implementation of ICompanyModel.updateCompany
        /// </summary>
        public void updateCompany(CCompany oCCompany)
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
                    new SqlParameter(PARM_COMPANY_CODE, SqlDbType.TinyInt),
                    new SqlParameter(PARM_COMPANY_NAME, SqlDbType.NVarChar, 75),
					new SqlParameter(PARM_ABN, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_ADDRESS_LINE1, SqlDbType.NVarChar,250),
                    new SqlParameter(PARM_ADDRESS_LINE2, SqlDbType.NVarChar,250),
                    new SqlParameter(PARM_CITY, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_STATE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_COUNTRY_NAME, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_POST_CODE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_PHONE, SqlDbType.NVarChar,50),
                    new SqlParameter(PARM_FAX, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_EMAIL, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_WEB, SqlDbType.NVarChar,30),
                    new SqlParameter(PARM_MISSIONSTATEMENT, SqlDbType.NVarChar,150),
                    new SqlParameter(PARM_LOGO, SqlDbType.Image),
                    new SqlParameter(PARM_UPDATED_BY, SqlDbType.Int)
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCCompany.Companycode;
            parms[1].Value = oCCompany.CompanyName;
            parms[2].Value = oCCompany.ABN;
            parms[3].Value = oCCompany.AddressLine1;
            parms[4].Value = oCCompany.AddressLine2;
            parms[5].Value = oCCompany.City;
            parms[6].Value = oCCompany.State;
            parms[7].Value = oCCompany.CountryName;
            parms[8].Value = oCCompany.PostCode;
            parms[9].Value = oCCompany.Phone;
            parms[10].Value = oCCompany.Fax;
            parms[11].Value = oCCompany.Email;
            parms[12].Value = oCCompany.Web;
            parms[13].Value = oCCompany.MissionStatement;
            parms[14].Value = oCCompany.Image;
            parms[15].Value = oCCompany.UpdatedBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }

        /// <summary>
        /// Implementation of IUnitMeasurment.deleteUnitMeasurment
        /// </summary>
        //public void deleteCompany(CCompany oCCompany)
        //{
        //    // Read the runtime setup.
        //    POSConfiguration settings = new POSConfiguration();
        //    // Attempt to load the parameters.
        //    SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(settings.getConnectionstring(), SQL_DELETE);
        //    int returnval;
        //    // Did we fail?
        //    if (parms == null)
        //    {
        //        // Create the parameters.
        //        parms = new SqlParameter[] 
        //        {
        //            new SqlParameter(PARM_MEASUREMENT_ID, SqlDbType.Int)
        //        };

        //        // Store the parameters in the cache.
        //        SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_DELETE, parms);

        //    } // End if we failed to load the parameters.

        //    // Assign values to the parameters.
        //    parms[0].Value = oCUnitMeasurement.Id;

        //    // Execute the SQL statement.
        //    returnval = Convert.ToInt16(SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_DELETE, parms));
        //    return returnval;
        //}

        #endregion
    }
}
