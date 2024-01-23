using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class PaymentVoucherMainDAO
	{
		public PaymentVoucherMainDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, PaymentVoucherMain oPaymentVoucherMain)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "PaymentVoucherId":
						oPaymentVoucherMain.PaymentVoucherId = Convert.ToInt64(oDbDataReader["PaymentVoucherId"]);
						break;
					case "PaymentVoucherMode":
						oPaymentVoucherMain.PaymentVoucherMode = Convert.ToString(oDbDataReader["PaymentVoucherMode"]);
						break;
					case "PaymentVoucherNo":
						oPaymentVoucherMain.PaymentVoucherNo = Convert.ToInt64(oDbDataReader["PaymentVoucherNo"]);
						break;
					case "PaymentVoucherDate":
						oPaymentVoucherMain.PaymentVoucherDate = Convert.ToDateTime(oDbDataReader["PaymentVoucherDate"]);
						break;
					case "CreatorId":
						oPaymentVoucherMain.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					case "CreateDate":
						oPaymentVoucherMain.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oPaymentVoucherMain.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oPaymentVoucherMain.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oPaymentVoucherMain.CF3 = Convert.ToString(oDbDataReader["CF3"]);
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

		public List<PaymentVoucherMain> PaymentVoucherMain_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PaymentVoucherMain> lstPaymentVoucherMain = new List<PaymentVoucherMain>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PaymentVoucherMain oPaymentVoucherMain = new PaymentVoucherMain();
					BuildEntity(oDbDataReader, oPaymentVoucherMain);
					lstPaymentVoucherMain.Add(oPaymentVoucherMain);
				}
				return lstPaymentVoucherMain;
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

		public List<PaymentVoucherMain> PaymentVoucherMain_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PaymentVoucherMain> lstPaymentVoucherMain = new List<PaymentVoucherMain>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PaymentVoucherMain oPaymentVoucherMain = new PaymentVoucherMain();
					BuildEntity(oDbDataReader, oPaymentVoucherMain);
					lstPaymentVoucherMain.Add(oPaymentVoucherMain);
				}
				return lstPaymentVoucherMain;
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

		public PaymentVoucherMain PaymentVoucherMain_GetById(Int64 PaymentVoucherId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PaymentVoucherMain oPaymentVoucherMain = new PaymentVoucherMain();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherId", DbType.Int64, PaymentVoucherId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPaymentVoucherMain);
				}
				return oPaymentVoucherMain;
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

		public int Add(PaymentVoucherMain _PaymentVoucherMain)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherMode", DbType.String, _PaymentVoucherMain.PaymentVoucherMode);
				AddParameter(oDbCommand, "@PaymentVoucherNo", DbType.Int64, _PaymentVoucherMain.PaymentVoucherNo);
				AddParameter(oDbCommand, "@PaymentVoucherDate", DbType.DateTime, _PaymentVoucherMain.PaymentVoucherDate);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _PaymentVoucherMain.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _PaymentVoucherMain.CreateDate);
				if (_PaymentVoucherMain.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _PaymentVoucherMain.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_PaymentVoucherMain.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _PaymentVoucherMain.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_PaymentVoucherMain.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _PaymentVoucherMain.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(PaymentVoucherMain _PaymentVoucherMain)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherMode", DbType.String, _PaymentVoucherMain.PaymentVoucherMode);
				AddParameter(oDbCommand, "@PaymentVoucherNo", DbType.Int64, _PaymentVoucherMain.PaymentVoucherNo);
				AddParameter(oDbCommand, "@PaymentVoucherDate", DbType.DateTime, _PaymentVoucherMain.PaymentVoucherDate);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _PaymentVoucherMain.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _PaymentVoucherMain.CreateDate);
				if (_PaymentVoucherMain.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _PaymentVoucherMain.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_PaymentVoucherMain.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _PaymentVoucherMain.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_PaymentVoucherMain.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _PaymentVoucherMain.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@PaymentVoucherId", DbType.Int64, _PaymentVoucherMain.PaymentVoucherId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 PaymentVoucherId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PaymentVoucherMain_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PaymentVoucherId", DbType.Int64, PaymentVoucherId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
