using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PurchaseProduct
	{
        public Int64 purchaseDtlId { get; set; }
		public int purchaseId { get; set; }
		public int productId { get; set; }
		public Nullable<Double> qty { get; set; }
		public Nullable<Double> unitCost { get; set; }
		public Nullable<DateTime> ExpireDate { get; set; }
		public string lotNumber{ get; set; }
		public string ProductName { get; set; }
        public double usedQty { get; set; }
        public double ReturnedQty { get; set; }
        public double ReturnQty { get; set; }

		public PurchaseProduct()
		{ }

		public PurchaseProduct(int purchaseId, int productId, Nullable<Double> qty, Nullable<Double> unitCost, Nullable<DateTime> ExpireDate)
		{
			this.purchaseId = purchaseId;
			this.productId = productId;
			this.qty = qty;
			this.unitCost = unitCost;
			this.ExpireDate = ExpireDate;
		}

		public override string ToString()
		{
			return "purchaseId = " + purchaseId.ToString() + ",productId = " + productId.ToString() + ",qty = " + qty.ToString() + ",unitCost = " + unitCost.ToString() + ",ExpireDate = " + ExpireDate.ToString() + ",LotNumber = " + lotNumber;
		}

	}
}
