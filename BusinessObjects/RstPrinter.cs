using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.VisualBasic;


namespace POSsible.BusinessObjects
{
    class RstPrinter
    {

         public class printdoc:PrintDocument 
         {
             //variable declaration
             //headrer declaration
             static int intCurrentChar;
             private string str_Head_StoreName;
             private string str_Head_StoreType;
             private string str_Head_StoreAddress;
             private string str_Head_StoreABN;
             //Body Declaration
             private string str_BodyTitle;
             private  string str_DollarHead ;
             private  string str_ItemHead ;
             private  string str_ItemQtyHead ;
             private  string str_ItemSymbolHead ;
             private  string str_ItemUnitPriceHead ;
             private  string str_ItemSubtotalHead ;
             //item Declaration
             private  string str_Item;
             private  string str_ItemQty;
             private  string str_ItemSymbol;
             private  string str_ItemUnitPrice;
             private   string str_ItemSubtotal;
             // Dot line print
             private    string str_lineDivide;
            //Item Sub Total Description
             private   string str_AmountDescription;
             private   string str_DollerItemSymbol;
             private   string str_Total;
             //Item Discount Detail
             private  string str_DiscountDetail;
             private  string str_DiscountPrice;
             //Item Grand Total
             private  String str_NetTotalDescription;
             private  string str_NetTotalPrice;
             //Purchase Date and time
             private   string str_DateTime ;
             // Footer SetUp

             private  string str_footer1 ;
             private  string str_footer2 ;
             private  string str_footer3 ;
             private  string str_footer4;
             private  string str_footer5;
             private  string str_footer6;
             private char[] sep={'\n'};

             private Bitmap bmpLogo;

//Font Declaration

             //headrer declaration
             private Font fnt_Head_StoreName;
             private Font fnt_Head_StoreType;
             private Font  fnt_Head_StoreAddress;
             private Font fnt_Head_StoreABN;
             //Body Declaration
             private Font fnt_BodyTitle ;
             private Font fnt_DollarHead ;
             private Font fnt_ItemHead ;
             private Font fnt_ItemQtyHead ;
             private Font fnt_ItemSymbolHead ;
             private Font fnt_ItemUnitPriceHead ;
             private Font fnt_ItemSubtotalHead ;
             //item Declaration
             private Font fnt_Item;
             private Font fnt_ItemQty;
             private Font fnt_ItemSymbol;
             private Font fnt_ItemUnitPrice;
             private Font fnt_ItemSubtotal;
             // Dot line print
             private Font fnt_lineDivide;
             //Item Sub Total Description
             private Font fnt_AmountDescription;
             private Font fnt_DollerItemSymbol;
             private Font fnt_Total;
             //Item Discount Detail
             private Font fnt_DiscountDetail;
             private Font fnt_DiscountPrice;
             //Item Grand Total
             private Font fnt_NetTotalDescription;
             private Font fnt_NetTotalPrice;
             //Purchase Date and time
             private Font fnt_DateTime;
             // Footer SetUp

             private Font fnt_footer1;
             private Font fnt_footer2;
             private Font fnt_footer3;
             private Font fnt_footer4;
             private Font fnt_footer5;
             private Font fnt_footer6;

//Height Calculation
             //headrer declaration
             private int iHead_StoreName;
             private int iHead_StoreType;
             private int iHead_StoreAddress;
             private int iHead_StoreABN;
             //Body Declaration
             private int iBodyTitle ;
             private int iDollarHead ;
             private int iItemHead ;
             private int iItemQtyHead ;
             private int iItemSymbolHead ;
             private int iItemUnitPriceHead ;
             private int iItemSubtotalHead ;
             //item Declaration
             private int iItem;
             private int iItemQty;
             private int iItemSymbol;
             private int iItemUnitPrice;
             private int iItemSubtotal;
             // Dot line print
             private int ilineDivide;
             //Item Sub Total Description
             private int iAmountDescription;
             private int iDollerItemSymbol;
             private int iTotal;
             //Item Discount Detail
             private int iDiscountDetail;
             private int iDiscountPrice;
             //Item Grand Total
             private int iNetTotalDescription;
             private int iNetTotalPrice;
             //Purchase Date and time
             private int iDateTime;
             // Footer SetUp

             private int ifooter1;
             private int ifooter2;
             private int ifooter3;
             private int ifooter4;
             private int ifooter5;
             private int ifooter6;

             //private Image bmpLogo;

        public printdoc()
            : base()
        {
        }
//Property Set for text
            //Header Property Set for text 
            public string Head_StoreName_Text
            {
              get { return str_Head_StoreName; }
             set { str_Head_StoreName  = value; }
            }

             public string Head_StoreType_Text
             {
                 get { return str_Head_StoreType; }
                 set { str_Head_StoreType = value; }
             }

             public string Head_StoreAddress_Text
             {
                 get { return str_Head_StoreAddress; }
                 set { str_Head_StoreAddress = value; }
             }

