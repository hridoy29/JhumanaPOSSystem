using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using Microsoft.Win32;

namespace POSsible.Models
{
    public class SecurityModel:ISecurityModel
    {

        public SecurityModel()
        { }


        #region Attributes

        /// <summary>
        /// The SQL to find all Department.
        /// </summary>
        private static readonly string SQL_FIND_USER = "ritpos_find_user";

        private static readonly string SQL_CREATE_LOGIN = "ritpos_create_login";

        private static readonly string SQL_UPDATE_LOGIN = "ritpos_update_login";

        private static readonly string SQL_FIND_AUTHORIZATION = "ritpos_find_authorization";

        /// <summary>
        /// Various parameter names.
        /// </summary>
        private static readonly string PARM_USER_NAME = "@userName";
        private static readonly string PARM_USER_PASSWORD = "@userPassword";

        private static readonly string PARM_SHIFT_ID = "@shiftId";
        private static readonly string PARM_USER_ID = "@userId";
        private static readonly string PARM_USER_TERMINAL = "@userTeminal";

        private static readonly string PARAM_LOGIN_ID = "@loginId";



        #endregion       
        /// <summary>
        /// Implementation of ISecurityModel.Authenticate
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public DataSet Authenticate(string sUserName, string sPassword)
        {
            // Read the runtime setup.
            POSConfiguration oPosConnection = new POSConfiguration();
            //oPosConnection.getConnectionstring();

            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
                oPosConnection.getConnectionstring(),
                SQL_FIND_USER
                );

            // Did we fail?
            if (parms == null)
            {

                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_USER_NAME, SqlDbType.VarChar, 50),
                    new SqlParameter(PARM_USER_PASSWORD, SqlDbType.VarChar, 50),
                 };

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(
                    oPosConnection.getConnectionstring(),
                    SQL_FIND_USER,
                    parms
                    );

            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = sUserName;
            parms[1].Value = sPassword;

