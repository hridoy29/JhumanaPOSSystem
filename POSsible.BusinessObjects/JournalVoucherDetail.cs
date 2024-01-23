using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class JournalVoucherDetail
	{
		public Int64 JournalVoucherDetailId { get; set; }
		public Int64 JournalVoucherId { get; set; }
		public Nullable<Int64> TransactionId { get; set; }
		public int AccTransTypeId { get; set; }
		public int AccountLedgerId { get; set; }
		public string Narration { get; set; }
		public Nullable<int> CCCode { get; set; }
        public double DrAmt { get; set; }
        public double CrAmt { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }
        public Int64 JournalVoucherNo { get; set; }

		public JournalVoucherDetail()
		{ }

        public JournalVoucherDetail(Int64 JournalVoucherDetailId, Int64 JournalVoucherId, Nullable<Int64> TransactionId, int AccTransTypeId, int AccountLedgerId, string Narration, Nullable<int> CCCode, double DrAmt, double CrAmt, string CF1, string CF2, string CF3, Int64 JournalVoucherNo)
		{
			this.JournalVoucherDetailId = JournalVoucherDetailId;
			this.JournalVoucherId = JournalVoucherId;
			this.TransactionId = TransactionId;
			this.AccTransTypeId = AccTransTypeId;
			this.AccountLedgerId = AccountLedgerId;
			this.Narration = Narration;
			this.CCCode = CCCode;
			this.DrAmt = DrAmt;
			this.CrAmt = CrAmt;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
            this.JournalVoucherNo = JournalVoucherNo;
		}

		public override string ToString()
		{
			return "JournalVoucherDetailId = " + JournalVoucherDetailId.ToString() + ",JournalVoucherId = " + JournalVoucherId.ToString() + ",TransactionId = " + TransactionId.ToString() + ",AccTransTypeId = " + AccTransTypeId.ToString() + ",AccountLedgerId = " + AccountLedgerId.ToString() + ",Narration = " + Narration + ",CCCode = " + CCCode.ToString() + ",DrAmt = " + DrAmt.ToString() + ",CrAmt = " + CrAmt.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
