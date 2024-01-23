using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Transaction
	{
		public Int64 TransId { get; set; }
		public int ParentId { get; set; }
		public int TransType { get; set; }
		public DateTime TransDate { get; set; }
		public int ProductId { get; set; }
		public double Quantity { get; set; }
        public double UsedQty { get; set; }
		public Double UnitPrice { get; set; }
		public int EnteredBy { get; set; }
		public DateTime EnteredTime { get; set; }
        public int StoreId { get; set; }
        public string pName { get; set; }
        public int catId { get; set; }

		public Transaction()
		{ }

		public Transaction(Int64 TransId, int ParentId, int TransType, DateTime TransDate, int ProductId, double Quantity, Double UnitPrice, int EnteredBy, DateTime EnteredTime)
		{
			this.TransId = TransId;
			this.ParentId = ParentId;
			this.TransType = TransType;
			this.TransDate = TransDate;
			this.ProductId = ProductId;
			this.Quantity = Quantity;
			this.UnitPrice = UnitPrice;
			this.EnteredBy = EnteredBy;
			this.EnteredTime = EnteredTime;
		}

		public override string ToString()
		{
			return "TransId = " + TransId.ToString() + ",ParentId = " + ParentId.ToString() + ",TransType = " + TransType.ToString() + ",TransDate = " + TransDate.ToString() + ",ProductId = " + ProductId.ToString() + ",Quantity = " + Quantity.ToString() + ",UnitPrice = " + UnitPrice.ToString() + ",EnteredBy = " + EnteredBy.ToString() + ",EnteredTime = " + EnteredTime.ToString();
		}

	}
}
