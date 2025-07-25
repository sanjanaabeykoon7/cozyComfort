using CozyComfortServiceRef;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CozyComfortWindowsApp
{
    public partial class ManufacturerDashboard : Form
    {
        private readonly CozyComfortServiceSoapClient client = new CozyComfortServiceSoapClient();

        public ManufacturerDashboard()
        {
            InitializeComponent();
        }

        private void ManufacturerDashboard_Load(object sender, EventArgs e)
        {
            SetupDataGridViews();
            RefreshBlanketList();
            RefreshStockRequestList();

            // Start the form in "Add Mode" for a better user experience
            SetFormMode(true);
        }

        #region UI and Form Logic

        private void SetupDataGridViews()
        {
            dgvBlankets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBlankets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBlankets.MultiSelect = false;
            dgvBlankets.ReadOnly = true;

            dgvStockRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockRequests.MultiSelect = false;
            dgvStockRequests.ReadOnly = true;
        }

        // Manages whether the form is in "Add Mode" or "Edit Mode"
        private void SetFormMode(bool isAddMode)
        {
            if (isAddMode)
            {
                // Clear all fields and enable the "Add" button
                dgvBlankets.ClearSelection();
                txtName.Clear();
                txtDescription.Clear();
                txtMaterial.Clear();
                txtPrice.Clear();

                btnAddBlanket.Enabled = true;
                btnUpdateBlanket.Enabled = false;
                txtName.Focus();
            }
            else
            {
                // Disable "Add" and enable "Update" when an item is selected
                btnAddBlanket.Enabled = false;
                btnUpdateBlanket.Enabled = true;
            }
        }

        // Handles the "Clear / New" button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Blanket Management

        private void RefreshBlanketList()
        {
            try
            {
                dgvBlankets.DataSource = null;
                dgvBlankets.DataSource = client.Manufacturer_GetBlankets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blankets: " + ex.Message, "Service Error");
            }
        }

        private void dgvBlankets_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBlankets.SelectedRows.Count > 0)
            {
                var selectedBlanket = dgvBlankets.SelectedRows[0].DataBoundItem as Blanket;
                if (selectedBlanket != null)
                {
                    txtName.Text = selectedBlanket.Name;
                    txtDescription.Text = selectedBlanket.Description;
                    txtMaterial.Text = selectedBlanket.Material;
                    txtPrice.Text = selectedBlanket.Price.ToString();
                    SetFormMode(false);
                }
            }
        }

        private void btnAddBlanket_Click_1(object sender, EventArgs e)
        {
            try
            {
                var newBlanket = new Blanket { Name = txtName.Text, Description = txtDescription.Text, Material = txtMaterial.Text, Price = decimal.Parse(txtPrice.Text) };
                string result = client.Manufacturer_AddBlanket(newBlanket);
                MessageBox.Show(result);
                RefreshBlanketList();
                SetFormMode(true);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price format. Please enter a valid number.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void btnUpdateBlanket_Click_1(object sender, EventArgs e)
        {
            if (dgvBlankets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a blanket to update.");
                return;
            }
            try
            {
                var selectedBlanket = dgvBlankets.SelectedRows[0].DataBoundItem as Blanket;
                var updatedBlanket = new Blanket { BlanketID = selectedBlanket.BlanketID, Name = txtName.Text, Description = txtDescription.Text, Material = txtMaterial.Text, Price = decimal.Parse(txtPrice.Text) };
                string result = client.Manufacturer_UpdateBlanket(updatedBlanket);
                MessageBox.Show(result);
                RefreshBlanketList();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price format. Please enter a valid number.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void btnDeleteBlanket_Click(object sender, EventArgs e)
        {
            if (dgvBlankets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a blanket to delete.");
                return;
            }
            var selectedBlanket = dgvBlankets.SelectedRows[0].DataBoundItem as Blanket;
            if (MessageBox.Show($"Are you sure you want to delete {selectedBlanket.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string result = client.Manufacturer_DeleteBlanket(selectedBlanket.BlanketID);
                    MessageBox.Show(result);
                    RefreshBlanketList();
                    SetFormMode(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
            }
        }
        #endregion

        #region Stock Request Viewer
        private void RefreshStockRequestList() { try { dgvStockRequests.DataSource = null; dgvStockRequests.DataSource = client.Manufacturer_GetStockRequests(); } catch (Exception ex) { MessageBox.Show("Error loading stock requests: " + ex.Message, "Service Error"); } }
        private void btnRefreshRequests_Click(object sender, EventArgs e) { RefreshStockRequestList(); }
        private void btnApproveRequest_Click(object sender, EventArgs e) { if (dgvStockRequests.SelectedRows.Count == 0) { MessageBox.Show("Please select a request to approve.", "Selection Required"); return; } var selectedRequest = dgvStockRequests.SelectedRows[0].DataBoundItem as StockRequest; if (selectedRequest.Status != "Pending") { MessageBox.Show("This request has already been processed.", "Request Not Pending"); return; } if (MessageBox.Show($"Are you sure you want to approve this request?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { try { string result = client.Manufacturer_ApproveRequest(selectedRequest.RequestID); MessageBox.Show(result, "Success"); RefreshStockRequestList(); } catch (Exception ex) { MessageBox.Show("An error occurred while approving the request: " + ex.Message, "Service Error"); } } }
        private void btnRejectRequest_Click(object sender, EventArgs e) { if (dgvStockRequests.SelectedRows.Count == 0) { MessageBox.Show("Please select a request to reject.", "Selection Required"); return; } var selectedRequest = dgvStockRequests.SelectedRows[0].DataBoundItem as StockRequest; if (selectedRequest.Status != "Pending") { MessageBox.Show("This request has already been processed.", "Request Not Pending"); return; } if (MessageBox.Show($"Are you sure you want to reject this request?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { try { string result = client.Manufacturer_RejectRequest(selectedRequest.RequestID); MessageBox.Show(result, "Success"); RefreshStockRequestList(); } catch (Exception ex) { MessageBox.Show("An error occurred while rejecting the request: " + ex.Message, "Service Error"); } } }
        #endregion

        #region Empty Event Handlers
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void txtDescription_TextChanged(object sender, EventArgs e) { }
        private void txtMaterial_TextChanged(object sender, EventArgs e) { }
        private void txtPrice_TextChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dgvBlankets_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvStockRequests_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
