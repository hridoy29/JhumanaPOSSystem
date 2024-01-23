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
    class CustomerInvoiceManager : ICustomerInvoiceManager
    {
        private ICustomerInvoiceModel _customerInvoiceModel;

        /// <summary>
        /// Reference to the ISupplierView
        /// </summary>
        private ICustomerInvoiceView _customerInvoiceView;

        /// <summary>
        /// null constructor
        /// </summary>
        public CustomerInvoiceManager()
        {
            _customerInvoiceModel = Factory.GetCustomerInvoiceModel();
        }

        /// <summary>
        /// Constructor to UnitMeasurment Manger for UnitMeasurmentView
        /// </summary>
        /// <param name="_ReferenceForUnitMeasurmentMangerView"></param>
        public CustomerInvoiceManager(ICustomerInvoiceView _ReferenceForCustomerInvoiceView)
        {
            _customerInvoiceView = _ReferenceForCustomerInvoiceView;
            _customerInvoiceModel = Factory.GetCustomerInvoiceModel();
        }

        /// <summary>
        /// Implementation of IUnitMeasurmentManager.getUnitMeasurmentList
        /// </summary>
        public List<CCustomerInvoice> getCustomerInvoiceList(string sCustomerBarcode)
        {
            List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();
            DataSet dsCustomerInvoice = new DataSet();

            try
            {
                dsCustomerInvoice = _customerInvoiceModel.getInvoiceListByCustomer(sCustomerBarcode);

                foreach (DataRow drCustomerInvoice in dsCustomerInvoice.Tables[0].Rows)
                {

                    CCustomerInvoice oCCustomerInvoice = new CCustomerInvoice();

                    oCCustomerInvoice.InvoiceId = (int)drCustomerInvoice["invoiceId"];
                    oCCustomerInvoice.CustomerBarCode = drCustomerInvoice["CustomerIDBarCodeNo"].ToString();
                    oCCustomerInvoice.InvoiceAmount = float.Parse(drCustomerInvoice["invoiceAmount"].ToString());
                    oCCustomerInvoice.PointsEarned = float.Parse(drCustomerInvoice["pointsEarned"].ToString());
                    oCCustomerInvoice.InvoiceDate = DateTime.Parse(drCustomerInvoice["invoiceDate"].ToString());


                    if (drCustomerInvoice["enteredTime"].ToString() != "")
                        oCCustomerInvoice.EnteredTime = DateTime.Parse(drCustomerInvoice["enteredTime"].ToString());
                    if (drCustomerInvoice["enteredBy"].ToString() != "")
                        oCCustomerInvoice.EnteredBy = Convert.ToString(drCustomerInvoice["enteredBy"]);
                    if (drCustomerInvoice["updatedBy"].ToString() != "")
                        oCCustomerInvoice.UpdatedBy = Convert.ToString(drCustomerInvoice["updatedBy"]);
                    if (drCustomerInvoice["updatedTime"].ToString() != "")
                        oCCustomerInvoice.UpdatedTime = DateTime.Parse(drCustomerInvoice["updatedTime"].ToString());

                    lCustomerInvoiceList.Add(oCCustomerInvoice);
                }
            }
            catch (Exception oEx)
            {
            }
            return lCustomerInvoiceList;
        }

        

        public void updateCustomerInvoice(CCustomerInvoice oCCustomerInvoice)
        {
            _customerInvoiceModel.updateCustomerInvoice(oCCustomerInvoice);
            _customerInvoiceView.Alert("Customer invoice updated successfully.");
        }

        /// <summary>
        /// Implementation of ICustomerInvoiceClaimPaoint
        /// </summary>
        public void createCustomerPointClaim(List<CCustomerInvoice> oCustomerInvoice)
        {
            _customerInvoiceModel.createCustomerClaimPoint(oCustomerInvoice);
            _customerInvoiceView.Alert("Customer claim point added successfully.");            
        }

        /// <summary>
        /// Customer Point Claim List
        /// </summary>
        /// <returns></returns>
        public List<CCustomerInvoice> getCustomerPointClaimList()
        {
            List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();
            DataSet dsCustomerInvoice = new DataSet();

            try
            {
                dsCustomerInvoice = _customerInvoiceModel.getCustomerClaimPointList();

                foreach (DataRow drCustomerInvoice in dsCustomerInvoice.Tables[0].Rows)
                {
                    CCustomerInvoice oCCustomerInvoice = new CCustomerInvoice();

                    oCCustomerInvoice.CustomerBarCode = drCustomerInvoice["CustomerIDBarCodeNo"].ToString();
                    oCCustomerInvoice.InvoiceAmount = float.Parse(drCustomerInvoice["TotalEarnedPoint"].ToString());
                    oCCustomerInvoice.PointsEarned = float.Parse(drCustomerInvoice["TotalClaimPoint"].ToString());
                    oCCustomerInvoice.Name = drCustomerInvoice["Name"].ToString();
                    oCCustomerInvoice.Address = drCustomerInvoice["Address"].ToString();
                    oCCustomerInvoice.Mobile = drCustomerInvoice["mobile"].ToString();
                    oCCustomerInvoice.HomePhone = drCustomerInvoice["homephone"].ToString();
                    oCCustomerInvoice.Sex = drCustomerInvoice["sex"].ToString();

                    lCustomerInvoiceList.Add(oCCustomerInvoice);
                }
            }
            catch (Exception oEx)
            {
            }
            return lCustomerInvoiceList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSOption"></param>
        /// <param name="strSearchText"></param>
        /// <returns></returns>
        public List<CCustomerInvoice> getCustomerPointClaimListSearch(int iSOption, string strSearchText)
        {
            List<CCustomerInvoice> lCustomerInvoiceList = new List<CCustomerInvoice>();
            DataSet dsCustomerInvoice = new DataSet();

            try
            {
                dsCustomerInvoice = _customerInvoiceModel.getCustomerClaimPointList(iSOption, strSearchText);

                foreach (DataRow drCustomerInvoice in dsCustomerInvoice.Tables[0].Rows)
                {
                    CCustomerInvoice oCCustomerInvoice = new CCustomerInvoice();

                    oCCustomerInvoice.CustomerBarCode = drCustomerInvoice["CustomerIDBarCodeNo"].ToString();

                    if (drCustomerInvoice["TotalEarnedPoint"] != null)
                        oCCustomerInvoice.InvoiceAmount = float.Parse(drCustomerInvoice["TotalEarnedPoint"].ToString());

                    if (drCustomerInvoice["TotalClaimPoint"] != null)
                        oCCustomerInvoice.PointsEarned = float.Parse(drCustomerInvoice["TotalClaimPoint"].ToString());

                    oCCustomerInvoice.Name = drCustomerInvoice["Name"].ToString();
                    oCCustomerInvoice.Address = drCustomerInvoice["Address"].ToString();
                    oCCustomerInvoice.Mobile = drCustomerInvoice["mobile"].ToString();
                    oCCustomerInvoice.HomePhone = drCustomerInvoice["homephone"].ToString();
                    oCCustomerInvoice.Sex = drCustomerInvoice["sex"].ToString();

                    lCustomerInvoiceList.Add(oCCustomerInvoice);
                }
            }
            catch (Exception oEx)
            {
            }
            return lCustomerInvoiceList;
        }
    }
}
