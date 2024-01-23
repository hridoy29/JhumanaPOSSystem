using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class PurchaseReturnDAO
	{
		public PurchaseReturnDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, PurchaseReturn oPurchaseReturn)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "ReturnId":
						oPurchaseReturn.ReturnId = Convert.ToInt64(oDbDataReader["ReturnId"]);
						break;
					case "StoreId":
						oPurchaseReturn.StoreId = Convert.ToInt32(oDbDataReader["StoreId"]);
						break;
					case "PurchaseId":
						oPurchaseReturn.PurchaseId = Convert.ToInt32(oDbDataReader["PurchaseId"]);
						break;
					case "ReturnDate":
						oPurchaseReturn.ReturnDate = Convert.ToDateTime(oDbDataReader["ReturnDate"]);
						break;
					case "Remarks":
						if (oDbDataReader["Remarks"] != DBNull.Value)
							oPurchaseReturn.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
						break;
					case "TotReturnAmt":
						if (oDbDataReader["TotReturnAmt"] != DBNull.Value)
							oPurchaseReturn.TotReturnAmt = Convert.ToDouble(oDbDataReader["TotReturnAmt"]);
						break;
					case "ShiftId":
						if (oDbDataReader["ShiftId"] != DBNull.Value)
							oPurchaseReturn.ShiftId = Convert.ToInt32(oDbDataReader["ShiftId"]);
						break;
					case "IsApproved":
						if (oDbDataReader["IsApproved"] != DBNull.Value)
							oPurchaseReturn.IsApproved = Convert.ToBoolean(oDbDataReader["IsApproved"]);
						break;
					case "ApproveBy":
						if (oDbDataReader["ApproveBy"] != DBNull.Value)
							oPurchaseReturn.ApproveBy = Convert.ToInt32(oDbDataReader["ApproveBy"]);
						break;
					case "ApproveDate":
						if (oDbDataReader["ApproveDate"] != DBNull.Value)
							oPurchaseReturn.ApproveDate = Convert.ToDateTime(oDbDataReader["ApproveDate"]);
						break;
					case "CreatorId":
						oPurchaseReturn.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					case "CreateDate":
						oPurchaseReturn.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
						break;
					case "UpdatorId":
						if (oDbDataReader["UpdatorId"] != DBNull.Value)
							oPurchaseReturn.UpdatorId = Convert.ToInt32(oDbDataReader["UpdatorId"]);
						break;
					case "UpdateDate":
						if (oDbDataReader["UpdateDate"] != DBNull.Value)
							oPurchaseReturn.UpdateDate = Convert.ToDateTime(oDbDataReader["UpdateDate"]);
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

		public List<PurchaseReturn> PurchaseReturn_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchaseReturn> lstPurchaseReturn = new List<PurchaseReturn>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturn_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchaseReturn oPurchaseReturn = new PurchaseReturn();
					BuildEntity(oDbDataReader, oPurchaseReturn);
					lstPurchaseReturn.Add(oPurchaseReturn);
				}
				return lstPurchaseReturn;
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

		public List<PurchaseReturn> PurchaseReturn_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchaseReturn> lstPurchaseReturn = new List<PurchaseReturn>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturn_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchaseReturn oPurchaseReturn = new PurchaseReturn();
					BuildEntity(oDbDataReader, oPurchaseReturn);
					lstPurchaseReturn.Add(oPurchaseReturn);
				}
				return lstPurchaseReturn;
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

		public PurchaseReturn PurchaseReturn_GetById(Int64 ReturnId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PurchaseReturn oPurchaseReturn = new PurchaseReturn();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturn_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReturnId", DbType.Int64, ReturnId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPurchaseReturn);
				}
				return oPurchaseReturn;
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

		public int Add(PurchaseReturn _PurchaseReturn)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturn_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _PurchaseReturn.StoreId);
				AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, _PurchaseReturn.PurchaseId);
				AddParameter(oDbCommand, "@ReturnDate", DbType.DateTime, _PurchaseReturn.ReturnDate);
				if (_PurchaseReturn.Remarks != null)
					AddParameter(oDbCommand, "@Remarks", DbType.String, _PurchaseReturn.Remarks);
				else
					AddParameter(oDbCommand, "@Remarks",DbType.String, DBNull.Value);
				if (_PurchaseReturn.TotReturnAmt.HasValue)
					AddParameter(oDbCommand, "@TotReturnAmt", DbType.Double, _PurchaseReturn.TotReturnAmt);
				else
					AddParameter(oDbCommand, "@TotReturnAmt",DbType.Double, DBNull.Value);
				if (_PurchaseReturn.ShiftId.HasValue)
					AddParameter(oDbCommand, "@ShiftId", DbType.Int32, _PurchaseReturn.ShiftId);
				else
					AddParameter(oDbCommand, "@ShiftId",DbType.Int32, DBNull.Value);
				if (_PurchaseReturn.IsApproved.HasValue)
					AddParameter(oDbCommand, "@IsApproved", DbType.Boolean, _PurchaseReturn.IsApproved);
				else
					AddParameter(oDbCommand, "@IsApproved",DbType.Boolean, DBNull.Value);
				if (_PurchaseReturn.ApproveBy.HasValue)
					AddParameter(oDbCommand, "@ApproveBy", DbType.Int32, _PurchaseReturn.ApproveBy);
				else
					AddParameter(oDbCommand, "@ApproveBy",DbType.Int32, DBNull.Value);
				if (_PurchaseReturn.ApproveDate.HasValue)
					AddParameter(oDbCommand, "@ApproveDate", DbType.DateTime, _PurchaseReturn.ApproveDate);
				else
					AddParameter(oDbCommand, "@ApproveDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _PurchaseReturn.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _PurchaseReturn.CreateDate);
				if (_PurchaseReturn.UpdatorId.HasValue)
					AddParameter(oDbCommand, "@UpdatorId", DbType.Int32, _PurchaseReturn.UpdatorId);
				else
					AddParameter(oDbCommand, "@UpdatorId",DbType.Int32, DBNull.Value);
				if (_PurchaseReturn.UpdateDate.HasValue)
					AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, _PurchaseReturn.UpdateDate);
				else
					AddParameter(oDbCommand, "@UpdateDate",DbType.DateTime, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(PurchaseReturn _PurchaseReturn)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturn_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _PurchaseReturn.StoreId);
				AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, _PurchaseReturn.PurchaseId);
				AddParameter(oDbCommand, "@ReturnDate", DbType.DateTime, _PurchaseReturn.ReturnDate);
				if (_PurchaseReturn.Remarks != null)
					AddParameter(oDbCommand, "@Remarks", DbType.String, _PurchaseReturn.Remarks);
				else
					AddParameter(oDbCommand, "@Remarks",DbType.String, DBNull.Value);
				if (_PurchaseReturn.TotReturnAmt.HasValue)
					AddParameter(oDbCommand, "@TotReturnAmt", DbType.Double, _PurchaseReturn.TotReturnAmt);
				else
					AddParameter(oDbCommand, "@TotReturnAmt",DbType.Double, DBNull.Value);
				if (_PurchaseReturn.ShiftId.HasValue)
					AddParameter(oDbCommand, "@ShiftId", DbType.Int32, _PurchaseReturn.ShiftId);
				else
					AddParameter(oDbCommand, "@ShiftId",DbType.Int32, DBNull.Value);
				if (_PurchaseReturn.IsApproved.HasValue)
					AddParameter(oDbCommand, "@IsApproved", DbType.Boolean, _PurchaseReturn.IsApproved);
				else
					AddParameter(oDbCommand, "@IsApproved",DbType.Boolean, DBNull.Value);
				if (_PurchaseReturn.ApproveBy.HasValue)
					AddParameter(oDbCommand, "@ApproveBy", DbType.Int32, _PurchaseReturn.ApproveBy);
				else
					AddParameter(oDbCommand, "@ApproveBy",DbType.Int32, DBNull.Value);
				if (_PurchaseReturn.ApproveDate.HasValue)
					AddParameter(oDbCommand, "@ApproveDate", DbType.DateTime, _PurchaseReturn.ApproveDate);
				else
					AddParameter(oDbCommand, "@ApproveDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _PurchaseReturn.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _PurchaseReturn.CreateDate);
				if (_PurchaseReturn.UpdatorId.HasValue)
					AddParameter(oDbCommand, "@UpdatorId", DbType.Int32, _PurchaseReturn.UpdatorId);
				else
					AddParameter(oDbCommand, "@UpdatorId",DbType.Int32, DBNull.Value);
				if (_PurchaseReturn.UpdateDate.HasValue)
					AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, _PurchaseReturn.UpdateDate);
				else
					AddParameter(oDbCommand, "@UpdateDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@ReturnId", DbType.Int64, _PurchaseReturn.ReturnId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 ReturnId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseReturn_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@ReturnId", DbType.Int64, ReturnId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
