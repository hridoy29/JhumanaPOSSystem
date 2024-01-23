using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class AccountLedger
	{
		public int AccountLedgerId { get; set; }
		public Int64 AccountLedgerNo { get; set; }
		public string AccountLedgerName { get; set; }
		public int LedgerGroupId { get; set; }
		public int AccTransTypeId { get; set; }
		public Nullable<bool> BudgetEnable { get; set; }
		public Nullable<DateTime> OpeningBalanceOn { get; set; }
		public string CF1 { get; set; }
		public string CF2 { get; set; }
		public string CF3 { get; set; }
        public string AccTransTypeName { get; set; }
        public int LedgerGroupNo { get; set; }
        public string LedgerGroupName { get; set; }
        public string AccountLedgerNameWithNo { get; set; }
        public string ProjectName { get; set; }
        public decimal DrAmt { get; set; }
        public decimal CrAmt { get; set; }
        public Int64 TransactionId { get; set; }
        public string CLassName { get; set; }

        public decimal OpeningBalance { get; set; }


		public AccountLedger()
		{ }

        public AccountLedger(int AccountLedgerId, Int64 AccountLedgerNo, string AccountLedgerName, int LedgerGroupId, int AccTransTypeId, Nullable<bool> BudgetEnable, Nullable<DateTime> OpeningBalanceOn, string CF1, string CF2, string CF3, string AccTransTypeName, string LedgerGroupName, string AccountLedgerNameWithNo, string ProjectName, decimal DrAmt, decimal CrAmt, int LedgerGroupNo, Int64 TransactionId, string CLassName, decimal OpeningBalance)
        {
            this.AccountLedgerId = AccountLedgerId;
            this.AccountLedgerNo = AccountLedgerNo;
            this.AccountLedgerName = AccountLedgerName;
            this.LedgerGroupId = LedgerGroupId;
            this.AccTransTypeId = AccTransTypeId;
            this.BudgetEnable = BudgetEnable;
            this.OpeningBalanceOn = OpeningBalanceOn;
            this.CF1 = CF1;
            this.CF2 = CF2;
            this.CF3 = CF3;
            this.AccTransTypeName = AccTransTypeName;
            this.LedgerGroupName = LedgerGroupName;
            this.AccountLedgerNameWithNo = AccountLedgerNameWithNo;
            this.ProjectName = ProjectName;
            this.DrAmt = DrAmt;
            this.CrAmt = CrAmt;
            this.LedgerGroupNo = LedgerGroupNo;
            this.TransactionId = TransactionId;
            this.CLassName = CLassName;
            this.OpeningBalance = OpeningBalance;
        }

		public override string ToString()
		{
			return "AccountLedgerId = " + AccountLedgerId.ToString() + ",AccountLedgerNo = " + AccountLedgerNo.ToString() + ",AccountLedgerName = " + AccountLedgerName + ",LedgerGroupId = " + LedgerGroupId.ToString() + ",AccTransTypeId = " + AccTransTypeId.ToString() + ",BudgetEnable = " + BudgetEnable.ToString() + ",OpeningBalanceOn = " + OpeningBalanceOn.ToString() + ",CF1 = " + CF1 + ",CF2 = " + CF2 + ",CF3 = " + CF3;
		}

	}
}
