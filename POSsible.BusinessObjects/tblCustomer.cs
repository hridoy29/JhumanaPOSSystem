using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class tblCustomer
	{
		public int customerId { get; set; }
		public string Name { get; set; }
		public string street_no { get; set; }
		public string suburb { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string postcode { get; set; }
		public string country { get; set; }
		public string mobile { get; set; }
		public string homephone { get; set; }
		public Nullable<bool> sex { get; set; }
		public string workphone { get; set; }
		public Nullable<DateTime> enteredtime { get; set; }
		public Nullable<long> enteredby { get; set; }
		public Nullable<DateTime> updatedtime { get; set; }
		public Nullable<long> updatedby { get; set; }
        public double DueBalance { get; set; }
        public string NameAndNo { get; set; }

		public tblCustomer()
		{ }

		public tblCustomer(int customerId, string Name, string street_no, string suburb, string city, string state, string postcode, string country, string mobile, string homephone, Nullable<bool> sex, string workphone, Nullable<DateTime> enteredtime, Nullable<long> enteredby, Nullable<DateTime> updatedtime, Nullable<long> updatedby)
		{
			this.customerId = customerId;
			this.Name = Name;
			this.street_no = street_no;
			this.suburb = suburb;
			this.city = city;
			this.state = state;
			this.postcode = postcode;
			this.country = country;
			this.mobile = mobile;
			this.homephone = homephone;
			this.sex = sex;
			this.workphone = workphone;
			this.enteredtime = enteredtime;
			this.enteredby = enteredby;
			this.updatedtime = updatedtime;
			this.updatedby = updatedby;
		}

		public override string ToString()
		{
			return "customerId = " + customerId.ToString() + ",Name = " + Name + ",street_no = " + street_no + ",suburb = " + suburb + ",city = " + city + ",state = " + state + ",postcode = " + postcode + ",country = " + country + ",mobile = " + mobile + ",homephone = " + homephone + ",sex = " + sex.ToString() + ",workphone = " + workphone + ",enteredtime = " + enteredtime.ToString() + ",enteredby = " + enteredby.ToString() + ",updatedtime = " + updatedtime.ToString() + ",updatedby = " + updatedby.ToString();
		}

	}
}