             public string Head_StoreABN_Text
             {
                 get { return str_Head_StoreABN; }
                 set { str_Head_StoreABN = value; }
             }
             //Body Property Set for text 
             public string BodyTitle_Text
             {
                 get { return str_BodyTitle; }
                 set { str_BodyTitle = value; }
             }
             public string DollarHead_Text
             {
                 get { return str_DollarHead; }
                 set { str_DollarHead = value; }
             }
             public string ItemHead_Text
             {
                 get { return str_ItemHead; }
                 set { str_ItemHead = value; }
             }
             public string ItemQtyHead_Text
             {
                 get { return str_ItemQtyHead; }
                 set { str_ItemQtyHead = value; }
             }
             public string ItemSymbolHead_Text
             {
                 get { return str_ItemSymbolHead; }
                 set { str_ItemSymbolHead = value; }
             }
             public string ItemUnitPriceHead_Text
             {
                 get { return str_ItemUnitPriceHead; }
                 set { str_ItemUnitPriceHead = value; }
             }
             public string ItemSubtotalHead_Text
             {
                 get { return str_ItemSubtotalHead; }
                 set { str_ItemSubtotalHead = value; }
             }
             //Item Property Set for text 
             public string Item_Text
             {
                 get { return str_Item; }
                 set { str_Item = value; }
             }
             public string ItemQty_Text
             {
                 get { return str_ItemQty; }
                 set { str_ItemQty = value; }
             }
             public string ItemSymbol_Text
             {
                 get { return str_ItemSymbol; }
                 set { str_ItemSymbol = value; }
             }
             public string ItemUnitPrice_Text
             {
                 get { return str_ItemUnitPrice; }
                 set { str_ItemUnitPrice = value; }
             }
             public string ItemSubtotal_Text
             {
                 get { return str_ItemSubtotal; }
                 set { str_ItemSubtotal = value; }
             }
             //Dot line Property Set for text 
             public string lineDivide_Text
             {
                 get { return str_lineDivide; }
                 set { str_lineDivide = value; }
             }
             //Item Sub Total propetry set for text
             public string AmountDescription_Text
             {
                 get { return str_AmountDescription; }
                 set { str_AmountDescription = value; }
             }
             public string DollerItemSymbol_Text
             {
                 get { return str_DollerItemSymbol; }
                 set { str_DollerItemSymbol = value; }
             }
             public string Total_Text
             {
                 get { return str_Total; }
                 set { str_Total = value; }
             }
             //Item Discount Detail Propetry set text
             public string DiscountDetail_Text
             {
                 get { return str_DiscountDetail; }
                 set { str_DiscountDetail = value; }
             }
             public string DiscountPrice_Text
             {
                 get { return str_DiscountPrice; }
                 set { str_DiscountPrice = value; }
             }
             //Item Grand Total Propety set text
             public string NetTotalDescription_Text
             {
                 get { return str_NetTotalDescription; }
                 set { str_NetTotalDescription = value; }
             }
             public string NetTotalPrice_Text
             {
                 get { return str_NetTotalPrice; }
                 set { str_NetTotalPrice = value; }
             }
             //Purchase Date and time
             public string DateTime_Text
             {
                 get { return str_DateTime; }
                 set { str_DateTime = value; }
             }
             // Footer propetry set for text
             public string footer1_Text
             {
                 get { return str_footer1; }
                 set { str_footer1 = value; }
             }
             public string footer2_Text
             {
                 get { return str_footer2; }
                 set { str_footer2 = value; }
             }
             public string footer3_Text
             {
                 get { return str_footer3; }
                 set { str_footer3 = value; }
             }
             public string footer4_Text
             {
                 get { return str_footer4; }
                 set { str_footer4 = value; }
             }
             public string footer5_Text
             {
                 get { return str_footer5; }
                 set { str_footer5 = value; }
             }
             public string footer6_Text
             {
                 get { return str_footer6; }
                 set { str_footer6 = value; }
             }
//property set for Font
             //Header Property Set for Font
             public Font Head_StoreName_font
             {
                 get { return fnt_Head_StoreName; }
                 set { fnt_Head_StoreName = value; }
             }

             public  Font Head_StoreType_font
             {
                 get { return fnt_Head_StoreType; }
                 set { fnt_Head_StoreType = value; }
             }

             public Font Head_StoreAddress_font
             {
                 get { return fnt_Head_StoreAddress; }
                 set { fnt_Head_StoreAddress = value; }
             }

             public Font Head_StoreABN_font
             {
                 get { return fnt_Head_StoreABN; }
                 set { fnt_Head_StoreABN = value; }
             }
             //Body Property Set for Font
             public Font BodyTitle_font
             {
                 get { return fnt_BodyTitle; }
                 set { fnt_BodyTitle = value; }
             }
             public Font DollarHead_font
             {
                 get { return fnt_DollarHead; }
                 set { fnt_DollarHead = value; }
             }
             public Font ItemHead_font
             {
                 get { return fnt_ItemHead; }
                 set { fnt_ItemHead = value; }
             }
             public Font ItemQtyHead_font
             {
                 get { return fnt_ItemQtyHead; }
                 set { fnt_ItemQtyHead = value; }
             }
             public Font ItemSymbolHead_font
             {
                 get { return fnt_ItemSymbolHead; }
                 set { fnt_ItemSymbolHead = value; }
             }
             public Font ItemUnitPriceHead_font
             {
                 get { return fnt_ItemUnitPriceHead; }
                 set { fnt_ItemUnitPriceHead = value; }
             }
             public Font ItemSubtotalHead_font
             {
                 get { return fnt_ItemSubtotalHead; }
                 set { fnt_ItemSubtotalHead = value; }
             }
             //Item Property Set for Font
             public Font Item_font
             {
                 get { return fnt_Item; }
                 set { fnt_Item = value; }
             }
             public Font ItemQty_font
             {
                 get { return fnt_ItemQty; }
                 set { fnt_ItemQty = value; }
             }
             public Font ItemSymbol_font
             {
                 get { return fnt_ItemSymbol; }
                 set { fnt_ItemSymbol = value; }
             }
             public Font ItemUnitPrice_font
             {
                 get { return fnt_ItemUnitPrice; }
                 set { fnt_ItemUnitPrice = value; }
             }
             public Font ItemSubtotal_font
             {
                 get { return fnt_ItemSubtotal; }
                 set { fnt_ItemSubtotal = value; }
             }
             //Dot line Property Set for text 
             public Font lineDivide_font
             {
                 get { return fnt_lineDivide; }
                 set { fnt_lineDivide = value; }
             }
             //Item Sub Total propetry set for Font
             public Font AmountDescription_font
             {
                 get { return fnt_AmountDescription; }
                 set { fnt_AmountDescription = value; }
             }
             public Font DollerItemSymbol_font
             {
                 get { return fnt_DollerItemSymbol; }
                 set { fnt_DollerItemSymbol = value; }
             }
             public Font Total_font
             {
                 get { return fnt_Total; }
                 set { fnt_Total = value; }
             }
             //Item Discount Detail Propetry set font
             public Font DiscountDetail_font
             {
                 get { return fnt_DiscountDetail; }
                 set { fnt_DiscountDetail = value; }
             }
             public Font DiscountPrice_font
             {
                 get { return fnt_DiscountPrice; }
                 set { fnt_DiscountPrice = value; }
             }
             //Item Grand Total Propety set Font
             public Font NetTotalDescription_font
             {
                 get { return fnt_NetTotalDescription; }
                 set { fnt_NetTotalDescription = value; }
             }
             public Font NetTotalPrice_font
             {
                 get { return fnt_NetTotalPrice; }
                 set { fnt_NetTotalPrice = value; }
             }
             //Purchase Date and time propetry set for Font
             public Font DateTime_font
             {
                 get { return fnt_DateTime; }
                 set { fnt_DateTime = value; }
             }
             // Footer propetry set for font
             public Font footer1_font
             {
                 get { return fnt_footer1; }
                 set { fnt_footer1 = value; }
             }
             public Font footer2_font
             {
                 get { return fnt_footer2; }
                 set { fnt_footer2 = value; }
             }
             public Font footer3_font
             {
                 get { return fnt_footer3; }
                 set { fnt_footer3 = value; }
             }
             public Font footer4_font
             {
                 get { return fnt_footer4; }
                 set { fnt_footer4 = value; }
             }
             public Font footer5_font
             {
                 get { return fnt_footer5; }
                 set { fnt_footer5 = value; }
             }
             public Font footer6_font
             {
                 get { return fnt_footer6; }
                 set { fnt_footer6 = value; }
             }


//propetry set for height
 
