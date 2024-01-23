using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class ReceiptVoucherDetail
	{
		public Int64 ReceiptVoucherDetailId { get; set; }
		public Int64 ReceiptVoucherId { get; set; }
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
        public Int64 ReceiptVoucherNo { get; set; }

		public ReceiptVoucherDetail()
		{ }

        public ReceiptVoucherDetail(Int64 ReceiptVoucherDetailId, Int64 ReceiptVoucherId, Nullable<Int64> TransactionId, int AccountLedgerId, string Narration, Nullable<int> CCCode, double DrAmt, double CrAmt, string ChequeNo, Nullable<DateTime> ChequeDate, string ChequeBank, string CF1, string CF2, string CF3, Int64 ReceiptVoucherNo)
		{
			this.ReceiptVoucherDetailId = ReceiptVoucherDetailId;
			this.ReceiptVoucherId = ReceiptVoucherId;
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
            this.ReceiptVoucherNo = ReceiptVoucherNo;
		}

		public override string ToString()
		{
			return "ReceiptVoucherDetailId = " + ReceiptVoucherDetailId.ToString() + ",ReceiptVoucherId = " + ReceiptVoucherId.ToString() + ",TransactionId = " + TransactionId.ToString() + ",AccountLedgerId = " + AccountLedgerId.ToString() + ",Narration = " + Narration + ",CCCode = " + CCCode.ToString() + ",DrAmt = " + DrAmt.ToString() + ",CrAmt = " + CrAmt.ToString() + ",ChequeNo = " + ChequeNo + ",ChequeDate = " + ChequeDate.ToString() + ",ChequeBank = " + ChequeBank + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
