using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class ProjectInfo
	{
		public int ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string Address { get; set; }
		public string ContactNo { get; set; }
		public string FaxNo { get; set; }
		public string EmailAdress { get; set; }
		public string ProjectURL { get; set; }
		public string ProjectType { get; set; }
		public string GroupName { get; set; }
		public Nullable<int> VoucherMode { get; set; }
		public Nullable<int> VoucherEntryMode { get; set; }
		public string LedgerIdSeparator { get; set; }
		public string Chairman { get; set; }
		public string MD { get; set; }
		public string Director { get; set; }
		public Byte[] Logo { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }

        public string VoucherModeName { get; set; }

		public ProjectInfo()
		{ }

        public ProjectInfo(int ProjectId, string ProjectName, string Address, string ContactNo, string FaxNo, string EmailAdress, string ProjectURL, string ProjectType, string GroupName, Nullable<int> VoucherMode, Nullable<int> VoucherEntryMode, string LedgerIdSeparator, string Chairman, string MD, string Director, Byte[] Logo, string CF1, string CF2, string CF3, string VoucherModeName)
		{
			this.ProjectId = ProjectId;
			this.ProjectName = ProjectName;
			this.Address = Address;
			this.ContactNo = ContactNo;
			this.FaxNo = FaxNo;
			this.EmailAdress = EmailAdress;
			this.ProjectURL = ProjectURL;
			this.ProjectType = ProjectType;
			this.GroupName = GroupName;
			this.VoucherMode = VoucherMode;
			this.VoucherEntryMode = VoucherEntryMode;
			this.LedgerIdSeparator = LedgerIdSeparator;
			this.Chairman = Chairman;
			this.MD = MD;
			this.Director = Director;
			this.Logo = Logo;
			this.CF1 = CF1;
			this.CF2 = CF2;
			this.CF3 = CF3;
            this.VoucherModeName = VoucherModeName;
		}

		public override string ToString()
		{
			return "ProjectId = " + ProjectId.ToString() + ",ProjectName = " + ProjectName + ",Address = " + Address + ",ContactNo = " + ContactNo + ",FaxNo = " + FaxNo + ",EmailAdress = " + EmailAdress + ",ProjectURL = " + ProjectURL + ",ProjectType = " + ProjectType + ",GroupName = " + GroupName + ",VoucherMode = " + VoucherMode.ToString() + ",VoucherEntryMode = " + VoucherEntryMode.ToString() + ",LedgerIdSeparator = " + LedgerIdSeparator + ",Chairman = " + Chairman + ",MD = " + MD + ",Director = " + Director + ",Logo = " + Logo.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
