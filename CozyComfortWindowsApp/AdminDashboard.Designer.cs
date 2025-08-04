using System;
using System.Drawing;
using System.Windows.Forms;

namespace CozyComfortWindowsApp
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvUsers;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnLogout;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
        private Label lblTitle;
        private GroupBox grpUserDetails;
        private GroupBox grpUserList;

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
            this.dgvUsers = new DataGridView();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.cmbRole = new ComboBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            this.btnLogout = new Button();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblRole = new Label();
            this.lblTitle = new Label();
            this.grpUserDetails = new GroupBox();
            this.grpUserList = new GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grpUserDetails.SuspendLayout();
            this.grpUserList.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Text = "Admin Dashboard - User Management";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(400, 20);
            this.lblTitle.Size = new Size(200, 29);
            this.lblTitle.Text = "Admin Dashboard";

            // User List GroupBox
            this.grpUserList.Location = new Point(20, 60);
            this.grpUserList.Size = new Size(600, 400);
            this.grpUserList.Text = "User List";

            // DataGridView
            this.dgvUsers.Location = new Point(10, 25);
            this.dgvUsers.Size = new Size(580, 360);
            this.dgvUsers.SelectionChanged += new EventHandler(this.dgvUsers_SelectionChanged);

            // User Details GroupBox
            this.grpUserDetails.Location = new Point(640, 60);
            this.grpUserDetails.Size = new Size(340, 400);
            this.grpUserDetails.Text = "User Details";

            // Username Label and TextBox
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new Point(20, 40);
            this.lblUsername.Size = new Size(60, 15);
            this.lblUsername.Text = "Username:";

            this.txtUsername.Location = new Point(90, 37);
            this.txtUsername.Size = new Size(230, 23);

            // Password Label and TextBox
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(20, 80);
            this.lblPassword.Size = new Size(60, 15);
            this.lblPassword.Text = "Password:";

            this.txtPassword.Location = new Point(90, 77);
            this.txtPassword.Size = new Size(230, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // Role Label and ComboBox
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(20, 120);
            this.lblRole.Size = new Size(30, 15);
            this.lblRole.Text = "Role:";

            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new Point(90, 117);
            this.cmbRole.Size = new Size(230, 23);

            // Buttons
            this.btnAdd.BackColor = Color.Green;
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(20, 170);
            this.btnAdd.Size = new Size(70, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = Color.Blue;
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.Location = new Point(100, 170);
            this.btnUpdate.Size = new Size(70, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor = Color.Red;
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(180, 170);
            this.btnDelete.Size = new Size(70, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor = Color.Gray;
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(260, 170);
            this.btnClear.Size = new Size(70, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // Logout Button
            this.btnLogout.BackColor = Color.Black;
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(450, 500);
            this.btnLogout.Size = new Size(100, 40);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            // Add controls to GroupBoxes
            this.grpUserList.Controls.Add(this.dgvUsers);
            this.grpUserDetails.Controls.Add(this.lblUsername);
            this.grpUserDetails.Controls.Add(this.txtUsername);
            this.grpUserDetails.Controls.Add(this.lblPassword);
            this.grpUserDetails.Controls.Add(this.txtPassword);
            this.grpUserDetails.Controls.Add(this.lblRole);
            this.grpUserDetails.Controls.Add(this.cmbRole);
            this.grpUserDetails.Controls.Add(this.btnAdd);
            this.grpUserDetails.Controls.Add(this.btnUpdate);
            this.grpUserDetails.Controls.Add(this.btnDelete);
            this.grpUserDetails.Controls.Add(this.btnClear);

            // Add controls to Form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpUserList);
            this.Controls.Add(this.grpUserDetails);
            this.Controls.Add(this.btnLogout);

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grpUserDetails.ResumeLayout(false);
            this.grpUserDetails.PerformLayout();
            this.grpUserList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}