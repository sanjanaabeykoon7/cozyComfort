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
    public partial class SellerDashboard : Form
    {
        private readonly CozyComfortServiceSoapClient client = new CozyComfortServiceSoapClient();
        private List<Blanket> allBlankets;

        public SellerDashboard()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Seller Dashboard - CozyComfort";
            this.WindowState = FormWindowState.Maximized;
            SetupDataGridViews();
            LoadAllBlanketTypes();
            RefreshMyStock();
            RefreshOrderHistory();
            SetupButtonTexts();
        }

        private void SetupButtonTexts()
        {
            btnadd.Text = "Add";
            btnupdate.Text = "Update";
            btndelete.Text = "Delete";
            btnplceorder.Text = "Place Order";
            RefreshHistory.Text = "Refresh";
        }

        private void SetupDataGridViews()
        {
            // Setup stock DataGridView
            dgvMyStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyStock.MultiSelect = false;
            dgvMyStock.ReadOnly = true;
            dgvMyStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular);

            // Setup order history DataGridView
            dgvOrderHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderHistory.MultiSelect = false;
            dgvOrderHistory.ReadOnly = true;
            dgvOrderHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular);
        }

        private void LoadAllBlanketTypes()
        {
            try
            {
                allBlankets = client.Seller_GetAvailableBlankets().ToList();

                if (allBlankets == null || !allBlankets.Any())
                {
                    MessageBox.Show("No blankets available. Please contact manufacturer.", "No Products Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Bind to stock management combo box
                cmbBlanketType.DataSource = allBlankets.ToList();
                cmbBlanketType.DisplayMember = "Name";
                cmbBlanketType.ValueMember = "BlanketID";

                // Bind to order combo box
                cmbrequestOrder.DataSource = allBlankets.ToList();
                cmbrequestOrder.DisplayMember = "Name";
                cmbrequestOrder.ValueMember = "BlanketID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blanket types: " + ex.Message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshMyStock()
        {
            try
            {
                // Use UserContext.SellerID instead of hardcoded value
                dgvMyStock.DataSource = client.Seller_GetStock(UserContext.SellerID);
                dgvMyStock.Columns[0].Visible = false; // Hide first column
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading your stock: " + ex.Message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOrderHistory()
        {
            try
            {
                dgvOrderHistory.DataSource = client.Seller_CheckOrders(UserContext.SellerID);
                dgvOrderHistory.Columns[0].Visible = false; // Hide first column
                dgvOrderHistory.Columns[2].Visible = false;
                dgvOrderHistory.Columns["OrderDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order history: " + ex.Message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers implementation
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Empty - required by designer
        }

        private void dgvMyStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // When user clicks on a stock row, populate the form fields
            if (e.RowIndex >= 0)
            {
                var selectedStock = dgvMyStock.Rows[e.RowIndex].DataBoundItem as Stock;
                if (selectedStock != null)
                {
                    cmbBlanketType.SelectedValue = selectedStock.BlanketID;
                    nudquantity.Value = selectedStock.Quantity;
                }
            }
        }

        private void cmbBlanketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset quantity when blanket type changes
            if (cmbBlanketType.Focused)
            {
                nudquantity.Value = 1;
            }
        }

        private void nudquantity_ValueChanged(object sender, EventArgs e)
        {
            // Empty - required by designer
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cmbBlanketType.SelectedValue == null)
            {
                MessageBox.Show("Please select a blanket type.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudquantity.Value <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get the selected blanket name from the combo box
                string selectedBlanketName = cmbBlanketType.Text;

                var stockItem = new Stock
                {
                    OwnerID = UserContext.SellerID,
                    BlanketID = (int)cmbBlanketType.SelectedValue,
                    BlanketName = selectedBlanketName,
                    Quantity = (int)nudquantity.Value
                };

                string result = client.Seller_AddStock(stockItem);
                MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshMyStock();
                nudquantity.Value = 1; // Reset form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvMyStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a stock item to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedStock = dgvMyStock.SelectedRows[0].DataBoundItem as Stock;
                if (selectedStock != null)
                {
                    int newQuantity = (int)nudquantity.Value;
                    string result = client.Seller_UpdateStock(selectedStock.StockID, newQuantity);
                    MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshMyStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvMyStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a stock item to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedStock = dgvMyStock.SelectedRows[0].DataBoundItem as Stock;
            if (selectedStock != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete '{selectedStock.BlanketName}' from your stock?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        string result = client.Seller_DeleteStock(selectedStock.StockID);
                        MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshMyStock();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            // Empty - required by designer
        }

        private void cmbrequestOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset order quantity when blanket type changes
            if (cmbrequestOrder.Focused)
            {
                nudquantityOrder.Value = 1;
            }
        }

        private void nudquantityOrder_ValueChanged(object sender, EventArgs e)
        {
            // Empty - required by designer
        }

        private void btnplceorder_Click(object sender, EventArgs e)
        {
            if (cmbrequestOrder.SelectedValue == null)
            {
                MessageBox.Show("Please select a blanket type to order.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudquantityOrder.Value <= 0)
            {
                MessageBox.Show("Please enter a valid order quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Place order for {nudquantityOrder.Value} units of {cmbrequestOrder.Text}?",
                "Confirm Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int sellerId = UserContext.SellerID;
                    string sellerName = UserContext.SellerName;

                    if (string.IsNullOrEmpty(sellerName))
                    {
                        MessageBox.Show("Seller information not available. Please log in again.", "Error");
                        return;
                    }

                    string blanketName = cmbrequestOrder.Text; // Adjust if needed

                    var order = new Order
                    {
                        SellerID = sellerId,
                        SellerName = sellerName,
                        BlanketID = (int)cmbrequestOrder.SelectedValue,
                        BlanketName = blanketName,
                        Quantity = (int)nudquantityOrder.Value,
                        OrderDate = DateTime.Now,
                        Status = "Pending"
                    };

                    string result = client.Seller_PlaceOrder(order);
                    MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOrderHistory();
                    nudquantityOrder.Value = 1; // Reset form
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error placing order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrderHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Empty - required by designer
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            // Empty - required by designer
        }

        private void RefreshHistory_Click(object sender, EventArgs e)
        {
            RefreshOrderHistory();
            MessageBox.Show("Order history refreshed.", "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}