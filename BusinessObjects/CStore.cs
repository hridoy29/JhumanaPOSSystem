using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CStore
    {
        private int m_iStoreId;
        private string m_sStoreName;
        private string m_sStoreAddress;
        private string m_sPhoneNumber;
        private CProduct m_oProduct=new CProduct();
        private CDepartment m_oDepartment=new CDepartment();

        public CStore()
        { }

        public CStore(int iStoreId,string sStoreName,string sStoreAddress,string sPhoneNumber,CProduct oProduct,CDepartment oDepartment)
        { 

        this.m_iStoreId=iStoreId;
        this.m_sStoreName=sStoreName;
        this.m_sStoreAddress=sStoreAddress;
        this.m_sPhoneNumber=sPhoneNumber;
        this.m_oProduct=oProduct;
        this.m_oDepartment=oDepartment;
        }

        public int StoreId
        {
            get
            {
                return m_iStoreId;
            }
            set
            {
                m_iStoreId = value;
            }
        }

        public string StoreName
        {
            get
            {
                return m_sStoreName;
            }
            set
            {
                m_sStoreName = value;
            }
        }

        public string StoreAddress
        {
            get
            {
                return m_sStoreAddress;
            }
            set
            {
                m_sStoreAddress = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_sPhoneNumber;
            }
            set
            {
                m_sPhoneNumber = value;
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

        public CDepartment Department
        {
            get
            {
                return m_oDepartment;
            }
            set
            {
                m_oDepartment = value;
            }
        }


    }
}
