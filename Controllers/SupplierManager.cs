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
    class SupplierManager:ISupplierManager
    {
        private ISupplierModel _supplierModel;

        /// <summary>
        /// Reference to the ISupplierView
        /// </summary>
        private ISupplierView _supplierView;

        /// <summary>
        /// null constructor
        /// </summary>
        public SupplierManager()
        {
            _supplierModel = Factory.GetSupplierModel();
        }

        /// <summary>
        /// Constructor to Supplier Manager for SupplierView
        /// </summary>
        /// <param name="_ReferenceForSupplierView"></param>
        public SupplierManager(ISupplierView _ReferenceForSupplierView)
        {
            _supplierView = _ReferenceForSupplierView;
            _supplierModel = Factory.GetSupplierModel();
        }

        #region Implementation of ISupplierManager Members
        /// <summary>
        /// Implementation of ISupplierManager.getSupplierList
        /// </summary>
        public List<Supplier> getSupplierList(string sName)
        {
            List<Supplier> lSupplierList = new List<Supplier>();
            DataSet dsSupplier = new DataSet();

            try
            {
                if(sName=="")
                    dsSupplier = _supplierModel.getSupplierList();
                else
                    dsSupplier = _supplierModel.getSupplierListLikeName(sName);

                foreach (DataRow drSupplier in dsSupplier.Tables[0].Rows)
                {
                    Supplier oSupplier=new Supplier();

                    oSupplier.SupplierId=(int)drSupplier["SupplierId"];
                    oSupplier.SupplierName=drSupplier["SupplierName"].ToString();
                    oSupplier.TradingAs=drSupplier["TradingAs"].ToString();
                    oSupplier.ABN=drSupplier["ABN"].ToString();
                    oSupplier.SupplierAddress=drSupplier["SupplierAddress"].ToString();
                    oSupplier.ContactName=drSupplier["ContactName"].ToString();
                    oSupplier.PhoneNo=drSupplier["PhoneNo"].ToString();
                    oSupplier.email = drSupplier["email"].ToString();
                    oSupplier.webadd = drSupplier["webadd"].ToString();
                    oSupplier.comments = drSupplier["comments"].ToString();
                    if(drSupplier["EnteredTime"].ToString()!="")
                        oSupplier.EnteredTime=DateTime.Parse(drSupplier["EnteredTime"].ToString());
                    if(drSupplier["EnteredBy"].ToString()!="")
                        oSupplier.EnteredBy=(int)drSupplier["EnteredBy"];
                    if (drSupplier["UpdatedBy"].ToString() != "")
                        oSupplier.UpdatedBy=(int)drSupplier["UpdatedBy"];
                    if (drSupplier["UpdatedTime"].ToString() != "")
                        oSupplier.UpdatedTime=DateTime.Parse(drSupplier["UpdatedTime"].ToString());

                    lSupplierList.Add(oSupplier);
                }
            }
            catch (Exception oEx)
            {

            }
            return lSupplierList;
        }

        /// <summary>
        /// Implementation of ISupplierManager.getSupplierById
        /// </summary>
        public Supplier getSupplierById(int iSupplierName)
        {
            Supplier oSupplier = new Supplier();

            try
            {
                SqlDataReader drSupplier = _supplierModel.getSupplierById(iSupplierName);
                
                if (drSupplier.Read())
                {
                    oSupplier.SupplierId = (int)drSupplier["SupplierId"];
                    oSupplier.SupplierName = drSupplier["SupplierName"].ToString();
                    oSupplier.TradingAs = drSupplier["TradingAs"].ToString();
                    oSupplier.ABN = drSupplier["ABN"].ToString();
                    oSupplier.SupplierAddress = drSupplier["SupplierAddress"].ToString();
                    oSupplier.ContactName = drSupplier["ContactName"].ToString();
                    oSupplier.PhoneNo = drSupplier["PhoneNo"].ToString();
                    oSupplier.email = drSupplier["email"].ToString();
                    oSupplier.webadd = drSupplier["webadd"].ToString();
                    oSupplier.comments = drSupplier["comments"].ToString();

                    if (drSupplier["EnteredTime"].ToString() != "")
                        oSupplier.EnteredTime = DateTime.Parse(drSupplier["EnteredTime"].ToString());
                    if (drSupplier["EnteredBy"].ToString() != "")
                        oSupplier.EnteredBy = (int)drSupplier["EnteredBy"];
                    if (drSupplier["UpdatedBy"].ToString() != "")
                        oSupplier.UpdatedBy = (int)drSupplier["UpdatedBy"];
                    if (drSupplier["UpdatedTime"].ToString() != "")
                        oSupplier.UpdatedTime = DateTime.Parse(drSupplier["UpdatedTime"].ToString());
                }
            }
            catch (Exception oEx)
            {

            }
            return oSupplier;
        }

        /// <summary>
        /// Implementation of ISupplierManager.addSupplier 
        /// </summary>
        public int addSupplier(Supplier oSupplier)
        {
            int iSupplierId= _supplierModel.addSupplier(oSupplier);
            _supplierView.Alert("Supplier added successfully.");
            return iSupplierId;
        }

        /// <summary>
        /// Implementation of ISupplierManager.addSupplier 
        /// </summary>
        public int deleteSupplier(Supplier oSupplier)
        {
            int returnval;
            returnval=_supplierModel.deleteSupplier(oSupplier);
            if (returnval != 547)
            {
                _supplierView.Alert("Supplier deleted successfully.");
                
            }
            else
            { 
                _supplierView.Alert("You have no permission to delete this supplier.");
                
            }
            return returnval;
        }


        /// <summary>
        /// Implementation of ISupplierManager.updateSupplier 
        /// </summary>
        public void updateSupplier(Supplier oSupplier)
        {
            _supplierModel.updateSupplier(oSupplier);
            _supplierView.Alert("Supplier updated successfully.");
        }
        #endregion
    }
}
