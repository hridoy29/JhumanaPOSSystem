using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class RefundProductDAO
    {
        public RefundProductDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, RefundProduct oRefundProduct)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "RefundDtlId":
                        oRefundProduct.RefundDtlId = Convert.ToInt64(oDbDataReader["RefundDtlId"]);
                        break;
                    case "Refundid":
                        oRefundProduct.Refundid = Convert.ToInt32(oDbDataReader["Refundid"]);
                        break;
                    case "productId":
                        oRefundProduct.productId = Convert.ToInt32(oDbDataReader["productId"]);
                        break;
                    case "qty":
                        if (oDbDataReader["qty"] != DBNull.Value)
                            oRefundProduct.qty = Convert.ToDouble(oDbDataReader["qty"]);
                        break;
                    case "UnitPrice":
                        if (oDbDataReader["UnitPrice"] != DBNull.Value)
                            oRefundProduct.UnitPrice = Convert.ToDouble(oDbDataReader["UnitPrice"]);
                        break;
                    case "description":
                        if (oDbDataReader["description"] != DBNull.Value)
                            oRefundProduct.description = Convert.ToString(oDbDataReader["description"]);
                        break;
                    case "EnteredBy":
                        if (oDbDataReader["EnteredBy"] != DBNull.Value)
                            oRefundProduct.EnteredBy = Convert.ToInt32(oDbDataReader["EnteredBy"]);
                        break;
                    case "EnteredTime":
                        if (oDbDataReader["EnteredTime"] != DBNull.Value)
                            oRefundProduct.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
                        break;
                    case "UpdatedBy":
                        if (oDbDataReader["UpdatedBy"] != DBNull.Value)
                            oRefundProduct.UpdatedBy = Convert.ToInt32(oDbDataReader["UpdatedBy"]);
                        break;
                    case "UpdatedTime":
                        if (oDbDataReader["UpdatedTime"] != DBNull.Value)
                            oRefundProduct.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
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

        public List<RefundProduct> RefundProduct_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<RefundProduct> lstRefundProduct = new List<RefundProduct>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RefundProduct_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    RefundProduct oRefundProduct = new RefundProduct();
                    BuildEntity(oDbDataReader, oRefundProduct);
                    lstRefundProduct.Add(oRefundProduct);
                }
                return lstRefundProduct;
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

        public List<RefundProduct> RefundProduct_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<RefundProduct> lstRefundProduct = new List<RefundProduct>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RefundProduct_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    RefundProduct oRefundProduct = new RefundProduct();
                    BuildEntity(oDbDataReader, oRefundProduct);
                    lstRefundProduct.Add(oRefundProduct);
                }
                return lstRefundProduct;
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

        public RefundProduct RefundProduct_GetById(Int64 RefundDtlId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                RefundProduct oRefundProduct = new RefundProduct();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RefundProduct_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@RefundDtlId", DbType.Int64, RefundDtlId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oRefundProduct);
                }
                return oRefundProduct;
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

        public int Add(RefundProduct _RefundProduct)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RefundProduct_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Refundid", DbType.Int32, _RefundProduct.Refundid);
                AddParameter(oDbCommand, "@productId", DbType.Int32, _RefundProduct.productId);
                AddParameter(oDbCommand, "@qty", DbType.Double, _RefundProduct.qty);
                if (_RefundProduct.UnitPrice.HasValue)
                    AddParameter(oDbCommand, "@UnitPrice", DbType.Double, _RefundProduct.UnitPrice);
                else
                    AddParameter(oDbCommand, "@UnitPrice", DbType.Double, DBNull.Value);
                if (_RefundProduct.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _RefundProduct.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_RefundProduct.EnteredBy.HasValue)
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _RefundProduct.EnteredBy);
                else
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, DBNull.Value);
                if (_RefundProduct.EnteredTime.HasValue)
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _RefundProduct.EnteredTime);
                else
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, DBNull.Value);
                if (_RefundProduct.UpdatedBy.HasValue)
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _RefundProduct.UpdatedBy);
                else
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, DBNull.Value);
                if (_RefundProduct.UpdatedTime.HasValue)
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _RefundProduct.UpdatedTime);
                else
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, DBNull.Value);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(RefundProduct _RefundProduct)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RefundProduct_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Refundid", DbType.Int32, _RefundProduct.Refundid);
                AddParameter(oDbCommand, "@productId", DbType.Int32, _RefundProduct.productId);
                AddParameter(oDbCommand, "@qty", DbType.Double, _RefundProduct.qty);
                if (_RefundProduct.UnitPrice.HasValue)
                    AddParameter(oDbCommand, "@UnitPrice", DbType.Double, _RefundProduct.UnitPrice);
                else
                    AddParameter(oDbCommand, "@UnitPrice", DbType.Double, DBNull.Value);
                if (_RefundProduct.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _RefundProduct.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_RefundProduct.EnteredBy.HasValue)
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _RefundProduct.EnteredBy);
                else
                    AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, DBNull.Value);
                if (_RefundProduct.EnteredTime.HasValue)
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _RefundProduct.EnteredTime);
                else
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, DBNull.Value);
                if (_RefundProduct.UpdatedBy.HasValue)
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _RefundProduct.UpdatedBy);
                else
                    AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, DBNull.Value);
                if (_RefundProduct.UpdatedTime.HasValue)
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _RefundProduct.UpdatedTime);
                else
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@RefundDtlId", DbType.Int64, _RefundProduct.RefundDtlId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Int64 RefundDtlId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("RefundProduct_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@RefundDtlId", DbType.Int64, RefundDtlId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
