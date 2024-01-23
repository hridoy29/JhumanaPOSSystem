using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class JournalVoucherDetailDAO
	{
		public JournalVoucherDetailDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, JournalVoucherDetail oJournalVoucherDetail)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "JournalVoucherDetailId":
						oJournalVoucherDetail.JournalVoucherDetailId = Convert.ToInt64(oDbDataReader["JournalVoucherDetailId"]);
						break;
					case "JournalVoucherId":
						oJournalVoucherDetail.JournalVoucherId = Convert.ToInt64(oDbDataReader["JournalVoucherId"]);
						break;
					case "TransactionId":
						if (oDbDataReader["TransactionId"] != DBNull.Value)
							oJournalVoucherDetail.TransactionId = Convert.ToInt64(oDbDataReader["TransactionId"]);
						break;
					case "AccTransTypeId":
						oJournalVoucherDetail.AccTransTypeId = Convert.ToInt32(oDbDataReader["AccTransTypeId"]);
						break;
					case "AccountLedgerId":
						oJournalVoucherDetail.AccountLedgerId = Convert.ToInt32(oDbDataReader["AccountLedgerId"]);
						break;
					case "Narration":
						oJournalVoucherDetail.Narration = Convert.ToString(oDbDataReader["Narration"]);
						break;
					case "CCCode":
						if (oDbDataReader["CCCode"] != DBNull.Value)
							oJournalVoucherDetail.CCCode = Convert.ToInt32(oDbDataReader["CCCode"]);
						break;
					case "DrAmt":
						oJournalVoucherDetail.DrAmt = Convert.ToDouble(oDbDataReader["DrAmt"]);
						break;
					case "CrAmt":
                        oJournalVoucherDetail.CrAmt = Convert.ToDouble(oDbDataReader["CrAmt"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oJournalVoucherDetail.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oJournalVoucherDetail.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oJournalVoucherDetail.CF3 = Convert.ToString(oDbDataReader["CF3"]);
						break;

                    case "JournalVoucherNo":
                        if (oDbDataReader["JournalVoucherNo"] != DBNull.Value)
                            oJournalVoucherDetail.JournalVoucherNo = Convert.ToInt64(oDbDataReader["JournalVoucherNo"]);
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

		public List<JournalVoucherDetail> JournalVoucherDetail_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<JournalVoucherDetail> lstJournalVoucherDetail = new List<JournalVoucherDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					JournalVoucherDetail oJournalVoucherDetail = new JournalVoucherDetail();
					BuildEntity(oDbDataReader, oJournalVoucherDetail);
					lstJournalVoucherDetail.Add(oJournalVoucherDetail);
				}
				return lstJournalVoucherDetail;
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

        public List<JournalVoucherDetail> JournalVoucherDetail_GetDynamicForEdit(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<JournalVoucherDetail> lstJournalVoucherDetail = new List<JournalVoucherDetail>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_GetDynamicForEdit", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    JournalVoucherDetail oJournalVoucherDetail = new JournalVoucherDetail();
                    BuildEntity(oDbDataReader, oJournalVoucherDetail);
                    lstJournalVoucherDetail.Add(oJournalVoucherDetail);
                }
                return lstJournalVoucherDetail;
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

		public List<JournalVoucherDetail> JournalVoucherDetail_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<JournalVoucherDetail> lstJournalVoucherDetail = new List<JournalVoucherDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					JournalVoucherDetail oJournalVoucherDetail = new JournalVoucherDetail();
					BuildEntity(oDbDataReader, oJournalVoucherDetail);
					lstJournalVoucherDetail.Add(oJournalVoucherDetail);
				}
				return lstJournalVoucherDetail;
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

		public JournalVoucherDetail JournalVoucherDetail_GetById(Int64 JournalVoucherDetailId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				JournalVoucherDetail oJournalVoucherDetail = new JournalVoucherDetail();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherDetailId", DbType.Int64, JournalVoucherDetailId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oJournalVoucherDetail);
				}
				return oJournalVoucherDetail;
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

		public int Add(JournalVoucherDetail _JournalVoucherDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, _JournalVoucherDetail.JournalVoucherId);
				if (_JournalVoucherDetail.TransactionId.HasValue)
					AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _JournalVoucherDetail.TransactionId);
				else
					AddParameter(oDbCommand, "@TransactionId",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@AccTransTypeId", DbType.Int32, _JournalVoucherDetail.AccTransTypeId);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _JournalVoucherDetail.AccountLedgerId);
				AddParameter(oDbCommand, "@Narration", DbType.String, _JournalVoucherDetail.Narration);
				if (_JournalVoucherDetail.CCCode.HasValue)
					AddParameter(oDbCommand, "@CCCode", DbType.Int32, _JournalVoucherDetail.CCCode);
				else
					AddParameter(oDbCommand, "@CCCode",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@DrAmt", DbType.Double, _JournalVoucherDetail.DrAmt);
				AddParameter(oDbCommand, "@CrAmt", DbType.Double, _JournalVoucherDetail.CrAmt);
				if (_JournalVoucherDetail.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _JournalVoucherDetail.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_JournalVoucherDetail.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _JournalVoucherDetail.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_JournalVoucherDetail.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _JournalVoucherDetail.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(JournalVoucherDetail _JournalVoucherDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, _JournalVoucherDetail.JournalVoucherId);
				if (_JournalVoucherDetail.TransactionId.HasValue)
					AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _JournalVoucherDetail.TransactionId);
				else
					AddParameter(oDbCommand, "@TransactionId",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@AccTransTypeId", DbType.Int32, _JournalVoucherDetail.AccTransTypeId);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _JournalVoucherDetail.AccountLedgerId);
				AddParameter(oDbCommand, "@Narration", DbType.String, _JournalVoucherDetail.Narration);
				if (_JournalVoucherDetail.CCCode.HasValue)
					AddParameter(oDbCommand, "@CCCode", DbType.Int32, _JournalVoucherDetail.CCCode);
				else
					AddParameter(oDbCommand, "@CCCode",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@DrAmt", DbType.Double, _JournalVoucherDetail.DrAmt);
				AddParameter(oDbCommand, "@CrAmt", DbType.Double, _JournalVoucherDetail.CrAmt);
				if (_JournalVoucherDetail.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _JournalVoucherDetail.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_JournalVoucherDetail.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _JournalVoucherDetail.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_JournalVoucherDetail.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _JournalVoucherDetail.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@JournalVoucherDetailId", DbType.Int64, _JournalVoucherDetail.JournalVoucherDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int UpdateFWOAutoVoucher(JournalVoucherDetail _JournalVoucherDetail)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_UpdateFWOAutoVoucher", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _JournalVoucherDetail.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _JournalVoucherDetail.CrAmt);            
                AddParameter(oDbCommand, "@JournalVoucherDetailId", DbType.Int64, _JournalVoucherDetail.JournalVoucherDetailId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public int Delete(Int64 JournalVoucherDetailId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherDetailId", DbType.Int64, JournalVoucherDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<JournalVoucherDetail> JournalVoucherMain_GetVoucherForGrid(string ProjectId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<JournalVoucherDetail> lstJournalVoucherDetail = new List<JournalVoucherDetail>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_GetVoucherForGrid", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.String, ProjectId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    JournalVoucherDetail oJournalVoucherDetail = new JournalVoucherDetail();
                    BuildEntity(oDbDataReader, oJournalVoucherDetail);
                    lstJournalVoucherDetail.Add(oJournalVoucherDetail);
                }
                return lstJournalVoucherDetail;
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

        public int DeleteByJournalVoucherId(Int64 JournalVoucherId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherDetail_DeleteByJournalVoucherId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, @JournalVoucherId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
