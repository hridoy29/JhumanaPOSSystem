using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class ProductCategoryDAO
    {
        public ProductCategoryDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, ProductCategory oProductCategory)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "categoryId":
                        oProductCategory.categoryId = Convert.ToInt32(oDbDataReader["categoryId"]);
                        break;
                    case "deptName":
                        oProductCategory.deptName = Convert.ToString(oDbDataReader["deptName"]);
                        break;
                    case "description":
                        if (oDbDataReader["description"] != DBNull.Value)
                            oProductCategory.description = Convert.ToString(oDbDataReader["description"]);
                        break;
                    case "CodePrefix":
                        if (oDbDataReader["CodePrefix"] != DBNull.Value)
                            oProductCategory.CodePrefix = Convert.ToString(oDbDataReader["CodePrefix"]);
                        break;
                    case "ParentId":
                        if (oDbDataReader["ParentId"] != DBNull.Value)
                            oProductCategory.ParentId = Convert.ToInt32(oDbDataReader["ParentId"]);
                        break;
                    case "enteredtime":
                        if (oDbDataReader["enteredtime"] != DBNull.Value)
                            oProductCategory.enteredtime = Convert.ToDateTime(oDbDataReader["enteredtime"]);
                        break;
                    case "enteredby":
                        if (oDbDataReader["enteredby"] != DBNull.Value)
                            oProductCategory.enteredby = Convert.ToInt32(oDbDataReader["enteredby"]);
                        break;
                    case "updatedtime":
                        if (oDbDataReader["updatedtime"] != DBNull.Value)
                            oProductCategory.updatedtime = Convert.ToDateTime(oDbDataReader["updatedtime"]);
                        break;
                    case "updatedby":
                        if (oDbDataReader["updatedby"] != DBNull.Value)
                            oProductCategory.updatedby = Convert.ToInt32(oDbDataReader["updatedby"]);
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

        public List<ProductCategory> ProductCategory_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ProductCategory> lstProductCategory = new List<ProductCategory>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ProductCategory oProductCategory = new ProductCategory();
                    BuildEntity(oDbDataReader, oProductCategory);
                    lstProductCategory.Add(oProductCategory);
                }
                return lstProductCategory;
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

        public List<ProductCategory> ProductCategory_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ProductCategory> lstProductCategory = new List<ProductCategory>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ProductCategory oProductCategory = new ProductCategory();
                    BuildEntity(oDbDataReader, oProductCategory);
                    lstProductCategory.Add(oProductCategory);
                }
                return lstProductCategory;
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

        public ProductCategory ProductCategory_GetById(int categoryId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                ProductCategory oProductCategory = new ProductCategory();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@categoryId", DbType.Int32, categoryId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oProductCategory);
                }
                return oProductCategory;
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

        public int Add(ProductCategory _ProductCategory)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@deptName", DbType.String, _ProductCategory.deptName);
                if (_ProductCategory.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _ProductCategory.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_ProductCategory.CodePrefix != null)
                    AddParameter(oDbCommand, "@CodePrefix", DbType.String, _ProductCategory.CodePrefix);
                else
                    AddParameter(oDbCommand, "@CodePrefix", DbType.String, DBNull.Value);
                if (_ProductCategory.ParentId.HasValue)
                    AddParameter(oDbCommand, "@ParentId", DbType.Int32, _ProductCategory.ParentId);
                else
                    AddParameter(oDbCommand, "@ParentId", DbType.Int32, DBNull.Value);
                if (_ProductCategory.enteredtime.HasValue)
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _ProductCategory.enteredtime);
                else
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, DBNull.Value);
                if (_ProductCategory.enteredby.HasValue)
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, _ProductCategory.enteredby);
                else
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, DBNull.Value);
                if (_ProductCategory.updatedtime.HasValue)
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _ProductCategory.updatedtime);
                else
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, DBNull.Value);
                if (_ProductCategory.updatedby.HasValue)
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, _ProductCategory.updatedby);
                else
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, DBNull.Value);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ProductCategory _ProductCategory)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@deptName", DbType.String, _ProductCategory.deptName);
                if (_ProductCategory.description != null)
                    AddParameter(oDbCommand, "@description", DbType.String, _ProductCategory.description);
                else
                    AddParameter(oDbCommand, "@description", DbType.String, DBNull.Value);
                if (_ProductCategory.CodePrefix != null)
                    AddParameter(oDbCommand, "@CodePrefix", DbType.String, _ProductCategory.CodePrefix);
                else
                    AddParameter(oDbCommand, "@CodePrefix", DbType.String, DBNull.Value);
                if (_ProductCategory.ParentId.HasValue)
                    AddParameter(oDbCommand, "@ParentId", DbType.Int32, _ProductCategory.ParentId);
                else
                    AddParameter(oDbCommand, "@ParentId", DbType.Int32, DBNull.Value);
                if (_ProductCategory.enteredtime.HasValue)
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _ProductCategory.enteredtime);
                else
                    AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, DBNull.Value);
                if (_ProductCategory.enteredby.HasValue)
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, _ProductCategory.enteredby);
                else
                    AddParameter(oDbCommand, "@enteredby", DbType.Int32, DBNull.Value);
                if (_ProductCategory.updatedtime.HasValue)
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _ProductCategory.updatedtime);
                else
                    AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, DBNull.Value);
                if (_ProductCategory.updatedby.HasValue)
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, _ProductCategory.updatedby);
                else
                    AddParameter(oDbCommand, "@updatedby", DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@categoryId", DbType.Int32, _ProductCategory.categoryId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int categoryId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@categoryId", DbType.Int32, categoryId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("This Category could not be removed.", "LPOS");
                return -1;
            }
        }

        public int ProductCategory_GetByName(string categoryName)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                ProductCategory oProductCategory = new ProductCategory();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ProductCategory_GetByName", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@categoryName", DbType.String, categoryName);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oProductCategory);
                }
                return oProductCategory.categoryId;
            }
            catch (Exception ex)
            {
                return -1;
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
    }
}
