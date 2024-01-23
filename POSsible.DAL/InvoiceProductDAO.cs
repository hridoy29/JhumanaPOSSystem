using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class InvoiceProductDAO
    {
        public InvoiceProductDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, InvoiceProduct oInvoiceProduct)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "invoiceDtlId":
                        oInvoiceProduct.invoiceDtlId = Convert.ToInt64(oDbDataReader["invoiceDtlId"]);
                        break;
                    case "invoiceId":
                        oInvoiceProduct.invoiceId = Convert.ToInt32(oDbDataReader["invoiceId"]);
                        break;
                    case "productId":
                        oInvoiceProduct.productId = Convert.ToInt32(oDbDataReader["productId"]);
                        break;
                    case "name":
                        oInvoiceProduct.productName = Convert.ToString(oDbDataReader["name"]);
                        break;
                    case "qty":
                        if (oDbDataReader["qty"] != DBNull.Value)
                            oInvoiceProduct.qty = Convert.ToDouble(oDbDataReader["qty"]);
                        break;
                    case "unitPrice":
                        if (oDbDataReader["unitPrice"] != DBNull.Value)
                            oInvoiceProduct.unitPrice = Convert.ToDouble(oDbDataReader["unitPrice"]);
                        break;
                    case "Status":
                        if (oDbDataReader["Status"] != DBNull.Value)
                            oInvoiceProduct.Status = Convert.ToString(oDbDataReader["Status"]);
                        break;
                    case "EnteredTime":
                        if (oDbDataReader["EnteredTime"] != DBNull.Value)
                            oInvoiceProduct.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
                        break;
                    case "Updatedatime":
                        if (oDbDataReader["Updatedatime"] != DBNull.Value)
                            oInvoiceProduct.Updatedatime = Convert.ToDateTime(oDbDataReader["Updatedatime"]);
                        break;
                    case "ReturnedQty":
                        if (oDbDataReader["ReturnedQty"] != DBNull.Value)
                            oInvoiceProduct.ReturnedQty = Convert.ToDouble(oDbDataReader["ReturnedQty"]);
                        break;
                    case "PcItemId":
                        if (oDbDataReader["PcItemId"] != DBNull.Value)
                            oInvoiceProduct.PcItemId = Convert.ToInt32(oDbDataReader["PcItemId"]);
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

        public List<InvoiceProduct> InvoiceProduct_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<InvoiceProduct> lstInvoiceProduct = new List<InvoiceProduct>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                    BuildEntity(oDbDataReader, oInvoiceProduct);
                    lstInvoiceProduct.Add(oInvoiceProduct);
                }
                return lstInvoiceProduct;
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

        public List<InvoiceProduct> InvoiceProduct_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<InvoiceProduct> lstInvoiceProduct = new List<InvoiceProduct>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                    BuildEntity(oDbDataReader, oInvoiceProduct);
                    lstInvoiceProduct.Add(oInvoiceProduct);
                }
                return lstInvoiceProduct;
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

        public List<InvoiceProduct> FatturaDetail_GetForSync(Int64 invoiceId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<InvoiceProduct> lstInvoiceProduct = new List<InvoiceProduct>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("FatturaDetail_GetForSync", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@InvoiceId", DbType.Int64, invoiceId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                    BuildEntity(oDbDataReader, oInvoiceProduct);
                    lstInvoiceProduct.Add(oInvoiceProduct);
                }
                return lstInvoiceProduct;
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

        public InvoiceProduct InvoiceProduct_GetById(Int64 invoiceDtlId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                InvoiceProduct oInvoiceProduct = new InvoiceProduct();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@invoiceDtlId", DbType.Int64, invoiceDtlId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oInvoiceProduct);
                }
                return oInvoiceProduct;
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

        public int Add(InvoiceProduct _InvoiceProduct)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@invoiceId", DbType.Int32, _InvoiceProduct.invoiceId);
                AddParameter(oDbCommand, "@productId", DbType.Int32, _InvoiceProduct.productId);
                if (_InvoiceProduct.qty.HasValue)
                    AddParameter(oDbCommand, "@qty", DbType.Double, _InvoiceProduct.qty);
                else
                    AddParameter(oDbCommand, "@qty", DbType.Double, DBNull.Value);
                if (_InvoiceProduct.unitPrice.HasValue)
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, _InvoiceProduct.unitPrice);
                else
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, DBNull.Value);
                if (_InvoiceProduct.Status != null)
                    AddParameter(oDbCommand, "@Status", DbType.String, _InvoiceProduct.Status);
                else
                    AddParameter(oDbCommand, "@Status", DbType.String, DBNull.Value);
                if (_InvoiceProduct.EnteredTime.HasValue)
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _InvoiceProduct.EnteredTime);
                else
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, DBNull.Value);
                if (_InvoiceProduct.Updatedatime.HasValue)
                    AddParameter(oDbCommand, "@Updatedatime", DbType.DateTime, _InvoiceProduct.Updatedatime);
                else
                    AddParameter(oDbCommand, "@Updatedatime", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@StoreId", DbType.Int32, _InvoiceProduct.StoreId);
                AddParameter(oDbCommand, "@PcItemId", DbType.Int32, _InvoiceProduct.PcItemId);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(InvoiceProduct _InvoiceProduct)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@invoiceId", DbType.Int32, _InvoiceProduct.invoiceId);
                AddParameter(oDbCommand, "@productId", DbType.Int32, _InvoiceProduct.productId);
                if (_InvoiceProduct.qty.HasValue)
                    AddParameter(oDbCommand, "@qty", DbType.Double, _InvoiceProduct.qty);
                else
                    AddParameter(oDbCommand, "@qty", DbType.Double, DBNull.Value);
                if (_InvoiceProduct.unitPrice.HasValue)
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, _InvoiceProduct.unitPrice);
                else
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, DBNull.Value);
                if (_InvoiceProduct.Status != null)
                    AddParameter(oDbCommand, "@Status", DbType.String, _InvoiceProduct.Status);
                else
                    AddParameter(oDbCommand, "@Status", DbType.String, DBNull.Value);
                if (_InvoiceProduct.EnteredTime.HasValue)
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _InvoiceProduct.EnteredTime);
                else
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, DBNull.Value);
                if (_InvoiceProduct.Updatedatime.HasValue)
                    AddParameter(oDbCommand, "@Updatedatime", DbType.DateTime, _InvoiceProduct.Updatedatime);
                else
                    AddParameter(oDbCommand, "@Updatedatime", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@invoiceDtlId", DbType.Int64, _InvoiceProduct.invoiceDtlId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Int64 invoiceDtlId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@invoiceDtlId", DbType.Int64, invoiceDtlId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteByInvoiceId(Int32 invoiceId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InvoiceProduct_DeleteByInvoiceId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@invoiceId", DbType.Int32, invoiceId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
