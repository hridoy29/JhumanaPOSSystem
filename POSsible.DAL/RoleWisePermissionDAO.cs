using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class RoleWisePermissionDAO
	{
		public RoleWisePermissionDAO()
		{
			DbProviderHelper.GetConnection();
		}
		private static void BuildEntity(DbDataReader oDbDataReader, RoleWisePermission oRoleWisePermission)
		{
		DataTable dt = oDbDataReader.GetSchemaTable();
		foreach (DataRow item in dt.Rows)
		{
			string col = item.ItemArray[0].ToString();
			switch (col)
			{
					case "PermissionId":
						oRoleWisePermission.PermissionId = Convert.ToInt64(oDbDataReader["PermissionId"]);
						break;
					case "RoleId":
						oRoleWisePermission.RoleId = Convert.ToInt32(oDbDataReader["RoleId"]);
						break;
					case "PageId":
						oRoleWisePermission.PageId = Convert.ToInt32(oDbDataReader["PageId"]);
						break;
					case "CanCreate":
						oRoleWisePermission.CanCreate = Convert.ToBoolean(oDbDataReader["CanCreate"]);
						break;
					case "CanDelete":
						oRoleWisePermission.CanDelete = Convert.ToBoolean(oDbDataReader["CanDelete"]);
						break;
					case "CanUpdate":
						oRoleWisePermission.CanUpdate = Convert.ToBoolean(oDbDataReader["CanUpdate"]);
						break;
					case "CanSelect":
						oRoleWisePermission.CanSelect = Convert.ToBoolean(oDbDataReader["CanSelect"]);
						break;
					case "AssignedBy":
						oRoleWisePermission.AssignedBy = Convert.ToInt32(oDbDataReader["AssignedBy"]);
						break;
					case "CompanyId":
						oRoleWisePermission.CompanyId = Convert.ToInt32(oDbDataReader["CompanyId"]);
						break;
					default:
						break;
			}
		}
		}
		public List<RoleWisePermission> RoleWisePermission_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<RoleWisePermission> lstRoleWisePermission = new List<RoleWisePermission>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetAll",CommandType.StoredProcedure);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RoleWisePermission oRoleWisePermission = new RoleWisePermission();
					BuildEntity(oDbDataReader, oRoleWisePermission);
					lstRoleWisePermission.Add(oRoleWisePermission);
				}
				return lstRoleWisePermission;
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
		public List<RoleWisePermission> RoleWisePermission_GetDynamic(string WhereCondition,string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<RoleWisePermission> lstRoleWisePermission = new List<RoleWisePermission>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetDynamic",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RoleWisePermission oRoleWisePermission = new RoleWisePermission();
					BuildEntity(oDbDataReader, oRoleWisePermission);
					lstRoleWisePermission.Add(oRoleWisePermission);
				}
				return lstRoleWisePermission;
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
		public List<RoleWisePermission> RoleWisePermission_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder, ref int rows)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<RoleWisePermission> lstRoleWisePermission = new List<RoleWisePermission>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetPaged",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
				AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
				AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
				AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
				AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RoleWisePermission oRoleWisePermission = new RoleWisePermission();
					BuildEntity(oDbDataReader, oRoleWisePermission);
					lstRoleWisePermission.Add(oRoleWisePermission);
				}
				if ((oDbDataReader.NextResult()) && (oDbDataReader.Read()))
				{
				rows = oDbDataReader.GetInt32(0);
				}
				return lstRoleWisePermission;
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
		public RoleWisePermission RoleWisePermission_GetById(Int64 PermissionId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				RoleWisePermission oRoleWisePermission = new RoleWisePermission();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetById",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PermissionId",DbType.Int64,PermissionId);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oRoleWisePermission);
				}
				return oRoleWisePermission;
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

        public List<RoleWisePermission> RoleWisePermissionList_GetById(Int64 PermissionId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<RoleWisePermission> lstSec_UserWisePermission = new List<RoleWisePermission>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@PermissionId", DbType.Int64, PermissionId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    RoleWisePermission oRoleWisePermission = new RoleWisePermission();
                    BuildEntity(oDbDataReader, oRoleWisePermission);
                    lstSec_UserWisePermission.Add(oRoleWisePermission);
                }
                return lstSec_UserWisePermission;
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
		public int Add(RoleWisePermission _RoleWisePermission)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_Create",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleId",DbType.Int32, _RoleWisePermission.RoleId);
				AddParameter(oDbCommand, "@PageId",DbType.Int32, _RoleWisePermission.PageId);
				AddParameter(oDbCommand, "@CanCreate",DbType.Boolean, _RoleWisePermission.CanCreate);
				AddParameter(oDbCommand, "@CanDelete",DbType.Boolean, _RoleWisePermission.CanDelete);
				AddParameter(oDbCommand, "@CanUpdate",DbType.Boolean, _RoleWisePermission.CanUpdate);
				AddParameter(oDbCommand, "@CanSelect",DbType.Boolean, _RoleWisePermission.CanSelect);
				AddParameter(oDbCommand, "@AssignedBy",DbType.Int32, _RoleWisePermission.AssignedBy);
				AddParameter(oDbCommand, "@CompanyId",DbType.Int32, _RoleWisePermission.CompanyId);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Update(RoleWisePermission _RoleWisePermission)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_Update",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleId",DbType.Int32, _RoleWisePermission.RoleId);
				AddParameter(oDbCommand, "@PageId",DbType.Int32, _RoleWisePermission.PageId);
				AddParameter(oDbCommand, "@CanCreate",DbType.Boolean, _RoleWisePermission.CanCreate);
				AddParameter(oDbCommand, "@CanDelete",DbType.Boolean, _RoleWisePermission.CanDelete);
				AddParameter(oDbCommand, "@CanUpdate",DbType.Boolean, _RoleWisePermission.CanUpdate);
				AddParameter(oDbCommand, "@CanSelect",DbType.Boolean, _RoleWisePermission.CanSelect);
				AddParameter(oDbCommand, "@AssignedBy",DbType.Int32, _RoleWisePermission.AssignedBy);
				AddParameter(oDbCommand, "@CompanyId",DbType.Int32, _RoleWisePermission.CompanyId);
				AddParameter(oDbCommand, "@PermissionId",DbType.Int64, _RoleWisePermission.PermissionId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Delete(Int64 PermissionId)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_DeleteById",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PermissionId",DbType.Int64,PermissionId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<RoleWisePermission> RoleWisePermission_GetByRoleId(Int32 RoleId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<RoleWisePermission> lstRoleWisePermissions = new List<RoleWisePermission>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetByRoleId",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@RoleId",DbType.Int32,RoleId);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RoleWisePermission oRoleWisePermission = new RoleWisePermission();
					BuildEntity(oDbDataReader, oRoleWisePermission);
					lstRoleWisePermissions.Add(oRoleWisePermission);
				}
				return lstRoleWisePermissions;
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
		public List<RoleWisePermission> RoleWisePermission_GetByCompanyId(Int32 CompanyId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<RoleWisePermission> lstRoleWisePermissions = new List<RoleWisePermission>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("RoleWisePermission_GetByCompanyId",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@CompanyId",DbType.Int32,CompanyId);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RoleWisePermission oRoleWisePermission = new RoleWisePermission();
					BuildEntity(oDbDataReader, oRoleWisePermission);
					lstRoleWisePermissions.Add(oRoleWisePermission);
				}
				return lstRoleWisePermissions;
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
