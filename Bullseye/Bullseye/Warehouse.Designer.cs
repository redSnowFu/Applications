namespace Bullseye
{
    partial class Warehouse
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
            this.tabWarehouse = new System.Windows.Forms.TabControl();
            this.tabItem = new System.Windows.Forms.TabPage();
            this.btnRefreshItem = new System.Windows.Forms.Button();
            this.grpChangeItem = new System.Windows.Forms.GroupBox();
            this.lblItemIDI = new System.Windows.Forms.Label();
            this.txtNotesI = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCaseSizeI = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRetailPriceI = new System.Windows.Forms.TextBox();
            this.cboSupplierNameI = new System.Windows.Forms.ComboBox();
            this.btnCancelItem = new System.Windows.Forms.Button();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.cboCategoryI = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCostPriceI = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWeightI = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSkuI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtItemNameI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescriptionI = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpAdminItem = new System.Windows.Forms.GroupBox();
            this.btnSwitchItem = new System.Windows.Forms.Button();
            this.grpSearchItems = new System.Windows.Forms.GroupBox();
            this.chkActiveItem = new System.Windows.Forms.CheckBox();
            this.txtDescriptionIF = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.txtSkuIF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemNameIF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemIDIF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSupplierNameIF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategoryIF = new System.Windows.Forms.ComboBox();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.grpManageItem = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.itemTableAdapter();
            this.itemcategoryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.itemcategoryTableAdapter();
            this.supplierTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.supplierTableAdapter();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.tabWarehouse.SuspendLayout();
            this.tabItem.SuspendLayout();
            this.grpChangeItem.SuspendLayout();
            this.grpAdminItem.SuspendLayout();
            this.grpSearchItems.SuspendLayout();
            this.grpItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.grpManageItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabWarehouse
            // 
            this.tabWarehouse.Controls.Add(this.tabItem);
            this.tabWarehouse.Location = new System.Drawing.Point(20, 76);
            this.tabWarehouse.Name = "tabWarehouse";
            this.tabWarehouse.SelectedIndex = 0;
            this.tabWarehouse.Size = new System.Drawing.Size(1381, 811);
            this.tabWarehouse.TabIndex = 0;
            this.tabWarehouse.SelectedIndexChanged += new System.EventHandler(this.tabWarehouse_SelectedIndexChanged);
            // 
            // tabItem
            // 
            this.tabItem.BackColor = System.Drawing.Color.Transparent;
            this.tabItem.Controls.Add(this.btnRefreshItem);
            this.tabItem.Controls.Add(this.grpChangeItem);
            this.tabItem.Controls.Add(this.grpAdminItem);
            this.tabItem.Controls.Add(this.grpSearchItems);
            this.tabItem.Controls.Add(this.grpItem);
            this.tabItem.Controls.Add(this.grpManageItem);
            this.tabItem.Location = new System.Drawing.Point(4, 25);
            this.tabItem.Name = "tabItem";
            this.tabItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabItem.Size = new System.Drawing.Size(1373, 782);
            this.tabItem.TabIndex = 0;
            this.tabItem.Text = "Item";
            // 
            // btnRefreshItem
            // 
            this.btnRefreshItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshItem.Location = new System.Drawing.Point(211, 155);
            this.btnRefreshItem.Name = "btnRefreshItem";
            this.btnRefreshItem.Size = new System.Drawing.Size(105, 38);
            this.btnRefreshItem.TabIndex = 20;
            this.btnRefreshItem.TabStop = false;
            this.btnRefreshItem.Text = "Refresh";
            this.btnRefreshItem.UseVisualStyleBackColor = true;
            // 
            // grpChangeItem
            // 
            this.grpChangeItem.BackColor = System.Drawing.Color.Aqua;
            this.grpChangeItem.Controls.Add(this.lblItemIDI);
            this.grpChangeItem.Controls.Add(this.txtNotesI);
            this.grpChangeItem.Controls.Add(this.label15);
            this.grpChangeItem.Controls.Add(this.txtCaseSizeI);
            this.grpChangeItem.Controls.Add(this.label16);
            this.grpChangeItem.Controls.Add(this.txtRetailPriceI);
            this.grpChangeItem.Controls.Add(this.cboSupplierNameI);
            this.grpChangeItem.Controls.Add(this.btnCancelItem);
            this.grpChangeItem.Controls.Add(this.btnSaveItem);
            this.grpChangeItem.Controls.Add(this.cboCategoryI);
            this.grpChangeItem.Controls.Add(this.label14);
            this.grpChangeItem.Controls.Add(this.label13);
            this.grpChangeItem.Controls.Add(this.txtCostPriceI);
            this.grpChangeItem.Controls.Add(this.label12);
            this.grpChangeItem.Controls.Add(this.txtWeightI);
            this.grpChangeItem.Controls.Add(this.label11);
            this.grpChangeItem.Controls.Add(this.label10);
            this.grpChangeItem.Controls.Add(this.txtSkuI);
            this.grpChangeItem.Controls.Add(this.label9);
            this.grpChangeItem.Controls.Add(this.txtItemNameI);
            this.grpChangeItem.Controls.Add(this.label8);
            this.grpChangeItem.Controls.Add(this.txtDescriptionI);
            this.grpChangeItem.Controls.Add(this.label7);
            this.grpChangeItem.Controls.Add(this.label6);
            this.grpChangeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChangeItem.Location = new System.Drawing.Point(27, 542);
            this.grpChangeItem.Name = "grpChangeItem";
            this.grpChangeItem.Size = new System.Drawing.Size(1328, 225);
            this.grpChangeItem.TabIndex = 4;
            this.grpChangeItem.TabStop = false;
            this.grpChangeItem.Text = "Change";
            // 
            // lblItemIDI
            // 
            this.lblItemIDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemIDI.Location = new System.Drawing.Point(132, 27);
            this.lblItemIDI.Name = "lblItemIDI";
            this.lblItemIDI.Size = new System.Drawing.Size(105, 27);
            this.lblItemIDI.TabIndex = 31;
            // 
            // txtNotesI
            // 
            this.txtNotesI.Location = new System.Drawing.Point(427, 162);
            this.txtNotesI.Name = "txtNotesI";
            this.txtNotesI.Size = new System.Drawing.Size(166, 27);
            this.txtNotesI.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(319, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 20);
            this.label15.TabIndex = 22;
            this.label15.Text = "Notes:";
            // 
            // txtCaseSizeI
            // 
            this.txtCaseSizeI.Location = new System.Drawing.Point(164, 162);
            this.txtCaseSizeI.Name = "txtCaseSizeI";
            this.txtCaseSizeI.Size = new System.Drawing.Size(105, 27);
            this.txtCaseSizeI.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = "Case Size:";
            // 
            // txtRetailPriceI
            // 
            this.txtRetailPriceI.Location = new System.Drawing.Point(539, 118);
            this.txtRetailPriceI.Name = "txtRetailPriceI";
            this.txtRetailPriceI.Size = new System.Drawing.Size(157, 27);
            this.txtRetailPriceI.TabIndex = 6;
            // 
            // cboSupplierNameI
            // 
            this.cboSupplierNameI.FormattingEnabled = true;
            this.cboSupplierNameI.Location = new System.Drawing.Point(946, 118);
            this.cboSupplierNameI.Name = "cboSupplierNameI";
            this.cboSupplierNameI.Size = new System.Drawing.Size(171, 28);
            this.cboSupplierNameI.TabIndex = 7;
            // 
            // btnCancelItem
            // 
            this.btnCancelItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelItem.Location = new System.Drawing.Point(1128, 165);
            this.btnCancelItem.Name = "btnCancelItem";
            this.btnCancelItem.Size = new System.Drawing.Size(105, 38);
            this.btnCancelItem.TabIndex = 11;
            this.btnCancelItem.Text = "Cancel";
            this.btnCancelItem.UseVisualStyleBackColor = true;
            this.btnCancelItem.Click += new System.EventHandler(this.btnCancelItem_Click);
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveItem.Location = new System.Drawing.Point(955, 165);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(105, 38);
            this.btnSaveItem.TabIndex = 10;
            this.btnSaveItem.Text = "Save";
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // cboCategoryI
            // 
            this.cboCategoryI.FormattingEnabled = true;
            this.cboCategoryI.Location = new System.Drawing.Point(767, 71);
            this.cboCategoryI.Name = "cboCategoryI";
            this.cboCategoryI.Size = new System.Drawing.Size(242, 28);
            this.cboCategoryI.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(646, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 20);
            this.label14.TabIndex = 16;
            this.label14.Text = "Category:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(783, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Supplier:";
            // 
            // txtCostPriceI
            // 
            this.txtCostPriceI.Location = new System.Drawing.Point(164, 115);
            this.txtCostPriceI.Name = "txtCostPriceI";
            this.txtCostPriceI.Size = new System.Drawing.Size(106, 27);
            this.txtCostPriceI.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Cost Price:";
            // 
            // txtWeightI
            // 
            this.txtWeightI.Location = new System.Drawing.Point(1188, 73);
            this.txtWeightI.Name = "txtWeightI";
            this.txtWeightI.Size = new System.Drawing.Size(99, 27);
            this.txtWeightI.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1069, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Weight:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(362, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Retail Price:";
            // 
            // txtSkuI
            // 
            this.txtSkuI.Location = new System.Drawing.Point(956, 25);
            this.txtSkuI.Name = "txtSkuI";
            this.txtSkuI.Size = new System.Drawing.Size(157, 27);
            this.txtSkuI.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(881, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "sku:";
            // 
            // txtItemNameI
            // 
            this.txtItemNameI.Location = new System.Drawing.Point(445, 27);
            this.txtItemNameI.Name = "txtItemNameI";
            this.txtItemNameI.Size = new System.Drawing.Size(345, 27);
            this.txtItemNameI.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Item Name:";
            // 
            // txtDescriptionI
            // 
            this.txtDescriptionI.Location = new System.Drawing.Point(211, 70);
            this.txtDescriptionI.Name = "txtDescriptionI";
            this.txtDescriptionI.Size = new System.Drawing.Size(350, 27);
            this.txtDescriptionI.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Item ID:";
            // 
            // grpAdminItem
            // 
            this.grpAdminItem.BackColor = System.Drawing.Color.Aqua;
            this.grpAdminItem.Controls.Add(this.btnSwitchItem);
            this.grpAdminItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdminItem.Location = new System.Drawing.Point(27, 124);
            this.grpAdminItem.Name = "grpAdminItem";
            this.grpAdminItem.Size = new System.Drawing.Size(152, 92);
            this.grpAdminItem.TabIndex = 1;
            this.grpAdminItem.TabStop = false;
            this.grpAdminItem.Text = "Admin";
            // 
            // btnSwitchItem
            // 
            this.btnSwitchItem.Location = new System.Drawing.Point(27, 31);
            this.btnSwitchItem.Name = "btnSwitchItem";
            this.btnSwitchItem.Size = new System.Drawing.Size(105, 38);
            this.btnSwitchItem.TabIndex = 0;
            this.btnSwitchItem.Text = "Switch";
            this.btnSwitchItem.UseVisualStyleBackColor = true;
            this.btnSwitchItem.Click += new System.EventHandler(this.btnSwitchItem_Click);
            // 
            // grpSearchItems
            // 
            this.grpSearchItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grpSearchItems.Controls.Add(this.chkActiveItem);
            this.grpSearchItems.Controls.Add(this.txtDescriptionIF);
            this.grpSearchItems.Controls.Add(this.label17);
            this.grpSearchItems.Controls.Add(this.btnSearchItem);
            this.grpSearchItems.Controls.Add(this.txtSkuIF);
            this.grpSearchItems.Controls.Add(this.label3);
            this.grpSearchItems.Controls.Add(this.txtItemNameIF);
            this.grpSearchItems.Controls.Add(this.label2);
            this.grpSearchItems.Controls.Add(this.txtItemIDIF);
            this.grpSearchItems.Controls.Add(this.label1);
            this.grpSearchItems.Controls.Add(this.label5);
            this.grpSearchItems.Controls.Add(this.cboSupplierNameIF);
            this.grpSearchItems.Controls.Add(this.label4);
            this.grpSearchItems.Controls.Add(this.cboCategoryIF);
            this.grpSearchItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchItems.Location = new System.Drawing.Point(393, 15);
            this.grpSearchItems.Name = "grpSearchItems";
            this.grpSearchItems.Size = new System.Drawing.Size(962, 211);
            this.grpSearchItems.TabIndex = 3;
            this.grpSearchItems.TabStop = false;
            this.grpSearchItems.Text = "Search";
            // 
            // chkActiveItem
            // 
            this.chkActiveItem.AutoSize = true;
            this.chkActiveItem.Location = new System.Drawing.Point(31, 167);
            this.chkActiveItem.Name = "chkActiveItem";
            this.chkActiveItem.Size = new System.Drawing.Size(93, 24);
            this.chkActiveItem.TabIndex = 13;
            this.chkActiveItem.Text = "Active?";
            this.chkActiveItem.UseVisualStyleBackColor = true;
            // 
            // txtDescriptionIF
            // 
            this.txtDescriptionIF.Location = new System.Drawing.Point(192, 125);
            this.txtDescriptionIF.Name = "txtDescriptionIF";
            this.txtDescriptionIF.Size = new System.Drawing.Size(493, 27);
            this.txtDescriptionIF.TabIndex = 11;
            this.txtDescriptionIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescriptionIF_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 20);
            this.label17.TabIndex = 12;
            this.label17.Text = "Description:";
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItem.Location = new System.Drawing.Point(742, 140);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(105, 38);
            this.btnSearchItem.TabIndex = 5;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // txtSkuIF
            // 
            this.txtSkuIF.Location = new System.Drawing.Point(387, 37);
            this.txtSkuIF.Name = "txtSkuIF";
            this.txtSkuIF.Size = new System.Drawing.Size(100, 27);
            this.txtSkuIF.TabIndex = 1;
            this.txtSkuIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSkuIF_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "sku:";
            // 
            // txtItemNameIF
            // 
            this.txtItemNameIF.Location = new System.Drawing.Point(192, 79);
            this.txtItemNameIF.Name = "txtItemNameIF";
            this.txtItemNameIF.Size = new System.Drawing.Size(349, 27);
            this.txtItemNameIF.TabIndex = 2;
            this.txtItemNameIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemNameIF_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item Name:";
            // 
            // txtItemIDIF
            // 
            this.txtItemIDIF.Location = new System.Drawing.Point(145, 37);
            this.txtItemIDIF.Name = "txtItemIDIF";
            this.txtItemIDIF.Size = new System.Drawing.Size(100, 27);
            this.txtItemIDIF.TabIndex = 0;
            this.txtItemIDIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemIDIF_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Supplier:";
            // 
            // cboSupplierNameIF
            // 
            this.cboSupplierNameIF.FormattingEnabled = true;
            this.cboSupplierNameIF.Location = new System.Drawing.Point(742, 79);
            this.cboSupplierNameIF.Name = "cboSupplierNameIF";
            this.cboSupplierNameIF.Size = new System.Drawing.Size(134, 28);
            this.cboSupplierNameIF.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category:";
            // 
            // cboCategoryIF
            // 
            this.cboCategoryIF.FormattingEnabled = true;
            this.cboCategoryIF.Location = new System.Drawing.Point(742, 34);
            this.cboCategoryIF.Name = "cboCategoryIF";
            this.cboCategoryIF.Size = new System.Drawing.Size(203, 28);
            this.cboCategoryIF.TabIndex = 3;
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.dgvItem);
            this.grpItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpItem.Location = new System.Drawing.Point(27, 243);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(1328, 293);
            this.grpItem.TabIndex = 19;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "Item";
            // 
            // dgvItem
            // 
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Location = new System.Drawing.Point(16, 26);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(1295, 250);
            this.dgvItem.TabIndex = 0;
            // 
            // grpManageItem
            // 
            this.grpManageItem.BackColor = System.Drawing.Color.Aqua;
            this.grpManageItem.Controls.Add(this.btnAddItem);
            this.grpManageItem.Controls.Add(this.btnEditItem);
            this.grpManageItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpManageItem.Location = new System.Drawing.Point(27, 15);
            this.grpManageItem.Name = "grpManageItem";
            this.grpManageItem.Size = new System.Drawing.Size(312, 92);
            this.grpManageItem.TabIndex = 0;
            this.grpManageItem.TabStop = false;
            this.grpManageItem.Text = "Manage";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(23, 31);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(105, 38);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.Location = new System.Drawing.Point(184, 31);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(105, 38);
            this.btnEditItem.TabIndex = 1;
            this.btnEditItem.Text = "Edit";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // itemcategoryTableAdapter
            // 
            this.itemcategoryTableAdapter.ClearBeforeFill = true;
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(24, 13);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(1373, 60);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 899);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.tabWarehouse);
            this.Name = "Warehouse";
            this.Text = "Warehouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Warehouse_FormClosing);
            this.Load += new System.EventHandler(this.Warehouse_Load);
            this.tabWarehouse.ResumeLayout(false);
            this.tabItem.ResumeLayout(false);
            this.grpChangeItem.ResumeLayout(false);
            this.grpChangeItem.PerformLayout();
            this.grpAdminItem.ResumeLayout(false);
            this.grpSearchItems.ResumeLayout(false);
            this.grpSearchItems.PerformLayout();
            this.grpItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.grpManageItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabWarehouse;
        private System.Windows.Forms.TabPage tabItem;
        private System.Windows.Forms.GroupBox grpAdminItem;
        private System.Windows.Forms.Button btnSwitchItem;
        private System.Windows.Forms.GroupBox grpSearchItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSupplierNameIF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCategoryIF;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.GroupBox grpManageItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.TextBox txtSkuIF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemNameIF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemIDIF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpChangeItem;
        private System.Windows.Forms.ComboBox cboSupplierNameI;
        private System.Windows.Forms.Button btnCancelItem;
        private System.Windows.Forms.Button btnSaveItem;
        private System.Windows.Forms.ComboBox cboCategoryI;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCostPriceI;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWeightI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSkuI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtItemNameI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescriptionI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.TextBox txtNotesI;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCaseSizeI;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRetailPriceI;
        private bullseyeDataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private bullseyeDataSetTableAdapters.itemcategoryTableAdapter itemcategoryTableAdapter;
        private bullseyeDataSetTableAdapters.supplierTableAdapter supplierTableAdapter;
        private System.Windows.Forms.Label lblItemIDI;
        private System.Windows.Forms.TextBox txtDescriptionIF;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkActiveItem;
        private System.Windows.Forms.Button btnRefreshItem;
        private System.Windows.Forms.Label lblUserInfo;
    }
}