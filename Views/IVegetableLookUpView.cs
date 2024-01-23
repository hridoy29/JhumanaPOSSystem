using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using POSsible.BusinessObjects;

namespace POSsible.Views
{
    public interface IVegetableLookUpView
    {
        void DisplayVegetableList(List<CProduct> oLstProduct);
    }
}
