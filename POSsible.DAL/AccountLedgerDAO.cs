using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class AccountLedgerDAO
	{
		public AccountLedgerDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, AccountLedger oAccountLedger)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "AccountLedgerId":
						oAccountLedger.AccountLedgerId = Convert.ToInt32(oDbDataReader["AccountLedgerId"]);
						break;
					case "AccountLedgerNo":
						oAccountLedger.AccountLedgerNo = Convert.ToInt64(oDbDataReader["AccountLedgerNo"]);
						break;
					case "AccountLedgerName":
						oAccountLedger.AccountLedgerName = Convert.ToString(oDbDataReader["AccountLedgerName"]);
						break;
					case "LedgerGroupId":
						oAccountLedger.LedgerGroupId = Convert.ToInt32(oDbDataReader["LedgerGroupId"]);
						break;
					case "AccTransTypeId":
						oAccountLedger.AccTransTypeId = Convert.ToInt32(oDbDataReader["AccTransTypeId"]);
						break;
					case "BudgetEnable":
						if (oDbDataReader["BudgetEnable"] != DBNull.Value)
							oAccountLedger.BudgetEnable = Convert.ToBoolean(oDbDataReader["BudgetEnable"]);
						break;
					case "OpeningBalanceOn":
						if (oDbDataReader["OpeningBalanceOn"] != DBNull.Value)
							oAccountLedger.OpeningBalanceOn = Convert.ToDateTime(oDbDataReader["OpeningBalanceOn"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oAccountLedger.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oAccountLedger.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oAccountLedger.CF3 = Convert.ToString(oDbDataReader["CF3"]);
						break;
                    case "AccTransTypeName":
                        if (oDbDataReader["AccTransTypeName"] != DBNull.Value)
                            oAccountLedger.AccTransTypeName = Convert.ToString(oDbDataReader["AccTransTypeName"]);
                        break;
                    case "LedgerGroupNo":
                        if (oDbDataReader["LedgerGroupNo"] != DBNull.Value)
                            oAccountLedger.LedgerGroupNo = Convert.ToInt32(oDbDataReader["LedgerGroupNo"]);
                        break;
                    case "LedgerGroupName":
                        if (oDbDataReader["LedgerGroupName"] != DBNull.Value)
                            oAccountLedger.LedgerGroupName = Convert.ToString(oDbDataReader["LedgerGroupName"]);
                        break;
                    case "AccountLedgerNameWithNo":
                        if (oDbDataReader["AccountLedgerNameWithNo"] != DBNull.Value)
                            oAccountLedger.AccountLedgerNameWithNo = Convert.ToString(oDbDataReader["AccountLedgerNameWithNo"]);
                        break;
                    case "ProjectName":
                        if (oDbDataReader["ProjectName"] != DBNull.Value)
                            oAccountLedger.ProjectName = Convert.ToString(oDbDataReader["ProjectName"]);
                        break;
                    case "DrAmt":
                        if (oDbDataReader["DrAmt"] != DBNull.Value)
                            oAccountLedger.DrAmt = Convert.ToDecimal(oDbDataReader["DrAmt"]);
                        break;
                    case "CrAmt":
                        if (oDbDataReader["CrAmt"] != DBNull.Value)
                            oAccountLedger.CrAmt = Convert.ToDecimal(oDbDataReader["CrAmt"]);
                        break;
                    case "TransactionId":
                        if (oDbDataReader["TransactionId"] != DBNull.Value)
                            oAccountLedger.TransactionId = Convert.ToInt64(oDbDataReader["TransactionId"]);
                        break;
                    case "CLassName":
                        if (oDbDataReader["CLassName"] != DBNull.Value)
                            oAccountLedger.CLassName = Convert.ToString(oDbDataReader["CLassName"]);
                        break;

                    case "OpeningBalance":
                        if (oDbDataReader["OpeningBalance"] != DBNull.Value)
                            oAccountLedger.OpeningBalance = Convert.ToDecimal(oDbDataReader["OpeningBalance"]);
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

		public List<AccountLedger> AccountLedger_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<AccountLedger> lstAccountLedger = new List<AccountLedger>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					AccountLedger oAccountLedger = new AccountLedger();
					BuildEntity(oDbDataReader, oAccountLedger);
					lstAccountLedger.Add(oAccountLedger);
				}
				return lstAccountLedger;
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

        public List<AccountLedger> AccountLedger_GetAllAssetsLiabilities(int ProjectId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<AccountLedger> lstAccountLedger = new List<AccountLedger>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_GetAllAssetsLiabilities", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.Int32, ProjectId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    AccountLedger oAccountLedger = new AccountLedger();
                    BuildEntity(oDbDataReader, oAccountLedger);
                    lstAccountLedger.Add(oAccountLedger);
                }
                return lstAccountLedger;
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

        public AccountLedger AccountLedger_GetByName(string AccLedgerName)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                AccountLedger oAccountLedger = new AccountLedger();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_GetByName", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AccountLedgerName", DbType.String, AccLedgerName);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oAccountLedger);
                }
                return oAccountLedger;
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

        public List<AccountLedger> AccountLedger_GetAllAssetsLiabilitiesSaved(int ProjectId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<AccountLedger> lstAccountLedger = new List<AccountLedger>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_GetAllAssetsLiabilitiesSaved", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.Int32, ProjectId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    AccountLedger oAccountLedger = new AccountLedger();
                    BuildEntity(oDbDataReader, oAccountLedger);
                    lstAccountLedger.Add(oAccountLedger);
                }
                return lstAccountLedger;
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

		public List<AccountLedger> AccountLedger_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<AccountLedger> lstAccountLedger = new List<AccountLedger>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					AccountLedger oAccountLedger = new AccountLedger();
					BuildEntity(oDbDataReader, oAccountLedger);
					lstAccountLedger.Add(oAccountLedger);
				}
				return lstAccountLedger;
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

		public AccountLedger AccountLedger_GetById(int AccountLedgerId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				AccountLedger oAccountLedger = new AccountLedger();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccountLedgerId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oAccountLedger);
				}
				return oAccountLedger;
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

		public int Add(AccountLedger _AccountLedger)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@AccountLedgerNo", DbType.Int64, _AccountLedger.AccountLedgerNo);
				AddParameter(oDbCommand, "@AccountLedgerName", DbType.String, _AccountLedger.AccountLedgerName);
				AddParameter(oDbCommand, "@LedgerGroupId", DbType.Int32, _AccountLedger.LedgerGroupId);
				AddParameter(oDbCommand, "@AccTransTypeId", DbType.Int32, _AccountLedger.AccTransTypeId);
				if (_AccountLedger.BudgetEnable.HasValue)
					AddParameter(oDbCommand, "@BudgetEnable", DbType.Boolean, _AccountLedger.BudgetEnable);
				else
					AddParameter(oDbCommand, "@BudgetEnable",DbType.Boolean, DBNull.Value);
				if (_AccountLedger.OpeningBalanceOn.HasValue)
					AddParameter(oDbCommand, "@OpeningBalanceOn", DbType.DateTime, _AccountLedger.OpeningBalanceOn);
				else
					AddParameter(oDbCommand, "@OpeningBalanceOn",DbType.DateTime, DBNull.Value);
				if (_AccountLedger.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _AccountLedger.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_AccountLedger.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _AccountLedger.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_AccountLedger.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _AccountLedger.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int UpdateName(AccountLedger _AccountLedger)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_UpdateName", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@AccountLedgerName", DbType.String, _AccountLedger.AccountLedgerName);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _AccountLedger.AccountLedgerId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public int UpdateOpeningBalanceEntered(AccountLedger _AccountLedger)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_UpdateOpeningBalanceEntered", CommandType.StoredProcedure);
                
                if (_AccountLedger.CF2 != null)
                    AddParameter(oDbCommand, "@CF2", DbType.String, _AccountLedger.CF2);
                else
                    AddParameter(oDbCommand, "@CF2", DbType.String, DBNull.Value);
                
                AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, _AccountLedger.AccountLedgerId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public int Delete(int AccountLedgerId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("AccountLedger_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@AccountLedgerId", DbType.Int32, AccountLedgerId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<AccountLedger> Report_TrialBalance(string ProjectId, DateTime FromDate, DateTime ToDate)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<AccountLedger> lstAccountLedger = new List<AccountLedger>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_TrialBalance", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.String, ProjectId);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, ToDate);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    AccountLedger oAccountLedger = new AccountLedger();
                    BuildEntity(oDbDataReader, oAccountLedger);
                    lstAccountLedger.Add(oAccountLedger);
                }
                return lstAccountLedger;
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

        public List<AccountLedger> Report_TrialBalanceUSD(string ProjectId, DateTime FromDate, DateTime ToDate)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<AccountLedger> lstAccountLedger = new List<AccountLedger>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_TrialBalanceUSD", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ProjectId", DbType.String, ProjectId);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, ToDate);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    AccountLedger oAccountLedger = new AccountLedger();
                    BuildEntity(oDbDataReader, oAccountLedger);
                    lstAccountLedger.Add(oAccountLedger);
                }
                return lstAccountLedger;
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
