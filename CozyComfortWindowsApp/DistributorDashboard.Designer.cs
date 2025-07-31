namespace CozyComfortWindowsApp
{
    partial class DistributorDashboard
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
            this.dgvMyStock = new System.Windows.Forms.DataGridView();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbBlanketType = new System.Windows.Forms.ComboBox();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnDeleteStock = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSellerOrders = new System.Windows.Forms.DataGridView();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnFulfillOrder = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbRequestBlanket = new System.Windows.Forms.ComboBox();
            this.numRequestQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnRequestStock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellerOrders)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRequestQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvMyStock);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.cmbBlanketType);
            this.groupBox1.Controls.Add(this.btnAddStock);
            this.groupBox1.Controls.Add(this.btnUpdateStock);
            this.groupBox1.Controls.Add(this.btnDeleteStock);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(34, 158);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1756, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvMyStock
            // 
            this.dgvMyStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyStock.Location = new System.Drawing.Point(24, 43);
            this.dgvMyStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMyStock.Name = "dgvMyStock";
            this.dgvMyStock.RowHeadersWidth = 62;
            this.dgvMyStock.Size = new System.Drawing.Size(1349, 263);
            this.dgvMyStock.TabIndex = 1;
            this.dgvMyStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyStock_CellContentClick);
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.Location = new System.Drawing.Point(1413, 94);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(325, 40);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // cmbBlanketType
            // 
            this.cmbBlanketType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBlanketType.FormattingEnabled = true;
            this.cmbBlanketType.Location = new System.Drawing.Point(1413, 43);
            this.cmbBlanketType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBlanketType.Name = "cmbBlanketType";
            this.cmbBlanketType.Size = new System.Drawing.Size(325, 40);
            this.cmbBlanketType.TabIndex = 2;
            this.cmbBlanketType.SelectedIndexChanged += new System.EventHandler(this.cmbBlanketType_SelectedIndexChanged);
            // 
            // btnAddStock
            // 
            this.btnAddStock.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddStock.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddStock.Location = new System.Drawing.Point(1413, 148);
            this.btnAddStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(325, 46);
            this.btnAddStock.TabIndex = 4;
            this.btnAddStock.Text = "Add";
            this.btnAddStock.UseVisualStyleBackColor = false;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click_1);
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateStock.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateStock.Location = new System.Drawing.Point(1413, 204);
            this.btnUpdateStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(325, 45);
            this.btnUpdateStock.TabIndex = 5;
            this.btnUpdateStock.Text = "Update";
            this.btnUpdateStock.UseVisualStyleBackColor = false;
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click_1);
            // 
            // btnDeleteStock
            // 
            this.btnDeleteStock.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteStock.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteStock.Location = new System.Drawing.Point(1413, 260);
            this.btnDeleteStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteStock.Name = "btnDeleteStock";
            this.btnDeleteStock.Size = new System.Drawing.Size(325, 46);
            this.btnDeleteStock.TabIndex = 6;
            this.btnDeleteStock.Text = "Delete";
            this.btnDeleteStock.UseVisualStyleBackColor = false;
            this.btnDeleteStock.Click += new System.EventHandler(this.btnDeleteStock_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvSellerOrders);
            this.groupBox2.Controls.Add(this.btnCancelOrder);
            this.groupBox2.Controls.Add(this.btnFulfillOrder);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(465, 529);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1387, 306);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seller Orders";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvSellerOrders
            // 
            this.dgvSellerOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSellerOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSellerOrders.Location = new System.Drawing.Point(24, 48);
            this.dgvSellerOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSellerOrders.Name = "dgvSellerOrders";
            this.dgvSellerOrders.RowHeadersWidth = 62;
            this.dgvSellerOrders.Size = new System.Drawing.Size(1101, 231);
            this.dgvSellerOrders.TabIndex = 8;
            this.dgvSellerOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSellerOrders_CellContentClick);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelOrder.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelOrder.Location = new System.Drawing.Point(1145, 107);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(220, 46);
            this.btnCancelOrder.TabIndex = 14;
            this.btnCancelOrder.Text = "Cancel";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnFulfillOrder
            // 
            this.btnFulfillOrder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFulfillOrder.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFulfillOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFulfillOrder.Location = new System.Drawing.Point(1145, 51);
            this.btnFulfillOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFulfillOrder.Name = "btnFulfillOrder";
            this.btnFulfillOrder.Size = new System.Drawing.Size(220, 46);
            this.btnFulfillOrder.TabIndex = 13;
            this.btnFulfillOrder.Text = "Complete";
            this.btnFulfillOrder.UseVisualStyleBackColor = false;
            this.btnFulfillOrder.Click += new System.EventHandler(this.btnFulfillOrder_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cmbRequestBlanket);
            this.groupBox3.Controls.Add(this.numRequestQuantity);
            this.groupBox3.Controls.Add(this.btnRequestStock);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(34, 529);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(423, 253);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Request Stock From Manufacturer";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cmbRequestBlanket
            // 
            this.cmbRequestBlanket.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRequestBlanket.FormattingEnabled = true;
            this.cmbRequestBlanket.Location = new System.Drawing.Point(28, 57);
            this.cmbRequestBlanket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRequestBlanket.Name = "cmbRequestBlanket";
            this.cmbRequestBlanket.Size = new System.Drawing.Size(340, 40);
            this.cmbRequestBlanket.TabIndex = 10;
            this.cmbRequestBlanket.SelectedIndexChanged += new System.EventHandler(this.cmbRequestBlanket_SelectedIndexChanged);
            // 
            // numRequestQuantity
            // 
            this.numRequestQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRequestQuantity.Location = new System.Drawing.Point(28, 115);
            this.numRequestQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numRequestQuantity.Name = "numRequestQuantity";
            this.numRequestQuantity.Size = new System.Drawing.Size(340, 40);
            this.numRequestQuantity.TabIndex = 11;
            this.numRequestQuantity.ValueChanged += new System.EventHandler(this.numRequestQuantity_ValueChanged);
            // 
            // btnRequestStock
            // 
            this.btnRequestStock.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRequestStock.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRequestStock.Location = new System.Drawing.Point(28, 175);
            this.btnRequestStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRequestStock.Name = "btnRequestStock";
            this.btnRequestStock.Size = new System.Drawing.Size(340, 46);
            this.btnRequestStock.TabIndex = 12;
            this.btnRequestStock.Text = "Request";
            this.btnRequestStock.UseVisualStyleBackColor = false;
            this.btnRequestStock.Click += new System.EventHandler(this.btnRequestStock_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(707, 880);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(434, 54);
            this.button1.TabIndex = 15;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(651, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 61);
            this.label1.TabIndex = 16;
            this.label1.Text = "Distributor Dashboard";
            // 
            // DistributorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1865, 958);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DistributorDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DistributorDashboard";
            this.Load += new System.EventHandler(this.DistributorDashboard_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellerOrders)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRequestQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMyStock;
        private System.Windows.Forms.ComboBox cmbBlanketType;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnUpdateStock;
        private System.Windows.Forms.Button btnDeleteStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSellerOrders;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbRequestBlanket;
        private System.Windows.Forms.NumericUpDown numRequestQuantity;
        private System.Windows.Forms.Button btnRequestStock;
        private System.Windows.Forms.Button btnFulfillOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}