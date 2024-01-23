using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;

namespace POSsible.Views
{
    public interface IFishLookUpView
    {
        void DisplayFishList(List<CProduct> oLstProduct);
        void Alert(string msg);
    }
}
