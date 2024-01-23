using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class ProductPromotionDAO
	{
		public ProductPromotionDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, ProductPromotion oProductPromotion)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "PromoId":
						oProductPromotion.PromoId = Convert.ToInt32(oDbDataReader["PromoId"]);
						break;
					case "PromoOnType":
						oProductPromotion.PromoOnType = Convert.ToString(oDbDataReader["PromoOnType"]);
						break;
					case "PromoOnId":
						oProductPromotion.PromoOnId = Convert.ToInt32(oDbDataReader["PromoOnId"]);
						break;
					case "PromoChargeType":
						oProductPromotion.PromoChargeType = Convert.ToString(oDbDataReader["PromoChargeType"]);
						break;
					case "Price":
						if (oDbDataReader["Price"] != DBNull.Value)
							oProductPromotion.Price = Convert.ToDouble(oDbDataReader["Price"]);
						break;
					case "Percentage":
						if (oDbDataReader["Percentage"] != DBNull.Value)
							oProductPromotion.Percentage = Convert.ToInt32(oDbDataReader["Percentage"]);
						break;
					case "SaleQty":
						if (oDbDataReader["SaleQty"] != DBNull.Value)
							oProductPromotion.SaleQty = Convert.ToInt32(oDbDataReader["SaleQty"]);
						break;
					case "FreeType":
						if (oDbDataReader["FreeType"] != DBNull.Value)
							oProductPromotion.FreeType = Convert.ToString(oDbDataReader["FreeType"]);
						break;
					case "FreeTypeId":
						if (oDbDataReader["FreeTypeId"] != DBNull.Value)
							oProductPromotion.FreeTypeId = Convert.ToInt32(oDbDataReader["FreeTypeId"]);
						break;
					case "FreeQty":
						if (oDbDataReader["FreeQty"] != DBNull.Value)
							oProductPromotion.FreeQty = Convert.ToInt32(oDbDataReader["FreeQty"]);
						break;
					case "StartDate":
						oProductPromotion.StartDate = Convert.ToDateTime(oDbDataReader["StartDate"]);
						break;
					case "EndDate":
						oProductPromotion.EndDate = Convert.ToDateTime(oDbDataReader["EndDate"]);
						break;
					case "CreatedBy":
						oProductPromotion.CreatedBy = Convert.ToInt32(oDbDataReader["CreatedBy"]);
						break;
					case "CreatedDate":
						if (oDbDataReader["CreatedDate"] != DBNull.Value)
							oProductPromotion.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
						break;
					case "UpdatedBy":
						if (oDbDataReader["UpdatedBy"] != DBNull.Value)
							oProductPromotion.UpdatedBy = Convert.ToInt32(oDbDataReader["UpdatedBy"]);
						break;
					case "UpdatedDate":
						if (oDbDataReader["UpdatedDate"] != DBNull.Value)
							oProductPromotion.UpdatedDate = Convert.ToDateTime(oDbDataReader["UpdatedDate"]);
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

		public List<ProductPromotion> ProductPromotion_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ProductPromotion> lstProductPromotion = new List<ProductPromotion>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductPromotion_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ProductPromotion oProductPromotion = new ProductPromotion();
					BuildEntity(oDbDataReader, oProductPromotion);
					lstProductPromotion.Add(oProductPromotion);
				}
				return lstProductPromotion;
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

		public List<ProductPromotion> ProductPromotion_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<ProductPromotion> lstProductPromotion = new List<ProductPromotion>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductPromotion_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					ProductPromotion oProductPromotion = new ProductPromotion();
					BuildEntity(oDbDataReader, oProductPromotion);
					lstProductPromotion.Add(oProductPromotion);
				}
				return lstProductPromotion;
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

		public ProductPromotion ProductPromotion_GetById(int PromoId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				ProductPromotion oProductPromotion = new ProductPromotion();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductPromotion_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PromoId", DbType.Int32, PromoId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oProductPromotion);
				}
				return oProductPromotion;
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

		public int Add(ProductPromotion _ProductPromotion)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductPromotion_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PromoOnType", DbType.String, _ProductPromotion.PromoOnType);
				AddParameter(oDbCommand, "@PromoOnId", DbType.Int32, _ProductPromotion.PromoOnId);
				AddParameter(oDbCommand, "@PromoChargeType", DbType.String, _ProductPromotion.PromoChargeType);
				if (_ProductPromotion.Price.HasValue)
					AddParameter(oDbCommand, "@Price", DbType.Double, _ProductPromotion.Price);
				else
					AddParameter(oDbCommand, "@Price",DbType.Double, DBNull.Value);
				if (_ProductPromotion.Percentage.HasValue)
					AddParameter(oDbCommand, "@Percentage", DbType.Int32, _ProductPromotion.Percentage);
				else
					AddParameter(oDbCommand, "@Percentage",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.SaleQty.HasValue)
					AddParameter(oDbCommand, "@SaleQty", DbType.Int32, _ProductPromotion.SaleQty);
				else
					AddParameter(oDbCommand, "@SaleQty",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.FreeType != null)
					AddParameter(oDbCommand, "@FreeType", DbType.String, _ProductPromotion.FreeType);
				else
					AddParameter(oDbCommand, "@FreeType",DbType.String, DBNull.Value);
				if (_ProductPromotion.FreeTypeId.HasValue)
					AddParameter(oDbCommand, "@FreeTypeId", DbType.Int32, _ProductPromotion.FreeTypeId);
				else
					AddParameter(oDbCommand, "@FreeTypeId",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.FreeQty.HasValue)
					AddParameter(oDbCommand, "@FreeQty", DbType.Int32, _ProductPromotion.FreeQty);
				else
					AddParameter(oDbCommand, "@FreeQty",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@StartDate", DbType.DateTime, _ProductPromotion.StartDate);
				AddParameter(oDbCommand, "@EndDate", DbType.DateTime, _ProductPromotion.EndDate);
				AddParameter(oDbCommand, "@CreatedBy", DbType.Int32, _ProductPromotion.CreatedBy);
				if (_ProductPromotion.CreatedDate.HasValue)
					AddParameter(oDbCommand, "@CreatedDate", DbType.DateTime, _ProductPromotion.CreatedDate);
				else
					AddParameter(oDbCommand, "@CreatedDate",DbType.DateTime, DBNull.Value);
				if (_ProductPromotion.UpdatedBy.HasValue)
					AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _ProductPromotion.UpdatedBy);
				else
					AddParameter(oDbCommand, "@UpdatedBy",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.UpdatedDate.HasValue)
					AddParameter(oDbCommand, "@UpdatedDate", DbType.DateTime, _ProductPromotion.UpdatedDate);
				else
					AddParameter(oDbCommand, "@UpdatedDate",DbType.DateTime, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(ProductPromotion _ProductPromotion)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductPromotion_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PromoOnType", DbType.String, _ProductPromotion.PromoOnType);
				AddParameter(oDbCommand, "@PromoOnId", DbType.Int32, _ProductPromotion.PromoOnId);
				AddParameter(oDbCommand, "@PromoChargeType", DbType.String, _ProductPromotion.PromoChargeType);
				if (_ProductPromotion.Price.HasValue)
					AddParameter(oDbCommand, "@Price", DbType.Double, _ProductPromotion.Price);
				else
					AddParameter(oDbCommand, "@Price",DbType.Double, DBNull.Value);
				if (_ProductPromotion.Percentage.HasValue)
					AddParameter(oDbCommand, "@Percentage", DbType.Int32, _ProductPromotion.Percentage);
				else
					AddParameter(oDbCommand, "@Percentage",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.SaleQty.HasValue)
					AddParameter(oDbCommand, "@SaleQty", DbType.Int32, _ProductPromotion.SaleQty);
				else
					AddParameter(oDbCommand, "@SaleQty",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.FreeType != null)
					AddParameter(oDbCommand, "@FreeType", DbType.String, _ProductPromotion.FreeType);
				else
					AddParameter(oDbCommand, "@FreeType",DbType.String, DBNull.Value);
				if (_ProductPromotion.FreeTypeId.HasValue)
					AddParameter(oDbCommand, "@FreeTypeId", DbType.Int32, _ProductPromotion.FreeTypeId);
				else
					AddParameter(oDbCommand, "@FreeTypeId",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.FreeQty.HasValue)
					AddParameter(oDbCommand, "@FreeQty", DbType.Int32, _ProductPromotion.FreeQty);
				else
					AddParameter(oDbCommand, "@FreeQty",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@StartDate", DbType.DateTime, _ProductPromotion.StartDate);
				AddParameter(oDbCommand, "@EndDate", DbType.DateTime, _ProductPromotion.EndDate);
				AddParameter(oDbCommand, "@CreatedBy", DbType.Int32, _ProductPromotion.CreatedBy);
				if (_ProductPromotion.CreatedDate.HasValue)
					AddParameter(oDbCommand, "@CreatedDate", DbType.DateTime, _ProductPromotion.CreatedDate);
				else
					AddParameter(oDbCommand, "@CreatedDate",DbType.DateTime, DBNull.Value);
				if (_ProductPromotion.UpdatedBy.HasValue)
					AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _ProductPromotion.UpdatedBy);
				else
					AddParameter(oDbCommand, "@UpdatedBy",DbType.Int32, DBNull.Value);
				if (_ProductPromotion.UpdatedDate.HasValue)
					AddParameter(oDbCommand, "@UpdatedDate", DbType.DateTime, _ProductPromotion.UpdatedDate);
				else
					AddParameter(oDbCommand, "@UpdatedDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@PromoId", DbType.Int32, _ProductPromotion.PromoId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int PromoId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductPromotion_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@PromoId", DbType.Int32, PromoId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