            // Execute the SQL statement.
            return SqlHelper.ExecuteDataset(
                oPosConnection.getConnectionstring(),
                CommandType.StoredProcedure,
                SQL_FIND_USER,
                parms
                );
        }

        /// <summary>
        /// Implementation of ISecurityModel.createLogin
        /// </summary>
        /// <param name="oUser"></param>
        public DataSet createLogin(CUser oUser)
        {
            // Read the runtime setup.
            POSConfiguration oPOSConfig = new POSConfiguration();


            SqlConnection con = new SqlConnection();
            string sWokStationId=con.WorkstationId.ToString();
            // Attempt to load the parameters.
            SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(oPOSConfig.getConnectionstring(), SQL_CREATE_LOGIN);

            // Did we fail?
            if (parms == null)
            {
                // Create the parameters.
                parms = new SqlParameter[] 
				{
					new SqlParameter(PARM_SHIFT_ID, SqlDbType.Int),
					new SqlParameter(PARM_USER_ID, SqlDbType.Int),					
					new SqlParameter(PARM_USER_TERMINAL, SqlDbType.VarChar, 200),
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(oPOSConfig.getConnectionstring(), SQL_CREATE_LOGIN, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oUser.ShiftId;// == 0 ? System.Data.SqlTypes.SqlInt32.Null : oUser.ShiftId; // as Shift id for Shift not started situation is null
            parms[1].Value = oUser.UserID;
            parms[2].Value = sWokStationId;
            

            // Execute the SQL statement.
            DataSet dsLoginInfo=SqlHelper.ExecuteDataset(oPOSConfig.getConnectionstring(), CommandType.StoredProcedure, SQL_CREATE_LOGIN, parms);
            return dsLoginInfo;

        }


        /// <summary>
        /// Implementation of ISecurityModel.setRegistryValue
        /// </summary>
        /// <param name="oPosConfiguration"></param>
        /// <returns></returns>
        public bool setRegistryValue(POSConfiguration oPosConfiguration)
        {
            if (SecurityManager.CheckConnection(oPosConfiguration))
            {
                try
                {
                    /// <summary>
                    /// Open the Registry Key
                    /// </summary>
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);

                    RegistryKey KeyPosSetting = key.CreateSubKey("POSSettings");

                    /// <summary>
                    /// Create Subkey for the POSSettings
                    /// </summary>
                    RegistryKey SubkeyDbSetting = KeyPosSetting.CreateSubKey("DBSettings");

                    /// <summary>
                    /// Create SubKey for the DatabaseSettings
                    ///// </summary>
                    //RegistryKey rkUserName = SubkeyDbSetting.CreateSubKey("UserName");
                    //RegistryKey rkPassword = SubkeyDbSetting.CreateSubKey("Password");
                    //RegistryKey rkServerName = SubkeyDbSetting.CreateSubKey("Server");
                    //RegistryKey rkDatabase = SubkeyDbSetting.CreateSubKey("Database");

                    /// <summary>
                    /// Create Subkey For the Terminal Settings
                    /// </summary>


                    /// <summary>
                    /// Open the Registry Key
                    /// </summary>
                    RegistryKey pRegKey = Registry.LocalMachine;
                    //RegistryKey RegKeyUser = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\UserName",true);
                    //RegistryKey RegKeyPassword = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Password",true);
                    //RegistryKey RegKeyServer = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Server",true);
                    //RegistryKey RegKeyDatabase = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Database",true);

                    RegistryKey RegKeyDBSetting = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings", true);
                    //RegistryKey RegKeyPassword = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Password", true);
                    //RegistryKey RegKeyServer = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Server", true);
                    //RegistryKey RegKeyDatabase = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Database", true);


                    /// <summary>
                    /// Set the value into the registry key
                    /// </summary>
                    RegKeyDBSetting.SetValue("UserName", oPosConfiguration.UserName);
                    RegKeyDBSetting.SetValue("Password", oPosConfiguration.Password);
                    RegKeyDBSetting.SetValue("Server", oPosConfiguration.Server);
                    RegKeyDBSetting.SetValue("Database", oPosConfiguration.Database);
                    RegKeyDBSetting.SetValue("TerminalIP", oPosConfiguration.TerminalIP);
                    RegKeyDBSetting.SetValue("PrinterName", oPosConfiguration.PrinterName);
                    RegKeyDBSetting.SetValue("ScalePortName", oPosConfiguration.ScalePortName);

                }
                catch (Exception oEx)
                {

                }
                return true;
            }
            else
            {
                return false;
            }

        }
               

        /// <summary>
        /// Implementation of ISecurityModel.updateLogin4LogOff
        /// </summary>
        /// <param name="oUser"></param>
        public void updateLogin4LogOff(CUser oUser)
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
                        new SqlParameter (PARAM_LOGIN_ID,SqlDbType.Int),
                        new SqlParameter (PARM_USER_ID,SqlDbType.Int),
                        
				};

                // Store the parameters in the cache.
                SqlHelperParameterCache.CacheParameterSet(settings.getConnectionstring(), SQL_UPDATE_LOGIN, parms);
            } // End if we failed to load the parameters.

            // Assign values to the parameters.
            parms[0].Value = oUser.UserLoginId;
            parms[1].Value = oUser.UserID;
            
            // Execute the SQL statement.
            SqlHelper.ExecuteNonQuery(settings.getConnectionstring(), CommandType.StoredProcedure, SQL_UPDATE_LOGIN, parms);

        }

        //public DataSet checkAuthorization(string sUserName, string sUserPassword)
        //{
        //    // Read the runtime setup.
        //    POSConfiguration oPosConnection = new POSConfiguration();
        //    //oPosConnection.getConnectionstring();

        //    // Attempt to load the parameters.
        //    SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(
        //        oPosConnection.getConnectionstring(),
        //        SQL_FIND_AUTHORIZATION
        //        );

        //    // Did we fail?
        //    if (parms == null)
        //    {

        //        // Create the parameters.
        //        parms = new SqlParameter[] 
        //        {
        //            new SqlParameter(PARM_USER_NAME, SqlDbType.VarChar, 50),
        //            new SqlParameter(PARM_USER_PASSWORD, SqlDbType.VarChar, 50),
        //         };

        //        // Store the parameters in the cache.
        //        SqlHelperParameterCache.CacheParameterSet(
        //            oPosConnection.getConnectionstring(),
        //            SQL_FIND_AUTHORIZATION,
        //            parms
        //            );

        //    } // End if we failed to load the parameters.

        //    // Assign values to the parameters.
        //    parms[0].Value = sUserName;
        //    parms[1].Value = sUserPassword;

        //    // Execute the SQL statement.
        //    return SqlHelper.ExecuteDataset(
        //        oPosConnection.getConnectionstring(),
        //        CommandType.StoredProcedure,
        //        SQL_FIND_AUTHORIZATION,
        //        parms
        //        );
        //}
    }
}
