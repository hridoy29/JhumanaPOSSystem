namespace POSsible
{
    partial class frmCustomerDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerDisplay));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblLogoffMsg = new System.Windows.Forms.Label();
            this.pnlInvoiceDisplay = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblThanku = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblDisplayCardAmountValue = new System.Windows.Forms.Label();
            this.lblDisplayChangeAmountValue = new System.Windows.Forms.Label();
            this.lblCashAmount = new System.Windows.Forms.Label();
            this.lblCardAmount = new System.Windows.Forms.Label();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.lblDisplayCashAmountValue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblItemValue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlWish = new System.Windows.Forms.Panel();
            this.picDesignRight = new System.Windows.Forms.PictureBox();
            this.picDesignFooter = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.picNextCust = new System.Windows.Forms.PictureBox();
            this.picThanks = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlInvoiceDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.pnlWish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesignRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesignFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNextCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThanks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogoffMsg
            // 
            this.lblLogoffMsg.AutoSize = true;
            this.lblLogoffMsg.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoffMsg.Location = new System.Drawing.Point(14, 184);
            this.lblLogoffMsg.Name = "lblLogoffMsg";
            this.lblLogoffMsg.Size = new System.Drawing.Size(680, 68);
            this.lblLogoffMsg.TabIndex = 11;
            this.lblLogoffMsg.Text = "This Checkout is closed";
            this.lblLogoffMsg.Visible = false;
            // 
            // pnlInvoiceDisplay
            // 
            this.pnlInvoiceDisplay.Controls.Add(this.pictureBox2);
            this.pnlInvoiceDisplay.Controls.Add(this.panel1);
            this.pnlInvoiceDisplay.Controls.Add(this.pictureBox6);
            this.pnlInvoiceDisplay.Controls.Add(this.lblThanku);
            this.pnlInvoiceDisplay.Controls.Add(this.pictureBox5);
            this.pnlInvoiceDisplay.Controls.Add(this.lblDisplayCardAmountValue);
            this.pnlInvoiceDisplay.Controls.Add(this.lblDisplayChangeAmountValue);
            this.pnlInvoiceDisplay.Controls.Add(this.lblCashAmount);
            this.pnlInvoiceDisplay.Controls.Add(this.lblCardAmount);
            this.pnlInvoiceDisplay.Controls.Add(this.lblChangeAmount);
            this.pnlInvoiceDisplay.Controls.Add(this.lblDisplayCashAmountValue);
            this.pnlInvoiceDisplay.Controls.Add(this.pictureBox1);
            this.pnlInvoiceDisplay.Controls.Add(this.lblItemValue);
            this.pnlInvoiceDisplay.Controls.Add(this.lblTotalValue);
            this.pnlInvoiceDisplay.Controls.Add(this.lblItem);
            this.pnlInvoiceDisplay.Controls.Add(this.lblTotal);
            this.pnlInvoiceDisplay.Controls.Add(this.dgvItem);
            this.pnlInvoiceDisplay.Controls.Add(this.lblLogoffMsg);
            this.pnlInvoiceDisplay.Location = new System.Drawing.Point(2, 42);
            this.pnlInvoiceDisplay.Name = "pnlInvoiceDisplay";
            this.pnlInvoiceDisplay.Size = new System.Drawing.Size(1022, 743);
            this.pnlInvoiceDisplay.TabIndex = 12;
            this.pnlInvoiceDisplay.Visible = false;
            this.pnlInvoiceDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInvoiceDisplay_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::POSsible.Properties.Resources.fruit_image_280w_x_238h;
            this.pictureBox2.Location = new System.Drawing.Point(730, 173);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(280, 238);
            this.pictureBox2.TabIndex = 84;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Location = new System.Drawing.Point(696, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 49);
            this.panel1.TabIndex = 83;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(41, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(271, 44);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "label1";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::POSsible.Properties.Resources.divider__5w_x_611h;
            this.pictureBox6.Location = new System.Drawing.Point(710, 79);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(5, 531);
            this.pictureBox6.TabIndex = 82;
            this.pictureBox6.TabStop = false;
            // 
            // lblThanku
            // 
            this.lblThanku.BackColor = System.Drawing.Color.Transparent;
            this.lblThanku.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanku.ForeColor = System.Drawing.Color.Black;
            this.lblThanku.Location = new System.Drawing.Point(726, 645);
            this.lblThanku.Name = "lblThanku";
            this.lblThanku.Size = new System.Drawing.Size(285, 37);
            this.lblThanku.TabIndex = 81;
            this.lblThanku.Text = "|| Thanks For Shopping With Us ||";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::POSsible.Properties.Resources.roots_logo_127w_x_78h;
            this.pictureBox5.Location = new System.Drawing.Point(-1, 645);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(127, 78);
            this.pictureBox5.TabIndex = 80;
            this.pictureBox5.TabStop = false;
            // 
            // lblDisplayCardAmountValue
            // 
            this.lblDisplayCardAmountValue.AutoSize = true;
            this.lblDisplayCardAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayCardAmountValue.Location = new System.Drawing.Point(587, 541);
            this.lblDisplayCardAmountValue.Name = "lblDisplayCardAmountValue";
            this.lblDisplayCardAmountValue.Size = new System.Drawing.Size(28, 24);
            this.lblDisplayCardAmountValue.TabIndex = 77;
            this.lblDisplayCardAmountValue.Text = "   ";
            // 
            // lblDisplayChangeAmountValue
            // 
            this.lblDisplayChangeAmountValue.AutoSize = true;
            this.lblDisplayChangeAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayChangeAmountValue.Location = new System.Drawing.Point(587, 508);
            this.lblDisplayChangeAmountValue.Name = "lblDisplayChangeAmountValue";
            this.lblDisplayChangeAmountValue.Size = new System.Drawing.Size(22, 24);
            this.lblDisplayChangeAmountValue.TabIndex = 76;
            this.lblDisplayChangeAmountValue.Text = "  ";
            // 
            // lblCashAmount
            // 
            this.lblCashAmount.AutoSize = true;
            this.lblCashAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashAmount.Location = new System.Drawing.Point(420, 477);
            this.lblCashAmount.Name = "lblCashAmount";
            this.lblCashAmount.Size = new System.Drawing.Size(152, 24);
            this.lblCashAmount.TabIndex = 73;
            this.lblCashAmount.Text = "Cash Amount $";
            // 
            // lblCardAmount
            // 
            this.lblCardAmount.AutoSize = true;
            this.lblCardAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardAmount.Location = new System.Drawing.Point(420, 541);
            this.lblCardAmount.Name = "lblCardAmount";
            this.lblCardAmount.Size = new System.Drawing.Size(155, 24);
            this.lblCardAmount.TabIndex = 72;
            this.lblCardAmount.Text = "Card Amount  $";
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.Location = new System.Drawing.Point(420, 509);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(153, 24);
            this.lblChangeAmount.TabIndex = 74;
            this.lblChangeAmount.Text = "Cash Change $";
            // 
            // lblDisplayCashAmountValue
            // 
            this.lblDisplayCashAmountValue.AutoSize = true;
            this.lblDisplayCashAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayCashAmountValue.Location = new System.Drawing.Point(587, 477);
            this.lblDisplayCashAmountValue.Name = "lblDisplayCashAmountValue";
            this.lblDisplayCashAmountValue.Size = new System.Drawing.Size(28, 24);
            this.lblDisplayCashAmountValue.TabIndex = 75;
            this.lblDisplayCashAmountValue.Text = "   ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(730, 458);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // lblItemValue
            // 
            this.lblItemValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemValue.Location = new System.Drawing.Point(190, 490);
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(143, 31);
            this.lblItemValue.TabIndex = 46;
            this.lblItemValue.Click += new System.EventHandler(this.lblItemValue_Click);
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.Location = new System.Drawing.Point(190, 534);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(143, 31);
            this.lblTotalValue.TabIndex = 45;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(32, 490);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(100, 31);
            this.lblItem.TabIndex = 42;
            this.lblItem.Text = "ITEM :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(32, 534);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 31);
            this.lblTotal.TabIndex = 40;
            this.lblTotal.Text = "TOTAL:  $";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToResizeColumns = false;
            this.dgvItem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.quantity,
            this.subtotal,
            this.itemid});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItem.Location = new System.Drawing.Point(13, 3);
            this.dgvItem.MultiSelect = false;
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidth = 44;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItem.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(684, 419);
            this.dgvItem.TabIndex = 79;
            // 
            // name
            // 
            this.name.HeaderText = "Item";
            this.name.MinimumWidth = 320;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 320;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Qty@Unit";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantity.Width = 210;
            // 
            // subtotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.subtotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.MinimumWidth = 145;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subtotal.Width = 145;
            // 
            // itemid
            // 
            this.itemid.HeaderText = "ItemID";
            this.itemid.Name = "itemid";
            this.itemid.ReadOnly = true;
            this.itemid.Visible = false;
            this.itemid.Width = 126;
            // 
            // pnlWish
            // 
            this.pnlWish.BackColor = System.Drawing.Color.Gray;
            this.pnlWish.Controls.Add(this.picDesignRight);
            this.pnlWish.Controls.Add(this.picDesignFooter);
            this.pnlWish.Controls.Add(this.pictureBox7);
            this.pnlWish.Controls.Add(this.picNextCust);
            this.pnlWish.Controls.Add(this.picThanks);
            this.pnlWish.Location = new System.Drawing.Point(1, 42);
            this.pnlWish.Name = "pnlWish";
            this.pnlWish.Size = new System.Drawing.Size(1023, 729);
            this.pnlWish.TabIndex = 44;
            this.pnlWish.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWish_Paint);
            // 
            // picDesignRight
            // 
            this.picDesignRight.BackColor = System.Drawing.Color.Transparent;
            this.picDesignRight.BackgroundImage = global::POSsible.Properties.Resources.design_right__146w_x_332_h;
            this.picDesignRight.Location = new System.Drawing.Point(877, 25);
            this.picDesignRight.Name = "picDesignRight";
            this.picDesignRight.Size = new System.Drawing.Size(146, 332);
            this.picDesignRight.TabIndex = 19;
            this.picDesignRight.TabStop = false;
            // 
            // picDesignFooter
            // 
            this.picDesignFooter.BackColor = System.Drawing.Color.Transparent;
            this.picDesignFooter.BackgroundImage = global::POSsible.Properties.Resources.design_01_left___263w_x_271;
            this.picDesignFooter.Location = new System.Drawing.Point(-1, 458);
            this.picDesignFooter.Name = "picDesignFooter";
            this.picDesignFooter.Size = new System.Drawing.Size(263, 271);
            this.picDesignFooter.TabIndex = 18;
            this.picDesignFooter.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = global::POSsible.Properties.Resources.divider___826w_x_6h;
            this.pictureBox7.Location = new System.Drawing.Point(88, 363);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(826, 6);
            this.pictureBox7.TabIndex = 17;
            this.pictureBox7.TabStop = false;
            // 
            // picNextCust
            // 
            this.picNextCust.BackColor = System.Drawing.Color.Transparent;
            this.picNextCust.BackgroundImage = global::POSsible.Properties.Resources.next_customer_please__799w_;
            this.picNextCust.Location = new System.Drawing.Point(99, 352);
            this.picNextCust.Name = "picNextCust";
            this.picNextCust.Size = new System.Drawing.Size(799, 119);
            this.picNextCust.TabIndex = 16;
            this.picNextCust.TabStop = false;
            // 
            // picThanks
            // 
            this.picThanks.BackColor = System.Drawing.Color.Transparent;
            this.picThanks.BackgroundImage = global::POSsible.Properties.Resources.thank_you___405w_x_81h;
            this.picThanks.Location = new System.Drawing.Point(300, 276);
            this.picThanks.Name = "picThanks";
            this.picThanks.Size = new System.Drawing.Size(405, 81);
            this.picThanks.TabIndex = 15;
            this.picThanks.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCustomerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1024, 780);
            this.ControlBox = false;
            this.Controls.Add(this.pnlWish);
            this.Controls.Add(this.pnlInvoiceDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomerDisplay";
            this.Text = "Familyneeds Pvt. Ltd. Customer Display ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlInvoiceDisplay.ResumeLayout(false);
            this.pnlInvoiceDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.pnlWish.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDesignRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesignFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNextCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThanks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblLogoffMsg;
        public System.Windows.Forms.Panel pnlInvoiceDisplay;
        
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblTotal;
        
        public System.Windows.Forms.Label lblItemValue;
        public System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblDisplayCardAmountValue;
        public System.Windows.Forms.Label lblDisplayChangeAmountValue;
        private System.Windows.Forms.Label lblCashAmount;
        private System.Windows.Forms.Label lblCardAmount;
        private System.Windows.Forms.Label lblChangeAmount;
        public System.Windows.Forms.Label lblDisplayCashAmountValue;
        public System.Windows.Forms.Panel pnlWish;
        private System.Windows.Forms.PictureBox picDesignRight;
        private System.Windows.Forms.PictureBox picDesignFooter;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox picNextCust;
        private System.Windows.Forms.PictureBox picThanks;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblThanku;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;

    }
}