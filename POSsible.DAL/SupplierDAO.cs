using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class SupplierDAO
	{
		public SupplierDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Supplier oSupplier)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "SupplierId":
						oSupplier.SupplierId = Convert.ToInt32(oDbDataReader["SupplierId"]);
						break;
					case "SupplierName":
						if (oDbDataReader["SupplierName"] != DBNull.Value)
							oSupplier.SupplierName = Convert.ToString(oDbDataReader["SupplierName"]);
						break;
					case "TradingAs":
						if (oDbDataReader["TradingAs"] != DBNull.Value)
							oSupplier.TradingAs = Convert.ToString(oDbDataReader["TradingAs"]);
						break;
					case "ABN":
						if (oDbDataReader["ABN"] != DBNull.Value)
							oSupplier.ABN = Convert.ToString(oDbDataReader["ABN"]);
						break;
					case "SupplierAddress":
						if (oDbDataReader["SupplierAddress"] != DBNull.Value)
							oSupplier.SupplierAddress = Convert.ToString(oDbDataReader["SupplierAddress"]);
						break;
					case "ContactName":
						if (oDbDataReader["ContactName"] != DBNull.Value)
							oSupplier.ContactName = Convert.ToString(oDbDataReader["ContactName"]);
						break;
					case "PhoneNo":
						if (oDbDataReader["PhoneNo"] != DBNull.Value)
							oSupplier.PhoneNo = Convert.ToString(oDbDataReader["PhoneNo"]);
						break;
					case "email":
						if (oDbDataReader["email"] != DBNull.Value)
							oSupplier.email = Convert.ToString(oDbDataReader["email"]);
						break;
					case "webadd":
						if (oDbDataReader["webadd"] != DBNull.Value)
							oSupplier.webadd = Convert.ToString(oDbDataReader["webadd"]);
						break;
					case "comments":
						if (oDbDataReader["comments"] != DBNull.Value)
							oSupplier.comments = Convert.ToString(oDbDataReader["comments"]);
						break;
					case "Fax":
						if (oDbDataReader["Fax"] != DBNull.Value)
							oSupplier.Fax = Convert.ToString(oDbDataReader["Fax"]);
						break;
					case "CivilId":
						if (oDbDataReader["CivilId"] != DBNull.Value)
							oSupplier.CivilId = Convert.ToString(oDbDataReader["CivilId"]);
						break;
					case "GLCode":
						if (oDbDataReader["GLCode"] != DBNull.Value)
							oSupplier.GLCode = Convert.ToString(oDbDataReader["GLCode"]);
						break;
					case "EnteredBy":
						if (oDbDataReader["EnteredBy"] != DBNull.Value)
							oSupplier.EnteredBy = Convert.ToInt32(oDbDataReader["EnteredBy"]);
						break;
					case "EnteredTime":
						if (oDbDataReader["EnteredTime"] != DBNull.Value)
							oSupplier.EnteredTime = Convert.ToDateTime(oDbDataReader["EnteredTime"]);
						break;
					case "UpdatedBy":
						if (oDbDataReader["UpdatedBy"] != DBNull.Value)
							oSupplier.UpdatedBy = Convert.ToInt32(oDbDataReader["UpdatedBy"]);
						break;
					case "UpdatedTime":
						if (oDbDataReader["UpdatedTime"] != DBNull.Value)
							oSupplier.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
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

		public List<Supplier> Supplier_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Supplier> lstSupplier = new List<Supplier>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Supplier_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Supplier oSupplier = new Supplier();
					BuildEntity(oDbDataReader, oSupplier);
					lstSupplier.Add(oSupplier);
				}
				return lstSupplier;
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

		public List<Supplier> Supplier_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Supplier> lstSupplier = new List<Supplier>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Supplier_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Supplier oSupplier = new Supplier();
					BuildEntity(oDbDataReader, oSupplier);
					lstSupplier.Add(oSupplier);
				}
				return lstSupplier;
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

		public Supplier Supplier_GetById(int SupplierId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Supplier oSupplier = new Supplier();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Supplier_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@SupplierId", DbType.Int32, SupplierId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oSupplier);
				}
				return oSupplier;
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

		public int Add(Supplier _Supplier)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Supplier_Create", CommandType.StoredProcedure);
				if (_Supplier.SupplierName != null)
					AddParameter(oDbCommand, "@SupplierName", DbType.String, _Supplier.SupplierName);
				else
					AddParameter(oDbCommand, "@SupplierName",DbType.String, DBNull.Value);
				if (_Supplier.TradingAs != null)
					AddParameter(oDbCommand, "@TradingAs", DbType.String, _Supplier.TradingAs);
				else
					AddParameter(oDbCommand, "@TradingAs",DbType.String, DBNull.Value);
				if (_Supplier.ABN != null)
					AddParameter(oDbCommand, "@ABN", DbType.String, _Supplier.ABN);
				else
					AddParameter(oDbCommand, "@ABN",DbType.String, DBNull.Value);
				if (_Supplier.SupplierAddress != null)
					AddParameter(oDbCommand, "@SupplierAddress", DbType.String, _Supplier.SupplierAddress);
				else
					AddParameter(oDbCommand, "@SupplierAddress",DbType.String, DBNull.Value);
				if (_Supplier.ContactName != null)
					AddParameter(oDbCommand, "@ContactName", DbType.String, _Supplier.ContactName);
				else
					AddParameter(oDbCommand, "@ContactName",DbType.String, DBNull.Value);
				if (_Supplier.PhoneNo != null)
					AddParameter(oDbCommand, "@PhoneNo", DbType.String, _Supplier.PhoneNo);
				else
					AddParameter(oDbCommand, "@PhoneNo",DbType.String, DBNull.Value);
				if (_Supplier.email != null)
					AddParameter(oDbCommand, "@email", DbType.String, _Supplier.email);
				else
					AddParameter(oDbCommand, "@email",DbType.String, DBNull.Value);
				if (_Supplier.webadd != null)
					AddParameter(oDbCommand, "@webadd", DbType.String, _Supplier.webadd);
				else
					AddParameter(oDbCommand, "@webadd",DbType.String, DBNull.Value);
				if (_Supplier.comments != null)
					AddParameter(oDbCommand, "@comments", DbType.String, _Supplier.comments);
				else
					AddParameter(oDbCommand, "@comments",DbType.String, DBNull.Value);
				if (_Supplier.Fax != null)
					AddParameter(oDbCommand, "@Fax", DbType.String, _Supplier.Fax);
				else
					AddParameter(oDbCommand, "@Fax",DbType.String, DBNull.Value);
				if (_Supplier.CivilId != null)
					AddParameter(oDbCommand, "@CivilId", DbType.String, _Supplier.CivilId);
				else
					AddParameter(oDbCommand, "@CivilId",DbType.String, DBNull.Value);
				if (_Supplier.GLCode != null)
					AddParameter(oDbCommand, "@GLCode", DbType.String, _Supplier.GLCode);
				else
					AddParameter(oDbCommand, "@GLCode",DbType.String, DBNull.Value);
				if (_Supplier.EnteredBy.HasValue)
					AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _Supplier.EnteredBy);
				else
					AddParameter(oDbCommand, "@EnteredBy",DbType.Int32, DBNull.Value);
				if (_Supplier.EnteredTime.HasValue)
					AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Supplier.EnteredTime);
				else
					AddParameter(oDbCommand, "@EnteredTime",DbType.DateTime, DBNull.Value);
				if (_Supplier.UpdatedBy.HasValue)
					AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _Supplier.UpdatedBy);
				else
					AddParameter(oDbCommand, "@UpdatedBy",DbType.Int32, DBNull.Value);
				if (_Supplier.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Supplier.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Supplier _Supplier)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Supplier_Update", CommandType.StoredProcedure);
				if (_Supplier.SupplierName != null)
					AddParameter(oDbCommand, "@SupplierName", DbType.String, _Supplier.SupplierName);
				else
					AddParameter(oDbCommand, "@SupplierName",DbType.String, DBNull.Value);
				if (_Supplier.TradingAs != null)
					AddParameter(oDbCommand, "@TradingAs", DbType.String, _Supplier.TradingAs);
				else
					AddParameter(oDbCommand, "@TradingAs",DbType.String, DBNull.Value);
				if (_Supplier.ABN != null)
					AddParameter(oDbCommand, "@ABN", DbType.String, _Supplier.ABN);
				else
					AddParameter(oDbCommand, "@ABN",DbType.String, DBNull.Value);
				if (_Supplier.SupplierAddress != null)
					AddParameter(oDbCommand, "@SupplierAddress", DbType.String, _Supplier.SupplierAddress);
				else
					AddParameter(oDbCommand, "@SupplierAddress",DbType.String, DBNull.Value);
				if (_Supplier.ContactName != null)
					AddParameter(oDbCommand, "@ContactName", DbType.String, _Supplier.ContactName);
				else
					AddParameter(oDbCommand, "@ContactName",DbType.String, DBNull.Value);
				if (_Supplier.PhoneNo != null)
					AddParameter(oDbCommand, "@PhoneNo", DbType.String, _Supplier.PhoneNo);
				else
					AddParameter(oDbCommand, "@PhoneNo",DbType.String, DBNull.Value);
				if (_Supplier.email != null)
					AddParameter(oDbCommand, "@email", DbType.String, _Supplier.email);
				else
					AddParameter(oDbCommand, "@email",DbType.String, DBNull.Value);
				if (_Supplier.webadd != null)
					AddParameter(oDbCommand, "@webadd", DbType.String, _Supplier.webadd);
				else
					AddParameter(oDbCommand, "@webadd",DbType.String, DBNull.Value);
				if (_Supplier.comments != null)
					AddParameter(oDbCommand, "@comments", DbType.String, _Supplier.comments);
				else
					AddParameter(oDbCommand, "@comments",DbType.String, DBNull.Value);
				if (_Supplier.Fax != null)
					AddParameter(oDbCommand, "@Fax", DbType.String, _Supplier.Fax);
				else
					AddParameter(oDbCommand, "@Fax",DbType.String, DBNull.Value);
				if (_Supplier.CivilId != null)
					AddParameter(oDbCommand, "@CivilId", DbType.String, _Supplier.CivilId);
				else
					AddParameter(oDbCommand, "@CivilId",DbType.String, DBNull.Value);
				if (_Supplier.GLCode != null)
					AddParameter(oDbCommand, "@GLCode", DbType.String, _Supplier.GLCode);
				else
					AddParameter(oDbCommand, "@GLCode",DbType.String, DBNull.Value);
				if (_Supplier.EnteredBy.HasValue)
					AddParameter(oDbCommand, "@EnteredBy", DbType.Int32, _Supplier.EnteredBy);
				else
					AddParameter(oDbCommand, "@EnteredBy",DbType.Int32, DBNull.Value);
				if (_Supplier.EnteredTime.HasValue)
					AddParameter(oDbCommand, "@EnteredTime", DbType.DateTime, _Supplier.EnteredTime);
				else
					AddParameter(oDbCommand, "@EnteredTime",DbType.DateTime, DBNull.Value);
				if (_Supplier.UpdatedBy.HasValue)
					AddParameter(oDbCommand, "@UpdatedBy", DbType.Int32, _Supplier.UpdatedBy);
				else
					AddParameter(oDbCommand, "@UpdatedBy",DbType.Int32, DBNull.Value);
				if (_Supplier.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Supplier.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);
				AddParameter(oDbCommand, "@SupplierId", DbType.Int32, _Supplier.SupplierId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int SupplierId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Supplier_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@SupplierId", DbType.Int32, SupplierId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
                System.Windows.Forms.MessageBox.Show("This Supplier could not be removed.", "LPOS");
                return -1;
			}
		}
	}
}
