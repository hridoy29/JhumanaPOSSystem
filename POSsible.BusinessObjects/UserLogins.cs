using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class UserLogins
	{
		public int UserLoginId { get; set; }
		public Nullable<int> ShiftId { get; set; }
		public int UserId { get; set; }
		public DateTime UserLoginTime { get; set; }
		public Nullable<DateTime> UserLogoutTime { get; set; }
		public string UserTerminal { get; set; }

		public UserLogins()
		{ }

		public UserLogins(int UserLoginId, Nullable<int> ShiftId, int UserId, DateTime UserLoginTime, Nullable<DateTime> UserLogoutTime, string UserTerminal)
		{
			this.UserLoginId = UserLoginId;
			this.ShiftId = ShiftId;
			this.UserId = UserId;
			this.UserLoginTime = UserLoginTime;
			this.UserLogoutTime = UserLogoutTime;
			this.UserTerminal = UserTerminal;
		}

		public override string ToString()
		{
			return "UserLoginId = " + UserLoginId.ToString() + ",ShiftId = " + ShiftId.ToString() + ",UserId = " + UserId.ToString() + ",UserLoginTime = " + UserLoginTime.ToString() + ",UserLogoutTime = " + UserLogoutTime.ToString() + ",UserTerminal = " + UserTerminal;
		}

	}
}
