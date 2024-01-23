using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PaymentVoucherMain
	{
		public Int64 PaymentVoucherId { get; set; }
		public string PaymentVoucherMode { get; set; }
		public Int64 PaymentVoucherNo { get; set; }
		public DateTime PaymentVoucherDate { get; set; }
		public int CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }

		public PaymentVoucherMain()
		{ }

		public PaymentVoucherMain(Int64 PaymentVoucherId, string PaymentVoucherMode, Int64 PaymentVoucherNo, DateTime PaymentVoucherDate, int CreatorId, DateTime CreateDate, string CF1, string CF2, string CF3)
		{
			this.PaymentVoucherId = PaymentVoucherId;
			this.PaymentVoucherMode = PaymentVoucherMode;
			this.PaymentVoucherNo = PaymentVoucherNo;
			this.PaymentVoucherDate = PaymentVoucherDate;
			this.CreatorId = CreatorId;
			this.CreateDate = CreateDate;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
		}

		public override string ToString()
		{
			return "PaymentVoucherId = " + PaymentVoucherId.ToString() + ",PaymentVoucherMode = " + PaymentVoucherMode + ",PaymentVoucherNo = " + PaymentVoucherNo.ToString() + ",PaymentVoucherDate = " + PaymentVoucherDate.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CreateDate = " + CreateDate.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
