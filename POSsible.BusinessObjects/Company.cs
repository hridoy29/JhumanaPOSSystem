using System;
using System.Text;

namespace POSsible.BusinessObjects
{
    [Serializable()]
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyAddress { get; set; }
        public string LicenseNo { get; set; }
        public string MissionStatement { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public Byte[] Logo { get; set; }
        public string OperatingAddrLine1 { get; set; }
        public string OperatingAddrLine2 { get; set; }
        public string WarehouseAddrLine1 { get; set; }
        public string WarehouseAddrLine2 { get; set; }
        public string WarehouseAddrLine3 { get; set; }
        public string WarehouseAddrLine4 { get; set; }
        public string WarehouseAddrLine5 { get; set; }
        public string WarehouseAddrLine6 { get; set; }
        public string WarehouseAddrLine7 { get; set; }
        public string WarehouseAddrLine8 { get; set; }

        public Company()
        { }

        public Company(string CompanyName, string CompanyCode, string CompanyAddress, string LicenseNo, string MissionStatement, string Phone, string Fax, string Email, string Web, Byte[] Logo)
        {
            this.CompanyName = CompanyName;
            this.CompanyCode = CompanyCode;
            this.CompanyAddress = CompanyAddress;
            this.LicenseNo = LicenseNo;
            this.MissionStatement = MissionStatement;
            this.Phone = Phone;
            this.Fax = Fax;
            this.Email = Email;
            this.Web = Web;
            this.Logo = Logo;
        }

        public override string ToString()
        {
            return "CompanyName = " + CompanyName + ",CompanyCode = " + CompanyCode + ",CompanyAddress = " + CompanyAddress + ",LicenseNo = " + LicenseNo + ",MissionStatement = " + MissionStatement + ",Phone = " + Phone + ",Fax = " + Fax + ",Email = " + Email + ",Web = " + Web + ",Logo = " + Logo.ToString();
        }

    }
}
