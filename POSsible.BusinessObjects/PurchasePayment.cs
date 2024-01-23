using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PurchasePayment
	{
		public Int64 PurchasePaymentId { get; set; }
		public Nullable<int> PurchaseId { get; set; }
		public DateTime PaymentDate { get; set; }
		public string PaymentType { get; set; }
		public string ChequeNo { get; set; }
		public Nullable<DateTime> ChequeDate { get; set; }
		public string ChequeBank { get; set; }
		public Nullable<bool> IsChqCleared { get; set; }
		public string MemoNumber { get; set; }
		public Decimal PaidAmount { get; set; }
		public Decimal DiscAmount { get; set; }
		public Decimal RemAmount { get; set; }
		public Nullable<Decimal> DueBalance { get; set; }
		public Nullable<int> PaidBy { get; set; }
		public string ReceivedBy { get; set; }
		public string Remarks { get; set; }
		public string ManualMRNo { get; set; }
		public string MRBookNo { get; set; }
		public Nullable<int> EnteredBy { get; set; }
		public Nullable<DateTime> EnteredTime { get; set; }
		public Nullable<int> UpdatedBy { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }

		public PurchasePayment()
		{ }

		public PurchasePayment(Int64 PurchasePaymentId, Nullable<int> PurchaseId, DateTime PaymentDate, string PaymentType, string ChequeNo, Nullable<DateTime> ChequeDate, string ChequeBank, Nullable<bool> IsChqCleared, string MemoNumber, Decimal PaidAmount, Decimal DiscAmount, Decimal RemAmount, Nullable<Decimal> DueBalance, Nullable<int> PaidBy, string ReceivedBy, string Remarks, string ManualMRNo, string MRBookNo, Nullable<int> EnteredBy, Nullable<DateTime> EnteredTime, Nullable<int> UpdatedBy, Nullable<DateTime> UpdatedTime, string CF1, string CF2, string CF3)
		{
			this.PurchasePaymentId = PurchasePaymentId;
			this.PurchaseId = PurchaseId;
			this.PaymentDate = PaymentDate;
			this.PaymentType = PaymentType;
			this.ChequeNo = ChequeNo;
			this.ChequeDate = ChequeDate;
			this.ChequeBank = ChequeBank;
			this.IsChqCleared = IsChqCleared;
			this.MemoNumber = MemoNumber;
			this.PaidAmount = PaidAmount;
			this.DiscAmount = DiscAmount;
			this.RemAmount = RemAmount;
			this.DueBalance = DueBalance;
			this.PaidBy = PaidBy;
			this.ReceivedBy = ReceivedBy;
			this.Remarks = Remarks;
			this.ManualMRNo = ManualMRNo;
			this.MRBookNo = MRBookNo;
			this.EnteredBy = EnteredBy;
			this.EnteredTime = EnteredTime;
			this.UpdatedBy = UpdatedBy;
			this.UpdatedTime = UpdatedTime;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
		}

		public override string ToString()
		{
			return "PurchasePaymentId = " + PurchasePaymentId.ToString() + ",PurchaseId = " + PurchaseId.ToString() + ",PaymentDate = " + PaymentDate.ToString() + ",PaymentType = " + PaymentType + ",ChequeNo = " + ChequeNo + ",ChequeDate = " + ChequeDate.ToString() + ",ChequeBank = " + ChequeBank + ",IsChqCleared = " + IsChqCleared.ToString() + ",MemoNumber = " + MemoNumber + ",PaidAmount = " + PaidAmount.ToString() + ",DiscAmount = " + DiscAmount.ToString() + ",RemAmount = " + RemAmount.ToString() + ",DueBalance = " + DueBalance.ToString() + ",PaidBy = " + PaidBy.ToString() + ",ReceivedBy = " + ReceivedBy + ",Remarks = " + Remarks + ",ManualMRNo = " + ManualMRNo + ",MRBookNo = " + MRBookNo + ",EnteredBy = " + EnteredBy.ToString() + ",EnteredTime = " + EnteredTime.ToString() + ",UpdatedBy = " + UpdatedBy.ToString() + ",UpdatedTime = " + UpdatedTime.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
