using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CCustomerInvoice
    {
        private string m_sCustomerBarcode;
        private int m_iinvoiceId;
        private DateTime m_invoiceDate;
        private float m_finvoiceAmount;
        private float m_fpointsEarned;
        private DateTime m_enteredTime;
        private string m_ienteredBy;
        private DateTime m_updatedTime;
        private string m_iupdatedBy;
        private string m_name;
        private string m_address;
        private string m_mobile;
        private string m_homephone;
        private string m_sex;
        private List<CCustomerInvoice> m_ocustomerInvoice;

        public List<CCustomerInvoice> CustomerInvoiceList
        {
            get
            {
                return m_ocustomerInvoice;
            }
            set
            {
                m_ocustomerInvoice = value;
            }
        }


        public string CustomerBarCode
        {
            get
            {
                return m_sCustomerBarcode;
            }
            set
            {
                m_sCustomerBarcode = value;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public string Address
        {
            get
            {
                return m_address;
            }
            set
            {
                m_address = value;
            }
        }

        public string Mobile
        {
            get
            {
                return m_mobile;
            }
            set
            {
                m_mobile = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return m_homephone;
            }
            set
            {
                m_homephone = value;
            }
        }

        public string Sex
        {
            get
            {
                return m_sex;
            }
            set
            {
                m_sex = value;
            }
        }

        public int InvoiceId
        {
            get
            {
                return m_iinvoiceId;
            }
            set
            {
                m_iinvoiceId = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return m_invoiceDate;
            }
            set
            {
                m_invoiceDate = value;
            }
        }

        public float InvoiceAmount
        {
            get
            {
                return m_finvoiceAmount;
            }
            set
            {
                m_finvoiceAmount = value;
            }
        }

        public float PointsEarned
        {
            get
            {
                return m_fpointsEarned;
            }
            set
            {
                m_fpointsEarned = value;
            }
        }

        public DateTime EnteredTime
        {
            get
            {
                return m_enteredTime;
            }
            set
            {
                m_enteredTime = value;
            }
        }

        public string  EnteredBy
        {
            get
            {
                return m_ienteredBy;
            }
            set
            {
                m_ienteredBy = value;
            }
        }

        public DateTime UpdatedTime
        {
            get
            {
                return m_updatedTime;
            }
            set
            {
                m_updatedTime = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return m_iupdatedBy;
            }
            set
            {
                m_iupdatedBy = value;
            }
        }

    }
}
