using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class InvoiceDAO
	{
		public InvoiceDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Invoice oInvoice)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "invoiceId":
						oInvoice.invoiceId = Convert.ToInt32(oDbDataReader["invoiceId"]);
						break;
					case "InvoiceNo":
						if (oDbDataReader["InvoiceNo"] != DBNull.Value)
							oInvoice.InvoiceNo = Convert.ToString(oDbDataReader["InvoiceNo"]);
						break;
					case "shiftId":
						if (oDbDataReader["shiftId"] != DBNull.Value)
							oInvoice.shiftId = Convert.ToInt32(oDbDataReader["shiftId"]);
						break;
					case "userId":
						oInvoice.userId = Convert.ToInt32(oDbDataReader["userId"]);
						break;
					case "customerId":
						if (oDbDataReader["customerId"] != DBNull.Value)
							oInvoice.customerId = Convert.ToInt32(oDbDataReader["customerId"]);
						break;
					case "StoreId":
						oInvoice.StoreId = Convert.ToInt32(oDbDataReader["StoreId"]);
						break;
					case "invoiceDate":
						if (oDbDataReader["invoiceDate"] != DBNull.Value)
							oInvoice.invoiceDate = Convert.ToDateTime(oDbDataReader["invoiceDate"]);
						break;
					case "SaleType":
						if (oDbDataReader["SaleType"] != DBNull.Value)
							oInvoice.SaleType = Convert.ToString(oDbDataReader["SaleType"]);
						break;
					case "TotalPrice":
						if (oDbDataReader["TotalPrice"] != DBNull.Value)
							oInvoice.TotalPrice = Convert.ToDouble(oDbDataReader["TotalPrice"]);
						break;
					case "TotalGST":
						if (oDbDataReader["TotalGST"] != DBNull.Value)
							oInvoice.TotalGST = Convert.ToDouble(oDbDataReader["TotalGST"]);
						break;
					case "CashAmt":
						if (oDbDataReader["CashAmt"] != DBNull.Value)
							oInvoice.CashAmt = Convert.ToDouble(oDbDataReader["CashAmt"]);
						break;
					case "CardAmt":
						if (oDbDataReader["CardAmt"] != DBNull.Value)
							oInvoice.CardAmt = Convert.ToDouble(oDbDataReader["CardAmt"]);
						break;
					case "changeGiven":
						if (oDbDataReader["changeGiven"] != DBNull.Value)
							oInvoice.changeGiven = Convert.ToDouble(oDbDataReader["changeGiven"]);
						break;
					case "DiscountGiven":
						if (oDbDataReader["DiscountGiven"] != DBNull.Value)
							oInvoice.DiscountGiven = Convert.ToString(oDbDataReader["DiscountGiven"]);
						break;
					case "DiscountAthorizedId":
						if (oDbDataReader["DiscountAthorizedId"] != DBNull.Value)
							oInvoice.DiscountAthorizedId = Convert.ToInt32(oDbDataReader["DiscountAthorizedId"]);
						break;
					case "description":
						if (oDbDataReader["description"] != DBNull.Value)
							oInvoice.description = Convert.ToString(oDbDataReader["description"]);
						break;
					case "status":
						if (oDbDataReader["status"] != DBNull.Value)
							oInvoice.status = Convert.ToString(oDbDataReader["status"]);
						break;
					case "updatedTime":
						if (oDbDataReader["updatedTime"] != DBNull.Value)
							oInvoice.updatedTime = Convert.ToDateTime(oDbDataReader["updatedTime"]);
						break;
					case "updatedBy":
						if (oDbDataReader["updatedBy"] != DBNull.Value)
							oInvoice.updatedBy = Convert.ToInt32(oDbDataReader["updatedBy"]);
						break;
					case "CardType":
						if (oDbDataReader["CardType"] != DBNull.Value)
							oInvoice.CardType = Convert.ToString(oDbDataReader["CardType"]);
						break;
					case "CardNo":
						if (oDbDataReader["CardNo"] != DBNull.Value)
							oInvoice.CardNo = Convert.ToString(oDbDataReader["CardNo"]);
						break;
					case "CardHolderName":
						if (oDbDataReader["CardHolderName"] != DBNull.Value)
							oInvoice.CardHolderName = Convert.ToString(oDbDataReader["CardHolderName"]);
						break;
                    case "CustomerName":
                        if (oDbDataReader["CustomerName"] != DBNull.Value)
                            oInvoice.CustomerName = Convert.ToString(oDbDataReader["CustomerName"]);
                        break;
					case "CusPrevBalance":
						if (oDbDataReader["CusPrevBalance"] != DBNull.Value)
							oInvoice.CusPrevBalance = Convert.ToDouble(oDbDataReader["CusPrevBalance"]);
						break;
					case "CF1":
						if (oDbDataReader["CF1"] != DBNull.Value)
							oInvoice.CF1 = Convert.ToString(oDbDataReader["CF1"]);
						break;
					case "CF2":
						if (oDbDataReader["CF2"] != DBNull.Value)
							oInvoice.CF2 = Convert.ToString(oDbDataReader["CF2"]);
						break;
					case "CF3":
						if (oDbDataReader["CF3"] != DBNull.Value)
							oInvoice.CF3 = Convert.ToString(oDbDataReader["CF3"]);
						break;
					case "CF4":
						if (oDbDataReader["CF4"] != DBNull.Value)
							oInvoice.CF4 = Convert.ToString(oDbDataReader["CF4"]);
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

		public List<Invoice> Invoice_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Invoice> lstInvoice = new List<Invoice>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Invoice oInvoice = new Invoice();
					BuildEntity(oDbDataReader, oInvoice);
					lstInvoice.Add(oInvoice);
				}
				return lstInvoice;
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

		public List<Invoice> Invoice_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Invoice> lstInvoice = new List<Invoice>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Invoice oInvoice = new Invoice();
					BuildEntity(oDbDataReader, oInvoice);
					lstInvoice.Add(oInvoice);
				}
				return lstInvoice;
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

        public List<Invoice> Fattura_GetForSync()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Invoice> lstInvoice = new List<Invoice>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Fattura_GetForSync", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Invoice oInvoice = new Invoice();
                    BuildEntity(oDbDataReader, oInvoice);
                    lstInvoice.Add(oInvoice);
                }
                return lstInvoice;
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

		public Invoice Invoice_GetById(int invoiceId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Invoice oInvoice = new Invoice();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@invoiceId", DbType.Int32, invoiceId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oInvoice);
				}
				return oInvoice;
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

		public int Add(Invoice _Invoice)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_Create", CommandType.StoredProcedure);
				if (_Invoice.InvoiceNo != null)
					AddParameter(oDbCommand, "@InvoiceNo", DbType.String, _Invoice.InvoiceNo);
				else
					AddParameter(oDbCommand, "@InvoiceNo",DbType.String, DBNull.Value);
				if (_Invoice.shiftId.HasValue)
					AddParameter(oDbCommand, "@shiftId", DbType.Int32, _Invoice.shiftId);
				else
					AddParameter(oDbCommand, "@shiftId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@userId", DbType.Int32, _Invoice.userId);
				if (_Invoice.customerId.HasValue)
					AddParameter(oDbCommand, "@customerId", DbType.Int32, _Invoice.customerId);
				else
					AddParameter(oDbCommand, "@customerId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Invoice.StoreId);
				if (_Invoice.invoiceDate.HasValue)
					AddParameter(oDbCommand, "@invoiceDate", DbType.DateTime, _Invoice.invoiceDate);
				else
					AddParameter(oDbCommand, "@invoiceDate",DbType.DateTime, DBNull.Value);
				if (_Invoice.SaleType != null)
					AddParameter(oDbCommand, "@SaleType", DbType.String, _Invoice.SaleType);
				else
					AddParameter(oDbCommand, "@SaleType",DbType.String, DBNull.Value);
				if (_Invoice.TotalPrice.HasValue)
					AddParameter(oDbCommand, "@TotalPrice", DbType.Double, _Invoice.TotalPrice);
				else
					AddParameter(oDbCommand, "@TotalPrice",DbType.Double, DBNull.Value);
				if (_Invoice.TotalGST.HasValue)
					AddParameter(oDbCommand, "@TotalGST", DbType.Double, _Invoice.TotalGST);
				else
					AddParameter(oDbCommand, "@TotalGST",DbType.Double, DBNull.Value);
				if (_Invoice.CashAmt.HasValue)
					AddParameter(oDbCommand, "@CashAmt", DbType.Double, _Invoice.CashAmt);
				else
					AddParameter(oDbCommand, "@CashAmt",DbType.Double, DBNull.Value);
				if (_Invoice.CardAmt.HasValue)
					AddParameter(oDbCommand, "@CardAmt", DbType.Double, _Invoice.CardAmt);
				else
					AddParameter(oDbCommand, "@CardAmt",DbType.Double, DBNull.Value);
				if (_Invoice.changeGiven.HasValue)
					AddParameter(oDbCommand, "@changeGiven", DbType.Double, _Invoice.changeGiven);
				else
					AddParameter(oDbCommand, "@changeGiven",DbType.Double, DBNull.Value);
				if (_Invoice.DiscountGiven != null)
					AddParameter(oDbCommand, "@DiscountGiven", DbType.String, _Invoice.DiscountGiven);
				else
					AddParameter(oDbCommand, "@DiscountGiven",DbType.String, DBNull.Value);
				if (_Invoice.DiscountAthorizedId.HasValue)
					AddParameter(oDbCommand, "@DiscountAthorizedId", DbType.Int32, _Invoice.DiscountAthorizedId);
				else
					AddParameter(oDbCommand, "@DiscountAthorizedId",DbType.Int32, DBNull.Value);
				if (_Invoice.description != null)
					AddParameter(oDbCommand, "@description", DbType.String, _Invoice.description);
				else
					AddParameter(oDbCommand, "@description",DbType.String, DBNull.Value);
				if (_Invoice.status != null)
					AddParameter(oDbCommand, "@status", DbType.String, _Invoice.status);
				else
					AddParameter(oDbCommand, "@status",DbType.String, DBNull.Value);
				if (_Invoice.updatedTime.HasValue)
					AddParameter(oDbCommand, "@updatedTime", DbType.DateTime, _Invoice.updatedTime);
				else
					AddParameter(oDbCommand, "@updatedTime",DbType.DateTime, DBNull.Value);
				if (_Invoice.updatedBy.HasValue)
					AddParameter(oDbCommand, "@updatedBy", DbType.Int32, _Invoice.updatedBy);
				else
					AddParameter(oDbCommand, "@updatedBy",DbType.Int32, DBNull.Value);
				if (_Invoice.CardType != null)
					AddParameter(oDbCommand, "@CardType", DbType.String, _Invoice.CardType);
				else
					AddParameter(oDbCommand, "@CardType",DbType.String, DBNull.Value);
				if (_Invoice.CardNo != null)
					AddParameter(oDbCommand, "@CardNo", DbType.String, _Invoice.CardNo);
				else
					AddParameter(oDbCommand, "@CardNo",DbType.String, DBNull.Value);
				if (_Invoice.CardHolderName != null)
					AddParameter(oDbCommand, "@CardHolderName", DbType.String, _Invoice.CardHolderName);
				else
					AddParameter(oDbCommand, "@CardHolderName",DbType.String, DBNull.Value);
				if (_Invoice.CusPrevBalance.HasValue)
					AddParameter(oDbCommand, "@CusPrevBalance", DbType.Double, _Invoice.CusPrevBalance);
				else
					AddParameter(oDbCommand, "@CusPrevBalance",DbType.Double, DBNull.Value);
				if (_Invoice.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _Invoice.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_Invoice.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _Invoice.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_Invoice.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _Invoice.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				if (_Invoice.CF4 != null)
					AddParameter(oDbCommand, "@CF4", DbType.String, _Invoice.CF4);
				else
					AddParameter(oDbCommand, "@CF4",DbType.String, DBNull.Value);

                //AddParameter(oDbCommand, "@CustomerName", DbType.String, _Invoice.CustomerName);
                //AddParameter(oDbCommand, "@SaleAcLgId", DbType.Int32, _Invoice.SaleAcLgId);
                //AddParameter(oDbCommand, "@CusAcLgId", DbType.Int32, _Invoice.CusAcLgId);
                //AddParameter(oDbCommand, "@CIHAcLgId", DbType.Int32, _Invoice.CIHAcLgId);
                //AddParameter(oDbCommand, "@BankAcLgId", DbType.Int32, _Invoice.BankAcLgId);
                //AddParameter(oDbCommand, "@ProjectId", DbType.String, _Invoice.ProjectId);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Invoice _Invoice)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_Update", CommandType.StoredProcedure);
				if (_Invoice.InvoiceNo != null)
					AddParameter(oDbCommand, "@InvoiceNo", DbType.String, _Invoice.InvoiceNo);
				else
					AddParameter(oDbCommand, "@InvoiceNo",DbType.String, DBNull.Value);
				if (_Invoice.shiftId.HasValue)
					AddParameter(oDbCommand, "@shiftId", DbType.Int32, _Invoice.shiftId);
				else
					AddParameter(oDbCommand, "@shiftId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@userId", DbType.Int32, _Invoice.userId);
				if (_Invoice.customerId.HasValue)
					AddParameter(oDbCommand, "@customerId", DbType.Int32, _Invoice.customerId);
				else
					AddParameter(oDbCommand, "@customerId",DbType.Int32, DBNull.Value);
				AddParameter(oDbCommand, "@StoreId", DbType.Int32, _Invoice.StoreId);
				if (_Invoice.invoiceDate.HasValue)
					AddParameter(oDbCommand, "@invoiceDate", DbType.DateTime, _Invoice.invoiceDate);
				else
					AddParameter(oDbCommand, "@invoiceDate",DbType.DateTime, DBNull.Value);
				if (_Invoice.SaleType != null)
					AddParameter(oDbCommand, "@SaleType", DbType.String, _Invoice.SaleType);
				else
					AddParameter(oDbCommand, "@SaleType",DbType.String, DBNull.Value);
				if (_Invoice.TotalPrice.HasValue)
					AddParameter(oDbCommand, "@TotalPrice", DbType.Double, _Invoice.TotalPrice);
				else
					AddParameter(oDbCommand, "@TotalPrice",DbType.Double, DBNull.Value);
				if (_Invoice.TotalGST.HasValue)
					AddParameter(oDbCommand, "@TotalGST", DbType.Double, _Invoice.TotalGST);
				else
					AddParameter(oDbCommand, "@TotalGST",DbType.Double, DBNull.Value);
				if (_Invoice.CashAmt.HasValue)
					AddParameter(oDbCommand, "@CashAmt", DbType.Double, _Invoice.CashAmt);
				else
					AddParameter(oDbCommand, "@CashAmt",DbType.Double, DBNull.Value);
				if (_Invoice.CardAmt.HasValue)
					AddParameter(oDbCommand, "@CardAmt", DbType.Double, _Invoice.CardAmt);
				else
					AddParameter(oDbCommand, "@CardAmt",DbType.Double, DBNull.Value);
				if (_Invoice.changeGiven.HasValue)
					AddParameter(oDbCommand, "@changeGiven", DbType.Double, _Invoice.changeGiven);
				else
					AddParameter(oDbCommand, "@changeGiven",DbType.Double, DBNull.Value);
				if (_Invoice.DiscountGiven != null)
					AddParameter(oDbCommand, "@DiscountGiven", DbType.String, _Invoice.DiscountGiven);
				else
					AddParameter(oDbCommand, "@DiscountGiven",DbType.String, DBNull.Value);
				if (_Invoice.DiscountAthorizedId.HasValue)
					AddParameter(oDbCommand, "@DiscountAthorizedId", DbType.Int32, _Invoice.DiscountAthorizedId);
				else
					AddParameter(oDbCommand, "@DiscountAthorizedId",DbType.Int32, DBNull.Value);
				if (_Invoice.description != null)
					AddParameter(oDbCommand, "@description", DbType.String, _Invoice.description);
				else
					AddParameter(oDbCommand, "@description",DbType.String, DBNull.Value);
				if (_Invoice.status != null)
					AddParameter(oDbCommand, "@status", DbType.String, _Invoice.status);
				else
					AddParameter(oDbCommand, "@status",DbType.String, DBNull.Value);
				if (_Invoice.updatedTime.HasValue)
					AddParameter(oDbCommand, "@updatedTime", DbType.DateTime, _Invoice.updatedTime);
				else
					AddParameter(oDbCommand, "@updatedTime",DbType.DateTime, DBNull.Value);
				if (_Invoice.updatedBy.HasValue)
					AddParameter(oDbCommand, "@updatedBy", DbType.Int32, _Invoice.updatedBy);
				else
					AddParameter(oDbCommand, "@updatedBy",DbType.Int32, DBNull.Value);
				if (_Invoice.CardType != null)
					AddParameter(oDbCommand, "@CardType", DbType.String, _Invoice.CardType);
				else
					AddParameter(oDbCommand, "@CardType",DbType.String, DBNull.Value);
				if (_Invoice.CardNo != null)
					AddParameter(oDbCommand, "@CardNo", DbType.String, _Invoice.CardNo);
				else
					AddParameter(oDbCommand, "@CardNo",DbType.String, DBNull.Value);
				if (_Invoice.CardHolderName != null)
					AddParameter(oDbCommand, "@CardHolderName", DbType.String, _Invoice.CardHolderName);
				else
					AddParameter(oDbCommand, "@CardHolderName",DbType.String, DBNull.Value);
				if (_Invoice.CusPrevBalance.HasValue)
					AddParameter(oDbCommand, "@CusPrevBalance", DbType.Double, _Invoice.CusPrevBalance);
				else
					AddParameter(oDbCommand, "@CusPrevBalance",DbType.Double, DBNull.Value);
				if (_Invoice.CF1 != null)
					AddParameter(oDbCommand, "@CF1", DbType.String, _Invoice.CF1);
				else
					AddParameter(oDbCommand, "@CF1",DbType.String, DBNull.Value);
				if (_Invoice.CF2 != null)
					AddParameter(oDbCommand, "@CF2", DbType.String, _Invoice.CF2);
				else
					AddParameter(oDbCommand, "@CF2",DbType.String, DBNull.Value);
				if (_Invoice.CF3 != null)
					AddParameter(oDbCommand, "@CF3", DbType.String, _Invoice.CF3);
				else
					AddParameter(oDbCommand, "@CF3",DbType.String, DBNull.Value);
				if (_Invoice.CF4 != null)
					AddParameter(oDbCommand, "@CF4", DbType.String, _Invoice.CF4);
				else
					AddParameter(oDbCommand, "@CF4",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@invoiceId", DbType.Int32, _Invoice.invoiceId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int invoiceId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@invoiceId", DbType.Int32, invoiceId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public DataTable Invoice_GetPaymentByInvoiceId(Int32 InvoiceId)
        {
            DataTable dt = new DataTable();
            DbDataReader oDbDataReader = null;
            try
            {
                //CreditCollection oCreditCollection = new CreditCollection();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_GetPaymentByInvoiceId", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@InvoiceId", DbType.Int32, InvoiceId);
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

        public DataTable Report_InvoiceForCreditSale(int InvoiceId, string SaleType, bool ShowRetailPrice)
        {
            DataTable dt = new DataTable();
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Report_InvoiceForCreditSale", CommandType.StoredProcedure);
                DbDataAdapter adpter = DbProviderHelper.CreateDataAdapter(oDbCommand);
                AddParameter(oDbCommand, "@InvoiceId", DbType.Int32, InvoiceId);
                AddParameter(oDbCommand, "@SaleType", DbType.String, SaleType);
                AddParameter(oDbCommand, "@ShowRetailPrice", DbType.Boolean, ShowRetailPrice);
                //oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dt = DbProviderHelper.FillDataTable(adpter);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public int UpdateIsPaid(Int32 InvoiceId)
        { 
            try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_UpdateIsPaid", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@InvoiceId", DbType.Int32, InvoiceId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public int UpdateTotalPrice(Int32 invoiceId, double totalPrice, DateTime saleDate, string invNo, string discGiven)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Invoice_UpdateTotalPrice", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@InvoiceId", DbType.Int32, invoiceId);
                AddParameter(oDbCommand, "@TotalPrice", DbType.Double, totalPrice);
                AddParameter(oDbCommand, "@SaleDate", DbType.DateTime, saleDate);
                AddParameter(oDbCommand, "@InvoiceNo", DbType.String, invNo);
                AddParameter(oDbCommand, "@DiscountGiven", DbType.String, discGiven);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
