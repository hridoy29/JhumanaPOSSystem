using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Employee
	{
		public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveString { get; set; }
        public int SL { get; set; }

		public Employee()
		{ }

        public Employee(int EmployeeId, string EmployeeName, bool IsActive)
		{
			this.EmployeeId = EmployeeId;
			this.EmployeeName = EmployeeName;
            this.IsActive = IsActive;
        }
	}
}
