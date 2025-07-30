namespace CozyComfortWindowsApp
{
    partial class SellerDashboard
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
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.nudquantity = new System.Windows.Forms.NumericUpDown();
            this.cmbBlanketType = new System.Windows.Forms.ComboBox();
            this.dgvMyStock = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnplceorder = new System.Windows.Forms.Button();
            this.nudquantityOrder = new System.Windows.Forms.NumericUpDown();
            this.cmbrequestOrder = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RefreshHistory = new System.Windows.Forms.Button();
            this.dgvOrderHistory = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudquantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyStock)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudquantityOrder)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btndelete);
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.btnadd);
            this.groupBox1.Controls.Add(this.nudquantity);
            this.groupBox1.Controls.Add(this.cmbBlanketType);
            this.groupBox1.Controls.Add(this.dgvMyStock);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 166);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1784, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btndelete.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btndelete.Location = new System.Drawing.Point(1486, 258);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(281, 46);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnupdate.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnupdate.Location = new System.Drawing.Point(1486, 206);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(279, 45);
            this.btnupdate.TabIndex = 4;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnadd.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnadd.Location = new System.Drawing.Point(1486, 154);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(279, 46);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // nudquantity
            // 
            this.nudquantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudquantity.Location = new System.Drawing.Point(1486, 100);
            this.nudquantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudquantity.Name = "nudquantity";
            this.nudquantity.Size = new System.Drawing.Size(281, 40);
            this.nudquantity.TabIndex = 2;
            this.nudquantity.ValueChanged += new System.EventHandler(this.nudquantity_ValueChanged);
            // 
            // cmbBlanketType
            // 
            this.cmbBlanketType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBlanketType.FormattingEnabled = true;
            this.cmbBlanketType.Location = new System.Drawing.Point(1486, 48);
            this.cmbBlanketType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBlanketType.Name = "cmbBlanketType";
            this.cmbBlanketType.Size = new System.Drawing.Size(279, 40);
            this.cmbBlanketType.TabIndex = 1;
            this.cmbBlanketType.SelectedIndexChanged += new System.EventHandler(this.cmbBlanketType_SelectedIndexChanged);
            // 
            // dgvMyStock
            // 
            this.dgvMyStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyStock.Location = new System.Drawing.Point(36, 48);
            this.dgvMyStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMyStock.Name = "dgvMyStock";
            this.dgvMyStock.RowHeadersWidth = 62;
            this.dgvMyStock.Size = new System.Drawing.Size(1416, 256);
            this.dgvMyStock.TabIndex = 0;
            this.dgvMyStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyStock_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnplceorder);
            this.groupBox2.Controls.Add(this.nudquantityOrder);
            this.groupBox2.Controls.Add(this.cmbrequestOrder);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 545);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(401, 312);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Stock From Distributor";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnplceorder
            // 
            this.btnplceorder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnplceorder.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplceorder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnplceorder.Location = new System.Drawing.Point(34, 173);
            this.btnplceorder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnplceorder.Name = "btnplceorder";
            this.btnplceorder.Size = new System.Drawing.Size(301, 55);
            this.btnplceorder.TabIndex = 2;
            this.btnplceorder.Text = "Request";
            this.btnplceorder.UseVisualStyleBackColor = false;
            this.btnplceorder.Click += new System.EventHandler(this.btnplceorder_Click);
            // 
            // nudquantityOrder
            // 
            this.nudquantityOrder.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudquantityOrder.Location = new System.Drawing.Point(36, 113);
            this.nudquantityOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudquantityOrder.Name = "nudquantityOrder";
            this.nudquantityOrder.Size = new System.Drawing.Size(299, 40);
            this.nudquantityOrder.TabIndex = 1;
            this.nudquantityOrder.ValueChanged += new System.EventHandler(this.nudquantityOrder_ValueChanged);
            // 
            // cmbrequestOrder
            // 
            this.cmbrequestOrder.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbrequestOrder.FormattingEnabled = true;
            this.cmbrequestOrder.Location = new System.Drawing.Point(36, 58);
            this.cmbrequestOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbrequestOrder.Name = "cmbrequestOrder";
            this.cmbrequestOrder.Size = new System.Drawing.Size(299, 40);
            this.cmbrequestOrder.TabIndex = 0;
            this.cmbrequestOrder.SelectedIndexChanged += new System.EventHandler(this.cmbrequestOrder_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.RefreshHistory);
            this.groupBox3.Controls.Add(this.dgvOrderHistory);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(446, 545);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1356, 312);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order History";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // RefreshHistory
            // 
            this.RefreshHistory.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RefreshHistory.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshHistory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RefreshHistory.Location = new System.Drawing.Point(507, 238);
            this.RefreshHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshHistory.Name = "RefreshHistory";
            this.RefreshHistory.Size = new System.Drawing.Size(338, 49);
            this.RefreshHistory.TabIndex = 1;
            this.RefreshHistory.Text = "Refresh";
            this.RefreshHistory.UseVisualStyleBackColor = false;
            this.RefreshHistory.Click += new System.EventHandler(this.RefreshHistory_Click);
            // 
            // dgvOrderHistory
            // 
            this.dgvOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderHistory.Location = new System.Drawing.Point(27, 54);
            this.dgvOrderHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrderHistory.Name = "dgvOrderHistory";
            this.dgvOrderHistory.RowHeadersWidth = 62;
            this.dgvOrderHistory.Size = new System.Drawing.Size(1310, 174);
            this.dgvOrderHistory.TabIndex = 0;
            this.dgvOrderHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderHistory_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(715, 880);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(418, 55);
            this.button1.TabIndex = 16;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(709, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 61);
            this.label1.TabIndex = 17;
            this.label1.Text = "Seller Dashboard";
            // 
            // SellerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1815, 958);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SellerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerDashboard";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudquantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyStock)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudquantityOrder)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBlanketType;
        private System.Windows.Forms.DataGridView dgvMyStock;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.NumericUpDown nudquantity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnplceorder;
        private System.Windows.Forms.NumericUpDown nudquantityOrder;
        private System.Windows.Forms.ComboBox cmbrequestOrder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button RefreshHistory;
        private System.Windows.Forms.DataGridView dgvOrderHistory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}