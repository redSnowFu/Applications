namespace Bullseye
{
    partial class Inventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtItemSku = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkUnderThreshold = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpLocationSearch = new System.Windows.Forms.GroupBox();
            this.grpReorder = new System.Windows.Forms.GroupBox();
            this.lblCaseSize2 = new System.Windows.Forms.Label();
            this.btnUpdateReorder = new System.Windows.Forms.Button();
            this.nudReorderLevel = new System.Windows.Forms.NumericUpDown();
            this.nudReorderThreshold = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnAddto = new System.Windows.Forms.Button();
            this.btnAddall = new System.Windows.Forms.Button();
            this.cboAddtoTypes = new System.Windows.Forms.ComboBox();
            this.bdsInventory = new System.Windows.Forms.BindingSource(this.components);
            this.grpAddTo = new System.Windows.Forms.GroupBox();
            this.lblQuan = new System.Windows.Forms.Label();
            this.nudCsQuan = new System.Windows.Forms.NumericUpDown();
            this.lblcSize = new System.Windows.Forms.Label();
            this.grpAddPanel = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudQuan = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGotoOrder = new System.Windows.Forms.Button();
            this.grpOrderAndReturn = new System.Windows.Forms.GroupBox();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lstOrdering = new System.Windows.Forms.ListBox();
            this.grpConvenience = new System.Windows.Forms.GroupBox();
            this.inventoryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.inventoryTableAdapter();
            this.itemTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.itemTableAdapter();
            this.transactionlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionlineTableAdapter();
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.locationTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.locationTableAdapter();
            this.transactiontypeTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactiontypeTableAdapter();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.grpLocationSearch.SuspendLayout();
            this.grpReorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInventory)).BeginInit();
            this.grpAddTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCsQuan)).BeginInit();
            this.grpAddPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuan)).BeginInit();
            this.grpOrderAndReturn.SuspendLayout();
            this.grpConvenience.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grpSearch.Controls.Add(this.txtItemSku);
            this.grpSearch.Controls.Add(this.label9);
            this.grpSearch.Controls.Add(this.chkUnderThreshold);
            this.grpSearch.Controls.Add(this.label6);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtItemID);
            this.grpSearch.Controls.Add(this.label5);
            this.grpSearch.Controls.Add(this.cboCategory);
            this.grpSearch.Controls.Add(this.label4);
            this.grpSearch.Controls.Add(this.txtDescription);
            this.grpSearch.Controls.Add(this.label3);
            this.grpSearch.Controls.Add(this.txtItemName);
            this.grpSearch.Controls.Add(this.label2);
            this.grpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearch.Location = new System.Drawing.Point(462, 72);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(941, 177);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // txtItemSku
            // 
            this.txtItemSku.Location = new System.Drawing.Point(699, 64);
            this.txtItemSku.Name = "txtItemSku";
            this.txtItemSku.Size = new System.Drawing.Size(168, 27);
            this.txtItemSku.TabIndex = 3;
            this.txtItemSku.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemSku_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(565, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Item sku:";
            // 
            // chkUnderThreshold
            // 
            this.chkUnderThreshold.AutoSize = true;
            this.chkUnderThreshold.Location = new System.Drawing.Point(365, 145);
            this.chkUnderThreshold.Name = "chkUnderThreshold";
            this.chkUnderThreshold.Size = new System.Drawing.Size(18, 17);
            this.chkUnderThreshold.TabIndex = 5;
            this.chkUnderThreshold.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Reached Reorder Threshold?";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(736, 118);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 44);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(699, 25);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(168, 27);
            this.txtItemID.TabIndex = 1;
            this.txtItemID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemID_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(565, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Item ID:";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(165, 26);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(218, 28);
            this.cboCategory.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Category:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(165, 102);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(218, 27);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description:";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(165, 64);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(327, 27);
            this.txtItemName.TabIndex = 2;
            this.txtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Item Name:";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 496);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(1038, 353);
            this.dgvInventory.TabIndex = 8;
            this.dgvInventory.SelectionChanged += new System.EventHandler(this.dgvInventory_SelectionChanged);
            // 
            // cboLocation
            // 
            this.cboLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(118, 34);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(202, 28);
            this.cboLocation.TabIndex = 0;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(143, 217);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 44);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpLocationSearch
            // 
            this.grpLocationSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grpLocationSearch.Controls.Add(this.label1);
            this.grpLocationSearch.Controls.Add(this.cboLocation);
            this.grpLocationSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLocationSearch.Location = new System.Drawing.Point(47, 85);
            this.grpLocationSearch.Name = "grpLocationSearch";
            this.grpLocationSearch.Size = new System.Drawing.Size(328, 83);
            this.grpLocationSearch.TabIndex = 12;
            this.grpLocationSearch.TabStop = false;
            this.grpLocationSearch.Text = "Location";
            // 
            // grpReorder
            // 
            this.grpReorder.BackColor = System.Drawing.Color.Aqua;
            this.grpReorder.Controls.Add(this.lblCaseSize2);
            this.grpReorder.Controls.Add(this.btnUpdateReorder);
            this.grpReorder.Controls.Add(this.nudReorderLevel);
            this.grpReorder.Controls.Add(this.nudReorderThreshold);
            this.grpReorder.Controls.Add(this.label8);
            this.grpReorder.Controls.Add(this.label7);
            this.grpReorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReorder.Location = new System.Drawing.Point(1073, 496);
            this.grpReorder.Name = "grpReorder";
            this.grpReorder.Size = new System.Drawing.Size(330, 191);
            this.grpReorder.TabIndex = 13;
            this.grpReorder.TabStop = false;
            this.grpReorder.Text = "Reorder by";
            // 
            // lblCaseSize2
            // 
            this.lblCaseSize2.AutoSize = true;
            this.lblCaseSize2.Location = new System.Drawing.Point(274, 90);
            this.lblCaseSize2.Name = "lblCaseSize2";
            this.lblCaseSize2.Size = new System.Drawing.Size(0, 20);
            this.lblCaseSize2.TabIndex = 22;
            // 
            // btnUpdateReorder
            // 
            this.btnUpdateReorder.Location = new System.Drawing.Point(88, 139);
            this.btnUpdateReorder.Name = "btnUpdateReorder";
            this.btnUpdateReorder.Size = new System.Drawing.Size(131, 44);
            this.btnUpdateReorder.TabIndex = 2;
            this.btnUpdateReorder.Text = "Update";
            this.btnUpdateReorder.UseVisualStyleBackColor = true;
            this.btnUpdateReorder.Click += new System.EventHandler(this.btnUpdateReorder_Click);
            // 
            // nudReorderLevel
            // 
            this.nudReorderLevel.Location = new System.Drawing.Point(88, 106);
            this.nudReorderLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudReorderLevel.Name = "nudReorderLevel";
            this.nudReorderLevel.Size = new System.Drawing.Size(131, 27);
            this.nudReorderLevel.TabIndex = 1;
            this.nudReorderLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudReorderThreshold
            // 
            this.nudReorderThreshold.Location = new System.Drawing.Point(88, 51);
            this.nudReorderThreshold.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudReorderThreshold.Name = "nudReorderThreshold";
            this.nudReorderThreshold.Size = new System.Drawing.Size(131, 27);
            this.nudReorderThreshold.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Reorder level:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Reorder threshold:";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(23, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(1286, 60);
            this.lblUserInfo.TabIndex = 18;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddto
            // 
            this.btnAddto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddto.Location = new System.Drawing.Point(29, 99);
            this.btnAddto.Name = "btnAddto";
            this.btnAddto.Size = new System.Drawing.Size(87, 35);
            this.btnAddto.TabIndex = 22;
            this.btnAddto.Text = "Add to";
            this.btnAddto.UseVisualStyleBackColor = true;
            this.btnAddto.Click += new System.EventHandler(this.btnAddto_Click);
            // 
            // btnAddall
            // 
            this.btnAddall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddall.Location = new System.Drawing.Point(35, 26);
            this.btnAddall.Name = "btnAddall";
            this.btnAddall.Size = new System.Drawing.Size(267, 48);
            this.btnAddall.TabIndex = 22;
            this.btnAddall.Text = "Add all low-quantity item(s) to Order(s)";
            this.btnAddall.UseVisualStyleBackColor = true;
            this.btnAddall.Click += new System.EventHandler(this.btnAddall_Click);
            // 
            // cboAddtoTypes
            // 
            this.cboAddtoTypes.FormattingEnabled = true;
            this.cboAddtoTypes.Location = new System.Drawing.Point(143, 100);
            this.cboAddtoTypes.Name = "cboAddtoTypes";
            this.cboAddtoTypes.Size = new System.Drawing.Size(245, 28);
            this.cboAddtoTypes.TabIndex = 23;
            this.cboAddtoTypes.SelectedIndexChanged += new System.EventHandler(this.cboAddtoTypes_SelectedIndexChanged);
            // 
            // grpAddTo
            // 
            this.grpAddTo.BackColor = System.Drawing.Color.Aqua;
            this.grpAddTo.Controls.Add(this.lblQuan);
            this.grpAddTo.Controls.Add(this.nudCsQuan);
            this.grpAddTo.Controls.Add(this.cboAddtoTypes);
            this.grpAddTo.Controls.Add(this.btnAddto);
            this.grpAddTo.Controls.Add(this.lblcSize);
            this.grpAddTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddTo.Location = new System.Drawing.Point(12, 300);
            this.grpAddTo.Name = "grpAddTo";
            this.grpAddTo.Size = new System.Drawing.Size(425, 162);
            this.grpAddTo.TabIndex = 23;
            this.grpAddTo.TabStop = false;
            this.grpAddTo.Text = "Add";
            // 
            // lblQuan
            // 
            this.lblQuan.AutoSize = true;
            this.lblQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuan.Location = new System.Drawing.Point(31, 43);
            this.lblQuan.Name = "lblQuan";
            this.lblQuan.Size = new System.Drawing.Size(85, 20);
            this.lblQuan.TabIndex = 34;
            this.lblQuan.Text = "Quantity:";
            // 
            // nudCsQuan
            // 
            this.nudCsQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCsQuan.Location = new System.Drawing.Point(143, 43);
            this.nudCsQuan.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCsQuan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCsQuan.Name = "nudCsQuan";
            this.nudCsQuan.Size = new System.Drawing.Size(71, 27);
            this.nudCsQuan.TabIndex = 32;
            this.nudCsQuan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblcSize
            // 
            this.lblcSize.AutoSize = true;
            this.lblcSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcSize.Location = new System.Drawing.Point(243, 45);
            this.lblcSize.Name = "lblcSize";
            this.lblcSize.Size = new System.Drawing.Size(102, 20);
            this.lblcSize.TabIndex = 30;
            this.lblcSize.Text = "* CaseSize";
            // 
            // grpAddPanel
            // 
            this.grpAddPanel.BackColor = System.Drawing.Color.Aqua;
            this.grpAddPanel.Controls.Add(this.btnCancel);
            this.grpAddPanel.Controls.Add(this.btnSave);
            this.grpAddPanel.Controls.Add(this.txtReason);
            this.grpAddPanel.Controls.Add(this.lblReason);
            this.grpAddPanel.Controls.Add(this.label12);
            this.grpAddPanel.Controls.Add(this.nudQuan);
            this.grpAddPanel.Controls.Add(this.lblTitle);
            this.grpAddPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddPanel.Location = new System.Drawing.Point(462, 255);
            this.grpAddPanel.Name = "grpAddPanel";
            this.grpAddPanel.Size = new System.Drawing.Size(411, 222);
            this.grpAddPanel.TabIndex = 24;
            this.grpAddPanel.TabStop = false;
            this.grpAddPanel.Text = "Edit";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(270, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(39, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 36);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(30, 124);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(368, 27);
            this.txtReason.TabIndex = 33;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(26, 90);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(145, 20);
            this.lblReason.TabIndex = 32;
            this.lblReason.Text = "Reason / Notes:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Quantity:";
            // 
            // nudQuan
            // 
            this.nudQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuan.Location = new System.Drawing.Point(135, 60);
            this.nudQuan.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudQuan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuan.Name = "nudQuan";
            this.nudQuan.Size = new System.Drawing.Size(71, 27);
            this.nudQuan.TabIndex = 29;
            this.nudQuan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(26, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 20);
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "Add ItemID to Type";
            // 
            // btnGotoOrder
            // 
            this.btnGotoOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGotoOrder.Location = new System.Drawing.Point(35, 80);
            this.btnGotoOrder.Name = "btnGotoOrder";
            this.btnGotoOrder.Size = new System.Drawing.Size(267, 43);
            this.btnGotoOrder.TabIndex = 18;
            this.btnGotoOrder.Text = "Go to Order(s)";
            this.btnGotoOrder.UseVisualStyleBackColor = true;
            this.btnGotoOrder.Click += new System.EventHandler(this.btnGotoOrder_Click_1);
            // 
            // grpOrderAndReturn
            // 
            this.grpOrderAndReturn.BackColor = System.Drawing.Color.Aqua;
            this.grpOrderAndReturn.Controls.Add(this.btnCancelOrder);
            this.grpOrderAndReturn.Controls.Add(this.btnSaveOrder);
            this.grpOrderAndReturn.Controls.Add(this.txtNotes);
            this.grpOrderAndReturn.Controls.Add(this.lblNotes);
            this.grpOrderAndReturn.Controls.Add(this.lstOrdering);
            this.grpOrderAndReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderAndReturn.Location = new System.Drawing.Point(912, 255);
            this.grpOrderAndReturn.Name = "grpOrderAndReturn";
            this.grpOrderAndReturn.Size = new System.Drawing.Size(491, 222);
            this.grpOrderAndReturn.TabIndex = 25;
            this.grpOrderAndReturn.TabStop = false;
            this.grpOrderAndReturn.Text = "Order/Return";
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.Location = new System.Drawing.Point(380, 180);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(95, 36);
            this.btnCancelOrder.TabIndex = 39;
            this.btnCancelOrder.Text = "Cancel";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOrder.Location = new System.Drawing.Point(380, 136);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(95, 36);
            this.btnSaveOrder.TabIndex = 38;
            this.btnSaveOrder.Text = "Save";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(20, 180);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(344, 27);
            this.txtNotes.TabIndex = 37;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(16, 152);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(145, 20);
            this.lblNotes.TabIndex = 36;
            this.lblNotes.Text = "Reason / Notes:";
            // 
            // lstOrdering
            // 
            this.lstOrdering.FormattingEnabled = true;
            this.lstOrdering.ItemHeight = 20;
            this.lstOrdering.Location = new System.Drawing.Point(20, 26);
            this.lstOrdering.Name = "lstOrdering";
            this.lstOrdering.Size = new System.Drawing.Size(455, 104);
            this.lstOrdering.TabIndex = 0;
            // 
            // grpConvenience
            // 
            this.grpConvenience.BackColor = System.Drawing.Color.Aqua;
            this.grpConvenience.Controls.Add(this.btnGotoOrder);
            this.grpConvenience.Controls.Add(this.btnAddall);
            this.grpConvenience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConvenience.Location = new System.Drawing.Point(1073, 706);
            this.grpConvenience.Name = "grpConvenience";
            this.grpConvenience.Size = new System.Drawing.Size(330, 143);
            this.grpConvenience.TabIndex = 26;
            this.grpConvenience.TabStop = false;
            this.grpConvenience.Text = "Convenience";
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // transactionlineTableAdapter
            // 
            this.transactionlineTableAdapter.ClearBeforeFill = true;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // transactiontypeTableAdapter
            // 
            this.transactiontypeTableAdapter.ClearBeforeFill = true;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 861);
            this.Controls.Add(this.grpConvenience);
            this.Controls.Add(this.grpOrderAndReturn);
            this.Controls.Add(this.grpAddPanel);
            this.Controls.Add(this.grpAddTo);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.grpReorder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpLocationSearch);
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventory_FormClosing);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.grpLocationSearch.ResumeLayout(false);
            this.grpLocationSearch.PerformLayout();
            this.grpReorder.ResumeLayout(false);
            this.grpReorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsInventory)).EndInit();
            this.grpAddTo.ResumeLayout(false);
            this.grpAddTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCsQuan)).EndInit();
            this.grpAddPanel.ResumeLayout(false);
            this.grpAddPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuan)).EndInit();
            this.grpOrderAndReturn.ResumeLayout(false);
            this.grpOrderAndReturn.PerformLayout();
            this.grpConvenience.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.BindingSource bdsInventory;
        private System.Windows.Forms.GroupBox grpLocationSearch;
        private System.Windows.Forms.CheckBox chkUnderThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpReorder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudReorderLevel;
        private System.Windows.Forms.NumericUpDown nudReorderThreshold;
        private System.Windows.Forms.Button btnUpdateReorder;
        private System.Windows.Forms.TextBox txtItemSku;
        private System.Windows.Forms.Label label9;
        private bullseyeDataSetTableAdapters.inventoryTableAdapter inventoryTableAdapter;
        private bullseyeDataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private bullseyeDataSetTableAdapters.transactionlineTableAdapter transactionlineTableAdapter;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblCaseSize2;
        private System.Windows.Forms.Button btnAddall;
        private bullseyeDataSetTableAdapters.locationTableAdapter locationTableAdapter;
        private System.Windows.Forms.Button btnAddto;
        private System.Windows.Forms.ComboBox cboAddtoTypes;
        private bullseyeDataSetTableAdapters.transactiontypeTableAdapter transactiontypeTableAdapter;
        private System.Windows.Forms.GroupBox grpAddTo;
        private System.Windows.Forms.GroupBox grpAddPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblcSize;
        private System.Windows.Forms.NumericUpDown nudQuan;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGotoOrder;
        private System.Windows.Forms.GroupBox grpOrderAndReturn;
        private System.Windows.Forms.GroupBox grpConvenience;
        private System.Windows.Forms.Label lblQuan;
        private System.Windows.Forms.NumericUpDown nudCsQuan;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ListBox lstOrdering;
    }
}