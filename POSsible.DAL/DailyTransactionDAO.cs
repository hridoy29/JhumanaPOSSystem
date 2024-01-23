using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class DailyTransactionDAO
	{
        public DailyTransactionDAO()
		{
			DbProviderHelper.GetConnection();
		}

        private static void BuildEntity(DbDataReader oDbDataReader, DailyTransaction oTransaction)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "TransactionId":
						oTransaction.TransactionId = Convert.ToInt64(oDbDataReader["TransactionId"]);
						break;
					case "TransactionPurposeId":
						oTransaction.TransactionPurposeId = Convert.ToInt32(oDbDataReader["TransactionPurposeId"]);
						break;
					case "WarehouseId":
						oTransaction.WarehouseId = Convert.ToInt32(oDbDataReader["WarehouseId"]);
						break;
					case "TransactionDate":
						oTransaction.TransactionDate = Convert.ToDateTime(oDbDataReader["TransactionDate"]);
						break;
					case "TransactionType":
						oTransaction.TransactionType = Convert.ToString(oDbDataReader["TransactionType"]);
						break;
					case "Narration":
						oTransaction.Narration = Convert.ToString(oDbDataReader["Narration"]);
						break;
					case "DrAmt":
						oTransaction.DrAmt = Convert.ToDecimal(oDbDataReader["DrAmt"]);
						break;
					case "CrAmt":
						oTransaction.CrAmt = Convert.ToDecimal(oDbDataReader["CrAmt"]);
						break;
					case "BalanceAmt":
						if (oDbDataReader["BalanceAmt"] != DBNull.Value)
							oTransaction.BalanceAmt = Convert.ToDecimal(oDbDataReader["BalanceAmt"]);
						break;
					case "SalesId":
						if (oDbDataReader["SalesId"] != DBNull.Value)
							oTransaction.SalesId = Convert.ToInt64(oDbDataReader["SalesId"]);
						break;
					case "PurchaseId":
						if (oDbDataReader["PurchaseId"] != DBNull.Value)
							oTransaction.PurchaseId = Convert.ToInt64(oDbDataReader["PurchaseId"]);
						break;
					case "SalesCollectionId":
						if (oDbDataReader["SalesCollectionId"] != DBNull.Value)
							oTransaction.SalesCollectionId = Convert.ToInt64(oDbDataReader["SalesCollectionId"]);
						break;
					case "PurchasePaymentId":
						if (oDbDataReader["PurchasePaymentId"] != DBNull.Value)
							oTransaction.PurchasePaymentId = Convert.ToInt64(oDbDataReader["PurchasePaymentId"]);
						break;
					case "CustomerId":
						if (oDbDataReader["CustomerId"] != DBNull.Value)
							oTransaction.CustomerId = Convert.ToInt32(oDbDataReader["CustomerId"]);
						break;
					case "SupplierId":
						if (oDbDataReader["SupplierId"] != DBNull.Value)
							oTransaction.SupplierId = Convert.ToInt32(oDbDataReader["SupplierId"]);
						break;
					case "VoucherNo":
						if (oDbDataReader["VoucherNo"] != DBNull.Value)
							oTransaction.VoucherNo = Convert.ToInt64(oDbDataReader["VoucherNo"]);
						break;
					case "BankId":
						if (oDbDataReader["BankId"] != DBNull.Value)
							oTransaction.BankId = Convert.ToInt32(oDbDataReader["BankId"]);
						break;
					case "BranchId":
						if (oDbDataReader["BranchId"] != DBNull.Value)
							oTransaction.BranchId = Convert.ToInt32(oDbDataReader["BranchId"]);
						break;
					case "ChequeNo":
						if (oDbDataReader["ChequeNo"] != DBNull.Value)
							oTransaction.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
						break;
					case "ChequeDate":
						if (oDbDataReader["ChequeDate"] != DBNull.Value)
							oTransaction.ChequeDate = Convert.ToDateTime(oDbDataReader["ChequeDate"]);
						break;
					case "CreatorId":
						oTransaction.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					case "CreateDate":
						oTransaction.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
						break;
					case "IsVoid":
						oTransaction.IsVoid = Convert.ToBoolean(oDbDataReader["IsVoid"]);
						break;
					case "VoidReson":
						if (oDbDataReader["VoidReson"] != DBNull.Value)
							oTransaction.VoidReson = Convert.ToString(oDbDataReader["VoidReson"]);
						break;
					case "VoidDate":
						if (oDbDataReader["VoidDate"] != DBNull.Value)
							oTransaction.VoidDate = Convert.ToDateTime(oDbDataReader["VoidDate"]);
						break;
					case "VoidBy":
						if (oDbDataReader["VoidBy"] != DBNull.Value)
							oTransaction.VoidBy = Convert.ToInt32(oDbDataReader["VoidBy"]);
						break;
                    case "TransactionPurposeName":
                        if (oDbDataReader["TransactionPurposeName"] != DBNull.Value)
                            oTransaction.TransactionPurposeName = Convert.ToString(oDbDataReader["TransactionPurposeName"]);
                        break;
                    case "Bank":
                        if (oDbDataReader["Bank"] != DBNull.Value)
                            oTransaction.Bank = Convert.ToString(oDbDataReader["Bank"]);
                        break;
                    case "Branch":
                        if (oDbDataReader["Branch"] != DBNull.Value)
                            oTransaction.Branch = Convert.ToString(oDbDataReader["Branch"]);
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

		public List<DailyTransaction> DailyTransaction_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<DailyTransaction> lstTransaction = new List<DailyTransaction>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					DailyTransaction oTransaction = new DailyTransaction();
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

		public List<DailyTransaction> DailyTransaction_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<DailyTransaction> lstDailyTransaction = new List<DailyTransaction>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					DailyTransaction oDailyTransaction = new DailyTransaction();
					BuildEntity(oDbDataReader, oDailyTransaction);
					lstDailyTransaction.Add(oDailyTransaction);
				}
				return lstDailyTransaction;
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

		public DailyTransaction DailyTransaction_GetById(Int64 TransactionId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				DailyTransaction oDailyTransaction = new DailyTransaction();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionId", DbType.Int64, TransactionId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oDailyTransaction);
				}
				return oDailyTransaction;
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

		public Int64 Add(DailyTransaction _Transaction)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionPurposeId", DbType.Int32, _Transaction.TransactionPurposeId);
				AddParameter(oDbCommand, "@WarehouseId", DbType.Int32, _Transaction.WarehouseId);
				AddParameter(oDbCommand, "@TransactionDate", DbType.DateTime, _Transaction.TransactionDate);
				AddParameter(oDbCommand, "@TransactionType", DbType.String, _Transaction.TransactionType);
				AddParameter(oDbCommand, "@Narration", DbType.String, _Transaction.Narration);
				AddParameter(oDbCommand, "@DrAmt", DbType.Decimal, _Transaction.DrAmt);
				AddParameter(oDbCommand, "@CrAmt", DbType.Decimal, _Transaction.CrAmt);
				if (_Transaction.BalanceAmt.HasValue)
					AddParameter(oDbCommand, "@BalanceAmt", DbType.Decimal, _Transaction.BalanceAmt);
				else
					AddParameter(oDbCommand, "@BalanceAmt",DbType.Decimal, DBNull.Value);
				if (_Transaction.SalesId.HasValue)
					AddParameter(oDbCommand, "@SalesId", DbType.Int64, _Transaction.SalesId);
				else
					AddParameter(oDbCommand, "@SalesId",DbType.Int64, DBNull.Value);
				if (_Transaction.PurchaseId.HasValue)
					AddParameter(oDbCommand, "@PurchaseId", DbType.Int64, _Transaction.PurchaseId);
				else
					AddParameter(oDbCommand, "@PurchaseId",DbType.Int64, DBNull.Value);
				if (_Transaction.SalesCollectionId.HasValue)
					AddParameter(oDbCommand, "@SalesCollectionId", DbType.Int64, _Transaction.SalesCollectionId);
				else
					AddParameter(oDbCommand, "@SalesCollectionId",DbType.Int64, DBNull.Value);
				if (_Transaction.PurchasePaymentId.HasValue)
					AddParameter(oDbCommand, "@PurchasePaymentId", DbType.Int64, _Transaction.PurchasePaymentId);
				else
					AddParameter(oDbCommand, "@PurchasePaymentId",DbType.Int64, DBNull.Value);
				if (_Transaction.CustomerId.HasValue)
					AddParameter(oDbCommand, "@CustomerId", DbType.Int32, _Transaction.CustomerId);
				else
					AddParameter(oDbCommand, "@CustomerId",DbType.Int32, DBNull.Value);
				if (_Transaction.SupplierId.HasValue)
					AddParameter(oDbCommand, "@SupplierId", DbType.Int32, _Transaction.SupplierId);
				else
					AddParameter(oDbCommand, "@SupplierId",DbType.Int32, DBNull.Value);
				if (_Transaction.VoucherNo != null)
                    AddParameter(oDbCommand, "@VoucherNo", DbType.Int64, _Transaction.VoucherNo);
				else
                    AddParameter(oDbCommand, "@VoucherNo", DbType.Int64, DBNull.Value);
				if (_Transaction.BankId.HasValue)
					AddParameter(oDbCommand, "@BankId", DbType.Int32, _Transaction.BankId);
				else
					AddParameter(oDbCommand, "@BankId",DbType.Int32, DBNull.Value);
				if (_Transaction.BranchId.HasValue)
					AddParameter(oDbCommand, "@BranchId", DbType.Int32, _Transaction.BranchId);
				else
					AddParameter(oDbCommand, "@BranchId",DbType.Int32, DBNull.Value);
				if (_Transaction.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _Transaction.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_Transaction.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _Transaction.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _Transaction.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _Transaction.CreateDate);
				AddParameter(oDbCommand, "@IsVoid", DbType.Boolean, _Transaction.IsVoid);
				if (_Transaction.VoidReson != null)
					AddParameter(oDbCommand, "@VoidReson", DbType.String, _Transaction.VoidReson);
				else
					AddParameter(oDbCommand, "@VoidReson",DbType.String, DBNull.Value);
				if (_Transaction.VoidDate.HasValue)
					AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, _Transaction.VoidDate);
				else
					AddParameter(oDbCommand, "@VoidDate",DbType.DateTime, DBNull.Value);
				if (_Transaction.VoidBy.HasValue)
					AddParameter(oDbCommand, "@VoidBy", DbType.Int32, _Transaction.VoidBy);
				else
					AddParameter(oDbCommand, "@VoidBy",DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@VoucherType", DbType.String, _Transaction.VoucherType);

				return Convert.ToInt64(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(DailyTransaction _Transaction)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionPurposeId", DbType.Int32, _Transaction.TransactionPurposeId);
				AddParameter(oDbCommand, "@WarehouseId", DbType.Int32, _Transaction.WarehouseId);
				AddParameter(oDbCommand, "@TransactionDate", DbType.DateTime, _Transaction.TransactionDate);
				AddParameter(oDbCommand, "@TransactionType", DbType.String, _Transaction.TransactionType);
				AddParameter(oDbCommand, "@Narration", DbType.String, _Transaction.Narration);
				AddParameter(oDbCommand, "@DrAmt", DbType.Decimal, _Transaction.DrAmt);
				AddParameter(oDbCommand, "@CrAmt", DbType.Decimal, _Transaction.CrAmt);
				if (_Transaction.BalanceAmt.HasValue)
					AddParameter(oDbCommand, "@BalanceAmt", DbType.Decimal, _Transaction.BalanceAmt);
				else
					AddParameter(oDbCommand, "@BalanceAmt",DbType.Decimal, DBNull.Value);
				if (_Transaction.CustomerId.HasValue)
					AddParameter(oDbCommand, "@CustomerId", DbType.Int32, _Transaction.CustomerId);
				else
					AddParameter(oDbCommand, "@CustomerId",DbType.Int32, DBNull.Value);
				if (_Transaction.SupplierId.HasValue)
					AddParameter(oDbCommand, "@SupplierId", DbType.Int32, _Transaction.SupplierId);
				else
					AddParameter(oDbCommand, "@SupplierId",DbType.Int32, DBNull.Value);
				if (_Transaction.BankId.HasValue)
					AddParameter(oDbCommand, "@BankId", DbType.Int32, _Transaction.BankId);
				else
					AddParameter(oDbCommand, "@BankId",DbType.Int32, DBNull.Value);
				if (_Transaction.BranchId.HasValue)
					AddParameter(oDbCommand, "@BranchId", DbType.Int32, _Transaction.BranchId);
				else
					AddParameter(oDbCommand, "@BranchId",DbType.Int32, DBNull.Value);
				if (_Transaction.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _Transaction.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_Transaction.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _Transaction.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@IsVoid", DbType.Boolean, _Transaction.IsVoid);
				if (_Transaction.VoidReson != null)
					AddParameter(oDbCommand, "@VoidReson", DbType.String, _Transaction.VoidReson);
				else
					AddParameter(oDbCommand, "@VoidReson",DbType.String, DBNull.Value);
				if (_Transaction.VoidDate.HasValue)
					AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, _Transaction.VoidDate);
				else
					AddParameter(oDbCommand, "@VoidDate",DbType.DateTime, DBNull.Value);
				if (_Transaction.VoidBy.HasValue)
					AddParameter(oDbCommand, "@VoidBy", DbType.Int32, _Transaction.VoidBy);
				else
					AddParameter(oDbCommand, "@VoidBy",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _Transaction.TransactionId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int UpdateIsVoid(DailyTransaction _Transaction)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_UpdateIsVoid", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@IsVoid", DbType.Boolean, _Transaction.IsVoid);
                if (_Transaction.VoidReson != null)
                    AddParameter(oDbCommand, "@VoidReson", DbType.String, _Transaction.VoidReson);
                else
                    AddParameter(oDbCommand, "@VoidReson", DbType.String, DBNull.Value);
                if (_Transaction.VoidDate.HasValue)
                    AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, _Transaction.VoidDate);
                else
                    AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, DBNull.Value);
                if (_Transaction.VoidBy.HasValue)
                    AddParameter(oDbCommand, "@VoidBy", DbType.Int32, _Transaction.VoidBy);
                else
                    AddParameter(oDbCommand, "@VoidBy", DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _Transaction.TransactionId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public int Delete(Int64 TransactionId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DailyTransaction_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionId", DbType.Int64, TransactionId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public DataTable DailyTransaction_MonthlyExpense(DateTime FromDate, DateTime ToDate)
        {
            DbDataReader oDbDataReader = null;
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_MonthlyExpense", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@FromDate", DbType.Date, FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.Date, ToDate);
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
