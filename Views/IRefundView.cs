using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;

namespace POSsible.Views
{
    public interface IRefundView
    {
        void bindRefundGrid(CInvoice oInvoice);
        void bindInvoiceCombo(List<CInvoice> oLstInvoice);
    }
}
