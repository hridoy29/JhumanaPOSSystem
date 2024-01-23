using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.Models
{
    class UserModel: IUserModel
    {
        #region attributes
        /// <summary>
        /// SQL Stored procedure lists
        /// </summary>
        private static readonly string SQL_GET_ALL_USR = "ritpos_get_all_user";
        private static readonly string SQL_UPDATE_ALL_USR_LOGIN = "ritpos_update_all_login_user";
        private static readonly string SQL_ADD = "ritpos_add_user";
        private static readonly string SQL_UPDATE = "ritpos_update_user";
        private static readonly string SQL_FIND_BY_ID = "ritpos_find_user_by_id";
        private static readonly string SQL_DELETE = "ritpos_delete_user";
        

        /// <summary>
        /// Parameter list
        /// </summary>
        private static readonly string PARM_USR_ID = "@UserId";
        private static readonly string PARM_USR_NAME = "@Name";
        private static readonly string PARM_USR_PASSWORD = "@Password";
        private static readonly string PARM_USR_FIRST_NAME = "@FirstName";
        private static readonly string PARM_USR_LAST_NAME = "@LastName";
        private static readonly string PARM_USR_EMAIL = "@Email";
        private static readonly string PARM_USR_ISLOGGEDIN = "@IsLoggedIn";
        private static readonly string PARM_USR_HASADMINRIGTHT = "@HasAdminRight";
        private static readonly string PARM_USR_HASREFUNDRIGHT = "@HasRefundright";
        private static readonly string PARM_USR_HASDISCOUNTRIGHT = "@HasDiscountRight";
        private static readonly string PARM_USR_HASSUPERADMINRIGHT = "@HasSuperAdminRight";
        private static readonly string PARM_USR_ENTERED_BY = "@EnteredBy";
        private static readonly string PARM_USR_UPDATE_BY = "@UpdatedBy";

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserModel()
        {
        }

        // ******************************************************************
        // IUnitMeasurmentManager implementation.
        // ******************************************************************
        #region Implementation of IUser Members
        /// <summary>
        /// Retrives all user info
        /// </summary>
        /// <returns></returns>
        public DataSet getAllUser()
        {
            DataSet dsUserList = null;
            try
            {
                // Read the runtime setup.
                POSConfiguration settings = new POSConfiguration();
                // Execute the SQL statement.
                dsUserList = SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_GET_ALL_USR);

            }
            catch (Exception xcp)
            {
                throw new Exception("Error occurred while retriving user list", xcp);

            }
            return dsUserList;
        }

        public int updateUserList(List<CUser> lstuser)
        {
            POSConfiguration setting = new POSConfiguration();
            SqlTransaction objTrans = null;
            SqlConnection o_conn = new SqlConnection(setting.getConnectionstring());
            try
            {
                o_conn.Open();
                objTrans = o_conn.BeginTransaction();

                foreach (CUser posuser in lstuser)
                {
                    SqlParameter[] arrParam = new SqlParameter[2];

                    arrParam[0] = new SqlParameter(PARM_USR_NAME, posuser.UserName);
                    arrParam[1] = new SqlParameter(PARM_USR_ISLOGGEDIN, posuser.IsLoggedIn);
                    //pass connection string, storedprocedure name and parameter array
                    SqlHelper.ExecuteNonQuery(setting.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE_ALL_USR_LOGIN, arrParam);
                }

            }

            catch (Exception Ex)
            {

                objTrans.Rollback();
                string sError = Ex.Message.ToString();
                return -1;

            }
            finally
            {
                o_conn.Close();
            }

            return 1;

        }

        public SqlDataReader getUserById(int iUserId)
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
                    new SqlParameter(PARM_USR_ID, SqlDbType.Int),
                };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_FIND_BY_ID, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = iUserId;

            // Execute the SQL statement.
            return SqlHelper.ExecuteReader(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_FIND_BY_ID, parms);
        }

        public int addUser(CUser oCUser)
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
					new SqlParameter(PARM_USR_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_USR_PASSWORD, SqlDbType.VarChar, 250),
                    new SqlParameter(PARM_USR_FIRST_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USR_LAST_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USR_EMAIL, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USR_ISLOGGEDIN, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASADMINRIGTHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASREFUNDRIGHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASDISCOUNTRIGHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASSUPERADMINRIGHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_ENTERED_BY, SqlDbType.Int),
                    
					new SqlParameter(PARM_USR_ID, SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, PARM_USR_ID, DataRowVersion.Current, null)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_ADD, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCUser.UserName;
            parms[1].Value = oCUser.UserPassword;
            parms[2].Value = oCUser.UserFirstName;
            parms[3].Value = oCUser.UserLastName;
            parms[4].Value = oCUser.Email;
            parms[5].Value = oCUser.IsLoggedIn;
            parms[6].Value = oCUser.Admin;
            parms[7].Value = oCUser.Refund;
            parms[8].Value = oCUser.Discount;
            parms[9].Value = oCUser.HasSuperAdminRight;
            parms[10].Value = oCUser.EnteredBy;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_ADD, parms);

            // Return the identity value.
            return (Int32)parms[11].Value;
        }

        public int deleteUser(CUser oCUser)
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
                    new SqlParameter(PARM_USR_ID, SqlDbType.Int)
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_DELETE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCUser.UserID;

            // Execute the SQL statement.
            returnval = Convert.ToInt16(SqlHelper.ExecuteScalar(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_DELETE, parms));
            return returnval;
        }

        public void updateUser(CUser oCUser)
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
					new SqlParameter(PARM_USR_NAME, SqlDbType.VarChar, 50),
					new SqlParameter(PARM_USR_PASSWORD, SqlDbType.VarChar, 250),
                    new SqlParameter(PARM_USR_FIRST_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USR_LAST_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USR_EMAIL, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USR_ISLOGGEDIN, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASADMINRIGTHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASREFUNDRIGHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASDISCOUNTRIGHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_HASSUPERADMINRIGHT, SqlDbType.Bit),
                    new SqlParameter(PARM_USR_UPDATE_BY, SqlDbType.Int),
                    new SqlParameter(PARM_USR_ID, SqlDbType.Int)

				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE, parms);

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oCUser.UserName;
            parms[1].Value = oCUser.UserPassword;
            parms[2].Value = oCUser.UserFirstName;
            parms[3].Value = oCUser.UserLastName;
            parms[4].Value = oCUser.Email;
            parms[5].Value = oCUser.IsLoggedIn;
            parms[6].Value = oCUser.Admin;
            parms[7].Value = oCUser.Refund;
            parms[8].Value = oCUser.Discount;
            parms[9].Value = oCUser.HasSuperAdminRight;
            parms[10].Value = oCUser.UpdatedBy;
            parms[11].Value = oCUser.UserID;

            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE, parms);
        }

        #endregion
    }
}
