using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class BankDAO
	{
		public BankDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Bank oBank)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "BankId":
						oBank.BankId = Convert.ToInt32(oDbDataReader["BankId"]);
						break;
					case "BankName":
						oBank.BankName = Convert.ToString(oDbDataReader["BankName"]);
						break;
					case "AccountLgId":
						if (oDbDataReader["AccountLgId"] != DBNull.Value)
							oBank.AccountLgId = Convert.ToInt32(oDbDataReader["AccountLgId"]);
						break;
					case "BankAddress":
						if (oDbDataReader["BankAddress"] != DBNull.Value)
							oBank.BankAddress = Convert.ToString(oDbDataReader["BankAddress"]);
						break;
					case "BankPhone":
						if (oDbDataReader["BankPhone"] != DBNull.Value)
							oBank.BankPhone = Convert.ToString(oDbDataReader["BankPhone"]);
						break;
					case "StoreId":
						oBank.StoreId = Convert.ToInt32(oDbDataReader["StoreId"]);
						break;
					case "ProjectId":
						if (oDbDataReader["ProjectId"] != DBNull.Value)
							oBank.ProjectId = Convert.ToInt32(oDbDataReader["ProjectId"]);
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

		public List<Bank> Bank_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Bank> lstBank = new List<Bank>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Bank_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Bank oBank = new Bank();
					BuildEntity(oDbDataReader, oBank);
					lstBank.Add(oBank);
				}
				return lstBank;
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

		public List<Bank> Bank_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Bank> lstBank = new List<Bank>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Bank_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Bank oBank = new Bank();
					BuildEntity(oDbDataReader, oBank);
					lstBank.Add(oBank);
				}
				return lstBank;
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

		public Bank Bank_GetById(int BankId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Bank oBank = new Bank();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Bank_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@BankId", DbType.Int32, BankId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oBank);
				}
				return oBank;
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

		public int Add(Bank _Bank)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Bank_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@BankName", DbType.String, _Bank.BankName);
				if (_Bank.AccountLgId.HasValue)
					AddParameter(oDbCommand, "@AccountLgId", DbType.Int32, _Bank.AccountLgId);
				else
					AddParameter(oDbCommand, "@AccountLgId",DbType.Int32, DBNull.Value);
				if (_Bank.BankAddress != null)
					AddParameter(oDbCommand, "@BankAddress", DbType.String, _Bank.BankAddress);
				else
					AddParameter(oDbCommand, "@BankAddress",DbType.String, DBNull.Value);
				if (_Bank.BankPhone != null)
					AddParameter(oDbCommand, "@BankPhone", DbType.String, _Bank.BankPhone);
				else
					AddParameter(oDbCommand, "@BankPhone",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Bank.StoreId);
				if (_Bank.ProjectId.HasValue)
					AddParameter(oDbCommand, "@ProjectId", DbType.Int32, _Bank.ProjectId);
				else
					AddParameter(oDbCommand, "@ProjectId",DbType.Int32, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Bank _Bank)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Bank_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@BankName", DbType.String, _Bank.BankName);
				if (_Bank.AccountLgId.HasValue)
					AddParameter(oDbCommand, "@AccountLgId", DbType.Int32, _Bank.AccountLgId);
				else
					AddParameter(oDbCommand, "@AccountLgId",DbType.Int32, DBNull.Value);
				if (_Bank.BankAddress != null)
					AddParameter(oDbCommand, "@BankAddress", DbType.String, _Bank.BankAddress);
				else
					AddParameter(oDbCommand, "@BankAddress",DbType.String, DBNull.Value);
				if (_Bank.BankPhone != null)
					AddParameter(oDbCommand, "@BankPhone", DbType.String, _Bank.BankPhone);
				else
					AddParameter(oDbCommand, "@BankPhone",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Bank.StoreId);
				if (_Bank.ProjectId.HasValue)
					AddParameter(oDbCommand, "@ProjectId", DbType.Int32, _Bank.ProjectId);
				else
					AddParameter(oDbCommand, "@ProjectId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@BankId", DbType.Int32, _Bank.BankId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int BankId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Bank_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@BankId", DbType.Int32, BankId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
