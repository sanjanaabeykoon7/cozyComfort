using CozyComfortServiceRef;
using CozyComfortSystem.Data;
using CozyComfortWindowsApp;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CozyComfortWindowsApp
{
    public partial class LoginForm : Form
    {
        private CozyComfortServiceSoapClient serviceClient;

        public LoginForm()
        {
            InitializeComponent();
            serviceClient = new CozyComfortServiceSoapClient(); // Initialize in constructor
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string role = serviceClient.Login(txtUsername.Text, txtPassword.Text);

                // Hide the login form BEFORE showing the new one
                this.Hide();

                switch (role)
                {
                    case "Manufacturer":
                        SetUserContext(txtUsername.Text, role); // Set context for Manufacturer
                        ManufacturerDashboard manufacturerDashboard = new ManufacturerDashboard();
                        manufacturerDashboard.FormClosed += Dashboard_FormClosed;
                        manufacturerDashboard.Show();
                        break;
                    case "Distributor":
                        SetUserContext(txtUsername.Text, role); // Set context for Distributor
                        DistributorDashboard distributorDashboard = new DistributorDashboard();
                        distributorDashboard.FormClosed += Dashboard_FormClosed;
                        distributorDashboard.Show();
                        break;
                    case "Seller":
                        SetUserContext(txtUsername.Text, role); // Set context for Seller
                        SellerDashboard sellerDashboard = new SellerDashboard();
                        sellerDashboard.FormClosed += Dashboard_FormClosed;
                        sellerDashboard.Show();
                        break;
                    case "Admin":
                        SetUserContext(txtUsername.Text, role);
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.FormClosed += Dashboard_FormClosed;
                        adminDashboard.Show();
                        break;
                    case "Invalid":
                        MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show(); // Show the login form again if login fails
                        break;
                    default:
                        MessageBox.Show("An error occurred while trying to log in.", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to the service. Please ensure the service is running.\n\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Show();
            }
        }

        // Method to set user context based on role
        private void SetUserContext(string username, string role)
        {
            using (var command = new SqlCommand("SELECT UserID, Username, Role FROM Users WHERE Username = @Username"))
            {
                command.Parameters.AddWithValue("@Username", username);
                var reader = DataAccessLayer.ExecuteReader(command);

                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    string userName = reader.GetString(1);
                    string dbRole = reader.GetString(2);

                    if (dbRole != role)
                    {
                        throw new Exception("Role mismatch detected.");
                    }

                    // Set context based on role
                    switch (role)
                    {
                        case "Distributor":
                            UserContext.DistributorID = userId;
                            UserContext.DistributorName = userName;
                            break;
                        case "Manufacturer":
                            UserContext.ManufacturerID = userId; // Add ManufacturerID to UserContext
                            UserContext.ManufacturerName = userName; // Add ManufacturerName
                            break;
                        case "Seller":
                            UserContext.SellerID = userId; // Add SellerID to UserContext
                            UserContext.SellerName = userName; // Add SellerName
                            break;
                        case "Admin":
                            UserContext.AdminID = userId;
                            UserContext.AdminName = userName;
                            break;
                    }
                }
                else
                {
                    throw new Exception("User not found.");
                }
                reader.Close();
            }
        }

        

        // This method will be called whenever any of the dashboards are closed.
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtPassword.Clear();
            this.Show();
            UserContext.DistributorID = 0;
            UserContext.DistributorName = null;
            UserContext.ManufacturerID = 0;
            UserContext.ManufacturerName = null;
            UserContext.SellerID = 0;
            UserContext.SellerName = null;
            UserContext.AdminID = 0;  // Add this
            UserContext.AdminName = null;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Optional: Initialize any form settings here
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure the service client is disposed when the form closes
            serviceClient?.Close();
        }

    }
}