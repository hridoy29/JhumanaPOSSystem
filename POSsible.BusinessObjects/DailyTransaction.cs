using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class DailyTransaction
	{
		public Int64 TransactionId { get; set; }
		public int TransactionPurposeId { get; set; }
		public int WarehouseId { get; set; }
		public DateTime TransactionDate { get; set; }
		public string TransactionType { get; set; }
		public string Narration { get; set; }
		public Decimal DrAmt { get; set; }
		public Decimal CrAmt { get; set; }
		public Nullable<Decimal> BalanceAmt { get; set; }
		public Nullable<Int64> SalesId { get; set; }
		public Nullable<Int64> PurchaseId { get; set; }
		public Nullable<Int64> SalesCollectionId { get; set; }
		public Nullable<Int64> PurchasePaymentId { get; set; }
		public Nullable<int> CustomerId { get; set; }
		public Nullable<int> SupplierId { get; set; }
        public Nullable<Int64> VoucherNo { get; set; }
		public Nullable<int> BankId { get; set; }
		public Nullable<int> BranchId { get; set; }
		public string ChequeNo { get; set; }
		public Nullable<DateTime> ChequeDate { get; set; }
		public int CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public bool IsVoid { get; set; }
		public string VoidReson { get; set; }
		public Nullable<DateTime> VoidDate { get; set; }
		public Nullable<int> VoidBy { get; set; }
        public string VoucherType { get; set; }
        public string TransactionPurposeName { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public int SL { get; set; }

		public DailyTransaction()
		{ }

        public DailyTransaction(Int64 TransactionId, int TransactionPurposeId, int WarehouseId, DateTime TransactionDate, string TransactionType, string Narration, Decimal DrAmt, Decimal CrAmt, Nullable<Decimal> BalanceAmt, Nullable<Int64> SalesId, Nullable<Int64> PurchaseId, Nullable<Int64> SalesCollectionId, Nullable<Int64> PurchasePaymentId, Nullable<int> CustomerId, Nullable<int> SupplierId, Nullable<Int64> VoucherNo, Nullable<int> BankId, Nullable<int> BranchId, string ChequeNo, Nullable<DateTime> ChequeDate, int CreatorId, DateTime CreateDate, bool IsVoid, string VoidReson, Nullable<DateTime> VoidDate, Nullable<int> VoidBy)
		{
			this.TransactionId = TransactionId;
			this.TransactionPurposeId = TransactionPurposeId;
			this.WarehouseId = WarehouseId;
			this.TransactionDate = TransactionDate;
			this.TransactionType = TransactionType;
			this.Narration = Narration;
			this.DrAmt = DrAmt;
			this.CrAmt = CrAmt;
			this.BalanceAmt = BalanceAmt;
			this.SalesId = SalesId;
			this.PurchaseId = PurchaseId;
			this.SalesCollectionId = SalesCollectionId;
			this.PurchasePaymentId = PurchasePaymentId;
			this.CustomerId = CustomerId;
			this.SupplierId = SupplierId;
			this.VoucherNo = VoucherNo;
			this.BankId = BankId;
			this.BranchId = BranchId;
			this.ChequeNo = ChequeNo;
			this.ChequeDate = ChequeDate;
			this.CreatorId = CreatorId;
			this.CreateDate = CreateDate;
			this.IsVoid = IsVoid;
			this.VoidReson = VoidReson;
			this.VoidDate = VoidDate;
			this.VoidBy = VoidBy;
		}

		public override string ToString()
		{
			return "TransactionId = " + TransactionId.ToString() + ",TransactionPurposeId = " + TransactionPurposeId.ToString() + ",WarehouseId = " + WarehouseId.ToString() + ",TransactionDate = " + TransactionDate.ToString() + ",TransactionType = " + TransactionType + ",Narration = " + Narration + ",DrAmt = " + DrAmt.ToString() + ",CrAmt = " + CrAmt.ToString() + ",BalanceAmt = " + BalanceAmt.ToString() + ",SalesId = " + SalesId.ToString() + ",PurchaseId = " + PurchaseId.ToString() + ",SalesCollectionId = " + SalesCollectionId.ToString() + ",PurchasePaymentId = " + PurchasePaymentId.ToString() + ",CustomerId = " + CustomerId.ToString() + ",SupplierId = " + SupplierId.ToString() + ",VoucherNo = " + VoucherNo + ",BankId = " + BankId.ToString() + ",BranchId = " + BranchId.ToString() + ",ChequeNo = " + ChequeNo + ",ChequeDate = " + ChequeDate.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CreateDate = " + CreateDate.ToString() + ",IsVoid = " + IsVoid.ToString() + ",VoidReson = " + VoidReson + ",VoidDate = " + VoidDate.ToString() + ",VoidBy = " + VoidBy.ToString();
		}

	}
}
