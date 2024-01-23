using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmRoleWisePermission : Form
    {
        private bool FirstLoadDone = false;

        public frmRoleWisePermission()
        {
            InitializeComponent();
        }

        private void frmRoleWisePermission_Load(object sender, EventArgs e)
        {
            LoadData();
            BindRoles();
            FirstLoadDone = true;
        }

        private void LoadData()
        {
            List<PageList> lst = new PageListDAO().PageList_GetAll();
            dgvPageList.Rows.Clear();
            //lst = lst.Where(x => x.IsPage == true).ToList();
            foreach (PageList page in lst)
            {
                dgvPageList.Rows.Add();
                int RowIndex = dgvPageList.RowCount - 1;
                DataGridViewRow R = dgvPageList.Rows[RowIndex];
                R.Cells["cPageId"].Value = page.PageId.ToString();
                R.Cells["cPageName"].Value = page.PageName;
            }
            //dataGridViewPage.AutoResizeColumns();
            //dataGridViewPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void BindRoles()
        {
            List<Roles> lstRoles = new RolesDAO().Roles_GetAll();
            if (lstRoles != null && lstRoles.Count > 0)
                lstRoles = lstRoles.OrderBy(p => p.RoleId).ToList();
            cmbRole.DataSource = lstRoles;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleId";
            cmbRole.SelectedIndex = -1;
        }

        private void dgvPageList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPageList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void cmbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex > -1 && FirstLoadDone)
            {
                List<RoleWisePermission> lst = new RoleWisePermissionDAO().RoleWisePermission_GetByRoleId(Convert.ToInt32(cmbRole.SelectedValue));
                foreach (DataGridViewRow row in dgvPageList.Rows)
                {
                    int pageId = Convert.ToInt32(row.Cells["cPageId"].Value);
                    if (lst.Count > 0)
                    {
                        RoleWisePermission rwp = lst.Where(p => p.PageId == pageId).FirstOrDefault();

                        if (rwp != null)
                        {
                            row.Cells[0].Value = rwp.PermissionId;
                            row.Cells[1].Value = rwp.PageId;
                            row.Cells[3].Value = rwp.CanSelect;

                        }
                        else
                        {
                            row.Cells[0].Value = 0;
                            row.Cells[1].Value = pageId;
                            row.Cells[3].Value = false;

                        }
                    }
                    else
                    {
                        row.Cells[0].Value = 0;
                        row.Cells[1].Value = pageId;
                        row.Cells[3].Value = false;

                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex > -1)
            {
                foreach (DataGridViewRow row in dgvPageList.Rows)
                {
                    RoleWisePermission rwp = new RoleWisePermission();
                    rwp.PermissionId = Convert.ToInt32(row.Cells[0].Value);
                    rwp.RoleId = Convert.ToInt32(cmbRole.SelectedValue);
                    rwp.PageId = Convert.ToInt32(row.Cells[1].Value);
                    rwp.CanSelect = Convert.ToBoolean(row.Cells[3].Value);
                    rwp.AssignedBy = MDIParent.userId;
                    rwp.CompanyId = 1;

                    if (rwp.PermissionId == 0)
                        new RoleWisePermissionDAO().Add(rwp);
                    else
                        new RoleWisePermissionDAO().Update(rwp);
                }
                ClearControls();
                MessageBox.Show("Saved Successfully.", "POSsible");
            }
            else
            {
                if (cmbRole.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select Role.");
                    return;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (btnSave.Enabled) btnSave_Click(null, null);
                return true;
            }

            else if (keyData == (Keys.Control | Keys.L))
            {
                ClearControls();
                return true;
            }

            else if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ClearControls()
        {
            cmbRole.SelectedIndex = -1;
            foreach (DataGridViewRow row in dgvPageList.Rows)
            {
                row.Cells[0].Value = 0;
                row.Cells[3].Value = false;
            }
        }

        private void frmRoleWisePermission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
