using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class TransactionPurpose
	{
		public int TransactionPurposeId { get; set; }
		public string TransactionPurposeName { get; set; }
		public string TransactionType { get; set; }
		public bool IsAuto { get; set; }
		public bool IsActive { get; set; }
		public int CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
        public string IsActiveString { get; set; }
        public int SL { get; set; }

		public TransactionPurpose()
		{ }

		public TransactionPurpose(int TransactionPurposeId, string TransactionPurposeName, string TransactionType, bool IsAuto, bool IsActive, int CreatorId, DateTime CreateDate)
		{
			this.TransactionPurposeId = TransactionPurposeId;
			this.TransactionPurposeName = TransactionPurposeName;
			this.TransactionType = TransactionType;
			this.IsAuto = IsAuto;
			this.IsActive = IsActive;
			this.CreatorId = CreatorId;
			this.CreateDate = CreateDate;
		}

		public override string ToString()
		{
			return "TransactionPurposeId = " + TransactionPurposeId.ToString() + ",TransactionPurposeName = " + TransactionPurposeName + ",TransactionType = " + TransactionType + ",IsAuto = " + IsAuto.ToString() + ",IsActive = " + IsActive.ToString() + ",CreatorId = " + CreatorId.ToString() + ",CreateDate = " + CreateDate.ToString();
		}

	}
}
