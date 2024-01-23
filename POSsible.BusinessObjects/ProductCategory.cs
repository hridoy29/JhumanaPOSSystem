using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class ProductCategory
	{
		public int categoryId { get; set; }
		public string deptName { get; set; }
		public string description { get; set; }
		public string CodePrefix { get; set; }
		public Nullable<int> ParentId { get; set; }
		public Nullable<DateTime> enteredtime { get; set; }
		public Nullable<int> enteredby { get; set; }
		public Nullable<DateTime> updatedtime { get; set; }
		public Nullable<int> updatedby { get; set; }

		public ProductCategory()
		{ }

		public ProductCategory(int categoryId, string deptName, string description, string CodePrefix, Nullable<int> ParentId, Nullable<DateTime> enteredtime, Nullable<int> enteredby, Nullable<DateTime> updatedtime, Nullable<int> updatedby)
		{
			this.categoryId = categoryId;
			this.deptName = deptName;
			this.description = description;
			this.CodePrefix = CodePrefix;
			this.ParentId = ParentId;
			this.enteredtime = enteredtime;
			this.enteredby = enteredby;
			this.updatedtime = updatedtime;
			this.updatedby = updatedby;
		}

		public override string ToString()
		{
			return "categoryId = " + categoryId.ToString() + ",deptName = " + deptName + ",description = " + description + ",CodePrefix = " + CodePrefix + ",ParentId = " + ParentId.ToString() + ",enteredtime = " + enteredtime.ToString() + ",enteredby = " + enteredby.ToString() + ",updatedtime = " + updatedtime.ToString() + ",updatedby = " + updatedby.ToString();
		}

	}
}
