using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class JournalVoucherMainDAO
	{
		public JournalVoucherMainDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, JournalVoucherMain oJournalVoucherMain)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "JournalVoucherId":
						oJournalVoucherMain.JournalVoucherId = Convert.ToInt64(oDbDataReader["JournalVoucherId"]);
						break;
					case "JournalVoucherMode":
						oJournalVoucherMain.JournalVoucherMode = Convert.ToString(oDbDataReader["JournalVoucherMode"]);
						break;
					case "JournalVoucherNo":
						oJournalVoucherMain.JournalVoucherNo = Convert.ToInt64(oDbDataReader["JournalVoucherNo"]);
						break;
					case "JournalVoucherDate":
						oJournalVoucherMain.JournalVoucherDate = Convert.ToDateTime(oDbDataReader["JournalVoucherDate"]);
						break;
					case "Purpose":
						if (oDbDataReader["Purpose"] != DBNull.Value)
							oJournalVoucherMain.Purpose = Convert.ToString(oDbDataReader["Purpose"]);
						break;
					case "TransactionBy":
						oJournalVoucherMain.TransactionBy = Convert.ToString(oDbDataReader["TransactionBy"]);
						break;
					case "ChequeNo":
						if (oDbDataReader["ChequeNo"] != DBNull.Value)
							oJournalVoucherMain.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
						break;
					case "ChequeDate":
						if (oDbDataReader["ChequeDate"] != DBNull.Value)
							oJournalVoucherMain.ChequeDate = Convert.ToDateTime(oDbDataReader["ChequeDate"]);
						break;
					case "CreatorId":
						oJournalVoucherMain.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					case "CreateDate":
						oJournalVoucherMain.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oJournalVoucherMain.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oJournalVoucherMain.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oJournalVoucherMain.CF3 = Convert.ToString(oDbDataReader["CF3"]);
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

		public List<JournalVoucherMain> JournalVoucherMain_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<JournalVoucherMain> lstJournalVoucherMain = new List<JournalVoucherMain>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					JournalVoucherMain oJournalVoucherMain = new JournalVoucherMain();
					BuildEntity(oDbDataReader, oJournalVoucherMain);
					lstJournalVoucherMain.Add(oJournalVoucherMain);
				}
				return lstJournalVoucherMain;
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

		public List<JournalVoucherMain> JournalVoucherMain_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<JournalVoucherMain> lstJournalVoucherMain = new List<JournalVoucherMain>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					JournalVoucherMain oJournalVoucherMain = new JournalVoucherMain();
					BuildEntity(oDbDataReader, oJournalVoucherMain);
					lstJournalVoucherMain.Add(oJournalVoucherMain);
				}
				return lstJournalVoucherMain;
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

		public JournalVoucherMain JournalVoucherMain_GetById(Int64 JournalVoucherId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				JournalVoucherMain oJournalVoucherMain = new JournalVoucherMain();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, JournalVoucherId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oJournalVoucherMain);
				}
				return oJournalVoucherMain;
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

		public int Add(JournalVoucherMain _JournalVoucherMain)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherMode", DbType.String, _JournalVoucherMain.JournalVoucherMode);
				AddParameter(oDbCommand, "@JournalVoucherNo", DbType.Int64, _JournalVoucherMain.JournalVoucherNo);
				AddParameter(oDbCommand, "@JournalVoucherDate", DbType.DateTime, _JournalVoucherMain.JournalVoucherDate);
				if (_JournalVoucherMain.Purpose != null)
					AddParameter(oDbCommand, "@Purpose", DbType.String, _JournalVoucherMain.Purpose);
				else
					AddParameter(oDbCommand, "@Purpose",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@TransactionBy", DbType.String, _JournalVoucherMain.TransactionBy);
				if (_JournalVoucherMain.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _JournalVoucherMain.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_JournalVoucherMain.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _JournalVoucherMain.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _JournalVoucherMain.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _JournalVoucherMain.CreateDate);
				if (_JournalVoucherMain.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _JournalVoucherMain.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_JournalVoucherMain.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _JournalVoucherMain.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_JournalVoucherMain.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _JournalVoucherMain.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(JournalVoucherMain _JournalVoucherMain)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherMode", DbType.String, _JournalVoucherMain.JournalVoucherMode);
				AddParameter(oDbCommand, "@JournalVoucherNo", DbType.Int64, _JournalVoucherMain.JournalVoucherNo);
				AddParameter(oDbCommand, "@JournalVoucherDate", DbType.DateTime, _JournalVoucherMain.JournalVoucherDate);
				if (_JournalVoucherMain.Purpose != null)
					AddParameter(oDbCommand, "@Purpose", DbType.String, _JournalVoucherMain.Purpose);
				else
					AddParameter(oDbCommand, "@Purpose",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@TransactionBy", DbType.String, _JournalVoucherMain.TransactionBy);
				if (_JournalVoucherMain.ChequeNo != null)
					AddParameter(oDbCommand, "@ChequeNo", DbType.String, _JournalVoucherMain.ChequeNo);
				else
					AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
				if (_JournalVoucherMain.ChequeDate.HasValue)
					AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _JournalVoucherMain.ChequeDate);
				else
					AddParameter(oDbCommand, "@ChequeDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _JournalVoucherMain.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _JournalVoucherMain.CreateDate);
				if (_JournalVoucherMain.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _JournalVoucherMain.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_JournalVoucherMain.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _JournalVoucherMain.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_JournalVoucherMain.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _JournalVoucherMain.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, _JournalVoucherMain.JournalVoucherId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int UpdateFWOAutoVoucher(JournalVoucherMain _JournalVoucherMain)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_UpdateFWOAutoVoucher", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@JournalVoucherDate", DbType.DateTime, _JournalVoucherMain.JournalVoucherDate);
                AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _JournalVoucherMain.CreatorId);
                
                AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, _JournalVoucherMain.JournalVoucherId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public int Delete(Int64 JournalVoucherId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("JournalVoucherMain_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@JournalVoucherId", DbType.Int64, JournalVoucherId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
