using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PurchaseReturn
	{
		public Int64 ReturnId { get; set; }
		public int StoreId { get; set; }
		public int PurchaseId { get; set; }
		public DateTime ReturnDate { get; set; }
		public string Remarks { get; set; }
		public Nullable<Double> TotReturnAmt { get; set; }
		public Nullable<int> ShiftId { get; set; }
		public Nullable<bool> IsApproved { get; set; }
		public Nullable<int> ApproveBy { get; set; }
		public Nullable<DateTime> ApproveDate { get; set; }
		public int CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Nullable<int> UpdatorId { get; set; }
		public Nullable<DateTime> UpdateDate { get; set; }

		public PurchaseReturn()
		{ }

		public PurchaseReturn(Int64 ReturnId, int StoreId, int PurchaseId, DateTime ReturnDate, string Remarks, Nullable<Double> TotReturnAmt, Nullable<int> ShiftId, Nullable<bool> IsApproved, Nullable<int> ApproveBy, Nullable<DateTime> ApproveDate, int CreatorId, DateTime CreateDate, Nullable<int> UpdatorId, Nullable<DateTime> UpdateDate)
		{
			this.ReturnId = ReturnId;
			this.StoreId = StoreId;
			this.PurchaseId = PurchaseId;
			this.ReturnDate = ReturnDate;
			this.Remarks = Remarks;
			this.TotReturnAmt = TotReturnAmt;
			this.ShiftId = ShiftId;
			this.IsApproved = IsApproved;
			this.ApproveBy = ApproveBy;
			this.ApproveDate = ApproveDate;
			this.CreatorId = CreatorId;
			this.CreateDate = CreateDate;
			this.UpdatorId = UpdatorId;
			this.UpdateDate = UpdateDate;
		}

		public override string ToString()
		{
			return "ReturnId = " + ReturnId.ToString() + ",StoreId = " + StoreId.ToString() + ",PurchaseId = " + PurchaseId.ToString() + ",ReturnDate = " + ReturnDate.ToString() + ",Remarks = " + Remarks + ",TotReturnAmt = " + TotReturnAmt.ToString() + ",ShiftId = " + ShiftId.ToString() + ",IsApproved = " + IsApproved.ToString() + ",ApproveBy = " + ApproveBy.ToString() + ",ApproveDate = " + ApproveDate.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CreateDate = " + CreateDate.ToString() + ",UpdatorId = " + UpdatorId.ToString() + ",UpdateDate = " + UpdateDate.ToString();
		}

	}
}
