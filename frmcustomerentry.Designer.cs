namespace POSsible
{
    partial class frmcustomerentry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvcustomer = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccellno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CivilId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtcountry = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.optmale = new System.Windows.Forms.RadioButton();
            this.optfemale = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.btnCustomerInvoice = new System.Windows.Forms.Button();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.lblCrLimit = new System.Windows.Forms.Label();
            this.cmbDefaulerType = new System.Windows.Forms.ComboBox();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.cmbReference = new System.Windows.Forms.ComboBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.cmbSearchFilter = new System.Windows.Forms.ComboBox();
            this.cmbDSaleType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkNewAC = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboAccountLedger = new System.Windows.Forms.ComboBox();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLicenceNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblFaxNo = new System.Windows.Forms.Label();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvcustomer
            // 
            this.dgvcustomer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvcustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvcustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvcustomer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvcustomer.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cname,
            this.ccellno,
            this.CivilId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcustomer.Location = new System.Drawing.Point(452, 48);
            this.dgvcustomer.Margin = new System.Windows.Forms.Padding(4);
            this.dgvcustomer.MultiSelect = false;
            this.dgvcustomer.Name = "dgvcustomer";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvcustomer.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvcustomer.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcustomer.Size = new System.Drawing.Size(587, 538);
            this.dgvcustomer.TabIndex = 19;
            this.dgvcustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcustomer_CellClick);
            // 
            // cId
            // 
            this.cId.HeaderText = "";
            this.cId.Name = "cId";
            this.cId.Visible = false;
            this.cId.Width = 5;
            // 
            // cname
            // 
            this.cname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cname.HeaderText = "Name";
            this.cname.MinimumWidth = 155;
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // ccellno
            // 
            this.ccellno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ccellno.HeaderText = "Mobile No.";
            this.ccellno.MinimumWidth = 130;
            this.ccellno.Name = "ccellno";
            this.ccellno.ReadOnly = true;
            this.ccellno.Width = 130;
            // 
            // CivilId
            // 
            this.CivilId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CivilId.HeaderText = "CivilId";
            this.CivilId.MinimumWidth = 130;
            this.CivilId.Name = "CivilId";
            this.CivilId.ReadOnly = true;
            this.CivilId.Visible = false;
            this.CivilId.Width = 130;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Navy;
            this.btnReset.Location = new System.Drawing.Point(597, 593);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(147, 41);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.Location = new System.Drawing.Point(608, 11);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchName.MaxLength = 100;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(431, 24);
            this.txtSearchName.TabIndex = 17;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Navy;
            this.btnExit.Location = new System.Drawing.Point(893, 593);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(147, 41);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnAdd.Location = new System.Drawing.Point(449, 593);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(147, 41);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.BackgroundImage = global::POSsible.Properties.Resources.delete_110w_x_33h;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Navy;
            this.btnDelete.Location = new System.Drawing.Point(745, 593);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(147, 41);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(5, 380);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 106;
            this.label6.Text = "Customer Type";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(173, 10);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.MaxLength = 80;
            this.txtCustomerName.Multiline = true;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(259, 29);
            this.txtCustomerName.TabIndex = 1;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 101;
            this.label1.Text = "Name";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Enabled = false;
            this.txtCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(636, 484);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerID.MaxLength = 6;
            this.txtCustomerID.Multiline = true;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(31, 30);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.Visible = false;
            // 
            // txtcountry
            // 
            this.txtcountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcountry.Location = new System.Drawing.Point(173, 453);
            this.txtcountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtcountry.MaxLength = 100;
            this.txtcountry.Name = "txtcountry";
            this.txtcountry.Size = new System.Drawing.Size(259, 24);
            this.txtcountry.TabIndex = 6;
            this.txtcountry.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 458);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 109;
            this.label8.Text = "Country";
            this.label8.Visible = false;
            // 
            // optmale
            // 
            this.optmale.Checked = true;
            this.optmale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optmale.ForeColor = System.Drawing.Color.Black;
            this.optmale.Location = new System.Drawing.Point(173, 566);
            this.optmale.Margin = new System.Windows.Forms.Padding(4);
            this.optmale.Name = "optmale";
            this.optmale.Size = new System.Drawing.Size(131, 30);
            this.optmale.TabIndex = 10;
            this.optmale.TabStop = true;
            this.optmale.Text = "Male";
            this.optmale.Visible = false;
            // 
            // optfemale
            // 
            this.optfemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optfemale.ForeColor = System.Drawing.Color.Black;
            this.optfemale.Location = new System.Drawing.Point(327, 566);
            this.optfemale.Margin = new System.Windows.Forms.Padding(4);
            this.optfemale.Name = "optfemale";
            this.optfemale.Size = new System.Drawing.Size(113, 30);
            this.optfemale.TabIndex = 11;
            this.optfemale.Text = "Female";
            this.optfemale.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(9, 567);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 18);
            this.label12.TabIndex = 118;
            this.label12.Text = "Gender";
            this.label12.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(173, 302);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.MaxLength = 12;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(259, 24);
            this.txtCode.TabIndex = 1;
            this.txtCode.TabStop = false;
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarCode.ForeColor = System.Drawing.Color.Black;
            this.lblBarCode.Location = new System.Drawing.Point(8, 305);
            this.lblBarCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(93, 18);
            this.lblBarCode.TabIndex = 120;
            this.lblBarCode.Text = "Cust. Code";
            // 
            // btnCustomerInvoice
            // 
            this.btnCustomerInvoice.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCustomerInvoice.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnCustomerInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerInvoice.ForeColor = System.Drawing.Color.Black;
            this.btnCustomerInvoice.Location = new System.Drawing.Point(481, 479);
            this.btnCustomerInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomerInvoice.Name = "btnCustomerInvoice";
            this.btnCustomerInvoice.Size = new System.Drawing.Size(147, 41);
            this.btnCustomerInvoice.TabIndex = 123;
            this.btnCustomerInvoice.Text = "EDIT POINT";
            this.btnCustomerInvoice.UseVisualStyleBackColor = false;
            this.btnCustomerInvoice.Visible = false;
            this.btnCustomerInvoice.Click += new System.EventHandler(this.btnCustomerInvoice_Click);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] {
            "General",
            "Special"});
            this.cmbCustomerType.Location = new System.Drawing.Point(172, 375);
            this.cmbCustomerType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(260, 26);
            this.cmbCustomerType.TabIndex = 3;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 125;
            this.label2.Text = "Address Line 1";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressLine1.Location = new System.Drawing.Point(173, 192);
            this.txtAddressLine1.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddressLine1.MaxLength = 100;
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(259, 24);
            this.txtAddressLine1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 495);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 130;
            this.label3.Text = "Defaulter Type";
            this.label3.Visible = false;
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditLimit.Location = new System.Drawing.Point(172, 529);
            this.txtCreditLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txtCreditLimit.MaxLength = 100;
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(259, 24);
            this.txtCreditLimit.TabIndex = 7;
            this.txtCreditLimit.Visible = false;
            this.txtCreditLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditLimit_KeyPress);
            // 
            // lblCrLimit
            // 
            this.lblCrLimit.AutoSize = true;
            this.lblCrLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrLimit.ForeColor = System.Drawing.Color.Black;
            this.lblCrLimit.Location = new System.Drawing.Point(8, 534);
            this.lblCrLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCrLimit.Name = "lblCrLimit";
            this.lblCrLimit.Size = new System.Drawing.Size(94, 18);
            this.lblCrLimit.TabIndex = 129;
            this.lblCrLimit.Text = "Credit Limit";
            this.lblCrLimit.Visible = false;
            // 
            // cmbDefaulerType
            // 
            this.cmbDefaulerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDefaulerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDefaulerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDefaulerType.FormattingEnabled = true;
            this.cmbDefaulerType.Items.AddRange(new object[] {
            "Days",
            "Bill to bill"});
            this.cmbDefaulerType.Location = new System.Drawing.Point(173, 490);
            this.cmbDefaulerType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDefaulerType.Name = "cmbDefaulerType";
            this.cmbDefaulerType.Size = new System.Drawing.Size(195, 26);
            this.cmbDefaulerType.TabIndex = 8;
            this.cmbDefaulerType.Visible = false;
            this.cmbDefaulerType.SelectedIndexChanged += new System.EventHandler(this.cmbDefaulerType_SelectedIndexChanged);
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(377, 490);
            this.txtDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtDays.MaxLength = 6;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(53, 24);
            this.txtDays.TabIndex = 9;
            this.txtDays.Visible = false;
            this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
            // 
            // cmbReference
            // 
            this.cmbReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReference.FormattingEnabled = true;
            this.cmbReference.Location = new System.Drawing.Point(115, 599);
            this.cmbReference.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReference.Name = "cmbReference";
            this.cmbReference.Size = new System.Drawing.Size(239, 26);
            this.cmbReference.TabIndex = 134;
            this.cmbReference.TabStop = false;
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRef.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblRef.Location = new System.Drawing.Point(8, 604);
            this.lblRef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(82, 18);
            this.lblRef.TabIndex = 133;
            this.lblRef.Text = "Salesman";
            // 
            // cmbSearchFilter
            // 
            this.cmbSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchFilter.FormattingEnabled = true;
            this.cmbSearchFilter.Items.AddRange(new object[] {
            "Name",
            "Mobile No"});
            this.cmbSearchFilter.Location = new System.Drawing.Point(452, 10);
            this.cmbSearchFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchFilter.Name = "cmbSearchFilter";
            this.cmbSearchFilter.Size = new System.Drawing.Size(147, 26);
            this.cmbSearchFilter.TabIndex = 135;
            // 
            // cmbDSaleType
            // 
            this.cmbDSaleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDSaleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDSaleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDSaleType.FormattingEnabled = true;
            this.cmbDSaleType.Items.AddRange(new object[] {
            "General",
            "Wholesale",
            "Special"});
            this.cmbDSaleType.Location = new System.Drawing.Point(172, 414);
            this.cmbDSaleType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDSaleType.Name = "cmbDSaleType";
            this.cmbDSaleType.Size = new System.Drawing.Size(260, 26);
            this.cmbDSaleType.TabIndex = 4;
            this.cmbDSaleType.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 418);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 18);
            this.label5.TabIndex = 136;
            this.label5.Text = "Sale Type";
            this.label5.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(8, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 111;
            this.label9.Text = "Mobile No.";
            // 
            // txtmobile
            // 
            this.txtmobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobile.Location = new System.Drawing.Point(173, 82);
            this.txtmobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtmobile.MaxLength = 100;
            this.txtmobile.Multiline = true;
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(259, 29);
            this.txtmobile.TabIndex = 2;
            // 
            // txtShortCode
            // 
            this.txtShortCode.AcceptsReturn = true;
            this.txtShortCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtShortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortCode.Location = new System.Drawing.Point(173, 47);
            this.txtShortCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtShortCode.MaxLength = 50;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.ReadOnly = true;
            this.txtShortCode.Size = new System.Drawing.Size(259, 24);
            this.txtShortCode.TabIndex = 140;
            this.txtShortCode.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(9, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 141;
            this.label7.Text = "Short Code";
            // 
            // chkNewAC
            // 
            this.chkNewAC.AutoSize = true;
            this.chkNewAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNewAC.Location = new System.Drawing.Point(940, 476);
            this.chkNewAC.Margin = new System.Windows.Forms.Padding(4);
            this.chkNewAC.Name = "chkNewAC";
            this.chkNewAC.Size = new System.Drawing.Size(54, 19);
            this.chkNewAC.TabIndex = 144;
            this.chkNewAC.Text = "New";
            this.chkNewAC.UseVisualStyleBackColor = true;
            this.chkNewAC.Visible = false;
            this.chkNewAC.CheckedChanged += new System.EventHandler(this.chkNewAC_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(705, 479);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 14);
            this.label11.TabIndex = 143;
            this.label11.Text = "[Account Ledger]";
            this.label11.Visible = false;
            // 
            // cboAccountLedger
            // 
            this.cboAccountLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAccountLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountLedger.DisplayMember = "AccountLedgerName";
            this.cboAccountLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccountLedger.FormattingEnabled = true;
            this.cboAccountLedger.Location = new System.Drawing.Point(855, 473);
            this.cboAccountLedger.Margin = new System.Windows.Forms.Padding(4);
            this.cboAccountLedger.Name = "cboAccountLedger";
            this.cboAccountLedger.Size = new System.Drawing.Size(76, 24);
            this.cboAccountLedger.TabIndex = 142;
            this.cboAccountLedger.TabStop = false;
            this.cboAccountLedger.Tag = "[Country]";
            this.cboAccountLedger.ValueMember = "AccountLedgerId";
            this.cboAccountLedger.Visible = false;
            this.cboAccountLedger.SelectedValueChanged += new System.EventHandler(this.cboAccountLedger_SelectedValueChanged);
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEmployee.Location = new System.Drawing.Point(357, 598);
            this.btnNewEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(76, 34);
            this.btnNewEmployee.TabIndex = 145;
            this.btnNewEmployee.TabStop = false;
            this.btnNewEmployee.Text = "New";
            this.btnNewEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewEmployee.UseVisualStyleBackColor = true;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 125;
            this.label4.Text = "Address Line 2";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressLine2.Location = new System.Drawing.Point(173, 228);
            this.txtAddressLine2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddressLine2.MaxLength = 100;
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(259, 24);
            this.txtAddressLine2.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 268);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 18);
            this.label10.TabIndex = 125;
            this.label10.Text = "Address Line 3";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressLine3.Location = new System.Drawing.Point(173, 265);
            this.txtAddressLine3.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddressLine3.MaxLength = 100;
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(259, 24);
            this.txtAddressLine3.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(8, 342);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 18);
            this.label13.TabIndex = 125;
            this.label13.Text = "Licence #";
            // 
            // txtLicenceNo
            // 
            this.txtLicenceNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenceNo.Location = new System.Drawing.Point(173, 338);
            this.txtLicenceNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicenceNo.MaxLength = 100;
            this.txtLicenceNo.Name = "txtLicenceNo";
            this.txtLicenceNo.Size = new System.Drawing.Size(259, 24);
            this.txtLicenceNo.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 123);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 18);
            this.label14.TabIndex = 111;
            this.label14.Text = "Phone No.";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(173, 119);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNo.MaxLength = 100;
            this.txtPhoneNo.Multiline = true;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(259, 29);
            this.txtPhoneNo.TabIndex = 2;
            this.txtPhoneNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNo_KeyPress);
            // 
            // lblFaxNo
            // 
            this.lblFaxNo.AutoSize = true;
            this.lblFaxNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaxNo.ForeColor = System.Drawing.Color.Black;
            this.lblFaxNo.Location = new System.Drawing.Point(7, 160);
            this.lblFaxNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFaxNo.Name = "lblFaxNo";
            this.lblFaxNo.Size = new System.Drawing.Size(67, 18);
            this.lblFaxNo.TabIndex = 111;
            this.lblFaxNo.Text = "Fax No.";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaxNo.Location = new System.Drawing.Point(172, 156);
            this.txtFaxNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFaxNo.MaxLength = 100;
            this.txtFaxNo.Multiline = true;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(259, 29);
            this.txtFaxNo.TabIndex = 2;
            this.txtFaxNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // frmcustomerentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1047, 638);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.cmbSearchFilter);
            this.Controls.Add(this.chkNewAC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboAccountLedger);
            this.Controls.Add(this.txtShortCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDSaleType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbReference);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.cmbDefaulerType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCreditLimit);
            this.Controls.Add(this.lblCrLimit);
            this.Controls.Add(this.txtLicenceNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAddressLine3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAddressLine2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddressLine1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.btnCustomerInvoice);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblBarCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.optmale);
            this.Controls.Add(this.optfemale);
            this.Controls.Add(this.txtFaxNo);
            this.Controls.Add(this.lblFaxNo);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtmobile);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtcountry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvcustomer);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmcustomerentry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Entry Screen";
            this.Load += new System.EventHandler(this.frmcustomerentry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvcustomer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtcountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton optmale;
        private System.Windows.Forms.RadioButton optfemale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Button btnCustomerInvoice;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.Label lblCrLimit;
        private System.Windows.Forms.ComboBox cmbDefaulerType;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.ComboBox cmbReference;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.ComboBox cmbSearchFilter;
        private System.Windows.Forms.ComboBox cmbDSaleType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtmobile;
        public System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkNewAC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboAccountLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccellno;
        private System.Windows.Forms.DataGridViewTextBoxColumn CivilId;
        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLicenceNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label lblFaxNo;
        private System.Windows.Forms.TextBox txtFaxNo;
    }
}