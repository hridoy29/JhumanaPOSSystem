using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Reflection;
using System.ComponentModel;
using POSsible.DAL;
using System.Text.RegularExpressions;

namespace POSsible
{
    public static class Helper
    {
        public static void Next_Control(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (sender is TextBox)
                {
                    TextBox tb = (TextBox)sender;
                    if (tb.Text.Trim() != String.Empty)
                    {
                        SendKeys.Send("{TAB}");

                    }
                    else if (tb.Tag != null && tb.Tag.ToString().StartsWith("["))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    //else
                    //{
                    //    SendKeys.Send("{TAB}");
                    //}
                }
                else if (sender is ComboBox)
                {
                    ComboBox cbo = (ComboBox)sender;

                    if (cbo.Tag != null && cbo.Tag.ToString().StartsWith("["))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    else if (cbo.SelectedIndex != -1)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    //else
                    //{
                    //    SendKeys.Send("{TAB}");
                    //}
                }
                else if (sender is DateTimePicker)
                {
                    SendKeys.Send("{TAB}");
                }
                else if (sender is Button)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        //public static void Enter_Control(Object sender, EventArgs e)
        //{
        //    if (sender is TextBox)
        //    {
        //        TextBox tb = (TextBox)sender;
        //        tb.BackColor = Color.Azure;
        //    }
        //    else if (sender is ComboBox)
        //    {
        //        ComboBox cbo = (ComboBox)sender;
        //        cbo.BackColor = Color.Azure;
        //    }
        //}

        //public static void Leave_Control(Object sender, EventArgs e)
        //{
        //    if (sender is TextBox)
        //    {
        //        TextBox tb = (TextBox)sender;
        //        tb.BackColor = Color.White;
        //    }
        //    else if (sender is ComboBox)
        //    {
        //        ComboBox cbo = (ComboBox)sender;
        //        cbo.BackColor = Color.White;
        //    }
        //}

        //public static void Empty(this TextBox tb)
        //{
        //    tb.Text = String.Empty;
        //}
        //public static void Empty(this ComboBox cbo)
        //{
        //    cbo.SelectedIndex = -1;
        //}

        public static void Empty(this TextBox tb)
        {
            tb.Text = String.Empty;
        }
        public static void Empty(this ComboBox cbo)
        {
            cbo.SelectedIndex = -1;
        }

        public static List<Button> ListBtns(Button n, Button s, Button d, Button r, Button c)
        {
            List<Button> listBtns = new List<Button>();
            listBtns.Add(n);
            listBtns.Add(s);
            listBtns.Add(d);
            listBtns.Add(r);
            listBtns.Add(c);
            return listBtns;
        }

        public static List<Button> ListBtns(Button n, Button s, Button d, Button r, Button c, Button c1)
        {
            List<Button> listBtns = new List<Button>();
            listBtns.Add(n);
            listBtns.Add(s);
            listBtns.Add(d);
            listBtns.Add(r);
            listBtns.Add(c);
            listBtns.Add(c1);
            return listBtns;
        }

        public static void ButtonStates(List<Button> btns, bool n, bool s, bool d, bool r, bool c)
        {
            btns[0].Enabled = n;
            btns[1].Enabled = s;
            btns[2].Enabled = d;
            btns[3].Enabled = r;
            btns[4].Enabled = c;
        }

        //public static List<Button> ListBtns1(Button n, Button e, Button d, Button s, Button c, Button sh)
        //{
        //    List<Button> listBtns = new List<Button>();
        //    listBtns.Add(n);
        //    listBtns.Add(e);
        //    listBtns.Add(d);
        //    listBtns.Add(s);
        //    listBtns.Add(c);
        //    listBtns.Add(sh);
        //    return listBtns;
        //}

        public static void ButtonStates(List<Button> btns, bool n, bool e, bool d, bool s, bool c, bool sh)
        {
            btns[0].Enabled = n;
            btns[1].Enabled = e;
            btns[2].Enabled = d;
            btns[3].Enabled = s;
            btns[4].Enabled = c;
            btns[5].Enabled = sh;
        }


        public static void LoadCombo(ComboBox combo, DataTable dt, String displayMember, String valueMember)
        {
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DataSource = dt;
        }
        public static void LoadCombo1(ComboBox combo, DataTable dt, String displayMember, String valueMember, String valueMember1, String valueMember2)
        {
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.ValueMember = valueMember1;
            combo.ValueMember = valueMember2;
            combo.DataSource = dt;
        }

        public static void DropList(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.DroppedDown = true;
            }
        }
        public static void ClearInputControls(Control element)
        {
            foreach (Control c in element.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                else if (c is ComboBox)
                {
                    ComboBox cbo = (ComboBox)c;
                    cbo.SelectedIndex = -1;
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)c;
                    dtp.Value = DateTime.Today;
                }
                else if (c.Controls.Count > 0)
                {
                    ClearInputControls(c);
                }
            }
        }

