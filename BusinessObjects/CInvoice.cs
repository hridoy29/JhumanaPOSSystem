using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CInvoice
    {
        private int m_iInvoiceId;
        private int m_iShiftId;
        private int m_iUserId;
        private int m_iCustomerId;
        private DateTime m_dtInvoiceDate;
        private double m_dTotalPrice;
        private double m_dTotalGst;
        private double m_dChangeGiven;
        private double m_sDiscountGiven;
        private int m_iDisCountAuthorizedId;
        private string m_sDescription;      
        private string m_sStatus;
        private DateTime m_dtUpdatedTime;
        private string m_sUpdatedBy;
        private double m_dCardAmount;
        private double m_dCashAmount;
        private int m_iPaymentType;
        private int m_iPaymentMethodId;
        private DateTime m_dtEnteredTime;
        private List<CProduct> m_oProduct;
        private double m_dReturnQuantity;
        private string m_sCustomerBarCode;

        private string m_sRefundMethod;

        private string m_sUserName;

        public CInvoice()
        { }

        public CInvoice(int iInvoiceId, int iShiftId, int iUserId, int iCustomerId, DateTime dtInvoiceDate, double dTotalPrice, double dTotalGst, double dChangeGiven, double sDiscountGiven, int iDisCountAuthorizedId, string sDescription, string sStatus, DateTime dtUpdatedTime, string sUpdatedBy, double dCardAmount, double dCashAmount, int iPaymentType, int iPaymentMethodId, DateTime dtEnteredTime, List<CProduct> oProduct, double dReturnQuantity, string sRefundMethod, string sCustomerBarCode)
        {
            this.m_iInvoiceId = iInvoiceId;
            this.m_iShiftId = iShiftId;
            this.m_iUserId = iUserId;
            this.m_iCustomerId = iCustomerId;
            this.m_dtInvoiceDate = dtInvoiceDate;
            this.m_dTotalPrice = dTotalPrice;
            this.m_dTotalGst = dTotalGst;
            this.m_dChangeGiven = dChangeGiven;
            this.m_sDiscountGiven = sDiscountGiven;
            this.m_iDisCountAuthorizedId = iDisCountAuthorizedId;
            this.m_sDescription = sDescription;
            this.m_sStatus = sStatus;
            this.m_dtUpdatedTime = dtUpdatedTime;
            this.m_sUpdatedBy = sUpdatedBy;
            this.m_dCardAmount = dCardAmount;
            this.m_dCashAmount = dCashAmount;
            this.m_iPaymentType = iPaymentType;
            this.m_iPaymentMethodId = iPaymentMethodId;
            this.m_dtEnteredTime = dtEnteredTime;
            this.m_oProduct = oProduct;
            this.m_dReturnQuantity = dReturnQuantity;
            this.m_sRefundMethod = sRefundMethod;
            this.m_sCustomerBarCode = sCustomerBarCode;
        }

        public int InvoiceId
        {
            get
            {
                return m_iInvoiceId;
            }
            set
            {
                m_iInvoiceId=value;
            }
        }

        public int ShiftId
        {
            get
            {
                return m_iShiftId;
            }
            set
            {
                m_iShiftId = value;
            }
        }

        public int UserId
        {
            get
            {
                return m_iUserId;
            }
            set
            {
                m_iUserId=value;
            }
        }

        public int CustomerId
        {
            get
            {
                return m_iCustomerId;
            }
            set
            {
                m_iCustomerId=value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return m_dtInvoiceDate;
            }
            set
            {
                m_dtInvoiceDate=value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return m_dTotalPrice;
            }
            set
            {
                m_dTotalPrice=value;
            }
        }

        public double TotalGst
        {
            get
            {
                return m_dTotalGst;
            }
            set
            {
                m_dTotalGst=value;
            }
        }

        public double ChangeGiven
        {
            get
            {
                return m_dChangeGiven;
            }
            set
            {
                m_dChangeGiven=value;
            }
        }

        public double DiscountGiven
        {
            get
            {
                return m_sDiscountGiven;
            }
            set
            {
                m_sDiscountGiven=value;
            }
        }

        public int DisCountAuthorizedId
        {
            get
            {
                return m_iDisCountAuthorizedId;
            }
            set
            {
                m_iDisCountAuthorizedId=value;
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
                m_sDescription=value;
            }
        }

        public string Status
        {
            get
            {
                return m_sStatus;
            }
            set
            {
                m_sStatus=value;
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
                m_dtUpdatedTime=value;
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
                m_sUpdatedBy=value;
            }
        }

        public double CardAmount
        {
            get
            {
                return m_dCardAmount;
            }
            set
            {
                m_dCardAmount = value;
            }
        }

        public double CashAmount
        {
            get
            {
                return m_dCashAmount;
            }
            set
            {
                m_dCashAmount = value;
            }
        }

        public int PaymentType
        {
            get
            {
                return m_iPaymentType;
            }
            set
            {
                m_iPaymentType = value;
            }
        }

        public int PaymentMethodId
        {
            get
            {
                return m_iPaymentMethodId;
            }
            set
            {
                m_iPaymentMethodId = value;
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

        public List<CProduct> Product
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

        public double ReturnQuantity
        {

            get
            {
                return m_dReturnQuantity;
            }
            set
            {
                m_dReturnQuantity = value;
            }
        }

        public string RefundMethod
        {
            get
            {
                return m_sRefundMethod;
            }
            set
            {
                m_sRefundMethod = value;
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

        public string UserName
        {
            get
            {
                return m_sUserName;
            }
            set
            {
                m_sUserName = value;
            }
        }
    }
}
