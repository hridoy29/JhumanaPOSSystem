using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class CompanyDAO
	{
		public CompanyDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Company oCompany)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
                    case "CompanyId":
                        if (oDbDataReader["CompanyId"] != DBNull.Value)
                            oCompany.CompanyId = Convert.ToInt32(oDbDataReader["CompanyId"]);
						break;
					case "CompanyName":
						if (oDbDataReader["CompanyName"] != DBNull.Value)
							oCompany.CompanyName = Convert.ToString(oDbDataReader["CompanyName"]);
						break;
					case "CompanyCode":
						if (oDbDataReader["CompanyCode"] != DBNull.Value)
							oCompany.CompanyCode = Convert.ToString(oDbDataReader["CompanyCode"]);
						break;
					case "CompanyAddress":
						if (oDbDataReader["CompanyAddress"] != DBNull.Value)
							oCompany.CompanyAddress = Convert.ToString(oDbDataReader["CompanyAddress"]);
						break;
					case "LicenseNo":
						if (oDbDataReader["LicenseNo"] != DBNull.Value)
							oCompany.LicenseNo = Convert.ToString(oDbDataReader["LicenseNo"]);
						break;
					case "MissionStatement":
						if (oDbDataReader["MissionStatement"] != DBNull.Value)
							oCompany.MissionStatement = Convert.ToString(oDbDataReader["MissionStatement"]);
						break;
					case "Phone":
						if (oDbDataReader["Phone"] != DBNull.Value)
							oCompany.Phone = Convert.ToString(oDbDataReader["Phone"]);
						break;
					case "Fax":
						if (oDbDataReader["Fax"] != DBNull.Value)
							oCompany.Fax = Convert.ToString(oDbDataReader["Fax"]);
						break;
					case "Email":
						if (oDbDataReader["Email"] != DBNull.Value)
							oCompany.Email = Convert.ToString(oDbDataReader["Email"]);
						break;
					case "Web":
						if (oDbDataReader["Web"] != DBNull.Value)
							oCompany.Web = Convert.ToString(oDbDataReader["Web"]);
						break;
					case "Logo":
						if (oDbDataReader["Logo"] != DBNull.Value)
							oCompany.Logo = (Byte[])(oDbDataReader["Logo"]);
						break;
                    case "OperatingAddrLine1":
                        if (oDbDataReader["OperatingAddrLine1"] != DBNull.Value)
                            oCompany.OperatingAddrLine1 = Convert.ToString(oDbDataReader["OperatingAddrLine1"]);
                        break;
                    case "OperatingAddrLine2":
                        if (oDbDataReader["OperatingAddrLine2"] != DBNull.Value)
                            oCompany.OperatingAddrLine2 = Convert.ToString(oDbDataReader["OperatingAddrLine2"]);
                        break;
                    case "WarehouseAddrLine1":
                        if (oDbDataReader["WarehouseAddrLine1"] != DBNull.Value)
                            oCompany.WarehouseAddrLine1 = Convert.ToString(oDbDataReader["WarehouseAddrLine1"]);
                        break;
                    case "WarehouseAddrLine2":
                        if (oDbDataReader["WarehouseAddrLine2"] != DBNull.Value)
                            oCompany.WarehouseAddrLine2 = Convert.ToString(oDbDataReader["WarehouseAddrLine2"]);
                        break;
                    case "WarehouseAddrLine3":
                        if (oDbDataReader["WarehouseAddrLine3"] != DBNull.Value)
                            oCompany.WarehouseAddrLine3 = Convert.ToString(oDbDataReader["WarehouseAddrLine3"]);
                        break;
                    case "WarehouseAddrLine4":
                        if (oDbDataReader["WarehouseAddrLine4"] != DBNull.Value)
                            oCompany.WarehouseAddrLine4 = Convert.ToString(oDbDataReader["WarehouseAddrLine4"]);
                        break;
                    case "WarehouseAddrLine5":
                        if (oDbDataReader["WarehouseAddrLine5"] != DBNull.Value)
                            oCompany.WarehouseAddrLine5 = Convert.ToString(oDbDataReader["WarehouseAddrLine5"]);
                        break;
                    case "WarehouseAddrLine6":
                        if (oDbDataReader["WarehouseAddrLine6"] != DBNull.Value)
                            oCompany.WarehouseAddrLine6 = Convert.ToString(oDbDataReader["WarehouseAddrLine6"]);
                        break;
                    case "WarehouseAddrLine7":
                        if (oDbDataReader["WarehouseAddrLine7"] != DBNull.Value)
                            oCompany.WarehouseAddrLine7 = Convert.ToString(oDbDataReader["WarehouseAddrLine7"]);
                        break;
                    case "WarehouseAddrLine8":
                        if (oDbDataReader["WarehouseAddrLine8"] != DBNull.Value)
                            oCompany.WarehouseAddrLine8 = Convert.ToString(oDbDataReader["WarehouseAddrLine8"]);
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

		public List<Company> Company_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Company> lstCompany = new List<Company>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Company_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Company oCompany = new Company();
					BuildEntity(oDbDataReader, oCompany);
					lstCompany.Add(oCompany);
				}
				return lstCompany;
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

		public List<Company> Company_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Company> lstCompany = new List<Company>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Company_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Company oCompany = new Company();
					BuildEntity(oDbDataReader, oCompany);
					lstCompany.Add(oCompany);
				}
				return lstCompany;
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

		public int Add(Company _Company)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Company_Create", CommandType.StoredProcedure);
				if (_Company.CompanyName != null)
					AddParameter(oDbCommand, "@CompanyName", DbType.String, _Company.CompanyName);
				else
					AddParameter(oDbCommand, "@CompanyName",DbType.String, DBNull.Value);
				if (_Company.CompanyCode != null)
					AddParameter(oDbCommand, "@CompanyCode", DbType.String, _Company.CompanyCode);
				else
					AddParameter(oDbCommand, "@CompanyCode",DbType.String, DBNull.Value);
				if (_Company.CompanyAddress != null)
					AddParameter(oDbCommand, "@CompanyAddress", DbType.String, _Company.CompanyAddress);
				else
					AddParameter(oDbCommand, "@CompanyAddress",DbType.String, DBNull.Value);
				if (_Company.LicenseNo != null)
					AddParameter(oDbCommand, "@LicenseNo", DbType.String, _Company.LicenseNo);
				else
					AddParameter(oDbCommand, "@LicenseNo",DbType.String, DBNull.Value);
				if (_Company.MissionStatement != null)
					AddParameter(oDbCommand, "@MissionStatement", DbType.String, _Company.MissionStatement);
				else
					AddParameter(oDbCommand, "@MissionStatement",DbType.String, DBNull.Value);
				if (_Company.Phone != null)
					AddParameter(oDbCommand, "@Phone", DbType.String, _Company.Phone);
				else
					AddParameter(oDbCommand, "@Phone",DbType.String, DBNull.Value);
				if (_Company.Fax != null)
					AddParameter(oDbCommand, "@Fax", DbType.String, _Company.Fax);
				else
					AddParameter(oDbCommand, "@Fax",DbType.String, DBNull.Value);
				if (_Company.Email != null)
					AddParameter(oDbCommand, "@Email", DbType.String, _Company.Email);
				else
					AddParameter(oDbCommand, "@Email",DbType.String, DBNull.Value);
				if (_Company.Web != null)
					AddParameter(oDbCommand, "@Web", DbType.String, _Company.Web);
				else
					AddParameter(oDbCommand, "@Web",DbType.String, DBNull.Value);
				if (_Company.Logo != null)
					AddParameter(oDbCommand, "@Logo", DbType.Binary, _Company.Logo);
				else
					AddParameter(oDbCommand, "@Logo",DbType.Binary, DBNull.Value);
                if (_Company.OperatingAddrLine1 != null)
                    AddParameter(oDbCommand, "@OperatingAddrLine1", DbType.String, _Company.OperatingAddrLine1);
                else
                    AddParameter(oDbCommand, "@OperatingAddrLine1", DbType.String, DBNull.Value);
                if (_Company.OperatingAddrLine2 != null)
                    AddParameter(oDbCommand, "@OperatingAddrLine2", DbType.String, _Company.OperatingAddrLine2);
                else
                    AddParameter(oDbCommand, "@OperatingAddrLine2", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine1 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine1", DbType.String, _Company.WarehouseAddrLine1);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine1", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine2 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine2", DbType.String, _Company.WarehouseAddrLine2);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine2", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine3 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine3", DbType.String, _Company.WarehouseAddrLine3);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine3", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine4 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine4", DbType.String, _Company.WarehouseAddrLine4);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine4", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine5 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine5", DbType.String, _Company.WarehouseAddrLine5);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine5", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine6 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine6", DbType.String, _Company.WarehouseAddrLine6);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine6", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine7 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine7", DbType.String, _Company.WarehouseAddrLine7);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine7", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine8 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine8", DbType.String, _Company.WarehouseAddrLine8);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine8", DbType.String, DBNull.Value);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int update(Company _Company)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Company_Update", CommandType.StoredProcedure);
				if (_Company.CompanyName != null)
					AddParameter(oDbCommand, "@CompanyName", DbType.String, _Company.CompanyName);
				else
					AddParameter(oDbCommand, "@CompanyName",DbType.String, DBNull.Value);
				if (_Company.CompanyCode != null)
					AddParameter(oDbCommand, "@CompanyCode", DbType.String, _Company.CompanyCode);
				else
					AddParameter(oDbCommand, "@CompanyCode",DbType.String, DBNull.Value);
				if (_Company.CompanyAddress != null)
					AddParameter(oDbCommand, "@CompanyAddress", DbType.String, _Company.CompanyAddress);
				else
					AddParameter(oDbCommand, "@CompanyAddress",DbType.String, DBNull.Value);
				if (_Company.LicenseNo != null)
					AddParameter(oDbCommand, "@LicenseNo", DbType.String, _Company.LicenseNo);
				else
					AddParameter(oDbCommand, "@LicenseNo",DbType.String, DBNull.Value);
				if (_Company.MissionStatement != null)
					AddParameter(oDbCommand, "@MissionStatement", DbType.String, _Company.MissionStatement);
				else
					AddParameter(oDbCommand, "@MissionStatement",DbType.String, DBNull.Value);
				if (_Company.Phone != null)
					AddParameter(oDbCommand, "@Phone", DbType.String, _Company.Phone);
				else
					AddParameter(oDbCommand, "@Phone",DbType.String, DBNull.Value);
				if (_Company.Fax != null)
					AddParameter(oDbCommand, "@Fax", DbType.String, _Company.Fax);
				else
					AddParameter(oDbCommand, "@Fax",DbType.String, DBNull.Value);
				if (_Company.Email != null)
					AddParameter(oDbCommand, "@Email", DbType.String, _Company.Email);
				else
					AddParameter(oDbCommand, "@Email",DbType.String, DBNull.Value);
				if (_Company.Web != null)
					AddParameter(oDbCommand, "@Web", DbType.String, _Company.Web);
				else
					AddParameter(oDbCommand, "@Web",DbType.String, DBNull.Value);
				if (_Company.Logo != null)
					AddParameter(oDbCommand, "@Logo", DbType.Binary, _Company.Logo);
				else
					AddParameter(oDbCommand, "@Logo",DbType.Binary, DBNull.Value);
                if (_Company.OperatingAddrLine1 != null)
                    AddParameter(oDbCommand, "@OperatingAddrLine1", DbType.String, _Company.OperatingAddrLine1);
                else
                    AddParameter(oDbCommand, "@OperatingAddrLine1", DbType.String, DBNull.Value);
                if (_Company.OperatingAddrLine2 != null)
                    AddParameter(oDbCommand, "@OperatingAddrLine2", DbType.String, _Company.OperatingAddrLine2);
                else
                    AddParameter(oDbCommand, "@OperatingAddrLine2", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine1 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine1", DbType.String, _Company.WarehouseAddrLine1);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine1", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine2 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine2", DbType.String, _Company.WarehouseAddrLine2);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine2", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine3 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine3", DbType.String, _Company.WarehouseAddrLine3);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine3", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine4 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine4", DbType.String, _Company.WarehouseAddrLine4);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine4", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine5 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine5", DbType.String, _Company.WarehouseAddrLine5);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine5", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine6 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine6", DbType.String, _Company.WarehouseAddrLine6);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine6", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine7 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine7", DbType.String, _Company.WarehouseAddrLine7);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine7", DbType.String, DBNull.Value);
                if (_Company.WarehouseAddrLine8 != null)
                    AddParameter(oDbCommand, "@WarehouseAddrLine8", DbType.String, _Company.WarehouseAddrLine8);
                else
                    AddParameter(oDbCommand, "@WarehouseAddrLine8", DbType.String, DBNull.Value);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error in Update.", "POSsible");
                throw;
            }
        }
	}
}
