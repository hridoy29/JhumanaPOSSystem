using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public interface ISecurityModel
    {
        DataSet Authenticate(string sUserName, string sPassword);
        bool setRegistryValue(POSConfiguration oPosConfigure);
        DataSet createLogin(CUser oUser);
        void updateLogin4LogOff(CUser oUser);
        //DataSet checkAuthorization(string sUserName, string sUserPassword);
        

    }
}
