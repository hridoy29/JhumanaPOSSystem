using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class CustomerDAO
	{
		public CustomerDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, tblCustomer oCustomer)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "customerId":
						oCustomer.customerId = Convert.ToInt32(oDbDataReader["customerId"]);
						break;
					case "Name":
						if (oDbDataReader["Name"] != DBNull.Value)
							oCustomer.Name = Convert.ToString(oDbDataReader["Name"]);
						break;
					case "street_no":
						if (oDbDataReader["street_no"] != DBNull.Value)
							oCustomer.street_no = Convert.ToString(oDbDataReader["street_no"]);
						break;
					case "suburb":
						if (oDbDataReader["suburb"] != DBNull.Value)
							oCustomer.suburb = Convert.ToString(oDbDataReader["suburb"]);
						break;
					case "city":
						if (oDbDataReader["city"] != DBNull.Value)
							oCustomer.city = Convert.ToString(oDbDataReader["city"]);
						break;
					case "state":
						if (oDbDataReader["state"] != DBNull.Value)
							oCustomer.state = Convert.ToString(oDbDataReader["state"]);
						break;
					case "postcode":
						if (oDbDataReader["postcode"] != DBNull.Value)
							oCustomer.postcode = Convert.ToString(oDbDataReader["postcode"]);
						break;
					case "country":
						if (oDbDataReader["country"] != DBNull.Value)
							oCustomer.country = Convert.ToString(oDbDataReader["country"]);
						break;
					case "mobile":
						if (oDbDataReader["mobile"] != DBNull.Value)
							oCustomer.mobile = Convert.ToString(oDbDataReader["mobile"]);
						break;
					case "homephone":
						if (oDbDataReader["homephone"] != DBNull.Value)
							oCustomer.homephone = Convert.ToString(oDbDataReader["homephone"]);
						break;
					case "sex":
						if (oDbDataReader["sex"] != DBNull.Value)
							oCustomer.sex = Convert.ToBoolean(oDbDataReader["sex"]);
						break;
					case "workphone":
						if (oDbDataReader["workphone"] != DBNull.Value)
							oCustomer.workphone = Convert.ToString(oDbDataReader["workphone"]);
						break;
					case "enteredtime":
						if (oDbDataReader["enteredtime"] != DBNull.Value)
							oCustomer.enteredtime = Convert.ToDateTime(oDbDataReader["enteredtime"]);
						break;
					case "enteredby":
						if (oDbDataReader["enteredby"] != DBNull.Value)
							oCustomer.enteredby = Convert.ToInt64(oDbDataReader["enteredby"]);
						break;
					case "updatedtime":
						if (oDbDataReader["updatedtime"] != DBNull.Value)
							oCustomer.updatedtime = Convert.ToDateTime(oDbDataReader["updatedtime"]);
						break;
					case "updatedby":
						if (oDbDataReader["updatedby"] != DBNull.Value)
							oCustomer.updatedby = Convert.ToInt64(oDbDataReader["updatedby"]);
						break;
                    case "DueBalance":
                        if (oDbDataReader["DueBalance"] != DBNull.Value)
                            oCustomer.DueBalance = Convert.ToDouble(oDbDataReader["DueBalance"]);
                        break;
                    case "NameAndNo":
                        if (oDbDataReader["NameAndNo"] != DBNull.Value)
                            oCustomer.NameAndNo = Convert.ToString(oDbDataReader["NameAndNo"]);
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

		public List<tblCustomer> Customer_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<tblCustomer> lstCustomer = new List<tblCustomer>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Customer_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					tblCustomer oCustomer = new tblCustomer();
					BuildEntity(oDbDataReader, oCustomer);
					lstCustomer.Add(oCustomer);
				}
				return lstCustomer;
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

		public List<tblCustomer> Customer_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<tblCustomer> lstCustomer = new List<tblCustomer>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Customer_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					tblCustomer oCustomer = new tblCustomer();
					BuildEntity(oDbDataReader, oCustomer);
					lstCustomer.Add(oCustomer);
				}
				return lstCustomer;
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

		public tblCustomer Customer_GetById(int customerId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				tblCustomer oCustomer = new tblCustomer();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Customer_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@customerId", DbType.Int32, customerId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oCustomer);
				}
				return oCustomer;
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

		public int Add(tblCustomer _Customer)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Customer_Create", CommandType.StoredProcedure);
				if (_Customer.Name != null)
					AddParameter(oDbCommand, "@Name", DbType.String, _Customer.Name);
				else
					AddParameter(oDbCommand, "@Name",DbType.String, DBNull.Value);
				if (_Customer.street_no != null)
					AddParameter(oDbCommand, "@street_no", DbType.String, _Customer.street_no);
				else
					AddParameter(oDbCommand, "@street_no",DbType.String, DBNull.Value);
				if (_Customer.suburb != null)
					AddParameter(oDbCommand, "@suburb", DbType.String, _Customer.suburb);
				else
					AddParameter(oDbCommand, "@suburb",DbType.String, DBNull.Value);
				if (_Customer.city != null)
					AddParameter(oDbCommand, "@city", DbType.String, _Customer.city);
				else
					AddParameter(oDbCommand, "@city",DbType.String, DBNull.Value);
				if (_Customer.state != null)
					AddParameter(oDbCommand, "@state", DbType.String, _Customer.state);
				else
					AddParameter(oDbCommand, "@state",DbType.String, DBNull.Value);
				if (_Customer.postcode != null)
					AddParameter(oDbCommand, "@postcode", DbType.String, _Customer.postcode);
				else
					AddParameter(oDbCommand, "@postcode",DbType.String, DBNull.Value);
				if (_Customer.country != null)
					AddParameter(oDbCommand, "@country", DbType.String, _Customer.country);
				else
					AddParameter(oDbCommand, "@country",DbType.String, DBNull.Value);
				if (_Customer.mobile != null)
					AddParameter(oDbCommand, "@mobile", DbType.String, _Customer.mobile);
				else
					AddParameter(oDbCommand, "@mobile",DbType.String, DBNull.Value);
				if (_Customer.homephone != null)
					AddParameter(oDbCommand, "@homephone", DbType.String, _Customer.homephone);
				else
					AddParameter(oDbCommand, "@homephone",DbType.String, DBNull.Value);
				if (_Customer.sex.HasValue)
					AddParameter(oDbCommand, "@sex", DbType.Boolean, _Customer.sex);
				else
					AddParameter(oDbCommand, "@sex",DbType.Boolean, DBNull.Value);
				if (_Customer.workphone != null)
					AddParameter(oDbCommand, "@workphone", DbType.String, _Customer.workphone);
				else
					AddParameter(oDbCommand, "@workphone",DbType.String, DBNull.Value);
				if (_Customer.enteredtime.HasValue)
					AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _Customer.enteredtime);
				else
					AddParameter(oDbCommand, "@enteredtime",DbType.DateTime, DBNull.Value);
				if (_Customer.enteredby.HasValue)
					AddParameter(oDbCommand, "@enteredby", DbType.Int64, _Customer.enteredby);
				else
                    AddParameter(oDbCommand, "@enteredby", DbType.Int64, DBNull.Value);
				if (_Customer.updatedtime.HasValue)
					AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _Customer.updatedtime);
				else
					AddParameter(oDbCommand, "@updatedtime",DbType.DateTime, DBNull.Value);
				if (_Customer.updatedby.HasValue)
                    AddParameter(oDbCommand, "@updatedby", DbType.Int64, _Customer.updatedby);
				else
                    AddParameter(oDbCommand, "@updatedby", DbType.Int64, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(tblCustomer _Customer)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Customer_Update", CommandType.StoredProcedure);
				if (_Customer.Name != null)
					AddParameter(oDbCommand, "@Name", DbType.String, _Customer.Name);
				else
					AddParameter(oDbCommand, "@Name",DbType.String, DBNull.Value);
				if (_Customer.street_no != null)
					AddParameter(oDbCommand, "@street_no", DbType.String, _Customer.street_no);
				else
					AddParameter(oDbCommand, "@street_no",DbType.String, DBNull.Value);
				if (_Customer.suburb != null)
					AddParameter(oDbCommand, "@suburb", DbType.String, _Customer.suburb);
				else
					AddParameter(oDbCommand, "@suburb",DbType.String, DBNull.Value);
				if (_Customer.city != null)
					AddParameter(oDbCommand, "@city", DbType.String, _Customer.city);
				else
					AddParameter(oDbCommand, "@city",DbType.String, DBNull.Value);
				if (_Customer.state != null)
					AddParameter(oDbCommand, "@state", DbType.String, _Customer.state);
				else
					AddParameter(oDbCommand, "@state",DbType.String, DBNull.Value);
				if (_Customer.postcode != null)
					AddParameter(oDbCommand, "@postcode", DbType.String, _Customer.postcode);
				else
					AddParameter(oDbCommand, "@postcode",DbType.String, DBNull.Value);
				if (_Customer.country != null)
					AddParameter(oDbCommand, "@country", DbType.String, _Customer.country);
				else
					AddParameter(oDbCommand, "@country",DbType.String, DBNull.Value);
				if (_Customer.mobile != null)
					AddParameter(oDbCommand, "@mobile", DbType.String, _Customer.mobile);
				else
					AddParameter(oDbCommand, "@mobile",DbType.String, DBNull.Value);
				if (_Customer.homephone != null)
					AddParameter(oDbCommand, "@homephone", DbType.String, _Customer.homephone);
				else
					AddParameter(oDbCommand, "@homephone",DbType.String, DBNull.Value);
				if (_Customer.sex.HasValue)
					AddParameter(oDbCommand, "@sex", DbType.Boolean, _Customer.sex);
				else
					AddParameter(oDbCommand, "@sex",DbType.Boolean, DBNull.Value);
				if (_Customer.workphone != null)
					AddParameter(oDbCommand, "@workphone", DbType.String, _Customer.workphone);
				else
					AddParameter(oDbCommand, "@workphone",DbType.String, DBNull.Value);
				if (_Customer.enteredtime.HasValue)
					AddParameter(oDbCommand, "@enteredtime", DbType.DateTime, _Customer.enteredtime);
				else
					AddParameter(oDbCommand, "@enteredtime",DbType.DateTime, DBNull.Value);
				if (_Customer.enteredby.HasValue)
                    AddParameter(oDbCommand, "@enteredby", DbType.Int64, _Customer.enteredby);
				else
                    AddParameter(oDbCommand, "@enteredby", DbType.Int64, DBNull.Value);
				if (_Customer.updatedtime.HasValue)
					AddParameter(oDbCommand, "@updatedtime", DbType.DateTime, _Customer.updatedtime);
				else
					AddParameter(oDbCommand, "@updatedtime",DbType.DateTime, DBNull.Value);
				if (_Customer.updatedby.HasValue)
                    AddParameter(oDbCommand, "@updatedby", DbType.Int64, _Customer.updatedby);
				else
					AddParameter(oDbCommand, "@updatedby",DbType.Int64, DBNull.Value);
				AddParameter(oDbCommand, "@customerId", DbType.Int32, _Customer.customerId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int customerId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Customer_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@customerId", DbType.Int32, customerId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