             //Header Property Set for Height
             public int Head_StoreName_Height
             {
                 get { return iHead_StoreName; }
                 set { iHead_StoreName = value*fnt_Head_StoreName.Height; }
             }

             public int Head_StoreType_Height
             {
                 get { return iHead_StoreType; }
                 set { iHead_StoreType = value*fnt_Head_StoreType.Height; }
             }

             public int Head_StoreAddress_Height
             {
                 get { return iHead_StoreAddress; }
                 set { iHead_StoreAddress = value*fnt_Head_StoreAddress.Height; }
             }

             public int Head_StoreABN_Height
             {
                 get { return iHead_StoreABN; }
                 set { iHead_StoreABN = value*fnt_Head_StoreABN.Height; }
             }
             //Body Property Set for Height
             public int BodyTitle_Height
             {
                 get { return iBodyTitle; }
                 set { iBodyTitle = value*fnt_BodyTitle.Height; }
             }
             public int DollarHead_Height
             {
                 get { return iDollarHead; }
                 set { iDollarHead = value*fnt_DollarHead.Height; }
             }
             public int ItemHead_Height
             {
                 get { return iItemHead; }
                 set { iItemHead = value*fnt_ItemHead.Height; }
             }
             public int ItemQtyHead_Height
             {
                 get { return iItemQtyHead; }
                 set { iItemQtyHead = value*fnt_ItemQtyHead.Height; }
             }
             public int ItemSymbolHead_Height
             {
                 get { return iItemSymbolHead; }
                 set { iItemSymbolHead = value*fnt_ItemSymbolHead.Height; }
             }
             public int ItemUnitPriceHead_Height
             {
                 get { return iItemUnitPriceHead; }
                 set { iItemUnitPriceHead = value*fnt_ItemUnitPriceHead.Height; }
             }
             public int ItemSubtotalHead_Height
             {
                 get { return iItemSubtotalHead; }
                 set { iItemSubtotalHead = value*fnt_ItemSubtotalHead.Height; }
             }
             //Item Property Set for Height
             public int Item_Height
             {
                 get { return iItem; }
                 set { iItem = value*fnt_Item.Height; }
             }
             public int ItemQty_Height
             {
                 get { return iItemQty; }
                 set { iItemQty = value*fnt_ItemQty.Height; }
             }
             public int ItemSymbol_Height
             {
                 get { return iItemSymbol; }
                 set { iItemSymbol = value*fnt_ItemSymbol.Height; }
             }
             public int ItemUnitPrice_Height
             {
                 get { return iItemUnitPrice; }
                 set { iItemUnitPrice = value*fnt_ItemUnitPrice.Height; }
             }
             public int ItemSubtotal_Height
             {
                 get { return iItemSubtotal; }
                 set { iItemSubtotal = value*fnt_ItemSubtotal.Height; }
             }
             //Dot line Property Set for Height 
             public int lineDivide_Height
             {
                 get { return ilineDivide; }
                 set { ilineDivide = value*fnt_lineDivide.Height; }
             }
             //Item Sub Total propetry set for Height
             public int AmountDescription_Height
             {
                 get { return iAmountDescription; }
                 set { iAmountDescription = value*fnt_AmountDescription.Height; }
             }
             public int DollerItemSymbol_Height
             {
                 get { return iDollerItemSymbol; }
                 set { iDollerItemSymbol = value*fnt_DollerItemSymbol.Height; }
             }
             public int Total_Height
             {
                 get { return iTotal; }
                 set { iTotal = value*fnt_Total.Height; }
             }
             //Item Discount Detail Propetry set Height
             public int DiscountDetail_Height
             {
                 get { return iDiscountDetail; }
                 set { iDiscountDetail = value*fnt_DiscountDetail.Height; }
             }
             public int DiscountPrice_Height
             {
                 get { return iDiscountPrice; }
                 set { iDiscountPrice = value*fnt_DiscountPrice.Height; }
             }
             //Item Grand Total Propety set Height
             public int NetTotalDescription_Height
             {
                 get { return iNetTotalDescription; }
                 set { iNetTotalDescription = value*fnt_NetTotalDescription.Height; }
             }
             public int NetTotalPrice_Height
             {
                 get { return iNetTotalPrice; }
                 set { iNetTotalPrice = value*fnt_NetTotalPrice.Height; }
             }
             //Purchase Date and time propetry set for Height
             public int DateTime_Height
             {
                 get { return iDateTime; }
                 set { iDateTime = value*fnt_DateTime.Height; }
             }
             // Footer propetry set for height
             public int footer1_Height
             {
                 get { return ifooter1; }
                 set { ifooter1 = value*fnt_footer1.Height; }
             }
             public int footer2_Height
             {
                 get { return ifooter2; }
                 set { ifooter2 = value*fnt_footer2.Height; }
             }
             public int footer3_Height
             {
                 get { return ifooter3; }
                 set { ifooter3 = value*fnt_footer3.Height; }
             }
             public int footer4_Height
             {
                 get { return ifooter4; }
                 set { ifooter4 = value*fnt_footer4.Height; }
             }
             public int footer5_Height
             {
                 get { return ifooter5; }
                 set { ifooter5 = value*fnt_footer5.Height; }
             }
             public int footer6_Height
             {
                 get { return ifooter6; }
                 set { ifooter6 = value* fnt_footer6.Height; }
             }
 

      
        public Bitmap LogoImage
        {
            get { return bmpLogo; }
            set { bmpLogo = value; }
        }

