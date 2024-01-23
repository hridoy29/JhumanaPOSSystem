using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class ACCTransactionDAO
    {
        public ACCTransactionDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, ACCTransaction oTransaction)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "TransactionId":
                        oTransaction.TransactionId = Convert.ToInt64(oDbDataReader["TransactionId"]);
                        break;
                    case "AccountLedgerId":
                        oTransaction.AccountLedgerId = Convert.ToInt32(oDbDataReader["AccountLedgerId"]);
                        break;
                    case "TransactionDate":
                        oTransaction.TransactionDate = Convert.ToDateTime(oDbDataReader["TransactionDate"]);
                        break;
                    case "Narration":
                        oTransaction.Narration = Convert.ToString(oDbDataReader["Narration"]);
                        break;
                    case "DrAmt":
                        oTransaction.DrAmt = Convert.ToDouble(oDbDataReader["DrAmt"]);
                        break;
                    case "CrAmt":
                        oTransaction.CrAmt = Convert.ToDouble(oDbDataReader["CrAmt"]);
                        break;
                    case "BalanceAmt":
                        oTransaction.BalanceAmt = Convert.ToDecimal(oDbDataReader["BalanceAmt"]);
                        break;
                    case "SalesId":
                        if (oDbDataReader["SalesId"] != DBNull.Value)
                            oTransaction.SalesId = Convert.ToInt64(oDbDataReader["SalesId"]);
                        break;
                    case "PurchaseId":
                        if (oDbDataReader["PurchaseId"] != DBNull.Value)
                            oTransaction.PurchaseId = Convert.ToInt64(oDbDataReader["PurchaseId"]);
                        break;
                    case "CustomerId":
                        if (oDbDataReader["CustomerId"] != DBNull.Value)
                            oTransaction.CustomerId = Convert.ToInt64(oDbDataReader["CustomerId"]);
                        break;
                    case "VoucherNo":
                        if (oDbDataReader["VoucherNo"] != DBNull.Value)
                            oTransaction.VoucherNo = Convert.ToString(oDbDataReader["VoucherNo"]);
                        break;
                    case "BankId":
                        if (oDbDataReader["BankId"] != DBNull.Value)
                            oTransaction.BankId = Convert.ToInt32(oDbDataReader["BankId"]);
                        break;
                    case "BranchId":
                        if (oDbDataReader["BranchId"] != DBNull.Value)
                            oTransaction.BranchId = Convert.ToInt32(oDbDataReader["BranchId"]);
                        break;
                    case "ChequeNo":
                        if (oDbDataReader["ChequeNo"] != DBNull.Value)
                            oTransaction.ChequeNo = Convert.ToString(oDbDataReader["ChequeNo"]);
                        break;
                    case "CreateDate":
                        oTransaction.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
                        break;
                    case "CreatorId":
                        oTransaction.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
                        break;
                    case "CustomField1":
                        if (oDbDataReader["CustomField1"] != DBNull.Value)
                            oTransaction.CustomField1 = Convert.ToString(oDbDataReader["CustomField1"]);
                        break;
                    case "CustomField2":
                        if (oDbDataReader["CustomField2"] != DBNull.Value)
                            oTransaction.CustomField2 = Convert.ToString(oDbDataReader["CustomField2"]);
                        break;
                    case "CustomField3":
                        if (oDbDataReader["CustomField3"] != DBNull.Value)
                            oTransaction.CustomField3 = Convert.ToString(oDbDataReader["CustomField3"]);
                        break;
                    case "CustomField4":
                        if (oDbDataReader["CustomField4"] != DBNull.Value)
                            oTransaction.CustomField4 = Convert.ToString(oDbDataReader["CustomField4"]);
                        break;
                    case "CustomField5":
                        if (oDbDataReader["CustomField5"] != DBNull.Value)
                            oTransaction.CustomField5 = Convert.ToString(oDbDataReader["CustomField5"]);
                        break;
                    case "IsVoid":
                        oTransaction.IsVoid = Convert.ToBoolean(oDbDataReader["IsVoid"]);
                        break;
                    case "VoidReson":
                        if (oDbDataReader["VoidReson"] != DBNull.Value)
                            oTransaction.VoidReson = Convert.ToString(oDbDataReader["VoidReson"]);
                        break;
                    case "VoidDate":
                        if (oDbDataReader["VoidDate"] != DBNull.Value)
                            oTransaction.VoidDate = Convert.ToDateTime(oDbDataReader["VoidDate"]);
                        break;
                    case "VoidBy":
                        if (oDbDataReader["VoidBy"] != DBNull.Value)
                            oTransaction.VoidBy = Convert.ToInt32(oDbDataReader["VoidBy"]);
                        break;
                    case "AccountLedgerName":
                        if (oDbDataReader["AccountLedgerName"] != DBNull.Value)
                            oTransaction.AccountLedgerName = Convert.ToString(oDbDataReader["AccountLedgerName"]);
                        break;
                    case "AccTransTypeName":
                        if (oDbDataReader["AccTransTypeName"] != DBNull.Value)
                            oTransaction.AccTransTypeName = Convert.ToString(oDbDataReader["AccTransTypeName"]);
                        break;
                    case "AccTransTypeId":
                        if (oDbDataReader["AccTransTypeId"] != DBNull.Value)
                            oTransaction.AccTransTypeId = Convert.ToInt32(oDbDataReader["AccTransTypeId"]);
                        break;
                    case "OpeningBalance":
                        if (oDbDataReader["OpeningBalance"] != DBNull.Value)
                            oTransaction.OpeningBalance = Convert.ToDecimal(oDbDataReader["OpeningBalance"]);
                        break;
                    case "VoucherFrom":
                        if (oDbDataReader["VoucherFrom"] != DBNull.Value)
                            oTransaction.VoucherFrom = Convert.ToString(oDbDataReader["VoucherFrom"]);
                        break;
                    case "VoucherMode":
                        if (oDbDataReader["VoucherMode"] != DBNull.Value)
                            oTransaction.VoucherMode = Convert.ToString(oDbDataReader["VoucherMode"]);
                        break;
                    case "DispatchNo":
                        if (oDbDataReader["DispatchNo"] != DBNull.Value)
                            oTransaction.DispatchNo = Convert.ToString(oDbDataReader["DispatchNo"]);
                        break;
                    case "VoucherId":
                        if (oDbDataReader["VoucherId"] != DBNull.Value)
                            oTransaction.VoucherId = Convert.ToInt64(oDbDataReader["VoucherId"]);
                        break;
                    case "ClassName":
                        if (oDbDataReader["ClassName"] != DBNull.Value)
                            oTransaction.ClassName = Convert.ToString(oDbDataReader["ClassName"]);
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

        public List<ACCTransaction> Transaction_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ACCTransaction> lstTransaction = new List<ACCTransaction>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ACCTransaction oTransaction = new ACCTransaction();
                    BuildEntity(oDbDataReader, oTransaction);
                    lstTransaction.Add(oTransaction);
                }
                return lstTransaction;
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

        public List<ACCTransaction> Transaction_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ACCTransaction> lstTransaction = new List<ACCTransaction>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ACCTransaction oTransaction = new ACCTransaction();
                    BuildEntity(oDbDataReader, oTransaction);
                    lstTransaction.Add(oTransaction);
                }
                return lstTransaction;
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

        public ACCTransaction Transaction_GetById(Int64 TransactionId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                ACCTransaction oTransaction = new ACCTransaction();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@TransactionId", DbType.Int64, TransactionId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oTransaction);
                }
                return oTransaction;
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

        public ACCTransaction Transaction_GetBalanceForAccLedger(int AccountLedgerId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                ACCTransaction oTransaction = new ACCTransaction();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetBalanceForAccLedger", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccountLedgerId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oTransaction);
                }
                return oTransaction;
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

        public Int64 Add(ACCTransaction _Transaction)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("ACCTransaction_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _Transaction.AccountLedgerId);
                AddParameter(oDbCommand, "@TransactionDate", DbType.DateTime, _Transaction.TransactionDate);
                AddParameter(oDbCommand, "@Narration", DbType.String, _Transaction.Narration);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _Transaction.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _Transaction.CrAmt);
                AddParameter(oDbCommand, "@BalanceAmt", DbType.Decimal, _Transaction.BalanceAmt);
                if (_Transaction.SalesId.HasValue)
                    AddParameter(oDbCommand, "@SalesId", DbType.Int64, _Transaction.SalesId);
                else
                    AddParameter(oDbCommand, "@SalesId", DbType.Int64, DBNull.Value);
                if (_Transaction.PurchaseId.HasValue)
                    AddParameter(oDbCommand, "@PurchaseId", DbType.Int64, _Transaction.PurchaseId);
                else
                    AddParameter(oDbCommand, "@PurchaseId", DbType.Int64, DBNull.Value);
                if (_Transaction.CustomerId.HasValue)
                    AddParameter(oDbCommand, "@CustomerId", DbType.Int64, _Transaction.CustomerId);
                else
                    AddParameter(oDbCommand, "@CustomerId", DbType.Int64, DBNull.Value);
                if (_Transaction.VoucherNo != null)
                    AddParameter(oDbCommand, "@VoucherNo", DbType.String, _Transaction.VoucherNo);
                else
                    AddParameter(oDbCommand, "@VoucherNo", DbType.String, DBNull.Value);
                if (_Transaction.BankId.HasValue)
                    AddParameter(oDbCommand, "@BankId", DbType.Int32, _Transaction.BankId);
                else
                    AddParameter(oDbCommand, "@BankId", DbType.Int32, DBNull.Value);
                if (_Transaction.BranchId.HasValue)
                    AddParameter(oDbCommand, "@BranchId", DbType.Int32, _Transaction.BranchId);
                else
                    AddParameter(oDbCommand, "@BranchId", DbType.Int32, DBNull.Value);
                if (_Transaction.ChequeNo != null)
                    AddParameter(oDbCommand, "@ChequeNo", DbType.String, _Transaction.ChequeNo);
                else
                    AddParameter(oDbCommand, "@ChequeNo", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _Transaction.CreateDate);
                AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _Transaction.CreatorId);
                if (_Transaction.CustomField1 != null)
                    AddParameter(oDbCommand, "@CustomField1", DbType.String, _Transaction.CustomField1);
                else
                    AddParameter(oDbCommand, "@CustomField1", DbType.String, DBNull.Value);
                if (_Transaction.CustomField2 != null)
                    AddParameter(oDbCommand, "@CustomField2", DbType.String, _Transaction.CustomField2);
                else
                    AddParameter(oDbCommand, "@CustomField2", DbType.String, DBNull.Value);
                if (_Transaction.CustomField3 != null)
                    AddParameter(oDbCommand, "@CustomField3", DbType.String, _Transaction.CustomField3);
                else
                    AddParameter(oDbCommand, "@CustomField3", DbType.String, DBNull.Value);
                if (_Transaction.CustomField4 != null)
                    AddParameter(oDbCommand, "@CustomField4", DbType.String, _Transaction.CustomField4);
                else
                    AddParameter(oDbCommand, "@CustomField4", DbType.String, DBNull.Value);
                if (_Transaction.CustomField5 != null)
                    AddParameter(oDbCommand, "@CustomField5", DbType.String, _Transaction.CustomField5);
                else
                    AddParameter(oDbCommand, "@CustomField5", DbType.String, DBNull.Value);
                AddParameter(oDbCommand, "@IsVoid", DbType.Boolean, _Transaction.IsVoid);
                if (_Transaction.VoidReson != null)
                    AddParameter(oDbCommand, "@VoidReson", DbType.String, _Transaction.VoidReson);
                else
                    AddParameter(oDbCommand, "@VoidReson", DbType.String, DBNull.Value);
                if (_Transaction.VoidDate.HasValue)
                    AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, _Transaction.VoidDate);
                else
                    AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, DBNull.Value);
                if (_Transaction.VoidBy.HasValue)
                    AddParameter(oDbCommand, "@VoidBy", DbType.Int32, _Transaction.VoidBy);
                else
                    AddParameter(oDbCommand, "@VoidBy", DbType.Int32, DBNull.Value);

                if (_Transaction.VoucherId != null)
                    AddParameter(oDbCommand, "@VoucherId", DbType.Int64, _Transaction.VoucherId);
                else
                    AddParameter(oDbCommand, "@VoucherId", DbType.Int64, DBNull.Value);

                return Convert.ToInt64(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ACCTransaction _Transaction)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_Update", CommandType.StoredProcedure);
                //AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _Transaction.AccountLedgerId);
                AddParameter(oDbCommand, "@TransactionDate", DbType.DateTime, _Transaction.TransactionDate);
                //AddParameter(oDbCommand, "@Narration", DbType.String, _Transaction.Narration);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _Transaction.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _Transaction.CrAmt);
                AddParameter(oDbCommand, "@BalanceAmt", DbType.Decimal, _Transaction.BalanceAmt);
                //if (_Transaction.SalesId.HasValue)
                //    AddParameter(oDbCommand, "@SalesId", DbType.Int64, _Transaction.SalesId);
                //else
                //    AddParameter(oDbCommand, "@SalesId",DbType.Int64, DBNull.Value);
                //if (_Transaction.PurchaseId.HasValue)
                //    AddParameter(oDbCommand, "@PurchaseId", DbType.Int64, _Transaction.PurchaseId);
                //else
                //    AddParameter(oDbCommand, "@PurchaseId",DbType.Int64, DBNull.Value);
                //if (_Transaction.CustomerId.HasValue)
                //    AddParameter(oDbCommand, "@CustomerId", DbType.Int64, _Transaction.CustomerId);
                //else
                //    AddParameter(oDbCommand, "@CustomerId",DbType.Int64, DBNull.Value);
                //if (_Transaction.VoucherNo != null)
                //    AddParameter(oDbCommand, "@VoucherNo", DbType.String, _Transaction.VoucherNo);
                //else
                //    AddParameter(oDbCommand, "@VoucherNo",DbType.String, DBNull.Value);
                //if (_Transaction.BankId.HasValue)
                //    AddParameter(oDbCommand, "@BankId", DbType.Int32, _Transaction.BankId);
                //else
                //    AddParameter(oDbCommand, "@BankId",DbType.Int32, DBNull.Value);
                //if (_Transaction.BranchId.HasValue)
                //    AddParameter(oDbCommand, "@BranchId", DbType.Int32, _Transaction.BranchId);
                //else
                //    AddParameter(oDbCommand, "@BranchId",DbType.Int32, DBNull.Value);
                //if (_Transaction.ChequeNo != null)
                //    AddParameter(oDbCommand, "@ChequeNo", DbType.String, _Transaction.ChequeNo);
                //else
                //    AddParameter(oDbCommand, "@ChequeNo",DbType.String, DBNull.Value);
                //AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _Transaction.CreateDate);
                //AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _Transaction.CreatorId);
                //if (_Transaction.CustomField1 != null)
                //    AddParameter(oDbCommand, "@CustomField1", DbType.String, _Transaction.CustomField1);
                //else
                //    AddParameter(oDbCommand, "@CustomField1",DbType.String, DBNull.Value);
                //if (_Transaction.CustomField2 != null)
                //    AddParameter(oDbCommand, "@CustomField2", DbType.String, _Transaction.CustomField2);
                //else
                //    AddParameter(oDbCommand, "@CustomField2",DbType.String, DBNull.Value);
                //if (_Transaction.CustomField3 != null)
                //    AddParameter(oDbCommand, "@CustomField3", DbType.String, _Transaction.CustomField3);
                //else
                //    AddParameter(oDbCommand, "@CustomField3",DbType.String, DBNull.Value);
                //if (_Transaction.CustomField4 != null)
                //    AddParameter(oDbCommand, "@CustomField4", DbType.String, _Transaction.CustomField4);
                //else
                //    AddParameter(oDbCommand, "@CustomField4",DbType.String, DBNull.Value);
                //if (_Transaction.CustomField5 != null)
                //    AddParameter(oDbCommand, "@CustomField5", DbType.String, _Transaction.CustomField5);
                //else
                //    AddParameter(oDbCommand, "@CustomField5",DbType.String, DBNull.Value);
                //AddParameter(oDbCommand, "@IsVoid", DbType.Boolean, _Transaction.IsVoid);
                //if (_Transaction.VoidReson != null)
                //    AddParameter(oDbCommand, "@VoidReson", DbType.String, _Transaction.VoidReson);
                //else
                //    AddParameter(oDbCommand, "@VoidReson",DbType.String, DBNull.Value);
                //if (_Transaction.VoidDate.HasValue)
                //    AddParameter(oDbCommand, "@VoidDate", DbType.DateTime, _Transaction.VoidDate);
                //else
                //    AddParameter(oDbCommand, "@VoidDate",DbType.DateTime, DBNull.Value);
                //if (_Transaction.VoidBy.HasValue)
                //    AddParameter(oDbCommand, "@VoidBy", DbType.Int32, _Transaction.VoidBy);
                //else
                //    AddParameter(oDbCommand, "@VoidBy",DbType.Int32, DBNull.Value);
                AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _Transaction.TransactionId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateFWOAutoTransaction(ACCTransaction _Transaction)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_UpdateFWOAutoTransaction", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@TransactionDate", DbType.DateTime, _Transaction.TransactionDate);
                AddParameter(oDbCommand, "@DrAmt", DbType.Double, _Transaction.DrAmt);
                AddParameter(oDbCommand, "@CrAmt", DbType.Double, _Transaction.CrAmt);
                AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _Transaction.CreatorId);
                AddParameter(oDbCommand, "@TransactionId", DbType.Int64, _Transaction.TransactionId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Int64 TransactionId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@TransactionId", DbType.Int64, TransactionId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteByVoucherNoAndProjectId(string VoucherNo, string ProjectId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_DeleteByVoucherNoAndProjectId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@VoucherNo", DbType.String, VoucherNo);
                AddParameter(oDbCommand, "@ProjectId", DbType.String, ProjectId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ACCTransaction> Transaction_GetAllForCashBook(int AccountLedgerId, DateTime _FromDate, DateTime _ToDate)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ACCTransaction> lstTransaction = new List<ACCTransaction>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_CashBook", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccountLedgerId);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, _FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, _ToDate);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ACCTransaction oTransaction = new ACCTransaction();
                    BuildEntity(oDbDataReader, oTransaction);
                    lstTransaction.Add(oTransaction);
                }
                return lstTransaction;
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

        public List<ACCTransaction> Transaction_GetAllForCashBookFac(DateTime _FromDate, DateTime _ToDate)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ACCTransaction> lstTransaction = new List<ACCTransaction>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_CashBookCAF", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, _FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, _ToDate);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ACCTransaction oTransaction = new ACCTransaction();
                    BuildEntity(oDbDataReader, oTransaction);
                    lstTransaction.Add(oTransaction);
                }
                return lstTransaction;
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

        public int UpdateBalance(int AccountLedgerId, long TransactionId, decimal diff, string change)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_UpdateBalance", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccountLedgerId);
                AddParameter(oDbCommand, "@TransactionId", DbType.Int64, TransactionId);
                AddParameter(oDbCommand, "@DiffAmt", DbType.Decimal, diff);
                AddParameter(oDbCommand, "@Change", DbType.String, change);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ACCTransaction> Transaction_GetForJournalBook(int AccLedgerId, DateTime _FromDate, DateTime _ToDate)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ACCTransaction> lstTransaction = new List<ACCTransaction>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_JournalBook", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccLedgerId);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, _FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, _ToDate);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ACCTransaction oTransaction = new ACCTransaction();
                    BuildEntity(oDbDataReader, oTransaction);
                    lstTransaction.Add(oTransaction);
                }
                return lstTransaction;
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

        public List<ACCTransaction> Transaction_GetForJournalBookUSD(int AccLedgerId, DateTime _FromDate, DateTime _ToDate)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<ACCTransaction> lstTransaction = new List<ACCTransaction>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_JournalBookUSD", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccLedgerId);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, _FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, _ToDate);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ACCTransaction oTransaction = new ACCTransaction();
                    BuildEntity(oDbDataReader, oTransaction);
                    lstTransaction.Add(oTransaction);
                }
                return lstTransaction;
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

        public DataTable Transaction_GetBalanceByHead(int AccLedgerId)
        {
            DbDataReader oDbDataReader = null;
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Transaction_GetBalanceByHead", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccLedgerId);
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
    }
}
