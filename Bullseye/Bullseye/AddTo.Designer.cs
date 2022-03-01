namespace Bullseye
{
    partial class AddTo
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.nudQuan = new System.Windows.Forms.NumericUpDown();
            this.lblCaseSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnConfrim = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.inventoryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.inventoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(52, 46);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 20);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Add ItemID to Type";
            // 
            // nudQuan
            // 
            this.nudQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuan.Location = new System.Drawing.Point(164, 99);
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
            this.nudQuan.TabIndex = 16;
            this.nudQuan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCaseSize
            // 
            this.lblCaseSize.AutoSize = true;
            this.lblCaseSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseSize.Location = new System.Drawing.Point(262, 99);
            this.lblCaseSize.Name = "lblCaseSize";
            this.lblCaseSize.Size = new System.Drawing.Size(102, 20);
            this.lblCaseSize.TabIndex = 22;
            this.lblCaseSize.Text = "* CaseSize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Reason / Notes:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(56, 206);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(368, 22);
            this.txtReason.TabIndex = 25;
            // 
            // btnConfrim
            // 
            this.btnConfrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfrim.Location = new System.Drawing.Point(73, 260);
            this.btnConfrim.Name = "btnConfrim";
            this.btnConfrim.Size = new System.Drawing.Size(95, 36);
            this.btnConfrim.TabIndex = 26;
            this.btnConfrim.Text = "OK";
            this.btnConfrim.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(304, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // AddTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 321);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfrim);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCaseSize);
            this.Controls.Add(this.nudQuan);
            this.Controls.Add(this.lblTitle);
            this.Name = "AddTo";
            this.Text = "AddTo";
            this.Load += new System.EventHandler(this.AddTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.NumericUpDown nudQuan;
        private System.Windows.Forms.Label lblCaseSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnConfrim;
        private System.Windows.Forms.Button btnCancel;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private bullseyeDataSetTableAdapters.inventoryTableAdapter inventoryTableAdapter;
    }
}