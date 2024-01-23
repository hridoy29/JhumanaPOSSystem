using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Supplier
	{
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }
		public string TradingAs { get; set; }
		public string ABN { get; set; }
		public string SupplierAddress { get; set; }
		public string ContactName { get; set; }
		public string PhoneNo { get; set; }
		public string email { get; set; }
		public string webadd { get; set; }
		public string comments { get; set; }
		public string Fax { get; set; }
		public string CivilId { get; set; }
		public string GLCode { get; set; }
		public Nullable<int> EnteredBy { get; set; }
		public Nullable<DateTime> EnteredTime { get; set; }
		public Nullable<int> UpdatedBy { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }

		public Supplier()
		{ }

		public Supplier(int SupplierId, string SupplierName, string TradingAs, string ABN, string SupplierAddress, string ContactName, string PhoneNo, string email, string webadd, string comments, string Fax, string CivilId, string GLCode, Nullable<int> EnteredBy, Nullable<DateTime> EnteredTime, Nullable<int> UpdatedBy, Nullable<DateTime> UpdatedTime)
		{
			this.SupplierId = SupplierId;
			this.SupplierName = SupplierName;
			this.TradingAs = TradingAs;
			this.ABN = ABN;
			this.SupplierAddress = SupplierAddress;
			this.ContactName = ContactName;
			this.PhoneNo = PhoneNo;
			this.email = email;
			this.webadd = webadd;
			this.comments = comments;
			this.Fax = Fax;
			this.CivilId = CivilId;
			this.GLCode = GLCode;
			this.EnteredBy = EnteredBy;
			this.EnteredTime = EnteredTime;
			this.UpdatedBy = UpdatedBy;
			this.UpdatedTime = UpdatedTime;
		}

		public override string ToString()
		{
			return "SupplierId = " + SupplierId.ToString() + ",SupplierName = " + SupplierName + ",TradingAs = " + TradingAs + ",ABN = " + ABN + ",SupplierAddress = " + SupplierAddress + ",ContactName = " + ContactName + ",PhoneNo = " + PhoneNo + ",email = " + email + ",webadd = " + webadd + ",comments = " + comments + ",Fax = " + Fax + ",CivilId = " + CivilId + ",GLCode = " + GLCode + ",EnteredBy = " + EnteredBy.ToString() + ",EnteredTime = " + EnteredTime.ToString() + ",UpdatedBy = " + UpdatedBy.ToString() + ",UpdatedTime = " + UpdatedTime.ToString();
		}

	}
}
