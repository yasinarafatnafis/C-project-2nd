using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project.Client
{
    public partial class Order_details : Form
    {
        private readonly DataAccess dataAccess = new DataAccess();

        public Order_details()
        {
            InitializeComponent();
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                string query = $@"
SELECT
    o.OrderId,
    i.ItemName      AS [Item],
    i.Quality,
    i.Quantity,
    i.PricePerUnit  AS [Unit Price],
    i.LineTotal     AS [Total],
    o.Deadline,
    o.OrderDate,
    o.Status,
    o.Payable,
    o.Payment,
    o.PaymentDate
FROM OfficeManagement.dbo.Orders o
LEFT JOIN OfficeManagement.dbo.OrderItems i
    ON o.OrderId = i.OrderId
WHERE o.UserId = '{Session.UserId}'
ORDER BY o.OrderDate DESC, o.OrderId DESC;";

                DataTable orderData = dataAccess.ExecuteQueryTable(query);
                dataGridView1.DataSource = orderData;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Client_Dash client_Dash = new Client_Dash();
            client_Dash.Show();
            this.Hide();
        }

        private void Order_details_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            
        }
    }
}
