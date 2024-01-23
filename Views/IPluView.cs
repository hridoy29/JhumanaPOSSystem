using System;
using System.Collections.Generic;
using System.Text;
using POSsible.BusinessObjects;

namespace POSsible.Views
{
    public interface IPluView
    {
        /// <summary>
        /// Used to Display the product List
        /// </summary>
        /// <param name="oProductList"></param>
        void displayProductList(CProduct oProductList);

        /// <summary>
        /// Used to display the DepartmentList in to the Combo
        /// </summary>
        /// <returns></returns>
        void putDepartmentList(List<CDepartment> oListproducts);

        void updateItemGrid(List<CProduct> oProduct);

        void Alert(string message);
    }
}
