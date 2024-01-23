using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class RolesDAO
	{
		public RolesDAO()
		{
			DbProviderHelper.GetConnection();
		}
		private static void BuildEntity(DbDataReader oDbDataReader, Roles oRoles)
		{
		DataTable dt = oDbDataReader.GetSchemaTable();
		foreach (DataRow item in dt.Rows)
		{
			string col = item.ItemArray[0].ToString();
			switch (col)
			{
					case "RoleId":
						oRoles.RoleId = Convert.ToInt32(oDbDataReader["RoleId"]);
						break;
					case "RoleName":
						oRoles.RoleName = Convert.ToString(oDbDataReader["RoleName"]);
						break;
					case "LoweredRoleName":
						oRoles.LoweredRoleName = Convert.ToString(oDbDataReader["LoweredRoleName"]);
						break;

					case "Description":
					if(oDbDataReader["Description"] != DBNull.Value)
						oRoles.Description = Convert.ToString(oDbDataReader["Description"]);
						break;
					case "CompanyId":
						oRoles.CompanyId = Convert.ToInt32(oDbDataReader["CompanyId"]);
						break;
                    case "CompanyName":
                        oRoles.CompanyName = Convert.ToString(oDbDataReader["CompanyName"]);
                        break;
					default:
						break;
			}
		}
		}
		public List<Roles> Roles_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Roles> lstRoles = new List<Roles>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_GetAll",CommandType.StoredProcedure);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Roles oRoles = new Roles();
					BuildEntity(oDbDataReader, oRoles);
					lstRoles.Add(oRoles);
				}
				return lstRoles;
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
		public List<Roles> Roles_GetDynamic(string WhereCondition,string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Roles> lstRoles = new List<Roles>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_GetDynamic",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Roles oRoles = new Roles();
					BuildEntity(oDbDataReader, oRoles);
					lstRoles.Add(oRoles);
				}
				return lstRoles;
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
		public List<Roles> Roles_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder, ref int rows)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Roles> lstRoles = new List<Roles>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_GetPaged",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
				AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
				AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
				AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
				AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Roles oRoles = new Roles();
					BuildEntity(oDbDataReader, oRoles);
					lstRoles.Add(oRoles);
				}
				if ((oDbDataReader.NextResult()) && (oDbDataReader.Read()))
				{
				rows = oDbDataReader.GetInt32(0);
				}
				return lstRoles;
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
		public Roles Roles_GetById(Int32 RoleId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Roles oRoles = new Roles();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_GetById",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleId",DbType.Int32,RoleId);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oRoles);
				}
				return oRoles;
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
		private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
		{
			 oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName,dbType,value));
		}
		public int Add(Roles _Roles)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_Create",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleName",DbType.String, _Roles.RoleName);
				AddParameter(oDbCommand, "@LoweredRoleName",DbType.String, _Roles.LoweredRoleName);
				if (_Roles.Description!=null)
					AddParameter(oDbCommand, "@Description",DbType.String, _Roles.Description);
				else
					AddParameter(oDbCommand, "@Description",DbType.String,DBNull.Value);
				AddParameter(oDbCommand, "@CompanyId",DbType.Int32, _Roles.CompanyId);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Update(Roles _Roles)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_Update",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleName",DbType.String, _Roles.RoleName);
				AddParameter(oDbCommand, "@LoweredRoleName",DbType.String, _Roles.LoweredRoleName);
				if (_Roles.Description!=null)
					AddParameter(oDbCommand, "@Description",DbType.String, _Roles.Description);
				else
					AddParameter(oDbCommand, "@Description",DbType.String,DBNull.Value);
				AddParameter(oDbCommand, "@CompanyId",DbType.Int32, _Roles.CompanyId);
				AddParameter(oDbCommand, "@RoleId",DbType.Int32, _Roles.RoleId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Delete(Int32 RoleId)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_DeleteById",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleId",DbType.Int32,RoleId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<Roles> Roles_GetByCompanyId(Int32 CompanyId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Roles> lstRoless = new List<Roles>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Roles_GetByCompanyId",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@CompanyId",DbType.Int32,CompanyId);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Roles oRoles = new Roles();
					BuildEntity(oDbDataReader, oRoles);
					lstRoless.Add(oRoles);
				}
				return lstRoless;
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
