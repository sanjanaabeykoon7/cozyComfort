using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CozyComfortServiceRef;

namespace CozyComfortWindowsApp
{
    public partial class AdminDashboard : Form
    {
        private readonly CozyComfortServiceSoapClient client = new CozyComfortServiceSoapClient();
        private List<CozyComfortServiceRef.User> allUsers;
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Check if user context is properly set
            if (UserContext.AdminID == 0) // You'll need to add AdminID to UserContext
            {
                MessageBox.Show("User context not properly initialized. Please log in again.", "Error");
                this.Close();
                return;
            }

            SetupDataGridView();
            SetupRoleComboBox();
            RefreshUserList();
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
        }

        private void SetupRoleComboBox()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "Admin", "Manufacturer", "Distributor", "Seller" });
            cmbRole.SelectedIndex = 0;
        }

        private void RefreshUserList()
        {
            try
            {
                allUsers = client.Admin_GetAllUsers().ToList();
                dgvUsers.DataSource = allUsers;

                // Hide the first column (UserID) and PasswordHash column
                if (dgvUsers.Columns.Count > 0)
                {
                    dgvUsers.Columns[0].Visible = false; // UserID
                    if (dgvUsers.Columns.Count > 2)
                    {
                        dgvUsers.Columns[2].Visible = false; // PasswordHash
                    }
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Service Error");
            }
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Required");
                return;
            }

            try
            {
                var newUser = new CozyComfortServiceRef.User
                {
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = txtPassword.Text, // Will be hashed in the controller
                    Role = cmbRole.SelectedItem.ToString()
                };

                string result = client.Admin_AddUser(newUser);
                MessageBox.Show(result, result.StartsWith("Error") ? "Error" : "Success");

                if (!result.StartsWith("Error"))
                {
                    RefreshUserList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update.", "Selection Required");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Input Required");
                return;
            }

            try
            {
                var selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.User;

                var updatedUser = new CozyComfortServiceRef.User
                {
                    UserID = selectedUser.UserID,
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = string.IsNullOrWhiteSpace(txtPassword.Text) ? selectedUser.PasswordHash : txtPassword.Text,
                    Role = cmbRole.SelectedItem.ToString()
                };

                string result = client.Admin_UpdateUser(updatedUser);
                MessageBox.Show(result, result.StartsWith("Error") ? "Error" : "Success");

                if (!result.StartsWith("Error"))
                {
                    RefreshUserList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required");
                return;
            }

            var selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.User;

            if (MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string result = client.Admin_DeleteUser(selectedUser.UserID);
                    MessageBox.Show(result, result.StartsWith("Error") ? "Error" : "Success");

                    if (!result.StartsWith("Error"))
                    {
                        RefreshUserList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Error");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvUsers.ClearSelection();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.User;
                txtUsername.Text = selectedUser.Username;
                txtPassword.Clear(); // Don't show the password hash
                cmbRole.SelectedItem = selectedUser.Role;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
