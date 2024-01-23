using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Roles
	{
		public Int32  RoleId { get; set; }
		public string  RoleName { get; set; }
		public string  LoweredRoleName { get; set; }
		public string  Description { get; set; }
		public Int32  CompanyId { get; set; }
        public string CompanyName { get; set; }

		public Roles()
		{ }

        public Roles(Int32 RoleId, string RoleName, string LoweredRoleName, string Description, Int32 CompanyId, string CompanyName)
		{
			this.RoleId = RoleId;
			this.RoleName = RoleName;
			this.LoweredRoleName = LoweredRoleName;
			this.Description = Description;
			this.CompanyId = CompanyId;
            this.CompanyName = CompanyName;
		}

		public override string ToString()
		{
			return "RoleId = " + RoleId.ToString() + ",RoleName = " + RoleName + ",LoweredRoleName = " + LoweredRoleName + ",Description = " + Description + ",CompanyId = " + CompanyId.ToString();
		}

	}
}
