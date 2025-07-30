using CozyComfortSystem.Models;
using CozyComfortServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CozyComfortWindowsApp
{
    public partial class DistributorDashboard : Form
    {
        private readonly CozyComfortServiceSoapClient client = new CozyComfortServiceSoapClient();
        private List<CozyComfortServiceRef.Blanket> allBlankets;

        public DistributorDashboard()
        {
            InitializeComponent();
        }

        private void DistributorDashboard_Load(object sender, EventArgs e)
        {
            // Check if user context is properly set
            if (UserContext.DistributorID == 0)
            {
                MessageBox.Show("User context not properly initialized. Please log in again.", "Error");
                this.Close();
                return;
            }

            SetupDataGridViews();
            LoadAllBlanketTypes();
            RefreshMyStock();
            RefreshSellerOrders();
        }

        private void SetupDataGridViews()
        {
            dgvMyStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyStock.MultiSelect = false;
            dgvMyStock.ReadOnly = true;
            dgvMyStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular);


            dgvSellerOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSellerOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSellerOrders.MultiSelect = false;
            dgvSellerOrders.ReadOnly = true;
            dgvSellerOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular);
        }

        private void LoadAllBlanketTypes()
        {
            try
            {
                allBlankets = client.Manufacturer_GetBlankets().ToList();

                cmbBlanketType.DataSource = allBlankets;
                cmbBlanketType.DisplayMember = "Name";
                cmbBlanketType.ValueMember = "BlanketID";

                cmbRequestBlanket.DataSource = allBlankets.ToList();
                cmbRequestBlanket.DisplayMember = "Name";
                cmbRequestBlanket.ValueMember = "BlanketID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blanket types: " + ex.Message, "Service Error");
            }
        }

        #region My Stock Management

        private void RefreshMyStock()
        {
            try
            {
                // Use UserContext.DistributorID instead of hardcoded value
                dgvMyStock.DataSource = client.Distributor_GetStock(UserContext.DistributorID);
                dgvMyStock.Columns[0].Visible = false; // Hide first column
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading your stock: " + ex.Message, "Service Error");
            }
        }

        private void dgvMyStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMyStock.SelectedRows.Count > 0)
            {
                var selectedStock = dgvMyStock.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.Stock;
                if (selectedStock != null)
                {
                    cmbBlanketType.SelectedValue = selectedStock.BlanketID;
                    numQuantity.Value = selectedStock.Quantity;
                }
            }
        }

        private void btnAddStock_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get the selected blanket name from the combo box
                string selectedBlanketName = cmbBlanketType.Text;

                var stockItem = new CozyComfortServiceRef.Stock
                {
                    OwnerID = UserContext.DistributorID,
                    BlanketID = (int)cmbBlanketType.SelectedValue,
                    BlanketName = selectedBlanketName,
                    Quantity = (int)numQuantity.Value
                };
                string result = client.Distributor_AddStock(stockItem);
                MessageBox.Show(result, "Success");
                RefreshMyStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding stock: " + ex.Message, "Error");
            }
        }

        private void btnUpdateStock_Click_1(object sender, EventArgs e)
        {
            if (dgvMyStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a stock item to update.", "Selection Required");
                return;
            }
            try
            {
                var selectedStock = dgvMyStock.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.Stock;
                int newQuantity = (int)numQuantity.Value;
                string result = client.Distributor_UpdateStock(selectedStock.StockID, newQuantity);
                MessageBox.Show(result, "Success");
                RefreshMyStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock: " + ex.Message, "Error");
            }
        }

        private void btnDeleteStock_Click_1(object sender, EventArgs e)
        {
            if (dgvMyStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a stock item to delete.", "Selection Required");
                return;
            }
            var selectedStock = dgvMyStock.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.Stock;
            if (MessageBox.Show($"Are you sure you want to delete {selectedStock.BlanketName} from your stock?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string result = client.Distributor_DeleteStock(selectedStock.StockID);
                    MessageBox.Show(result, "Success");
                    RefreshMyStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting stock: " + ex.Message, "Error");
                }
            }
        }

        #endregion

        #region Seller Order Viewer

        private void RefreshSellerOrders()
        {
            try
            {
                dgvSellerOrders.DataSource = client.Distributor_GetSellerOrders();
                dgvSellerOrders.Columns[0].Visible = false; // Hide first column
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seller orders: " + ex.Message, "Service Error");
            }
        }

        private void btnFulfillOrder_Click(object sender, EventArgs e)
        {
            if (dgvSellerOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to fulfill.", "Selection Required");
                return;
            }

            var selectedOrder = dgvSellerOrders.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.Order;
            if (selectedOrder.Status != "Pending")
            {
                MessageBox.Show("This order has already been processed.", "Order Not Pending");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to fulfill this order?", "Confirm Fulfillment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string result = client.Distributor_FulfillOrder(selectedOrder.OrderID, UserContext.DistributorID);
                    MessageBox.Show(result, "Action Result");

                    RefreshSellerOrders();
                    RefreshMyStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Service Error");
                }
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvSellerOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.", "Selection Required");
                return;
            }

            var selectedOrder = dgvSellerOrders.SelectedRows[0].DataBoundItem as CozyComfortServiceRef.Order;
            if (selectedOrder.Status != "Pending")
            {
                MessageBox.Show("This order has already been processed.", "Order Not Pending");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to cancel this order?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string result = client.Distributor_CancelOrder(selectedOrder.OrderID);
                    MessageBox.Show(result, "Action Result");
                    RefreshSellerOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Service Error");
                }
            }
        }

        #endregion

        #region Request Stock

        private void btnRequestStock_Click_1(object sender, EventArgs e)
        {
            if (cmbRequestBlanket.SelectedValue == null)
            {
                MessageBox.Show("Please select a blanket type to request.", "Selection Required");
                return;
            }

            try
            {
                int distributorId = UserContext.DistributorID;
                string distributorName = UserContext.DistributorName;

                if (string.IsNullOrEmpty(distributorName))
                {
                    MessageBox.Show("Distributor information not available. Please log in again.", "Error");
                    return;
                }

                string blanketName = cmbRequestBlanket.Text; // Adjust if needed

                var request = new CozyComfortServiceRef.StockRequest
                {
                    DistributorID = distributorId,
                    DistributorName = distributorName,
                    BlanketID = (int)cmbRequestBlanket.SelectedValue,
                    BlanketName = blanketName,
                    Quantity = (int)numRequestQuantity.Value,
                    RequestDate = DateTime.Now,
                    Status = "Pending"
                };

                string result = client.Distributor_RequestStock(request);
                MessageBox.Show(result, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error requesting stock: " + ex.Message, "Error");
            }
        }
        #endregion

        #region --- Empty Event Handlers for Designer ---
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dgvMyStock_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cmbBlanketType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numQuantity_ValueChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dgvSellerOrders_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void cmbRequestBlanket_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numRequestQuantity_ValueChanged(object sender, EventArgs e) { }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
