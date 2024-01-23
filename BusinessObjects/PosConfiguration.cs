using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;
using Microsoft.Win32;
using POSsible.Properties;
using System.Resources;

namespace POSsible.BusinessObjects
{
   public class POSConfiguration
    {
        private string m_sUserName;
        private string m_sPassword;
        private string m_sDatabase;
        private string m_sServer;
        private string m_sTerminalName;
        private string m_sTerminalIp;
        private string m_sPrinterName;
        private string m_sScalePort;
        

       public POSConfiguration()
       { }
        
       public POSConfiguration(string sUserName, string sPassword, string sDatabase, string sServer, string sTerminalName, string sTerminalIp)
        {

            this.m_sUserName = sUserName;
            this.m_sPassword = sPassword;
            this.m_sDatabase = sDatabase;
            this.m_sServer = sServer;
            this.m_sTerminalName = sTerminalName;
            this.m_sTerminalIp = sTerminalIp;

        }

       public string UserName
        {
            get
            {
                return m_sUserName;
            }
            set
            {
                m_sUserName=value ;
            }
        }
       
       public string Password
        {
            get
            {
                return m_sPassword;
            }
            set
            {
                m_sPassword = value;
            }
        }
       
       public string Database
        {
            get
            {
                return m_sDatabase;
            }
            set
            {
                m_sDatabase = value;
            }
        }
       
       public string Server
        {
            get
            {
                return m_sServer;
            }
            set
            {
                m_sServer = value;
            }
        }

       public string TerminalName
        {
            get
            {
                return m_sTerminalName;
            }
            set
            {
                m_sTerminalName = value;
            }
        }
       
       public string TerminalIP
        {
            get
            {
                return m_sTerminalIp;
            }
            set
            {
                m_sTerminalIp = value;
            }
        }

       public string PrinterName
       {
           get
           {
               return m_sPrinterName;
           }
           set
           {
               m_sPrinterName = value;
           }
       }
       public string ScalePortName
       {
           get
           {
               return m_sScalePort;
           }
           set
           {
               m_sScalePort = value;
           }
       }
       
       /// <summary>
        /// returns the connection string getting info from the registry
        /// </summary>
        /// <returns></returns>       
       public string getConnectionstring()
        {


            string subKey = "SOFTWARE\\POSSettings\\DBSettings"; //+ Application.ProductName.ToUpper();
            RegistryKey objRegistryKey = Registry.LocalMachine;
            // Open a subKey as read-only
            RegistryKey skey = objRegistryKey.OpenSubKey(subKey);


            /// <summary>
            /// Open the Registry Key
            /// </summary>
            RegistryKey pRegKey = Registry.LocalMachine;
            RegistryKey RegKeyUser = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\UserName", true);
            RegistryKey RegKeyPassword = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Password", true);
            RegistryKey RegKeyServer = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Server", true);
            RegistryKey RegKeyDatabase = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\Database", true);
            RegistryKey RegKeyTerminalIP = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\TerminalIP", true);
            RegistryKey RegKeyPrinterName = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\PrinterName", true);
            RegistryKey RegKeyScalePortName = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\ScalePortName", true);

            
            
            //RegistryKey objRegistryKey = Registry.LocalMachine;
            //string sUserName = (string)RegKeyUser.GetValue("UserName");
            //string sPassword = (string)RegKeyPassword.GetValue("Password");
            //string sServer = (string)RegKeyServer.GetValue("Server");
            //string sDatabase = (string)RegKeyDatabase.GetValue("Database");

            //string connString = " server ='" + sServer + "'"
            //                    +"database ='"+sDatabase+"'"
            //                    +"user id ='" + sUserName + "'"
            //                    +"password ='" + sPassword + "'";
            string sUserName = (string)skey.GetValue("UserName");
            string sPassword = (string)skey.GetValue("Password");
            string sServer = (string)skey.GetValue("Server");
            string sDatabase = (string)skey.GetValue("Database");

            string sTerminalIP = (string)skey.GetValue("TerminalIP");
            string sPrinterName = (string)skey.GetValue("PrinterName");
            string sScalePortName = (string)skey.GetValue("ScalePortName");



            string connString = " server ='" + sServer + "';"
                                +"database ='"+sDatabase+"';"
                                +"user id ='" + sUserName + "';"
                                +"password ='" + sPassword + "';";

            //string connString = "Data Source=THESTRANGER\\SQLEXPRESS;Initial Catalog=RITPOS;User Id=sa;Password=sa;";
            return connString;

        }
       
       /// <summary>
        /// sets the registry key for Database Host, DataBase Name,DataBase User and password for the user
        /// </summary>
        /// <param name="dbHost"></param>
        /// <param name="dbName"></param>
        /// <param name="dbUser"></param>
        /// <param name="dbPassword"></param>
       
       public void setConnectionstring(string dbHost,string dbName,string dbUser,string dbPassword )
        {
        }

       public string getScalePortName()
       {
           string subKey = "SOFTWARE\\POSSettings\\DBSettings"; //+ Application.ProductName.ToUpper();
           RegistryKey objRegistryKey = Registry.LocalMachine;
           // Open a subKey as read-only
           RegistryKey skey = objRegistryKey.OpenSubKey(subKey);

           /// <summary>
           /// Open the Registry Key
           /// </summary>
           RegistryKey pRegKey = Registry.LocalMachine;            
           RegistryKey RegKeyScalePortName = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\ScalePortName", true);

           string sScalePortName = (string)skey.GetValue("ScalePortName");

           return sScalePortName;
       }
       
       /// <summary>
       /// Sets the printer name to system registry
       /// </summary>
       /// <param name="printerName"></param>
       
       public void setPrinter(string printerName)
       {

       }
       /// <summary>
       /// Retrives the printer name from system Registry
       /// </summary>
       /// <returns></returns>
       public string getPrinter()
       {
           string subKey = "SOFTWARE\\POSSettings\\DBSettings"; //+ Application.ProductName.ToUpper();
           RegistryKey objRegistryKey = Registry.LocalMachine;
           // Open a subKey as read-only
           RegistryKey skey = objRegistryKey.OpenSubKey(subKey);

           /// <summary>
           /// Open the Registry Key
           /// </summary>
           RegistryKey pRegKey = Registry.LocalMachine;            
           RegistryKey RegKeyTerminalIP = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\TerminalIP", true);
           RegistryKey RegKeyPrinterName = pRegKey.OpenSubKey("SOFTWARE\\POSSettings\\DBSettings\\PrinterName", true);
           
           string sTerminalIP = (string)skey.GetValue("TerminalIP");
           string sPrinterName = (string)skey.GetValue("PrinterName");
           
           return "\\\\" + sTerminalIP.Trim() + "\\" + sPrinterName.Trim();

           //return Settings.Default.PrinterName.ToString();        

       }


#region ReadResourceFile
/// <summary>
/// method for reading a value from a resource file
/// (.resx file)
/// </summary>
/// <param name="file">file to read from</param>
/// <param name="key">key to get the value for</param>
/// <returns>a string value</returns>
public string ReadResourceValue(string file, string key)
{
    //value for our return value
    string resourceValue = string.Empty;
    try
    {
        // specify your resource file name 
        string resourceFile = file;
        // get the path of your file
        string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        // create a resource manager for reading from
        //the resx file
        ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
        // retrieve the value of the specified key
        resourceValue = resourceManager.GetString(key);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        resourceValue = string.Empty;
    }
    return resourceValue;
}
#endregion

    }
}
