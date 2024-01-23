using System;
using System.Text;

namespace POSsible.BusinessObjects
{
    [Serializable()]
    public class Product
    {
        public int productId { get; set; }
        public int categorytId { get; set; }
        public string barcodeNo { get; set; }
        public string name { get; set; }
        public string shortcode { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public string madeIn { get; set; }
        public Nullable<Double> weight { get; set; }
        public Nullable<bool> isGstItem { get; set; }
        public Nullable<bool> isexpireable { get; set; }
        public Nullable<bool> ticketType { get; set; }
        public Nullable<Double> unitCost { get; set; }
        public Nullable<Double> unitPrice { get; set; }
        public Nullable<Double> promoUnitPrice { get; set; }
        public Nullable<DateTime> promoStartDate { get; set; }
        public Nullable<DateTime> promoEndDate { get; set; }
        public int unitMeasureId { get; set; }
        public Nullable<Double> qtyInStock { get; set; }
        public Nullable<Double> qtyInOrder { get; set; }
        public Nullable<Double> minQty { get; set; }
        public Byte[] ProductImage { get; set; }
        public Nullable<DateTime> enteredtime { get; set; }
        public Nullable<int> enteredby { get; set; }
        public Nullable<DateTime> updatedtime { get; set; }
        public Nullable<int> updatedby { get; set; }
        public string UnitMeasureName { get; set; }
        public string Bar_Name { get; set; }

        public Product()
        { }

        public Product(int productId, int categorytId, string barcodeNo, string name, string shortcode, string description, string brand, string madeIn, Nullable<Double> weight, Nullable<bool> isGstItem, Nullable<bool> isexpireable, Nullable<bool> ticketType, Nullable<Double> unitCost, Nullable<Double> unitPrice, Nullable<Double> promoUnitPrice, Nullable<DateTime> promoStartDate, Nullable<DateTime> promoEndDate, int unitMeasureId, Nullable<Double> qtyInStock, Nullable<Double> qtyInOrder, Nullable<Double> minQty, Byte[] ProductImage, Nullable<DateTime> enteredtime, Nullable<int> enteredby, Nullable<DateTime> updatedtime, Nullable<int> updatedby)
        {
            this.productId = productId;
            this.categorytId = categorytId;
            this.barcodeNo = barcodeNo;
            this.name = name;
            this.shortcode = shortcode;
            this.description = description;
            this.brand = brand;
            this.madeIn = madeIn;
            this.weight = weight;
            this.isGstItem = isGstItem;
            this.isexpireable = isexpireable;
            this.ticketType = ticketType;
            this.unitCost = unitCost;
            this.unitPrice = unitPrice;
            this.promoUnitPrice = promoUnitPrice;
            this.promoStartDate = promoStartDate;
            this.promoEndDate = promoEndDate;
            this.unitMeasureId = unitMeasureId;
            this.qtyInStock = qtyInStock;
            this.qtyInOrder = qtyInOrder;
            this.minQty = minQty;
            this.ProductImage = ProductImage;
            this.enteredtime = enteredtime;
            this.enteredby = enteredby;
            this.updatedtime = updatedtime;
            this.updatedby = updatedby;
        }



    }
}
