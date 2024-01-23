using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class ProductPromotion
	{
		public int PromoId { get; set; }
		public string PromoOnType { get; set; }
		public int PromoOnId { get; set; }
		public string PromoChargeType { get; set; }
		public Nullable<Double> Price { get; set; }
		public Nullable<int> Percentage { get; set; }
		public Nullable<int> SaleQty { get; set; }
		public string FreeType { get; set; }
		public Nullable<int> FreeTypeId { get; set; }
		public Nullable<int> FreeQty { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int CreatedBy { get; set; }
		public Nullable<DateTime> CreatedDate { get; set; }
		public Nullable<int> UpdatedBy { get; set; }
		public Nullable<DateTime> UpdatedDate { get; set; }

		public ProductPromotion()
		{ }

		public ProductPromotion(int PromoId, string PromoOnType, int PromoOnId, string PromoChargeType, Nullable<Double> Price, Nullable<int> Percentage, Nullable<int> SaleQty, string FreeType, Nullable<int> FreeTypeId, Nullable<int> FreeQty, DateTime StartDate, DateTime EndDate, int CreatedBy, Nullable<DateTime> CreatedDate, Nullable<int> UpdatedBy, Nullable<DateTime> UpdatedDate)
		{
			this.PromoId = PromoId;
			this.PromoOnType = PromoOnType;
			this.PromoOnId = PromoOnId;
			this.PromoChargeType = PromoChargeType;
			this.Price = Price;
			this.Percentage = Percentage;
			this.SaleQty = SaleQty;
			this.FreeType = FreeType;
			this.FreeTypeId = FreeTypeId;
			this.FreeQty = FreeQty;
			this.StartDate = StartDate;
			this.EndDate = EndDate;
			this.CreatedBy = CreatedBy;
			this.CreatedDate = CreatedDate;
			this.UpdatedBy = UpdatedBy;
			this.UpdatedDate = UpdatedDate;
		}

		public override string ToString()
		{
			return "PromoId = " + PromoId.ToString() + ",PromoOnType = " + PromoOnType + ",PromoOnId = " + PromoOnId.ToString() + ",PromoChargeType = " + PromoChargeType + ",Price = " + Price.ToString() + ",Percentage = " + Percentage.ToString() + ",SaleQty = " + SaleQty.ToString() + ",FreeType = " + FreeType + ",FreeTypeId = " + FreeTypeId.ToString() + ",FreeQty = " + FreeQty.ToString() + ",StartDate = " + StartDate.ToString() + ",EndDate = " + EndDate.ToString() + ",CreatedBy = " + CreatedBy.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",UpdatedBy = " + UpdatedBy.ToString() + ",UpdatedDate = " + UpdatedDate.ToString();
		}

	}
}
