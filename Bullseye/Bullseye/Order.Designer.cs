namespace Bullseye
{
    partial class Order
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
            this.tabOrder = new System.Windows.Forms.TabControl();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.btnCancelBO = new System.Windows.Forms.Button();
            this.btnConfrimReturn = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.btnCreateE = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.grpSearchOrders = new System.Windows.Forms.GroupBox();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mTxtToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mTxtFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTypeOF = new System.Windows.Forms.ComboBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStatusOF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLocationIDOF = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.cboUpdateStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabDeliveries = new System.Windows.Forms.TabPage();
            this.grpSearchDLF = new System.Windows.Forms.GroupBox();
            this.mtxtEndDLF = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mtxtStartDLF = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearchDLF = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cboStatusDLF = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboLocDLF = new System.Windows.Forms.ComboBox();
            this.btnRefreshDeliveries = new System.Windows.Forms.Button();
            this.btnReceiveStore = new System.Windows.Forms.Button();
            this.btnConfirmDel = new System.Windows.Forms.Button();
            this.btnLoadOrder = new System.Windows.Forms.Button();
            this.dgvDeliveries = new System.Windows.Forms.DataGridView();
            this.grpProcessReturn = new System.Windows.Forms.GroupBox();
            this.cboProcessReturn = new System.Windows.Forms.ComboBox();
            this.btnReceiveReturn = new System.Windows.Forms.Button();
            this.btnProcessReturn = new System.Windows.Forms.Button();
            this.bdsOrders = new System.Windows.Forms.BindingSource(this.components);
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.bdsDeliveries = new System.Windows.Forms.BindingSource(this.components);
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.transactiontypeTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactiontypeTableAdapter();
            this.transactionstatusTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionstatusTableAdapter();
            this.locationTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.locationTableAdapter();
            this.transactionlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionlineTableAdapter();
            this.inventoryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.inventoryTableAdapter();
            this.deliveryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.deliveryTableAdapter();
            this.deliverytransactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.deliverytransactionTableAdapter();
            this.courierTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.courierTableAdapter();
            this.tabOrder.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.grpCreate.SuspendLayout();
            this.grpSearchOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpUpdate.SuspendLayout();
            this.tabDeliveries.SuspendLayout();
            this.grpSearchDLF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveries)).BeginInit();
            this.grpProcessReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.tabOrders);
            this.tabOrder.Controls.Add(this.tabDeliveries);
            this.tabOrder.Location = new System.Drawing.Point(12, 72);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.SelectedIndex = 0;
            this.tabOrder.Size = new System.Drawing.Size(1269, 671);
            this.tabOrder.TabIndex = 0;
            this.tabOrder.SelectedIndexChanged += new System.EventHandler(this.tabOrder_SelectedIndexChanged);
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.btnCancelBO);
            this.tabOrders.Controls.Add(this.btnConfrimReturn);
            this.tabOrders.Controls.Add(this.btnRefresh);
            this.tabOrders.Controls.Add(this.grpCreate);
            this.tabOrders.Controls.Add(this.grpSearchOrders);
            this.tabOrders.Controls.Add(this.btnScan);
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Controls.Add(this.btnView);
            this.tabOrders.Controls.Add(this.grpUpdate);
            this.tabOrders.Location = new System.Drawing.Point(4, 25);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(1261, 642);
            this.tabOrders.TabIndex = 0;
            this.tabOrders.Text = "Orders";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // btnCancelBO
            // 
            this.btnCancelBO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBO.Location = new System.Drawing.Point(376, 165);
            this.btnCancelBO.Name = "btnCancelBO";
            this.btnCancelBO.Size = new System.Drawing.Size(188, 38);
            this.btnCancelBO.TabIndex = 38;
            this.btnCancelBO.Text = "Cancel Back Order";
            this.btnCancelBO.UseVisualStyleBackColor = true;
            this.btnCancelBO.Click += new System.EventHandler(this.btnCancelBO_Click);
            // 
            // btnConfrimReturn
            // 
            this.btnConfrimReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfrimReturn.Location = new System.Drawing.Point(374, 69);
            this.btnConfrimReturn.Name = "btnConfrimReturn";
            this.btnConfrimReturn.Size = new System.Drawing.Size(190, 38);
            this.btnConfrimReturn.TabIndex = 37;
            this.btnConfrimReturn.Text = "Confirm Return";
            this.btnConfrimReturn.UseVisualStyleBackColor = true;
            this.btnConfrimReturn.Click += new System.EventHandler(this.btnConfrimReturn_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(410, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 38);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpCreate
            // 
            this.grpCreate.BackColor = System.Drawing.Color.Aqua;
            this.grpCreate.Controls.Add(this.btnCreateE);
            this.grpCreate.Controls.Add(this.btnAddOrder);
            this.grpCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCreate.Location = new System.Drawing.Point(25, 36);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(345, 81);
            this.grpCreate.TabIndex = 35;
            this.grpCreate.TabStop = false;
            this.grpCreate.Text = "Create";
            // 
            // btnCreateE
            // 
            this.btnCreateE.BackColor = System.Drawing.Color.Red;
            this.btnCreateE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateE.Location = new System.Drawing.Point(6, 32);
            this.btnCreateE.Name = "btnCreateE";
            this.btnCreateE.Size = new System.Drawing.Size(159, 38);
            this.btnCreateE.TabIndex = 37;
            this.btnCreateE.Text = "Create E Order";
            this.btnCreateE.UseVisualStyleBackColor = false;
            this.btnCreateE.Click += new System.EventHandler(this.btnCreateE_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(175, 32);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(159, 38);
            this.btnAddOrder.TabIndex = 33;
            this.btnAddOrder.Text = "Create Orders";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // grpSearchOrders
            // 
            this.grpSearchOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grpSearchOrders.Controls.Add(this.txtTransactionID);
            this.grpSearchOrders.Controls.Add(this.label6);
            this.grpSearchOrders.Controls.Add(this.mTxtToDate);
            this.grpSearchOrders.Controls.Add(this.label3);
            this.grpSearchOrders.Controls.Add(this.mTxtFromDate);
            this.grpSearchOrders.Controls.Add(this.label2);
            this.grpSearchOrders.Controls.Add(this.label1);
            this.grpSearchOrders.Controls.Add(this.cboTypeOF);
            this.grpSearchOrders.Controls.Add(this.btnSearchItem);
            this.grpSearchOrders.Controls.Add(this.label5);
            this.grpSearchOrders.Controls.Add(this.cboStatusOF);
            this.grpSearchOrders.Controls.Add(this.label4);
            this.grpSearchOrders.Controls.Add(this.cboLocationIDOF);
            this.grpSearchOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchOrders.Location = new System.Drawing.Point(587, 25);
            this.grpSearchOrders.Name = "grpSearchOrders";
            this.grpSearchOrders.Size = new System.Drawing.Size(650, 222);
            this.grpSearchOrders.TabIndex = 30;
            this.grpSearchOrders.TabStop = false;
            this.grpSearchOrders.Text = "Search";
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Location = new System.Drawing.Point(194, 26);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(130, 27);
            this.txtTransactionID.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Transaction ID:";
            // 
            // mTxtToDate
            // 
            this.mTxtToDate.Location = new System.Drawing.Point(269, 177);
            this.mTxtToDate.Mask = "00/00/0000";
            this.mTxtToDate.Name = "mTxtToDate";
            this.mTxtToDate.Size = new System.Drawing.Size(116, 27);
            this.mTxtToDate.TabIndex = 15;
            this.mTxtToDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "To";
            // 
            // mTxtFromDate
            // 
            this.mTxtFromDate.Location = new System.Drawing.Point(85, 177);
            this.mTxtFromDate.Mask = "00/00/0000";
            this.mTxtFromDate.Name = "mTxtFromDate";
            this.mTxtFromDate.Size = new System.Drawing.Size(116, 27);
            this.mTxtFromDate.TabIndex = 13;
            this.mTxtFromDate.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Type:";
            // 
            // cboTypeOF
            // 
            this.cboTypeOF.FormattingEnabled = true;
            this.cboTypeOF.Location = new System.Drawing.Point(485, 25);
            this.cboTypeOF.Name = "cboTypeOF";
            this.cboTypeOF.Size = new System.Drawing.Size(150, 28);
            this.cboTypeOF.TabIndex = 10;
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItem.Location = new System.Drawing.Point(530, 171);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(105, 38);
            this.btnSearchItem.TabIndex = 5;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status:";
            // 
            // cboStatusOF
            // 
            this.cboStatusOF.FormattingEnabled = true;
            this.cboStatusOF.Location = new System.Drawing.Point(485, 102);
            this.cboStatusOF.Name = "cboStatusOF";
            this.cboStatusOF.Size = new System.Drawing.Size(150, 28);
            this.cboStatusOF.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Location:";
            // 
            // cboLocationIDOF
            // 
            this.cboLocationIDOF.FormattingEnabled = true;
            this.cboLocationIDOF.Location = new System.Drawing.Point(144, 102);
            this.cboLocationIDOF.Name = "cboLocationIDOF";
            this.cboLocationIDOF.Size = new System.Drawing.Size(145, 28);
            this.cboLocationIDOF.TabIndex = 3;
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(410, 117);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(124, 38);
            this.btnScan.TabIndex = 36;
            this.btnScan.Text = "Scan items";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(25, 268);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1214, 354);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(410, 209);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(124, 38);
            this.btnView.TabIndex = 33;
            this.btnView.Text = "View Detail";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // grpUpdate
            // 
            this.grpUpdate.BackColor = System.Drawing.Color.Aqua;
            this.grpUpdate.Controls.Add(this.cboUpdateStatus);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUpdate.Location = new System.Drawing.Point(25, 160);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(345, 87);
            this.grpUpdate.TabIndex = 34;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Update";
            // 
            // cboUpdateStatus
            // 
            this.cboUpdateStatus.FormattingEnabled = true;
            this.cboUpdateStatus.Location = new System.Drawing.Point(15, 36);
            this.cboUpdateStatus.Name = "cboUpdateStatus";
            this.cboUpdateStatus.Size = new System.Drawing.Size(150, 28);
            this.cboUpdateStatus.TabIndex = 31;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(175, 33);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(159, 38);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "Update Status";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tabDeliveries
            // 
            this.tabDeliveries.Controls.Add(this.grpSearchDLF);
            this.tabDeliveries.Controls.Add(this.btnRefreshDeliveries);
            this.tabDeliveries.Controls.Add(this.btnReceiveStore);
            this.tabDeliveries.Controls.Add(this.btnConfirmDel);
            this.tabDeliveries.Controls.Add(this.btnLoadOrder);
            this.tabDeliveries.Controls.Add(this.dgvDeliveries);
            this.tabDeliveries.Controls.Add(this.grpProcessReturn);
            this.tabDeliveries.Location = new System.Drawing.Point(4, 25);
            this.tabDeliveries.Name = "tabDeliveries";
            this.tabDeliveries.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeliveries.Size = new System.Drawing.Size(1261, 642);
            this.tabDeliveries.TabIndex = 1;
            this.tabDeliveries.Text = "Deliveries";
            this.tabDeliveries.UseVisualStyleBackColor = true;
            // 
            // grpSearchDLF
            // 
            this.grpSearchDLF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grpSearchDLF.Controls.Add(this.mtxtEndDLF);
            this.grpSearchDLF.Controls.Add(this.label8);
            this.grpSearchDLF.Controls.Add(this.mtxtStartDLF);
            this.grpSearchDLF.Controls.Add(this.label9);
            this.grpSearchDLF.Controls.Add(this.btnSearchDLF);
            this.grpSearchDLF.Controls.Add(this.label11);
            this.grpSearchDLF.Controls.Add(this.cboStatusDLF);
            this.grpSearchDLF.Controls.Add(this.label12);
            this.grpSearchDLF.Controls.Add(this.cboLocDLF);
            this.grpSearchDLF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchDLF.Location = new System.Drawing.Point(18, 24);
            this.grpSearchDLF.Name = "grpSearchDLF";
            this.grpSearchDLF.Size = new System.Drawing.Size(725, 135);
            this.grpSearchDLF.TabIndex = 44;
            this.grpSearchDLF.TabStop = false;
            this.grpSearchDLF.Text = "Search";
            // 
            // mtxtEndDLF
            // 
            this.mtxtEndDLF.Location = new System.Drawing.Point(584, 27);
            this.mtxtEndDLF.Mask = "00/00/0000";
            this.mtxtEndDLF.Name = "mtxtEndDLF";
            this.mtxtEndDLF.Size = new System.Drawing.Size(116, 27);
            this.mtxtEndDLF.TabIndex = 15;
            this.mtxtEndDLF.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(533, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "End";
            // 
            // mtxtStartDLF
            // 
            this.mtxtStartDLF.Location = new System.Drawing.Point(400, 27);
            this.mtxtStartDLF.Mask = "00/00/0000";
            this.mtxtStartDLF.Name = "mtxtStartDLF";
            this.mtxtStartDLF.Size = new System.Drawing.Size(116, 27);
            this.mtxtStartDLF.TabIndex = 13;
            this.mtxtStartDLF.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Start";
            // 
            // btnSearchDLF
            // 
            this.btnSearchDLF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDLF.Location = new System.Drawing.Point(595, 78);
            this.btnSearchDLF.Name = "btnSearchDLF";
            this.btnSearchDLF.Size = new System.Drawing.Size(105, 38);
            this.btnSearchDLF.TabIndex = 5;
            this.btnSearchDLF.Text = "Search";
            this.btnSearchDLF.UseVisualStyleBackColor = true;
            this.btnSearchDLF.Click += new System.EventHandler(this.btnSearchDLF_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Status:";
            // 
            // cboStatusDLF
            // 
            this.cboStatusDLF.FormattingEnabled = true;
            this.cboStatusDLF.Location = new System.Drawing.Point(144, 84);
            this.cboStatusDLF.Name = "cboStatusDLF";
            this.cboStatusDLF.Size = new System.Drawing.Size(150, 28);
            this.cboStatusDLF.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Location:";
            // 
            // cboLocDLF
            // 
            this.cboLocDLF.FormattingEnabled = true;
            this.cboLocDLF.Location = new System.Drawing.Point(144, 26);
            this.cboLocDLF.Name = "cboLocDLF";
            this.cboLocDLF.Size = new System.Drawing.Size(145, 28);
            this.cboLocDLF.TabIndex = 3;
            // 
            // btnRefreshDeliveries
            // 
            this.btnRefreshDeliveries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDeliveries.Location = new System.Drawing.Point(619, 181);
            this.btnRefreshDeliveries.Name = "btnRefreshDeliveries";
            this.btnRefreshDeliveries.Size = new System.Drawing.Size(124, 38);
            this.btnRefreshDeliveries.TabIndex = 43;
            this.btnRefreshDeliveries.Text = "Refresh";
            this.btnRefreshDeliveries.UseVisualStyleBackColor = true;
            this.btnRefreshDeliveries.Click += new System.EventHandler(this.btnRefreshDeliveries_Click);
            // 
            // btnReceiveStore
            // 
            this.btnReceiveStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveStore.Location = new System.Drawing.Point(418, 181);
            this.btnReceiveStore.Name = "btnReceiveStore";
            this.btnReceiveStore.Size = new System.Drawing.Size(185, 38);
            this.btnReceiveStore.TabIndex = 42;
            this.btnReceiveStore.Text = "Receive at Store";
            this.btnReceiveStore.UseVisualStyleBackColor = true;
            this.btnReceiveStore.Click += new System.EventHandler(this.btnReceiveStore_Click);
            // 
            // btnConfirmDel
            // 
            this.btnConfirmDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmDel.Location = new System.Drawing.Point(200, 181);
            this.btnConfirmDel.Name = "btnConfirmDel";
            this.btnConfirmDel.Size = new System.Drawing.Size(194, 38);
            this.btnConfirmDel.TabIndex = 41;
            this.btnConfirmDel.Text = "Confirm delivery";
            this.btnConfirmDel.UseVisualStyleBackColor = true;
            this.btnConfirmDel.Click += new System.EventHandler(this.btnConfirmDel_Click);
            // 
            // btnLoadOrder
            // 
            this.btnLoadOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadOrder.Location = new System.Drawing.Point(18, 181);
            this.btnLoadOrder.Name = "btnLoadOrder";
            this.btnLoadOrder.Size = new System.Drawing.Size(159, 38);
            this.btnLoadOrder.TabIndex = 40;
            this.btnLoadOrder.Text = "Load to Truck";
            this.btnLoadOrder.UseVisualStyleBackColor = true;
            this.btnLoadOrder.Click += new System.EventHandler(this.btnLoadOrder_Click);
            // 
            // dgvDeliveries
            // 
            this.dgvDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveries.Location = new System.Drawing.Point(18, 246);
            this.dgvDeliveries.Name = "dgvDeliveries";
            this.dgvDeliveries.RowTemplate.Height = 24;
            this.dgvDeliveries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliveries.Size = new System.Drawing.Size(1223, 373);
            this.dgvDeliveries.TabIndex = 0;
            this.dgvDeliveries.SelectionChanged += new System.EventHandler(this.dgvDeliveries_SelectionChanged);
            // 
            // grpProcessReturn
            // 
            this.grpProcessReturn.BackColor = System.Drawing.Color.Aqua;
            this.grpProcessReturn.Controls.Add(this.cboProcessReturn);
            this.grpProcessReturn.Controls.Add(this.btnReceiveReturn);
            this.grpProcessReturn.Controls.Add(this.btnProcessReturn);
            this.grpProcessReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProcessReturn.Location = new System.Drawing.Point(1041, 24);
            this.grpProcessReturn.Name = "grpProcessReturn";
            this.grpProcessReturn.Size = new System.Drawing.Size(200, 195);
            this.grpProcessReturn.TabIndex = 48;
            this.grpProcessReturn.TabStop = false;
            this.grpProcessReturn.Text = "Process Return";
            // 
            // cboProcessReturn
            // 
            this.cboProcessReturn.FormattingEnabled = true;
            this.cboProcessReturn.Location = new System.Drawing.Point(21, 157);
            this.cboProcessReturn.Name = "cboProcessReturn";
            this.cboProcessReturn.Size = new System.Drawing.Size(159, 28);
            this.cboProcessReturn.TabIndex = 47;
            // 
            // btnReceiveReturn
            // 
            this.btnReceiveReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveReturn.Location = new System.Drawing.Point(21, 27);
            this.btnReceiveReturn.Name = "btnReceiveReturn";
            this.btnReceiveReturn.Size = new System.Drawing.Size(159, 38);
            this.btnReceiveReturn.TabIndex = 45;
            this.btnReceiveReturn.Text = "Receive Return";
            this.btnReceiveReturn.UseVisualStyleBackColor = true;
            this.btnReceiveReturn.Click += new System.EventHandler(this.btnReceiveReturn_Click);
            // 
            // btnProcessReturn
            // 
            this.btnProcessReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessReturn.Location = new System.Drawing.Point(35, 84);
            this.btnProcessReturn.Name = "btnProcessReturn";
            this.btnProcessReturn.Size = new System.Drawing.Size(134, 61);
            this.btnProcessReturn.TabIndex = 46;
            this.btnProcessReturn.Text = "Process Return by";
            this.btnProcessReturn.UseVisualStyleBackColor = true;
            this.btnProcessReturn.Click += new System.EventHandler(this.btnProcessReturn_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(12, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(1265, 60);
            this.lblUserInfo.TabIndex = 20;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // transactiontypeTableAdapter
            // 
            this.transactiontypeTableAdapter.ClearBeforeFill = true;
            // 
            // transactionstatusTableAdapter
            // 
            this.transactionstatusTableAdapter.ClearBeforeFill = true;
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // transactionlineTableAdapter
            // 
            this.transactionlineTableAdapter.ClearBeforeFill = true;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // deliveryTableAdapter
            // 
            this.deliveryTableAdapter.ClearBeforeFill = true;
            // 
            // deliverytransactionTableAdapter
            // 
            this.deliverytransactionTableAdapter.ClearBeforeFill = true;
            // 
            // courierTableAdapter
            // 
            this.courierTableAdapter.ClearBeforeFill = true;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 755);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.tabOrder);
            this.Name = "Order";
            this.Text = "Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Order_FormClosing);
            this.Load += new System.EventHandler(this.Order_Load);
            this.tabOrder.ResumeLayout(false);
            this.tabOrders.ResumeLayout(false);
            this.grpCreate.ResumeLayout(false);
            this.grpSearchOrders.ResumeLayout(false);
            this.grpSearchOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.grpUpdate.ResumeLayout(false);
            this.tabDeliveries.ResumeLayout(false);
            this.grpSearchDLF.ResumeLayout(false);
            this.grpSearchDLF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveries)).EndInit();
            this.grpProcessReturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeliveries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOrder;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabDeliveries;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.BindingSource bdsOrders;
        private System.Windows.Forms.GroupBox grpSearchOrders;
        private System.Windows.Forms.MaskedTextBox mTxtToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mTxtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTypeOF;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStatusOF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLocationIDOF;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private System.Windows.Forms.TextBox txtTransactionID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.ComboBox cboUpdateStatus;
        private System.Windows.Forms.Button btnUpdate;
        private bullseyeDataSetTableAdapters.transactiontypeTableAdapter transactiontypeTableAdapter;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.GroupBox grpCreate;
        private bullseyeDataSetTableAdapters.transactionstatusTableAdapter transactionstatusTableAdapter;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnCreateE;
        private bullseyeDataSetTableAdapters.locationTableAdapter locationTableAdapter;
        private System.Windows.Forms.Button btnRefresh;
        private bullseyeDataSetTableAdapters.transactionlineTableAdapter transactionlineTableAdapter;
        private bullseyeDataSetTableAdapters.inventoryTableAdapter inventoryTableAdapter;
        private bullseyeDataSetTableAdapters.deliveryTableAdapter deliveryTableAdapter;
        private System.Windows.Forms.DataGridView dgvDeliveries;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.BindingSource bdsDeliveries;
        private System.Windows.Forms.Button btnReceiveStore;
        private System.Windows.Forms.Button btnConfirmDel;
        private System.Windows.Forms.Button btnLoadOrder;
        private System.Windows.Forms.Button btnRefreshDeliveries;
        private System.Windows.Forms.GroupBox grpSearchDLF;
        private System.Windows.Forms.MaskedTextBox mtxtEndDLF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtxtStartDLF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearchDLF;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboStatusDLF;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboLocDLF;
        private System.Windows.Forms.Button btnConfrimReturn;
        private bullseyeDataSetTableAdapters.deliverytransactionTableAdapter deliverytransactionTableAdapter;
        private bullseyeDataSetTableAdapters.courierTableAdapter courierTableAdapter;
        private System.Windows.Forms.Button btnReceiveReturn;
        private System.Windows.Forms.ComboBox cboProcessReturn;
        private System.Windows.Forms.Button btnProcessReturn;
        private System.Windows.Forms.GroupBox grpProcessReturn;
        private System.Windows.Forms.Button btnCancelBO;
    }
}