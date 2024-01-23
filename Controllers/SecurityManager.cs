using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;

namespace POSsible.Controllers
{
    public class SecurityManager : ISecurityManager
    {
        /// <summary>refernce to the ILoginView, passed in on 
        /// creation</summary>
        private POSsible.Views.ILoginView _LoginView;

        /// <summary>
        /// reference to the ISecurityModel, retrived 
        /// on creation from the factory
        /// </summary>
        private POSsible.Models.ISecurityModel _SecurityModel;

        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForLoginView"></param>
        public SecurityManager(POSsible.Views.ILoginView _ReferenceForLoginView)
        {
            _LoginView = _ReferenceForLoginView;
            _SecurityModel = POSsible.Factories.Factory.GetSecurityModel();
        }

        /// <summary>
        /// refernce to the IDBSettingsView
        /// </summary>
        private POSsible.Views.IDBSettingsView _DBSettingsView;

        /// <summary>
        /// refernce to the IMainView
        /// </summary>
        private POSsible.Views.IMainView _MainView;

        private POSsible.Views.IAuthorization _Authorization;
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="_ReferenceForDBSettingsView"></param>
        public SecurityManager()
        {
            _SecurityModel = POSsible.Factories.Factory.GetSecurityModel();
        }

        /// <summary>
        /// Making a constructor
        /// </summary>
        /// <param name="_ReferenceForDBSettingsView"></param>
        public SecurityManager(POSsible.Views.IDBSettingsView _ReferenceForDBSettingsView)
        {
            _DBSettingsView = _ReferenceForDBSettingsView;
            _SecurityModel = POSsible.Factories.Factory.GetSecurityModel();

        }

        public SecurityManager(POSsible.Views.IMainView _ReferenceForMainView)
        {
            _MainView = _ReferenceForMainView;
            _SecurityModel = POSsible.Factories.Factory.GetSecurityModel();
        }

        public SecurityManager(POSsible.Views.IAuthorization _ReferenceForAuthorization)
        {
            _Authorization = _ReferenceForAuthorization;
            _SecurityModel = POSsible.Factories.Factory.GetSecurityModel();
        }



        /// <summary>
        /// Implementation of ISecurityMangaer.Authenticate
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        public void Authenticate(string sUserName, string sPassword)
        {
            try
            {
                DataSet dsUser = _SecurityModel.Authenticate(sUserName, sPassword);
                CUser oUser = new CUser();
                if (dsUser.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
                    {
                        DataRow drUser = dsUser.Tables[0].Rows[i];

                        oUser.UserID = (int)drUser["userId"];
                        if (drUser["name"].ToString() != "")
                            oUser.UserName = drUser["name"].ToString();
                        if (drUser["Password"].ToString() != "")
                            oUser.UserPassword = drUser["Password"].ToString();
                        if (drUser["FirstName"].ToString() != "")
                            oUser.UserFirstName = drUser["FirstName"].ToString();
                        if (drUser["LastName"].ToString() != "")
                            oUser.UserLastName = drUser["LastName"].ToString();
                        if (drUser["Email"].ToString() != "")
                            oUser.Email = drUser["Email"].ToString();
                        if (drUser["EnteredBy"].ToString() != "")
                            oUser.EnteredBy = drUser["EnteredBy"].ToString();
                        if (drUser["EnteredTime"].ToString() != "")
                            oUser.EnteredTime = Convert.ToDateTime(drUser["EnteredTime"]);
                        if (drUser["UpdatedBy"].ToString() != "")
                            oUser.UpdatedBy = drUser["UpdatedBy"].ToString();
                        //oUser.UpdatedTime=Convert.ToDateTime(drUser["UpdatedTime"]);
                        //oUser.DeactivatedTime= drUser["DeactivatedTime"] == System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drUser["DeactivatedTime"]);
                        if (drUser["isLoggedIn"].ToString() != "")
                            oUser.IsLoggedIn = Convert.ToBoolean(drUser["isLoggedIn"]);
                        if (drUser["HasRefundRight"].ToString() != "")
                            oUser.Refund = Convert.ToBoolean(drUser["HasRefundRight"]);
                        if (drUser["HasAdminRight"].ToString() != "")
                            oUser.Admin = Convert.ToBoolean(drUser["HasAdminRight"]);
                        if (drUser["HasDiscountRight"].ToString() != "")
                            oUser.Discount = Convert.ToBoolean(drUser["HasDiscountRight"]);
                        //if (drUser["HasSuperAdminRight"].ToString() != "")
                        oUser.HasSuperAdminRight = true; //Convert.ToBoolean(drUser["HasSuperAdminRight"]);

                    }

                    if (_LoginView != null)
                    {
                        if (oUser.IsLoggedIn == true && oUser.HasSuperAdminRight != true)
                        {
                            _LoginView.notAuthenticated("You are already logged in.");
                        }
                        else
                        {
                            DataSet dsLoginInfo = _SecurityModel.createLogin(oUser);
                            foreach (DataRow row in dsLoginInfo.Tables[0].Rows)
                            {
                                //oUser.IsLoggedIn = Convert.ToBoolean(row["Isloggedin"]);
                                oUser.UserLoginId = (int)row["UserLoginId"];
                                oUser.ShiftId = (int)row["ShiftId"];
                                oUser.IsLoggedIn = true;
                                oUser.userTerminal = row["UserTerminal"].ToString();
                            }

                            _LoginView.goToMainform(oUser);
                        }
                    }
                    else
                    {
                        if (_Authorization != null)
                            _Authorization.goToAuthorizationform(oUser);
                    }
                }
                else
                {
                    if (_LoginView != null)
                        _LoginView.notAuthenticated("Invalid User Name or Password");
                    else if (_Authorization != null)
                        _Authorization.goToAuthorizationform(null);
                }

            }
            catch (Exception oEx)
            {
                if (_LoginView != null)
                    _LoginView.notAuthenticated(oEx.Message + "Connection Error-RPOSErr" + "00001");
            }
        }

