using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class RoleWisePermission
	{
		public Int64  PermissionId { get; set; }
		public Int32  RoleId { get; set; }
		public Int32  PageId { get; set; }
		public bool  CanCreate { get; set; }
		public bool  CanDelete { get; set; }
		public bool  CanUpdate { get; set; }
		public bool  CanSelect { get; set; }
		public Int32  AssignedBy { get; set; }
		public Int32  CompanyId { get; set; }
        public string PageName { get; set; }

		public RoleWisePermission()
		{ }

		public RoleWisePermission(Int64 PermissionId,Int32 RoleId,Int32 PageId,bool CanCreate,bool CanDelete,bool CanUpdate,bool CanSelect,Int32 AssignedBy,Int32 CompanyId)
		{
			this.PermissionId = PermissionId;
			this.RoleId = RoleId;
			this.PageId = PageId;
			this.CanCreate = CanCreate;
			this.CanDelete = CanDelete;
			this.CanUpdate = CanUpdate;
			this.CanSelect = CanSelect;
			this.AssignedBy = AssignedBy;
			this.CompanyId = CompanyId;
		}

		public override string ToString()
		{
			return "PermissionId = " + PermissionId.ToString() + ",RoleId = " + RoleId.ToString() + ",PageId = " + PageId.ToString() + ",CanCreate = " + CanCreate.ToString() + ",CanDelete = " + CanDelete.ToString() + ",CanUpdate = " + CanUpdate.ToString() + ",CanSelect = " + CanSelect.ToString() + ",AssignedBy = " + AssignedBy.ToString() + ",CompanyId = " + CompanyId.ToString();
		}

	}
}
