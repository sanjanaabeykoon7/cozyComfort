using CozyComfortServiceRef;
using CozyComfortWindowsApp;
using System;
using System.Windows.Forms;

namespace CozyComfortWindowsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var serviceClient = new CozyComfortServiceSoapClient();

            try
            {
                string role = serviceClient.Login(txtUsername.Text, txtPassword.Text);

                // Hide the login form BEFORE showing the new one
                this.Hide();

                switch (role)
                {
                    case "Manufacturer":
                        ManufacturerDashboard manufacturerDashboard = new ManufacturerDashboard();
                        // This next line is important. It says: "When the dashboard closes, run my Dashboard_FormClosed method."
                        manufacturerDashboard.FormClosed += Dashboard_FormClosed;
                        manufacturerDashboard.Show();
                        break;
                    case "Distributor":
                        DistributorDashboard distributorDashboard = new DistributorDashboard();
                        distributorDashboard.FormClosed += Dashboard_FormClosed;
                        distributorDashboard.Show();
                        break;
                    case "Seller":
                        SellerDashboard sellerDashboard = new SellerDashboard();
                        sellerDashboard.FormClosed += Dashboard_FormClosed;
                        sellerDashboard.Show();
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

        // This method will be called whenever any of the dashboards are closed.
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clear the password field for security and show the login form again.
            txtPassword.Clear();
            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
