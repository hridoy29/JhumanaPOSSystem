namespace POSsible
{
    partial class frmRoleWisePermission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPageList = new System.Windows.Forms.DataGridView();
            this.PermissionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permission = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPageList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(514, 562);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Firebrick;
            this.label8.Location = new System.Drawing.Point(106, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(302, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Role Wise Permission Form";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSave);
            this.splitContainer2.Panel1.Controls.Add(this.cmbRole);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvPageList);
            this.splitContainer2.Size = new System.Drawing.Size(514, 522);
            this.splitContainer2.SplitterDistance = 54;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(386, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 35);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(72, 10);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(271, 32);
            this.cmbRole.TabIndex = 25;
            this.cmbRole.SelectedValueChanged += new System.EventHandler(this.cmbRole_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Role:";
            // 
            // dgvPageList
            // 
            this.dgvPageList.AllowUserToAddRows = false;
            this.dgvPageList.AllowUserToDeleteRows = false;
            this.dgvPageList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPageList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PermissionId,
            this.cPageId,
            this.cPageName,
            this.Permission});
            this.dgvPageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPageList.Location = new System.Drawing.Point(0, 0);
            this.dgvPageList.Name = "dgvPageList";
            this.dgvPageList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPageList.Size = new System.Drawing.Size(514, 464);
            this.dgvPageList.TabIndex = 1;
            this.dgvPageList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPageList_CellContentClick);
            // 
            // PermissionId
            // 
            this.PermissionId.HeaderText = "PermissionId";
            this.PermissionId.Name = "PermissionId";
            this.PermissionId.Visible = false;
            // 
            // cPageId
            // 
            this.cPageId.HeaderText = "PageId";
            this.cPageId.Name = "cPageId";
            this.cPageId.Visible = false;
            // 
            // cPageName
            // 
            this.cPageName.HeaderText = "Page Name";
            this.cPageName.Name = "cPageName";
            this.cPageName.ReadOnly = true;
            this.cPageName.Width = 340;
            // 
            // Permission
            // 
            this.Permission.HeaderText = "Permission";
            this.Permission.Name = "Permission";
            this.Permission.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmRoleWisePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 562);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "frmRoleWisePermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role Wise Permission";
            this.Load += new System.EventHandler(this.frmRoleWisePermission_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRoleWisePermission_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPageList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPageList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn PermissionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPageName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Permission;
    }
}