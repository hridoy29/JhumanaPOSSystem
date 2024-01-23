using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class Supplier
    {
        private int m_iSupplierId;
        private string m_sSupplierName;
        private string m_sTradingAs;
        private string m_sABN;
        private string m_sAddress;
        private string m_sContactPerson;
        private string m_sPhoneNo;
        private string m_semail;
        private string m_swebadd;
        private string m_scomments;
        private DateTime m_dtEnteredTime;
        private int m_iEnteredBy;
        private DateTime m_dtUpdatedTime;
        private int m_iUpdatedBy;

        public Supplier()
        { 
        }

        public Supplier(int iSupplierId, string sSupplierName, string sTradingAs, string sABN, string sAddress, string sContactPerson, string sPhoneNo,string sEmail,string sWebadd,string sComments, DateTime dtEnteredTime, int iEnteredBy, DateTime dtUpdatedTime, int iUpdatedBy)
        {
            this.m_iSupplierId = iSupplierId;
            this.m_sSupplierName = sSupplierName;
            this.m_sTradingAs = sTradingAs;
            this.m_sABN = sABN;
            this.m_sAddress = sAddress;
            this.m_sPhoneNo = sPhoneNo;
            this.m_semail = sEmail;
            this.m_swebadd = sWebadd;
            this.m_scomments = sComments;
            this.m_sContactPerson = sContactPerson;
            this.m_dtEnteredTime = dtEnteredTime;
            this.m_iEnteredBy = iEnteredBy;
            this.m_dtUpdatedTime = dtUpdatedTime;
            this.m_iUpdatedBy = iUpdatedBy;
        }

        public int SupplierId
        {
            get
            {
                return m_iSupplierId;
            }
            set
            {
                m_iSupplierId = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return m_sSupplierName;
            }
            set
            {
                m_sSupplierName = value;
            }
        }

        public string TradingAs
        {
            get
            {
                return m_sTradingAs;
            }
            set
            {
                m_sTradingAs = value;
            }
        }

        public string Address
        {
            get
            {
                return m_sAddress;
            }
            set
            {
                m_sAddress = value;
            }
        }

        public string PhoneNo
        {
            get
            {
                return m_sPhoneNo;
            }
            set
            {
                m_sPhoneNo = value;
            }
        }

        public string Email
        {
            get
            {
                return m_semail;
            }
            set
            {
                m_semail = value;
            }
        }

        public string Webadd
        {
            get
            {
                return m_swebadd;
            }
            set
            {
                m_swebadd = value;
            }
        }

        public string Comments
        {
            get
            {
                return m_scomments;
            }
            set
            {
                m_scomments = value;
            }
        }

        public string ABN
        {
            get
            {
                return m_sABN;
            }
            set
            {
                m_sABN = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return m_sContactPerson;
            }
            set
            {
                m_sContactPerson = value;
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

        public int EnteredBy
        {
            get
            {
                return m_iEnteredBy;
            }
            set
            {
                m_iEnteredBy = value;
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

        public int UpdatedBy
        {
            get
            {
                return m_iUpdatedBy;
            }
            set
            {
                m_iUpdatedBy = value;
            }
        }
    }
}

