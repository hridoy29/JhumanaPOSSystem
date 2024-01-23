using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class PurchaseReturnDetailDAO
	{
		public PurchaseReturnDetailDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, PurchaseReturnDetail oPurchaseReturnDetail)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "ReturnDetailId":
						oPurchaseReturnDetail.ReturnDetailId = Convert.ToInt64(oDbDataReader["ReturnDetailId"]);
						break;
					case "ReturnId":
						oPurchaseReturnDetail.ReturnId = Convert.ToInt64(oDbDataReader["ReturnId"]);
						break;
					case "ProductId":
						oPurchaseReturnDetail.ProductId = Convert.ToInt32(oDbDataReader["ProductId"]);
						break;
					case "ReturnQty":
						oPurchaseReturnDetail.ReturnQty = Convert.ToDouble(oDbDataReader["ReturnQty"]);
						break;
					case "ReturnPrice":
						oPurchaseReturnDetail.ReturnPrice = Convert.ToDouble(oDbDataReader["ReturnPrice"]);
						break;
					case "ReturnAmount":
						oPurchaseReturnDetail.ReturnAmount = Convert.ToDouble(oDbDataReader["ReturnAmount"]);
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

		public List<PurchaseReturnDetail> PurchaseReturnDetail_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchaseReturnDetail> lstPurchaseReturnDetail = new List<PurchaseReturnDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturnDetail_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchaseReturnDetail oPurchaseReturnDetail = new PurchaseReturnDetail();
					BuildEntity(oDbDataReader, oPurchaseReturnDetail);
					lstPurchaseReturnDetail.Add(oPurchaseReturnDetail);
				}
				return lstPurchaseReturnDetail;
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

		public List<PurchaseReturnDetail> PurchaseReturnDetail_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchaseReturnDetail> lstPurchaseReturnDetail = new List<PurchaseReturnDetail>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturnDetail_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchaseReturnDetail oPurchaseReturnDetail = new PurchaseReturnDetail();
					BuildEntity(oDbDataReader, oPurchaseReturnDetail);
					lstPurchaseReturnDetail.Add(oPurchaseReturnDetail);
				}
				return lstPurchaseReturnDetail;
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

		public PurchaseReturnDetail PurchaseReturnDetail_GetById(Int64 ReturnDetailId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PurchaseReturnDetail oPurchaseReturnDetail = new PurchaseReturnDetail();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturnDetail_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReturnDetailId", DbType.Int64, ReturnDetailId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPurchaseReturnDetail);
				}
				return oPurchaseReturnDetail;
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

		public int Add(PurchaseReturnDetail _PurchaseReturnDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturnDetail_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReturnId", DbType.Int64, _PurchaseReturnDetail.ReturnId);
				AddParameter(oDbCommand, "@ProductId", DbType.Int32, _PurchaseReturnDetail.ProductId);
				AddParameter(oDbCommand, "@ReturnQty", DbType.Double, _PurchaseReturnDetail.ReturnQty);
				AddParameter(oDbCommand, "@ReturnPrice", DbType.Double, _PurchaseReturnDetail.ReturnPrice);
				AddParameter(oDbCommand, "@ReturnAmount", DbType.Double, _PurchaseReturnDetail.ReturnAmount);
                AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, _PurchaseReturnDetail.PurchaseId);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(PurchaseReturnDetail _PurchaseReturnDetail)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturnDetail_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReturnId", DbType.Int64, _PurchaseReturnDetail.ReturnId);
				AddParameter(oDbCommand, "@ProductId", DbType.Int32, _PurchaseReturnDetail.ProductId);
				AddParameter(oDbCommand, "@ReturnQty", DbType.Double, _PurchaseReturnDetail.ReturnQty);
				AddParameter(oDbCommand, "@ReturnPrice", DbType.Double, _PurchaseReturnDetail.ReturnPrice);
				AddParameter(oDbCommand, "@ReturnAmount", DbType.Double, _PurchaseReturnDetail.ReturnAmount);
				AddParameter(oDbCommand, "@ReturnDetailId", DbType.Int64, _PurchaseReturnDetail.ReturnDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 ReturnDetailId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturnDetail_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReturnDetailId", DbType.Int64, ReturnDetailId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
