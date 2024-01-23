using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL 
{
	public class PaymentVoucherDetailDAO
	{
		public PaymentVoucherDetailDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, PaymentVoucherDetail oPaymentVoucherDetail)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "PaymentVoucherDetailId":
						oPaymentVoucherDetail.PaymentVoucherDetailId = Convert.ToInt64(oDbDataReader["PaymentVoucherDetailId"]);
						break;
					case "PaymentVoucherId":
						oPaymentVoucherDetail.PaymentVoucherId = Convert.ToInt64(oDbDataReader["PaymentVoucherId"]);
						break;
					case "TransactionId":
						if (oDbDataReader["TransactionId"] != DBNull.Value)
							oPaymentVoucherDetail.TransactionId = Convert.ToInt64(oDbDataReader["TransactionId"]);
						break;
					case "AccountLedgerId":
						oPaymentVoucherDetail.AccountLedgerId = Convert.ToInt32(oDbDataReader["AccountLedgerId"]);
						break;
					case "Narration":
						oPaymentVoucherDetail.Narration = Convert.ToString(oDbDataReader["Narration"]);
						break;
					case "CCCode":
						if (oDbDataReader["CCCode"] != DBNull.Value)
							oPaymentVoucherDetail.CCCode = Convert.ToInt32(oDbDataReader["CCCode"]);
						break;
					case "DrAmt":
                        oPaymentVoucherDetail.DrAmt = Convert.ToDouble(oDbDataReader["DrAmt"]);
						break;
					case "CrAmt":
                        oPaymentVoucherDetail.CrAmt = Convert.ToDouble(oDbDataReader["CrAmt"]);
						break;
					case "ChequeNo":
						if (oDbDataReader["ChequeNo"] != DBNull.Value)
							oPaymentVoucherDetail.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
						break;
					case "ChequeDate":
						if (oDbDataReader["ChequeDate"] != DBNull.Value)
							oPaymentVoucherDetail.ChequeDate = Convert.ToDateTime(oDbDataReader["ChequeDate"]);
						break;
					case "ChequeBank":
						if (oDbDataReader["ChequeBank"] != DBNull.Value)
							oPaymentVoucherDetail.ChequeBank = Convert.ToString(oDbDataReader["ChequeBank"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oPaymentVoucherDetail.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oPaymentVoucherDetail.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oPaymentVoucherDetail.CF3 = Convert.ToString(oDbDataReader["CF3"]);
						break;
                    case "PaymentVoucherNo":
                        if (oDbDataReader["PaymentVoucherNo"] != DBNull.Value)
                            oPaymentVoucherDetail.PaymentVoucherNo = Convert.ToInt64(oDbDataReader["PaymentVoucherNo"]);
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

		public List<PaymentVoucherDetail> PaymentVoucherDetail_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PaymentVoucherDetail> lstPaymentVoucherDetail = new List<PaymentVoucherDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PaymentVoucherDetail oPaymentVoucherDetail = new PaymentVoucherDetail();
					BuildEntity(oDbDataReader, oPaymentVoucherDetail);
					lstPaymentVoucherDetail.Add(oPaymentVoucherDetail);
				}
				return lstPaymentVoucherDetail;
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

		public List<PaymentVoucherDetail> PaymentVoucherDetail_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PaymentVoucherDetail> lstPaymentVoucherDetail = new List<PaymentVoucherDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PaymentVoucherDetail oPaymentVoucherDetail = new PaymentVoucherDetail();
					BuildEntity(oDbDataReader, oPaymentVoucherDetail);
					lstPaymentVoucherDetail.Add(oPaymentVoucherDetail);
				}
				return lstPaymentVoucherDetail;
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

		public PaymentVoucherDetail PaymentVoucherDetail_GetById(Int64 PaymentVoucherDetailId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PaymentVoucherDetail oPaymentVoucherDetail = new PaymentVoucherDetail();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherDetailId", DbType.Int64, PaymentVoucherDetailId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPaymentVoucherDetail);
				}
				return oPaymentVoucherDetail;
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

		public Int64 Add(PaymentVoucherDetail _PaymentVoucherDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherId", DbType.Int64, _PaymentVoucherDetail.PaymentVoucherId);
				if (_PaymentVoucherDetail.TransactionId.HasValue)
					AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _PaymentVoucherDetail.TransactionId);
				else
					AddParameter(oDbCommand, "@TransactionId",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _PaymentVoucherDetail.AccountLedgerId);
				AddParameter(oDbCommand, "@Narration", DbType.String, _PaymentVoucherDetail.Narration);
				if (_PaymentVoucherDetail.CCCode.HasValue)
					AddParameter(oDbCommand, "@CCCode", DbType.Int32, _PaymentVoucherDetail.CCCode);
				else
					AddParameter(oDbCommand, "@CCCode",DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _PaymentVoucherDetail.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _PaymentVoucherDetail.CrAmt);
				if (_PaymentVoucherDetail.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _PaymentVoucherDetail.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _PaymentVoucherDetail.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				if (_PaymentVoucherDetail.ChequeBank != null)
					AddParameter(oDbCommand, "@ChequeBank", DbType.String, _PaymentVoucherDetail.ChequeBank);
				else
					AddParameter(oDbCommand, "@ChequeBank",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _PaymentVoucherDetail.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _PaymentVoucherDetail.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _PaymentVoucherDetail.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt64(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(PaymentVoucherDetail _PaymentVoucherDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherId", DbType.Int64, _PaymentVoucherDetail.PaymentVoucherId);
				if (_PaymentVoucherDetail.TransactionId.HasValue)
					AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _PaymentVoucherDetail.TransactionId);
				else
					AddParameter(oDbCommand, "@TransactionId",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _PaymentVoucherDetail.AccountLedgerId);
				AddParameter(oDbCommand, "@Narration", DbType.String, _PaymentVoucherDetail.Narration);
				if (_PaymentVoucherDetail.CCCode.HasValue)
					AddParameter(oDbCommand, "@CCCode", DbType.Int32, _PaymentVoucherDetail.CCCode);
				else
					AddParameter(oDbCommand, "@CCCode",DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _PaymentVoucherDetail.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _PaymentVoucherDetail.CrAmt);
				if (_PaymentVoucherDetail.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _PaymentVoucherDetail.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _PaymentVoucherDetail.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				if (_PaymentVoucherDetail.ChequeBank != null)
					AddParameter(oDbCommand, "@ChequeBank", DbType.String, _PaymentVoucherDetail.ChequeBank);
				else
					AddParameter(oDbCommand, "@ChequeBank",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _PaymentVoucherDetail.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _PaymentVoucherDetail.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_PaymentVoucherDetail.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _PaymentVoucherDetail.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@PaymentVoucherDetailId", DbType.Int64, _PaymentVoucherDetail.PaymentVoucherDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 PaymentVoucherDetailId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherDetailId", DbType.Int64, PaymentVoucherDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int DeleteByPaymentVoucherId(Int64 PaymentVoucherId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherDetail_DeleteByPaymentVoucherId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@PaymentVoucherId", DbType.Int64, PaymentVoucherId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PaymentVoucherDetail> PaymentVoucherMain_GetVoucherForGrid(string ProjectId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PaymentVoucherDetail> lstPaymentVoucherDetail = new List<PaymentVoucherDetail>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_GetVoucherForGrid", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.String, ProjectId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PaymentVoucherDetail oPaymentVoucherDetail = new PaymentVoucherDetail();
					BuildEntity(oDbDataReader, oPaymentVoucherDetail);
					lstPaymentVoucherDetail.Add(oPaymentVoucherDetail);
				}
				return lstPaymentVoucherDetail;
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
