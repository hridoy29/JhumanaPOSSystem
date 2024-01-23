using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using POSsible.BusinessObjects;
using POSsible.DAL;
using System.Configuration;


namespace POSsible
{
    public partial class frmDBBackup : Form
    {
        int Count = 0;
        string FileName = string.Empty;
        string Database = Helper.GetDataBaseName();
        string foldername = string.Empty;

        public frmDBBackup()
        {
            InitializeComponent();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                //ClearControls();
                foldername = this.folderBrowserDialog1.SelectedPath;
                if (!string.IsNullOrEmpty(txtFileName.Text.Trim()))
                {
                    this.lblDirectory.Text = foldername + "\\" + txtFileName.Text.Trim();
                }
                else
                    this.lblDirectory.Text = foldername;

                txtFileName.Focus();
            }
        }

        private void ClearControls()
        {
            txtFileName.Clear();
            lblDirectory.Text = string.Empty;
            btnOpenFolder.Enabled = btnSave.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (chkAutoName.Checked)
            {
                FileName = AutoDBBackupName(Database);
                SaveToDirectory(FileName, Database);
            }
            else
            {
                if (string.IsNullOrEmpty(txtFileName.Text.Trim()))
                {
                    MessageBox.Show("Please give a file name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFileName.Focus();
                    return;
                }
                else
                {
                    FileName = txtFileName.Text.Trim();
                    if (FileName.Contains(".bak"))
                    {
                        SaveToDirectory(FileName, Database);
                    }
                    else
                    {
                        FileName = FileName + ".bak";
                        SaveToDirectory(FileName, Database);
                    }
                }
            }
        }

        public string AutoDBBackupName(string Database)
        {
            string Year = Convert.ToString(DateTime.Now.Year);
            string Month = Convert.ToString(DateTime.Now.Month);
            Count = Month.Length; //CountCharacter(Month);
            if (Count <= 1)
                Month = "0" + Month;

            string Date = Convert.ToString(DateTime.Now.Day);
            Count = Date.Length; // CountCharacter(Date);
            if (Count <= 1)
                Date = "0" + Date;

            string Hour = Convert.ToString(DateTime.Now.Hour);
            Count = Hour.Length; // CountCharacter(Hour);
            if (Count <= 1)
                Hour = "0" + Hour;

            string Minute = Convert.ToString(DateTime.Now.Minute);
            Count = Minute.Length; // CountCharacter(Minute);
            if (Count <= 1)
                Minute = "0" + Minute;

            string Second = Convert.ToString(DateTime.Now.Second);
            Count = Second.Length; // CountCharacter(Second);
            if (Count <= 1)
                Second = "0" + Second;

            FileName = Database + "_" + Year + Month + Date + Hour + Minute + Second + ".bak";
            return FileName;
        }

        private void SaveToDirectory(string Filename, string Database)
        {
            string Directory = lblDirectory.Text;
            if (!Directory.EndsWith(".bak"))
            {
                Directory = Directory + ".bak";
            }
            if (string.IsNullOrEmpty(foldername))
            {
                MessageBox.Show("Please select a folder to backup database", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpenFolder.Focus();
                return;
            }
            if (File.Exists(Directory))
            {
                MessageBox.Show("This file name already exist. Please give another name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFileName.Focus();
                return;
            }

            string Query = "Backup Database " + Database + " To Disk = '" + Directory + "' ";
            int id = new TransactionDAO().ExecuteQuery(Query);
            //if (id > 0)
            //{
            ClearControls();
            MessageBox.Show("Database backup successfully done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        public int CountCharacter(string Char)
        {
            int Count = Char.Length;
            return Count;
        }

        private void chkAutoName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoName.Checked)
            {
                txtFileName.Clear();
                txtFileName.Enabled = false;
                btnSave.Focus();
                FileName = AutoDBBackupName(Database);
                txtFileName.Text = FileName;
                if (!string.IsNullOrEmpty(foldername))
                {
                    lblDirectory.Text = foldername + "\\" + txtFileName.Text;
                }
            }
            else
            {
                //txtFileName.Clear();
                txtFileName.Enabled = true;
                txtFileName.Focus();
            }
        }

        private void frmDBBackup_Load(object sender, EventArgs e)
        {
            chkAutoName.Checked = true;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(foldername))
            {
                lblDirectory.Text = foldername + "\\" + txtFileName.Text.Trim();
            }
            else
                lblDirectory.Text = txtFileName.Text.Trim();
        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave.Focus();
            }
        }
    }
}
