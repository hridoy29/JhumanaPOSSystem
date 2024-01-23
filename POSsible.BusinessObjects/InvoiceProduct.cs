using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class InvoiceProduct
	{
		public Int64 invoiceDtlId { get; set; }
		public int invoiceId { get; set; }
		public int productId { get; set; }
		public Nullable<Double> qty { get; set; }
		public Nullable<Double> unitPrice { get; set; }
		public string Status { get; set; }
		public Nullable<DateTime> EnteredTime { get; set; }
		public Nullable<DateTime> Updatedatime { get; set; }
        public String productName { get; set; }
        public double ReturnedQty { get; set; }
        public int PcItemId { get; set; }
        public double PcsPerCrtn { get; set; }
        public int StoreId { get; set; }

        public string UnitMeasureName { get; set; }
        public int categorytId { get; set; }

		public InvoiceProduct()
		{ }

		public InvoiceProduct(Int64 invoiceDtlId, int invoiceId, int productId, Nullable<Double> qty, Nullable<Double> unitPrice, string Status, Nullable<DateTime> EnteredTime, Nullable<DateTime> Updatedatime)
		{
			this.invoiceDtlId = invoiceDtlId;
			this.invoiceId = invoiceId;
			this.productId = productId;
			this.qty = qty;
			this.unitPrice = unitPrice;
			this.Status = Status;
			this.EnteredTime = EnteredTime;
			this.Updatedatime = Updatedatime;
		}

		public override string ToString()
		{
			return "invoiceDtlId = " + invoiceDtlId.ToString() + ",invoiceId = " + invoiceId.ToString() + ",productId = " + productId.ToString() + ",qty = " + qty.ToString() + ",unitPrice = " + unitPrice.ToString() + ",Status = " + Status + ",EnteredTime = " + EnteredTime.ToString() + ",Updatedatime = " + Updatedatime.ToString();
		}

	}
}
