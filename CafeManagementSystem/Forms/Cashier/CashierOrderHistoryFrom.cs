using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class CashierOrderHistoryFrom : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        public CashierOrderHistoryFrom()
        {
            InitializeComponent();
            displayOrders();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayOrders();
        }

        public void displayOrders()
        {
            OrderData cData = new OrderData();
            List<OrderData> listData = cData.allOrdersData();

            dgvOders.DataSource = listData;
        }

        private void CashierCustomerForm_customerTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOders.Rows[e.RowIndex];

                int? cusID = row.Cells["CusID"].Value == DBNull.Value ? (int?)null : int.Parse(row.Cells["OrderID"].Value.ToString());
                int orderID = int.Parse(row.Cells["OrderID"].Value.ToString());
                tbCusName.Text = "Khách lẻ";
                tbTotalPrice.Text = row.Cells["TotalPrice"].Value.ToString();
                tbAmount.Text = row.Cells["Amount"].Value.ToString();
                tbChange.Text = row.Cells["Change"].Value.ToString();
                tbDate.Text = row.Cells["OrderDate"].Value.ToString();

                if (cusID.HasValue)
                {
                    try
                    {
                        if (connect.State == ConnectionState.Closed) connect.Open();
                        string query = "SELECT full_name from customers WHERE cus_id = @CusID";

                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@CusID", cusID);
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                tbCusName.Text = reader["full_name"].ToString();
                            }
                        }

                        connect.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi hiển thị chi tiết đơn hàng " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else tbCusName.Text = "";


                try
                {
                    if (connect.State == ConnectionState.Closed) connect.Open();

                    string query = "SELECT p.prod_name, p.prod_price, od.qty " +
                                   "FROM order_details od JOIN products p ON od.prod_id = p.prod_id " +
                                   "WHERE od.order_id = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        DataTable table = new DataTable();
                        table.Load(reader);

                        dgvListProd.DataSource = table;

                        dgvListProd.AllowUserToAddRows = false;           // Không cho thêm dòng mới
                        dgvListProd.ReadOnly = true;                      // Không cho chỉnh sửa nội dung
                        dgvListProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvListProd.MultiSelect = false;                  // Chọn một dòng mỗi lần

                        // Hiển thị lưới 
                        dgvListProd.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        dgvListProd.GridColor = Color.Gray;
                        dgvListProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
