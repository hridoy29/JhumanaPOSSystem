using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public interface ICompanyModel
    {
        SqlDataReader getCompanyById(int iCompanyId);

        int addCompany(CCompany oCCompany);
        //int deleteCompany(CCompany oCCompany);
        void updateCompany(CCompany oCCompany);
    }
}
