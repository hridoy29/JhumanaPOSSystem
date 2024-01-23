using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using POSsible.Models;
using POSsible.Factories;
using POSsible.Views;

namespace POSsible.Controllers
{
    class UserManager: IUserManager
    {
        private IUserModel _userModel;

        /// <summary>
        /// Reference to the IUserView
        /// </summary>
        private IUserView _userView;

        /// <summary>
        /// null constructor
        /// </summary>
        public UserManager()
        {
            _userModel = Factory.GetUserModel();
        }

        /// <summary>
        /// Constructor to user Manger for userView
        /// </summary>
        /// <param name="_ReferenceForUserMangerView"></param>
        public UserManager(IUserView _ReferenceForUserView)
        {
            _userView = _ReferenceForUserView;
            _userModel = Factory.GetUserModel();
        }


        #region Implementation of IProductCategoryManager

        public CUser getUserId(int iUserId)
        {
            CUser o_user = new CUser();

            try
            {
                SqlDataReader drUser = _userModel.getUserById(iUserId);

                if (drUser.Read())
                {

                    o_user.UserID = (int)drUser["UserId"];

                    if (drUser["Name"].ToString() != "")
                        o_user.UserName = drUser["Name"].ToString();

                    if (drUser["Name"].ToString() != "")
                        o_user.UserName = drUser["Name"].ToString();

                    if (drUser["Password"].ToString() != "")
                        o_user.UserPassword = drUser["Password"].ToString();

                    if (drUser["FirstName"].ToString() != "")
                        o_user.UserFirstName = drUser["FirstName"].ToString();

                    if (drUser["LastName"].ToString() != "")
                        o_user.UserLastName = drUser["LastName"].ToString();

                    if (drUser["Email"].ToString() != "")
                        o_user.Email = drUser["Email"].ToString();

                    if (drUser["IsLoggedIn"].ToString() != "")
                        o_user.IsLoggedIn = (bool)drUser["IsLoggedIn"];

                    if (drUser["HasAdminRight"].ToString() != "")
                        o_user.Admin = (bool)drUser["HasAdminRight"];

                    if (drUser["HasRefundright"].ToString() != "")
                        o_user.Refund = (bool)drUser["HasRefundright"];

                    if (drUser["HasDiscountRight"].ToString() != "")
                        o_user.Discount = (bool)drUser["HasDiscountRight"];

                    if (drUser["HasSuperAdminRight"].ToString() != "")
                        o_user.HasSuperAdminRight = (bool)drUser["HasSuperAdminRight"];

                    if (drUser["EnteredBy"].ToString() != "")
                        o_user.EnteredBy = drUser["EnteredBy"].ToString();

                    if (drUser["EnteredBy"].ToString() != "")
                        o_user.EnteredBy = drUser["EnteredBy"].ToString();

                    if (drUser["EnteredTime"].ToString() != "")
                        o_user.EnteredTime = DateTime.Parse(drUser["EnteredTime"].ToString());

                    if (drUser["UpdatedBy"].ToString() != "")
                        o_user.UpdatedBy = drUser["UpdatedBy"].ToString();
                }
            }
            catch (Exception oEx)
            {
            }
            return o_user;

        }

        public List<CUser> getUserList()
        {

            List<CUser> lstUser = new List<CUser>();
            try
            {
                UserModel usermodel = new UserModel();
                DataSet dsUserList = usermodel.getAllUser();

                foreach (DataRow row in dsUserList.Tables[0].Rows)
                {
                    CUser o_user = new CUser();

                    o_user.UserID = (int)row["UserId"];

                    if (row["Name"].ToString() != "")
                        o_user.UserName = row["Name"].ToString();

                    if (row["Name"].ToString() != "")
                        o_user.UserName = row["Name"].ToString();

                    if (row["Password"].ToString() != "")
                        o_user.UserPassword = row["Password"].ToString();

                    if (row["FirstName"].ToString() != "")
                        o_user.UserFirstName = row["FirstName"].ToString();

                    if (row["LastName"].ToString() != "")
                        o_user.UserLastName = row["LastName"].ToString();

                    if (row["Email"].ToString() != "")
                        o_user.Email = row["Email"].ToString();
                                        
                    if (row["IsLoggedIn"].ToString() != "")
                        o_user.IsLoggedIn = (bool)row["IsLoggedIn"];

                    if (row["HasAdminRight"].ToString() != "")
                        o_user.Admin = (bool)row["HasAdminRight"];

                    if (row["HasRefundright"].ToString() != "")
                        o_user.Refund = (bool)row["HasRefundright"];

                    if (row["HasDiscountRight"].ToString() != "")
                        o_user.Discount = (bool)row["HasDiscountRight"];

                    if (row["HasSuperAdminRight"].ToString() != "")
                        o_user.HasSuperAdminRight = (bool)row["HasSuperAdminRight"];

                    if (row["EnteredBy"].ToString() != "")
                        o_user.EnteredBy = row["EnteredBy"].ToString();

                    if (row["EnteredBy"].ToString() != "")
                        o_user.EnteredBy = row["EnteredBy"].ToString();

                    if (row["EnteredTime"].ToString() != "")
                        o_user.EnteredTime =DateTime.Parse(row["EnteredTime"].ToString());

                    if (row["UpdatedBy"].ToString() != "")
                        o_user.UpdatedBy = row["UpdatedBy"].ToString();

                    lstUser.Add(o_user);
                }
            }
            catch (Exception xcp)
            {

            }
            return lstUser;
        }

        public List<CUser> getAllUser()
        {

            List<CUser> lstUser = new List<CUser>();
            try
            {
                UserModel usermodel = new UserModel();
                DataSet dsUserList = usermodel.getAllUser();

                foreach (DataRow row in dsUserList.Tables[0].Rows)
                {
                    CUser o_user = new CUser();

                    o_user.UserID = (int)row["UserId"];
                    if (row["Name"].ToString() != "")
                        o_user.UserName = row["Name"].ToString();
                    if (row["IsLoggedIn"].ToString() != "")
                        o_user.IsLoggedIn = (bool)row["IsLoggedIn"];

                    lstUser.Add(o_user);
                }
            }
            catch (Exception xcp)
            {

            }
            return lstUser;
        }


        
        /// <summary>
        /// For user entry Form
        /// </summary>
        public int addUser(CUser oCUser)
        {
            int iUserId = _userModel.addUser(oCUser);
            _userView.Alert("User added successfully.");
            return iUserId;
        }

        /// <summary>
        /// Implementation of IUser.delect User
        /// </summary>        
        public int deleteUser(CUser oCUser)
        {
            int returnval;
            returnval = _userModel.deleteUser(oCUser);

            if (returnval != 547)
            {
                _userView.Alert("User deleted successfully.");

            }
            else
            {
                _userView.Alert("You have no permission to delete this User.");

            }
            return returnval; 
        }

        public void updateUser(CUser oCUser)
        {
            _userModel.updateUser(oCUser);
            _userView.Alert("User updated successfully.");
        }        

        public int updateUserList(List<CUser> lstUser)
        {
            int retval = -1;
            try
            {
                UserModel usermodel = new UserModel();
                retval = usermodel.updateUserList(lstUser);
            }
            catch (Exception xcp)
            {                
            }
            return retval;
        }
        #endregion
    }
}
