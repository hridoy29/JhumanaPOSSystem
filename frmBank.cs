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
using System.Text.RegularExpressions;

namespace POSsible
{
    public partial class frmBank : Form
    {
        #region Variables

        private List<Button> lstBtns = new List<Button>();
        private bool hasSetColumns = false;
        private String SaveMode = "";
        private bool ValueExists = false;
        private bool FLD = false;
        BankDAO oBankDAO = new BankDAO();
        public static bool FromBankBranchForm = false;
        public static int BankId = 0;
        public static string BankName = "";
        public static int AccountLgId = 0;

        #endregion

        #region Events

        public frmBank()
        {
            InitializeComponent();
        }

        private void frmBank_Load(object sender, EventArgs e)
        {
            lstBtns = Helper.ListBtns(btnNew, btnSave, btnClear, btnClose, new Button());
            LoadData();
            EnableDisable(false);
            Helper.ButtonStates(lstBtns, true, false, false, false, true);
            FLD = true;
            btnNew.Focus();
            if (FromBankBranchForm)
            {
                btnNew_Click(null, null);
                Helper.ButtonStates(lstBtns, false, true, false, false, true);
            }
        }

        #region Button Click

        private void btnNew_Click(object sender, EventArgs e)
        {
            SaveMode = "NEW";
            EnableDisable(true);
            ClearControl();
            txtBank.Focus();
            Helper.ButtonStates(lstBtns, false, true, false, true, true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Helper.ValidateNotEmpty(new List<Control>() { txtBank }))
            {
                CheckBankExist();
                if (ValueExists)
                {
                    ValueExists = false; return;
                }

                Bank bank = new Bank();
                bank.BankName = txtBank.Text.Trim();
                bank.StoreId = MDIParent.storeId;
                bank.ProjectId = MDIParent.projectId;
                bank.AccountLgId = AccountLgId;

                #region
                AccountLedger ALC = new AccountLedger();
                ALC.AccountLedgerName = bank.BankName;
                ALC.AccountLedgerNo = GetAcLedgerNo(22); //ledger Group Id
                ALC.LedgerGroupId = 22;
                ALC.AccTransTypeId = 3;
                ALC.BudgetEnable = true;
                ALC.CF1 = MDIParent.projectId.ToString();
                ALC.CF2 = "N";
                ALC.OpeningBalanceOn = DateTime.Now;
                #endregion
                int Id = 0;

                if (SaveMode == "NEW")
                {
                    bank.AccountLgId = new AccountLedgerDAO().Add(ALC);
                    Id = oBankDAO.Add(bank);
                    if (Id > 0)
                        MessageBox.Show("Bank Saved", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bank.BankId = Convert.ToInt32(GridView.SelectedRows[0].Cells["BankId"].Value);
                    Id = oBankDAO.Update(bank);
                    if (Id > 0)
                        MessageBox.Show("Bank Updated", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (Id > 0)
                {
                    if (FromBankBranchForm)
                    {
                        BankId = Id;
                        FromBankBranchForm = false;
                        this.Close();
                    }
                    GridView.Rows.Clear();
                    LoadData();
                    ClearControl();
                    EnableDisable(false);
                    Helper.ButtonStates(lstBtns, true, false, false, false, true);
                    btnNew.Focus();
                }
            }
        }

        private Int64 GetAcLedgerNo(int val)
        {
            string where = "";
            where = " AL.LedgerGroupId = '" + val + "' ";
            string sort = string.Empty;

            List<AccountLedger> lst = new AccountLedgerDAO().AccountLedger_GetDynamic(where, sort);
            Int64 accCode = 0;
            if (lst.Count > 0)
            {
                lst = lst.OrderByDescending(x => x.AccountLedgerNo).ToList();
                AccountLedger alEntity = lst.FirstOrDefault();
                accCode = alEntity.AccountLedgerNo + 1000;
            }
            else
            {
                LedgerGroup lgEntity = new LedgerGroupDAO().LedgerGroup_GetById(val);
                accCode = lgEntity.LedgerGroupNo + 101000;
            }
            return accCode;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            GridView.Rows.Clear();
            LoadData();
            EnableDisable(false);
            ClearControl();
            Helper.ButtonStates(lstBtns, true, false, false, false, true);
            btnNew.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        private void txtBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 150 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13 && btnSave.Enabled)
            {
                btnSave.Focus();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.N))
            {
                if (btnNew.Enabled) btnNew_Click(null, null);
                return true;
            }

            else if (keyData == (Keys.Control | Keys.S))
            {
                if (btnSave.Enabled) btnSave_Click(null, null);
                return true;
            }



            else if (keyData == (Keys.Alt | Keys.C))
            {
                if (btnClear.Enabled) btnClear_Click(null, null);
                return true;
            }

            else if (keyData == (Keys.Alt | Keys.O))
            {
                if (btnClose.Enabled) btnClose_Click(null, null);
                return true;
            }

            else if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Methods
        private void EnableDisable(bool value)
        {
            txtBank.Enabled = value;
        }

        private void ClearControl()
        {
            txtBank.Text = string.Empty;
        }

        private void CheckBankExist()
        {
            if (SaveMode == "NEW")
            {
                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    if (GridView.Rows[i].Cells["BankName"].Value != null && txtBank.Text.Trim().ToLower() == GridView.Rows[i].Cells["BankName"].Value.ToString().Trim().ToLower())
                    {
                        MessageBox.Show("Bank name already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBank.Focus();
                        ValueExists = true;
                        return;
                    }
                }
            }

            else
            {
                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    if (!GridView.Rows[i].Selected && GridView.Rows[i].Cells["BankName"].Value != null && txtBank.Text.Trim().ToLower() == GridView.Rows[i].Cells["BankName"].Value.ToString().Trim().ToLower())
                    {
                        MessageBox.Show("Bank name already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBank.Focus();
                        ValueExists = true;
                        return;
                    }
                }
            }
        }

        private void LoadData()
        {
            if (!hasSetColumns)
                this.SetColumns();

            this.SetColumnValues();
        }

        private void SetColumns()
        {

            GridView.Columns.Add("BankId", "BankId");
            GridView.Columns["BankId"].Visible = false;
            GridView.Columns.Add("BankName", "BankName");
            GridView.Columns["BankName"].Visible = true;
            GridView.Columns.Add("AccountLgId", "AccountLgId");
            GridView.Columns["AccountLgId"].Visible = false;
            GridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            GridView.RowHeadersWidth = 50;
            hasSetColumns = true;
        }

        private void SetColumnValues()
        {
            List<Bank> lst = oBankDAO.Bank_GetDynamic("[StoreId] = " + MDIParent.storeId, "BankName");

            if (lst != null)
            {
                foreach (Bank item in lst)
                {
                    GridView.Rows.Add(item.BankId.ToString(), item.BankName.ToString(), item.AccountLgId.ToString());
                }
                setRowNumber(GridView);
            }
        }

        private void setRowNumber(DataGridView GridView)
        {
            foreach (DataGridViewRow row in GridView.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
        #endregion

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RI = e.RowIndex;
            int CI = e.ColumnIndex;

            BankId = Convert.ToInt32(GridView.Rows[RI].Cells[0].Value);
            BankName = GridView.Rows[RI].Cells[1].Value.ToString();
            AccountLgId = Convert.ToInt32(GridView.Rows[RI].Cells[2].Value.ToString());
            SaveMode = "EDIT";
            EnableDisable(true);
            txtBank.Text = BankName;
            Helper.ButtonStates(lstBtns, false, true, true, true, true);

        }
    }
}
