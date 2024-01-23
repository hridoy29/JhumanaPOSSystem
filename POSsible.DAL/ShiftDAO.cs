using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
	public class ShiftDAO
	{
		public ShiftDAO()
		{
			DbProviderHelper.GetConnection();
		}

		private static void BuildEntity(DbDataReader oDbDataReader, Shift oShift)
		{
			DataTable dt = oDbDataReader.GetSchemaTable();
			foreach (DataRow item in dt.Rows)
			{
				string col = item.ItemArray[0].ToString();
				switch (col)
				{
					case "shiftId":
						oShift.shiftId = Convert.ToInt32(oDbDataReader["shiftId"]);
						break;
					case "shiftName":
						if (oDbDataReader["shiftName"] != DBNull.Value)
							oShift.shiftName = Convert.ToString(oDbDataReader["shiftName"]);
						break;
					case "userId":
						if (oDbDataReader["userId"] != DBNull.Value)
							oShift.userId = Convert.ToInt32(oDbDataReader["userId"]);
						break;
					case "StartTime":
						if (oDbDataReader["StartTime"] != DBNull.Value)
							oShift.StartTime = Convert.ToDateTime(oDbDataReader["StartTime"]);
						break;
					case "EndTime":
						if (oDbDataReader["EndTime"] != DBNull.Value)
							oShift.EndTime = Convert.ToDateTime(oDbDataReader["EndTime"]);
						break;
					case "StartMoney":
						if (oDbDataReader["StartMoney"] != DBNull.Value)
							oShift.StartMoney = Convert.ToDouble(oDbDataReader["StartMoney"]);
						break;
					case "EndMoney":
						if (oDbDataReader["EndMoney"] != DBNull.Value)
							oShift.EndMoney = Convert.ToDouble(oDbDataReader["EndMoney"]);
						break;
					case "TotalChangeGiven":
						if (oDbDataReader["TotalChangeGiven"] != DBNull.Value)
							oShift.TotalChangeGiven = Convert.ToDouble(oDbDataReader["TotalChangeGiven"]);
						break;
					case "TotalSafeDrop":
						if (oDbDataReader["TotalSafeDrop"] != DBNull.Value)
							oShift.TotalSafeDrop = Convert.ToDouble(oDbDataReader["TotalSafeDrop"]);
						break;
					case "TotalSale":
						if (oDbDataReader["TotalSale"] != DBNull.Value)
							oShift.TotalSale = Convert.ToDouble(oDbDataReader["TotalSale"]);
						break;
					case "TotalEftposSale":
						if (oDbDataReader["TotalEftposSale"] != DBNull.Value)
							oShift.TotalEftposSale = Convert.ToDouble(oDbDataReader["TotalEftposSale"]);
						break;
					case "TotalCashSale":
						if (oDbDataReader["TotalCashSale"] != DBNull.Value)
							oShift.TotalCashSale = Convert.ToDouble(oDbDataReader["TotalCashSale"]);
						break;
					case "TotalVegiSale":
						if (oDbDataReader["TotalVegiSale"] != DBNull.Value)
							oShift.TotalVegiSale = Convert.ToDouble(oDbDataReader["TotalVegiSale"]);
						break;
					case "TotalGrocerySale":
						if (oDbDataReader["TotalGrocerySale"] != DBNull.Value)
							oShift.TotalGrocerySale = Convert.ToDouble(oDbDataReader["TotalGrocerySale"]);
						break;
					case "TotalFruitSale":
						if (oDbDataReader["TotalFruitSale"] != DBNull.Value)
							oShift.TotalFruitSale = Convert.ToDouble(oDbDataReader["TotalFruitSale"]);
						break;
					case "TotalFishSale":
						if (oDbDataReader["TotalFishSale"] != DBNull.Value)
							oShift.TotalFishSale = Convert.ToDouble(oDbDataReader["TotalFishSale"]);
						break;
					case "TotalMeatSale":
						if (oDbDataReader["TotalMeatSale"] != DBNull.Value)
							oShift.TotalMeatSale = Convert.ToDouble(oDbDataReader["TotalMeatSale"]);
						break;
					case "TotalDairySale":
						if (oDbDataReader["TotalDairySale"] != DBNull.Value)
							oShift.TotalDairySale = Convert.ToDouble(oDbDataReader["TotalDairySale"]);
						break;
					case "TotalDairyOtherSale":
						if (oDbDataReader["TotalDairyOtherSale"] != DBNull.Value)
							oShift.TotalDairyOtherSale = Convert.ToDouble(oDbDataReader["TotalDairyOtherSale"]);
						break;
					case "TotalTobaccoSale":
						if (oDbDataReader["TotalTobaccoSale"] != DBNull.Value)
							oShift.TotalTobaccoSale = Convert.ToDouble(oDbDataReader["TotalTobaccoSale"]);
						break;
					case "TotalDrinksSale":
						if (oDbDataReader["TotalDrinksSale"] != DBNull.Value)
							oShift.TotalDrinksSale = Convert.ToDouble(oDbDataReader["TotalDrinksSale"]);
						break;
					case "TotalPhoneCardSale":
						if (oDbDataReader["TotalPhoneCardSale"] != DBNull.Value)
							oShift.TotalPhoneCardSale = Convert.ToDouble(oDbDataReader["TotalPhoneCardSale"]);
						break;
					case "TotalDVDSale":
						if (oDbDataReader["TotalDVDSale"] != DBNull.Value)
							oShift.TotalDVDSale = Convert.ToDouble(oDbDataReader["TotalDVDSale"]);
						break;
					case "UpdatedTime":
						if (oDbDataReader["UpdatedTime"] != DBNull.Value)
							oShift.UpdatedTime = Convert.ToDateTime(oDbDataReader["UpdatedTime"]);
						break;
					case "Userterminal":
						if (oDbDataReader["Userterminal"] != DBNull.Value)
							oShift.Userterminal = Convert.ToString(oDbDataReader["Userterminal"]);
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

		public List<Shift> Shift_GetAll()
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Shift> lstShift = new List<Shift>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Shift_GetAll", CommandType.StoredProcedure);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Shift oShift = new Shift();
					BuildEntity(oDbDataReader, oShift);
					lstShift.Add(oShift);
				}
				return lstShift;
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

		public List<Shift> Shift_GetDynamic(string WhereCondition, string OrderByExpression)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				List<Shift> lstShift = new List<Shift>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Shift_GetDynamic", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
				AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					Shift oShift = new Shift();
					BuildEntity(oDbDataReader, oShift);
					lstShift.Add(oShift);
				}
				return lstShift;
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

		public Shift Shift_GetById(int shiftId)
		{
			DbDataReader oDbDataReader = null;
			try
			{
				Shift oShift = new Shift();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Shift_GetById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@shiftId", DbType.Int32, shiftId);
				oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					BuildEntity(oDbDataReader, oShift);
				}
				return oShift;
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

		public int Add(Shift _Shift)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Shift_Create", CommandType.StoredProcedure);
				if (_Shift.shiftName != null)
					AddParameter(oDbCommand, "@shiftName", DbType.String, _Shift.shiftName);
				else
					AddParameter(oDbCommand, "@shiftName",DbType.String, DBNull.Value);
				if (_Shift.userId.HasValue)
					AddParameter(oDbCommand, "@userId", DbType.Int32, _Shift.userId);
				else
					AddParameter(oDbCommand, "@userId",DbType.Int32, DBNull.Value);
				if (_Shift.StartTime.HasValue)
					AddParameter(oDbCommand, "@StartTime", DbType.DateTime, _Shift.StartTime);
				else
					AddParameter(oDbCommand, "@StartTime",DbType.DateTime, DBNull.Value);
				if (_Shift.EndTime.HasValue)
					AddParameter(oDbCommand, "@EndTime", DbType.DateTime, _Shift.EndTime);
				else
					AddParameter(oDbCommand, "@EndTime",DbType.DateTime, DBNull.Value);
				if (_Shift.StartMoney.HasValue)
					AddParameter(oDbCommand, "@StartMoney", DbType.Double, _Shift.StartMoney);
				else
					AddParameter(oDbCommand, "@StartMoney",DbType.Double, DBNull.Value);
				if (_Shift.EndMoney.HasValue)
					AddParameter(oDbCommand, "@EndMoney", DbType.Double, _Shift.EndMoney);
				else
					AddParameter(oDbCommand, "@EndMoney",DbType.Double, DBNull.Value);
				if (_Shift.TotalChangeGiven.HasValue)
					AddParameter(oDbCommand, "@TotalChangeGiven", DbType.Double, _Shift.TotalChangeGiven);
				else
					AddParameter(oDbCommand, "@TotalChangeGiven",DbType.Double, DBNull.Value);
				if (_Shift.TotalSafeDrop.HasValue)
					AddParameter(oDbCommand, "@TotalSafeDrop", DbType.Double, _Shift.TotalSafeDrop);
				else
					AddParameter(oDbCommand, "@TotalSafeDrop",DbType.Double, DBNull.Value);
				if (_Shift.TotalSale.HasValue)
					AddParameter(oDbCommand, "@TotalSale", DbType.Double, _Shift.TotalSale);
				else
					AddParameter(oDbCommand, "@TotalSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalEftposSale.HasValue)
					AddParameter(oDbCommand, "@TotalEftposSale", DbType.Double, _Shift.TotalEftposSale);
				else
					AddParameter(oDbCommand, "@TotalEftposSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalCashSale.HasValue)
					AddParameter(oDbCommand, "@TotalCashSale", DbType.Double, _Shift.TotalCashSale);
				else
					AddParameter(oDbCommand, "@TotalCashSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalVegiSale.HasValue)
					AddParameter(oDbCommand, "@TotalVegiSale", DbType.Double, _Shift.TotalVegiSale);
				else
					AddParameter(oDbCommand, "@TotalVegiSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalGrocerySale.HasValue)
					AddParameter(oDbCommand, "@TotalGrocerySale", DbType.Double, _Shift.TotalGrocerySale);
				else
					AddParameter(oDbCommand, "@TotalGrocerySale",DbType.Double, DBNull.Value);
				if (_Shift.TotalFruitSale.HasValue)
					AddParameter(oDbCommand, "@TotalFruitSale", DbType.Double, _Shift.TotalFruitSale);
				else
					AddParameter(oDbCommand, "@TotalFruitSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalFishSale.HasValue)
					AddParameter(oDbCommand, "@TotalFishSale", DbType.Double, _Shift.TotalFishSale);
				else
					AddParameter(oDbCommand, "@TotalFishSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalMeatSale.HasValue)
					AddParameter(oDbCommand, "@TotalMeatSale", DbType.Double, _Shift.TotalMeatSale);
				else
					AddParameter(oDbCommand, "@TotalMeatSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDairySale.HasValue)
					AddParameter(oDbCommand, "@TotalDairySale", DbType.Double, _Shift.TotalDairySale);
				else
					AddParameter(oDbCommand, "@TotalDairySale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDairyOtherSale.HasValue)
					AddParameter(oDbCommand, "@TotalDairyOtherSale", DbType.Double, _Shift.TotalDairyOtherSale);
				else
					AddParameter(oDbCommand, "@TotalDairyOtherSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalTobaccoSale.HasValue)
					AddParameter(oDbCommand, "@TotalTobaccoSale", DbType.Double, _Shift.TotalTobaccoSale);
				else
					AddParameter(oDbCommand, "@TotalTobaccoSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDrinksSale.HasValue)
					AddParameter(oDbCommand, "@TotalDrinksSale", DbType.Double, _Shift.TotalDrinksSale);
				else
					AddParameter(oDbCommand, "@TotalDrinksSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalPhoneCardSale.HasValue)
					AddParameter(oDbCommand, "@TotalPhoneCardSale", DbType.Double, _Shift.TotalPhoneCardSale);
				else
					AddParameter(oDbCommand, "@TotalPhoneCardSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDVDSale.HasValue)
					AddParameter(oDbCommand, "@TotalDVDSale", DbType.Double, _Shift.TotalDVDSale);
				else
					AddParameter(oDbCommand, "@TotalDVDSale",DbType.Double, DBNull.Value);
				if (_Shift.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Shift.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);
				if (_Shift.Userterminal != null)
					AddParameter(oDbCommand, "@Userterminal", DbType.String, _Shift.Userterminal);
				else
					AddParameter(oDbCommand, "@Userterminal",DbType.String, DBNull.Value);

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Shift _Shift)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Shift_Update", CommandType.StoredProcedure);
				if (_Shift.shiftName != null)
					AddParameter(oDbCommand, "@shiftName", DbType.String, _Shift.shiftName);
				else
					AddParameter(oDbCommand, "@shiftName",DbType.String, DBNull.Value);
				if (_Shift.userId.HasValue)
					AddParameter(oDbCommand, "@userId", DbType.Int32, _Shift.userId);
				else
					AddParameter(oDbCommand, "@userId",DbType.Int32, DBNull.Value);
				if (_Shift.StartTime.HasValue)
					AddParameter(oDbCommand, "@StartTime", DbType.DateTime, _Shift.StartTime);
				else
					AddParameter(oDbCommand, "@StartTime",DbType.DateTime, DBNull.Value);
				if (_Shift.EndTime.HasValue)
					AddParameter(oDbCommand, "@EndTime", DbType.DateTime, _Shift.EndTime);
				else
					AddParameter(oDbCommand, "@EndTime",DbType.DateTime, DBNull.Value);
				if (_Shift.StartMoney.HasValue)
					AddParameter(oDbCommand, "@StartMoney", DbType.Double, _Shift.StartMoney);
				else
					AddParameter(oDbCommand, "@StartMoney",DbType.Double, DBNull.Value);
				if (_Shift.EndMoney.HasValue)
					AddParameter(oDbCommand, "@EndMoney", DbType.Double, _Shift.EndMoney);
				else
					AddParameter(oDbCommand, "@EndMoney",DbType.Double, DBNull.Value);
				if (_Shift.TotalChangeGiven.HasValue)
					AddParameter(oDbCommand, "@TotalChangeGiven", DbType.Double, _Shift.TotalChangeGiven);
				else
					AddParameter(oDbCommand, "@TotalChangeGiven",DbType.Double, DBNull.Value);
				if (_Shift.TotalSafeDrop.HasValue)
					AddParameter(oDbCommand, "@TotalSafeDrop", DbType.Double, _Shift.TotalSafeDrop);
				else
					AddParameter(oDbCommand, "@TotalSafeDrop",DbType.Double, DBNull.Value);
				if (_Shift.TotalSale.HasValue)
					AddParameter(oDbCommand, "@TotalSale", DbType.Double, _Shift.TotalSale);
				else
					AddParameter(oDbCommand, "@TotalSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalEftposSale.HasValue)
					AddParameter(oDbCommand, "@TotalEftposSale", DbType.Double, _Shift.TotalEftposSale);
				else
					AddParameter(oDbCommand, "@TotalEftposSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalCashSale.HasValue)
					AddParameter(oDbCommand, "@TotalCashSale", DbType.Double, _Shift.TotalCashSale);
				else
					AddParameter(oDbCommand, "@TotalCashSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalVegiSale.HasValue)
					AddParameter(oDbCommand, "@TotalVegiSale", DbType.Double, _Shift.TotalVegiSale);
				else
					AddParameter(oDbCommand, "@TotalVegiSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalGrocerySale.HasValue)
					AddParameter(oDbCommand, "@TotalGrocerySale", DbType.Double, _Shift.TotalGrocerySale);
				else
					AddParameter(oDbCommand, "@TotalGrocerySale",DbType.Double, DBNull.Value);
				if (_Shift.TotalFruitSale.HasValue)
					AddParameter(oDbCommand, "@TotalFruitSale", DbType.Double, _Shift.TotalFruitSale);
				else
					AddParameter(oDbCommand, "@TotalFruitSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalFishSale.HasValue)
					AddParameter(oDbCommand, "@TotalFishSale", DbType.Double, _Shift.TotalFishSale);
				else
					AddParameter(oDbCommand, "@TotalFishSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalMeatSale.HasValue)
					AddParameter(oDbCommand, "@TotalMeatSale", DbType.Double, _Shift.TotalMeatSale);
				else
					AddParameter(oDbCommand, "@TotalMeatSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDairySale.HasValue)
					AddParameter(oDbCommand, "@TotalDairySale", DbType.Double, _Shift.TotalDairySale);
				else
					AddParameter(oDbCommand, "@TotalDairySale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDairyOtherSale.HasValue)
					AddParameter(oDbCommand, "@TotalDairyOtherSale", DbType.Double, _Shift.TotalDairyOtherSale);
				else
					AddParameter(oDbCommand, "@TotalDairyOtherSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalTobaccoSale.HasValue)
					AddParameter(oDbCommand, "@TotalTobaccoSale", DbType.Double, _Shift.TotalTobaccoSale);
				else
					AddParameter(oDbCommand, "@TotalTobaccoSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDrinksSale.HasValue)
					AddParameter(oDbCommand, "@TotalDrinksSale", DbType.Double, _Shift.TotalDrinksSale);
				else
					AddParameter(oDbCommand, "@TotalDrinksSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalPhoneCardSale.HasValue)
					AddParameter(oDbCommand, "@TotalPhoneCardSale", DbType.Double, _Shift.TotalPhoneCardSale);
				else
					AddParameter(oDbCommand, "@TotalPhoneCardSale",DbType.Double, DBNull.Value);
				if (_Shift.TotalDVDSale.HasValue)
					AddParameter(oDbCommand, "@TotalDVDSale", DbType.Double, _Shift.TotalDVDSale);
				else
					AddParameter(oDbCommand, "@TotalDVDSale",DbType.Double, DBNull.Value);
				if (_Shift.UpdatedTime.HasValue)
					AddParameter(oDbCommand, "@UpdatedTime", DbType.DateTime, _Shift.UpdatedTime);
				else
					AddParameter(oDbCommand, "@UpdatedTime",DbType.DateTime, DBNull.Value);
				if (_Shift.Userterminal != null)
					AddParameter(oDbCommand, "@Userterminal", DbType.String, _Shift.Userterminal);
				else
					AddParameter(oDbCommand, "@Userterminal",DbType.String, DBNull.Value);
				AddParameter(oDbCommand, "@shiftId", DbType.Int32, _Shift.shiftId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(int shiftId)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("Shift_DeleteById", CommandType.StoredProcedure);
				AddParameter(oDbCommand, "@shiftId", DbType.Int32, shiftId);
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
