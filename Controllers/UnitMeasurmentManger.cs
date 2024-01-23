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
    class UnitMeasurmentManger: IUnitMeasurmentManager
    {
        private IUnitMeasurmentModel _unitMeasurmentModel;

        /// <summary>
        /// Reference to the ISupplierView
        /// </summary>
        private IUnitMeasurmentView _unitMeasurmentView;

        /// <summary>
        /// null constructor
        /// </summary>
        public UnitMeasurmentManger()
        {
            _unitMeasurmentModel = Factory.GetUnitMeasurmentModel();
        }

        /// <summary>
        /// Constructor to UnitMeasurment Manger for UnitMeasurmentView
        /// </summary>
        /// <param name="_ReferenceForUnitMeasurmentMangerView"></param>
        public UnitMeasurmentManger(IUnitMeasurmentView _ReferenceForUnitMeasurmentView)
        {
            _unitMeasurmentView = _ReferenceForUnitMeasurmentView;
            _unitMeasurmentModel = Factory.GetUnitMeasurmentModel();
        }


        #region Implementation of IProductCategoryManager

        public CUnitMeasurement getUnitMeasurmentId(int iUnitMeasurmentId)
        {
            CUnitMeasurement oCUnitMeasurement = new CUnitMeasurement();

            try
            {
                SqlDataReader drUnitMeasurement = _unitMeasurmentModel.getUnitMeasurmentById(iUnitMeasurmentId);

                if (drUnitMeasurement.Read())
                {

                    oCUnitMeasurement.Id = (int)drUnitMeasurement["unitMeasureId"];
                    oCUnitMeasurement.Name = drUnitMeasurement["UnitMeasureName"].ToString();

                    if (drUnitMeasurement["enteredtime"].ToString() != "")
                        oCUnitMeasurement.EnteredTime = DateTime.Parse(drUnitMeasurement["enteredtime"].ToString());
                    if (drUnitMeasurement["enteredby"].ToString() != "")
                        oCUnitMeasurement.EnteredBy = Convert.ToString(drUnitMeasurement["enteredby"]);
                    if (drUnitMeasurement["updatedby"].ToString() != "")
                        oCUnitMeasurement.UpdatedBy = Convert.ToString(drUnitMeasurement["updatedby"]);
                    if (drUnitMeasurement["updatedtime"].ToString() != "")
                        oCUnitMeasurement.UpdatedTime = DateTime.Parse(drUnitMeasurement["updatedtime"].ToString());
                }
            }
            catch (Exception oEx)
            {
            }
            return oCUnitMeasurement;
        }

        /// <summary>
        /// Implementation of IUnitMeasurmentManager.getUnitMeasurmentList
        /// </summary>
        public List<CUnitMeasurement> getUnitMeasurmentList()
        {
            List<CUnitMeasurement> lUnitMeasurementList = new List<CUnitMeasurement>();
            DataSet dsUnitMeasurement = new DataSet();

            try
            {
                dsUnitMeasurement = _unitMeasurmentModel.getUnitMeasurmentList();

                foreach (DataRow drUnitMeasurement in dsUnitMeasurement.Tables[0].Rows)
                {
                    CUnitMeasurement oCUnitMeasurement = new CUnitMeasurement();
                    oCUnitMeasurement.Id = (int)drUnitMeasurement["unitMeasureId"];
                    oCUnitMeasurement.Name = drUnitMeasurement["UnitMeasureName"].ToString();
                                        
                    if (drUnitMeasurement["enteredtime"].ToString() != "")
                        oCUnitMeasurement.EnteredTime = DateTime.Parse(drUnitMeasurement["enteredtime"].ToString());
                    if (drUnitMeasurement["enteredby"].ToString() != "")
                        oCUnitMeasurement.EnteredBy = Convert.ToString(drUnitMeasurement["enteredby"]);
                    if (drUnitMeasurement["updatedby"].ToString() != "")
                        oCUnitMeasurement.UpdatedBy = Convert.ToString(drUnitMeasurement["updatedby"]);
                    if (drUnitMeasurement["updatedtime"].ToString() != "")
                        oCUnitMeasurement.UpdatedTime = DateTime.Parse(drUnitMeasurement["updatedtime"].ToString());

                    lUnitMeasurementList.Add(oCUnitMeasurement);
                }
            }
            catch (Exception oEx)
            {
            }
            return lUnitMeasurementList;
        }


        public int addUnitMeasurment(CUnitMeasurement oCUnitMeasurement)
        {
            int iUnitMeasurementId = _unitMeasurmentModel.addUnitMeasurment(oCUnitMeasurement);
            _unitMeasurmentView.Alert("Unit of Measurment has been saved successfully.");
            return iUnitMeasurementId;
        }

        /// <summary>
        /// Implementation of IUnitMeasurement.addUnitMeasurement
        /// </summary>
        public int deleteUnitMeasurment(CUnitMeasurement oCUnitMeasurement)
        {
            int returnval;
            returnval = _unitMeasurmentModel.deleteUnitMeasurment(oCUnitMeasurement);

            if (returnval != 547)
            {
                _unitMeasurmentView.Alert("Unit of Measurment has been deleted successfully.");

            }
            else
            {
                _unitMeasurmentView.Alert("You have no permission to delete this Unit Measurment.");

            }
            return returnval;
        }

        public void updateUnitMeasurment(CUnitMeasurement oCUnitMeasurement)
        {
            _unitMeasurmentModel.updateUnitMeasurment(oCUnitMeasurement);
            _unitMeasurmentView.Alert("Unit of Measurment has been updated successfully.");
        }

        #endregion
    }
}
