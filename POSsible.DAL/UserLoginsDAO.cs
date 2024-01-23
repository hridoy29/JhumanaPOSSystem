using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class UserLoginsDAO
	{
		public UserLoginsDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, UserLogins oUserLogins)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "UserLoginId":
						oUserLogins.UserLoginId = Convert.ToInt32(oDbDataReader["UserLoginId"]);
						break;
					case "ShiftId":
						if (oDbDataReader["ShiftId"] != DBNull.Value)
							oUserLogins.ShiftId = Convert.ToInt32(oDbDataReader["ShiftId"]);
						break;
					case "UserId":
						oUserLogins.UserId = Convert.ToInt32(oDbDataReader["UserId"]);
						break;
					case "UserLoginTime":
						oUserLogins.UserLoginTime = Convert.ToDateTime(oDbDataReader["UserLoginTime"]);
						break;
					case "UserLogoutTime":
						if (oDbDataReader["UserLogoutTime"] != DBNull.Value)
							oUserLogins.UserLogoutTime = Convert.ToDateTime(oDbDataReader["UserLogoutTime"]);
						break;
					case "UserTerminal":
						if (oDbDataReader["UserTerminal"] != DBNull.Value)
							oUserLogins.UserTerminal = Convert.ToString(oDbDataReader["UserTerminal"]);
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

		public List<UserLogins> UserLogins_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<UserLogins> lstUserLogins = new List<UserLogins>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UserLogins_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					UserLogins oUserLogins = new UserLogins();
					BuildEntity(oDbDataReader, oUserLogins);
					lstUserLogins.Add(oUserLogins);
				}
				return lstUserLogins;
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

		public List<UserLogins> UserLogins_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<UserLogins> lstUserLogins = new List<UserLogins>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UserLogins_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					UserLogins oUserLogins = new UserLogins();
					BuildEntity(oDbDataReader, oUserLogins);
					lstUserLogins.Add(oUserLogins);
				}
				return lstUserLogins;
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

		public UserLogins UserLogins_GetById(int UserLoginId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				UserLogins oUserLogins = new UserLogins();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UserLogins_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@UserLoginId", DbType.Int32, UserLoginId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oUserLogins);
				}
				return oUserLogins;
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

		public int Add(UserLogins _UserLogins)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UserLogins_Create", CommandType.StoredProcedure);
				if (_UserLogins.ShiftId.HasValue)
					AddParameter(oDbCommand, "@ShiftId", DbType.Int32, _UserLogins.ShiftId);
				else
					AddParameter(oDbCommand, "@ShiftId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@UserId", DbType.Int32, _UserLogins.UserId);
				AddParameter(oDbCommand, "@UserLoginTime", DbType.DateTime, _UserLogins.UserLoginTime);
				if (_UserLogins.UserLogoutTime.HasValue)
					AddParameter(oDbCommand, "@UserLogoutTime", DbType.DateTime, _UserLogins.UserLogoutTime);
				else
					AddParameter(oDbCommand, "@UserLogoutTime",DbType.DateTime, DBNull.Value);
				if (_UserLogins.UserTerminal != null)
					AddParameter(oDbCommand, "@UserTerminal", DbType.String, _UserLogins.UserTerminal);
				else
					AddParameter(oDbCommand, "@UserTerminal",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(UserLogins _UserLogins)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UserLogins_Update", CommandType.StoredProcedure);
				if (_UserLogins.ShiftId.HasValue)
					AddParameter(oDbCommand, "@ShiftId", DbType.Int32, _UserLogins.ShiftId);
				else
					AddParameter(oDbCommand, "@ShiftId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@UserId", DbType.Int32, _UserLogins.UserId);
				AddParameter(oDbCommand, "@UserLoginTime", DbType.DateTime, _UserLogins.UserLoginTime);
				if (_UserLogins.UserLogoutTime.HasValue)
					AddParameter(oDbCommand, "@UserLogoutTime", DbType.DateTime, _UserLogins.UserLogoutTime);
				else
					AddParameter(oDbCommand, "@UserLogoutTime",DbType.DateTime, DBNull.Value);
				if (_UserLogins.UserTerminal != null)
					AddParameter(oDbCommand, "@UserTerminal", DbType.String, _UserLogins.UserTerminal);
				else
					AddParameter(oDbCommand, "@UserTerminal",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@UserLoginId", DbType.Int32, _UserLogins.UserLoginId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int UserLoginId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UserLogins_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@UserLoginId", DbType.Int32, UserLoginId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
