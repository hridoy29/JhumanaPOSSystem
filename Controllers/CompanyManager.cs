using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using POSsible.Models;
using POSsible.Factories;
using POSsible.Views;


namespace POSsible.Controllers
{
    class CompanyManager: ICompanyManager
    {
        private ICompanyModel _CompanyModel;

        /// <summary>
        /// Reference to the ICompanyView
        /// </summary>
        private ICompanyView _CompanyView;

        /// <summary>
        /// null constructor
        /// </summary>
        public CompanyManager()
        {
            _CompanyModel = Factory.GetCompanyModel();
        }

        /// <summary>
        /// Constructor to CompanyManger for CompanyView
        /// </summary>
        /// <param name="_ReferenceForCompanyView"></param>
        public CompanyManager(ICompanyView _ReferenceForCompanyView)
        {
            _CompanyView = _ReferenceForCompanyView;
            _CompanyModel = Factory.GetCompanyModel();
        }

        #region Implementation of ICompanyManager

        public CCompany getCompanyInfoCode(int iCompanyCode)
        {
            CCompany oCCompany = new CCompany();

            try
            {
                SqlDataReader drCompany = _CompanyModel.getCompanyById(iCompanyCode);

                if (drCompany.Read())
                {                    
                    oCCompany.Companycode = int.Parse(drCompany["Companycode"].ToString());
                    oCCompany.CompanyName = drCompany["CompanyName"].ToString();
                    oCCompany.ABN = drCompany["ABN"].ToString();
                    oCCompany.AddressLine1 = drCompany["AddressLine1"].ToString();
                    oCCompany.AddressLine2 = drCompany["AddressLine2"].ToString();
                    oCCompany.City = drCompany["City"].ToString();
                    oCCompany.State = drCompany["State"].ToString();
                    oCCompany.CountryName = drCompany["CountryName"].ToString();
                    oCCompany.PostCode = drCompany["PostCode"].ToString();
                    oCCompany.Phone = drCompany["Phone"].ToString();
                    oCCompany.Fax = drCompany["Fax"].ToString();
                    oCCompany.Email = drCompany["Email"].ToString();
                    oCCompany.Web = drCompany["Web"].ToString();
                    oCCompany.MissionStatement = drCompany["MissionStatement"].ToString();
                    
                    if (drCompany["Logo"].ToString() != "")
                        oCCompany.Image = (byte[])drCompany["Logo"];   
                    
                    if (drCompany["enteredtime"].ToString() != "")
                        oCCompany.EnteredTime = DateTime.Parse(drCompany["enteredtime"].ToString());
                    if (drCompany["enteredby"].ToString() != "")
                        oCCompany.EnteredBy = Convert.ToString(drCompany["enteredby"]);
                    if (drCompany["UpdatedBy"].ToString() != "")
                        oCCompany.UpdatedBy = Convert.ToString(drCompany["UpdatedBy"]);
                    if (drCompany["UpdatedTime"].ToString() != "")
                        oCCompany.UpdatedTime = DateTime.Parse(drCompany["UpdatedTime"].ToString());
                }
            }
            catch (Exception oEx)
            {
            }
            return oCCompany;
        }


        public int addCompany(CCompany oCCompany)
        {
            int iCompanyId = _CompanyModel.addCompany(oCCompany);
            _CompanyView.Alert("Company added successfully.");
            return iCompanyId;
        }


        public void updateCompany(CCompany oCCompany)
        {
            _CompanyModel.updateCompany(oCCompany);
            _CompanyView.Alert("Company updated successfully.");
        }

        #endregion
    }
}
