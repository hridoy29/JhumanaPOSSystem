using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;

namespace POSsible.Views
{
    public interface IAuthorization
    {
        void goToAuthorizationform(CUser oUser);
    }
}
