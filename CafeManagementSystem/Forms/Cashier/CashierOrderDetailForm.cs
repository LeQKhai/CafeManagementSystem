using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeManagementSystem.Forms.Cashier
{
    public partial class CashierOrderDetailForm : Form
    {
        private int pagerId;
        public CashierOrderDetailForm(int pagerId)
        {
            InitializeComponent();
            this.pagerId = pagerId;
            LoadOrderDetails();
        }
        private void LoadOrderDetails()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
            {
                conn.Open();
                string query = @"
                    SELECT od.prod_id, p.prod_name, od.qty
                    FROM order_details od
                    JOIN products p ON od.prod_id = p.prod_id
                    JOIN orders o ON od.order_id = o.id
                    JOIN pager_orders po ON o.id = po.order_id
                    WHERE po.pager_id = @PagerID
                    AND o.id = (SELECT MAX(o2.id) 
                                FROM orders o2 
                                JOIN pager_orders po2 ON o2.id = po2.order_id 
                                WHERE po2.pager_id = @PagerID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PagerID", pagerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("prod_id", typeof(string));
                        dt.Columns.Add("prod_name", typeof(string));
                        dt.Columns.Add("qty", typeof(int));
                        while (reader.Read())
                        {
                            dt.Rows.Add(reader["prod_id"], reader["prod_name"], reader["qty"]);
                        }
                        orderDetailGrid.DataSource = dt;
                        orderDetailGrid.Columns["prod_id"].HeaderText = "Product ID";
                        orderDetailGrid.Columns["prod_name"].HeaderText = "Product Name";
                        orderDetailGrid.Columns["qty"].HeaderText = "Quantity";
                    }
                }
            }
        }

        private void readyBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
            {
                conn.Open();
                string updateQuery = "UPDATE Pagers SET Status = 2 WHERE PagerID = @PagerID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PagerID", pagerId);
                    cmd.ExecuteNonQuery();
                }
            }
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}