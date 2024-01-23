using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class ReceiptVoucherMainDAO
	{
		public ReceiptVoucherMainDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, ReceiptVoucherMain oReceiptVoucherMain)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "ReceiptVoucherId":
						oReceiptVoucherMain.ReceiptVoucherId = Convert.ToInt64(oDbDataReader["ReceiptVoucherId"]);
						break;
					case "ReceiptVoucherMode":
						oReceiptVoucherMain.ReceiptVoucherMode = Convert.ToString(oDbDataReader["ReceiptVoucherMode"]);
						break;
					case "ReceiptVoucherNo":
						oReceiptVoucherMain.ReceiptVoucherNo = Convert.ToInt64(oDbDataReader["ReceiptVoucherNo"]);
						break;
					case "ReceiptVoucherDate":
						oReceiptVoucherMain.ReceiptVoucherDate = Convert.ToDateTime(oDbDataReader["ReceiptVoucherDate"]);
						break;
					case "CreatorId":
						oReceiptVoucherMain.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					case "CreateDate":
						oReceiptVoucherMain.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oReceiptVoucherMain.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oReceiptVoucherMain.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oReceiptVoucherMain.CF3 = Convert.ToString(oDbDataReader["CF3"]);
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

		public List<ReceiptVoucherMain> ReceiptVoucherMain_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ReceiptVoucherMain> lstReceiptVoucherMain = new List<ReceiptVoucherMain>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ReceiptVoucherMain oReceiptVoucherMain = new ReceiptVoucherMain();
					BuildEntity(oDbDataReader, oReceiptVoucherMain);
					lstReceiptVoucherMain.Add(oReceiptVoucherMain);
				}
				return lstReceiptVoucherMain;
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

		public List<ReceiptVoucherMain> ReceiptVoucherMain_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ReceiptVoucherMain> lstReceiptVoucherMain = new List<ReceiptVoucherMain>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ReceiptVoucherMain oReceiptVoucherMain = new ReceiptVoucherMain();
					BuildEntity(oDbDataReader, oReceiptVoucherMain);
					lstReceiptVoucherMain.Add(oReceiptVoucherMain);
				}
				return lstReceiptVoucherMain;
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

		public ReceiptVoucherMain ReceiptVoucherMain_GetById(Int64 ReceiptVoucherId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				ReceiptVoucherMain oReceiptVoucherMain = new ReceiptVoucherMain();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherId", DbType.Int64, ReceiptVoucherId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oReceiptVoucherMain);
				}
				return oReceiptVoucherMain;
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

		public int Add(ReceiptVoucherMain _ReceiptVoucherMain)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherMode", DbType.String, _ReceiptVoucherMain.ReceiptVoucherMode);
				AddParameter(oDbCommand, "@ReceiptVoucherNo", DbType.Int64, _ReceiptVoucherMain.ReceiptVoucherNo);
				AddParameter(oDbCommand, "@ReceiptVoucherDate", DbType.DateTime, _ReceiptVoucherMain.ReceiptVoucherDate);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _ReceiptVoucherMain.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _ReceiptVoucherMain.CreateDate);
				if (_ReceiptVoucherMain.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _ReceiptVoucherMain.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_ReceiptVoucherMain.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _ReceiptVoucherMain.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_ReceiptVoucherMain.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _ReceiptVoucherMain.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(ReceiptVoucherMain _ReceiptVoucherMain)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherMode", DbType.String, _ReceiptVoucherMain.ReceiptVoucherMode);
				AddParameter(oDbCommand, "@ReceiptVoucherNo", DbType.Int64, _ReceiptVoucherMain.ReceiptVoucherNo);
				AddParameter(oDbCommand, "@ReceiptVoucherDate", DbType.DateTime, _ReceiptVoucherMain.ReceiptVoucherDate);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _ReceiptVoucherMain.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _ReceiptVoucherMain.CreateDate);
				if (_ReceiptVoucherMain.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _ReceiptVoucherMain.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_ReceiptVoucherMain.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _ReceiptVoucherMain.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_ReceiptVoucherMain.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _ReceiptVoucherMain.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ReceiptVoucherId", DbType.Int64, _ReceiptVoucherMain.ReceiptVoucherId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 ReceiptVoucherId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ReceiptVoucherMain_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReceiptVoucherId", DbType.Int64, ReceiptVoucherId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
