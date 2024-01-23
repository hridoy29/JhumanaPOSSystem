using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.DAL;
using POSsible.BusinessObjects;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;


namespace POSsible.Reports
{
    public partial class frmRptPurchase : Form
    {
        public frmRptPurchase()
        {
            InitializeComponent();
            cmbSupplierBind();
            cmbStoreBind();
        }

        private void cmbStoreBind()
        {
            DataTable dt = new DataTable();
            DbDataReader oDbDataReader = null;
            try
            {
                //CreditCollection oCreditCollection = new CreditCollection();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECT StoreName, StoreId FROM [tblStore]", CommandType.Text);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);

                dt.Load(oDbDataReader);
                cmbStore.DataSource = dt;
                cmbStore.DisplayMember = "StoreName";
                cmbStore.ValueMember = "StoreId";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }

        }

        private void cmbSupplierBind()
        {
            List<Supplier> lstSupp = new SupplierDAO().Supplier_GetAll();
            if (lstSupp.Count > 0)
            {
                cmbSupplier.DataSource = lstSupp;
                cmbSupplier.SelectedIndex = -1;
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierId";
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //int supId = (cmbSupplier.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbSupplier.SelectedValue);
                //int stoId = (cmbStore.SelectedIndex < 0) ? 0 : Convert.ToInt32(cmbStore.SelectedValue);
                //frmReportViewer rv = new frmReportViewer(this, 2, supId, stoId, dtpFrom.Value.Date, dtpTo.Value.Date);
                //rv.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
