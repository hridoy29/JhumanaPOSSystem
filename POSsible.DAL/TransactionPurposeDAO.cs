using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class TransactionPurposeDAO
	{
		public TransactionPurposeDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, TransactionPurpose oTransactionPurpose)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "TransactionPurposeId":
						oTransactionPurpose.TransactionPurposeId = Convert.ToInt32(oDbDataReader["TransactionPurposeId"]);
						break;
					case "TransactionPurposeName":
						oTransactionPurpose.TransactionPurposeName = Convert.ToString(oDbDataReader["TransactionPurposeName"]);
						break;
					case "TransactionType":
						oTransactionPurpose.TransactionType = Convert.ToString(oDbDataReader["TransactionType"]);
						break;
					case "IsAuto":
						oTransactionPurpose.IsAuto = Convert.ToBoolean(oDbDataReader["IsAuto"]);
						break;
					case "IsActive":
						oTransactionPurpose.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
				        oTransactionPurpose.IsActiveString = oTransactionPurpose.IsActive ? "Yes" : "No";
						break;
					case "CreatorId":
						oTransactionPurpose.CreatorId = Convert.ToInt32(oDbDataReader["CreatorId"]);
						break;
					case "CreateDate":
						oTransactionPurpose.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);
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

		public List<TransactionPurpose> TransactionPurpose_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<TransactionPurpose> lstTransactionPurpose = new List<TransactionPurpose>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					TransactionPurpose oTransactionPurpose = new TransactionPurpose();
					BuildEntity(oDbDataReader, oTransactionPurpose);
					lstTransactionPurpose.Add(oTransactionPurpose);
				}
				return lstTransactionPurpose;
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

		public List<TransactionPurpose> TransactionPurpose_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<TransactionPurpose> lstTransactionPurpose = new List<TransactionPurpose>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					TransactionPurpose oTransactionPurpose = new TransactionPurpose();
					BuildEntity(oDbDataReader, oTransactionPurpose);
					lstTransactionPurpose.Add(oTransactionPurpose);
				}
				return lstTransactionPurpose;
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

		public TransactionPurpose TransactionPurpose_GetById(int TransactionPurposeId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				TransactionPurpose oTransactionPurpose = new TransactionPurpose();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionPurposeId", DbType.Int32, TransactionPurposeId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oTransactionPurpose);
				}
				return oTransactionPurpose;
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

        public TransactionPurpose TransactionPurpose_GetByName(string TransactionPurposeName)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                TransactionPurpose oTransactionPurpose = new TransactionPurpose();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_GetByName", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@TransactionPurposeName", DbType.String, TransactionPurposeName);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oTransactionPurpose);
                }
                return oTransactionPurpose;
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

		public int Add(TransactionPurpose _TransactionPurpose)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionPurposeName", DbType.String, _TransactionPurpose.TransactionPurposeName);
				AddParameter(oDbCommand, "@TransactionType", DbType.String, _TransactionPurpose.TransactionType);
				AddParameter(oDbCommand, "@IsAuto", DbType.Boolean, _TransactionPurpose.IsAuto);
				AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _TransactionPurpose.IsActive);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _TransactionPurpose.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _TransactionPurpose.CreateDate);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(TransactionPurpose _TransactionPurpose)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionPurposeName", DbType.String, _TransactionPurpose.TransactionPurposeName);
				AddParameter(oDbCommand, "@TransactionType", DbType.String, _TransactionPurpose.TransactionType);
				AddParameter(oDbCommand, "@IsAuto", DbType.Boolean, _TransactionPurpose.IsAuto);
				AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _TransactionPurpose.IsActive);
				AddParameter(oDbCommand, "@CreatorId", DbType.Int32, _TransactionPurpose.CreatorId);
				AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _TransactionPurpose.CreateDate);
				AddParameter(oDbCommand, "@TransactionPurposeId", DbType.Int32, _TransactionPurpose.TransactionPurposeId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int TransactionPurposeId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("TransactionPurpose_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@TransactionPurposeId", DbType.Int32, TransactionPurposeId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
