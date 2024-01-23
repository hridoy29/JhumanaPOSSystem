using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class UnitMeasure
	{
		public int unitMeasureId { get; set; }
		public string UnitMeasureName { get; set; }
		public string UnitSymbol { get; set; }
		public Nullable<DateTime> enteredtime { get; set; }
		public string enteredby { get; set; }
		public Nullable<DateTime> updatedtime { get; set; }
		public string updatedby { get; set; }

		public UnitMeasure()
		{ }

		public UnitMeasure(int unitMeasureId, string UnitMeasureName, string UnitSymbol, Nullable<DateTime> enteredtime, string enteredby, Nullable<DateTime> updatedtime, string updatedby)
		{
			this.unitMeasureId = unitMeasureId;
			this.UnitMeasureName = UnitMeasureName;
			this.UnitSymbol = UnitSymbol;
			this.enteredtime = enteredtime;
			this.enteredby = enteredby;
			this.updatedtime = updatedtime;
			this.updatedby = updatedby;
		}

		public override string ToString()
		{
			return "unitMeasureId = " + unitMeasureId.ToString() + ",UnitMeasureName = " + UnitMeasureName + ",UnitSymbol = " + UnitSymbol + ",enteredtime = " + enteredtime.ToString() + ",enteredby = " + enteredby + ",updatedtime = " + updatedtime.ToString() + ",updatedby = " + updatedby;
		}

	}
}