       protected override void OnBeginPrint(PrintEventArgs ev)
        {
            base.OnBeginPrint(ev);

            string[] strTmpText;

            if (str_Head_StoreName == null)
            {
                str_Head_StoreName = "";
            }

            if (str_Head_StoreType == null)
            {
                str_Head_StoreType = "";
            }

            if (str_Head_StoreAddress == null)
            {
                str_Head_StoreAddress = "";
            }

            if (str_Head_StoreABN == null)
            {
                str_Head_StoreABN = "";
            }

            if (str_BodyTitle == null)
            {
                str_BodyTitle = "";
            }

            if (str_DollarHead == null)
            {
                str_DollarHead = "";
            }
            if (str_ItemHead == null)
            {
                str_ItemHead = "";
            }
            if (str_ItemQtyHead == null)
            {
                str_ItemQtyHead = "";
            }
            if (str_ItemSymbolHead == null)
            {
                str_ItemSymbolHead = "";
            }
            if (str_ItemUnitPriceHead == null)
            {
                str_ItemUnitPriceHead = "";
            }
            if (str_ItemSubtotalHead == null)
            {
                str_ItemSubtotalHead = "";
            }
            if (str_Item == null)
            {
                str_Item = "";
            }
            if (str_ItemQty == null)
            {
                str_ItemQty = "";
            }
            if (str_ItemSymbol == null)
            {
                str_ItemSymbol = "";
            }
            if (str_ItemUnitPrice == null)
            {
                str_ItemUnitPrice = "";
            }
            if (str_ItemSubtotal == null)
            {
                str_ItemSubtotal = "";
            }
            if (str_lineDivide == null)
            {
                str_lineDivide = "";
            }
            if (str_AmountDescription == null)
            {
                str_AmountDescription = "";
            }
            if (str_DollerItemSymbol == null)
            {
                str_DollerItemSymbol = "";
            }

            if (str_Total == null)
            {
                str_Total = "";
            }

            if (str_DiscountDetail == null)
            {
                str_DiscountDetail = "";
            }
            if (str_DiscountPrice == null)
            {
                str_DiscountPrice = "";
            }
            if (str_NetTotalDescription == null)
            {
                str_NetTotalDescription = "";
            }
            if (str_NetTotalPrice == null)
            {
                str_NetTotalPrice = "";
            }
            if (str_DateTime == null)
            {
                str_DateTime = "";
            }
            if (str_footer1 == null)
            {
                str_footer1 = "";
            }
            if (str_footer2 == null)
            {
                str_footer2 = "";
            }
            if (str_footer3 == null)
            {
                str_footer3 = "";
            }
            if (str_footer4 == null)
            {
                str_footer4 = "";
            }
            if (str_footer5 == null)
            {
                str_footer5= "";
            }
            if (str_footer6 == null)
            {
                str_footer6= "";
            }


            if (fnt_Head_StoreName == null)
            {
                fnt_Head_StoreName = new Font("Agency FB", 13, FontStyle.Bold);
            }

            if (fnt_Head_StoreType == null)
            {
                fnt_Head_StoreType = new Font("Agency FB",11);
            }
            if (fnt_Head_StoreAddress == null)
            {
                fnt_Head_StoreAddress = new Font("Agency FB", 11);
            }
            if (fnt_Head_StoreABN == null)
            {
                fnt_Head_StoreABN = new Font("Agency FB", 11);
            }
            if (fnt_BodyTitle == null)
            {
                fnt_BodyTitle = new Font("Agency FB", 11);
            }
            if (fnt_DollarHead == null)
            {
                fnt_DollarHead = new Font("Agency FB", 11,FontStyle.Bold);
            }
            if (fnt_ItemHead == null)
            {
                fnt_ItemHead = new Font("Agency FB", 11,FontStyle.Bold);
            }
            if (fnt_ItemQtyHead == null)
            {
                fnt_ItemQtyHead = new Font("Agency FB", 11, FontStyle.Bold);
            }
            if (fnt_ItemSymbolHead == null)
            {
                fnt_ItemSymbolHead = new Font("Agency FB", 11, FontStyle.Bold);
            }
            if (fnt_ItemSymbolHead == null)
            {
                fnt_ItemSymbolHead = new Font("Agency FB", 11, FontStyle.Bold);
            }
            if (fnt_ItemSymbolHead == null)
            {
                fnt_ItemSymbolHead = new Font("Agency FB", 11, FontStyle.Bold);
            }
            if (fnt_ItemUnitPriceHead == null)
            {
                fnt_ItemUnitPriceHead = new Font("Agency FB", 11, FontStyle.Bold);
            }
            if (fnt_ItemSubtotalHead == null)
            {
                fnt_ItemSubtotalHead = new Font("Agency FB", 11, FontStyle.Bold);
            }
            if (fnt_Item == null)
            {
                fnt_Item = new Font("Agency FB", 11);
            }
            if (fnt_ItemQty == null)
            {
                fnt_ItemQty = new Font("Agency FB", 11);
            }
            if (fnt_ItemSymbol == null)
            {
                fnt_ItemSymbol = new Font("Agency FB", 11);
            }
            if (fnt_ItemUnitPrice == null)
            {
                fnt_ItemUnitPrice = new Font("Agency FB", 11);
            }
            if (fnt_ItemSubtotal == null)
            {
                fnt_ItemSubtotal = new Font("Agency FB", 11);
            }
            if (fnt_lineDivide == null)
            {
                fnt_lineDivide = new Font("Agency FB", 11);
            }
            if (fnt_AmountDescription == null)
            {
                fnt_AmountDescription = new Font("Agency FB", 11);
            }
            if (fnt_DollerItemSymbol == null)
            {
                fnt_DollerItemSymbol = new Font("Agency FB", 11);
            }
            if (fnt_Total == null)
            {
                fnt_Total = new Font("Agency FB", 11);
            }
            if (fnt_DiscountDetail == null)
            {
                fnt_DiscountDetail = new Font("Agency FB", 11);
            }
            if (fnt_DiscountPrice == null)
            {
                fnt_DiscountPrice = new Font("Agency FB", 11);
            }
            if (fnt_NetTotalDescription == null)
            {
                fnt_NetTotalDescription = new Font("Agency FB", 11);
            }
            if (fnt_NetTotalDescription == null)
            {
                fnt_NetTotalDescription = new Font("Agency FB", 11);
            }
            if (fnt_NetTotalPrice == null)
            {
                fnt_NetTotalPrice = new Font("Agency FB", 11);
            }
            if (fnt_DateTime == null)
            {
                fnt_DateTime = new Font("Agency FB", 11);
            }
            if (fnt_footer1 == null)
            {
                fnt_footer1 = new Font("Agency FB", 11,FontStyle.Bold);
            }
            if (fnt_footer2 == null)
            {
                fnt_footer2 = new Font("Agency FB", 11);
            }
            if (fnt_footer3 == null)
            {
                fnt_footer3 = new Font("Agency FB", 11);
            }
            if (fnt_footer4 == null)
            {
                fnt_footer4 = new Font("Agency FB", 11);
            }
            if (fnt_footer5 == null)
            {
                fnt_footer5 = new Font("Agency FB",13,FontStyle.Bold);
            }
            if (fnt_footer6 == null)
            {
                fnt_footer6 = new Font("Agency FB", 11);
            }
            if (iHead_StoreName == 0)
            {
                strTmpText = str_Head_StoreName.Split(sep);

                iHead_StoreName = strTmpText.Length * fnt_Head_StoreName.Height;
            }
            if (iHead_StoreType == 0)
            {
                strTmpText = str_Head_StoreType.Split(sep);
                iHead_StoreType = strTmpText.Length * fnt_Head_StoreType.Height;
            }
            if (iHead_StoreAddress == 0)
            {
                strTmpText = str_Head_StoreAddress.Split(sep);
                iHead_StoreAddress = strTmpText.Length * fnt_Head_StoreAddress.Height;
            }
            if (iHead_StoreABN == 0)
            {
                strTmpText = str_Head_StoreABN.Split(sep);
                iHead_StoreABN = strTmpText.Length * fnt_Head_StoreABN.Height;
            }
            if (iBodyTitle == 0)
            {
                strTmpText = str_BodyTitle.Split(sep);
                iBodyTitle = strTmpText.Length * fnt_BodyTitle.Height;
            }
            if (iDollarHead == 0)
            {
                strTmpText = str_DollarHead.Split(sep);
                iDollarHead = strTmpText.Length * fnt_DollarHead.Height;
            }
            if (iItemHead == 0)
            {
                strTmpText = str_ItemHead.Split(sep);
                iItemHead = strTmpText.Length * fnt_ItemHead.Height;
            }
            if (iItemQtyHead == 0)
            {
                strTmpText = str_ItemQtyHead.Split(sep);
                iItemQtyHead = strTmpText.Length * fnt_ItemQtyHead.Height;
            }
            if (iItemQtyHead == 0)
            {
                strTmpText = str_ItemQtyHead.Split(sep);
                iItemQtyHead = strTmpText.Length * fnt_ItemQtyHead.Height;
            }
            if (iItemSymbolHead == 0)
            {
                strTmpText = str_ItemSymbolHead.Split(sep);
                iItemSymbolHead = strTmpText.Length * fnt_ItemSymbolHead.Height;
            }
            if (iItemUnitPriceHead == 0)
            {
                strTmpText = str_ItemUnitPriceHead.Split(sep);
                iItemUnitPriceHead = strTmpText.Length * fnt_ItemUnitPrice.Height;
            }
            if (iItemSubtotalHead == 0)
            {
                strTmpText = str_ItemSubtotalHead.Split(sep);
                iItemSubtotalHead = strTmpText.Length * fnt_ItemSubtotalHead.Height;
            }
            if (iItem == 0)
            {
                strTmpText = str_Item.Split(sep);
                iItem = (strTmpText.Length-1) * fnt_Item.Height;
            }
            if (iItemQty == 0)
            {
                strTmpText = str_ItemQty.Split(sep);
                iItemQty = strTmpText.Length * fnt_ItemQty.Height;
            }
            if (iItemSymbol == 0)
            {
                strTmpText = str_ItemSymbol.Split(sep);
                iItemSymbol = strTmpText.Length * fnt_ItemSymbol.Height;
            }
            if (iItemUnitPrice == 0)
            {
                strTmpText = str_ItemUnitPrice.Split(sep);
                iItemUnitPrice = strTmpText.Length * fnt_ItemUnitPrice.Height;
            }
            if (iItemSubtotal == 0)
            {
                strTmpText = str_ItemSubtotal.Split(sep);
                iItemSubtotal = strTmpText.Length * fnt_ItemUnitPrice.Height;
            }
            if (ilineDivide == 0)
            {
                strTmpText = str_lineDivide.Split(sep);
                ilineDivide = strTmpText.Length * fnt_lineDivide.Height;
            }
            if (iAmountDescription == 0)
            {
                strTmpText = str_AmountDescription.Split(sep);
                iAmountDescription = strTmpText.Length * fnt_AmountDescription.Height;
            }
            if (iDollerItemSymbol == 0)
            {
                strTmpText = str_DollerItemSymbol.Split(sep);
                iDollerItemSymbol = strTmpText.Length * fnt_DollerItemSymbol.Height;
            }
            if (iTotal == 0)
            {
                strTmpText = str_Total.Split(sep);
                iTotal = strTmpText.Length * fnt_Total.Height;
            }
            if (iDiscountDetail == 0)
            {
                strTmpText = str_DiscountDetail.Split(sep);
                iDiscountDetail = strTmpText.Length * fnt_DiscountDetail.Height;
            }
            if (iDiscountPrice == 0)
            {
                strTmpText = str_DiscountPrice.Split(sep);
                iDiscountPrice = strTmpText.Length * fnt_DiscountPrice.Height;
            }
            if (iNetTotalDescription == 0)
            {
                strTmpText = str_NetTotalDescription.Split(sep);
                iNetTotalDescription = strTmpText.Length * fnt_NetTotalDescription.Height;
            }
            if (iNetTotalPrice == 0)
            {
                strTmpText = str_NetTotalPrice.Split(sep);
                iNetTotalPrice = (strTmpText.Length) * fnt_NetTotalPrice.Height;
            }
            if (iDateTime == 0)
            {
                strTmpText = str_DateTime.Split(sep);
                iDateTime = strTmpText.Length * fnt_DateTime.Height;
            }
            if (ifooter1 == 0)
            {
                strTmpText = str_footer1.Split(sep);
                ifooter1 = strTmpText.Length * fnt_footer1.Height;
            }
            if (ifooter2 == 0)
            {
                strTmpText = str_footer1.Split(sep);
                ifooter2 = strTmpText.Length * fnt_footer2.Height;
            }
            if (ifooter3 == 0)
            {
                strTmpText = str_footer1.Split(sep);
                ifooter3 = strTmpText.Length * fnt_footer3.Height;
            }
            if (ifooter4 == 0)
            {
                strTmpText = str_footer1.Split(sep);
                ifooter4 = strTmpText.Length * fnt_footer4.Height;
            }
            if (ifooter5 == 0)
            {
                strTmpText = str_footer1.Split(sep);
                ifooter5 = strTmpText.Length * fnt_footer5.Height;
            }
            if (ifooter6 == 0)
            {
                strTmpText = str_footer1.Split(sep);
                ifooter6 = strTmpText.Length * fnt_footer6.Height;
            }
          
        }

