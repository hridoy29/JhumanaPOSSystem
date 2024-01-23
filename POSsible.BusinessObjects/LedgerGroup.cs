using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class LedgerGroup
	{
		public int LedgerGroupId { get; set; }
		public int LedgerGroupNo { get; set; }
		public string LedgerGroupName { get; set; }
		public int ClassId { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }

        public string CLassName { get; set; }        

		public LedgerGroup()
		{ }

        public LedgerGroup(int LedgerGroupId, int LedgerGroupNo, string LedgerGroupName, int ClassId, string CF1, string CF2, string CLassName)
		{
			this.LedgerGroupId = LedgerGroupId;
			this.LedgerGroupNo = LedgerGroupNo;
			this.LedgerGroupName = LedgerGroupName;
			this.ClassId = ClassId;
			this.CF1 = CF1;
			this.CF2 = CF2;
            this.CLassName = CLassName;
		}

		public override string ToString()
		{
			return "LedgerGroupId = " + LedgerGroupId.ToString() + ",LedgerGroupNo = " + LedgerGroupNo.ToString() + ",LedgerGroupName = " + LedgerGroupName + ",ClassId = " + ClassId.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2;
		}

	}
}
