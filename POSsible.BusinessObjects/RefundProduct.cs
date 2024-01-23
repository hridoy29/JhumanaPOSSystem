using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class RefundProduct
	{
		public Int64 RefundDtlId { get; set; }
		public int Refundid { get; set; }
		public int productId { get; set; }
		public double qty { get; set; }
		public Nullable<Double> UnitPrice { get; set; }
		public string description { get; set; }
		public Nullable<int> EnteredBy { get; set; }
		public Nullable<DateTime> EnteredTime { get; set; }
		public Nullable<int> UpdatedBy { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }
        public int PcItemId { get; set; }

		public RefundProduct()
		{ }

		public RefundProduct(Int64 RefundDtlId, int Refundid, int productId, double qty, Nullable<Double> UnitPrice, string description, Nullable<int> EnteredBy, Nullable<DateTime> EnteredTime, Nullable<int> UpdatedBy, Nullable<DateTime> UpdatedTime)
		{
			this.RefundDtlId = RefundDtlId;
			this.Refundid = Refundid;
			this.productId = productId;
			this.qty = qty;
			this.UnitPrice = UnitPrice;
			this.description = description;
			this.EnteredBy = EnteredBy;
			this.EnteredTime = EnteredTime;
			this.UpdatedBy = UpdatedBy;
			this.UpdatedTime = UpdatedTime;
		}

		public override string ToString()
		{
			return "RefundDtlId = " + RefundDtlId.ToString() + ",Refundid = " + Refundid.ToString() + ",productId = " + productId.ToString() + ",qty = " + qty.ToString() + ",UnitPrice = " + UnitPrice.ToString() + ",description = " + description + ",EnteredBy = " + EnteredBy.ToString() + ",EnteredTime = " + EnteredTime.ToString() + ",UpdatedBy = " + UpdatedBy.ToString() + ",UpdatedTime = " + UpdatedTime.ToString();
		}

	}
}
