using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class Customer
    {

        private int m_iCustomerId;
        private string m_sCustomerBarCode;
        private string m_sCustomerName;
        private string m_street_no;
        private string m_ssuburb;
        private string m_sstate;
        private string m_spostcode;
        private string m_scountry;
        private string m_smobile;
        private string m_shomephone;
        private string m_sworkphone;
        private int m_isex;
        private DateTime m_dtEnteredTime;
        private int m_iEnteredBy;
        private DateTime m_dtUpdatedTime;
        private int m_iUpdatedBy;

        public Customer()
        { 
        }

        public Customer(int iCustomerId,string sCustomerBarCode, string sCustomerName, string street_no, string ssuburb,  string sstate, string spostcode, string scountry,string smobile, string shomephone, string sworkphone,int isex, DateTime dtEnteredTime, int iEnteredBy, DateTime dtUpdatedTime, int iUpdatedBy)
        {
            this.m_iCustomerId = iCustomerId;
            this.m_sCustomerBarCode = sCustomerBarCode;
            this.m_sCustomerName = sCustomerName;
            this.m_street_no = street_no;
            this.m_ssuburb = ssuburb;
            this.m_sstate = sstate;
            this.m_spostcode = spostcode;
            this.m_scountry=scountry;
            this.m_smobile=smobile;
            this.m_shomephone=shomephone;
            this.m_sworkphone=sworkphone;
            this.m_isex = isex;
            this.m_dtEnteredTime = dtEnteredTime;
            this.m_iEnteredBy = iEnteredBy;
            this.m_dtUpdatedTime = dtUpdatedTime;
            this.m_iUpdatedBy = iUpdatedBy;
        }

        public int CustomerId
        {
            get
            {
                return m_iCustomerId;
            }
            set
            {
                m_iCustomerId = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return m_sCustomerName;
            }
            set
            {
                m_sCustomerName = value;
            }
        }

        public string CustomerBarCode
        {
            get
            {
                return m_sCustomerBarCode;
            }
            set
            {
                m_sCustomerBarCode = value;
            }
        }

        public string Street_no
        {
            get
            {
                return m_street_no;
            }
            set
            {
                m_street_no = value;
            }
        }

        public string Suburb
        {
            get
            {
                return m_ssuburb;
            }
            set
            {
                m_ssuburb = value;
            }
        }

        
        public string State
        {
            get
            {
                return m_sstate;
            }
            set
            {
                m_sstate = value;
            }
        }

        public string Postcode
        {
            get
            {
                return m_spostcode;
            }
            set
            {
                m_spostcode = value;
            }
        }

        public string Country
        {
            get
            {
                return m_scountry;
            }
            set
            {
                m_scountry = value;
            }
        }

        public string Mobile
        {
            get
            {
                return m_smobile;
            }
            set
            {
                m_smobile = value;
            }
        }

        public string Homephone
        {
            get
            {
                return m_shomephone;
            }
            set
            {
                m_shomephone = value;
            }
        }
        public string Workphone
        {
            get
            {
                return m_sworkphone;
            }
            set
            {
                m_sworkphone = value;
            }
        }

        public int Sex
        {
            get
            {
                return m_isex;
            }
            set
            {
                m_isex = value;
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
