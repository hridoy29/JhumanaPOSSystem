using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using POSsible.BusinessObjects;
using POSsible.DAL;

namespace POSsible
{
    public partial class frmEmployee : Form
    {
        #region VARIABLES
        EmployeeDAO oEmployeeDAO = new EmployeeDAO();
        private String SaveMode = "";
        private bool FLD = false;
        public static bool FromCustomerEntry = false;
        public static int EmployeeID = 0;
        #endregion

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            SaveMode = "NEW";
            btnSave.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            btnDelete.Enabled = false;
            txtEmployeeName.Focus();
            LoadData();
            FLD = true;

            if (FromCustomerEntry)
            {
                chkActive.Enabled = btnSave.Enabled = btnClose.Enabled = true;
                btnDelete.Enabled = btnClear.Enabled = dgv.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text.Trim()))
            {
                MessageBox.Show("Please type EmployeeName", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmployeeName.Focus();
                return;
            }

            Employee tp = new Employee(0, txtEmployeeName.Text.Trim(), (FromCustomerEntry ? true : chkActive.Checked));
            int id = 0;

            if (SaveMode == "NEW")
            {
                id = oEmployeeDAO.Add(tp);
                if (id > 0)
                {
                    MessageBox.Show("Employee Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (FromCustomerEntry)
                    {
                        EmployeeID = id;
                        FromCustomerEntry = false;
                        this.Close();
                    }
                }
            }
            else
            {
                tp.EmployeeId = Convert.ToInt32(dgv.SelectedRows[0].Cells["EmployeeId"].Value);
                id = oEmployeeDAO.Update(tp);
                if (id > 0)
                    MessageBox.Show("Employee Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgv.DataSource = new DataTable();
            LoadData();
            btnClear.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure to delete this Employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                int trnPurposeId = Convert.ToInt32(dgv.SelectedRows[0].Cells["EmployeeId"].Value);
                try
                {
                    int del = oEmployeeDAO.Delete(trnPurposeId);
                    if (del > 0)
                    {
                        MessageBox.Show("Employee Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveMode = "NEW";
                        dgv.DataSource = new DataTable();
                        LoadData();
                        btnClear.PerformClick();
                    }
                    else
                        MessageBox.Show("This Employee is already in use.\nCan't Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("This Employee is already in use.\nCan't Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SaveMode = "NEW";
            EmployeeID = 0;
            txtEmployeeName.Clear();
            chkActive.Checked = true;
            btnSave.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            btnDelete.Enabled = false;
            txtEmployeeName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!FromCustomerEntry && dgv.SelectedRows.Count > 0 && FLD)
            {
                string trPurName = dgv.SelectedRows[0].Cells["EmployeeName"].Value.ToString().ToLower();

                if (dgv.SelectedRows[0].Cells["EmployeeName"].Value != null)
                    txtEmployeeName.Text = dgv.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                else
                    txtEmployeeName.Text = String.Empty;
                if (dgv.SelectedRows[0].Cells["IsActive"].Value != null)
                    chkActive.Checked = Convert.ToBoolean(dgv.SelectedRows[0].Cells["IsActive"].Value);
                else
                    chkActive.Checked = false;
                SaveMode = "EDIT";
                btnSave.Enabled = btnDelete.Enabled = btnClear.Enabled = btnClose.Enabled = true;
            }
        }

        private void txtEmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                btnSave.Focus();
                return;
            }

            //if (e.KeyChar == '.')
            //{
            //    e.Handled = true;
            //    return;
            //}

            //if (e.KeyChar.Equals((char)Keys.Back) || e.KeyChar.Equals((char)Keys.Tab) || e.KeyChar.Equals((char)Keys.Delete))
            //{
            //    e.Handled = false;
            //    return;
            //}

            //if (!Char.IsLetterOrDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //    return;
            //}
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (btnSave.Enabled) btnSave.PerformClick();
                return true;
            }

            else if (keyData == (Keys.Control | Keys.D))
            {
                if (btnDelete.Enabled) btnDelete.PerformClick();
                return true;
            }

            else if (keyData == (Keys.Control | Keys.C))
            {
                if (btnClear.Enabled) btnClear.PerformClick();
                return true;
            }

            else if (keyData == (Keys.Control | Keys.O))
            {
                if (btnClose.Enabled) btnClose.PerformClick();
                return true;
            }

            else if (keyData == Keys.Escape)
            {
                FromCustomerEntry = false;
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv.ClearSelection();
        }

        private void LoadData()
        {
            List<Employee> lst = oEmployeeDAO.Employee_GetAll();
            if (lst.Count > 0)
            {
                dgv.DataSource = lst;
                dgv.Columns["EmployeeId"].Visible = dgv.Columns["IsActive"].Visible = false;
                dgv.Columns["EmployeeName"].HeaderText = "Employee Name";
                dgv.Columns["IsActiveString"].HeaderText = "Active?";
                dgv.Columns["SL"].HeaderText = "S/N";
                dgv.Columns["IsActiveString"].Width = 58;
                dgv.Columns["SL"].Width = 40;
                dgv.Columns["IsActiveString"].DefaultCellStyle.Alignment = dgv.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["EmployeeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["SL"].DisplayIndex = 0;
                int loop = 1;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells["SL"].Value = loop; loop += 1;
                }
            }
        }

        private void txtEmployeeName_Leave(object sender, EventArgs e)
        {
            string where = "[EmployeeName]='" + txtEmployeeName.Text.Trim() + "'";
            if (SaveMode != "NEW")
                where += " AND [EmployeeId]<>" + dgv.SelectedRows[0].Cells["EmployeeId"].Value;

            List<Employee> lst = oEmployeeDAO.Employee_GetDynamic(where, string.Empty);
            if (lst.Count > 0)
            {
                MessageBox.Show(txtEmployeeName.Text + " already entered", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEmployeeName.Focus();
            }
        }
    }
}
