using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Reflection;
using POSsible.BusinessObjects;
using POSsible.Properties;
using Microsoft.ApplicationBlocks.Data;

namespace POSsible.BusinessObjects
{
    class CPrinter
    {
        private string m_printername;
        private int Shiftid;
        string struserlist = "";
        // Fixed String assign for END of the day report

        
        public CPrinter()
        {
            POSConfiguration configuration = new POSConfiguration();
            m_printername = configuration.getPrinter();
           
        }
        
    #region Shift End Report
        public void printendshift(int iShiftId)
        {
            Shiftid = iShiftId;
            //headrer declaration
            string str_Head_StoreName = "  FAMILY NEEDS";
            string str_Head_StoreType = "  A LIMITED PARTNERSHIP";
            string str_Head_StoreAddress = "  AUSTRALIA";
            string str_Head_StoreABN = "     ABN:27129700705";
            //Body Declaration
       
            //Purchase Date and time
            string str_DateTime = "15-02-08";
            string str_Total;
            // Footer SetUp


            try
            {
                RstPrinter.printdoc ObjrstPrinter = new RstPrinter.printdoc();
                PrintDirect objPrintDirect = new PrintDirect();
                StandardPrintController offPrintDialog = new StandardPrintController();

                ObjrstPrinter.PrintController = offPrintDialog;

                ObjrstPrinter.PrinterSettings.PrinterName = m_printername;//"\\\\192.168.0.9\\EPSON TM-T88II Partial cut";

                ObjrstPrinter.DateTime_Text = "  " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");

                ObjrstPrinter.Head_StoreName_Text = str_Head_StoreName;
                ObjrstPrinter.Head_StoreType_Text = str_Head_StoreType;
                ObjrstPrinter.Head_StoreAddress_Text = str_Head_StoreAddress;
                ObjrstPrinter.Head_StoreABN_Text = str_Head_StoreABN;
                fillshiftinfo();
                fillupuserlist();
                filldatewisesales();

                //str_Total = struserlist + Environment.NewLine + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");
                //str_Total += str_Total + Environment.NewLine + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");

                ObjrstPrinter.Total_Text = struserlist;//"  Total $12";

                ObjrstPrinter.Print();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataSet getuserlist()
        {

            POSConfiguration settings = new POSConfiguration();
            
            string SqlStr = "EXEC ritpos_shiftend_userlist " + Shiftid;
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        public DataSet getshiftinfo()
        {

            POSConfiguration settings = new POSConfiguration();
            
            struserlist = "";
            
            string SqlStr = "EXEC ritpos_shiftend_Report_info " + Shiftid;
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        public DataSet getDeptWisesales()
        {

            POSConfiguration settings = new POSConfiguration();
           
            string SqlStr = "EXEC ritpos_shiftend_DeptWiseSales " + Shiftid;
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        public void filldatewisesales()
        {
            DataSet Dsdeptwisesales = new DataSet();
            Dsdeptwisesales = getDeptWisesales();
            struserlist = struserlist + "  SHIFT SALES INFO" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            struserlist = struserlist + "  DeptName TotSales TotGst" + Environment.NewLine;
            struserlist = struserlist + " -------------------------" + Environment.NewLine;
            double totsalesamnt = 0;
            double totgstamnt = 0;
            foreach (DataRow Drdeptwisesales in Dsdeptwisesales.Tables[0].Rows)
            {
                double Totgst;
                //Totgst = (Convert.ToDouble(Drdeptwisesales["TotAmnt"]) * Convert.ToDouble(Drdeptwisesales["isGstItem"]) * Convert.ToDouble(Drdeptwisesales["Gstper"])) / 100;
                Totgst = (Convert.ToDouble(Drdeptwisesales["TotAmnt"]) * Convert.ToDouble(Drdeptwisesales["isGstItem"]) / Convert.ToDouble(Drdeptwisesales["Gstper"]));
                struserlist = struserlist + "  " + GetFixedLengthString(Drdeptwisesales["deptName"].ToString(), 8) + " ";
                struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}",Convert.ToDouble(Drdeptwisesales["TotAmnt"])), 7)+ " ";
                //struserlist = struserlist + Drdeptwisesales["isGstItem"]  ;
                struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}",Convert.ToDouble(Totgst)), 6) + Environment.NewLine;

                totsalesamnt = totsalesamnt + Convert.ToDouble( Drdeptwisesales["TotAmnt"]);
                totgstamnt = totgstamnt + Totgst;

            }
            struserlist = struserlist + " -------------------------" + Environment.NewLine;
            struserlist = struserlist + "  " + GetFixedLengthString("Total :", 8);
            struserlist = struserlist + " "+GetFixedLengthString(string.Format("{0:$###0.00}", Convert.ToDouble(totsalesamnt)), 7) + " ";
            struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}", Convert.ToDouble(totgstamnt)), 6) + Environment.NewLine;
            struserlist = struserlist + Environment.NewLine + Environment.NewLine + Environment.NewLine;
        }
        public void fillshiftinfo()
        {
            DataSet DsShiftinfo = new DataSet();
            DsShiftinfo = getshiftinfo();

            struserlist = "   END OF THE SHIFT REPORT" + Environment.NewLine;
            struserlist = struserlist + "===========================" + Environment.NewLine + Environment.NewLine;
            struserlist = struserlist + " SHIFT GENERAL INFO" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            foreach (DataRow DrShiftinfo in DsShiftinfo.Tables[0].Rows)
            {
                double cashamnt = 0;
                cashamnt = Convert.ToDouble(DrShiftinfo["TotCashAmnt"]) - Convert.ToDouble(DrShiftinfo["TotCardAmnt"]);

                struserlist = struserlist + " Press NoSales :" + DrShiftinfo["TotNoSales"] + Environment.NewLine;
                struserlist = struserlist + " Start Shift Amount :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["StartMoney"])) + Environment.NewLine;
                struserlist = struserlist + " End Shift Amount   :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["EndMoney"])) + Environment.NewLine;
                struserlist = struserlist + " Cash(Sales)   :" + string.Format("{0:$###0.00}", cashamnt) + Environment.NewLine;
                struserlist = struserlist + " Card(Sales)   :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["ToTCardAmnt"])) + Environment.NewLine;
                struserlist = struserlist + " Safe Drop     :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["TotalSafeDrop"])) + Environment.NewLine ;
                struserlist = struserlist + " Cash Diff    :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["TotCashdiff"])) + Environment.NewLine + Environment.NewLine + Environment.NewLine;


            }
        }
        public void fillupuserlist()
        {
            DataSet DsUserList = new DataSet();
            DsUserList = getuserlist();
            struserlist = struserlist + "  SHIFT USER LIST" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            struserlist = struserlist + "  UserName INTIME   OUTTIME" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            foreach (DataRow DrUserList in DsUserList.Tables[0].Rows)
            {
                DateTime intime;
                DateTime outtime;
                string strintime;
                string strouttime;
                if (DrUserList["UserLoginTime"].ToString() != "")
                {
                    intime = (DateTime)DrUserList["UserLoginTime"];
                    strintime = intime.ToString("hh:mm:ss");
                }
                else
                {
                    strintime = "00:00:00";
                }
                if (DrUserList["UserLogoutTime"].ToString() != "")
                {
                    outtime = (DateTime)DrUserList["UserLogoutTime"];
                    strouttime = outtime.ToString("hh:mm:ss");
                }
                else
                {
                    strouttime = "00:00:00";
                }
                //strusername = strusername.Append(DrUserList["Name"]);
                struserlist = struserlist + "  " + GetFixedLengthString(DrUserList["Name"].ToString(),8) + " "
                + strintime + " "
                + strouttime + Environment.NewLine;
            }
            struserlist = struserlist + Environment.NewLine + Environment.NewLine + Environment.NewLine;
        }
        
#endregion

    #region Day End Report
        public void printendEndoftheDay()
        {
            //headrer declaration
            string str_Head_StoreName = "  FAMILY NEEDS";
            string str_Head_StoreType = "  A LIMITED PARTNERSHIP";
            string str_Head_StoreAddress = "  AUSTRALIA";
            string str_Head_StoreABN = "     ABN:27129700705";
            //Body Declaration
            
            //item Declaration
           
            // Dot line print
            
            string str_Total;
            //Item Discount Detail
            
            //Purchase Date and time
            string str_DateTime = "15-02-08";
            // Footer SetUp


            try
            {
                RstPrinter.printdoc ObjrstPrinter = new RstPrinter.printdoc();
                PrintDirect objPrintDirect = new PrintDirect();
                StandardPrintController offPrintDialog = new StandardPrintController();

                ObjrstPrinter.PrintController = offPrintDialog;

                ObjrstPrinter.PrinterSettings.PrinterName = m_printername; //"EPSON TM-T88II Partial cut";

                ObjrstPrinter.DateTime_Text = "  " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");

                ObjrstPrinter.Head_StoreName_Text = str_Head_StoreName;
                ObjrstPrinter.Head_StoreType_Text = str_Head_StoreType;
                ObjrstPrinter.Head_StoreAddress_Text = str_Head_StoreAddress;
                ObjrstPrinter.Head_StoreABN_Text = str_Head_StoreABN;

                fillDayEndshiftinfo();
                fillDayEndupuserlist();
                fillDayEnddatewisesales();

                //str_Total = struserlist+ Environment.NewLine+DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");
                //str_Total += str_Total 

                ObjrstPrinter.Total_Text = struserlist;//"  Total $12";

                ObjrstPrinter.Print();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private DataSet getDayEnduserlist()
        {

            POSConfiguration settings = new POSConfiguration();
            string SqlStr = "EXEC ritpos_endoftheday_userlist  '"+Environment.MachineName.ToString()+"'";
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        private DataSet getDayEndshiftinfo()
        {

            POSConfiguration settings = new POSConfiguration();
            struserlist = "";
            string SqlStr = "EXEC ritpos_endoftheday_info  '" + Environment.MachineName.ToString() + "'";
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        private DataSet getDayEndDeptWisesales()
        {

            POSConfiguration settings = new POSConfiguration();
            string SqlStr = "EXEC ritpos_endOfDay_DeptWiseSales '" + Environment.MachineName.ToString() + "'";
            return SqlHelper.ExecuteDataset(settings.getConnectionstring(), CommandType.Text, SqlStr);

        }
        private void fillDayEnddatewisesales()
        {
            DataSet Dsdeptwisesales = new DataSet();
            Dsdeptwisesales = getDayEndDeptWisesales();
            struserlist = struserlist + " DAY END SALES INFO" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            struserlist = struserlist + " DeptName TotSales TotGst" + Environment.NewLine;
            struserlist = struserlist + " -------------------------" + Environment.NewLine;
            double totsalesamnt=0;
            double totgstamnt=0;
            foreach (DataRow Drdeptwisesales in Dsdeptwisesales.Tables[0].Rows)
            {
                double Totgst;
                Totgst = (Convert.ToDouble(Drdeptwisesales["TotAmnt"]) * Convert.ToDouble(Drdeptwisesales["isGstItem"]) * Convert.ToDouble(Drdeptwisesales["Gstper"])) / 100;
                struserlist = struserlist + " " + GetFixedLengthString(Drdeptwisesales["deptName"].ToString(),8) + " ";
                struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}", Convert.ToDouble(Drdeptwisesales["TotAmnt"])),8) + " ";
                struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}", Convert.ToDouble(Totgst)),6) + Environment.NewLine;
                totsalesamnt = totsalesamnt + Convert.ToDouble( Drdeptwisesales["TotAmnt"]);
                totgstamnt = totgstamnt + Totgst;

            }
            struserlist = struserlist + " -------------------------" + Environment.NewLine;
            struserlist = struserlist + " " + GetFixedLengthString("Total :", 8);
            struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}", Convert.ToDouble(totsalesamnt)), 8) + " ";
            struserlist = struserlist + GetFixedLengthString(string.Format("{0:$###0.00}", Convert.ToDouble(totgstamnt)), 7) + Environment.NewLine;
                
            struserlist = struserlist + Environment.NewLine + Environment.NewLine + Environment.NewLine;
        }
        private void fillDayEndshiftinfo()
        {
            DataSet DsShiftinfo = new DataSet();
            DsShiftinfo = getDayEndshiftinfo();

            struserlist = "   END OF THE DAY REPORT" + Environment.NewLine;
            struserlist = struserlist + "===========================" + Environment.NewLine + Environment.NewLine;
            struserlist = struserlist + "  DAY GENERAL INFO" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            foreach (DataRow DrShiftinfo in DsShiftinfo.Tables[0].Rows)
            {
                double cashamnt = 0;
                double cashdiff = 0;
                //TotalCashSale+TotalSafeDrop+StartMoney-TotalChangeGiven-EndMoney 
                cashdiff=Convert.ToDouble(DrShiftinfo["EndMoney"])-(Convert.ToDouble(DrShiftinfo["TotalCashSale"]) -Convert.ToDouble(DrShiftinfo["TotalSafeDrop"])+Convert.ToDouble(DrShiftinfo["StartMoney"])-Convert.ToDouble(DrShiftinfo["TotalChangeGiven"]));
                cashamnt = Convert.ToDouble(DrShiftinfo["TotCashAmnt"]) - Convert.ToDouble(DrShiftinfo["TotCardAmnt"]);
                struserlist = struserlist + "  Press NoSales:" + DrShiftinfo["TotNoSales"] + Environment.NewLine;
                struserlist = struserlist + "  Cash(Drawer) :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["Cashamount"])) + Environment.NewLine;
                struserlist = struserlist + "  Cash(Sales)  :" + string.Format("{0:$###0.00}", cashamnt) + Environment.NewLine;
                struserlist = struserlist + "  Card(Sales)  :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["TotCardAmnt"])) + Environment.NewLine;
                struserlist = struserlist + "  Safe Drop    :" + string.Format("{0:$###0.00}", Convert.ToDouble(DrShiftinfo["TotalSafeDrop"])) + Environment.NewLine ;
                struserlist = struserlist + "  Cash Diff    :" + string.Format("{0:$###0.00}", cashdiff) + Environment.NewLine + Environment.NewLine + Environment.NewLine;

            }
        }
        private void fillDayEndupuserlist()
        {
            DataSet DsUserList = new DataSet();
            DsUserList = getDayEnduserlist();
            struserlist = struserlist + "  DAY USER LIST" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            struserlist = struserlist + "  UserName INTIME   OUTTIME" + Environment.NewLine;
            struserlist = struserlist + "----------------------------" + Environment.NewLine;
            foreach (DataRow DrUserList in DsUserList.Tables[0].Rows)
            {
                DateTime intime;
                DateTime outtime;
                string strintime;
                string strouttime;
                if (DrUserList["UserLoginTime"].ToString() != "")
                {
                    intime = (DateTime)DrUserList["UserLoginTime"];
                    strintime = intime.ToString("hh:mm:ss");
                }
                else
                {
                    strintime = "00:00:00";
                }
                if (DrUserList["UserLogoutTime"].ToString() != "")
                {
                    outtime = (DateTime)DrUserList["UserLogoutTime"];
                    strouttime = outtime.ToString("hh:mm:ss");
                }
                else
                {
                    strouttime = "00:00:00";
                }
                //strusername = strusername.Append( DrUserList["Name"]);
                struserlist = struserlist + "  " + GetFixedLengthString(DrUserList["Name"].ToString(), 8) + " "
                + strintime + " "
                + strouttime + Environment.NewLine;
            }
            struserlist = struserlist + Environment.NewLine + Environment.NewLine + Environment.NewLine;
        }

#endregion

    #region Invoice Report
        public void printbill(CInvoice invoice)
        {

            //headrer declaration
            
            string str_Head_StoreName = "               TAX INVOICE";
            string str_Head_StoreType = "                FAMILY NEEDS";
            string str_Head_StoreABN = "                ABN:27129700705";
            //Body Declaration
            string str_ItemHead = "  Name";
            string str_ItemQtyHead = "$";
            string str_ItemSymbolHead = "/";
            string str_ItemUnitPriceHead = "Unit";
            string str_ItemSubtotalHead = "Subtotal";
            //item Declaration
            string Total = invoice.TotalPrice.ToString();
            //Item Discount Detail
            //Purchase Date and time
            string str_DateTime = invoice.InvoiceDate.ToLongDateString();
            // Footer SetUp

            string str_footer1 = "Please retain your Tax " + Environment.NewLine + "Invoice for any returns or exchanges.";
            string str_footer2 = "FAMILY NEEDS";
            string str_footer6 = "Mon-Wed: 9:00 a.m - 10:00 p.m " + Environment.NewLine + "Thu    : 7:00 a.m - 9:00 p.m" + Environment.NewLine + "Fri    : 7:00 a.m - 10:00 p.m" + Environment.NewLine + "Sat    : 7.00 a.m - 10:00 p.m" + Environment.NewLine + "Sun    : 7.00 a.m - 10:00 p.m";


            RstPrinter.printdoc ObjrstPrinter = new RstPrinter.printdoc();
            PrintDirect objPrintDirect = new PrintDirect();
            StandardPrintController offPrintDialog = new StandardPrintController();

            ObjrstPrinter.PrintController = offPrintDialog;

            ObjrstPrinter.PrinterSettings.PrinterName = m_printername;//"\\\\192.168.0.9\\EPSON TM-T88II Partial cut";

            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _imageStream = _assembly.GetManifestResourceStream("POSsibleResources.familyneedlogo.bmp");
            if(_imageStream!=null)
            ObjrstPrinter.LogoImage = new Bitmap(_imageStream);

            ObjrstPrinter.Head_StoreName_Text = str_Head_StoreName;
            ObjrstPrinter.Head_StoreType_Text = "   " + str_Head_StoreType + Environment.NewLine + str_Head_StoreABN + Environment.NewLine + " --------------------------------------------------";
            // ObjrstPrinter.Head_StoreABN_Text = str_Head_StoreABN +Environment.NewLine+" ------------------------- ";
            ObjrstPrinter.ItemHead_Text = str_ItemHead + "    " + str_ItemQtyHead + "" + str_ItemSymbolHead + "" + str_ItemUnitPriceHead + "    " + str_ItemSubtotalHead + Environment.NewLine + " ----------------------------------------------";
            ObjrstPrinter.Item_Text = " ";
            if(invoice.Product != null)
            foreach (CProduct product in invoice.Product)
            {
                string strqtyup;
                if (product.UnitMeasure.Equals("Kg"))
                {
                    strqtyup = string.Format("{0:###0.000}", Convert.ToDouble(product.QtyInorder)) + product.UnitMeasure.Substring(0, 2) + str_ItemSymbolHead + "" + string.Format("{0:$###0.00}", Convert.ToDouble(product.UnitPrice));
                }
                else
                {
                    strqtyup = string.Format("{0:###0}", Convert.ToDouble(product.QtyInorder)) + product.UnitMeasure.Substring(0, 2) + str_ItemSymbolHead + "" + string.Format("{0:$###0.00}", Convert.ToDouble(product.UnitPrice));
                }
                ObjrstPrinter.Item_Text += product.ProductName.ToString() + Environment.NewLine;
                ObjrstPrinter.Item_Text += "  " + GetFixedLengthString("", 5) + "  " + GetFixedLengthString(strqtyup, 14) + "  " + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(product.QtyInorder * product.UnitPrice)), 12) + Environment.NewLine;
            }

            ObjrstPrinter.Total_Text = " --------------------------------------------------- " + Environment.NewLine;

            //if (Convert.ToDouble(Total) > 9.99)
            //{
            //    ObjrstPrinter.Total_Text += GetFixedLengthString("Total Price             :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(Total)), 19);
            //}
            //else
            
            ObjrstPrinter.Total_Text += GetFixedLengthString("Total Price             :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(Total)), 19);


            if (Convert.ToDouble(invoice.DiscountGiven) > 9.99)
            {
                ObjrstPrinter.DiscountPrice_Text = GetFixedLengthString(" Discount                 :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(invoice.DiscountGiven)), 20);
            }
            else
                ObjrstPrinter.DiscountPrice_Text = GetFixedLengthString(" Discount                 :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.DiscountGiven)), 20);

            if (invoice.CashAmount != 0)
            {
                if (Convert.ToDouble(invoice.CashAmount) > 9.99)
                {
                    ObjrstPrinter.NetTotalPrice_Text += GetFixedLengthString(" Tender                    :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(invoice.CashAmount)), 21);
                }
                else
                    ObjrstPrinter.NetTotalPrice_Text += GetFixedLengthString(" Tender                    :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.CashAmount)), 21);
            }

            if (invoice.CardAmount != 0)
            {
                if (Convert.ToDouble(invoice.CardAmount) > 9.99)
                {
                    ObjrstPrinter.NetTotalPrice_Text += Environment.NewLine + GetFixedLengthString("Card Amount             :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(invoice.CardAmount)), 15);
                }
                else
                    ObjrstPrinter.NetTotalPrice_Text += Environment.NewLine + GetFixedLengthString("Card Amount             :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.CardAmount)), 15);
            }
            if (invoice.ChangeGiven!= 0)
            {
                Double roundamnt = 0;
                roundamnt = (Convert.ToDouble(Total) - Convert.ToDouble( invoice.DiscountGiven) + Convert.ToDouble(invoice.ChangeGiven))-invoice.CashAmount ;
                
                if (Convert.ToDouble(roundamnt) > 9.99)
                {
                    ObjrstPrinter.NetTotalPrice_Text += Environment.NewLine + GetFixedLengthString("Rounding               :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(roundamnt)), 17);
                }
                else
                    ObjrstPrinter.NetTotalPrice_Text += Environment.NewLine + GetFixedLengthString("Rounding               :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(roundamnt)), 17);

                if (Convert.ToDouble(invoice.ChangeGiven) > 9.99)
                {
                    ObjrstPrinter.NetTotalPrice_Text += Environment.NewLine + GetFixedLengthString("Change Amount   :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(invoice.ChangeGiven)), 10);
                }
                else
                    ObjrstPrinter.NetTotalPrice_Text += Environment.NewLine + GetFixedLengthString("Change Amount   :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.ChangeGiven)), 10);
            }
            if (invoice.TotalGst != 0)
            {
                ObjrstPrinter.NetTotalPrice_Text +=Environment.NewLine + GetFixedLengthString("Total Gst" + "                :",28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.TotalGst)), 18) ;
            }
            //ObjrstPrinter.NetTotalPrice_Text += " --------------------------------------------------" + GetFixedLengthString(" GrandTotal            :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.TotalPrice - invoice.DiscountGiven)), 18) + Environment.NewLine;
            //ObjrstPrinter.NetTotalPrice_Text += "---------------------------------------------------" + Environment.NewLine + "*=GST Item";

            if (Convert.ToDouble(invoice.TotalPrice - invoice.DiscountGiven) > 9.99)
            {
                ObjrstPrinter.footer1_Text = " ------------------------------------------------" + GetFixedLengthString(" GrandTotal           :", 28) + GetFixedLengthamount(string.Format("{0:$###00.00}", Convert.ToDouble(invoice.TotalPrice - invoice.DiscountGiven)), 13) + Environment.NewLine;
            }
            else
                ObjrstPrinter.footer1_Text = " ------------------------------------------------" + GetFixedLengthString(" GrandTotal           :", 28) + GetFixedLengthamount(string.Format("{0:$###0.00}", Convert.ToDouble(invoice.TotalPrice - invoice.DiscountGiven)), 13) + Environment.NewLine;

            ObjrstPrinter.footer2_Text = "---------------------------------------------------" + Environment.NewLine + "*=GST Item";
            ObjrstPrinter.footer2_Text += Environment.NewLine + " " + str_footer1;
            ObjrstPrinter.footer2_Text += Environment.NewLine + " " + str_footer2 + Environment.NewLine + "" + "    Lot-41, 19A Evans Ave" + Environment.NewLine + "    Eastlakes, NSW 2018." + Environment.NewLine + "Phone:(02)96691069" + Environment.NewLine + invoice.InvoiceDate.ToString("dddd, dd MMMM yyyy HH:mm") + Environment.NewLine + "User Name:" + invoice.UserName + Environment.NewLine + "Invoice No." + invoice.InvoiceId;
            ObjrstPrinter.Print();
        }
#endregion
        
    #region open cash Drawer
        public void openChashDrawer()
        {
            PrintDirect printer = new PrintDirect(m_printername);
            printer.OpenCashDrawer();
        }
        
#endregion

    #region Common methods
    
        private string GetFixedLengthString(string input, int length)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                result = new string(' ', length);
            }
            else if (input.Length > length)
            {
                result = input.Substring(0, length);
            }
            else
            {
                result = input.PadRight(length);
            }

            return result;
        }


        private string GetFixedLengthamount(string input, int length)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                result = new string(' ', length);
            }
            else if (input.Length > length)
            {
                result = input.Substring(0, length);
            }
            else
            {
                result = input.PadLeft(length);
            }

            return result;
        }
#endregion

    }

}
