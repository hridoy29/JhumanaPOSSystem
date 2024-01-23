using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class ACCTransaction
	{
		public Int64 TransactionId { get; set; }
		public int AccountLedgerId { get; set; }
		public DateTime TransactionDate { get; set; }
		public string Narration { get; set; }
		public double DrAmt { get; set; }
		public double CrAmt { get; set; }
		public decimal BalanceAmt { get; set; }
		public Nullable<Int64> SalesId { get; set; }
		public Nullable<Int64> PurchaseId { get; set; }
		public Nullable<Int64> CustomerId { get; set; }
		public string VoucherNo { get; set; }
		public Nullable<int> BankId { get; set; }
		public Nullable<int> BranchId { get; set; }
		public string ChequeNo { get; set; }
		public DateTime CreateDate { get; set; }
		public int CreatorId { get; set; }
		public string CustomField1 { get; set; }
		public string CustomField2 { get; set; }
		public string CustomField3 { get; set; }
		public string CustomField4 { get; set; }
		public string CustomField5 { get; set; }
		public bool IsVoid { get; set; }
		public string VoidReson { get; set; }
		public Nullable<DateTime> VoidDate { get; set; }
		public Nullable<int> VoidBy { get; set; }

        public string AccountLedgerName { get; set; }
        public int CCCode { get; set; }
        public string AccTransTypeName { get; set; }
        public int AccTransTypeId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string VoucherFrom { get; set; }

        public string VoucherMode { get; set; }
        public string DispatchNo { get; set; }
        public Int64 VoucherId { get; set; }
        public string ClassName { get; set; }

		public ACCTransaction()
		{ }

        public ACCTransaction(Int64 TransactionId, int AccountLedgerId, DateTime TransactionDate, string Narration, double DrAmt, double CrAmt, decimal BalanceAmt, Nullable<Int64> SalesId, Nullable<Int64> PurchaseId, Nullable<Int64> CustomerId, string VoucherNo, Nullable<int> BankId, Nullable<int> BranchId, string ChequeNo, DateTime CreateDate, int CreatorId, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, bool IsVoid, string VoidReson, Nullable<DateTime> VoidDate, Nullable<int> VoidBy, string AccountLedgerName, int CCCode, string AccTransTypeName, int AccTransTypeId, decimal OpeningBalance, string VoucherFrom, string VoucherMode, string DispatchNo, Int64 VoucherId, string ClassName)
		{
			this.TransactionId = TransactionId;
			this.AccountLedgerId = AccountLedgerId;
			this.TransactionDate = TransactionDate;
			this.Narration = Narration;
			this.DrAmt = DrAmt;
			this.CrAmt = CrAmt;
			this.BalanceAmt = BalanceAmt;
			this.SalesId = SalesId;
			this.PurchaseId = PurchaseId;
			this.CustomerId = CustomerId;
			this.VoucherNo = VoucherNo;
			this.BankId = BankId;
			this.BranchId = BranchId;
			this.ChequeNo = ChequeNo;
			this.CreateDate = CreateDate;
			this.CreatorId = CreatorId;
			this.CustomField1 = CustomField1;
			this.CustomField2 = CustomField2;
			this.CustomField3 = CustomField3;
			this.CustomField4 = CustomField4;
			this.CustomField5 = CustomField5;
			this.IsVoid = IsVoid;
			this.VoidReson = VoidReson;
			this.VoidDate = VoidDate;
			this.VoidBy = VoidBy;
            this.AccountLedgerName = AccountLedgerName;
            this.CCCode = CCCode;
            this.AccTransTypeName = AccTransTypeName;
            this.AccTransTypeId = AccTransTypeId;
            this.OpeningBalance = OpeningBalance;
            this.VoucherFrom = VoucherFrom;
            this.VoucherMode = VoucherMode;
            this.DispatchNo = DispatchNo;
            this.VoucherId = VoucherId;
            this.ClassName = ClassName;
		}

		public override string ToString()
		{
			return "TransactionId = " + TransactionId.ToString() + ",AccountLedgerId = " + AccountLedgerId.ToString() + ",TransactionDate = " + TransactionDate.ToString() + ",Narration = " + Narration + ",DrAmt = " + DrAmt.ToString() + ",CrAmt = " + CrAmt.ToString() + ",BalanceAmt = " + BalanceAmt.ToString() + ",SalesId = " + SalesId.ToString() + ",PurchaseId = " + PurchaseId.ToString() + ",CustomerId = " + CustomerId.ToString() + ",VoucherNo = " + VoucherNo + ",BankId = " + BankId.ToString() + ",BranchId = " + BranchId.ToString() + ",ChequeNo = " + ChequeNo + ",CreateDate = " + CreateDate.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CustomField1 = " + CustomField1 + ",CustomField2 = " + CustomField2 + ",CustomField3 = " + CustomField3 + ",CustomField4 = " + CustomField4 + ",CustomField5 = " + CustomField5 + ",IsVoid = " + IsVoid.ToString() + ",VoidReson = " + VoidReson + ",VoidDate = " + VoidDate.ToString() + ",VoidBy = " + VoidBy.ToString();
		}

	}
}
