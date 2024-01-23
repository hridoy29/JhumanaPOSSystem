using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using POSsible.BusinessObjects;
using POSsible.DAL;

namespace POSsible
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            int resultInvoiceAdd = 3; string cusMobNo = "";
            Store store = new StoreDAO().Store_GetById(MDIParent.storeId);
            Company com = new CompanyDAO().Company_GetAll().FirstOrDefault();
            Invoice InvoiceEntity = new InvoiceDAO().Invoice_GetById(resultInvoiceAdd);
            string cusName = (cmbCustomer.SelectedIndex < 0) ? "General Customer" : cmbCustomer.Text;
            cusName = (cmbCustomer.SelectedIndex > -1 && !string.IsNullOrEmpty(cusMobNo)) ? cusName + " (" + cusMobNo + ")" : cusName;

            Graphics graphics = e.Graphics;
            Font font10 = new Font("Lekton", 8);
            Font font12 = new Font("Lekton", 10);
            Font font14 = new Font("Lekton", 13);

            float leading = 4;
            float lineheight10 = font10.GetHeight() + leading;
            float lineheight12 = font12.GetHeight() + leading;
            float lineheight14 = font14.GetHeight() + leading;

            float startX = 0;
            float startY = leading;
            float Offset = 0;

            StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatCenter = new StringFormat(formatLeft);
            StringFormat formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            SizeF layoutSize = new SizeF(284 - Offset * 2, lineheight14);
            RectangleF layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            Brush brush = new SolidBrush(Color.Black);

            graphics.DrawString(com.CompanyName, font14, brush, layout, formatCenter);
            Offset = Offset + lineheight14;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString(store.StoreName, font12, brush, layout, formatCenter);
            Offset = Offset + lineheight12;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString(store.StoreAddress, font10, brush, layout, formatCenter);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Tel:" + store.PhoneNo + ", Email:" + store.Email, font10, brush, layout, formatCenter);
            Offset = Offset + lineheight10-10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("".PadRight(45, '_'), font10, brush, layout, formatLeft);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Invoice # ".PadRight(12) + InvoiceEntity.InvoiceNo, font12, brush, layout, formatLeft);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Customer: ".PadRight(10) + cusName, font12, brush, layout, formatLeft);
            Offset = Offset + lineheight12;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Cashier: ".PadRight(12) + MDIParent.userName, font12, brush, layout, formatLeft);
            Offset = Offset + lineheight12;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Date: ".PadRight(14) + String.Format("{0:dd-MMM-yyyy hh:mm tt}", InvoiceEntity.invoiceDate), font12, brush, layout, formatLeft);
            Offset = Offset + lineheight10 - 5;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("".PadRight(45, '_'), font10, brush, layout, formatLeft);
            Offset = Offset + lineheight10;

            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Description                                        Rate               Value", font10, new SolidBrush(Color.Black), layout, formatLeft);
            Offset = Offset + lineheight10;

            Font font = new Font("Lekton", 8, FontStyle.Regular);
            float fontHeight = font.GetHeight();
            List<InvoiceProduct> lst = new InvoiceProductDAO().InvoiceProduct_GetDynamic("[invoiceId]='" + resultInvoiceAdd + "'", "");
            double total = 0;
            int itemSpace = 186;
            bool multiline = false;
            foreach (InvoiceProduct item in lst)
            {
                int productNameLength = item.productName.Length;
                string productDescription = item.productName;
                if (multiline) itemSpace += 15;
                multiline = false;
                if (productNameLength > 34)
                {
                    productDescription = productDescription.Insert(32, Convert.ToString((Char)0x0A));
                    productDescription = productDescription.Insert(33, "   -");
                    multiline = true;
                }
                string productTotal = Convert.ToInt32(item.qty).ToString();
                double unitPrice = Convert.ToDouble(item.unitPrice);
                double productPrice = unitPrice * Convert.ToInt32(item.qty);
                total += productPrice;

                string QtyPrice = productTotal + "@" + String.Format("{00:00.00}", unitPrice);

                graphics.DrawString(productDescription, font, new SolidBrush(Color.Black), startX, itemSpace);
                graphics.DrawString(QtyPrice, font, new SolidBrush(Color.Black), 170, itemSpace);
                graphics.DrawString(String.Format("{00:0.000}", productPrice), font, new SolidBrush(Color.Black), 240, itemSpace);
                itemSpace += 15;
                Offset = Offset + (int)fontHeight + 5;
            }

            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 5);
            graphics.DrawString("TOTAL(KD):".PadLeft(26) + String.Format("{0:0.000}", total).PadLeft(30), new Font("Lekton", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX, itemSpace + 17);
            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 35);

            double totDiscount = Convert.ToDouble(InvoiceEntity.DiscountGiven); double change = 0.2; double card = 7;
            if (totDiscount > 0)
            {
                itemSpace += 3;
                graphics.DrawString("Discount:".PadLeft(29) + String.Format("{0:0.000}", totDiscount).PadLeft(51), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
                itemSpace += 15;
                graphics.DrawString("NET(KD):".PadLeft(28) + String.Format("{0:0.000}", total - totDiscount).PadLeft(49), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
                itemSpace += 15;
            }

            graphics.DrawString("CASH(KD):".PadLeft(29) + String.Format("{0:0.000}", InvoiceEntity.CashAmt).PadLeft(47), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
            if (card > 0)
            {
                itemSpace += 15;
                graphics.DrawString("CARD(KD):".PadLeft(29) + String.Format("{0:0.000}", InvoiceEntity.CardAmt).PadLeft(47), font, new SolidBrush(Color.Black), startX, itemSpace + 45);
            }

            graphics.DrawString("                    BALANCE(KD):" + String.Format("{0:0.000}", InvoiceEntity.changeGiven).PadLeft(40), font, new SolidBrush(Color.Black), startX, itemSpace + 60);
            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 70);
            graphics.DrawString("---------------------------------------", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, itemSpace + 75);
            graphics.DrawString("Thank You for shopping with us, please come back soon", font, new SolidBrush(Color.Black), startX, itemSpace + 90);

            font10.Dispose(); font12.Dispose(); font14.Dispose();

            //Graphics graphic = e.Graphics;

            //Font font = new Font("Lekton", 8, FontStyle.Regular);

            //float fontHeight = font.GetHeight();

            //int startX = 0;
            //int startY = 0;
            //int offset = 40;

            //Company com = new CompanyDAO().Company_GetAll().FirstOrDefault();

            //string company = "### " + com.CompanyName + " ###\n";
            //string store = "JANATA TRADING (Wholesale)";
            //string add = "Shuwaikh, Near Old Veg. Market.";
            //string tel = "Tel:97662399, Email:janatagroup@hotmail.com";

            //int addpositionX = 0;
            //if (add.Length < 40)
            //{
            //    addpositionX = (40 - add.Length) / 2;
            //}

            //graphic.DrawString(company, new Font("Courier Sans New", 13), new SolidBrush(Color.Black), (115 - com.CompanyName.Length) / 2, startY);
            //graphic.DrawString(store, new Font("Courier Sans New", 11), new SolidBrush(Color.Black), (210 - store.Length) / 2, startY + 20);
            //graphic.DrawString("Shuwaikh, Near Old Veg. Market.", new Font("Courier Sans New", 9), new SolidBrush(Color.Black), addpositionX, startY + 40);
            //graphic.DrawString("Tel:97662399, Email:janatagroup@hotmail.comm", new Font("Courier Sans New", 9), new SolidBrush(Color.Black), startX, startY + 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintReceipt);
            printDocument.Print();
        }
    }
}
