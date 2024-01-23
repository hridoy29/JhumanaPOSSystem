using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmMonthlyExpense : Form
    {
        public static string header = string.Empty;
        public string month = string.Empty;

        public frmMonthlyExpense()
        {
            InitializeComponent();
        }

        private void frmMonthlyExpense_Load(object sender, EventArgs e)
        {
            string monthName = header.Split(' ')[0];
            if (monthName == "January") month = "01";
            else if (monthName == "February") month = "02";
            else if (monthName == "March") month = "03";
            else if (monthName == "April") month = "04";
            else if (monthName == "May") month = "05";
            else if (monthName == "June") month = "06";
            else if (monthName == "July") month = "07";
            else if (monthName == "August") month = "08";
            else if (monthName == "September") month = "09";
            else if (monthName == "October") month = "10";
            else if (monthName == "November") month = "11";
            else if (monthName == "December") month = "12";

            string year = header.Split(' ')[1];

            DateTime fromDate = Convert.ToDateTime(year + "-" + month + "-01");

            if (fromDate < MDIParent.StoreOpeningDate)
            {
                fromDate = MDIParent.StoreOpeningDate;

                switch (fromDate.Month)
                {
                    case 1:
                        monthName = "January";
                        break;
                    case 2:
                        monthName = "February";
                        break;
                    case 3:
                        monthName = "March";
                        break;
                    case 4:
                        monthName = "April";
                        break;
                    case 5:
                        monthName = "May";
                        break;
                    case 6:
                        monthName = "June";
                        break;
                    case 7:
                        monthName = "July";
                        break;
                    case 8:
                        monthName = "August";
                        break;
                    case 9:
                        monthName = "September";
                        break;
                    case 10:
                        monthName = "October";
                        break;
                    case 11:
                        monthName = "November";
                        break;
                    case 12:
                        monthName = "December";
                        break;
                    default:
                        break;
                }

                year = fromDate.Year.ToString();
            }

            lblHeader.Text = "Monthly Expense " + monthName + " " + year;

            dgv.DataSource = new DailyTransactionDAO().DailyTransaction_MonthlyExpense(fromDate, DateTime.Now);
        }

        private void copyAlltoClipboard()
        {
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgv.MultiSelect = true;
            dgv.SelectAll();
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
