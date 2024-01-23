using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PaymentVoucherDetail
	{
		public Int64 PaymentVoucherDetailId { get; set; }
		public Int64 PaymentVoucherId { get; set; }
		public Nullable<Int64> TransactionId { get; set; }
		public int AccountLedgerId { get; set; }
		public string Narration { get; set; }
		public Nullable<int> CCCode { get; set; }
        public double DrAmt { get; set; }
        public double CrAmt { get; set; }
		public string ChequeNo { get; set; }
		public Nullable<DateTime> ChequeDate { get; set; }
		public string ChequeBank { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }
        public Int64 PaymentVoucherNo { get; set; }

		public PaymentVoucherDetail()
		{ }

        public PaymentVoucherDetail(Int64 PaymentVoucherDetailId, Int64 PaymentVoucherId, Nullable<Int64> TransactionId, int AccountLedgerId, string Narration, Nullable<int> CCCode, double DrAmt, double CrAmt, string ChequeNo, Nullable<DateTime> ChequeDate, string ChequeBank, string CF1, string CF2, string CF3, Int64 PaymentVoucherNo)
		{
			this.PaymentVoucherDetailId = PaymentVoucherDetailId;
			this.PaymentVoucherId = PaymentVoucherId;
			this.TransactionId = TransactionId;
			this.AccountLedgerId = AccountLedgerId;
			this.Narration = Narration;
			this.CCCode = CCCode;
			this.DrAmt = DrAmt;
			this.CrAmt = CrAmt;
			this.ChequeNo = ChequeNo;
			this.ChequeDate = ChequeDate;
			this.ChequeBank = ChequeBank;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
            this.PaymentVoucherNo = PaymentVoucherNo;
		}

		public override string ToString()
		{
			return "PaymentVoucherDetailId = " + PaymentVoucherDetailId.ToString() + ",PaymentVoucherId = " + PaymentVoucherId.ToString() + ",TransactionId = " + TransactionId.ToString() + ",AccountLedgerId = " + AccountLedgerId.ToString() + ",Narration = " + Narration + ",CCCode = " + CCCode.ToString() + ",DrAmt = " + DrAmt.ToString() + ",CrAmt = " + CrAmt.ToString() + ",ChequeNo = " + ChequeNo + ",ChequeDate = " + ChequeDate.ToString() + ",ChequeBank = " + ChequeBank + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
