namespace POSsible
{
    partial class OpeningQtyEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboItemSelect = new System.Windows.Forms.ComboBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtOPQty = new System.Windows.Forms.TextBox();
            this.lblUnitQty = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOpeningDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Del = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmbItemBarcodeSearch = new System.Windows.Forms.ComboBox();
            this.cmbSearchFilter = new System.Windows.Forms.ComboBox();
            this.cmbSearchCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbItemNameSearch = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.lblUnitCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboItemSelect
            // 
            this.cboItemSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemSelect.BackColor = System.Drawing.Color.White;
            this.cboItemSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemSelect.Location = new System.Drawing.Point(118, 44);
            this.cboItemSelect.Name = "cboItemSelect";
            this.cboItemSelect.Size = new System.Drawing.Size(532, 26);
            this.cboItemSelect.TabIndex = 80;
            this.cboItemSelect.SelectedIndexChanged += new System.EventHandler(this.cboItemSelect_SelectedIndexChanged);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblSubtotal.Location = new System.Drawing.Point(12, 45);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(130, 23);
            this.lblSubtotal.TabIndex = 81;
            this.lblSubtotal.Text = "Item Name";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOPQty
            // 
            this.txtOPQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOPQty.Location = new System.Drawing.Point(118, 81);
            this.txtOPQty.MaxLength = 6;
            this.txtOPQty.Name = "txtOPQty";
            this.txtOPQty.Size = new System.Drawing.Size(96, 24);
            this.txtOPQty.TabIndex = 82;
            this.txtOPQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOPQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPQty_KeyPress);
            // 
            // lblUnitQty
            // 
            this.lblUnitQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnitQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitQty.ForeColor = System.Drawing.Color.White;
            this.lblUnitQty.Location = new System.Drawing.Point(13, 82);
            this.lblUnitQty.Name = "lblUnitQty";
            this.lblUnitQty.Size = new System.Drawing.Size(110, 23);
            this.lblUnitQty.TabIndex = 83;
            this.lblUnitQty.Text = "Qty";
            this.lblUnitQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStore
            // 
            this.cmbStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(118, 6);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(325, 26);
            this.cmbStore.TabIndex = 146;
            this.cmbStore.SelectedIndexChanged += new System.EventHandler(this.cmbStore_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 145;
            this.label1.Text = "Store";
            // 
            // dtpOpeningDate
            // 
            this.dtpOpeningDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpOpeningDate.CustomFormat = "dd/MM/yyyy";
            this.dtpOpeningDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOpeningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOpeningDate.Location = new System.Drawing.Point(521, 7);
            this.dtpOpeningDate.Name = "dtpOpeningDate";
            this.dtpOpeningDate.Size = new System.Drawing.Size(129, 24);
            this.dtpOpeningDate.TabIndex = 242;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(449, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 241;
            this.label9.Text = "O. Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItem.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvItem.ColumnHeadersHeight = 24;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemName,
            this.OpQty,
            this.ODate,
            this.productId,
            this.store,
            this.unitp,
            this.trans,
            this.Edit,
            this.Del});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItem.Location = new System.Drawing.Point(10, 242);
            this.dgvItem.Name = "dgvItem";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            this.dgvItem.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItem.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvItem.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(633, 260);
            this.dgvItem.TabIndex = 243;
            this.dgvItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellContentClick);
            // 
            // itemName
            // 
            this.itemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemName.HeaderText = "Item Name";
            this.itemName.MinimumWidth = 50;
            this.itemName.Name = "itemName";
            this.itemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemName.Width = 79;
            // 
            // OpQty
            // 
            this.OpQty.HeaderText = "Opening Qty";
            this.OpQty.Name = "OpQty";
            this.OpQty.Width = 107;
            // 
            // ODate
            // 
            dataGridViewCellStyle21.Format = "d";
            dataGridViewCellStyle21.NullValue = null;
            this.ODate.DefaultCellStyle = dataGridViewCellStyle21;
            this.ODate.HeaderText = "Opening Date";
            this.ODate.Name = "ODate";
            this.ODate.Width = 116;
            // 
            // productId
            // 
            this.productId.HeaderText = "productId";
            this.productId.Name = "productId";
            this.productId.ReadOnly = true;
            this.productId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productId.Visible = false;
            this.productId.Width = 70;
            // 
            // store
            // 
            this.store.HeaderText = "storeId";
            this.store.Name = "store";
            this.store.Visible = false;
            this.store.Width = 74;
            // 
            // unitp
            // 
            this.unitp.HeaderText = "UnitPrice";
            this.unitp.Name = "unitp";
            this.unitp.Visible = false;
            this.unitp.Width = 87;
            // 
            // trans
            // 
            this.trans.HeaderText = "transId";
            this.trans.Name = "trans";
            this.trans.Visible = false;
            this.trans.Width = 73;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = global::POSsible.Properties.Resources.UniversalEditButton3_22230410;
            this.Edit.Name = "Edit";
            this.Edit.Width = 37;
            // 
            // Del
            // 
            this.Del.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Del.HeaderText = "Del";
            this.Del.Image = global::POSsible.Properties.Resources.bullet_cross;
            this.Del.Name = "Del";
            this.Del.Width = 40;
            // 
            // cmbItemBarcodeSearch
            // 
            this.cmbItemBarcodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemBarcodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemBarcodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemBarcodeSearch.DisplayMember = "barcodeNo";
            this.cmbItemBarcodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbItemBarcodeSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemBarcodeSearch.Location = new System.Drawing.Point(153, 210);
            this.cmbItemBarcodeSearch.Name = "cmbItemBarcodeSearch";
            this.cmbItemBarcodeSearch.Size = new System.Drawing.Size(491, 24);
            this.cmbItemBarcodeSearch.TabIndex = 246;
            this.cmbItemBarcodeSearch.ValueMember = "productId";
            // 
            // cmbSearchFilter
            // 
            this.cmbSearchFilter.DisplayMember = "deptName";
            this.cmbSearchFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSearchFilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchFilter.Items.AddRange(new object[] {
            "Name",
            "Barcode"});
            this.cmbSearchFilter.Location = new System.Drawing.Point(13, 209);
            this.cmbSearchFilter.Name = "cmbSearchFilter";
            this.cmbSearchFilter.Size = new System.Drawing.Size(123, 24);
            this.cmbSearchFilter.TabIndex = 245;
            this.cmbSearchFilter.ValueMember = "categoryId";
            this.cmbSearchFilter.SelectedIndexChanged += new System.EventHandler(this.cmbSearchFilter_SelectedIndexChanged);
            // 
            // cmbSearchCategory
            // 
            this.cmbSearchCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearchCategory.DisplayMember = "deptName";
            this.cmbSearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSearchCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchCategory.Location = new System.Drawing.Point(152, 177);
            this.cmbSearchCategory.Name = "cmbSearchCategory";
            this.cmbSearchCategory.Size = new System.Drawing.Size(491, 24);
            this.cmbSearchCategory.TabIndex = 247;
            this.cmbSearchCategory.ValueMember = "categoryId";
            this.cmbSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSearchCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location = new System.Drawing.Point(13, 177);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(123, 24);
            this.lblCategory.TabIndex = 248;
            this.lblCategory.Text = "Category";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbItemNameSearch);
            this.groupBox1.Location = new System.Drawing.Point(-1, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 348);
            this.groupBox1.TabIndex = 249;
            this.groupBox1.TabStop = false;
            // 
            // cmbItemNameSearch
            // 
            this.cmbItemNameSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemNameSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNameSearch.DisplayMember = "name";
            this.cmbItemNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbItemNameSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemNameSearch.Location = new System.Drawing.Point(153, 49);
            this.cmbItemNameSearch.Name = "cmbItemNameSearch";
            this.cmbItemNameSearch.Size = new System.Drawing.Size(263, 24);
            this.cmbItemNameSearch.TabIndex = 255;
            this.cmbItemNameSearch.ValueMember = "productId";
            this.cmbItemNameSearch.SelectedIndexChanged += new System.EventHandler(this.cmbItemNameSearch_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(122, 124);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 33);
            this.btnReset.TabIndex = 251;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(235, 124);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 33);
            this.btnExit.TabIndex = 252;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(10, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 33);
            this.btnAdd.TabIndex = 250;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitCost.Location = new System.Drawing.Point(322, 82);
            this.txtUnitCost.MaxLength = 6;
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(328, 24);
            this.txtUnitCost.TabIndex = 253;
            this.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitCost_KeyPress);
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnitCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitCost.ForeColor = System.Drawing.Color.White;
            this.lblUnitCost.Location = new System.Drawing.Point(220, 82);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(108, 23);
            this.lblUnitCost.TabIndex = 254;
            this.lblUnitCost.Text = "Unit Price";
            this.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OpeningQtyEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(663, 514);
            this.Controls.Add(this.txtUnitCost);
            this.Controls.Add(this.lblUnitCost);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbSearchCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbItemBarcodeSearch);
            this.Controls.Add(this.cmbSearchFilter);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.dtpOpeningDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOPQty);
            this.Controls.Add(this.lblUnitQty);
            this.Controls.Add(this.cboItemSelect);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.groupBox1);
            this.Name = "OpeningQtyEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opening Qty Entry";
            this.Load += new System.EventHandler(this.OpeningQtyEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboItemSelect;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtOPQty;
        private System.Windows.Forms.Label lblUnitQty;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOpeningDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvItem;
        internal System.Windows.Forms.ComboBox cmbItemBarcodeSearch;
        internal System.Windows.Forms.ComboBox cmbSearchFilter;
        internal System.Windows.Forms.ComboBox cmbSearchCategory;
        internal System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.Label lblUnitCost;
        internal System.Windows.Forms.ComboBox cmbItemNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn store;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitp;
        private System.Windows.Forms.DataGridViewTextBoxColumn trans;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Del;
    }
}