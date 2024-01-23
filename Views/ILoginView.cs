using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace POSsible.Views
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoginView
    {
        void notAuthenticated(string sMsg);
        void goToMainform(CUser oUser);
    }
}