        /// <summary>
        /// Implementation of ISecuritManager.updateLogin4LogOff
        /// </summary>
        /// <param name="oUser"></param>
        public void updateLogin4LogOff(CUser oUser)
        {
            try
            {
                _SecurityModel.updateLogin4LogOff(oUser);
            }
            catch (Exception oEx)
            {
            }

        }

        /// <summary>
        /// Implementation of ISecurityMangaer.CheckConnection
        /// </summary>
        /// <param name="oPosConn"></param>
        /// <returns></returns>
        public static bool CheckConnection(POSConfiguration oPosConn)
        {

            string Constr = " server =" + oPosConn.Server + ";"
                            + "database =" + oPosConn.Database + ";"
                            + "user id =" + oPosConn.UserName + ";"
                            + "password =" + oPosConn.Password + ";";

            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = Constr;
            try
            {
                oConn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Implementation of ISecurityMangaer.setRegistryValue
        /// </summary>
        /// <param name="sDatabaseUser"></param>
        /// <param name="sPassword"></param>
        /// <param name="sServer"></param>
        /// <param name="sDatabaseName"></param>
        /// <param name="sTerminalName"></param>
        /// <param name="sTerminalIp"></param>
        /// <returns></returns>
        public bool setRegistryValue(string sDatabaseUser, string sPassword, string sServer, string sDatabaseName, string sTerminalIP, string sPrinterName, string sScalePort)
        {
            POSConfiguration oPosConfigure = new POSConfiguration();
            oPosConfigure.UserName = sDatabaseUser;
            oPosConfigure.Password = sPassword;
            oPosConfigure.Server = sServer;
            oPosConfigure.Database = sDatabaseName;
            oPosConfigure.TerminalIP = sTerminalIP;
            oPosConfigure.PrinterName = sPrinterName;
            oPosConfigure.ScalePortName = sScalePort;


            //oPosConfigure.TerminalIp = sTerminalIp;
            bool bSetRegistry = _SecurityModel.setRegistryValue(oPosConfigure);

            if (bSetRegistry.Equals(true))
            {
                return true;
            }
            else
            {
                _DBSettingsView.Alert("Could not Connect with the Database");
                return false;
            }


        }

        //public CUser checkAuthorization(string sUserName, string sUserPassword)
        //{
        //    CUser oUser = new CUser();
        //    try
        //    {
        //        DataSet dsAuthorizedUser = _SecurityModel.checkAuthorization(sUserName, sUserPassword);                

        //        if (dsAuthorizedUser.Tables[0].Rows.Count != 0)
        //        {
        //            for (int i = 0; i < dsAuthorizedUser.Tables[0].Rows.Count; i++)
        //            {
        //                DataRow drUser = dsAuthorizedUser.Tables[0].Rows[i];
        //                oUser.UserID = (int)drUser["userId"];
        //                oUser.UserName = drUser["Name"].ToString();
        //                oUser.Refund = Convert.ToBoolean(drUser["Refund"]);
        //            }
        //        }

        //    }
        //    catch (Exception oEx)
        //    { 

        //    }
        //    return oUser;
        //}
    }
}
