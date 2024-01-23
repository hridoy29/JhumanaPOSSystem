using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class StoreDAO
	{
		public StoreDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Store oStore)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "StoreId":
						oStore.StoreId = Convert.ToInt32(oDbDataReader["StoreId"]);
						break;
					case "StoreName":
						if (oDbDataReader["StoreName"] != DBNull.Value)
							oStore.StoreName = Convert.ToString(oDbDataReader["StoreName"]);
						break;
					case "StoreAddress":
						if (oDbDataReader["StoreAddress"] != DBNull.Value)
							oStore.StoreAddress = Convert.ToString(oDbDataReader["StoreAddress"]);
						break;
					case "PhoneNo":
						if (oDbDataReader["PhoneNo"] != DBNull.Value)
							oStore.PhoneNo = Convert.ToString(oDbDataReader["PhoneNo"]);
						break;
					case "Email":
						if (oDbDataReader["Email"] != DBNull.Value)
							oStore.Email = Convert.ToString(oDbDataReader["Email"]);
						break;
					case "ProjectId":
						oStore.ProjectId = Convert.ToInt32(oDbDataReader["ProjectId"]);
						break;
					case "CompanyId":
						oStore.CompanyId = Convert.ToInt32(oDbDataReader["CompanyId"]);
						break;
					case "Mobile":
						if (oDbDataReader["Mobile"] != DBNull.Value)
							oStore.Mobile = Convert.ToString(oDbDataReader["Mobile"]);
						break;
					case "ContactPerson":
						if (oDbDataReader["ContactPerson"] != DBNull.Value)
							oStore.ContactPerson = Convert.ToString(oDbDataReader["ContactPerson"]);
						break;
					case "StoreCF1":
						if (oDbDataReader["StoreCF1"] != DBNull.Value)
							oStore.StoreCF1 = Convert.ToString(oDbDataReader["StoreCF1"]);
						break;
					case "StoreCF2":
						if (oDbDataReader["StoreCF2"] != DBNull.Value)
							oStore.StoreCF2 = Convert.ToString(oDbDataReader["StoreCF2"]);
						break;
					case "StoreCF3":
						if (oDbDataReader["StoreCF3"] != DBNull.Value)
							oStore.StoreCF3 = Convert.ToString(oDbDataReader["StoreCF3"]);
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

		public List<Store> Store_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Store> lstStore = new List<Store>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Store oStore = new Store();
					BuildEntity(oDbDataReader, oStore);
					lstStore.Add(oStore);
				}
				return lstStore;
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

		public List<Store> Store_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Store> lstStore = new List<Store>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Store oStore = new Store();
					BuildEntity(oDbDataReader, oStore);
					lstStore.Add(oStore);
				}
				return lstStore;
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

		public Store Store_GetById(int StoreId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Store oStore = new Store();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, StoreId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oStore);
				}
				return oStore;
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

		public int Add(Store _Store)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_Create", CommandType.StoredProcedure);
				if (_Store.StoreName != null)
					AddParameter(oDbCommand, "@StoreName", DbType.String, _Store.StoreName);
				else
					AddParameter(oDbCommand, "@StoreName",DbType.String, DBNull.Value);
				if (_Store.StoreAddress != null)
					AddParameter(oDbCommand, "@StoreAddress", DbType.String, _Store.StoreAddress);
				else
					AddParameter(oDbCommand, "@StoreAddress",DbType.String, DBNull.Value);
				if (_Store.PhoneNo != null)
					AddParameter(oDbCommand, "@PhoneNo", DbType.String, _Store.PhoneNo);
				else
					AddParameter(oDbCommand, "@PhoneNo",DbType.String, DBNull.Value);
				if (_Store.Email != null)
					AddParameter(oDbCommand, "@Email", DbType.String, _Store.Email);
				else
					AddParameter(oDbCommand, "@Email",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ProjectId", DbType.Int32, _Store.ProjectId);
				AddParameter(oDbCommand, "@CompanyId", DbType.Int32, _Store.CompanyId);
				if (_Store.Mobile != null)
					AddParameter(oDbCommand, "@Mobile", DbType.String, _Store.Mobile);
				else
					AddParameter(oDbCommand, "@Mobile",DbType.String, DBNull.Value);
				if (_Store.ContactPerson != null)
					AddParameter(oDbCommand, "@ContactPerson", DbType.String, _Store.ContactPerson);
				else
					AddParameter(oDbCommand, "@ContactPerson",DbType.String, DBNull.Value);
				if (_Store.StoreCF1 != null)
					AddParameter(oDbCommand, "@StoreCF1", DbType.String, _Store.StoreCF1);
				else
					AddParameter(oDbCommand, "@StoreCF1",DbType.String, DBNull.Value);
				if (_Store.StoreCF2 != null)
					AddParameter(oDbCommand, "@StoreCF2", DbType.String, _Store.StoreCF2);
				else
					AddParameter(oDbCommand, "@StoreCF2",DbType.String, DBNull.Value);
				if (_Store.StoreCF3 != null)
					AddParameter(oDbCommand, "@StoreCF3", DbType.String, _Store.StoreCF3);
				else
					AddParameter(oDbCommand, "@StoreCF3",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Store _Store)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_Update", CommandType.StoredProcedure);
				if (_Store.StoreName != null)
					AddParameter(oDbCommand, "@StoreName", DbType.String, _Store.StoreName);
				else
					AddParameter(oDbCommand, "@StoreName",DbType.String, DBNull.Value);
				if (_Store.StoreAddress != null)
					AddParameter(oDbCommand, "@StoreAddress", DbType.String, _Store.StoreAddress);
				else
					AddParameter(oDbCommand, "@StoreAddress",DbType.String, DBNull.Value);
				if (_Store.PhoneNo != null)
					AddParameter(oDbCommand, "@PhoneNo", DbType.String, _Store.PhoneNo);
				else
					AddParameter(oDbCommand, "@PhoneNo",DbType.String, DBNull.Value);
				if (_Store.Email != null)
					AddParameter(oDbCommand, "@Email", DbType.String, _Store.Email);
				else
					AddParameter(oDbCommand, "@Email",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@ProjectId", DbType.Int32, _Store.ProjectId);
				AddParameter(oDbCommand, "@CompanyId", DbType.Int32, _Store.CompanyId);
				if (_Store.Mobile != null)
					AddParameter(oDbCommand, "@Mobile", DbType.String, _Store.Mobile);
				else
					AddParameter(oDbCommand, "@Mobile",DbType.String, DBNull.Value);
				if (_Store.ContactPerson != null)
					AddParameter(oDbCommand, "@ContactPerson", DbType.String, _Store.ContactPerson);
				else
					AddParameter(oDbCommand, "@ContactPerson",DbType.String, DBNull.Value);
				if (_Store.StoreCF1 != null)
					AddParameter(oDbCommand, "@StoreCF1", DbType.String, _Store.StoreCF1);
				else
					AddParameter(oDbCommand, "@StoreCF1",DbType.String, DBNull.Value);
				if (_Store.StoreCF2 != null)
					AddParameter(oDbCommand, "@StoreCF2", DbType.String, _Store.StoreCF2);
				else
					AddParameter(oDbCommand, "@StoreCF2",DbType.String, DBNull.Value);
				if (_Store.StoreCF3 != null)
					AddParameter(oDbCommand, "@StoreCF3", DbType.String, _Store.StoreCF3);
				else
					AddParameter(oDbCommand, "@StoreCF3",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Store.StoreId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int StoreId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Store_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, StoreId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
