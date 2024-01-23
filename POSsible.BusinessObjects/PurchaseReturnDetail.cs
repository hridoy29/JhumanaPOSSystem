using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PurchaseReturnDetail
	{
		public Int64 ReturnDetailId { get; set; }
		public Int64 ReturnId { get; set; }
		public int ProductId { get; set; }
		public Double ReturnQty { get; set; }
		public Double ReturnPrice { get; set; }
		public Double ReturnAmount { get; set; }
        public int PurchaseId { get; set; }

		public PurchaseReturnDetail()
		{ }

		public PurchaseReturnDetail(Int64 ReturnDetailId, Int64 ReturnId, int ProductId, Double ReturnQty, Double ReturnPrice, Double ReturnAmount)
		{
			this.ReturnDetailId = ReturnDetailId;
			this.ReturnId = ReturnId;
			this.ProductId = ProductId;
			this.ReturnQty = ReturnQty;
			this.ReturnPrice = ReturnPrice;
			this.ReturnAmount = ReturnAmount;
		}

		public override string ToString()
		{
			return "ReturnDetailId = " + ReturnDetailId.ToString() + ",ReturnId = " + ReturnId.ToString() + ",ProductId = " + ProductId.ToString() + ",ReturnQty = " + ReturnQty.ToString() + ",ReturnPrice = " + ReturnPrice.ToString() + ",ReturnAmount = " + ReturnAmount.ToString();
		}

	}
}