       protected override void OnPrintPage(PrintPageEventArgs ev)
        {
           
            base.OnPrintPage(ev);
            
            int intPrintAreaHeight;
            int intPrintAreaWidth;
            int intMarginLeft;
            int intMarginTop;

            {
                intPrintAreaHeight = 0;
                intPrintAreaWidth = 275;
                intMarginLeft = 2;
                intMarginTop = 60;
            }

            if (base.DefaultPageSettings.Landscape)
            {
                int intTemp;
                intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }
//To set printable Area for Headrer
            RectangleF rectPrintingArea_DateTime = new RectangleF(intMarginLeft, 40, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_Head_StoreName = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_Head_StoreType = new RectangleF(intMarginLeft, intMarginTop +DateTime_Height+ iHead_StoreName, intPrintAreaWidth, intPrintAreaHeight); 
            RectangleF rectPrintingArea_Head_StoreAddress = new RectangleF(intMarginLeft, intMarginTop +DateTime_Height+ iHead_StoreName + iHead_StoreType, intPrintAreaWidth, intPrintAreaHeight);
           // RectangleF rectPrintingArea_Head_StoreABN = new RectangleF(intMarginLeft, intMarginTop + iHead_StoreName + iHead_StoreType + iHead_StoreAddress, intPrintAreaWidth, intPrintAreaHeight);

//To set Printable Area for Body
           // RectangleF rectPrintingArea_BodyTitle = new RectangleF(intMarginLeft, intMarginTop + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iHead_StoreABN, intPrintAreaWidth, intPrintAreaHeight);
          //  RectangleF rectPrintingArea_DollarHead = new RectangleF(intMarginLeft, intMarginTop + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iHead_StoreABN + iBodyTitle, intPrintAreaWidth, intPrintAreaHeight);   
            RectangleF rectPrintingArea_ItemHead = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress, intPrintAreaWidth, intPrintAreaHeight);
      
//To set Item Printable Area

            RectangleF rectPrintingArea_Item = new RectangleF(intMarginLeft, intMarginTop +DateTime_Height+ iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead , intPrintAreaWidth, intPrintAreaHeight);

//To set Dot Printiable Area       

            RectangleF rectPrintingArea_lineDivide = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem, intPrintAreaWidth, intPrintAreaHeight);

//To set Total Amount printable Area

