using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Store
	{
		public int StoreId { get; set; }
		public string StoreName { get; set; }
		public string StoreAddress { get; set; }
		public string PhoneNo { get; set; }
		public string Email { get; set; }
		public int ProjectId { get; set; }
		public int CompanyId { get; set; }
		public string Mobile { get; set; }
		public string ContactPerson { get; set; }
		public string StoreCF1 { get; set; }
		public string StoreCF2 { get; set; }
		public string StoreCF3 { get; set; }

		public Store()
		{ }

		public Store(int StoreId, string StoreName, string StoreAddress, string PhoneNo, string Email, int ProjectId, int CompanyId, string Mobile, string ContactPerson, string StoreCF1, string StoreCF2, string StoreCF3)
		{
			this.StoreId = StoreId;
			this.StoreName = StoreName;
			this.StoreAddress = StoreAddress;
			this.PhoneNo = PhoneNo;
			this.Email = Email;
			this.ProjectId = ProjectId;
			this.CompanyId = CompanyId;
			this.Mobile = Mobile;
			this.ContactPerson = ContactPerson;
			this.StoreCF1 = StoreCF1;
			this.StoreCF2 = StoreCF2;
			this.StoreCF3 = StoreCF3;
		}

		public override string ToString()
		{
			return "StoreId = " + StoreId.ToString() + ",StoreName = " + StoreName + ",StoreAddress = " + StoreAddress + ",PhoneNo = " + PhoneNo + ",Email = " + Email + ",ProjectId = " + ProjectId.ToString() + ",CompanyId = " + CompanyId.ToString() + ",Mobile = " + Mobile + ",ContactPerson = " + ContactPerson + ",StoreCF1 = " + StoreCF1 + ",StoreCF2 = " + StoreCF2 + ",StoreCF3 = " + StoreCF3;
		}

	}
}
