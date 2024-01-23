using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;

namespace POSsible.Views
{
    public interface IItemView
    {
        void Alert(string sMsg);
        void updateItemGrid(List<CProduct> oProduct);
        void ClearFormContent();
        void FillUpFormContent(CProduct oProduct);
        void putDepartmentList(List<CDepartment> oLstDepartment);
        void putUnitMeasurementList(List<CUnitMeasurement> oLstMeasurementList);
    }
}