            RectangleF rectPrintingArea_Total = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide, intPrintAreaWidth, intPrintAreaHeight);

//To set Discount printable Area

            RectangleF rectPrintingArea_DiscountPrice = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal, intPrintAreaWidth, intPrintAreaHeight);  

//To set Grand Total Printable Area

            RectangleF rectPrintingArea_NetTotalPrice = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice, intPrintAreaWidth, intPrintAreaHeight);

//To set Printable Date Area

            //RectangleF rectPrintingArea_DateTime = new RectangleF(intMarginLeft, intMarginTop + iHead_StoreName + iHead_StoreType + iHead_StoreAddress  + iItemHead  + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice, intPrintAreaWidth, intPrintAreaHeight);

//To set Printable Area For footer

            RectangleF rectPrintingArea_footer1 = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice + iDateTime, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_footer2 = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice + iDateTime + ifooter1, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_footer3 = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice + iDateTime + ifooter1 + ifooter2, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_footer4 = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice + iDateTime + ifooter1 + ifooter2 + ifooter3, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_footer5 = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice + iDateTime + ifooter1 + ifooter2 + ifooter3 + ifooter4, intPrintAreaWidth, intPrintAreaHeight);
            RectangleF rectPrintingArea_footer6 = new RectangleF(intMarginLeft, intMarginTop + DateTime_Height + iHead_StoreName + iHead_StoreType + iHead_StoreAddress + iItemHead + iItem + ilineDivide + iTotal + iDiscountPrice + iNetTotalPrice + iDateTime + ifooter1 + ifooter2 + ifooter3 + ifooter4 + ifooter5, intPrintAreaWidth, intPrintAreaHeight);

            StringFormat objSF = new StringFormat(StringFormatFlags.LineLimit);

            Int32 intLinesFilled;
            Int32 intCharsFitted;

            ////---------------------------To Print Logo-----------------------------------------------------------
            if ((bmpLogo == null) == false)
            {
               // ev.Graphics.DrawImage(bmpLogo, 20, 5, 230,60);
                ev.Graphics.DrawImage(bmpLogo,30,0,230,60);

            }


            ////-----------------------To Print Date & time---------------------------------------------------------------
            if (str_DateTime != "")
            {
                ev.Graphics.MeasureString(str_DateTime.Substring(UpgradeZeros(intCurrentChar)), fnt_DateTime, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
                ev.Graphics.DrawString(str_DateTime.Substring(UpgradeZeros(intCurrentChar)), fnt_DateTime, Brushes.Black, rectPrintingArea_DateTime, objSF);
            }

            //-----------------------To Print Header ---------------------------------------------------------------New SizeF(intPrintAreaWidth,intPrintAreaHeight),objSF,intCharsFitted,intLinesFilled)

            if (str_Head_StoreName != "")
            {
              ev.Graphics.MeasureString(str_Head_StoreName.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreName, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_Head_StoreName.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreName, Brushes.Black, rectPrintingArea_Head_StoreName, objSF);
            }
            if (str_Head_StoreType != "")
            {
              ev.Graphics.MeasureString(str_Head_StoreType.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreType, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_Head_StoreType.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreType, Brushes.Black, rectPrintingArea_Head_StoreType, objSF);
            }
            if (str_Head_StoreAddress != "")
            {
              ev.Graphics.MeasureString(str_Head_StoreAddress.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreAddress, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_Head_StoreAddress.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreAddress, Brushes.Black, rectPrintingArea_Head_StoreAddress, objSF);
            }
            //if (str_Head_StoreAddress != "")
            //{
            //  ev.Graphics.MeasureString(str_Head_StoreABN.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreABN, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //  ev.Graphics.DrawString(str_Head_StoreABN.Substring(UpgradeZeros(intCurrentChar)), fnt_Head_StoreABN, Brushes.Black, rectPrintingArea_Head_StoreABN, objSF);
            //}



            ////-----------------------To Print BodyTitle---------------------------------------------------------------
            //if (str_BodyTitle != "")
            //{
            // ev.Graphics.MeasureString(str_BodyTitle.Substring(UpgradeZeros(intCurrentChar)), fnt_BodyTitle, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out  intLinesFilled);
            //  ev.Graphics.DrawString(str_BodyTitle.Substring(UpgradeZeros(intCurrentChar)), fnt_BodyTitle, Brushes.Black, rectPrintingArea_BodyTitle, objSF);
            //}
            ////-----------------------To Print DollarHead---------------------------------------------------------------
            //if (str_DollarHead !="")
            // {
            //   ev.Graphics.MeasureString(str_DollarHead.Substring( UpgradeZeros(intCurrentChar)), fnt_DollarHead, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF,out intCharsFitted,out intLinesFilled);
            //   ev.Graphics.DrawString(str_DollarHead.Substring( UpgradeZeros(intCurrentChar)), fnt_DollarHead, Brushes.Black, rectPrintingArea_DollarHead, objSF);
            // }
            ////-----------------------To Print IteamHead---------------------------------------------------------------
             if (str_ItemHead !="")
             {
              ev.Graphics.MeasureString(str_ItemHead.Substring( UpgradeZeros(intCurrentChar)), fnt_ItemHead, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF,out intCharsFitted,out  intLinesFilled);
              ev.Graphics.DrawString(str_ItemHead.Substring( UpgradeZeros(intCurrentChar)), fnt_ItemHead, Brushes.Black, rectPrintingArea_ItemHead, objSF);
             }
            ////-----------------------To Print Iteam---------------------------------------------------------------
             if (str_Item != "")
            {
              ev.Graphics.MeasureString(str_Item.Substring(UpgradeZeros(intCurrentChar)), fnt_Item, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_Item.Substring(UpgradeZeros(intCurrentChar)), fnt_Item, Brushes.Black, rectPrintingArea_Item, objSF);
             }
            ////-----------------------To Print line Dividide---------------------------------------------------------------
            //if (str_lineDivide != "")
            //{
            //   ev.Graphics.MeasureString(str_lineDivide.Substring(UpgradeZeros(intCurrentChar)), fnt_lineDivide, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //   ev.Graphics.DrawString(str_lineDivide.Substring(UpgradeZeros(intCurrentChar)), fnt_lineDivide, Brushes.Black, rectPrintingArea_lineDivide, objSF);
            //}
            ////-----------------------To Print Total---------------------------------------------------------------
            if (str_Total != "")
            {
             ev.Graphics.MeasureString(str_Total.Substring(UpgradeZeros(intCurrentChar)), fnt_Total, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_Total.Substring(UpgradeZeros(intCurrentChar)), fnt_Total, Brushes.Black, rectPrintingArea_Total, objSF);
            }
            ////-----------------------To Print Discount---------------------------------------------------------------
            if (str_DiscountPrice != "")
            {
             ev.Graphics.MeasureString(str_DiscountPrice.Substring(UpgradeZeros(intCurrentChar)), fnt_DiscountPrice, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
             ev.Graphics.DrawString(str_DiscountPrice.Substring(UpgradeZeros(intCurrentChar)), fnt_DiscountPrice, Brushes.Black, rectPrintingArea_DiscountPrice, objSF);
            }
            ////-----------------------To Print Grand Total---------------------------------------------------------------
            if (str_NetTotalPrice != "")
            {
              ev.Graphics.MeasureString(str_NetTotalPrice.Substring(UpgradeZeros(intCurrentChar)), fnt_NetTotalPrice, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_NetTotalPrice.Substring(UpgradeZeros(intCurrentChar)), fnt_NetTotalPrice, Brushes.Black, rectPrintingArea_NetTotalPrice, objSF);
            }
            ////-----------------------To Print Date & time---------------------------------------------------------------
            //if (str_DateTime != "")
            //{
            //  ev.Graphics.MeasureString(str_DateTime.Substring(UpgradeZeros(intCurrentChar)), fnt_DateTime, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //  ev.Graphics.DrawString(str_DateTime.Substring(UpgradeZeros(intCurrentChar)), fnt_DateTime, Brushes.Black, rectPrintingArea_DateTime, objSF);
            //}
            ////-----------------------To Print Footer1---------------------------------------------------------------
            if (str_footer1 != "")
            {
               ev.Graphics.MeasureString(str_footer1.Substring(UpgradeZeros(intCurrentChar)), fnt_footer1, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_footer1.Substring(UpgradeZeros(intCurrentChar)), fnt_footer1, Brushes.Black, rectPrintingArea_footer1, objSF);
            }
            ////-----------------------To Print Footer2---------------------------------------------------------------
            if (str_footer2 != "")
            {
              ev.Graphics.MeasureString(str_footer2.Substring(UpgradeZeros(intCurrentChar)), fnt_footer2, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
              ev.Graphics.DrawString(str_footer2.Substring(UpgradeZeros(intCurrentChar)), fnt_footer2, Brushes.Black, rectPrintingArea_footer2, objSF);
            }
            ////-----------------------To Print Footer3---------------------------------------------------------------
            //if (str_footer3 != "")
            //{
            //   ev.Graphics.MeasureString(str_footer3.Substring(UpgradeZeros(intCurrentChar)), fnt_footer3, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //   ev.Graphics.DrawString(str_footer3.Substring(UpgradeZeros(intCurrentChar)), fnt_footer3, Brushes.Black, rectPrintingArea_footer3, objSF);
            //}
            ////-----------------------To Print Footer4---------------------------------------------------------------
            //if (str_footer4 != "")
            //{
            //   ev.Graphics.MeasureString(str_footer4.Substring(UpgradeZeros(intCurrentChar)), fnt_footer4, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //   ev.Graphics.DrawString(str_footer4.Substring(UpgradeZeros(intCurrentChar)), fnt_footer4, Brushes.Black, rectPrintingArea_footer4, objSF);
            //}
            ////-----------------------To Print Footer5---------------------------------------------------------------
            //if (str_footer5 != "")
            //{
            //   ev.Graphics.MeasureString(str_footer5.Substring(UpgradeZeros(intCurrentChar)), fnt_footer5, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //   ev.Graphics.DrawString(str_footer5.Substring(UpgradeZeros(intCurrentChar)), fnt_footer5, Brushes.Black, rectPrintingArea_footer5, objSF);
            //}
            ////-----------------------To Print Footer6---------------------------------------------------------------
            //if (str_footer6 != "")
            //{
            //   ev.Graphics.MeasureString(str_footer6.Substring(UpgradeZeros(intCurrentChar)), fnt_footer6, new SizeF(intPrintAreaWidth, intPrintAreaHeight), objSF, out intCharsFitted, out intLinesFilled);
            //   ev.Graphics.DrawString(str_footer6.Substring(UpgradeZeros(intCurrentChar)), fnt_footer6, Brushes.Black, rectPrintingArea_footer6, objSF);
            //}

        }
      

        public int UpgradeZeros(int Input)
        {
            if (Input == 0)
            {
                return 1;
            }
            else
            {
                return Input;
            }
        }

    }
}
    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFO
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDataType;
    }
    public class PrintDirect
    {
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern long ClosePrinter(IntPtr hPrinter);

        private string m_printername;
        public PrintDirect()
        {

        }
        public PrintDirect(string printername)
        {
            m_printername = printername;
        }
        public void OpenCashDrawer()
        {
            try
            {
                System.IntPtr lhPrinter = new System.IntPtr();
                DOCINFO di = new DOCINFO();
                int pcWritten = new int();
                string st2 = Convert.ToChar(27).ToString() + Convert.ToChar(112).ToString() + "0" + "50" + "40";

                di.pDocName = "RITPOS_OpenCashDrawer_Cmd";
                di.pDataType = "RAW";

                PrintDirect.OpenPrinter(m_printername, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref di);
                PrintDirect.StartPagePrinter(lhPrinter);

                PrintDirect.WritePrinter(lhPrinter, st2, st2.Length, ref pcWritten);

                PrintDirect.EndPagePrinter(lhPrinter);
                PrintDirect.EndDocPrinter(lhPrinter);
                PrintDirect.ClosePrinter(lhPrinter);
            }
            catch (Exception xcp)
            {
                throw new Exception("An error occurred to write to printer", xcp);
            }
        }
    }

 }

