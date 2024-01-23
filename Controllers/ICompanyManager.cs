using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using POSsible.BusinessObjects;


namespace POSsible.Controllers
{
    public interface ICompanyManager
    {

        int addCompany(CCompany oCCompany);
        CCompany getCompanyInfoCode(int iCompanyCode);
        void updateCompany(CCompany oCCompany);
    }
}
