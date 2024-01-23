using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Invoice
	{
		public int invoiceId { get; set; }
		public string InvoiceNo { get; set; }
		public Nullable<int> shiftId { get; set; }
		public int userId { get; set; }
		public Nullable<int> customerId { get; set; }
		public int StoreId { get; set; }
		public Nullable<DateTime> invoiceDate { get; set; }
		public string SaleType { get; set; }
		public Nullable<Double> TotalPrice { get; set; }
		public Nullable<Double> TotalGST { get; set; }
		public Nullable<Double> CashAmt { get; set; }
		public Nullable<Double> CardAmt { get; set; }
		public Nullable<Double> changeGiven { get; set; }
		public string DiscountGiven { get; set; }
		public Nullable<int> DiscountAthorizedId { get; set; }
		public string description { get; set; }
		public string status { get; set; }
		public Nullable<DateTime> updatedTime { get; set; }
		public Nullable<int> updatedBy { get; set; }
		public string CardType { get; set; }
		public string CardNo { get; set; }
		public string CardHolderName { get; set; }
		public Nullable<Double> CusPrevBalance { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }
		public string CF4 { get; set; }
        public string CustomerName { get; set; }
        //public int CIHAcLgId { get; set; }
        //public int BankAcLgId { get; set; }
        //public int SaleAcLgId { get; set; }
        //public int CusAcLgId { get; set; }
        //public string ProjectId { get; set; }

		public Invoice()
		{ }

		public Invoice(int invoiceId, string InvoiceNo, Nullable<int> shiftId, int userId, Nullable<int> customerId, int StoreId, Nullable<DateTime> invoiceDate, string SaleType, Nullable<Double> TotalPrice, Nullable<Double> TotalGST, Nullable<Double> CashAmt, Nullable<Double> CardAmt, Nullable<Double> changeGiven, string DiscountGiven, Nullable<int> DiscountAthorizedId, string description, string status, Nullable<DateTime> updatedTime, Nullable<int> updatedBy, string CardType, string CardNo, string CardHolderName, Nullable<Double> CusPrevBalance, string CF1, string CF2, string CF3, string CF4)
		{
			this.invoiceId = invoiceId;
			this.InvoiceNo = InvoiceNo;
			this.shiftId = shiftId;
			this.userId = userId;
			this.customerId = customerId;
			this.StoreId = StoreId;
			this.invoiceDate = invoiceDate;
			this.SaleType = SaleType;
			this.TotalPrice = TotalPrice;
			this.TotalGST = TotalGST;
			this.CashAmt = CashAmt;
			this.CardAmt = CardAmt;
			this.changeGiven = changeGiven;
			this.DiscountGiven = DiscountGiven;
			this.DiscountAthorizedId = DiscountAthorizedId;
			this.description = description;
			this.status = status;
			this.updatedTime = updatedTime;
			this.updatedBy = updatedBy;
			this.CardType = CardType;
			this.CardNo = CardNo;
			this.CardHolderName = CardHolderName;
			this.CusPrevBalance = CusPrevBalance;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
			this.CF4 = CF4;
		}

		public override string ToString()
		{
			return "invoiceId = " + invoiceId.ToString() + ",InvoiceNo = " + InvoiceNo + ",shiftId = " + shiftId.ToString() + ",userId = " + userId.ToString() + ",customerId = " + customerId.ToString() + ",StoreId = " + StoreId.ToString() + ",invoiceDate = " + invoiceDate.ToString() + ",SaleType = " + SaleType + ",TotalPrice = " + TotalPrice.ToString() + ",TotalGST = " + TotalGST.ToString() + ",CashAmt = " + CashAmt.ToString() + ",CardAmt = " + CardAmt.ToString() + ",changeGiven = " + changeGiven.ToString() + ",DiscountGiven = " + DiscountGiven + ",DiscountAthorizedId = " + DiscountAthorizedId.ToString() + ",description = " + description + ",status = " + status + ",updatedTime = " + updatedTime.ToString() + ",updatedBy = " + updatedBy.ToString() + ",CardType = " + CardType + ",CardNo = " + CardNo + ",CardHolderName = " + CardHolderName + ",CusPrevBalance = " + CusPrevBalance.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3 + ",CF4 = " + CF4;
		}

	}
}
