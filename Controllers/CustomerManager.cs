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
    class CustomerManager:ICustomerManager
    {
         private ICustomerModel _customerModel;

        /// <summary>
        /// Reference to the ICustomerrView
        /// </summary>
        private ICustomerView _customerView;

        /// <summary>
        /// null constructor
        /// </summary>
        public CustomerManager()
        {
            _customerModel = Factory.GetCusomerModel();
        }

        /// <summary>
        /// Constructor to Customer Manager for CustomerView
        /// </summary>
        /// <param name="_ReferenceForCustomerView"></param>
        public CustomerManager(ICustomerView _ReferenceForCustomerView)
        {
            _customerView = _ReferenceForCustomerView;
            _customerModel = Factory.GetCusomerModel();
        }

        #region Implementation of ICustomerManager Members
        /// <summary>
        /// Implementation of ICustomerManager.getCustomerList
        /// </summary>
        public List<Customer> getCustomerList(string sName)
        {
            List<Customer> lCustomerList = new List<Customer>();
            DataSet dsCustomer = new DataSet();

            try
            {
                if(sName=="")
                    dsCustomer = _customerModel.getCustomerList();
                else
                    dsCustomer = _customerModel.getCustomerListLikeName(sName);

                foreach (DataRow drCustomer in dsCustomer.Tables[0].Rows)
                {
                    Customer oCustomer = new Customer();

                    oCustomer.CustomerId = (int)drCustomer["customerId"];
                    oCustomer.CustomerBarCode = drCustomer["CustomerIDBarCodeNo"].ToString();
                    oCustomer.CustomerName = drCustomer["Name"].ToString();
                    oCustomer.Country = drCustomer["country"].ToString();
                    oCustomer.State = drCustomer["state"].ToString();
                    oCustomer.Street_no = drCustomer["street_no"].ToString();
                    oCustomer.Mobile = drCustomer["mobile"].ToString();
                    oCustomer.Postcode = drCustomer["postcode"].ToString();
                    oCustomer.Suburb = drCustomer["suburb"].ToString();
                    oCustomer.Workphone = drCustomer["workphone"].ToString();
                    if (drCustomer["sex"].Equals(true))
                        oCustomer.Sex = 1;
                    else
                        oCustomer.Sex = 0;
                    oCustomer.Homephone = drCustomer["homephone"].ToString();
                    if (drCustomer["EnteredTime"].ToString() != "")
                        oCustomer.EnteredTime = DateTime.Parse(drCustomer["EnteredTime"].ToString());
                    if (drCustomer["EnteredBy"].ToString() != "")
                        oCustomer.EnteredBy = (int)drCustomer["EnteredBy"];
                    if (drCustomer["UpdatedBy"].ToString() != "")
                        oCustomer.UpdatedBy = (int)drCustomer["UpdatedBy"];
                    if (drCustomer["UpdatedTime"].ToString() != "")
                        oCustomer.UpdatedTime = DateTime.Parse(drCustomer["UpdatedTime"].ToString());

                    lCustomerList.Add(oCustomer);
                }
            }
            catch (Exception oEx)
            {

            }
            return lCustomerList;
        }

        /// <summary>
        /// Implementation of ICustomerManager.getCustomerByBarCode
        /// </summary>
        public Customer getCustomerByBarCode(string sCustomerBarCode)
        {
            Customer oCustomer;

            try
            {
                oCustomer = new Customer();
                SqlDataReader drCustomer = _customerModel.getCustomerByBarCode(sCustomerBarCode);

                if (drCustomer.Read())
                {
                    oCustomer.CustomerId = (int)drCustomer["customerId"];
                    oCustomer.CustomerBarCode = drCustomer["CustomerIDBarCodeNo"].ToString();
                    oCustomer.CustomerName = drCustomer["Name"].ToString();
                    oCustomer.Country = drCustomer["country"].ToString();
                    oCustomer.State = drCustomer["state"].ToString();
                    oCustomer.Street_no = drCustomer["street_no"].ToString();
                    oCustomer.Mobile = drCustomer["mobile"].ToString();
                    oCustomer.Postcode = drCustomer["postcode"].ToString();
                    oCustomer.Suburb = drCustomer["suburb"].ToString();
                    oCustomer.Workphone = drCustomer["workphone"].ToString();
                    if (drCustomer["sex"].Equals(true))
                        oCustomer.Sex = 1;
                    else
                        oCustomer.Sex = 0;
                    oCustomer.Homephone = drCustomer["homephone"].ToString();
                    if (drCustomer["EnteredTime"].ToString() != "")
                        oCustomer.EnteredTime = DateTime.Parse(drCustomer["EnteredTime"].ToString());
                    if (drCustomer["EnteredBy"].ToString() != "")
                        oCustomer.EnteredBy = (int)drCustomer["EnteredBy"];
                    if (drCustomer["UpdatedBy"].ToString() != "")
                        oCustomer.UpdatedBy = (int)drCustomer["UpdatedBy"];
                    if (drCustomer["UpdatedTime"].ToString() != "")
                        oCustomer.UpdatedTime = DateTime.Parse(drCustomer["UpdatedTime"].ToString());
                }
                else
                {
                    oCustomer = null;
                }
            }
            catch (Exception oEx)
            {
                oCustomer = null;
            }
            return oCustomer;
        }


        /// <summary>
        /// Implementation of ICustomerManager.getCustomerById
        /// </summary>
        public Customer getCustomerById(int iCustomerId)
        {
            Customer oCustomer ;

            try
            {
                oCustomer = new Customer();
                SqlDataReader drCustomer = _customerModel.getCustomerById(iCustomerId);

                if (drCustomer.Read())
                {
                    oCustomer.CustomerId = (int)drCustomer["customerId"];
                    oCustomer.CustomerBarCode = drCustomer["CustomerIDBarCodeNo"].ToString();
                    oCustomer.CustomerName = drCustomer["Name"].ToString();
                    oCustomer.Country = drCustomer["country"].ToString();
                    oCustomer.State = drCustomer["state"].ToString();
                    oCustomer.Street_no = drCustomer["street_no"].ToString();
                    oCustomer.Mobile = drCustomer["mobile"].ToString();
                    oCustomer.Postcode = drCustomer["postcode"].ToString();
                    oCustomer.Suburb = drCustomer["suburb"].ToString();
                    oCustomer.Workphone = drCustomer["workphone"].ToString();
                    if (drCustomer["sex"].Equals(true))
                        oCustomer.Sex = 1;
                    else
                        oCustomer.Sex = 0;
                    oCustomer.Homephone = drCustomer["homephone"].ToString();
                    if (drCustomer["EnteredTime"].ToString() != "")
                        oCustomer.EnteredTime = DateTime.Parse(drCustomer["EnteredTime"].ToString());
                    if (drCustomer["EnteredBy"].ToString() != "")
                        oCustomer.EnteredBy = (int)drCustomer["EnteredBy"];
                    if (drCustomer["UpdatedBy"].ToString() != "")
                        oCustomer.UpdatedBy = (int)drCustomer["UpdatedBy"];
                    if (drCustomer["UpdatedTime"].ToString() != "")
                        oCustomer.UpdatedTime = DateTime.Parse(drCustomer["UpdatedTime"].ToString());
                }
                else
                {
                    oCustomer = null;
                }
            }
            catch (Exception oEx)
            {
                oCustomer = null;
            }
            return oCustomer;
        }

        /// <summary>
        /// Implementation of ICustomerManager.addCustomer 
        /// </summary>
        public int addCustomer(Customer oCustomer)
        {
            int iCustomerId = _customerModel.addCustomer(oCustomer);
            _customerView.Alert("Customer added successfully.");
            return iCustomerId;
        }

        /// <summary>
        /// Implementation of ICustomerManager.DeleteCustomer 
        /// </summary>
        public int deleteCustomer(Customer oCustomer)
        {
            int returnval;
            returnval = _customerModel.deleteCustomer(oCustomer);
            if (returnval != 547)
            {
                _customerView.Alert("Customer deleted successfully.");
                
            }
            else
            {
                _customerView.Alert("You have no permission to delete this Customer.");
                
            }
            return returnval;
        }


        /// <summary>
        /// Implementation of ICustomerManager.updateCustomer 
        /// </summary>
        public void updateCustomer(Customer oCustomer)
        {
            _customerModel.updateCustomer(oCustomer);
            _customerView.Alert("Customer updated successfully.");
        }
        #endregion

    }
}
