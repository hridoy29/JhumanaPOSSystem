using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class PurchasePaymentDAO
	{
		public PurchasePaymentDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, PurchasePayment oPurchasePayment)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "PurchasePaymentId":
						oPurchasePayment.PurchasePaymentId = Convert.ToInt64(oDbDataReader["PurchasePaymentId"]);
						break;
					case "PurchaseId":
						if (oDbDataReader["PurchaseId"] != DBNull.Value)
							oPurchasePayment.PurchaseId = Convert.ToInt32(oDbDataReader["PurchaseId"]);
						break;
					case "PaymentDate":
						oPurchasePayment.PaymentDate = Convert.ToDateTime(oDbDataReader["PaymentDate"]);
						break;
					case "PaymentType":
						oPurchasePayment.PaymentType = Convert.ToString(oDbDataReader["PaymentType"]);
						break;
					case "ChequeNo":
						if (oDbDataReader["ChequeNo"] != DBNull.Value)
							oPurchasePayment.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
						break;
					case "ChequeDate":
						if (oDbDataReader["ChequeDate"] != DBNull.Value)
							oPurchasePayment.ChequeDate = Convert.ToDateTime(oDbDataReader["ChequeDate"]);
						break;
					case "ChequeBank":
						if (oDbDataReader["ChequeBank"] != DBNull.Value)
							oPurchasePayment.ChequeBank = Convert.ToString(oDbDataReader["ChequeBank"]);
						break;
					case "IsChqCleared":
						if (oDbDataReader["IsChqCleared"] != DBNull.Value)
							oPurchasePayment.IsChqCleared = Convert.ToBoolean(oDbDataReader["IsChqCleared"]);
						break;
					case "MemoNumber":
						oPurchasePayment.MemoNumber = Convert.ToString(oDbDataReader["MemoNumber"]);
						break;
					case "PaidAmount":
						oPurchasePayment.PaidAmount = Convert.ToDecimal(oDbDataReader["PaidAmount"]);
						break;
					case "DiscAmount":
						oPurchasePayment.DiscAmount = Convert.ToDecimal(oDbDataReader["DiscAmount"]);
						break;
					case "RemAmount":
						oPurchasePayment.RemAmount = Convert.ToDecimal(oDbDataReader["RemAmount"]);
						break;
					case "DueBalance":
						if (oDbDataReader["DueBalance"] != DBNull.Value)
							oPurchasePayment.DueBalance = Convert.ToDecimal(oDbDataReader["DueBalance"]);
						break;
					case "PaidBy":
						if (oDbDataReader["PaidBy"] != DBNull.Value)
							oPurchasePayment.PaidBy = Convert.ToInt32(oDbDataReader["PaidBy"]);
						break;
					case "ReceivedBy":
						if (oDbDataReader["ReceivedBy"] != DBNull.Value)
							oPurchasePayment.ReceivedBy = Convert.ToString(oDbDataReader["ReceivedBy"]);
						break;
					case "Remarks":
						if (oDbDataReader["Remarks"] != DBNull.Value)
							oPurchasePayment.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
						break;
					case "ManualMRNo":
						if (oDbDataReader["ManualMRNo"] != DBNull.Value)
							oPurchasePayment.ManualMRNo = Convert.ToString(oDbDataReader["ManualMRNo"]);
						break;
					case "MRBookNo":
						if (oDbDataReader["MRBookNo"] != DBNull.Value)
							oPurchasePayment.MRBookNo = Convert.ToString(oDbDataReader["MRBookNo"]);
						break;
					case "EnteredBy":
						if (oDbDataReader["EnteredBy"] != DBNull.Value)
							oPurchasePayment.EnteredBy = Convert.ToInt32(oDbDataReader["EnteredBy"]);
						break;
					case "EnteredTime":
						if (oDbDataReader["EnteredTime"] != DBNull.Value)
							oPurchasePayment.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
						break;
					case "UpdatedBy":
						if (oDbDataReader["UpdatedBy"] != DBNull.Value)
							oPurchasePayment.UpdatedBy = Convert.ToInt32(oDbDataReader["UpdatedBy"]);
						break;
					case "UpdatedTime":
						if (oDbDataReader["UpdatedTime"] != DBNull.Value)
							oPurchasePayment.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oPurchasePayment.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oPurchasePayment.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oPurchasePayment.CF3 = Convert.ToString(oDbDataReader["CF3"]);
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

		public List<PurchasePayment> PurchasePayment_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchasePayment> lstPurchasePayment = new List<PurchasePayment>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchasePayment oPurchasePayment = new PurchasePayment();
					BuildEntity(oDbDataReader, oPurchasePayment);
					lstPurchasePayment.Add(oPurchasePayment);
				}
				return lstPurchasePayment;
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

		public List<PurchasePayment> PurchasePayment_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchasePayment> lstPurchasePayment = new List<PurchasePayment>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchasePayment oPurchasePayment = new PurchasePayment();
					BuildEntity(oDbDataReader, oPurchasePayment);
					lstPurchasePayment.Add(oPurchasePayment);
				}
				return lstPurchasePayment;
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

		public PurchasePayment PurchasePayment_GetById(Int64 PurchasePaymentId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PurchasePayment oPurchasePayment = new PurchasePayment();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PurchasePaymentId", DbType.Int64, PurchasePaymentId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPurchasePayment);
				}
				return oPurchasePayment;
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

		public int Add(PurchasePayment _PurchasePayment)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_Create", CommandType.StoredProcedure);
				if (_PurchasePayment.PurchaseId.HasValue)
					AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, _PurchasePayment.PurchaseId);
				else
					AddParameter(oDbCommand, "@PurchaseId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@PaymentDate", DbType.DateTime, _PurchasePayment.PaymentDate);
				AddParameter(oDbCommand, "@PaymentType", DbType.String, _PurchasePayment.PaymentType);
				if (_PurchasePayment.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _PurchasePayment.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_PurchasePayment.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _PurchasePayment.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				if (_PurchasePayment.ChequeBank != null)
					AddParameter(oDbCommand, "@ChequeBank", DbType.String, _PurchasePayment.ChequeBank);
				else
					AddParameter(oDbCommand, "@ChequeBank",DbType.String, DBNull.Value);
				if (_PurchasePayment.IsChqCleared.HasValue)
					AddParameter(oDbCommand, "@IsChqCleared", DbType.Boolean, _PurchasePayment.IsChqCleared);
				else
					AddParameter(oDbCommand, "@IsChqCleared",DbType.Boolean, DBNull.Value);
				AddParameter(oDbCommand, "@MemoNumber", DbType.String, _PurchasePayment.MemoNumber);
				AddParameter(oDbCommand, "@PaidAmount", DbType.Decimal, _PurchasePayment.PaidAmount);
				AddParameter(oDbCommand, "@DiscAmount", DbType.Decimal, _PurchasePayment.DiscAmount);
				AddParameter(oDbCommand, "@RemAmount", DbType.Decimal, _PurchasePayment.RemAmount);
				if (_PurchasePayment.DueBalance.HasValue)
					AddParameter(oDbCommand, "@DueBalance", DbType.Decimal, _PurchasePayment.DueBalance);
				else
					AddParameter(oDbCommand, "@DueBalance",DbType.Decimal, DBNull.Value);
				if (_PurchasePayment.PaidBy.HasValue)
					AddParameter(oDbCommand, "@PaidBy", DbType.Int32, _PurchasePayment.PaidBy);
				else
					AddParameter(oDbCommand, "@PaidBy",DbType.Int32, DBNull.Value);
				if (_PurchasePayment.ReceivedBy != null)
					AddParameter(oDbCommand, "@ReceivedBy", DbType.String, _PurchasePayment.ReceivedBy);
				else
					AddParameter(oDbCommand, "@ReceivedBy",DbType.String, DBNull.Value);
				if (_PurchasePayment.Remarks != null)
					AddParameter(oDbCommand, "@Remarks", DbType.String, _PurchasePayment.Remarks);
				else
					AddParameter(oDbCommand, "@Remarks",DbType.String, DBNull.Value);
				if (_PurchasePayment.ManualMRNo != null)
					AddParameter(oDbCommand, "@ManualMRNo", DbType.String, _PurchasePayment.ManualMRNo);
				else
					AddParameter(oDbCommand, "@ManualMRNo",DbType.String, DBNull.Value);
				if (_PurchasePayment.MRBookNo != null)
					AddParameter(oDbCommand, "@MRBookNo", DbType.String, _PurchasePayment.MRBookNo);
				else
					AddParameter(oDbCommand, "@MRBookNo",DbType.String, DBNull.Value);
				if (_PurchasePayment.EnteredBy.HasValue)
					AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _PurchasePayment.EnteredBy);
				else
					AddParameter(oDbCommand, "@EnteredBy",DbType.Int32, DBNull.Value);
				if (_PurchasePayment.EnteredTime.HasValue)
					AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _PurchasePayment.EnteredTime);
				else
					AddParameter(oDbCommand, "@EnteredTime",DbType.DateTime, DBNull.Value);
				if (_PurchasePayment.UpdatedBy.HasValue)
					AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _PurchasePayment.UpdatedBy);
				else
					AddParameter(oDbCommand, "@UpdatedBy",DbType.Int32, DBNull.Value);
				if (_PurchasePayment.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _PurchasePayment.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);
				if (_PurchasePayment.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _PurchasePayment.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_PurchasePayment.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _PurchasePayment.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_PurchasePayment.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _PurchasePayment.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(PurchasePayment _PurchasePayment)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_Update", CommandType.StoredProcedure);
				if (_PurchasePayment.PurchaseId.HasValue)
					AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, _PurchasePayment.PurchaseId);
				else
					AddParameter(oDbCommand, "@PurchaseId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@PaymentDate", DbType.DateTime, _PurchasePayment.PaymentDate);
				AddParameter(oDbCommand, "@PaymentType", DbType.String, _PurchasePayment.PaymentType);
				if (_PurchasePayment.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _PurchasePayment.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_PurchasePayment.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _PurchasePayment.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				if (_PurchasePayment.ChequeBank != null)
					AddParameter(oDbCommand, "@ChequeBank", DbType.String, _PurchasePayment.ChequeBank);
				else
					AddParameter(oDbCommand, "@ChequeBank",DbType.String, DBNull.Value);
				if (_PurchasePayment.IsChqCleared.HasValue)
					AddParameter(oDbCommand, "@IsChqCleared", DbType.Boolean, _PurchasePayment.IsChqCleared);
				else
					AddParameter(oDbCommand, "@IsChqCleared",DbType.Boolean, DBNull.Value);
				AddParameter(oDbCommand, "@MemoNumber", DbType.String, _PurchasePayment.MemoNumber);
				AddParameter(oDbCommand, "@PaidAmount", DbType.Decimal, _PurchasePayment.PaidAmount);
				AddParameter(oDbCommand, "@DiscAmount", DbType.Decimal, _PurchasePayment.DiscAmount);
				AddParameter(oDbCommand, "@RemAmount", DbType.Decimal, _PurchasePayment.RemAmount);
				if (_PurchasePayment.DueBalance.HasValue)
					AddParameter(oDbCommand, "@DueBalance", DbType.Decimal, _PurchasePayment.DueBalance);
				else
					AddParameter(oDbCommand, "@DueBalance",DbType.Decimal, DBNull.Value);
				if (_PurchasePayment.PaidBy.HasValue)
					AddParameter(oDbCommand, "@PaidBy", DbType.Int32, _PurchasePayment.PaidBy);
				else
					AddParameter(oDbCommand, "@PaidBy",DbType.Int32, DBNull.Value);
				if (_PurchasePayment.ReceivedBy != null)
					AddParameter(oDbCommand, "@ReceivedBy", DbType.String, _PurchasePayment.ReceivedBy);
				else
					AddParameter(oDbCommand, "@ReceivedBy",DbType.String, DBNull.Value);
				if (_PurchasePayment.Remarks != null)
					AddParameter(oDbCommand, "@Remarks", DbType.String, _PurchasePayment.Remarks);
				else
					AddParameter(oDbCommand, "@Remarks",DbType.String, DBNull.Value);
				if (_PurchasePayment.ManualMRNo != null)
					AddParameter(oDbCommand, "@ManualMRNo", DbType.String, _PurchasePayment.ManualMRNo);
				else
					AddParameter(oDbCommand, "@ManualMRNo",DbType.String, DBNull.Value);
				if (_PurchasePayment.MRBookNo != null)
					AddParameter(oDbCommand, "@MRBookNo", DbType.String, _PurchasePayment.MRBookNo);
				else
					AddParameter(oDbCommand, "@MRBookNo",DbType.String, DBNull.Value);
				if (_PurchasePayment.EnteredBy.HasValue)
					AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _PurchasePayment.EnteredBy);
				else
					AddParameter(oDbCommand, "@EnteredBy",DbType.Int32, DBNull.Value);
				if (_PurchasePayment.EnteredTime.HasValue)
					AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _PurchasePayment.EnteredTime);
				else
					AddParameter(oDbCommand, "@EnteredTime",DbType.DateTime, DBNull.Value);
				if (_PurchasePayment.UpdatedBy.HasValue)
					AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _PurchasePayment.UpdatedBy);
				else
					AddParameter(oDbCommand, "@UpdatedBy",DbType.Int32, DBNull.Value);
				if (_PurchasePayment.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _PurchasePayment.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);
				if (_PurchasePayment.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _PurchasePayment.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_PurchasePayment.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _PurchasePayment.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_PurchasePayment.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _PurchasePayment.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@PurchasePaymentId", DbType.Int64, _PurchasePayment.PurchasePaymentId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 PurchasePaymentId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PurchasePaymentId", DbType.Int64, PurchasePaymentId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int DeleteByPurchaseId(Int32 PurchaseId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchasePayment_DeleteByPurchaseId", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, PurchaseId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
       
	}
}
