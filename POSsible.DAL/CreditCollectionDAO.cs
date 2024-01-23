using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class CreditCollectionDAO
    {
        public CreditCollectionDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, CreditCollection oCreditCollection)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "CreditCollectionId":
                        oCreditCollection.CreditCollectionId = Convert.ToInt64(oDbDataReader["CreditCollectionId"]);
                        break;
                    case "SaleId":
                        oCreditCollection.SaleId = Convert.ToInt32(oDbDataReader["SaleId"]);
                        break;
                    case "PaidAmount":
                        oCreditCollection.PaidAmount = Convert.ToDouble(oDbDataReader["PaidAmount"]);
                        break;
                    case "DiscAmount":
                        if (oDbDataReader["DiscAmount"] != DBNull.Value)
                            oCreditCollection.DiscAmount = Convert.ToDouble(oDbDataReader["DiscAmount"]);
                        break;
                    case "RemAmount":
                        if (oDbDataReader["RemAmount"] != DBNull.Value)
                            oCreditCollection.RemAmount = Convert.ToDouble(oDbDataReader["RemAmount"]);
                        break;
                    case "DueBalance":
                        if (oDbDataReader["DueBalance"] != DBNull.Value)
                            oCreditCollection.DueBalance = Convert.ToDouble(oDbDataReader["DueBalance"]);
                        break;
                    case "CollectionDate":
                        oCreditCollection.CollectionDate = Convert.ToDateTime(oDbDataReader["CollectionDate"]);
                        break;
                    case "ChequeDate":
                        if (oDbDataReader["ChequeDate"] != DBNull.Value)
                            oCreditCollection.ChequeDate = Convert.ToDateTime(oDbDataReader["ChequeDate"]);
                        break;
                    case "ChequeNo":
                        if (oDbDataReader["ChequeNo"] != DBNull.Value)
                            oCreditCollection.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
                        break;
                    case "ChequeBank":
                        if (oDbDataReader["ChequeBank"] != DBNull.Value)
                            oCreditCollection.ChequeBank = Convert.ToString(oDbDataReader["ChequeBank"]);
                        break;
                    case "isChequeCleared":
                        if (oDbDataReader["isChequeCleared"] != DBNull.Value)
                            oCreditCollection.isChequeCleared = Convert.ToBoolean(oDbDataReader["isChequeCleared"]);
                        break;
                    case "MemoNo":
                        oCreditCollection.MemoNo = Convert.ToString(oDbDataReader["MemoNo"]);
                        break;
                    case "PaidBy":
                        if (oDbDataReader["PaidBy"] != DBNull.Value)
                            oCreditCollection.PaidBy = Convert.ToString(oDbDataReader["PaidBy"]);
                        break;
                    case "ReceivedBy":
                        oCreditCollection.ReceivedBy = Convert.ToInt32(oDbDataReader["ReceivedBy"]);
                        break;
                    case "Remarks":
                        if (oDbDataReader["Remarks"] != DBNull.Value)
                            oCreditCollection.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                        break;
                    case "ManualMRNo":
                        if (oDbDataReader["ManualMRNo"] != DBNull.Value)
                            oCreditCollection.ManualMRNo = Convert.ToString(oDbDataReader["ManualMRNo"]);
                        break;
                    case "MRBookNo":
                        if (oDbDataReader["MRBookNo"] != DBNull.Value)
                            oCreditCollection.MRBookNo = Convert.ToString(oDbDataReader["MRBookNo"]);
                        break;
                    case "EnteredBy":
                        oCreditCollection.EnteredBy = Convert.ToInt32(oDbDataReader["EnteredBy"]);
                        break;
                    case "EnteredTime":
                        if (oDbDataReader["EnteredTime"] != DBNull.Value)
                            oCreditCollection.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
                        break;
                    case "UpdatedBy":
                        oCreditCollection.UpdatedBy = Convert.ToInt32(oDbDataReader["UpdatedBy"]);
                        break;
                    case "UpdatedTime":
                        if (oDbDataReader["UpdatedTime"] != DBNull.Value)
                            oCreditCollection.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
                        break;
                    case "CF1":
                        if (oDbDataReader["CF1"] != DBNull.Value)
                            oCreditCollection.CF1 = Convert.ToString(oDbDataReader["CF1"]);
                        break;
                    case "CF2":
                        if (oDbDataReader["CF2"] != DBNull.Value)
                            oCreditCollection.CF2 = Convert.ToString(oDbDataReader["CF2"]);
                        break;
                    case "CollectionType":
                        if (oDbDataReader["CollectionType"] != DBNull.Value)
                            oCreditCollection.CollectionType = Convert.ToString(oDbDataReader["CollectionType"]);
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

        public List<CreditCollection> CreditCollection_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<CreditCollection> lstCreditCollection = new List<CreditCollection>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    CreditCollection oCreditCollection = new CreditCollection();
                    BuildEntity(oDbDataReader, oCreditCollection);
                    lstCreditCollection.Add(oCreditCollection);
                }
                return lstCreditCollection;
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

        public List<CreditCollection> CreditCollection_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<CreditCollection> lstCreditCollection = new List<CreditCollection>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    CreditCollection oCreditCollection = new CreditCollection();
                    BuildEntity(oDbDataReader, oCreditCollection);
                    lstCreditCollection.Add(oCreditCollection);
                }
                return lstCreditCollection;
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

        public CreditCollection CreditCollection_GetById(Int64 CreditCollectionId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                CreditCollection oCreditCollection = new CreditCollection();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@CreditCollectionId", DbType.Int64, CreditCollectionId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oCreditCollection);
                }
                return oCreditCollection;
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

        public int Add(CreditCollection _CreditCollection)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@SaleId", DbType.Int32, _CreditCollection.SaleId);
                AddParameter(oDbCommand, "@PaidAmount", DbType.Double, _CreditCollection.PaidAmount);
                if (_CreditCollection.DiscAmount.HasValue)
                    AddParameter(oDbCommand, "@DiscAmount", DbType.Double, _CreditCollection.DiscAmount);
                else
                    AddParameter(oDbCommand, "@DiscAmount", DbType.Double, DBNull.Value);
                if (_CreditCollection.RemAmount.HasValue)
                    AddParameter(oDbCommand, "@RemAmount", DbType.Double, _CreditCollection.RemAmount);
                else
                    AddParameter(oDbCommand, "@RemAmount", DbType.Double, DBNull.Value);
                if (_CreditCollection.DueBalance.HasValue)
                    AddParameter(oDbCommand, "@DueBalance", DbType.Double, _CreditCollection.DueBalance);
                else
                    AddParameter(oDbCommand, "@DueBalance", DbType.Double, DBNull.Value);
                AddParameter(oDbCommand, "@CollectionDate", DbType.DateTime, _CreditCollection.CollectionDate);
                if (_CreditCollection.ChequeDate.HasValue)
                    AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _CreditCollection.ChequeDate);
                else
                    AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, DBNull.Value);
                if (_CreditCollection.ChequeNo != null)
                    AddParameter(oDbCommand, "@ChequeNo", DbType.String, _CreditCollection.ChequeNo);
                else
                    AddParameter(oDbCommand, "@ChequeNo", DbType.String, DBNull.Value);
                if (_CreditCollection.ChequeBank != null)
                    AddParameter(oDbCommand, "@ChequeBank", DbType.String, _CreditCollection.ChequeBank);
                else
                    AddParameter(oDbCommand, "@ChequeBank", DbType.String, DBNull.Value);
                if (_CreditCollection.isChequeCleared.HasValue)
                    AddParameter(oDbCommand, "@isChequeCleared", DbType.Boolean, _CreditCollection.isChequeCleared);
                else
                    AddParameter(oDbCommand, "@isChequeCleared", DbType.Boolean, DBNull.Value);
                AddParameter(oDbCommand, "@MemoNo", DbType.String, _CreditCollection.MemoNo);
                if (_CreditCollection.PaidBy != null)
                    AddParameter(oDbCommand, "@PaidBy", DbType.String, _CreditCollection.PaidBy);
                else
                    AddParameter(oDbCommand, "@PaidBy", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@ReceivedBy", DbType.Int32, _CreditCollection.ReceivedBy);
                if (_CreditCollection.Remarks != null)
                    AddParameter(oDbCommand, "@Remarks", DbType.String, _CreditCollection.Remarks);
                else
                    AddParameter(oDbCommand, "@Remarks", DbType.String, DBNull.Value);
                if (_CreditCollection.ManualMRNo != null)
                    AddParameter(oDbCommand, "@ManualMRNo", DbType.String, _CreditCollection.ManualMRNo);
                else
                    AddParameter(oDbCommand, "@ManualMRNo", DbType.String, DBNull.Value);
                if (_CreditCollection.MRBookNo != null)
                    AddParameter(oDbCommand, "@MRBookNo", DbType.String, _CreditCollection.MRBookNo);
                else
                    AddParameter(oDbCommand, "@MRBookNo", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _CreditCollection.EnteredBy);
                if (_CreditCollection.EnteredTime.HasValue)
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _CreditCollection.EnteredTime);
                else
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _CreditCollection.UpdatedBy);
                if (_CreditCollection.UpdatedTime.HasValue)
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _CreditCollection.UpdatedTime);
                else
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, DBNull.Value);
                if (_CreditCollection.CF1 != null)
                    AddParameter(oDbCommand, "@CF1", DbType.String, _CreditCollection.CF1);
                else
                    AddParameter(oDbCommand, "@CF1", DbType.String, DBNull.Value);
                if (_CreditCollection.CF2 != null)
                    AddParameter(oDbCommand, "@CF2", DbType.String, _CreditCollection.CF2);
                else
                    AddParameter(oDbCommand, "@CF2", DbType.String, DBNull.Value);

                if (_CreditCollection.CollectionType != null)
                    AddParameter(oDbCommand, "@CollectionType", DbType.String, _CreditCollection.CollectionType);
                else
                    AddParameter(oDbCommand, "@CollectionType", DbType.String, DBNull.Value);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(CreditCollection _CreditCollection)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@SaleId", DbType.Int32, _CreditCollection.SaleId);
                AddParameter(oDbCommand, "@PaidAmount", DbType.Double, _CreditCollection.PaidAmount);
                if (_CreditCollection.DiscAmount.HasValue)
                    AddParameter(oDbCommand, "@DiscAmount", DbType.Double, _CreditCollection.DiscAmount);
                else
                    AddParameter(oDbCommand, "@DiscAmount", DbType.Double, DBNull.Value);
                if (_CreditCollection.RemAmount.HasValue)
                    AddParameter(oDbCommand, "@RemAmount", DbType.Double, _CreditCollection.RemAmount);
                else
                    AddParameter(oDbCommand, "@RemAmount", DbType.Double, DBNull.Value);
                if (_CreditCollection.DueBalance.HasValue)
                    AddParameter(oDbCommand, "@DueBalance", DbType.Double, _CreditCollection.DueBalance);
                else
                    AddParameter(oDbCommand, "@DueBalance", DbType.Double, DBNull.Value);
                AddParameter(oDbCommand, "@CollectionDate", DbType.DateTime, _CreditCollection.CollectionDate);
                if (_CreditCollection.ChequeDate.HasValue)
                    AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, _CreditCollection.ChequeDate);
                else
                    AddParameter(oDbCommand, "@ChequeDate", DbType.DateTime, DBNull.Value);
                if (_CreditCollection.ChequeNo != null)
                    AddParameter(oDbCommand, "@ChequeNo", DbType.String, _CreditCollection.ChequeNo);
                else
                    AddParameter(oDbCommand, "@ChequeNo", DbType.String, DBNull.Value);
                if (_CreditCollection.ChequeBank != null)
                    AddParameter(oDbCommand, "@ChequeBank", DbType.String, _CreditCollection.ChequeBank);
                else
                    AddParameter(oDbCommand, "@ChequeBank", DbType.String, DBNull.Value);
                if (_CreditCollection.isChequeCleared.HasValue)
                    AddParameter(oDbCommand, "@isChequeCleared", DbType.Boolean, _CreditCollection.isChequeCleared);
                else
                    AddParameter(oDbCommand, "@isChequeCleared", DbType.Boolean, DBNull.Value);
                AddParameter(oDbCommand, "@MemoNo", DbType.String, _CreditCollection.MemoNo);
                if (_CreditCollection.PaidBy != null)
                    AddParameter(oDbCommand, "@PaidBy", DbType.String, _CreditCollection.PaidBy);
                else
                    AddParameter(oDbCommand, "@PaidBy", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@ReceivedBy", DbType.Int32, _CreditCollection.ReceivedBy);
                if (_CreditCollection.Remarks != null)
                    AddParameter(oDbCommand, "@Remarks", DbType.String, _CreditCollection.Remarks);
                else
                    AddParameter(oDbCommand, "@Remarks", DbType.String, DBNull.Value);
                if (_CreditCollection.ManualMRNo != null)
                    AddParameter(oDbCommand, "@ManualMRNo", DbType.String, _CreditCollection.ManualMRNo);
                else
                    AddParameter(oDbCommand, "@ManualMRNo", DbType.String, DBNull.Value);
                if (_CreditCollection.MRBookNo != null)
                    AddParameter(oDbCommand, "@MRBookNo", DbType.String, _CreditCollection.MRBookNo);
                else
                    AddParameter(oDbCommand, "@MRBookNo", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _CreditCollection.EnteredBy);
                if (_CreditCollection.EnteredTime.HasValue)
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _CreditCollection.EnteredTime);
                else
                    AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _CreditCollection.UpdatedBy);
                if (_CreditCollection.UpdatedTime.HasValue)
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _CreditCollection.UpdatedTime);
                else
                    AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, DBNull.Value);
                if (_CreditCollection.CF1 != null)
                    AddParameter(oDbCommand, "@CF1", DbType.String, _CreditCollection.CF1);
                else
                    AddParameter(oDbCommand, "@CF1", DbType.String, DBNull.Value);
                if (_CreditCollection.CF2 != null)
                    AddParameter(oDbCommand, "@CF2", DbType.String, _CreditCollection.CF2);
                else
                    AddParameter(oDbCommand, "@CF2", DbType.String, DBNull.Value);
                if (_CreditCollection.CollectionType != null)
                    AddParameter(oDbCommand, "@CollectionType", DbType.String, _CreditCollection.CollectionType);
                else
                    AddParameter(oDbCommand, "@CollectionType", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@CreditCollectionId", DbType.Int64, _CreditCollection.CreditCollectionId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Int64 CreditCollectionId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@CreditCollectionId", DbType.Int64, CreditCollectionId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePaidAmount(int saleId, double paidAmount, DateTime saleDate)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CreditCollection_UpdatePaidAmount", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@SaleId", DbType.Int32, saleId);
                AddParameter(oDbCommand, "@PaidAmount", DbType.Double, paidAmount);
                AddParameter(oDbCommand, "@SaleDate", DbType.DateTime, saleDate);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
