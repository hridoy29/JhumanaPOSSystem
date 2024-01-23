using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CDepartment
    {
        private int m_iCategoryId;
        private string m_sDepartmentName;
        private string m_sDescription;
        private DateTime m_dtEnteredTime;
        private string m_sEnteredBy;
        private DateTime m_dtUpdatedTime;
        private string m_sUpdatedBy;
        private string m_iScanNonScanStatus;
        private CProduct m_oProduct=new CProduct();

        public CDepartment()
        { 
        
        }

        public CDepartment(int iCategoryId, string sDepartmentName, string sDescription, DateTime dtEnteredTime, string sEnteredBy, DateTime dtUpdatedTime, string sUpdatedBy,CProduct oProduct)
        { 
        this.m_iCategoryId=iCategoryId;
        this.m_sDepartmentName=sDepartmentName;
        this.m_sDescription=sDescription;
        this.m_dtEnteredTime=dtEnteredTime;
        this.m_sEnteredBy = sEnteredBy;
        this.m_dtUpdatedTime=dtUpdatedTime;
        this.m_sUpdatedBy=sUpdatedBy;
        this.m_oProduct = oProduct;
        }

        public int CategoryId
        {
            get
            {
                return m_iCategoryId;
            }
            set
            {
                m_iCategoryId = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return m_sDepartmentName;
            }
            set
            {
                m_sDepartmentName = value;
            }
        }

        public string Description
        {
            get
            {
                return m_sDescription;
            }
            set
            {
                m_sDescription = value;
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

        public string ScanNonScanStatus
        {
            get
            {
                return m_iScanNonScanStatus;
            }
            set
            {
                m_iScanNonScanStatus = value;
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

        public CProduct Product
        {
            get
            {
                return m_oProduct;
            }
            set
            {
                m_oProduct = value;
            }
        }

    }
}
