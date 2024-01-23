using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CCompany
    {


        private int m_sCompanycode;
        private string m_CompanyName;
        private string m_ABN;
        private string m_AddressLine1;
        private string m_AddressLine2;
        private string m_City;
        private string m_State;
        private string m_CountryName;
        private string m_PostCode;
        private string m_Phone;
        private string m_Fax;
        private string m_Email;
        private string m_Web;
        private string m_MissionStatement;
        private byte[] m_iImage;
        private DateTime m_enteredTime;
        private string m_ienteredBy;
        private DateTime m_updatedTime;
        private string m_iupdatedBy;



        public int Companycode
        {
            get
            {
                return m_sCompanycode;
            }
            set
            {
                m_sCompanycode = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return m_CompanyName;
            }
            set
            {
                m_CompanyName = value;
            }
        }
        
        public string ABN
        {
            get
            {
                return m_ABN;
            }
            set
            {
                m_ABN = value;
            }
        }

        public string AddressLine1
        {
            get
            {
                return m_AddressLine1;
            }
            set
            {
                m_AddressLine1 = value;
            }
        }

        public string AddressLine2
        {
            get
            {
                return m_AddressLine2;
            }
            set
            {
                m_AddressLine2 = value;
            }
        }

        
        public string City
        {
            get
            {
                return m_City;
            }
            set
            {
                m_City = value;
            }
        }

        public string State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        public string CountryName
        {
            get
            {
                return m_CountryName;
            }
            set
            {
                m_CountryName = value;
            }
        }
        
        public string PostCode
        {
            get
            {
                return m_PostCode;
            }
            set
            {
                m_PostCode = value;
            }
        }

        public string Phone
        {
            get
            {
                return m_Phone;
            }
            set
            {
                m_Phone = value;
            }
        }
        
        public string Fax
        {
            get
            {
                return m_Fax;
            }
            set
            {
                m_Fax = value;
            }
        }

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }

        public string Web
        {
            get
            {
                return m_Web;
            }
            set
            {
                m_Web = value;
            }
        }
        
        public string MissionStatement
        {
            get
            {
                return m_MissionStatement;
            }
            set
            {
                m_MissionStatement = value;
            }
        }

        public byte[] Image
        {
            get
            {
                return m_iImage;
            }
            set
            {
                m_iImage = value;
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

        public string EnteredBy
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
