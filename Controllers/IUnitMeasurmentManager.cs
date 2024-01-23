using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using POSsible.BusinessObjects;

namespace POSsible.Controllers
{
    /// <summary>
    /// This is the interface of UnitMeasurmentManager the View will use to communicate 
    /// with the Controller object using a simple Call Back Pattern.
    /// </summary>    
    public interface IUnitMeasurmentManager
    {
        List<CUnitMeasurement> getUnitMeasurmentList();
        CUnitMeasurement getUnitMeasurmentId(int iUnitMeasurmentId);

        /// <summary>
        /// For Product Category entry Form
        /// </summary>
        int addUnitMeasurment(CUnitMeasurement oCUnitMeasurement);
        int deleteUnitMeasurment(CUnitMeasurement oCUnitMeasurement);
        void updateUnitMeasurment(CUnitMeasurement oCUnitMeasurement);
    }
}
