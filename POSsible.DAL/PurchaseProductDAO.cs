using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class PurchaseProductDAO
	{
		public PurchaseProductDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, PurchaseProduct oPurchaseProduct)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "purchaseDtlId":
						oPurchaseProduct.purchaseDtlId = Convert.ToInt64(oDbDataReader["purchaseDtlId"]);
						break;
					case "purchaseId":
						oPurchaseProduct.purchaseId = Convert.ToInt32(oDbDataReader["purchaseId"]);
						break;
					case "productId":
						oPurchaseProduct.productId = Convert.ToInt32(oDbDataReader["productId"]);
						break;
					case "qty":
						if (oDbDataReader["qty"] != DBNull.Value)
							oPurchaseProduct.qty = Convert.ToDouble(oDbDataReader["qty"]);
						break;
					case "unitCost":
						if (oDbDataReader["unitCost"] != DBNull.Value)
							oPurchaseProduct.unitCost = Convert.ToDouble(oDbDataReader["unitCost"]);
						break;
					case "ExpireDate":
						if (oDbDataReader["ExpireDate"] != DBNull.Value)
							oPurchaseProduct.ExpireDate = Convert.ToDateTime(oDbDataReader["ExpireDate"]);
						break;
                    case "ProductName":
                        oPurchaseProduct.ProductName = Convert.ToString(oDbDataReader["ProductName"]);
                        break;
                    case "usedQty":
                        oPurchaseProduct.usedQty = Convert.ToDouble(oDbDataReader["usedQty"]);
                        break;
                    case "ReturnedQty":
                        oPurchaseProduct.ReturnedQty = Convert.ToDouble(oDbDataReader["ReturnedQty"]);
                        break;
					case "lotNumber":
						oPurchaseProduct.lotNumber = Convert.ToString(oDbDataReader["lotNumber"]);
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

		public List<PurchaseProduct> PurchaseProduct_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchaseProduct> lstPurchaseProduct = new List<PurchaseProduct>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchaseProduct oPurchaseProduct = new PurchaseProduct();
					BuildEntity(oDbDataReader, oPurchaseProduct);
					lstPurchaseProduct.Add(oPurchaseProduct);
				}
				return lstPurchaseProduct;
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

		public List<PurchaseProduct> PurchaseProduct_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<PurchaseProduct> lstPurchaseProduct = new List<PurchaseProduct>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					PurchaseProduct oPurchaseProduct = new PurchaseProduct();
					BuildEntity(oDbDataReader, oPurchaseProduct);
					lstPurchaseProduct.Add(oPurchaseProduct);
				}
				return lstPurchaseProduct;
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

		public PurchaseProduct PurchaseProduct_GetById(Int64 purchaseDtlId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				PurchaseProduct oPurchaseProduct = new PurchaseProduct();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@purchaseDtlId", DbType.Int64, purchaseDtlId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oPurchaseProduct);
				}
				return oPurchaseProduct;
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

		public int Add(PurchaseProduct _PurchaseProduct)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@purchaseId", DbType.Int32, _PurchaseProduct.purchaseId);
				AddParameter(oDbCommand, "@productId", DbType.Int32, _PurchaseProduct.productId);
				if (_PurchaseProduct.qty.HasValue)
					AddParameter(oDbCommand, "@qty", DbType.Double, _PurchaseProduct.qty);
				else
					AddParameter(oDbCommand, "@qty",DbType.Double, DBNull.Value);
				if (_PurchaseProduct.unitCost.HasValue)
					AddParameter(oDbCommand, "@unitCost", DbType.Double, _PurchaseProduct.unitCost);
				else
					AddParameter(oDbCommand, "@unitCost",DbType.Double, DBNull.Value);
				if (_PurchaseProduct.ExpireDate.HasValue)
					AddParameter(oDbCommand, "@ExpireDate", DbType.DateTime, _PurchaseProduct.ExpireDate);
				else
					AddParameter(oDbCommand, "@ExpireDate",DbType.DateTime, DBNull.Value);
				if (!string.IsNullOrEmpty(_PurchaseProduct.lotNumber))
					AddParameter(oDbCommand, "@lotNumber", DbType.String ,_PurchaseProduct.lotNumber);
				else
					AddParameter(oDbCommand, "@lotNumber", DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(PurchaseProduct _PurchaseProduct)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@purchaseId", DbType.Int32, _PurchaseProduct.purchaseId);
				AddParameter(oDbCommand, "@productId", DbType.Int32, _PurchaseProduct.productId);
				if (_PurchaseProduct.qty.HasValue)
					AddParameter(oDbCommand, "@qty", DbType.Double, _PurchaseProduct.qty);
				else
					AddParameter(oDbCommand, "@qty",DbType.Double, DBNull.Value);
				if (_PurchaseProduct.unitCost.HasValue)
					AddParameter(oDbCommand, "@unitCost", DbType.Double, _PurchaseProduct.unitCost);
				else
					AddParameter(oDbCommand, "@unitCost",DbType.Double, DBNull.Value);
				if (_PurchaseProduct.ExpireDate.HasValue)
					AddParameter(oDbCommand, "@ExpireDate", DbType.DateTime, _PurchaseProduct.ExpireDate);
				else
					AddParameter(oDbCommand, "@ExpireDate",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@purchaseDtlId", DbType.Int64, _PurchaseProduct.purchaseDtlId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Int64 purchaseDtlId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@purchaseDtlId", DbType.Int64, purchaseDtlId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        
        public int PurchaseProduct_DeleteByPurchaseIdOnly(Int32 purchaseId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("PurchaseProduct_DeleteByPurchaseIdOnly", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@purchaseId", DbType.Int32, purchaseId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
