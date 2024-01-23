using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Purchase
	{
		public int purchaseId { get; set; }
		public string status { get; set; }
		public string description { get; set; }
		public Nullable<DateTime> orderDate { get; set; }
		public Nullable<DateTime> deliveryDate { get; set; }
		public string shippingMethod { get; set; }
		public string shipTo { get; set; }
		public Nullable<int> supplierId { get; set; }
		public Nullable<Double> totalCost { get; set; }
		public bool IsPaid { get; set; }
		public bool IsStored { get; set; }
		public Nullable<DateTime> enteredTime { get; set; }
		public Nullable<int> enteredBy { get; set; }
		public Nullable<DateTime> updatedTime { get; set; }
		public Nullable<int> updatedBy { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string MemoNumber { get; set; }

		public Purchase()
		{ }

		public Purchase(int purchaseId, string status, string description, Nullable<DateTime> orderDate, Nullable<DateTime> deliveryDate, string shippingMethod, string shipTo, Nullable<int> supplierId, Nullable<Double> totalCost, bool IsPaid, bool IsStored, Nullable<DateTime> enteredTime, Nullable<int> enteredBy, Nullable<DateTime> updatedTime, Nullable<int> updatedBy)
		{
			this.purchaseId = purchaseId;
			this.status = status;
			this.description = description;
			this.orderDate = orderDate;
			this.deliveryDate = deliveryDate;
			this.shippingMethod = shippingMethod;
			this.shipTo = shipTo;
			this.supplierId = supplierId;
			this.totalCost = totalCost;
			this.IsPaid = IsPaid;
			this.IsStored = IsStored;
			this.enteredTime = enteredTime;
			this.enteredBy = enteredBy;
			this.updatedTime = updatedTime;
			this.updatedBy = updatedBy;
		}

		public override string ToString()
		{
			return "purchaseId = " + purchaseId.ToString() + ",status = " + status + ",description = " + description + ",orderDate = " + orderDate.ToString() + ",deliveryDate = " + deliveryDate.ToString() + ",shippingMethod = " + shippingMethod + ",shipTo = " + shipTo + ",supplierId = " + supplierId.ToString() + ",totalCost = " + totalCost.ToString() + ",IsPaid = " + IsPaid.ToString() + ",IsStored = " + IsStored.ToString() + ",enteredTime = " + enteredTime.ToString() + ",enteredBy = " + enteredBy.ToString() + ",updatedTime = " + updatedTime.ToString() + ",updatedBy = " + updatedBy.ToString();
		}

	}
}
