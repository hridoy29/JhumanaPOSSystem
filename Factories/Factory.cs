using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;
using POSsible.Models;
using POSsible.Views;
using POSsible.Controllers;

namespace POSsible.Factories
{
    #region Factories
    /// <summary>
    ///Used a simple Factory pattern here to create Models and Controllers
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Reference of IProductModel
        /// have the factory 
        /// </summary>
        private static POSsible.Models.IProductModel _ProductModel;
      

        /// <summary>
        /// Get's an instatiated IProductModel object
        /// </summary>
        /// <returns></returns>
        public static POSsible.Models.IProductModel GetProductModel()
        {
            if (_ProductModel == null)
            {
                _ProductModel = new POSsible.Models.ProductModel();
            }
            return _ProductModel;
        }


        /// <summary>
        /// Get's an instantiated IProductManager object
        /// </summary>
        /// <param name="VegetableLookUpView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IVegetableLookUpView _VegetableLookUpView)
        {
            return new POSsible.Controllers.ProductManager(_VegetableLookUpView);
        }

        /// <summary>
        /// Get's an instantiated IProductManager object
        /// </summary>
        /// <param name="FruitLookUpview"></param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IFruitLookUpView _FruitLookUpview)
        {
            return new POSsible.Controllers.ProductManager(_FruitLookUpview);
        }

        /// <summary>
        /// Get's an instantiated IProductManager object
        /// </summary>
        /// <param name="VegetableLookUpView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IMeatLookUpView _MeatLookUpView)
        {
            return new POSsible.Controllers.ProductManager(_MeatLookUpView);
        }

        /// <summary>
        /// Get's an instantiated IProductManager object
        /// </summary>
        /// <param name="FishLookUpView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IFishLookUpView _FishLookUpView)
        {
            return new POSsible.Controllers.ProductManager(_FishLookUpView);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_IMainView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IProductCategoryView _IProductCategoryView)
        {
            return new POSsible.Controllers.ProductManager(_IProductCategoryView);
        }

        /// <summary>
        /// Get's instantiated IProductManager Object
        /// </summary>
        /// <param name="_PluView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IPluView _PluView)
        {
            return new POSsible.Controllers.ProductManager(_PluView);
        }

        /// <summary>
        /// Get's instantiated IProductManager Object for ItemView
        /// </summary>
        /// <param name="_ItemView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IItemView _ItemView)
        {
            return new POSsible.Controllers.ProductManager(_ItemView);
        }


        /// <summary>
        /// Get's instantiated IProductManager Object for IMainView
        /// </summary>
        /// <param name="_ItemView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.IProductManager GetProductManager(POSsible.Views.IMainView _IMainView)
        {
            return new POSsible.Controllers.ProductManager(_IMainView);
        }
        
        /// <summary>
        /// Reference of ISecurityModel
        /// have the factory 
        /// </summary>
        private static POSsible.Models.ISecurityModel _SecurityModel;

        /// <summary>
        /// Get's an instatiated ISecurityModelobject
        /// </summary>
        /// <returns></returns>
        public static POSsible.Models.ISecurityModel GetSecurityModel()
        {
            if (_SecurityModel == null)
            {
                _SecurityModel = new POSsible.Models.SecurityModel();
            }
            return _SecurityModel;
        }

        /// <summary>
        ///  Get's instantiated ISecurityManager Object for ILoginView
        /// </summary>
        /// <param name="_LoginView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.ISecurityManager GetSecurityManager(POSsible.Views.ILoginView _LoginView)
        {
            return new POSsible.Controllers.SecurityManager(_LoginView);
        }

        /// <summary>
        ///  Get's instantiated ISalesManager Object for IDBSettingsView
        /// </summary>
        /// <param name="_DBSettingsView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.ISecurityManager GetSecurityManager(POSsible.Views.IDBSettingsView _DBSettingsView)
        {
            return new POSsible.Controllers.SecurityManager(_DBSettingsView);
        }


        /// <summary>
        ///  Get's instantiated ISalesManager Object for IDBSettingsView
        /// </summary>
        /// <param name="_DBSettingsView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.ISecurityManager GetSecurityManager(POSsible.Views.IMainView _MainView)
        {
            return new POSsible.Controllers.SecurityManager(_MainView);
        }


