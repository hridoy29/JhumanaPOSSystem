using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Bank
	{
		public int BankId { get; set; }
		public string BankName { get; set; }
		public Nullable<int> AccountLgId { get; set; }
		public string BankAddress { get; set; }
		public string BankPhone { get; set; }
		public int StoreId { get; set; }
		public Nullable<int> ProjectId { get; set; }

		public Bank()
		{ }

		public Bank(int BankId, string BankName, Nullable<int> AccountLgId, string BankAddress, string BankPhone, int StoreId, Nullable<int> ProjectId)
		{
			this.BankId = BankId;
			this.BankName = BankName;
			this.AccountLgId = AccountLgId;
			this.BankAddress = BankAddress;
			this.BankPhone = BankPhone;
			this.StoreId = StoreId;
			this.ProjectId = ProjectId;
		}

		public override string ToString()
		{
			return "BankId = " + BankId.ToString() + ",BankName = " + BankName + ",AccountLgId = " + AccountLgId.ToString() + ",BankAddress = " + BankAddress + ",BankPhone = " + BankPhone + ",StoreId = " + StoreId.ToString() + ",ProjectId = " + ProjectId.ToString();
		}

	}
}
