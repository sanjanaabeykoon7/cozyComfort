namespace CozyComfortWindowsApp
{
    partial class ManufacturerDashboard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBlankets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddBlanket = new System.Windows.Forms.Button();
            this.btnUpdateBlanket = new System.Windows.Forms.Button();
            this.btnDeleteBlanket = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStockRequests = new System.Windows.Forms.DataGridView();
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            this.btnRejectRequest = new System.Windows.Forms.Button();
            this.btnApproveRequest = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlankets)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvBlankets);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 154);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1131, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Blankets";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvBlankets
            // 
            this.dgvBlankets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBlankets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlankets.Location = new System.Drawing.Point(27, 45);
            this.dgvBlankets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBlankets.Name = "dgvBlankets";
            this.dgvBlankets.RowHeadersWidth = 62;
            this.dgvBlankets.Size = new System.Drawing.Size(1071, 275);
            this.dgvBlankets.TabIndex = 1;
            this.dgvBlankets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBlankets_CellContentClick);
            this.dgvBlankets.SelectionChanged += new System.EventHandler(this.dgvBlankets_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1226, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(1400, 190);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(346, 35);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(1400, 249);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(346, 35);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.Location = new System.Drawing.Point(1400, 311);
            this.txtMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(346, 35);
            this.txtMaterial.TabIndex = 5;
            this.txtMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(1400, 375);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(346, 35);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // btnAddBlanket
            // 
            this.btnAddBlanket.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddBlanket.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBlanket.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddBlanket.Location = new System.Drawing.Point(1216, 454);
            this.btnAddBlanket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddBlanket.Name = "btnAddBlanket";
            this.btnAddBlanket.Size = new System.Drawing.Size(136, 45);
            this.btnAddBlanket.TabIndex = 7;
            this.btnAddBlanket.Text = "Add";
            this.btnAddBlanket.UseVisualStyleBackColor = false;
            this.btnAddBlanket.Click += new System.EventHandler(this.btnAddBlanket_Click_1);
            // 
            // btnUpdateBlanket
            // 
            this.btnUpdateBlanket.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateBlanket.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBlanket.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateBlanket.Location = new System.Drawing.Point(1362, 454);
            this.btnUpdateBlanket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdateBlanket.Name = "btnUpdateBlanket";
            this.btnUpdateBlanket.Size = new System.Drawing.Size(134, 45);
            this.btnUpdateBlanket.TabIndex = 8;
            this.btnUpdateBlanket.Text = "Update";
            this.btnUpdateBlanket.UseVisualStyleBackColor = false;
            this.btnUpdateBlanket.Click += new System.EventHandler(this.btnUpdateBlanket_Click_1);
            // 
            // btnDeleteBlanket
            // 
            this.btnDeleteBlanket.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteBlanket.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBlanket.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteBlanket.Location = new System.Drawing.Point(1504, 454);
            this.btnDeleteBlanket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteBlanket.Name = "btnDeleteBlanket";
            this.btnDeleteBlanket.Size = new System.Drawing.Size(134, 45);
            this.btnDeleteBlanket.TabIndex = 9;
            this.btnDeleteBlanket.Text = "Delete";
            this.btnDeleteBlanket.UseVisualStyleBackColor = false;
            this.btnDeleteBlanket.Click += new System.EventHandler(this.btnDeleteBlanket_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvStockRequests);
            this.groupBox2.Controls.Add(this.btnRefreshRequests);
            this.groupBox2.Controls.Add(this.btnRejectRequest);
            this.groupBox2.Controls.Add(this.btnApproveRequest);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(39, 526);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1759, 315);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock Requests From Distributors";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvStockRequests
            // 
            this.dgvStockRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockRequests.Location = new System.Drawing.Point(32, 48);
            this.dgvStockRequests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvStockRequests.Name = "dgvStockRequests";
            this.dgvStockRequests.RowHeadersWidth = 62;
            this.dgvStockRequests.Size = new System.Drawing.Size(1377, 231);
            this.dgvStockRequests.TabIndex = 11;
            this.dgvStockRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockRequests_CellContentClick);
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefreshRequests.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshRequests.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshRequests.Location = new System.Drawing.Point(1439, 217);
            this.btnRefreshRequests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(300, 45);
            this.btnRefreshRequests.TabIndex = 12;
            this.btnRefreshRequests.Text = "Refresh";
            this.btnRefreshRequests.UseVisualStyleBackColor = false;
            this.btnRefreshRequests.Click += new System.EventHandler(this.btnRefreshRequests_Click);
            // 
            // btnRejectRequest
            // 
            this.btnRejectRequest.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRejectRequest.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectRequest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRejectRequest.Location = new System.Drawing.Point(1439, 144);
            this.btnRejectRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRejectRequest.Name = "btnRejectRequest";
            this.btnRejectRequest.Size = new System.Drawing.Size(300, 45);
            this.btnRejectRequest.TabIndex = 14;
            this.btnRejectRequest.Text = "Reject";
            this.btnRejectRequest.UseVisualStyleBackColor = false;
            this.btnRejectRequest.Click += new System.EventHandler(this.btnRejectRequest_Click);
            // 
            // btnApproveRequest
            // 
            this.btnApproveRequest.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnApproveRequest.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveRequest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApproveRequest.Location = new System.Drawing.Point(1439, 70);
            this.btnApproveRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnApproveRequest.Name = "btnApproveRequest";
            this.btnApproveRequest.Size = new System.Drawing.Size(300, 45);
            this.btnApproveRequest.TabIndex = 13;
            this.btnApproveRequest.Text = "Approve";
            this.btnApproveRequest.UseVisualStyleBackColor = false;
            this.btnApproveRequest.Click += new System.EventHandler(this.btnApproveRequest_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClear.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(1646, 454);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(134, 45);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(726, 876);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(444, 55);
            this.button1.TabIndex = 16;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1226, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1226, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 32);
            this.label3.TabIndex = 18;
            this.label3.Text = "Material";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1226, 372);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 32);
            this.label4.TabIndex = 19;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(618, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(607, 61);
            this.label5.TabIndex = 20;
            this.label5.Text = "Manufacturer Dashboard";
            // 
            // ManufacturerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1811, 955);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddBlanket);
            this.Controls.Add(this.btnDeleteBlanket);
            this.Controls.Add(this.btnUpdateBlanket);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManufacturerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManufacturerDashboard";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlankets)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBlankets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAddBlanket;
        private System.Windows.Forms.Button btnUpdateBlanket;
        private System.Windows.Forms.Button btnDeleteBlanket;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStockRequests;
        private System.Windows.Forms.Button btnRefreshRequests;
        private System.Windows.Forms.Button btnApproveRequest;
        private System.Windows.Forms.Button btnRejectRequest;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}