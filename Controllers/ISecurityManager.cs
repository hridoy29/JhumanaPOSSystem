using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;


namespace POSsible.Controllers
{
    
    public interface ISecurityManager
    {
        /// <summary>
        /// Used to Verify User login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        void Authenticate(string username,string password);

        /// <summary>
        /// Used to set the Registry value for Authentication
        /// </summary>
        /// <param name="sDatabaseUser"></param>
        /// <param name="sPassword"></param>
        /// <param name="sServer"></param>
        /// <param name="sDatabaseName"></param>
        /// <param name="sTerminalName"></param>
        /// <param name="sTerminalIp"></param>
        /// <returns></returns>
        bool setRegistryValue(string sDatabaseUser, string sPassword, string sServer, string sDatabaseName, string sTerminalIP, string sPrinterName, string sScalePort);        
       // void Alert(string sMsg);

        void updateLogin4LogOff(CUser oUser);

        //CUser checkAuthorization(string sUserName, string sUserPassword);
        
    }
}
