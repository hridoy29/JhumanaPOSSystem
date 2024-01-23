using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class PurchaseDAO
    {
        public PurchaseDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, Purchase oPurchase)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "purchaseId":
                        oPurchase.purchaseId = Convert.ToInt32(oDbDataReader["purchaseId"]);
                        break;
                    case "status":
                        if (oDbDataReader["status"] != DBNull.Value)
                            oPurchase.status = Convert.ToString(oDbDataReader["status"]);
                        break;
                    case "description":
                        if (oDbDataReader["description"] != DBNull.Value)
                            oPurchase.description = Convert.ToString(oDbDataReader["description"]);
                        break;
                    case "orderDate":
                        if (oDbDataReader["orderDate"] != DBNull.Value)
                            oPurchase.orderDate = Convert.ToDateTime(oDbDataReader["orderDate"]);
                        break;
                    case "deliveryDate":
                        if (oDbDataReader["deliveryDate"] != DBNull.Value)
                            oPurchase.deliveryDate = Convert.ToDateTime(oDbDataReader["deliveryDate"]);
                        break;
                    case "shippingMethod":
                        if (oDbDataReader["shippingMethod"] != DBNull.Value)
                            oPurchase.shippingMethod = Convert.ToString(oDbDataReader["shippingMethod"]);
                        break;
                    case "shipTo":
                        if (oDbDataReader["shipTo"] != DBNull.Value)
                            oPurchase.shipTo = Convert.ToString(oDbDataReader["shipTo"]);
                        break;
                    case "supplierId":
                        if (oDbDataReader["supplierId"] != DBNull.Value)
                            oPurchase.supplierId = Convert.ToInt32(oDbDataReader["supplierId"]);
                        break;
                    case "totalCost":
                        if (oDbDataReader["totalCost"] != DBNull.Value)
                            oPurchase.totalCost = Convert.ToDouble(oDbDataReader["totalCost"]);
                        break;
                    case "IsPaid":
                        oPurchase.IsPaid = Convert.ToBoolean(oDbDataReader["IsPaid"]);
                        break;
                    case "IsStored":
                        oPurchase.IsStored = Convert.ToBoolean(oDbDataReader["IsStored"]);
                        break;
                    case "enteredTime":
                        if (oDbDataReader["enteredTime"] != DBNull.Value)
                            oPurchase.enteredTime = Convert.ToDateTime(oDbDataReader["enteredTime"]);
                        break;
                    case "enteredBy":
                        if (oDbDataReader["enteredBy"] != DBNull.Value)
                            oPurchase.enteredBy = Convert.ToInt32(oDbDataReader["enteredBy"]);
                        break;
                    case "updatedTime":
                        if (oDbDataReader["updatedTime"] != DBNull.Value)
                            oPurchase.updatedTime = Convert.ToDateTime(oDbDataReader["updatedTime"]);
                        break;
                    case "updatedBy":
                        if (oDbDataReader["updatedBy"] != DBNull.Value)
                            oPurchase.updatedBy = Convert.ToInt32(oDbDataReader["updatedBy"]);
                        break;
                    case "SupplierName":
                        oPurchase.SupplierName = Convert.ToString(oDbDataReader["SupplierName"]);
                        break;
                    case "StoreId":
                        oPurchase.StoreId = Convert.ToInt32(oDbDataReader["StoreId"]);
                        break;
                    case "MemoNumber":
                        oPurchase.MemoNumber = Convert.ToString(oDbDataReader["MemoNumber"]);
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

        public List<Purchase> Purchase_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Purchase> lstPurchase = new List<Purchase>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Purchase oPurchase = new Purchase();
                    BuildEntity(oDbDataReader, oPurchase);
                    lstPurchase.Add(oPurchase);
                }
                return lstPurchase;
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

        public List<Purchase> Purchase_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Purchase> lstPurchase = new List<Purchase>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Purchase oPurchase = new Purchase();
                    BuildEntity(oDbDataReader, oPurchase);
                    lstPurchase.Add(oPurchase);
                }
                return lstPurchase;
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

        public Purchase Purchase_GetById(int purchaseId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                Purchase oPurchase = new Purchase();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@purchaseId", DbType.Int32, purchaseId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oPurchase);
                }
                return oPurchase;
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

        public int Add(Purchase _Purchase)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_Create", CommandType.StoredProcedure);
                if (_Purchase.status != null)
                    AddParameter(oDbCommand, "@status", DbType.String, _Purchase.status);
                else
                    AddParameter(oDbCommand, "@status", DbType.String, DBNull.Value);
                if (_Purchase.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _Purchase.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_Purchase.orderDate.HasValue)
                    AddParameter(oDbCommand, "@orderDate", DbType.DateTime, _Purchase.orderDate);
                else
                    AddParameter(oDbCommand, "@orderDate", DbType.DateTime, DBNull.Value);
                if (_Purchase.deliveryDate.HasValue)
                    AddParameter(oDbCommand, "@deliveryDate", DbType.DateTime, _Purchase.deliveryDate);
                else
                    AddParameter(oDbCommand, "@deliveryDate", DbType.DateTime, DBNull.Value);
                if (_Purchase.shippingMethod != null)
                    AddParameter(oDbCommand, "@shippingMethod", DbType.String, _Purchase.shippingMethod);
                else
                    AddParameter(oDbCommand, "@shippingMethod", DbType.String, DBNull.Value);
                if (_Purchase.shipTo != null)
                    AddParameter(oDbCommand, "@shipTo", DbType.String, _Purchase.shipTo);
                else
                    AddParameter(oDbCommand, "@shipTo", DbType.String, DBNull.Value);
                if (_Purchase.supplierId.HasValue)
                    AddParameter(oDbCommand, "@supplierId", DbType.Int32, _Purchase.supplierId);
                else
                    AddParameter(oDbCommand, "@supplierId", DbType.Int32, DBNull.Value);
                if (_Purchase.totalCost.HasValue)
                    AddParameter(oDbCommand, "@totalCost", DbType.Double, _Purchase.totalCost);
                else
                    AddParameter(oDbCommand, "@totalCost", DbType.Double, DBNull.Value);
                AddParameter(oDbCommand, "@IsPaid", DbType.Boolean, _Purchase.IsPaid);
                AddParameter(oDbCommand, "@IsStored", DbType.Boolean, _Purchase.IsStored);
                if (_Purchase.enteredTime.HasValue)
                    AddParameter(oDbCommand, "@enteredTime", DbType.DateTime, _Purchase.enteredTime);
                else
                    AddParameter(oDbCommand, "@enteredTime", DbType.DateTime, DBNull.Value);
                if (_Purchase.enteredBy.HasValue)
                    AddParameter(oDbCommand, "@enteredBy", DbType.Int32, _Purchase.enteredBy);
                else
                    AddParameter(oDbCommand, "@enteredBy", DbType.Int32, DBNull.Value);
                if (_Purchase.updatedTime.HasValue)
                    AddParameter(oDbCommand, "@updatedTime", DbType.DateTime, _Purchase.updatedTime);
                else
                    AddParameter(oDbCommand, "@updatedTime", DbType.DateTime, DBNull.Value);
                if (_Purchase.updatedBy.HasValue)
                    AddParameter(oDbCommand, "@updatedBy", DbType.Int32, _Purchase.updatedBy);
                else
                    AddParameter(oDbCommand, "@updatedBy", DbType.Int32, DBNull.Value);
                if (_Purchase.StoreId.HasValue)
                    AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Purchase.StoreId);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Purchase _Purchase)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_Update", CommandType.StoredProcedure);
                if (_Purchase.status != null)
                    AddParameter(oDbCommand, "@status", DbType.String, _Purchase.status);
                else
                    AddParameter(oDbCommand, "@status", DbType.String, DBNull.Value);
                if (_Purchase.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _Purchase.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_Purchase.orderDate.HasValue)
                    AddParameter(oDbCommand, "@orderDate", DbType.DateTime, _Purchase.orderDate);
                else
                    AddParameter(oDbCommand, "@orderDate", DbType.DateTime, DBNull.Value);
                if (_Purchase.deliveryDate.HasValue)
                    AddParameter(oDbCommand, "@deliveryDate", DbType.DateTime, _Purchase.deliveryDate);
                else
                    AddParameter(oDbCommand, "@deliveryDate", DbType.DateTime, DateTime.Now);
                if (_Purchase.shippingMethod != null)
                    AddParameter(oDbCommand, "@shippingMethod", DbType.String, _Purchase.shippingMethod);
                else
                    AddParameter(oDbCommand, "@shippingMethod", DbType.String, DBNull.Value);
                if (_Purchase.shipTo != null)
                    AddParameter(oDbCommand, "@shipTo", DbType.String, _Purchase.shipTo);
                else
                    AddParameter(oDbCommand, "@shipTo", DbType.String, DBNull.Value);
                if (_Purchase.supplierId.HasValue)
                    AddParameter(oDbCommand, "@supplierId", DbType.Int32, _Purchase.supplierId);
                else
                    AddParameter(oDbCommand, "@supplierId", DbType.Int32, DBNull.Value);
                if (_Purchase.totalCost.HasValue)
                    AddParameter(oDbCommand, "@totalCost", DbType.Double, _Purchase.totalCost);
                else
                    AddParameter(oDbCommand, "@totalCost", DbType.Double, DBNull.Value);
                AddParameter(oDbCommand, "@IsPaid", DbType.Boolean, _Purchase.IsPaid);
                AddParameter(oDbCommand, "@IsStored", DbType.Boolean, _Purchase.IsStored);
                if (_Purchase.enteredTime.HasValue)
                    AddParameter(oDbCommand, "@enteredTime", DbType.DateTime, _Purchase.enteredTime);
                else
                    AddParameter(oDbCommand, "@enteredTime", DbType.DateTime, DBNull.Value);
                if (_Purchase.enteredBy.HasValue)
                    AddParameter(oDbCommand, "@enteredBy", DbType.Int32, _Purchase.enteredBy);
                else
                    AddParameter(oDbCommand, "@enteredBy", DbType.Int32, DBNull.Value);
                if (_Purchase.updatedTime.HasValue)
                    AddParameter(oDbCommand, "@updatedTime", DbType.DateTime, _Purchase.updatedTime);
                else
                    AddParameter(oDbCommand, "@updatedTime", DbType.DateTime, DBNull.Value);
                if (_Purchase.updatedBy.HasValue)
                    AddParameter(oDbCommand, "@updatedBy", DbType.Int32, _Purchase.updatedBy);
                else
                    AddParameter(oDbCommand, "@updatedBy", DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@purchaseId", DbType.Int32, _Purchase.purchaseId);
                if (_Purchase.StoreId.HasValue)
                    AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Purchase.StoreId);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int purchaseId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@purchaseId", DbType.Int32, purchaseId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Purchase_DeletePurchaseDetailTransById(int purchaseId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_DeletePurchaseDetailTransById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@purchaseId", DbType.Int32, purchaseId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Purchase_GetPaymentByPurchaseId(Int32 PurchaseId)
        {
            DataTable dt = new DataTable();
            DbDataReader oDbDataReader = null;
            try
            {
                PurchasePayment oPurchasePayment = new PurchasePayment();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_GetPaymentByPurchaseId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@PurchaseId", DbType.Int32, PurchaseId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);

                dt.Load(oDbDataReader);
                return dt;
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

        public DataTable Purchase_GetPurchasePriceForSale(Int32 productId)
        {
            DataTable dt = new DataTable();
            DbDataReader oDbDataReader = null;
            try
            {
                PurchasePayment oPurchasePayment = new PurchasePayment();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_GetPurchasePriceForSale", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProductId", DbType.Int32, productId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);

                dt.Load(oDbDataReader);
                return dt;
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

        public void Purchase_UpdateIsPaid(Int32 PurchaseId, bool isPaid)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Purchase_UpdateIsPaid", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@IsPaid", DbType.Boolean, isPaid);
                AddParameter(oDbCommand, "@purchaseId", DbType.Int32, PurchaseId);
                DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
