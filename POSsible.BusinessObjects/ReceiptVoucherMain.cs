using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class ReceiptVoucherMain
	{
		public Int64 ReceiptVoucherId { get; set; }
		public string ReceiptVoucherMode { get; set; }
		public Int64 ReceiptVoucherNo { get; set; }
		public DateTime ReceiptVoucherDate { get; set; }
		public int CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }

		public ReceiptVoucherMain()
		{ }

		public ReceiptVoucherMain(Int64 ReceiptVoucherId, string ReceiptVoucherMode, Int64 ReceiptVoucherNo, DateTime ReceiptVoucherDate, int CreatorId, DateTime CreateDate, string CF1, string CF2, string CF3)
		{
			this.ReceiptVoucherId = ReceiptVoucherId;
			this.ReceiptVoucherMode = ReceiptVoucherMode;
			this.ReceiptVoucherNo = ReceiptVoucherNo;
			this.ReceiptVoucherDate = ReceiptVoucherDate;
			this.CreatorId = CreatorId;
			this.CreateDate = CreateDate;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
		}

		public override string ToString()
		{
			return "ReceiptVoucherId = " + ReceiptVoucherId.ToString() + ",ReceiptVoucherMode = " + ReceiptVoucherMode + ",ReceiptVoucherNo = " + ReceiptVoucherNo.ToString() + ",ReceiptVoucherDate = " + ReceiptVoucherDate.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CreateDate = " + CreateDate.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
