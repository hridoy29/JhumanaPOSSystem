using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Refund
	{
		public int Refundid { get; set; }
		public Nullable<int> invoiceId { get; set; }
		public Nullable<DateTime> refundDate { get; set; }
		public Nullable<int> AuthorizedBy { get; set; }
		public Nullable<int> RefundedBy { get; set; }
		public string RefundMethod { get; set; }
		public Nullable<DateTime> EnteredTime { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }

		public Refund()
		{ }

		public Refund(int Refundid, Nullable<int> invoiceId, Nullable<DateTime> refundDate, Nullable<int> AuthorizedBy, Nullable<int> RefundedBy, string RefundMethod, Nullable<DateTime> EnteredTime, Nullable<DateTime> UpdatedTime)
		{
			this.Refundid = Refundid;
			this.invoiceId = invoiceId;
			this.refundDate = refundDate;
			this.AuthorizedBy = AuthorizedBy;
			this.RefundedBy = RefundedBy;
			this.RefundMethod = RefundMethod;
			this.EnteredTime = EnteredTime;
			this.UpdatedTime = UpdatedTime;
		}

		public override string ToString()
		{
			return "Refundid = " + Refundid.ToString() + ",invoiceId = " + invoiceId.ToString() + ",refundDate = " + refundDate.ToString() + ",AuthorizedBy = " + AuthorizedBy.ToString() + ",RefundedBy = " + RefundedBy.ToString() + ",RefundMethod = " + RefundMethod + ",EnteredTime = " + EnteredTime.ToString() + ",UpdatedTime = " + UpdatedTime.ToString();
		}

	}
}
