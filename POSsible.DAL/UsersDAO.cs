using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class UsersDAO
    {
        public UsersDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, Users oUsers)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "UserId":
						oUsers.UserId = Convert.ToInt32(oDbDataReader["UserId"]);
						break;
					case "Name":
						oUsers.Name = Convert.ToString(oDbDataReader["Name"]);
						break;
					case "Password":
						oUsers.Password = Convert.ToString(oDbDataReader["Password"]);
						break;
					case "FirstName":
						if (oDbDataReader["FirstName"] != DBNull.Value)
							oUsers.FirstName = Convert.ToString(oDbDataReader["FirstName"]);
						break;
					case "LastName":
						if (oDbDataReader["LastName"] != DBNull.Value)
							oUsers.LastName = Convert.ToString(oDbDataReader["LastName"]);
						break;
					case "Email":
						if (oDbDataReader["Email"] != DBNull.Value)
							oUsers.Email = Convert.ToString(oDbDataReader["Email"]);
						break;
					case "IsLoggedIn":
						oUsers.IsLoggedIn = Convert.ToBoolean(oDbDataReader["IsLoggedIn"]);
						break;
					case "HasAdminRight":
						if (oDbDataReader["HasAdminRight"] != DBNull.Value)
							oUsers.HasAdminRight = Convert.ToBoolean(oDbDataReader["HasAdminRight"]);
						break;
					case "HasRefundright":
						if (oDbDataReader["HasRefundright"] != DBNull.Value)
							oUsers.HasRefundright = Convert.ToBoolean(oDbDataReader["HasRefundright"]);
						break;
					case "HasDiscountRight":
						if (oDbDataReader["HasDiscountRight"] != DBNull.Value)
							oUsers.HasDiscountRight = Convert.ToBoolean(oDbDataReader["HasDiscountRight"]);
						break;
					case "EnteredBy":
						if (oDbDataReader["EnteredBy"] != DBNull.Value)
							oUsers.EnteredBy = Convert.ToInt32(oDbDataReader["EnteredBy"]);
						break;
					case "EnteredTime":
						oUsers.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
						break;
					case "UpdatedBy":
						if (oDbDataReader["UpdatedBy"] != DBNull.Value)
							oUsers.UpdatedBy = Convert.ToInt32(oDbDataReader["UpdatedBy"]);
						break;
					case "UpdatedTime":
						if (oDbDataReader["UpdatedTime"] != DBNull.Value)
							oUsers.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
						break;
					case "DeactivatedTime":
						if (oDbDataReader["DeactivatedTime"] != DBNull.Value)
							oUsers.DeactivatedTime = Convert.ToDateTime(oDbDataReader["DeactivatedTime"]);
						break;
                    case "EmployeeName":
                        if (oDbDataReader["EmployeeName"] != DBNull.Value)
                            oUsers.EmployeeName = Convert.ToString(oDbDataReader["EmployeeName"]);
                        break;
                    case "StoreName":
                        if (oDbDataReader["StoreName"] != DBNull.Value)
                            oUsers.storeName = Convert.ToString(oDbDataReader["StoreName"]);
                        break;
                    case "ProjectId":
                        if (oDbDataReader["ProjectId"] != DBNull.Value)
                            oUsers.projectId = Convert.ToInt32(oDbDataReader["ProjectId"]);
                        break;
                    case "DesignationName":
                        if (oDbDataReader["DesignationName"] != DBNull.Value)
                            oUsers.DesignationName = Convert.ToString(oDbDataReader["DesignationName"]);
                        break;
                    case "CardAmtLgId":
                        if (oDbDataReader["CardAmtLgId"] != DBNull.Value)
                            oUsers.CardAmtLgId = Convert.ToInt32(oDbDataReader["CardAmtLgId"]);
                        break;
					default:
						break;
				}
			}
		}

        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public List<Users> Users_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Users> lstUsers = new List<Users>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Users_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Users oUsers = new Users();
                    BuildEntity(oDbDataReader, oUsers);
                    lstUsers.Add(oUsers);
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public List<Users> Users_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Users> lstUsers = new List<Users>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Users_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Users oUsers = new Users();
                    BuildEntity(oDbDataReader, oUsers);
                    lstUsers.Add(oUsers);
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public Users Users_GetById(int UserId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                Users oUsers = new Users();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Users_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.Int32, UserId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oUsers);
                }
                return oUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public int Add(Users _Users)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Users_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Name", DbType.String, _Users.Name);
                AddParameter(oDbCommand, "@Password", DbType.String, _Users.Password);
                if (_Users.FirstName != null)
                    AddParameter(oDbCommand, "@FirstName", DbType.String, _Users.FirstName);
                else
                    AddParameter(oDbCommand, "@FirstName", DbType.String, DBNull.Value);
                if (_Users.LastName != null)
                    AddParameter(oDbCommand, "@LastName", DbType.String, _Users.LastName);
                else
                    AddParameter(oDbCommand, "@LastName", DbType.String, DBNull.Value);
                if (_Users.Email != null)
                    AddParameter(oDbCommand, "@Email", DbType.String, _Users.Email);
                else
                    AddParameter(oDbCommand, "@Email", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@IsLoggedIn", DbType.Boolean, _Users.IsLoggedIn);
                if (_Users.HasAdminRight.HasValue)
                    AddParameter(oDbCommand, "@HasAdminRight", DbType.Boolean, _Users.HasAdminRight);
                else
                    AddParameter(oDbCommand, "@HasAdminRight", DbType.Boolean, DBNull.Value);
                if (_Users.HasRefundright.HasValue)
                    AddParameter(oDbCommand, "@HasRefundright", DbType.Boolean, _Users.HasRefundright);
                else
                    AddParameter(oDbCommand, "@HasRefundright", DbType.Boolean, DBNull.Value);
                if (_Users.HasDiscountRight.HasValue)
                    AddParameter(oDbCommand, "@HasDiscountRight", DbType.Boolean, _Users.HasDiscountRight);
                else
                    AddParameter(oDbCommand, "@HasDiscountRight", DbType.Boolean, DBNull.Value);
                if (_Users.EnteredBy.HasValue)
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _Users.EnteredBy);
                else
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Users.EnteredTime);
                if (_Users.UpdatedBy.HasValue)
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _Users.UpdatedBy);
                else
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, DBNull.Value);
                if (_Users.UpdatedTime.HasValue)
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Users.UpdatedTime);
                else
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, DBNull.Value);
                if (_Users.DeactivatedTime.HasValue)
                    AddParameter(oDbCommand, "@DeactivatedTime", DbType.DateTime, _Users.DeactivatedTime);
                else
                    AddParameter(oDbCommand, "@DeactivatedTime", DbType.DateTime, DBNull.Value);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Users _Users)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Users_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Name", DbType.String, _Users.Name);
                AddParameter(oDbCommand, "@Password", DbType.String, _Users.Password);
                if (_Users.FirstName != null)
                    AddParameter(oDbCommand, "@FirstName", DbType.String, _Users.FirstName);
                else
                    AddParameter(oDbCommand, "@FirstName", DbType.String, DBNull.Value);
                if (_Users.LastName != null)
                    AddParameter(oDbCommand, "@LastName", DbType.String, _Users.LastName);
                else
                    AddParameter(oDbCommand, "@LastName", DbType.String, DBNull.Value);
                if (_Users.Email != null)
                    AddParameter(oDbCommand, "@Email", DbType.String, _Users.Email);
                else
                    AddParameter(oDbCommand, "@Email", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@IsLoggedIn", DbType.Boolean, _Users.IsLoggedIn);
                if (_Users.HasAdminRight.HasValue)
                    AddParameter(oDbCommand, "@HasAdminRight", DbType.Boolean, _Users.HasAdminRight);
                else
                    AddParameter(oDbCommand, "@HasAdminRight", DbType.Boolean, DBNull.Value);
                if (_Users.HasRefundright.HasValue)
                    AddParameter(oDbCommand, "@HasRefundright", DbType.Boolean, _Users.HasRefundright);
                else
                    AddParameter(oDbCommand, "@HasRefundright", DbType.Boolean, DBNull.Value);
                if (_Users.HasDiscountRight.HasValue)
                    AddParameter(oDbCommand, "@HasDiscountRight", DbType.Boolean, _Users.HasDiscountRight);
                else
                    AddParameter(oDbCommand, "@HasDiscountRight", DbType.Boolean, DBNull.Value);
                if (_Users.EnteredBy.HasValue)
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _Users.EnteredBy);
                else
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Users.EnteredTime);
                if (_Users.UpdatedBy.HasValue)
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _Users.UpdatedBy);
                else
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, DBNull.Value);
                if (_Users.UpdatedTime.HasValue)
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Users.UpdatedTime);
                else
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, DBNull.Value);
                if (_Users.DeactivatedTime.HasValue)
                    AddParameter(oDbCommand, "@DeactivatedTime", DbType.DateTime, _Users.DeactivatedTime);
                else
                    AddParameter(oDbCommand, "@DeactivatedTime", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@UserId", DbType.Int32, _Users.UserId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int UserId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Users_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.Int32, UserId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Employee_GetForDDL(int StoreId)
        {
            DbDataReader oDbDataReader = null;
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Employee_GetForDDL", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@StoreId", DbType.Int32, StoreId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dt.Load(oDbDataReader);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public DataTable Store_GetAll()
        {
            DbDataReader oDbDataReader = null;
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dt.Load(oDbDataReader);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public DataTable Store_GetById(int storeId)
        {
            DbDataReader oDbDataReader = null;
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@StoreId", DbType.Int32, storeId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dt.Load(oDbDataReader);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }
    }
}
