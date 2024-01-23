using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class LedgerGroupDAO
	{
		public LedgerGroupDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, LedgerGroup oLedgerGroup)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "LedgerGroupId":
						oLedgerGroup.LedgerGroupId = Convert.ToInt32(oDbDataReader["LedgerGroupId"]);
						break;
					case "LedgerGroupNo":
						oLedgerGroup.LedgerGroupNo = Convert.ToInt32(oDbDataReader["LedgerGroupNo"]);
						break;
					case "LedgerGroupName":
						oLedgerGroup.LedgerGroupName = Convert.ToString(oDbDataReader["LedgerGroupName"]);
						break;
					case "ClassId":
						oLedgerGroup.ClassId = Convert.ToInt32(oDbDataReader["ClassId"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oLedgerGroup.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oLedgerGroup.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
                    case "CLassName":
                        if (oDbDataReader["CLassName"] != DBNull.Value)
                            oLedgerGroup.CLassName = Convert.ToString(oDbDataReader["CLassName"]);
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

		public List<LedgerGroup> LedgerGroup_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<LedgerGroup> lstLedgerGroup = new List<LedgerGroup>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					LedgerGroup oLedgerGroup = new LedgerGroup();
					BuildEntity(oDbDataReader, oLedgerGroup);
					lstLedgerGroup.Add(oLedgerGroup);
				}
				return lstLedgerGroup;
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

		public List<LedgerGroup> LedgerGroup_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<LedgerGroup> lstLedgerGroup = new List<LedgerGroup>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					LedgerGroup oLedgerGroup = new LedgerGroup();
					BuildEntity(oDbDataReader, oLedgerGroup);
					lstLedgerGroup.Add(oLedgerGroup);
				}
				return lstLedgerGroup;
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

		public LedgerGroup LedgerGroup_GetById(int LedgerGroupId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				LedgerGroup oLedgerGroup = new LedgerGroup();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@LedgerGroupId", DbType.Int32, LedgerGroupId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oLedgerGroup);
				}
				return oLedgerGroup;
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

		public int Add(LedgerGroup _LedgerGroup)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@LedgerGroupNo", DbType.Int32, _LedgerGroup.LedgerGroupNo);
				AddParameter(oDbCommand, "@LedgerGroupName", DbType.String, _LedgerGroup.LedgerGroupName);
				AddParameter(oDbCommand, "@ClassId", DbType.Int32, _LedgerGroup.ClassId);
				if (_LedgerGroup.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _LedgerGroup.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_LedgerGroup.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _LedgerGroup.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(LedgerGroup _LedgerGroup)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@LedgerGroupNo", DbType.Int32, _LedgerGroup.LedgerGroupNo);
				AddParameter(oDbCommand, "@LedgerGroupName", DbType.String, _LedgerGroup.LedgerGroupName);
				AddParameter(oDbCommand, "@ClassId", DbType.Int32, _LedgerGroup.ClassId);
				if (_LedgerGroup.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _LedgerGroup.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_LedgerGroup.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _LedgerGroup.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@LedgerGroupId", DbType.Int32, _LedgerGroup.LedgerGroupId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int LedgerGroupId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@LedgerGroupId", DbType.Int32, LedgerGroupId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public LedgerGroup LedgerGroup_GetByName(string LedgerGroupName)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                LedgerGroup oLedgerGroup = new LedgerGroup();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("LedgerGroup_GetByName", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@LedgerGroupName", DbType.String, LedgerGroupName);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oLedgerGroup);
                }
                return oLedgerGroup;
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