        public static POSsible.Controllers.ISecurityManager GetSecurityManager(POSsible.Views.IAuthorization _Authorization)
        {
            return new POSsible.Controllers.SecurityManager(_Authorization);
        }

        /// <summary>
        /// Reference of ISalesModel
        /// have the factory 
        /// </summary>
        private static POSsible.Models.ISalesModel _SalesModel;

        /// <summary>
        /// Get's an instatiated ISalesModel
        /// </summary>
        /// <returns></returns>
        public static POSsible.Models.ISalesModel GetSalesModel()
        {

            if (_SalesModel == null)
            {
                _SalesModel = new POSsible.Models.SalesModel();
            }
            return _SalesModel;
        }

        /// <summary>
        /// Get's instantiated ISalesManager Object for IShiftStartView
        /// </summary>
        /// <param name="_ShiftStartView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.ISalesManager GetSalesManager(POSsible.Views.IShiftStartView _ShiftStartView)
        {
            return new POSsible.Controllers.SalesManager(_ShiftStartView);
        }

        /// <summary>
        /// Get's instantiated ISalesManager Object for IShiftEndView
      /// </summary>
      /// <param name="_ShiftEndView"></param>
      /// <returns></returns>
        public static POSsible.Controllers.ISalesManager GetSalesManager(POSsible.Views.IShiftEndView _ShiftEndView)
        {
            return new POSsible.Controllers.SalesManager(_ShiftEndView);
        }


        /// <summary>
        ///  Get's instantiated ISalesManager Object for ISafeFundView
       /// </summary>
       /// <param name="_SafeFundView"></param>
       /// <returns></returns>
        public static POSsible.Controllers.ISalesManager GetSalesManager(POSsible.Views.ISafeFundView _SafeFundView)
        {
            return new POSsible.Controllers.SalesManager(_SafeFundView);
        }

        


        /// <summary>
        ///  Get's instantiated ISalesManager Object for ISafeFundView
        /// </summary>
        /// <param name="_SafeFundView"></param>
        /// <returns></returns>
        public static POSsible.Controllers.ISalesManager GetSalesManager(POSsible.Views.IMainView _MainView)
        {
            return new POSsible.Controllers.SalesManager(_MainView);
        }

        public static POSsible.Controllers.ISalesManager GetSalesManager(POSsible.Views.IRefundView _RefundView)
        {
            return new POSsible.Controllers.SalesManager(_RefundView);
        }

        #region Customer Invoice Model and Customer Invoice Manager Bridge
        /// <summary>
        /// Reference of ICustomer Invoice Model
        /// have the factory 
        /// </summary>
        private static ICustomerInvoiceModel _customerInvoiceModel;

        /// <summary>
        /// Get's an instatiated ICustomer Invoice Model object
        /// </summary>
        /// <returns></returns>
        public static ICustomerInvoiceModel GetCustomerInvoiceModel()
        {
            if (_customerInvoiceModel == null)
            {
                _customerInvoiceModel = new POSsible.Models.CustomerInvoiceModel();
            }
            return _customerInvoiceModel;
        }


        /// <summary>
        /// Get's an instantiated ICustomerInvoiceModel object
        /// </summary>
        /// <param name="SupplierView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static ICustomerInvoiceManager GetCustomerInvoiceManager(ICustomerInvoiceView _CustomerInvoiceView)
        {
            return new CustomerInvoiceManager(_CustomerInvoiceView);
        }

        #endregion

        #region UserModel and UserManager Bridge
        /// <summary>
        /// Reference of IUser Model
        /// have the factory 
        /// </summary>
        private static IUserModel _UserModel;

        /// <summary>
        /// Get's an instatiated IProductCategoryModel object
        /// </summary>
        /// <returns></returns>
        public static IUserModel GetUserModel()
        {
            if (_UserModel == null)
            {
                _UserModel = new POSsible.Models.UserModel();
            }
            return _UserModel;
        }

        /// <summary>
        /// Get's an instantiated IUser Model object
        /// </summary>
        /// <param name="UserView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static IUserManager GetUserManager(IUserView _userView)
        {
            return new UserManager(_userView);
        }

        #endregion

        #region Unit Measurement Model and Unit Measurement Manager Bridge
        /// <summary>
        /// Reference of IUnit Measurement Model
        /// have the factory 
        /// </summary>
        private static IUnitMeasurmentModel _unitMeasurmentModel;

