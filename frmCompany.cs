using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.Controllers;
using POSsible.Views;
using POSsible.Factories;
using System.IO;
using POSsible.DAL;
using System.Linq;

namespace POSsible
{
    public partial class frmCompany : Form
    {
        private long m_lImageFileLength = 0;
        public static byte[] m_barrImg;
        public Users oUser;
        CompanyDAO oCompanyDAO = new CompanyDAO();
        public frmCompany()
        {
            InitializeComponent();
        }

        public frmCompany(Users oUser)
        {
            InitializeComponent();
            this.oUser = oUser;
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            Company C = oCompanyDAO.Company_GetAll().FirstOrDefault();
            if (C == null)
            {
                btnAdd.Text = "ADD";
                txtCompanyCode.Text = "C" + DateTime.Now.Millisecond + "2001";
                return;
            }
            else
                ShowData(C);

        }

        private string isNull(string value)
        {
            value = (string.IsNullOrEmpty(value)) ? string.Empty : value;
            return value;
        }

        private void ShowData(Company oCCompany)
        {
            btnAdd.Text = "UPDATE";

            txtCompanyCode.Text = isNull(oCCompany.CompanyCode);
            txtName.Text = isNull(oCCompany.CompanyName);
            txtABN.Text = isNull(oCCompany.LicenseNo);
            txtRegOfficeAddress.Text = isNull(oCCompany.CompanyAddress);
            txtPhone.Text = isNull(oCCompany.Phone);
            txtFax.Text = isNull(oCCompany.Fax);
            txtEmail.Text = isNull(oCCompany.Email);
            txtWeb.Text = isNull(oCCompany.Web);
            txtMissionStatement.Text = isNull(oCCompany.MissionStatement);
            txtOperateAddrLine1.Text = oCCompany.OperatingAddrLine1;
            txtOperateAddrLine2.Text = oCCompany.OperatingAddrLine2;
            txtWHAddrLine1.Text = oCCompany.WarehouseAddrLine1;
            txtWHAddrLine2.Text = oCCompany.WarehouseAddrLine2;
            txtWHAddrLine3.Text = oCCompany.WarehouseAddrLine3;
            txtWHAddrLine4.Text = oCCompany.WarehouseAddrLine4;
            txtWHAddrLine5.Text = oCCompany.WarehouseAddrLine5;
            txtWHAddrLine6.Text = oCCompany.WarehouseAddrLine6;
            txtWHAddrLine7.Text = oCCompany.WarehouseAddrLine7;
            txtWHAddrLine8.Text = oCCompany.WarehouseAddrLine8;

            if (oCCompany.Logo != null)
            {
                m_barrImg = oCCompany.Logo;
                string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                fs.Write(oCCompany.Logo, 0, oCCompany.Logo.Length);
                fs.Flush();
                fs.Close();

                picLogo.Image = Image.FromFile(strfn);
            }
            else
                picLogo.Image = null;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtABN.Text = txtName.Text = txtRegOfficeAddress.Text = txtPhone.Text = txtFax.Text = txtEmail.Text = txtWeb.Text = txtMissionStatement.Text = txtPictureBox.Text = "";
            txtOperateAddrLine1.Text = txtOperateAddrLine2.Text = txtWHAddrLine1.Text = txtWHAddrLine2.Text = txtWHAddrLine3.Text = string.Empty;
            txtWHAddrLine4.Text = txtWHAddrLine5.Text = txtWHAddrLine6.Text = txtWHAddrLine7.Text = txtWHAddrLine8.Text = string.Empty;

            txtName.Focus();
        }

        protected void LoadImage()
        {
            try
            {
                OFDPicture.Filter = "Picture Files |*.png;*.jpg;*.jpeg;*.bmp";
                this.OFDPicture.ShowDialog(this);
                string strFn = this.OFDPicture.FileName;
                picLogo.Image = Image.FromFile(strFn);
                txtPictureBox.Text = strFn;
                FileInfo fiImage = new FileInfo(strFn);
                this.m_lImageFileLength = fiImage.Length;

                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckValidity()
        {
            if (txtName.Text == "")
            {
                Alert("Enter Company Name");
                txtName.Focus();
                return false;
            }
            if (txtRegOfficeAddress.Text == "")
            {
                Alert("Enter Company Address.");
                txtRegOfficeAddress.Focus();
                return false;
            }
            if (txtABN.Text == "")
            {
                Alert("Enter License No.");
                txtABN.Focus();
                return false;
            } if (txtPhone.Text == "")
            {
                Alert("Enter Phone No.");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            try
            {
                if (CheckValidity())
                {
                    Company oCCompany = new Company();

                    oCCompany.CompanyName = txtName.Text.Trim();
                    oCCompany.LicenseNo = txtABN.Text.Trim();
                    oCCompany.CompanyCode = txtCompanyCode.Text.Trim();
                    oCCompany.Phone = txtPhone.Text.Trim();
                    oCCompany.Fax = txtFax.Text.Trim();
                    oCCompany.Email = txtEmail.Text.Trim();
                    oCCompany.Web = txtWeb.Text.Trim();
                    oCCompany.MissionStatement = txtMissionStatement.Text.Trim();
                    oCCompany.Logo = m_barrImg;
                    oCCompany.CompanyAddress = txtRegOfficeAddress.Text.Trim();
                    oCCompany.OperatingAddrLine1 = txtOperateAddrLine1.Text.Trim();
                    oCCompany.OperatingAddrLine2 = txtOperateAddrLine2.Text.Trim();
                    oCCompany.WarehouseAddrLine1 = txtWHAddrLine1.Text.Trim();
                    oCCompany.WarehouseAddrLine2 = txtWHAddrLine2.Text.Trim();
                    oCCompany.WarehouseAddrLine3 = txtWHAddrLine3.Text.Trim();
                    oCCompany.WarehouseAddrLine4 = txtWHAddrLine4.Text.Trim();
                    oCCompany.WarehouseAddrLine5 = txtWHAddrLine5.Text.Trim();
                    oCCompany.WarehouseAddrLine6 = txtWHAddrLine6.Text.Trim();
                    oCCompany.WarehouseAddrLine7 = txtWHAddrLine7.Text.Trim();
                    oCCompany.WarehouseAddrLine8 = txtWHAddrLine8.Text.Trim();


                    if (btnAdd.Text == "UPDATE")
                    {
                        oCompanyDAO.update(oCCompany);
                        Alert("Company information updated successfully.");
                    }
                    else if (btnAdd.Text == "ADD")
                    {
                        int iCustomerId = oCompanyDAO.Add(oCCompany);
                    }

                    ShowData(oCCompany);
                }
            }
            catch (Exception ex)
            {
                if (btnAdd.Text == "UPDATE")
                {
                    Alert("Company information did not updated successfully.");
                }
                else
                {
                    Alert("Company information did not added successfully.");
                }
            }
        }

        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "POSsible");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}