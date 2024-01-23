using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class ReceiptVoucherDetailDAO
	{
		public ReceiptVoucherDetailDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, ReceiptVoucherDetail oReceiptVoucherDetail)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "ReceiptVoucherDetailId":
						oReceiptVoucherDetail.ReceiptVoucherDetailId = Convert.ToInt64(oDbDataReader["ReceiptVoucherDetailId"]);
						break;
					case "ReceiptVoucherId":
						oReceiptVoucherDetail.ReceiptVoucherId = Convert.ToInt64(oDbDataReader["ReceiptVoucherId"]);
						break;
					case "TransactionId":
						if (oDbDataReader["TransactionId"] != DBNull.Value)
							oReceiptVoucherDetail.TransactionId = Convert.ToInt64(oDbDataReader["TransactionId"]);
						break;
					case "AccountLedgerId":
						oReceiptVoucherDetail.AccountLedgerId = Convert.ToInt32(oDbDataReader["AccountLedgerId"]);
						break;
					case "Narration":
						oReceiptVoucherDetail.Narration = Convert.ToString(oDbDataReader["Narration"]);
						break;
					case "CCCode":
						if (oDbDataReader["CCCode"] != DBNull.Value)
							oReceiptVoucherDetail.CCCode = Convert.ToInt32(oDbDataReader["CCCode"]);
						break;
					case "DrAmt":
                        oReceiptVoucherDetail.DrAmt = Convert.ToDouble(oDbDataReader["DrAmt"]);
						break;
					case "CrAmt":
                        oReceiptVoucherDetail.CrAmt = Convert.ToDouble(oDbDataReader["CrAmt"]);
						break;
					case "ChequeNo":
						if (oDbDataReader["ChequeNo"] != DBNull.Value)
							oReceiptVoucherDetail.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
						break;
					case "ChequeDate":
						if (oDbDataReader["ChequeDate"] != DBNull.Value)
							oReceiptVoucherDetail.ChequeDate = Convert.ToDateTime(oDbDataReader["ChequeDate"]);
						break;
					case "ChequeBank":
						if (oDbDataReader["ChequeBank"] != DBNull.Value)
							oReceiptVoucherDetail.ChequeBank = Convert.ToString(oDbDataReader["ChequeBank"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oReceiptVoucherDetail.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oReceiptVoucherDetail.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oReceiptVoucherDetail.CF3 = Convert.ToString(oDbDataReader["CF3"]);
						break;
                    case "ReceiptVoucherNo":
                        if (oDbDataReader["ReceiptVoucherNo"] != DBNull.Value)
                            oReceiptVoucherDetail.ReceiptVoucherNo = Convert.ToInt64(oDbDataReader["ReceiptVoucherNo"]);
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

		public List<ReceiptVoucherDetail> ReceiptVoucherDetail_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ReceiptVoucherDetail> lstReceiptVoucherDetail = new List<ReceiptVoucherDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ReceiptVoucherDetail oReceiptVoucherDetail = new ReceiptVoucherDetail();
					BuildEntity(oDbDataReader, oReceiptVoucherDetail);
					lstReceiptVoucherDetail.Add(oReceiptVoucherDetail);
				}
				return lstReceiptVoucherDetail;
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

		public List<ReceiptVoucherDetail> ReceiptVoucherDetail_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ReceiptVoucherDetail> lstReceiptVoucherDetail = new List<ReceiptVoucherDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ReceiptVoucherDetail oReceiptVoucherDetail = new ReceiptVoucherDetail();
					BuildEntity(oDbDataReader, oReceiptVoucherDetail);
					lstReceiptVoucherDetail.Add(oReceiptVoucherDetail);
				}
				return lstReceiptVoucherDetail;
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

		public ReceiptVoucherDetail ReceiptVoucherDetail_GetById(Int64 ReceiptVoucherDetailId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				ReceiptVoucherDetail oReceiptVoucherDetail = new ReceiptVoucherDetail();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherDetailId", DbType.Int64, ReceiptVoucherDetailId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oReceiptVoucherDetail);
				}
				return oReceiptVoucherDetail;
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

		public int Add(ReceiptVoucherDetail _ReceiptVoucherDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherId", DbType.Int64, _ReceiptVoucherDetail.ReceiptVoucherId);
				if (_ReceiptVoucherDetail.TransactionId.HasValue)
					AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _ReceiptVoucherDetail.TransactionId);
				else
					AddParameter(oDbCommand, "@TransactionId",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _ReceiptVoucherDetail.AccountLedgerId);
				AddParameter(oDbCommand, "@Narration", DbType.String, _ReceiptVoucherDetail.Narration);
				if (_ReceiptVoucherDetail.CCCode.HasValue)
					AddParameter(oDbCommand, "@CCCode", DbType.Int32, _ReceiptVoucherDetail.CCCode);
				else
					AddParameter(oDbCommand, "@CCCode",DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _ReceiptVoucherDetail.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _ReceiptVoucherDetail.CrAmt);
				if (_ReceiptVoucherDetail.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _ReceiptVoucherDetail.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _ReceiptVoucherDetail.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				if (_ReceiptVoucherDetail.ChequeBank != null)
					AddParameter(oDbCommand, "@ChequeBank", DbType.String, _ReceiptVoucherDetail.ChequeBank);
				else
					AddParameter(oDbCommand, "@ChequeBank",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _ReceiptVoucherDetail.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _ReceiptVoucherDetail.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _ReceiptVoucherDetail.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(ReceiptVoucherDetail _ReceiptVoucherDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherId", DbType.Int64, _ReceiptVoucherDetail.ReceiptVoucherId);
				if (_ReceiptVoucherDetail.TransactionId.HasValue)
					AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _ReceiptVoucherDetail.TransactionId);
				else
					AddParameter(oDbCommand, "@TransactionId",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _ReceiptVoucherDetail.AccountLedgerId);
				AddParameter(oDbCommand, "@Narration", DbType.String, _ReceiptVoucherDetail.Narration);
				if (_ReceiptVoucherDetail.CCCode.HasValue)
					AddParameter(oDbCommand, "@CCCode", DbType.Int32, _ReceiptVoucherDetail.CCCode);
				else
					AddParameter(oDbCommand, "@CCCode",DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _ReceiptVoucherDetail.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _ReceiptVoucherDetail.CrAmt);
				if (_ReceiptVoucherDetail.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _ReceiptVoucherDetail.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _ReceiptVoucherDetail.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				if (_ReceiptVoucherDetail.ChequeBank != null)
					AddParameter(oDbCommand, "@ChequeBank", DbType.String, _ReceiptVoucherDetail.ChequeBank);
				else
					AddParameter(oDbCommand, "@ChequeBank",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _ReceiptVoucherDetail.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _ReceiptVoucherDetail.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_ReceiptVoucherDetail.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _ReceiptVoucherDetail.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ReceiptVoucherDetailId", DbType.Int64, _ReceiptVoucherDetail.ReceiptVoucherDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 ReceiptVoucherDetailId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherDetailId", DbType.Int64, ReceiptVoucherDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int DeleteByReceiptVoucherId(Int64 ReceiptVoucherId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherDetail_DeleteByReceiptVoucherId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ReceiptVoucherId", DbType.Int64, ReceiptVoucherId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReceiptVoucherDetail> ReceiptVoucherMain_GetVoucherForGrid(string ProjectId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ReceiptVoucherDetail> lstReceiptVoucherDetail = new List<ReceiptVoucherDetail>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_GetVoucherForGrid", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.String, ProjectId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ReceiptVoucherDetail oReceiptVoucherDetail = new ReceiptVoucherDetail();
                    BuildEntity(oDbDataReader, oReceiptVoucherDetail);
                    lstReceiptVoucherDetail.Add(oReceiptVoucherDetail);
                }
                return lstReceiptVoucherDetail;
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
