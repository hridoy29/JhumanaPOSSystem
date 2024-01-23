using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class PageListDAO
	{
		public PageListDAO()
		{
			DbProviderHelper.GetConnection();
		}
		private static void BuildEntity(DbDataReader oDbDataReader, PageList oPageList)
		{
		DataTable dt = oDbDataReader.GetSchemaTable();
		foreach (DataRow item in dt.Rows)
		{
			string col = item.ItemArray[0].ToString();
			switch (col)
			{
					case "PageId":
						oPageList.PageId = Convert.ToInt32(oDbDataReader["PageId"]);
						break;
                    case "ParentId":
                        oPageList.ParentId = Convert.ToInt32(oDbDataReader["ParentId"]);
                        break;
					case "PageTitle":
						oPageList.PageTitle = Convert.ToString(oDbDataReader["PageTitle"]);
						break;
					case "PageName":
						oPageList.PageName = Convert.ToString(oDbDataReader["PageName"]);
						break;
					case "Description":
						oPageList.Description = Convert.ToString(oDbDataReader["Description"]);
						break;
					case "PageUrl":
						oPageList.PageUrl = Convert.ToString(oDbDataReader["PageUrl"]);
						break;

					case "ImageUrl":
					if(oDbDataReader["ImageUrl"] != DBNull.Value)
						oPageList.ImageUrl = Convert.ToString(oDbDataReader["ImageUrl"]);
						break;
					case "ModuleId":
						oPageList.ModuleId = Convert.ToInt32(oDbDataReader["ModuleId"]);
						break;
					case "IsPage":
						oPageList.IsPage = Convert.ToBoolean(oDbDataReader["IsPage"]);
						break;
					case "IsRemoved":
						oPageList.IsRemoved = Convert.ToBoolean(oDbDataReader["IsRemoved"]);
						break;
					case "CreateDate":
						oPageList.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
						break;
					case "CreatorId":
						oPageList.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					default:
						break;
			}
		}
		}
		public List<PageList> PageList_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PageList> lstPageList = new List<PageList>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_GetAll",CommandType.StoredProcedure);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PageList oPageList = new PageList();
					BuildEntity(oDbDataReader, oPageList);
					lstPageList.Add(oPageList);
				}
				return lstPageList;
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
		public List<PageList> PageList_GetDynamic(string WhereCondition,string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PageList> lstPageList = new List<PageList>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_GetDynamic",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PageList oPageList = new PageList();
					BuildEntity(oDbDataReader, oPageList);
					lstPageList.Add(oPageList);
				}
				return lstPageList;
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
		public List<PageList> PageList_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder, ref int rows)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PageList> lstPageList = new List<PageList>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_GetPaged",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
				AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
				AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
				AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
				AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PageList oPageList = new PageList();
					BuildEntity(oDbDataReader, oPageList);
					lstPageList.Add(oPageList);
				}
				if ((oDbDataReader.NextResult()) && (oDbDataReader.Read()))
				{
				rows = oDbDataReader.GetInt32(0);
				}
				return lstPageList;
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
		public PageList PageList_GetById(Int32 PageId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PageList oPageList = new PageList();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_GetById",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PageId",DbType.Int32,PageId);
				 oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPageList);
				}
				return oPageList;
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
		public int Add(PageList _PageList)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_Create",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PageTitle",DbType.String, _PageList.PageTitle);
				AddParameter(oDbCommand, "@PageName",DbType.String, _PageList.PageName);
				AddParameter(oDbCommand, "@Description",DbType.String, _PageList.Description);
				AddParameter(oDbCommand, "@PageUrl",DbType.String, _PageList.PageUrl);
				if (_PageList.ImageUrl!=null)
					AddParameter(oDbCommand, "@ImageUrl",DbType.String, _PageList.ImageUrl);
				else
					AddParameter(oDbCommand, "@ImageUrl",DbType.String,DBNull.Value);
				AddParameter(oDbCommand, "@ModuleId",DbType.Int32, _PageList.ModuleId);
				AddParameter(oDbCommand, "@IsPage",DbType.Boolean, _PageList.IsPage);
				AddParameter(oDbCommand, "@IsRemoved",DbType.Boolean, _PageList.IsRemoved);
				AddParameter(oDbCommand, "@CreateDate",DbType.DateTime, _PageList.CreateDate);
				AddParameter(oDbCommand, "@CreatorId",DbType.Int32, _PageList.CreatorId);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Update(PageList _PageList)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_Update",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PageTitle",DbType.String, _PageList.PageTitle);
				AddParameter(oDbCommand, "@PageName",DbType.String, _PageList.PageName);
				AddParameter(oDbCommand, "@Description",DbType.String, _PageList.Description);
				AddParameter(oDbCommand, "@PageUrl",DbType.String, _PageList.PageUrl);
				if (_PageList.ImageUrl!=null)
					AddParameter(oDbCommand, "@ImageUrl",DbType.String, _PageList.ImageUrl);
				else
					AddParameter(oDbCommand, "@ImageUrl",DbType.String,DBNull.Value);
				AddParameter(oDbCommand, "@ModuleId",DbType.Int32, _PageList.ModuleId);
				AddParameter(oDbCommand, "@IsPage",DbType.Boolean, _PageList.IsPage);
				AddParameter(oDbCommand, "@IsRemoved",DbType.Boolean, _PageList.IsRemoved);
				AddParameter(oDbCommand, "@CreateDate",DbType.DateTime, _PageList.CreateDate);
				AddParameter(oDbCommand, "@CreatorId",DbType.Int32, _PageList.CreatorId);
				AddParameter(oDbCommand, "@PageId",DbType.Int32, _PageList.PageId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Delete(Int32 PageId)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PageList_DeleteById",CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PageId",DbType.Int32,PageId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