        public static void EnableInputControls(Control element, Boolean tf)
        {
            foreach (Control c in element.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = tf;
                }
                else if (c is ComboBox)
                {
                    ComboBox cbo = (ComboBox)c;
                    cbo.Enabled = tf;
                }
                else if (c.Controls.Count > 0)
                {
                    EnableInputControls(c, tf);
                }
            }
        }

        public static Boolean ValidateNotEmpty(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text.Trim() == "")
                    {
                        MessageBox.Show(((TextBox)c).Tag + " cannot be empty!");
                        c.Focus();
                        return false;
                    }
                }

                if (c is ComboBox)
                {
                    if (((ComboBox)c).SelectedIndex == -1)
                    {
                        MessageBox.Show(((ComboBox)c).Tag + " must be selected!");
                        c.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
        public static void Input0to9Only(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Back) || e.KeyChar.Equals((char)Keys.Tab) || e.KeyChar.Equals((char)Keys.Delete))
            {
                e.Handled = false;
                return;
            }

            for (int i = 0; i <= 9; i++)
            {
                if (e.KeyChar != (char)i)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        public static void InputOnlyNumbers(object sender, KeyPressEventArgs e, string text)
        {

            if (!Char.IsDigit(e.KeyChar))
            {

                if (e.KeyChar == '.')
                {
                    int lastPosOfDot = text.LastIndexOf(".");
                    if (lastPosOfDot < 0)
                    {
                        e.Handled = false;
                        return;
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else e.Handled = true;
            }
            if (e.KeyChar.Equals((char)Keys.Back) || e.KeyChar.Equals((char)Keys.Tab) || e.KeyChar.Equals((char)Keys.Delete))
            {
                e.Handled = false;
                return;
            }


        }
        public static void InputOnlyInt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar.Equals((char)Keys.Back) || e.KeyChar.Equals((char)Keys.Tab) || e.KeyChar.Equals((char)Keys.Delete))
            {
                e.Handled = false;
                return;
            }

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        public static void InputOnlySignedNumbers(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Back) || e.KeyChar.Equals((char)Keys.Tab) || e.KeyChar.Equals((char)Keys.Delete))
            {
                e.Handled = false;
                return;
            }
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '.' || e.KeyChar != '-')
                {
                    e.Handled = true;
                }
            }
        }
        public static void InputNumberWith2DecimalPlace(object sender, KeyPressEventArgs e, TextBox t)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (!(sender as TextBox).Text.Contains(".") && (sender as TextBox).Text.Length == 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(t.Text, @"\.\d\d") && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static Boolean ValidDecimal(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox)
                {
                    try
                    {
                        Convert.ToDecimal((c as TextBox).Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(((TextBox)c).Tag + " is not a valid value!");
                        c.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        public static DataTable RemoveColumnsFromDataTable(DataTable dt, List<string> columns)
        {
            foreach (string col in columns)
            {
                if (dt.Columns.Contains(col))
                {
                    dt.Columns.Remove(col);
                }
            }
            return dt;
        }

        public static void SetDataBaseLogonForReport(ReportDocument oReportDocument)
        {
            System.Data.Common.DbConnection connection = (DbProviderHelper.GetConnection());
            String connStr = connection.ConnectionString;
            String pwd = "Luxury123"; //System.Configuration.ConfigurationManager.AppSettings["pwd"];
            string[] connValues = connStr.Split(';');
            string[] serverName = connValues[0].Split('=');
            string[] dbName = connValues[1].Split('=');
            string[] userID = connValues[2].Split('=');
            string[] password = connValues[3].Split('=');
            System.Data.SqlClient.SqlConnectionStringBuilder SConn = new System.Data.SqlClient.SqlConnectionStringBuilder(connection.ConnectionString);
            oReportDocument.SetDatabaseLogon(userID[1], pwd, serverName[1], dbName[1]);
        }

        public static void SetDataBaseLogonForCrReport(ReportDocument oReportDocument)
        {
            System.Data.Common.DbConnection connection = (DbProviderHelper.GetConnection());
            String connStr = connection.ConnectionString;
            String pwd = System.Configuration.ConfigurationManager.AppSettings["pwd"];
            string[] connValues = connStr.Split(';');
            string[] serverName = connValues[0].Split('=');
            string[] dbName = connValues[1].Split('=');
            string[] userID = connValues[2].Split('=');
            string[] password = connValues[3].Split('=');
            //System.Data.SqlClient.SqlConnectionStringBuilder SConn = new System.Data.SqlClient.SqlConnectionStringBuilder(connection.ConnectionString);
            //oReportDocument.SetDatabaseLogon(userID[1], pwd, serverName[1], dbName[1]);
            ConnectionInfo conInfo = new ConnectionInfo();
            conInfo.DatabaseName = dbName[1];
            conInfo.Password = pwd;
            conInfo.ServerName = serverName[1];
            conInfo.UserID = userID[1];
            Database cdb = oReportDocument.Database;
            TableLogOnInfo logInfo;
            foreach (Table oCrTable in cdb.Tables)
            {
                logInfo = oCrTable.LogOnInfo;
                logInfo.ConnectionInfo = conInfo;
                oCrTable.ApplyLogOnInfo(logInfo);
            }
        }

        public static string GetDataBaseName()
        {
            System.Data.Common.DbConnection connection = (DbProviderHelper.GetConnection());
            String connStr = connection.ConnectionString;
            string[] connValues = connStr.Split(';');
            string[] dbName = connValues[1].Split('=');
            return dbName[1];
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
