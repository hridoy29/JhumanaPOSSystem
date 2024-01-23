using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Shift
	{
		public int shiftId { get; set; }
		public string shiftName { get; set; }
		public Nullable<int> userId { get; set; }
		public Nullable<DateTime> StartTime { get; set; }
		public Nullable<DateTime> EndTime { get; set; }
		public Nullable<Double> StartMoney { get; set; }
		public Nullable<Double> EndMoney { get; set; }
		public Nullable<Double> TotalChangeGiven { get; set; }
		public Nullable<Double> TotalSafeDrop { get; set; }
		public Nullable<Double> TotalSale { get; set; }
		public Nullable<Double> TotalEftposSale { get; set; }
		public Nullable<Double> TotalCashSale { get; set; }
		public Nullable<Double> TotalVegiSale { get; set; }
		public Nullable<Double> TotalGrocerySale { get; set; }
		public Nullable<Double> TotalFruitSale { get; set; }
		public Nullable<Double> TotalFishSale { get; set; }
		public Nullable<Double> TotalMeatSale { get; set; }
		public Nullable<Double> TotalDairySale { get; set; }
		public Nullable<Double> TotalDairyOtherSale { get; set; }
		public Nullable<Double> TotalTobaccoSale { get; set; }
		public Nullable<Double> TotalDrinksSale { get; set; }
		public Nullable<Double> TotalPhoneCardSale { get; set; }
		public Nullable<Double> TotalDVDSale { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }
		public string Userterminal { get; set; }

		public Shift()
		{ }

		public Shift(int shiftId, string shiftName, Nullable<int> userId, Nullable<DateTime> StartTime, Nullable<DateTime> EndTime, Nullable<Double> StartMoney, Nullable<Double> EndMoney, Nullable<Double> TotalChangeGiven, Nullable<Double> TotalSafeDrop, Nullable<Double> TotalSale, Nullable<Double> TotalEftposSale, Nullable<Double> TotalCashSale, Nullable<Double> TotalVegiSale, Nullable<Double> TotalGrocerySale, Nullable<Double> TotalFruitSale, Nullable<Double> TotalFishSale, Nullable<Double> TotalMeatSale, Nullable<Double> TotalDairySale, Nullable<Double> TotalDairyOtherSale, Nullable<Double> TotalTobaccoSale, Nullable<Double> TotalDrinksSale, Nullable<Double> TotalPhoneCardSale, Nullable<Double> TotalDVDSale, Nullable<DateTime> UpdatedTime, string Userterminal)
		{
			this.shiftId = shiftId;
			this.shiftName = shiftName;
			this.userId = userId;
			this.StartTime = StartTime;
			this.EndTime = EndTime;
			this.StartMoney = StartMoney;
			this.EndMoney = EndMoney;
			this.TotalChangeGiven = TotalChangeGiven;
			this.TotalSafeDrop = TotalSafeDrop;
			this.TotalSale = TotalSale;
			this.TotalEftposSale = TotalEftposSale;
			this.TotalCashSale = TotalCashSale;
			this.TotalVegiSale = TotalVegiSale;
			this.TotalGrocerySale = TotalGrocerySale;
			this.TotalFruitSale = TotalFruitSale;
			this.TotalFishSale = TotalFishSale;
			this.TotalMeatSale = TotalMeatSale;
			this.TotalDairySale = TotalDairySale;
			this.TotalDairyOtherSale = TotalDairyOtherSale;
			this.TotalTobaccoSale = TotalTobaccoSale;
			this.TotalDrinksSale = TotalDrinksSale;
			this.TotalPhoneCardSale = TotalPhoneCardSale;
			this.TotalDVDSale = TotalDVDSale;
			this.UpdatedTime = UpdatedTime;
			this.Userterminal = Userterminal;
		}

		public override string ToString()
		{
			return "shiftId = " + shiftId.ToString() + ",shiftName = " + shiftName + ",userId = " + userId.ToString() + ",StartTime = " + StartTime.ToString() + ",EndTime = " + EndTime.ToString() + ",StartMoney = " + StartMoney.ToString() + ",EndMoney = " + EndMoney.ToString() + ",TotalChangeGiven = " + TotalChangeGiven.ToString() + ",TotalSafeDrop = " + TotalSafeDrop.ToString() + ",TotalSale = " + TotalSale.ToString() + ",TotalEftposSale = " + TotalEftposSale.ToString() + ",TotalCashSale = " + TotalCashSale.ToString() + ",TotalVegiSale = " + TotalVegiSale.ToString() + ",TotalGrocerySale = " + TotalGrocerySale.ToString() + ",TotalFruitSale = " + TotalFruitSale.ToString() + ",TotalFishSale = " + TotalFishSale.ToString() + ",TotalMeatSale = " + TotalMeatSale.ToString() + ",TotalDairySale = " + TotalDairySale.ToString() + ",TotalDairyOtherSale = " + TotalDairyOtherSale.ToString() + ",TotalTobaccoSale = " + TotalTobaccoSale.ToString() + ",TotalDrinksSale = " + TotalDrinksSale.ToString() + ",TotalPhoneCardSale = " + TotalPhoneCardSale.ToString() + ",TotalDVDSale = " + TotalDVDSale.ToString() + ",UpdatedTime = " + UpdatedTime.ToString() + ",Userterminal = " + Userterminal;
		}

	}
}
