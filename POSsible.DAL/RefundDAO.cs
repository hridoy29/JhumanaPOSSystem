using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class RefundDAO
	{
		public RefundDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Refund oRefund)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "Refundid":
						oRefund.Refundid = Convert.ToInt32(oDbDataReader["Refundid"]);
						break;
					case "invoiceId":
						if (oDbDataReader["invoiceId"] != DBNull.Value)
							oRefund.invoiceId = Convert.ToInt32(oDbDataReader["invoiceId"]);
						break;
					case "refundDate":
						if (oDbDataReader["refundDate"] != DBNull.Value)
							oRefund.refundDate = Convert.ToDateTime(oDbDataReader["refundDate"]);
						break;
					case "AuthorizedBy":
						if (oDbDataReader["AuthorizedBy"] != DBNull.Value)
							oRefund.AuthorizedBy = Convert.ToInt32(oDbDataReader["AuthorizedBy"]);
						break;
					case "RefundedBy":
						if (oDbDataReader["RefundedBy"] != DBNull.Value)
							oRefund.RefundedBy = Convert.ToInt32(oDbDataReader["RefundedBy"]);
						break;
					case "RefundMethod":
						if (oDbDataReader["RefundMethod"] != DBNull.Value)
							oRefund.RefundMethod = Convert.ToString(oDbDataReader["RefundMethod"]);
						break;
					case "EnteredTime":
						if (oDbDataReader["EnteredTime"] != DBNull.Value)
							oRefund.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
						break;
					case "UpdatedTime":
						if (oDbDataReader["UpdatedTime"] != DBNull.Value)
							oRefund.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
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

		public List<Refund> Refund_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Refund> lstRefund = new List<Refund>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Refund_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Refund oRefund = new Refund();
					BuildEntity(oDbDataReader, oRefund);
					lstRefund.Add(oRefund);
				}
				return lstRefund;
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

		public List<Refund> Refund_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Refund> lstRefund = new List<Refund>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Refund_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Refund oRefund = new Refund();
					BuildEntity(oDbDataReader, oRefund);
					lstRefund.Add(oRefund);
				}
				return lstRefund;
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

		public Refund Refund_GetById(int Refundid)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Refund oRefund = new Refund();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Refund_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@Refundid", DbType.Int32, Refundid);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oRefund);
				}
				return oRefund;
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

		public int Add(Refund _Refund)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Refund_Create", CommandType.StoredProcedure);
				if (_Refund.invoiceId.HasValue)
					AddParameter(oDbCommand, "@invoiceId", DbType.Int32, _Refund.invoiceId);
				else
					AddParameter(oDbCommand, "@invoiceId",DbType.Int32, DBNull.Value);
				if (_Refund.refundDate.HasValue)
					AddParameter(oDbCommand, "@refundDate", DbType.DateTime, _Refund.refundDate);
				else
					AddParameter(oDbCommand, "@refundDate",DbType.DateTime, DBNull.Value);
				if (_Refund.AuthorizedBy.HasValue)
					AddParameter(oDbCommand, "@AuthorizedBy", DbType.Int32, _Refund.AuthorizedBy);
				else
					AddParameter(oDbCommand, "@AuthorizedBy",DbType.Int32, DBNull.Value);
				if (_Refund.RefundedBy.HasValue)
					AddParameter(oDbCommand, "@RefundedBy", DbType.Int32, _Refund.RefundedBy);
				else
					AddParameter(oDbCommand, "@RefundedBy",DbType.Int32, DBNull.Value);
				if (_Refund.RefundMethod != null)
					AddParameter(oDbCommand, "@RefundMethod", DbType.String, _Refund.RefundMethod);
				else
					AddParameter(oDbCommand, "@RefundMethod",DbType.String, DBNull.Value);
				if (_Refund.EnteredTime.HasValue)
					AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Refund.EnteredTime);
				else
					AddParameter(oDbCommand, "@EnteredTime",DbType.DateTime, DBNull.Value);
				if (_Refund.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Refund.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Refund _Refund)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Refund_Update", CommandType.StoredProcedure);
				if (_Refund.invoiceId.HasValue)
					AddParameter(oDbCommand, "@invoiceId", DbType.Int32, _Refund.invoiceId);
				else
					AddParameter(oDbCommand, "@invoiceId",DbType.Int32, DBNull.Value);
				if (_Refund.refundDate.HasValue)
					AddParameter(oDbCommand, "@refundDate", DbType.DateTime, _Refund.refundDate);
				else
					AddParameter(oDbCommand, "@refundDate",DbType.DateTime, DBNull.Value);
				if (_Refund.AuthorizedBy.HasValue)
					AddParameter(oDbCommand, "@AuthorizedBy", DbType.Int32, _Refund.AuthorizedBy);
				else
					AddParameter(oDbCommand, "@AuthorizedBy",DbType.Int32, DBNull.Value);
				if (_Refund.RefundedBy.HasValue)
					AddParameter(oDbCommand, "@RefundedBy", DbType.Int32, _Refund.RefundedBy);
				else
					AddParameter(oDbCommand, "@RefundedBy",DbType.Int32, DBNull.Value);
				if (_Refund.RefundMethod != null)
					AddParameter(oDbCommand, "@RefundMethod", DbType.String, _Refund.RefundMethod);
				else
					AddParameter(oDbCommand, "@RefundMethod",DbType.String, DBNull.Value);
				if (_Refund.EnteredTime.HasValue)
					AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Refund.EnteredTime);
				else
					AddParameter(oDbCommand, "@EnteredTime",DbType.DateTime, DBNull.Value);
				if (_Refund.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Refund.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@Refundid", DbType.Int32, _Refund.Refundid);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int Refundid)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Refund_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@Refundid", DbType.Int32, Refundid);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
