using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.Properties;


namespace POSsible
{
    public partial class frmNonScanItemInfo : Form, POSsible.Views.IProductCategoryView
    {
        private POSsible.Controllers.IProductManager _ProductManager;
        private frmMain oFrmMainGlobal;
        private CProduct nonscanproduct;
        

        public frmNonScanItemInfo()
        {
            InitializeComponent();
            _ProductManager = POSsible.Factories.Factory.GetProductManager(this);
        }

        public frmNonScanItemInfo(frmMain oFrmMain, CProduct nonscanproduct1)
        {
            InitializeComponent();
            _ProductManager = POSsible.Factories.Factory.GetProductManager(this);
            oFrmMainGlobal = new frmMain();
            oFrmMainGlobal = oFrmMain;
            nonscanproduct = new CProduct();
            nonscanproduct = nonscanproduct1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNonScanItemInfo_Load(object sender, EventArgs e)
        {
            try
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNonScanItemInfo));
                List<CDepartment> oProductCategoryList =_ProductManager.getProductCategoryList(1);
                Panel pnl = new Panel();
                
                pnl.Width = 405;
                pnl.Location = new Point(0, 0);
                this.Controls.Add(pnl);
                this.Width = 410;


                int j=0,x = 12, y=13,iHeight=13;

                Button[] btnArr = new Button[oProductCategoryList.Count];

                foreach (CDepartment oProductCategory in oProductCategoryList)
                {
                    if (j > 1)
                    {
                        if (j % 3 == 0)
                        {
                            x = 12;
                            y = y + 70;
                            iHeight = iHeight + 70;
                        }
                        else //if (j % 2 == 1)
                        {
                            x = x + 128;
                        }
                    }
                    else if (j == 1)
                    {
                        x = x + 128;
                        iHeight = iHeight + 70;
                    }

                    btnArr[j] = new Button();
                    btnArr[j].Text = oProductCategory.DepartmentName;
                    btnArr[j].Location = new Point(x, y);
                    btnArr[j].Width = 125;
                    btnArr[j].Height = 64;
                    btnArr[j].Font = new Font("Microsoft Sans Serif",float.Parse("11"),FontStyle.Bold);
                    btnArr[j].BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btntest.BackgroundImage")));
                    pnl.Controls.Add(btnArr[j]);
                    pnl.Height = iHeight + 5;

                    if (oProductCategoryList.Count == j + 1)
                    {
                        this.Height = iHeight + 80;
                    }
                    else
                        this.Height = iHeight + 120;

                    this.Location = new Point(350, 150);
                    btnArr[j].Name = Convert.ToString(oProductCategory.CategoryId);
                    
                    btnArr[j].Click += new EventHandler(btnArr_Click);

                    j=j+1;
                }

                if (oProductCategoryList.Count > 0)
                {
                    btnArr[0].Focus();
                }
               
                btnCancel.Location = new Point(268,iHeight+5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method is used  to show the alert for any insertion/deletion or update
        /// </summary>
        /// <param name="sMsg"></param>
        public void Alert(string sMessage)
        {
            MessageBox.Show(sMessage, "RITPOS");
        }

        private void btnArr_Click(object sender, EventArgs e)
        {
            nonscanproduct.DepartmentId = Convert.ToInt32(((Control)sender).Name);
            nonscanproduct.ProductName = ((Control)sender).Text;            
            this.Close();
        }
    }
}