using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CUnitMeasurement
    {
        private int m_iUnitMeasureId;
        private string m_sUnitMeasureName;
        private DateTime m_dtEnteredTime;
        private string m_sEnteredBy;
        private DateTime m_dtUpdatedTime;
        private string m_sUpdatedBy;

        public CUnitMeasurement()
        { 
        
        }

        public CUnitMeasurement(int iUnitMeasureId, string sUnitMeasureName, DateTime dtEnteredTime, string sEnteredBy, DateTime dtUpdatedTime, string sUpdatedBy)
        {
            this.m_iUnitMeasureId = iUnitMeasureId;
            this.m_sUnitMeasureName = sUnitMeasureName;
            this.m_dtEnteredTime = dtEnteredTime;
            this.m_sEnteredBy = sEnteredBy;
            this.m_dtUpdatedTime = dtUpdatedTime;
            this.m_sUpdatedBy = sUpdatedBy;
        }

        public int Id
        {
            get
            {
                return m_iUnitMeasureId;
            }
            set
            {
                m_iUnitMeasureId = value;
            }
        }

        public string Name
        {
            get
            {
                return m_sUnitMeasureName;
            }
            set
            {
                m_sUnitMeasureName = value;
            }
        }

        public DateTime EnteredTime
        {
            get
            {
                return m_dtEnteredTime;
            }
            set
            {
                m_dtEnteredTime = value;
            }
        }

        public string EnteredBy
        {
            get
            {
                return m_sEnteredBy;
            }
            set
            {
                m_sEnteredBy = value;
            }
        }

        public DateTime UpdatedTime
        {
            get
            {
                return m_dtUpdatedTime;
            }
            set
            {
                m_dtUpdatedTime = value;
            }
        
        }

        public string UpdatedBy
        {
            get
            {
                return m_sUpdatedBy;
            }
            set
            {
                m_sUpdatedBy = value;
            }
        }
    }
}
