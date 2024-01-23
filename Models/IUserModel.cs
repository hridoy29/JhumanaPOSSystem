using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public interface IUserModel
    {
        //DataSet getUserList();
        SqlDataReader getUserById(int iUserId);

        int addUser(CUser oCUser);
        int deleteUser(CUser oCUser);
        void updateUser(CUser oCUser);
    }
}
