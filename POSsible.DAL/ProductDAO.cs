using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class ProductDAO
    {
        public ProductDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, Product oProduct)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "productId":
                        oProduct.productId = Convert.ToInt32(oDbDataReader["productId"]);
                        break;
                    case "categorytId":
                        oProduct.categorytId = Convert.ToInt32(oDbDataReader["categorytId"]);
                        break;
                    case "barcodeNo":
                        if (oDbDataReader["barcodeNo"] != DBNull.Value)
                            oProduct.barcodeNo = Convert.ToString(oDbDataReader["barcodeNo"]);
                        break;
                    case "name":
                        if (oDbDataReader["name"] != DBNull.Value)
                            oProduct.name = Convert.ToString(oDbDataReader["name"]);
                        break;
                    case "shortcode":
                        if (oDbDataReader["shortcode"] != DBNull.Value)
                            oProduct.shortcode = Convert.ToString(oDbDataReader["shortcode"]);
                        break;
                    case "description":
                        if (oDbDataReader["description"] != DBNull.Value)
                            oProduct.description = Convert.ToString(oDbDataReader["description"]);
                        break;
                    case "brand":
                        if (oDbDataReader["brand"] != DBNull.Value)
                            oProduct.brand = Convert.ToString(oDbDataReader["brand"]);
                        break;
                    case "madeIn":
                        if (oDbDataReader["madeIn"] != DBNull.Value)
                            oProduct.madeIn = Convert.ToString(oDbDataReader["madeIn"]);
                        break;
                    case "weight":
                        if (oDbDataReader["weight"] != DBNull.Value)
                            oProduct.weight = Convert.ToDouble(oDbDataReader["weight"]);
                        break;
                    case "isGstItem":
                        if (oDbDataReader["isGstItem"] != DBNull.Value)
                            oProduct.isGstItem = Convert.ToBoolean(oDbDataReader["isGstItem"]);
                        break;
                    case "isexpireable":
                        if (oDbDataReader["isexpireable"] != DBNull.Value)
                            oProduct.isexpireable = Convert.ToBoolean(oDbDataReader["isexpireable"]);
                        break;
                    case "ticketType":
                        if (oDbDataReader["ticketType"] != DBNull.Value)
                            oProduct.ticketType = Convert.ToBoolean(oDbDataReader["ticketType"]);
                        break;
                    case "unitCost":
                        if (oDbDataReader["unitCost"] != DBNull.Value)
                            oProduct.unitCost = Convert.ToDouble(oDbDataReader["unitCost"]);
                        break;
                    case "unitPrice":
                        if (oDbDataReader["unitPrice"] != DBNull.Value)
                            oProduct.unitPrice = Convert.ToDouble(oDbDataReader["unitPrice"]);
                        break;
                    case "promoUnitPrice":
                        if (oDbDataReader["promoUnitPrice"] != DBNull.Value)
                            oProduct.promoUnitPrice = Convert.ToDouble(oDbDataReader["promoUnitPrice"]);
                        break;
                    case "promoStartDate":
                        if (oDbDataReader["promoStartDate"] != DBNull.Value)
                            oProduct.promoStartDate = Convert.ToDateTime(oDbDataReader["promoStartDate"]);
                        break;
                    case "promoEndDate":
                        if (oDbDataReader["promoEndDate"] != DBNull.Value)
                            oProduct.promoEndDate = Convert.ToDateTime(oDbDataReader["promoEndDate"]);
                        break;
                    case "unitMeasureId":
                        oProduct.unitMeasureId = Convert.ToInt32(oDbDataReader["unitMeasureId"]);
                        break;
                    case "qtyInStock":
                        if (oDbDataReader["qtyInStock"] != DBNull.Value)
                            oProduct.qtyInStock = Convert.ToDouble(oDbDataReader["qtyInStock"]);
                        break;
                    case "qtyInOrder":
                        if (oDbDataReader["qtyInOrder"] != DBNull.Value)
                            oProduct.qtyInOrder = Convert.ToDouble(oDbDataReader["qtyInOrder"]);
                        break;
                    case "minQty":
                        if (oDbDataReader["minQty"] != DBNull.Value)
                            oProduct.minQty = Convert.ToDouble(oDbDataReader["minQty"]);
                        break;
                    case "ProductImage":
                        if (oDbDataReader["ProductImage"] != DBNull.Value)
                            oProduct.ProductImage = (Byte[])(oDbDataReader["ProductImage"]);
                        break;
                    case "enteredtime":
                        if (oDbDataReader["enteredtime"] != DBNull.Value)
                            oProduct.enteredtime = Convert.ToDateTime(oDbDataReader["enteredtime"]);
                        break;
                    case "enteredby":
                        if (oDbDataReader["enteredby"] != DBNull.Value)
                            oProduct.enteredby = Convert.ToInt32(oDbDataReader["enteredby"]);
                        break;
                    case "updatedtime":
                        if (oDbDataReader["updatedtime"] != DBNull.Value)
                            oProduct.updatedtime = Convert.ToDateTime(oDbDataReader["updatedtime"]);
                        break;
                    case "updatedby":
                        if (oDbDataReader["updatedby"] != DBNull.Value)
                            oProduct.updatedby = Convert.ToInt32(oDbDataReader["updatedby"]);
                        break;
                    case "UnitMeasureName":
                        if (oDbDataReader["UnitMeasureName"] != DBNull.Value)
                            oProduct.UnitMeasureName = Convert.ToString(oDbDataReader["UnitMeasureName"]);
                        break;
                    case "Bar_Name":
                        oProduct.Bar_Name = Convert.ToString(oDbDataReader["Bar_Name"]);
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

        public List<Product> Product_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Product> lstProduct = new List<Product>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Product oProduct = new Product();
                    BuildEntity(oDbDataReader, oProduct);
                    lstProduct.Add(oProduct);
                }
                return lstProduct;
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

        public List<Product> Product_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Product> lstProduct = new List<Product>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Product oProduct = new Product();
                    BuildEntity(oDbDataReader, oProduct);
                    lstProduct.Add(oProduct);
                }
                return lstProduct;
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

        public Product Product_GetById(int productId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                Product oProduct = new Product();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@productId", DbType.Int32, productId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oProduct);
                }
                return oProduct;
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

        public Product Product_GetByIdAndCustomer(int productId, int customerId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                Product oProduct = new Product();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_GetByIdAndCustomer", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@productId", DbType.Int32, productId);
                AddParameter(oDbCommand, "@customerId", DbType.Int32, customerId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oProduct);
                }
                return oProduct;
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

        public int Add(Product _Product)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@categorytId", DbType.Int32, _Product.categorytId);
                if (_Product.barcodeNo != null)
                    AddParameter(oDbCommand, "@barcodeNo", DbType.String, _Product.barcodeNo);
                else
                    AddParameter(oDbCommand, "@barcodeNo", DbType.String, DBNull.Value);
                if (_Product.name != null)
                    AddParameter(oDbCommand, "@name", DbType.String, _Product.name);
                else
                    AddParameter(oDbCommand, "@name", DbType.String, DBNull.Value);
                if (_Product.shortcode != null)
                    AddParameter(oDbCommand, "@shortcode", DbType.String, _Product.shortcode);
                else
                    AddParameter(oDbCommand, "@shortcode", DbType.String, DBNull.Value);
                if (_Product.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _Product.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_Product.brand != null)
                    AddParameter(oDbCommand, "@brand", DbType.String, _Product.brand);
                else
                    AddParameter(oDbCommand, "@brand", DbType.String, DBNull.Value);
                if (_Product.madeIn != null)
                    AddParameter(oDbCommand, "@madeIn", DbType.String, _Product.madeIn);
                else
                    AddParameter(oDbCommand, "@madeIn", DbType.String, DBNull.Value);
                if (_Product.weight.HasValue)
                    AddParameter(oDbCommand, "@weight", DbType.Double, _Product.weight);
                else
                    AddParameter(oDbCommand, "@weight", DbType.Double, DBNull.Value);
                if (_Product.isGstItem.HasValue)
                    AddParameter(oDbCommand, "@isGstItem", DbType.Boolean, _Product.isGstItem);
                else
                    AddParameter(oDbCommand, "@isGstItem", DbType.Boolean, DBNull.Value);
                if (_Product.isexpireable.HasValue)
                    AddParameter(oDbCommand, "@isexpireable", DbType.Boolean, _Product.isexpireable);
                else
                    AddParameter(oDbCommand, "@isexpireable", DbType.Boolean, DBNull.Value);
                if (_Product.ticketType.HasValue)
                    AddParameter(oDbCommand, "@ticketType", DbType.Boolean, _Product.ticketType);
                else
                    AddParameter(oDbCommand, "@ticketType", DbType.Boolean, DBNull.Value);
                if (_Product.unitCost.HasValue)
                    AddParameter(oDbCommand, "@unitCost", DbType.Double, _Product.unitCost);
                else
                    AddParameter(oDbCommand, "@unitCost", DbType.Double, DBNull.Value);
                if (_Product.unitPrice.HasValue)
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, _Product.unitPrice);
                else
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, DBNull.Value);
                if (_Product.promoUnitPrice.HasValue)
                    AddParameter(oDbCommand, "@promoUnitPrice", DbType.Double, _Product.promoUnitPrice);
                else
                    AddParameter(oDbCommand, "@promoUnitPrice", DbType.Double, DBNull.Value);
                if (_Product.promoStartDate.HasValue)
                    AddParameter(oDbCommand, "@promoStartDate", DbType.DateTime, _Product.promoStartDate);
                else
                    AddParameter(oDbCommand, "@promoStartDate", DbType.DateTime, DBNull.Value);
                if (_Product.promoEndDate.HasValue)
                    AddParameter(oDbCommand, "@promoEndDate", DbType.DateTime, _Product.promoEndDate);
                else
                    AddParameter(oDbCommand, "@promoEndDate", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@unitMeasureId", DbType.Int32, _Product.unitMeasureId);
                if (_Product.qtyInStock.HasValue)
                    AddParameter(oDbCommand, "@qtyInStock", DbType.Double, _Product.qtyInStock);
                else
                    AddParameter(oDbCommand, "@qtyInStock", DbType.Double, DBNull.Value);
                if (_Product.qtyInOrder.HasValue)
                    AddParameter(oDbCommand, "@qtyInOrder", DbType.Double, _Product.qtyInOrder);
                else
                    AddParameter(oDbCommand, "@qtyInOrder", DbType.Double, DBNull.Value);
                if (_Product.minQty.HasValue)
                    AddParameter(oDbCommand, "@minQty", DbType.Double, _Product.minQty);
                else
                    AddParameter(oDbCommand, "@minQty", DbType.Double, DBNull.Value);
                if (_Product.ProductImage != null)
                    AddParameter(oDbCommand, "@ProductImage", DbType.Binary, _Product.ProductImage);
                else
                    AddParameter(oDbCommand, "@ProductImage", DbType.Binary, DBNull.Value);
                if (_Product.enteredtime.HasValue)
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _Product.enteredtime);
                else
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, DBNull.Value);
                if (_Product.enteredby.HasValue)
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, _Product.enteredby);
                else
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, DBNull.Value);
                if (_Product.updatedtime.HasValue)
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _Product.updatedtime);
                else
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, DBNull.Value);
                if (_Product.updatedby.HasValue)
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, _Product.updatedby);
                else
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, DBNull.Value);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Product _Product)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@categorytId", DbType.Int32, _Product.categorytId);
                if (_Product.barcodeNo != null)
                    AddParameter(oDbCommand, "@barcodeNo", DbType.String, _Product.barcodeNo);
                else
                    AddParameter(oDbCommand, "@barcodeNo", DbType.String, DBNull.Value);
                if (_Product.name != null)
                    AddParameter(oDbCommand, "@name", DbType.String, _Product.name);
                else
                    AddParameter(oDbCommand, "@name", DbType.String, DBNull.Value);
                if (_Product.shortcode != null)
                    AddParameter(oDbCommand, "@shortcode", DbType.String, _Product.shortcode);
                else
                    AddParameter(oDbCommand, "@shortcode", DbType.String, DBNull.Value);
                if (_Product.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _Product.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_Product.brand != null)
                    AddParameter(oDbCommand, "@brand", DbType.String, _Product.brand);
                else
                    AddParameter(oDbCommand, "@brand", DbType.String, DBNull.Value);
                if (_Product.madeIn != null)
                    AddParameter(oDbCommand, "@madeIn", DbType.String, _Product.madeIn);
                else
                    AddParameter(oDbCommand, "@madeIn", DbType.String, DBNull.Value);
                if (_Product.weight.HasValue)
                    AddParameter(oDbCommand, "@weight", DbType.Double, _Product.weight);
                else
                    AddParameter(oDbCommand, "@weight", DbType.Double, DBNull.Value);
                if (_Product.isGstItem.HasValue)
                    AddParameter(oDbCommand, "@isGstItem", DbType.Boolean, _Product.isGstItem);
                else
                    AddParameter(oDbCommand, "@isGstItem", DbType.Boolean, DBNull.Value);
                if (_Product.isexpireable.HasValue)
                    AddParameter(oDbCommand, "@isexpireable", DbType.Boolean, _Product.isexpireable);
                else
                    AddParameter(oDbCommand, "@isexpireable", DbType.Boolean, DBNull.Value);
                if (_Product.ticketType.HasValue)
                    AddParameter(oDbCommand, "@ticketType", DbType.Boolean, _Product.ticketType);
                else
                    AddParameter(oDbCommand, "@ticketType", DbType.Boolean, DBNull.Value);
                if (_Product.unitCost.HasValue)
                    AddParameter(oDbCommand, "@unitCost", DbType.Double, _Product.unitCost);
                else
                    AddParameter(oDbCommand, "@unitCost", DbType.Double, DBNull.Value);
                if (_Product.unitPrice.HasValue)
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, _Product.unitPrice);
                else
                    AddParameter(oDbCommand, "@unitPrice", DbType.Double, DBNull.Value);
                if (_Product.promoUnitPrice.HasValue)
                    AddParameter(oDbCommand, "@promoUnitPrice", DbType.Double, _Product.promoUnitPrice);
                else
                    AddParameter(oDbCommand, "@promoUnitPrice", DbType.Double, DBNull.Value);
                if (_Product.promoStartDate.HasValue)
                    AddParameter(oDbCommand, "@promoStartDate", DbType.DateTime, _Product.promoStartDate);
                else
                    AddParameter(oDbCommand, "@promoStartDate", DbType.DateTime, DBNull.Value);
                if (_Product.promoEndDate.HasValue)
                    AddParameter(oDbCommand, "@promoEndDate", DbType.DateTime, _Product.promoEndDate);
                else
                    AddParameter(oDbCommand, "@promoEndDate", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@unitMeasureId", DbType.Int32, _Product.unitMeasureId);
                if (_Product.qtyInStock.HasValue)
                    AddParameter(oDbCommand, "@qtyInStock", DbType.Double, _Product.qtyInStock);
                else
                    AddParameter(oDbCommand, "@qtyInStock", DbType.Double, DBNull.Value);
                if (_Product.qtyInOrder.HasValue)
                    AddParameter(oDbCommand, "@qtyInOrder", DbType.Double, _Product.qtyInOrder);
                else
                    AddParameter(oDbCommand, "@qtyInOrder", DbType.Double, DBNull.Value);
                if (_Product.minQty.HasValue)
                    AddParameter(oDbCommand, "@minQty", DbType.Double, _Product.minQty);
                else
                    AddParameter(oDbCommand, "@minQty", DbType.Double, DBNull.Value);
                if (_Product.ProductImage != null)
                    AddParameter(oDbCommand, "@ProductImage", DbType.Binary, _Product.ProductImage);
                else
                    AddParameter(oDbCommand, "@ProductImage", DbType.Binary, DBNull.Value);
                if (_Product.enteredtime.HasValue)
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _Product.enteredtime);
                else
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, DBNull.Value);
                if (_Product.enteredby.HasValue)
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, _Product.enteredby);
                else
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, DBNull.Value);
                if (_Product.updatedtime.HasValue)
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _Product.updatedtime);
                else
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, DBNull.Value);
                if (_Product.updatedby.HasValue)
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, _Product.updatedby);
                else
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@productId", DbType.Int32, _Product.productId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int productId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Product_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@productId", DbType.Int32, productId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetBarcodeForVariableWtProduct()
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECT ISNULL((MAX(CAST(barcodeNo AS INT))),10000)+1 FROM [tblProduct] WHERE qtyInStock=-3 and ticketType=1", CommandType.Text);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
