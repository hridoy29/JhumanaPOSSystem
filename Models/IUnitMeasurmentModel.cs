using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using POSsible.BusinessObjects;


namespace POSsible.Models
{
    public interface IUnitMeasurmentModel
    {
        DataSet getUnitMeasurmentList();
        //DataSet getUnitMeasurmentListLikeName(string sName);
        SqlDataReader getUnitMeasurmentById(int iUnitMeasurmentId);

        int addUnitMeasurment(CUnitMeasurement oCUnitMeasurement);
        int deleteUnitMeasurment(CUnitMeasurement oCUnitMeasurement);
        void updateUnitMeasurment(CUnitMeasurement oCUnitMeasurement);
    }
}
