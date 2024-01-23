using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using POSsible.BusinessObjects;

namespace POSsible.Controllers
{
    /// <summary>
    /// This is the interface of UserManager the View will use to communicate 
    /// with the Controller object using a simple Call Back Pattern.
    /// </summary>        
    public interface IUserManager
    {
        List<CUser> getUserList();        
        List<CUser> getAllUser();
        CUser getUserId(int iUserId);

        /// <summary>
        /// For user entry Form
        /// </summary>
        int addUser(CUser oCUser);
        int deleteUser(CUser oCUser);
        void updateUser(CUser oCUser);
        int updateUserList(List<CUser> lstUser);        
    }
}
