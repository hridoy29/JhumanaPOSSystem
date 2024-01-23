using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class Users
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool IsLoggedIn { get; set; }
		public Nullable<bool> HasAdminRight { get; set; }
		public Nullable<bool> HasRefundright { get; set; }
		public Nullable<bool> HasDiscountRight { get; set; }
		public Nullable<int> EnteredBy { get; set; }
		public DateTime EnteredTime { get; set; }
		public Nullable<int> UpdatedBy { get; set; }
		public Nullable<DateTime> UpdatedTime { get; set; }
		public Nullable<DateTime> DeactivatedTime { get; set; }
        public string EmployeeName { get; set; }
        public string storeName { get; set; }
        public int projectId { get; set; }
        public string  DesignationName { get; set; }
        public int CardAmtLgId { get; set; }

		public Users()
		{ }

		public Users(int UserId, string Name, string Password, string FirstName, string LastName, string Email, bool IsLoggedIn, Nullable<bool> HasAdminRight, Nullable<bool> HasRefundright, Nullable<bool> HasDiscountRight, Nullable<int> EnteredBy, DateTime EnteredTime, Nullable<int> UpdatedBy, Nullable<DateTime> UpdatedTime, Nullable<DateTime> DeactivatedTime)
		{
			this.UserId = UserId;
			this.Name = Name;
			this.Password = Password;
			this.FirstName = FirstName;
			this.LastName = LastName;
			this.Email = Email;
			this.IsLoggedIn = IsLoggedIn;
			this.HasAdminRight = HasAdminRight;
			this.HasRefundright = HasRefundright;
			this.HasDiscountRight = HasDiscountRight;
			this.EnteredBy = EnteredBy;
			this.EnteredTime = EnteredTime;
			this.UpdatedBy = UpdatedBy;
			this.UpdatedTime = UpdatedTime;
			this.DeactivatedTime = DeactivatedTime;
		}

		public override string ToString()
		{
			return "UserId = " + UserId.ToString() + ",Name = " + Name + ",Password = " + Password + ",FirstName = " + FirstName + ",LastName = " + LastName + ",Email = " + Email + ",IsLoggedIn = " + IsLoggedIn.ToString() + ",HasAdminRight = " + HasAdminRight.ToString() + ",HasRefundright = " + HasRefundright.ToString() + ",HasDiscountRight = " + HasDiscountRight.ToString() + ",EnteredBy = " + EnteredBy.ToString() + ",EnteredTime = " + EnteredTime.ToString() + ",UpdatedBy = " + UpdatedBy.ToString() + ",UpdatedTime = " + UpdatedTime.ToString() + ",DeactivatedTime = " + DeactivatedTime.ToString();
		}

	}
}
