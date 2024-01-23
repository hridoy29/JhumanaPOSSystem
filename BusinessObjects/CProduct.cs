using System;
using System.Collections.Generic;
using System.Text;

namespace POSsible.BusinessObjects
{
    public class CProduct
    {
        private int m_iProductId;
        private int m_iDepartmentId;
        private string m_sBarcodeNo;
        private string m_sProductName;
        private string m_sProductDescription;
        private string m_sProductBrand;
        private string m_sProductMadeIn;
        private double m_dProductWeight;
        private bool m_bIsGstItem;
        private double m_dUnitCost;
        private double m_dUnitPrice;
        private double m_dPromoUnitPrice;
        private DateTime m_dtPromoStartDate;
        private DateTime m_dtPromoEndDate;
        private string m_sUnitMeasure;
        private int m_iUnitMeasureId;
        private double m_dQtyInStock;
        private double m_dQtyInorder;
        private double m_dMinQty;
        private byte[] m_iImage;
        private DateTime m_dtEnteredtime;
        private int m_iEnteredBy;
        private DateTime m_dtUpdatedTime;
        private int m_iUpdatedBy;
        private string m_sShortCode;
        private double m_dOpeningQty;
        private bool m_bExpirable;
        private bool m_bTicket;

        public CProduct()
        {

        }

        public CProduct(int iProductId, int iDepartmentId, string sBarcodeNo, string sProductName, string sProductDescription, string sProductBrand, string sProductMadeIn, double dProductWeight, bool bIsGstItem, double dUnitCost, double dUnitPrice, double dPromoUnitPrice, DateTime dtPromoStartDate, DateTime dtPromoEndDate, string sUnitMeasure, double dQtyInStock, double dQtyInorder, double dMinQty, byte[] iImage, DateTime dtEnteredtime, int iEnteredBy, DateTime dtUpdatedTime, int iUpdatedBy, string sShortCode, double dOpeningQty, bool bExpirable, bool bTicket)
        {
            this.m_iProductId = iProductId;
            this.m_iDepartmentId = iDepartmentId;
            this.m_sBarcodeNo = sBarcodeNo;
            this.m_sProductName = sProductName;
            this.m_sProductDescription = sProductDescription;
            this.m_sProductBrand = sProductBrand;
            this.m_sProductMadeIn = sProductMadeIn;
            this.m_dProductWeight = dProductWeight;
            this.m_bIsGstItem = bIsGstItem;
            this.m_dUnitCost = dUnitCost;
            this.m_dUnitPrice = dUnitPrice;
            this.m_dPromoUnitPrice = dPromoUnitPrice;
            this.m_dtPromoStartDate = dtPromoStartDate;
            this.m_dtPromoEndDate = dtPromoEndDate;
            this.m_sUnitMeasure = sUnitMeasure;
            this.m_dQtyInStock = dQtyInStock;
            this.m_dQtyInorder = dQtyInorder;
            this.m_dMinQty = dMinQty;
            this.m_iImage = iImage;
            this.m_dtEnteredtime = dtEnteredtime;
            this.m_iEnteredBy = iEnteredBy;
            this.m_dtUpdatedTime = dtUpdatedTime;
            this.m_iUpdatedBy = iUpdatedBy;
            this.m_sShortCode = sShortCode;
            this.m_dOpeningQty = dOpeningQty;
            this.m_bExpirable = bExpirable;
            this.m_bTicket = bTicket;
        }

        public int ProductId
        {
            get
            {
                return m_iProductId;
            }
            set
            {
                m_iProductId = value;
            }

        }

        public int DepartmentId
        {
            get
            {
                return m_iDepartmentId;
            }
            set
            {
                m_iDepartmentId = value;
            }

        }

        public string BarcodeNo
        {
            get
            {
                return m_sBarcodeNo;
            }
            set
            {
                m_sBarcodeNo = value;
            }
        }

        public string ProductName
        {
            get
            {
                return m_sProductName;
            }
            set
            {
                m_sProductName = value;
            }
        }

        public string ProductDescription
        {
            get
            {
                return m_sProductDescription;
            }
            set
            {
                m_sProductDescription = value;
            }

        }

        public string ProductBrand
        {
            get
            {
                return m_sProductBrand;
            }
            set
            {
                m_sProductBrand = value;
            }
        }

        public string ProductMadeIn
        {
            get
            {
                return m_sProductMadeIn;
            }
            set
            {
                m_sProductMadeIn = value;
            }
        }

        public double ProductWeight
        {
            get
            {
                return m_dProductWeight;
            }
            set
            {
                m_dProductWeight = value;
            }
        }

        public bool IsGstItem
        {
            get
            {
                return m_bIsGstItem;
            }
            set
            {
                m_bIsGstItem = value;
            }
        }

        public double UnitCost
        {
            get
            {
                return m_dUnitCost;
            }
            set
            {
                m_dUnitCost = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return m_dUnitPrice;
            }
            set
            {
                m_dUnitPrice = value;
            }
        }

        public double PromoUnitPrice
        {
            get
            {
                return m_dPromoUnitPrice;
            }
            set
            {
                m_dPromoUnitPrice = value;
            }
        }

        public DateTime PromoStartDate
        {
            get
            {
                return m_dtPromoStartDate;
            }
            set
            {
                if (value != DateTime.MinValue)
                    m_dtPromoStartDate = value;
            }
        }

        public DateTime PromoEndDate
        {
            get
            {
                return m_dtPromoEndDate;
            }
            set
            {
                if (value != DateTime.MinValue)
                    m_dtPromoEndDate = value;
            }
        }

        public string UnitMeasure
        {
            get
            {
                return m_sUnitMeasure;
            }
            set
            {
                m_sUnitMeasure = value;
            }
        }

        public int UnitMeasureId
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

        public double QtyInStock
        {
            get
            {
                return m_dQtyInStock;
            }
            set
            {
                m_dQtyInStock = value;
            }
        }

        public double QtyInorder
        {

            get
            {
                return m_dQtyInorder;
            }
            set
            {
                m_dQtyInorder = value;
            }
        }

        public double MinQty
        {
            get
            {
                return m_dMinQty;
            }
            set
            {
                m_dMinQty = value;
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

        public DateTime Enteredtime
        {
            get
            {
                return m_dtEnteredtime;
            }
            set
            {
                m_dtEnteredtime = value;
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

        public string ShortCode
        {
            get
            {
                return m_sShortCode;
            }
            set
            {
                m_sShortCode = value;
            }
        }

        public double OpeningQty
        {
            get
            {
                return m_dOpeningQty;
            }
            set
            {
                m_dOpeningQty = value;
            }
        }

        public bool IsExpirable
        {
            get
            {
                return m_bExpirable;
            }
            set
            {
                m_bExpirable = value;
            }
        }

        public bool Ticket
        {
            get
            {
                return m_bTicket;
            }
            set
            {
                m_bTicket = value;
            }
        }

        public void getNonScanId()
        {
            try
            {
                POSsible.Models.ProductModel productmodel = new POSsible.Models.ProductModel();
                m_sBarcodeNo = productmodel.getNonScanId();
            }
            catch (Exception xcp)
            {

            }
        }

    }
}
