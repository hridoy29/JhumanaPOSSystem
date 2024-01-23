using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class UnitMeasureDAO
	{
		public UnitMeasureDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, UnitMeasure oUnitMeasure)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "unitMeasureId":
						oUnitMeasure.unitMeasureId = Convert.ToInt32(oDbDataReader["unitMeasureId"]);
						break;
					case "UnitMeasureName":
						oUnitMeasure.UnitMeasureName = Convert.ToString(oDbDataReader["UnitMeasureName"]);
						break;
					case "UnitSymbol":
						if (oDbDataReader["UnitSymbol"] != DBNull.Value)
							oUnitMeasure.UnitSymbol = Convert.ToString(oDbDataReader["UnitSymbol"]);
						break;
					case "enteredtime":
						if (oDbDataReader["enteredtime"] != DBNull.Value)
							oUnitMeasure.enteredtime = Convert.ToDateTime(oDbDataReader["enteredtime"]);
						break;
					case "enteredby":
						if (oDbDataReader["enteredby"] != DBNull.Value)
							oUnitMeasure.enteredby = Convert.ToString(oDbDataReader["enteredby"]);
						break;
					case "updatedtime":
						if (oDbDataReader["updatedtime"] != DBNull.Value)
							oUnitMeasure.updatedtime = Convert.ToDateTime(oDbDataReader["updatedtime"]);
						break;
					case "updatedby":
						if (oDbDataReader["updatedby"] != DBNull.Value)
							oUnitMeasure.updatedby = Convert.ToString(oDbDataReader["updatedby"]);
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

		public List<UnitMeasure> UnitMeasure_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<UnitMeasure> lstUnitMeasure = new List<UnitMeasure>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UnitMeasure_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					UnitMeasure oUnitMeasure = new UnitMeasure();
					BuildEntity(oDbDataReader, oUnitMeasure);
					lstUnitMeasure.Add(oUnitMeasure);
				}
				return lstUnitMeasure;
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

		public List<UnitMeasure> UnitMeasure_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<UnitMeasure> lstUnitMeasure = new List<UnitMeasure>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UnitMeasure_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					UnitMeasure oUnitMeasure = new UnitMeasure();
					BuildEntity(oDbDataReader, oUnitMeasure);
					lstUnitMeasure.Add(oUnitMeasure);
				}
				return lstUnitMeasure;
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

		public UnitMeasure UnitMeasure_GetById(int unitMeasureId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				UnitMeasure oUnitMeasure = new UnitMeasure();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UnitMeasure_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@unitMeasureId", DbType.Int32, unitMeasureId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oUnitMeasure);
				}
				return oUnitMeasure;
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

		public int Add(UnitMeasure _UnitMeasure)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UnitMeasure_Create", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@UnitMeasureName", DbType.String, _UnitMeasure.UnitMeasureName);
				if (_UnitMeasure.UnitSymbol != null)
					AddParameter(oDbCommand, "@UnitSymbol", DbType.String, _UnitMeasure.UnitSymbol);
				else
					AddParameter(oDbCommand, "@UnitSymbol",DbType.String, DBNull.Value);
				if (_UnitMeasure.enteredtime.HasValue)
					AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _UnitMeasure.enteredtime);
				else
					AddParameter(oDbCommand, "@enteredtime",DbType.DateTime, DBNull.Value);
				if (_UnitMeasure.enteredby != null)
					AddParameter(oDbCommand, "@enteredby", DbType.String, _UnitMeasure.enteredby);
				else
					AddParameter(oDbCommand, "@enteredby",DbType.String, DBNull.Value);
				if (_UnitMeasure.updatedtime.HasValue)
					AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _UnitMeasure.updatedtime);
				else
					AddParameter(oDbCommand, "@updatedtime",DbType.DateTime, DBNull.Value);
				if (_UnitMeasure.updatedby != null)
					AddParameter(oDbCommand, "@updatedby", DbType.String, _UnitMeasure.updatedby);
				else
					AddParameter(oDbCommand, "@updatedby",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(UnitMeasure _UnitMeasure)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UnitMeasure_Update", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@UnitMeasureName", DbType.String, _UnitMeasure.UnitMeasureName);
				if (_UnitMeasure.UnitSymbol != null)
					AddParameter(oDbCommand, "@UnitSymbol", DbType.String, _UnitMeasure.UnitSymbol);
				else
					AddParameter(oDbCommand, "@UnitSymbol",DbType.String, DBNull.Value);
				if (_UnitMeasure.enteredtime.HasValue)
					AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _UnitMeasure.enteredtime);
				else
					AddParameter(oDbCommand, "@enteredtime",DbType.DateTime, DBNull.Value);
				if (_UnitMeasure.enteredby != null)
					AddParameter(oDbCommand, "@enteredby", DbType.String, _UnitMeasure.enteredby);
				else
					AddParameter(oDbCommand, "@enteredby",DbType.String, DBNull.Value);
				if (_UnitMeasure.updatedtime.HasValue)
					AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _UnitMeasure.updatedtime);
				else
					AddParameter(oDbCommand, "@updatedtime",DbType.DateTime, DBNull.Value);
				if (_UnitMeasure.updatedby != null)
					AddParameter(oDbCommand, "@updatedby", DbType.String, _UnitMeasure.updatedby);
				else
					AddParameter(oDbCommand, "@updatedby",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@unitMeasureId", DbType.Int32, _UnitMeasure.unitMeasureId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int unitMeasureId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UnitMeasure_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@unitMeasureId", DbType.Int32, unitMeasureId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
                MessageBox.Show("This Unit of Measurement could not be removed.", "LPOS");
                return -1;
            }
		}
	}
}
