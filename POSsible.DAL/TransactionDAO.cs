using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;
using System.Data.SqlClient;

namespace POSsible.DAL
{
	public class TransactionDAO
	{
		public TransactionDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Transaction oTransaction)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "TransId":
						oTransaction.TransId = Convert.ToInt64(oDbDataReader["TransId"]);
						break;
					case "ParentId":
						oTransaction.ParentId = Convert.ToInt32(oDbDataReader["ParentId"]);
						break;
					case "TransType":
						oTransaction.TransType = Convert.ToInt32(oDbDataReader["TransType"]);
						break;
					case "TransDate":
						oTransaction.TransDate = Convert.ToDateTime(oDbDataReader["TransDate"]);
						break;
					case "ProductId":
						oTransaction.ProductId = Convert.ToInt32(oDbDataReader["ProductId"]);
						break;
					case "Quantity":
                        oTransaction.Quantity = Convert.ToDouble(oDbDataReader["Quantity"]);
						break;
                    case "UsedQty":
                        oTransaction.UsedQty = Convert.ToDouble(oDbDataReader["UsedQty"]);
                        break;
					case "UnitPrice":
						oTransaction.UnitPrice = Convert.ToDouble(oDbDataReader["UnitPrice"]);
						break;
					case "EnteredBy":
						oTransaction.EnteredBy = Convert.ToInt32(oDbDataReader["EnteredBy"]);
						break;
					case "EnteredTime":
						oTransaction.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
						break;
                    case "StoreId":
                        oTransaction.StoreId = Convert.ToInt32(oDbDataReader["StoreId"]);
                        break;
                    case "pName":
                        oTransaction.pName = Convert.ToString(oDbDataReader["pName"]);
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

		public List<Transaction> Transaction_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Transaction> lstTransaction = new List<Transaction>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Transaction oTransaction = new Transaction();
					BuildEntity(oDbDataReader, oTransaction);
					lstTransaction.Add(oTransaction);
				}
				return lstTransaction;
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

		public List<Transaction> Transaction_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Transaction> lstTransaction = new List<Transaction>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Transaction oTransaction = new Transaction();
					BuildEntity(oDbDataReader, oTransaction);
					lstTransaction.Add(oTransaction);
				}
				return lstTransaction;
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

		public Transaction Transaction_GetById(Int64 TransId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Transaction oTransaction = new Transaction();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransId", DbType.Int64, TransId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oTransaction);
				}
				return oTransaction;
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

		public int Add(Transaction _Transaction)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ParentId", DbType.Int32, _Transaction.ParentId);
				AddParameter(oDbCommand, "@TransType", DbType.Int32, _Transaction.TransType);
				AddParameter(oDbCommand, "@TransDate", DbType.DateTime, _Transaction.TransDate);
				AddParameter(oDbCommand, "@ProductId", DbType.Int32, _Transaction.ProductId);
				AddParameter(oDbCommand, "@Quantity", DbType.Double, _Transaction.Quantity);
                AddParameter(oDbCommand, "@UsedQty", DbType.Double, _Transaction.UsedQty);
				AddParameter(oDbCommand, "@UnitPrice", DbType.Double, _Transaction.UnitPrice);
				AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _Transaction.EnteredBy);
				AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Transaction.EnteredTime);
                AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Transaction.StoreId);
				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Transaction _Transaction)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ParentId", DbType.Int32, _Transaction.ParentId);
				AddParameter(oDbCommand, "@TransType", DbType.Int32, _Transaction.TransType);
				AddParameter(oDbCommand, "@TransDate", DbType.DateTime, _Transaction.TransDate);
				AddParameter(oDbCommand, "@ProductId", DbType.Int32, _Transaction.ProductId);
				AddParameter(oDbCommand, "@Quantity", DbType.Double, _Transaction.Quantity);
                AddParameter(oDbCommand, "@UsedQty", DbType.Double, _Transaction.UsedQty);
				AddParameter(oDbCommand, "@UnitPrice", DbType.Double, _Transaction.UnitPrice);
				AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _Transaction.EnteredBy);
				AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Transaction.EnteredTime);
				AddParameter(oDbCommand, "@TransId", DbType.Int64, _Transaction.TransId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 TransId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransId", DbType.Int64, TransId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int Transaction_DeleteByParentId(Int32 ParentId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_DeleteByParentId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ParentId", DbType.Int32, ParentId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteQuery(string query)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand(query, CommandType.Text);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ExecuteScalar(String Query)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand(Query, CommandType.Text);
                return (double)DbProviderHelper.ExecuteScalar(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteScalarInt(String Query)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand(Query, CommandType.Text);
                return (int)DbProviderHelper.ExecuteScalar(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ExecuteScalarString(String Query)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand(Query, CommandType.Text);
                return (string)DbProviderHelper.ExecuteScalar(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Transaction_GetBalanceByHead(int AccLedgerId)
        {
            DbDataReader oDbDataReader = null;
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetBalanceByHead", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccLedgerId);
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
