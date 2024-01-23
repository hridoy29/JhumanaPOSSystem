using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class JournalVoucherMain
	{
		public Int64 JournalVoucherId { get; set; }
		public string JournalVoucherMode { get; set; }
		public Int64 JournalVoucherNo { get; set; }
		public DateTime JournalVoucherDate { get; set; }
		public string Purpose { get; set; }
		public string TransactionBy { get; set; }
		public string ChequeNo { get; set; }
		public Nullable<DateTime> ChequeDate { get; set; }
		public int CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }

		public JournalVoucherMain()
		{ }

		public JournalVoucherMain(Int64 JournalVoucherId, string JournalVoucherMode, Int64 JournalVoucherNo, DateTime JournalVoucherDate, string Purpose, string TransactionBy, string ChequeNo, Nullable<DateTime> ChequeDate, int CreatorId, DateTime CreateDate, string CF1, string CF2, string CF3)
		{
			this.JournalVoucherId = JournalVoucherId;
			this.JournalVoucherMode = JournalVoucherMode;
			this.JournalVoucherNo = JournalVoucherNo;
			this.JournalVoucherDate = JournalVoucherDate;
			this.Purpose = Purpose;
			this.TransactionBy = TransactionBy;
			this.ChequeNo = ChequeNo;
			this.ChequeDate = ChequeDate;
			this.CreatorId = CreatorId;
			this.CreateDate = CreateDate;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
		}

		public override string ToString()
		{
			return "JournalVoucherId = " + JournalVoucherId.ToString() + ",JournalVoucherMode = " + JournalVoucherMode + ",JournalVoucherNo = " + JournalVoucherNo.ToString() + ",JournalVoucherDate = " + JournalVoucherDate.ToString() + ",Purpose = " + Purpose + ",TransactionBy = " + TransactionBy + ",ChequeNo = " + ChequeNo + ",ChequeDate = " + ChequeDate.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CreateDate = " + CreateDate.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