        /// <summary>
        /// Get's an instatiated IProductCategoryModel object
        /// </summary>
        /// <returns></returns>
        public static IUnitMeasurmentModel GetUnitMeasurmentModel()
        {
            if (_unitMeasurmentModel == null)
            {
                _unitMeasurmentModel = new POSsible.Models.UnitMeasurmentModel();
            }
            return _unitMeasurmentModel;
        }

        /// <summary>
        /// Get's an instantiated IUnit Measurement Model object
        /// </summary>
        /// <param name="SupplierView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static IUnitMeasurmentManager GetUnitMeasurmentManager(IUnitMeasurmentView _UnitMeasurmentView)
        {
            return new UnitMeasurmentManger(_UnitMeasurmentView);
        }

        #endregion

        #region ProductCategoryModel and ProductCategoryManager Bridge
        /// <summary>
        /// Reference of IProductCategoryModel
        /// have the factory 
        /// </summary>
        private static IProductCategoryModel _productCategoryModel;

        /// <summary>
        /// Get's an instatiated IProductCategoryModel object
        /// </summary>
        /// <returns></returns>
        public static IProductCategoryModel GetProductCategoryModel()
        {
            if (_productCategoryModel == null)
            {
                _productCategoryModel = new POSsible.Models.ProductCategoryModel();
            }
            return _productCategoryModel;
        }

        /// <summary>
        /// Get's an instantiated IProductCategoryModel object
        /// </summary>
        /// <param name="SupplierView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static IProductCategoryManager GetProductCategoryManager1(IProductCategoryView _ProductCategoryView)
        {
            return new ProductCategoryManager(_ProductCategoryView);
        }

        #endregion

        #region SupplierModel and SupplierManager Bridge
        /// <summary>
        /// Reference of ISupplierModel
        /// have the factory 
        /// </summary>
        private static ISupplierModel _SupplierModel;

        /// <summary>
        /// Get's an instatiated ISupplierModel object
        /// </summary>
        /// <returns></returns>
        public static ISupplierModel GetSupplierModel()
        {

            if (_SupplierModel == null)
            {
                _SupplierModel = new POSsible.Models.SupplierModel();
            }
            return _SupplierModel;
        }

        /// <summary>
        /// Get's an instantiated ISupplierModel object
        /// </summary>
        /// <param name="SupplierView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static ISupplierManager GetSuppilerManager(ISupplierView _SupplierView)
        {
            return new SupplierManager(_SupplierView);
        }
        #endregion

        #region Company Model and Company Manager Bridge
        /// <summary>
        /// Reference of ICompanyModel
        /// have the factory 
        /// </summary>
        private static ICompanyModel _companyModel;

        /// <summary>
        /// Get's an instatiated ICompanyModel object
        /// </summary>
        /// <returns></returns>
        public static ICompanyModel GetCompanyModel()
        {
            if (_companyModel == null)
            {
                _companyModel = new POSsible.Models.CompanyModel();
            }
            return _companyModel;
        }


        /// <summary>
        /// Get's an instantiated ICompany Model object
        /// </summary>
        /// <param name="CompanyView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static ICompanyManager GetCompanyManager(ICompanyView _companyView)
        {
            return new CompanyManager(_companyView);
        }

        #endregion

        #region CustomerModel and CustomerManager Bridge
        /// <summary>
        /// Reference of ICustomerModel
        /// have the factory 
        /// </summary>
        private static ICustomerModel _CustomerModel;

        /// <summary>
        /// Get's an instatiated ICustomerModel object
        /// </summary>
        /// <returns></returns>
        public static ICustomerModel GetCusomerModel()
        {

            if (_CustomerModel == null)
            {
                _CustomerModel = new POSsible.Models.CustomerModel();
            }
            return _CustomerModel;
        }

        /// <summary>
        /// Get's an instantiated ICustomerModel object
        /// </summary>
        /// <param name="SupplierView">reference to view using controller for callbacks</param>
        /// <returns></returns>
        public static ICustomerManager GetCustomerManager(ICustomerView _CustomerView)
        {
            return new CustomerManager(_CustomerView);
        }
        #endregion

    }
    #endregion

}
