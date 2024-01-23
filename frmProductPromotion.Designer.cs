namespace POSsible
{
    partial class frmProductPromotion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPOCatalogue = new System.Windows.Forms.RadioButton();
            this.rbPOProduct = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPTFree = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rbPTPercentage = new System.Windows.Forms.RadioButton();
            this.rbPTFixed = new System.Windows.Forms.RadioButton();
            this.lblVariation = new System.Windows.Forms.Label();
            this.txtVariation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFreeQty = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.dgvPromotion = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbProductPromo = new System.Windows.Forms.ComboBox();
            this.lblPromo = new System.Windows.Forms.Label();
            this.cmbCategoryPromo = new System.Windows.Forms.ComboBox();
            this.PromoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Startdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromoType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Promotion On";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbPOCatalogue
            // 
            this.rbPOCatalogue.AutoSize = true;
            this.rbPOCatalogue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPOCatalogue.Location = new System.Drawing.Point(272, 26);
            this.rbPOCatalogue.Name = "rbPOCatalogue";
            this.rbPOCatalogue.Size = new System.Drawing.Size(83, 18);
            this.rbPOCatalogue.TabIndex = 101;
            this.rbPOCatalogue.Text = "Category";
            this.rbPOCatalogue.UseVisualStyleBackColor = true;
            // 
            // rbPOProduct
            // 
            this.rbPOProduct.AutoSize = true;
            this.rbPOProduct.Checked = true;
            this.rbPOProduct.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPOProduct.Location = new System.Drawing.Point(156, 25);
            this.rbPOProduct.Name = "rbPOProduct";
            this.rbPOProduct.Size = new System.Drawing.Size(73, 18);
            this.rbPOProduct.TabIndex = 100;
            this.rbPOProduct.TabStop = true;
            this.rbPOProduct.Text = "Product";
            this.rbPOProduct.UseVisualStyleBackColor = true;
            this.rbPOProduct.CheckedChanged += new System.EventHandler(this.rbPOProduct_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 102;
            this.label2.Text = "Start Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(260, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 103;
            this.label3.Text = "End Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(135, 101);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(122, 24);
            this.dtpStartDate.TabIndex = 104;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(378, 101);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(123, 24);
            this.dtpEndDate.TabIndex = 105;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPTFree);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rbPTPercentage);
            this.groupBox1.Controls.Add(this.rbPTFixed);
            this.groupBox1.Location = new System.Drawing.Point(15, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 54);
            this.groupBox1.TabIndex = 223;
            this.groupBox1.TabStop = false;
            // 
            // rbPTFree
            // 
            this.rbPTFree.AutoSize = true;
            this.rbPTFree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTFree.Location = new System.Drawing.Point(397, 20);
            this.rbPTFree.Name = "rbPTFree";
            this.rbPTFree.Size = new System.Drawing.Size(53, 18);
            this.rbPTFree.TabIndex = 227;
            this.rbPTFree.Text = "Free";
            this.rbPTFree.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 23);
            this.label5.TabIndex = 224;
            this.label5.Text = "Promo. Type";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbPTPercentage
            // 
            this.rbPTPercentage.AutoSize = true;
            this.rbPTPercentage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTPercentage.Location = new System.Drawing.Point(242, 20);
            this.rbPTPercentage.Name = "rbPTPercentage";
            this.rbPTPercentage.Size = new System.Drawing.Size(97, 18);
            this.rbPTPercentage.TabIndex = 226;
            this.rbPTPercentage.Text = "Percentage";
            this.rbPTPercentage.UseVisualStyleBackColor = true;
            this.rbPTPercentage.CheckedChanged += new System.EventHandler(this.rbPTPercentage_CheckedChanged);
            // 
            // rbPTFixed
            // 
            this.rbPTFixed.AutoSize = true;
            this.rbPTFixed.Checked = true;
            this.rbPTFixed.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPTFixed.Location = new System.Drawing.Point(138, 20);
            this.rbPTFixed.Name = "rbPTFixed";
            this.rbPTFixed.Size = new System.Drawing.Size(58, 18);
            this.rbPTFixed.TabIndex = 225;
            this.rbPTFixed.TabStop = true;
            this.rbPTFixed.Text = "Fixed";
            this.rbPTFixed.UseVisualStyleBackColor = true;
            this.rbPTFixed.CheckedChanged += new System.EventHandler(this.rbPTFixed_CheckedChanged);
            // 
            // lblVariation
            // 
            this.lblVariation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVariation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblVariation.ForeColor = System.Drawing.Color.White;
            this.lblVariation.Location = new System.Drawing.Point(26, 201);
            this.lblVariation.Name = "lblVariation";
            this.lblVariation.Size = new System.Drawing.Size(107, 23);
            this.lblVariation.TabIndex = 112;
            this.lblVariation.Text = "Price";
            this.lblVariation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVariation
            // 
            this.txtVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVariation.Location = new System.Drawing.Point(135, 201);
            this.txtVariation.Name = "txtVariation";
            this.txtVariation.Size = new System.Drawing.Size(123, 22);
            this.txtVariation.TabIndex = 113;
            this.txtVariation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVariation_KeyPress);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(260, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 23);
            this.label7.TabIndex = 114;
            this.label7.Text = "Free Qty";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // txtFreeQty
            // 
            this.txtFreeQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreeQty.Location = new System.Drawing.Point(378, 201);
            this.txtFreeQty.Name = "txtFreeQty";
            this.txtFreeQty.Size = new System.Drawing.Size(123, 22);
            this.txtFreeQty.TabIndex = 115;
            this.txtFreeQty.Visible = false;
            this.txtFreeQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFreeQty_KeyPress);
            // 
            // lblProduct
            // 
            this.lblProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProduct.ForeColor = System.Drawing.Color.White;
            this.lblProduct.Location = new System.Drawing.Point(26, 239);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(107, 23);
            this.lblProduct.TabIndex = 220;
            this.lblProduct.Text = "Product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProduct.Visible = false;
            // 
            // cmbProduct
            // 
            this.cmbProduct.DisplayMember = "name";
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.DropDownWidth = 85;
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProduct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.Location = new System.Drawing.Point(135, 238);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(366, 24);
            this.cmbProduct.TabIndex = 221;
            this.cmbProduct.ValueMember = "productId";
            this.cmbProduct.Visible = false;
            // 
            // dgvPromotion
            // 
            this.dgvPromotion.AllowUserToAddRows = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPromotion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPromotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPromotion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPromotion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPromotion.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPromotion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPromotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PromoNo,
            this.Startdt,
            this.EndDt,
            this.PromoType,
            this.promoId,
            this.edit,
            this.Column6});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPromotion.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPromotion.Location = new System.Drawing.Point(2, 281);
            this.dgvPromotion.Name = "dgvPromotion";
            this.dgvPromotion.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPromotion.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvPromotion.RowHeadersVisible = false;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPromotion.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPromotion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromotion.Size = new System.Drawing.Size(515, 173);
            this.dgvPromotion.TabIndex = 222;
            this.dgvPromotion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromotion_CellContentClick);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(334, 460);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 33);
            this.btnReset.TabIndex = 225;
            this.btnReset.Text = "&RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(422, 460);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 33);
            this.btnExit.TabIndex = 227;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImage = global::POSsible.Properties.Resources.delete_110w_x_33h;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(246, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 226;
            this.btnSave.Tag = "SAVE";
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbProductPromo
            // 
            this.cmbProductPromo.DisplayMember = "name";
            this.cmbProductPromo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductPromo.DropDownWidth = 85;
            this.cmbProductPromo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProductPromo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductPromo.Location = new System.Drawing.Point(135, 62);
            this.cmbProductPromo.Name = "cmbProductPromo";
            this.cmbProductPromo.Size = new System.Drawing.Size(366, 24);
            this.cmbProductPromo.TabIndex = 229;
            this.cmbProductPromo.ValueMember = "productId";
            // 
            // lblPromo
            // 
            this.lblPromo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPromo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPromo.ForeColor = System.Drawing.Color.White;
            this.lblPromo.Location = new System.Drawing.Point(26, 62);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(107, 23);
            this.lblPromo.TabIndex = 228;
            this.lblPromo.Text = "Product";
            this.lblPromo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategoryPromo
            // 
            this.cmbCategoryPromo.DisplayMember = "deptName";
            this.cmbCategoryPromo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryPromo.DropDownWidth = 85;
            this.cmbCategoryPromo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategoryPromo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoryPromo.Location = new System.Drawing.Point(135, 62);
            this.cmbCategoryPromo.Name = "cmbCategoryPromo";
            this.cmbCategoryPromo.Size = new System.Drawing.Size(366, 24);
            this.cmbCategoryPromo.TabIndex = 230;
            this.cmbCategoryPromo.ValueMember = "categoryId";
            // 
            // PromoNo
            // 
            this.PromoNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PromoNo.HeaderText = "Promotion No.";
            this.PromoNo.Name = "PromoNo";
            this.PromoNo.ReadOnly = true;
            this.PromoNo.Width = 115;
            // 
            // Startdt
            // 
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            this.Startdt.DefaultCellStyle = dataGridViewCellStyle10;
            this.Startdt.HeaderText = "Start Date";
            this.Startdt.Name = "Startdt";
            this.Startdt.ReadOnly = true;
            this.Startdt.Width = 102;
            // 
            // EndDt
            // 
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            this.EndDt.DefaultCellStyle = dataGridViewCellStyle11;
            this.EndDt.HeaderText = "End Date";
            this.EndDt.Name = "EndDt";
            this.EndDt.ReadOnly = true;
            this.EndDt.Width = 97;
            // 
            // PromoType
            // 
            this.PromoType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PromoType.HeaderText = "Promo Type";
            this.PromoType.Name = "PromoType";
            this.PromoType.ReadOnly = true;
            // 
            // promoId
            // 
            this.promoId.HeaderText = "PromoId";
            this.promoId.Name = "promoId";
            this.promoId.ReadOnly = true;
            this.promoId.Visible = false;
            this.promoId.Width = 91;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.edit.HeaderText = "Edit";
            this.edit.Image = global::POSsible.Properties.Resources.UniversalEditButton3_22230410;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 50;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "Del";
            this.Column6.Image = global::POSsible.Properties.Resources.bullet_cross;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 40;
            // 
            // frmProductPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(518, 502);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbProductPromo);
            this.Controls.Add(this.lblPromo);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPromotion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.txtFreeQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVariation);
            this.Controls.Add(this.lblVariation);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbPOCatalogue);
            this.Controls.Add(this.rbPOProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCategoryPromo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductPromotion";
            this.Text = "Product Production";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPOCatalogue;
        private System.Windows.Forms.RadioButton rbPOProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblVariation;
        private System.Windows.Forms.TextBox txtVariation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFreeQty;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        public System.Windows.Forms.DataGridView dgvPromotion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPTFree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbPTPercentage;
        private System.Windows.Forms.RadioButton rbPTFixed;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbProductPromo;
        private System.Windows.Forms.Label lblPromo;
        private System.Windows.Forms.ComboBox cmbCategoryPromo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Startdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromoType;
        private System.Windows.Forms.DataGridViewTextBoxColumn promoId;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
    }
}