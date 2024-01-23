using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class CreditCollection
	{
		public Int64 CreditCollectionId { get; set; }
		public int SaleId { get; set; }
		public Double PaidAmount { get; set; }
		public Nullable<Double> DiscAmount { get; set; }
		public Nullable<Double> RemAmount { get; set; }
		public Nullable<Double> DueBalance { get; set; }
		public DateTime CollectionDate { get; set; }
        public string CollectionType { get; set; }
		public Nullable<DateTime> ChequeDate { get; set; }
		public string ChequeNo { get; set; }
		public string ChequeBank { get; set; }
		public Nullable<bool> isChequeCleared { get; set; }
		public string MemoNo { get; set; }
		public string PaidBy { get; set; }
		public int ReceivedBy { get; set; }
		public string Remarks { get; set; }
		public string ManualMRNo { get; set; }
		public string MRBookNo { get; set; }
		public int EnteredBy { get; set; }
		public Nullable<DateTime> EnteredTime { get; set; }
		public int UpdatedBy { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }

		public CreditCollection()
		{ }

		public CreditCollection(Int64 CreditCollectionId, int SaleId, Double PaidAmount, Nullable<Double> DiscAmount, Nullable<Double> RemAmount, Nullable<Double> DueBalance, DateTime CollectionDate, Nullable<DateTime> ChequeDate, string ChequeNo, string ChequeBank, Nullable<bool> isChequeCleared, string MemoNo, string PaidBy, int ReceivedBy, string Remarks, string ManualMRNo, string MRBookNo, int EnteredBy, Nullable<DateTime> EnteredTime, int UpdatedBy, Nullable<DateTime> UpdatedTime, string CF1, string CF2)
		{
			this.CreditCollectionId = CreditCollectionId;
			this.SaleId = SaleId;
			this.PaidAmount = PaidAmount;
			this.DiscAmount = DiscAmount;
			this.RemAmount = RemAmount;
			this.DueBalance = DueBalance;
			this.CollectionDate = CollectionDate;
			this.ChequeDate = ChequeDate;
			this.ChequeNo = ChequeNo;
			this.ChequeBank = ChequeBank;
			this.isChequeCleared = isChequeCleared;
			this.MemoNo = MemoNo;
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
		}

		public override string ToString()
		{
			return "CreditCollectionId = " + CreditCollectionId.ToString() + ",SaleId = " + SaleId.ToString() + ",PaidAmount = " + PaidAmount.ToString() + ",DiscAmount = " + DiscAmount.ToString() + ",RemAmount = " + RemAmount.ToString() + ",DueBalance = " + DueBalance.ToString() + ",CollectionDate = " + CollectionDate.ToString() + ",ChequeDate = " + ChequeDate.ToString() + ",ChequeNo = " + ChequeNo + ",ChequeBank = " + ChequeBank + ",isChequeCleared = " + isChequeCleared.ToString() + ",MemoNo = " + MemoNo + ",PaidBy = " + PaidBy + ",ReceivedBy = " + ReceivedBy.ToString() + ",Remarks = " + Remarks + ",ManualMRNo = " + ManualMRNo + ",MRBookNo = " + MRBookNo + ",EnteredBy = " + EnteredBy.ToString() + ",EnteredTime = " + EnteredTime.ToString() + ",UpdatedBy = " + UpdatedBy.ToString() + ",UpdatedTime = " + UpdatedTime.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2;
		}

	}
}
