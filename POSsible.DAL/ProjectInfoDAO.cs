using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class ProjectInfoDAO
	{
		public ProjectInfoDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, ProjectInfo oProjectInfo)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "ProjectId":
						oProjectInfo.ProjectId = Convert.ToInt32(oDbDataReader["ProjectId"]);
						break;
					case "ProjectName":
						oProjectInfo.ProjectName = Convert.ToString(oDbDataReader["ProjectName"]);
						break;
					case "Address":
						if (oDbDataReader["Address"] != DBNull.Value)
							oProjectInfo.Address = Convert.ToString(oDbDataReader["Address"]);
						break;
					case "ContactNo":
						oProjectInfo.ContactNo = Convert.ToString(oDbDataReader["ContactNo"]);
						break;
					case "FaxNo":
						if (oDbDataReader["FaxNo"] != DBNull.Value)
							oProjectInfo.FaxNo = Convert.ToString(oDbDataReader["FaxNo"]);
						break;
					case "EmailAdress":
						if (oDbDataReader["EmailAdress"] != DBNull.Value)
							oProjectInfo.EmailAdress = Convert.ToString(oDbDataReader["EmailAdress"]);
						break;
					case "ProjectURL":
						if (oDbDataReader["ProjectURL"] != DBNull.Value)
							oProjectInfo.ProjectURL = Convert.ToString(oDbDataReader["ProjectURL"]);
						break;
					case "ProjectType":
						if (oDbDataReader["ProjectType"] != DBNull.Value)
							oProjectInfo.ProjectType = Convert.ToString(oDbDataReader["ProjectType"]);
						break;
					case "GroupName":
						oProjectInfo.GroupName = Convert.ToString(oDbDataReader["GroupName"]);
						break;
					case "VoucherMode":
						if (oDbDataReader["VoucherMode"] != DBNull.Value)
							oProjectInfo.VoucherMode = Convert.ToInt32(oDbDataReader["VoucherMode"]);
						break;
					case "VoucherEntryMode":
						if (oDbDataReader["VoucherEntryMode"] != DBNull.Value)
							oProjectInfo.VoucherEntryMode = Convert.ToInt32(oDbDataReader["VoucherEntryMode"]);
						break;
					case "LedgerIdSeparator":
						if (oDbDataReader["LedgerIdSeparator"] != DBNull.Value)
							oProjectInfo.LedgerIdSeparator = Convert.ToString(oDbDataReader["LedgerIdSeparator"]);
						break;
					case "Chairman":
						if (oDbDataReader["Chairman"] != DBNull.Value)
							oProjectInfo.Chairman = Convert.ToString(oDbDataReader["Chairman"]);
						break;
					case "MD":
						if (oDbDataReader["MD"] != DBNull.Value)
							oProjectInfo.MD = Convert.ToString(oDbDataReader["MD"]);
						break;
					case "Director":
						if (oDbDataReader["Director"] != DBNull.Value)
							oProjectInfo.Director = Convert.ToString(oDbDataReader["Director"]);
						break;
					case "Logo":
						if (oDbDataReader["Logo"] != DBNull.Value)
							oProjectInfo.Logo = (Byte[])(oDbDataReader["Logo"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oProjectInfo.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oProjectInfo.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oProjectInfo.CF3 = Convert.ToString(oDbDataReader["CF3"]);
						break;
                    case "VoucherModeName":
                        if (oDbDataReader["VoucherModeName"] != DBNull.Value)
                            oProjectInfo.VoucherModeName = Convert.ToString(oDbDataReader["VoucherModeName"]);
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

		public List<ProjectInfo> ProjectInfo_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ProjectInfo> lstProjectInfo = new List<ProjectInfo>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProjectInfo_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ProjectInfo oProjectInfo = new ProjectInfo();
					BuildEntity(oDbDataReader, oProjectInfo);
					lstProjectInfo.Add(oProjectInfo);
				}
				return lstProjectInfo;
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

		public List<ProjectInfo> ProjectInfo_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ProjectInfo> lstProjectInfo = new List<ProjectInfo>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProjectInfo_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ProjectInfo oProjectInfo = new ProjectInfo();
					BuildEntity(oDbDataReader, oProjectInfo);
					lstProjectInfo.Add(oProjectInfo);
				}
				return lstProjectInfo;
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

		public ProjectInfo ProjectInfo_GetById(int ProjectId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				ProjectInfo oProjectInfo = new ProjectInfo();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProjectInfo_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ProjectId", DbType.Int32, ProjectId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oProjectInfo);
				}
				return oProjectInfo;
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

		public int Add(ProjectInfo _ProjectInfo)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProjectInfo_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ProjectName", DbType.String, _ProjectInfo.ProjectName);
				if (_ProjectInfo.Address != null)
					AddParameter(oDbCommand, "@Address", DbType.String, _ProjectInfo.Address);
				else
					AddParameter(oDbCommand, "@Address",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ContactNo", DbType.String, _ProjectInfo.ContactNo);
				if (_ProjectInfo.FaxNo != null)
					AddParameter(oDbCommand, "@FaxNo", DbType.String, _ProjectInfo.FaxNo);
				else
					AddParameter(oDbCommand, "@FaxNo",DbType.String, DBNull.Value);
				if (_ProjectInfo.EmailAdress != null)
					AddParameter(oDbCommand, "@EmailAdress", DbType.String, _ProjectInfo.EmailAdress);
				else
					AddParameter(oDbCommand, "@EmailAdress",DbType.String, DBNull.Value);
				if (_ProjectInfo.ProjectURL != null)
					AddParameter(oDbCommand, "@ProjectURL", DbType.String, _ProjectInfo.ProjectURL);
				else
					AddParameter(oDbCommand, "@ProjectURL",DbType.String, DBNull.Value);
				if (_ProjectInfo.ProjectType != null)
					AddParameter(oDbCommand, "@ProjectType", DbType.String, _ProjectInfo.ProjectType);
				else
					AddParameter(oDbCommand, "@ProjectType",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@GroupName", DbType.String, _ProjectInfo.GroupName);
				if (_ProjectInfo.VoucherMode.HasValue)
					AddParameter(oDbCommand, "@VoucherMode", DbType.Int32, _ProjectInfo.VoucherMode);
				else
					AddParameter(oDbCommand, "@VoucherMode",DbType.Int32, DBNull.Value);
				if (_ProjectInfo.VoucherEntryMode.HasValue)
					AddParameter(oDbCommand, "@VoucherEntryMode", DbType.Int32, _ProjectInfo.VoucherEntryMode);
				else
					AddParameter(oDbCommand, "@VoucherEntryMode",DbType.Int32, DBNull.Value);
				if (_ProjectInfo.LedgerIdSeparator != null)
					AddParameter(oDbCommand, "@LedgerIdSeparator", DbType.String, _ProjectInfo.LedgerIdSeparator);
				else
					AddParameter(oDbCommand, "@LedgerIdSeparator",DbType.String, DBNull.Value);
				if (_ProjectInfo.Chairman != null)
					AddParameter(oDbCommand, "@Chairman", DbType.String, _ProjectInfo.Chairman);
				else
					AddParameter(oDbCommand, "@Chairman",DbType.String, DBNull.Value);
				if (_ProjectInfo.MD != null)
					AddParameter(oDbCommand, "@MD", DbType.String, _ProjectInfo.MD);
				else
					AddParameter(oDbCommand, "@MD",DbType.String, DBNull.Value);
				if (_ProjectInfo.Director != null)
					AddParameter(oDbCommand, "@Director", DbType.String, _ProjectInfo.Director);
				else
					AddParameter(oDbCommand, "@Director",DbType.String, DBNull.Value);
				if (_ProjectInfo.Logo != null)
					AddParameter(oDbCommand, "@Logo", DbType.Binary, _ProjectInfo.Logo);
				else
					AddParameter(oDbCommand, "@Logo",DbType.Binary, DBNull.Value);
				if (_ProjectInfo.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _ProjectInfo.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_ProjectInfo.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _ProjectInfo.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_ProjectInfo.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _ProjectInfo.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(ProjectInfo _ProjectInfo)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProjectInfo_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ProjectName", DbType.String, _ProjectInfo.ProjectName);
				if (_ProjectInfo.Address != null)
					AddParameter(oDbCommand, "@Address", DbType.String, _ProjectInfo.Address);
				else
					AddParameter(oDbCommand, "@Address",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ContactNo", DbType.String, _ProjectInfo.ContactNo);
				if (_ProjectInfo.FaxNo != null)
					AddParameter(oDbCommand, "@FaxNo", DbType.String, _ProjectInfo.FaxNo);
				else
					AddParameter(oDbCommand, "@FaxNo",DbType.String, DBNull.Value);
				if (_ProjectInfo.EmailAdress != null)
					AddParameter(oDbCommand, "@EmailAdress", DbType.String, _ProjectInfo.EmailAdress);
				else
					AddParameter(oDbCommand, "@EmailAdress",DbType.String, DBNull.Value);
				if (_ProjectInfo.ProjectURL != null)
					AddParameter(oDbCommand, "@ProjectURL", DbType.String, _ProjectInfo.ProjectURL);
				else
					AddParameter(oDbCommand, "@ProjectURL",DbType.String, DBNull.Value);
				if (_ProjectInfo.ProjectType != null)
					AddParameter(oDbCommand, "@ProjectType", DbType.String, _ProjectInfo.ProjectType);
				else
					AddParameter(oDbCommand, "@ProjectType",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@GroupName", DbType.String, _ProjectInfo.GroupName);
				if (_ProjectInfo.VoucherMode.HasValue)
					AddParameter(oDbCommand, "@VoucherMode", DbType.Int32, _ProjectInfo.VoucherMode);
				else
					AddParameter(oDbCommand, "@VoucherMode",DbType.Int32, DBNull.Value);
				if (_ProjectInfo.VoucherEntryMode.HasValue)
					AddParameter(oDbCommand, "@VoucherEntryMode", DbType.Int32, _ProjectInfo.VoucherEntryMode);
				else
					AddParameter(oDbCommand, "@VoucherEntryMode",DbType.Int32, DBNull.Value);
				if (_ProjectInfo.LedgerIdSeparator != null)
					AddParameter(oDbCommand, "@LedgerIdSeparator", DbType.String, _ProjectInfo.LedgerIdSeparator);
				else
					AddParameter(oDbCommand, "@LedgerIdSeparator",DbType.String, DBNull.Value);
				if (_ProjectInfo.Chairman != null)
					AddParameter(oDbCommand, "@Chairman", DbType.String, _ProjectInfo.Chairman);
				else
					AddParameter(oDbCommand, "@Chairman",DbType.String, DBNull.Value);
				if (_ProjectInfo.MD != null)
					AddParameter(oDbCommand, "@MD", DbType.String, _ProjectInfo.MD);
				else
					AddParameter(oDbCommand, "@MD",DbType.String, DBNull.Value);
				if (_ProjectInfo.Director != null)
					AddParameter(oDbCommand, "@Director", DbType.String, _ProjectInfo.Director);
				else
					AddParameter(oDbCommand, "@Director",DbType.String, DBNull.Value);
				if (_ProjectInfo.Logo != null)
					AddParameter(oDbCommand, "@Logo", DbType.Binary, _ProjectInfo.Logo);
				else
					AddParameter(oDbCommand, "@Logo",DbType.Binary, DBNull.Value);
				if (_ProjectInfo.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _ProjectInfo.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_ProjectInfo.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _ProjectInfo.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_ProjectInfo.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _ProjectInfo.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ProjectId", DbType.Int32, _ProjectInfo.ProjectId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int ProjectId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProjectInfo_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ProjectId", DbType.Int32, ProjectId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
