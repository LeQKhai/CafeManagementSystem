using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CafeManagementSystem
{
    public partial class CashierOrderForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        private object selectedValue;
        private int idGen = 0;
        private float totalPrice;
        public static int getCusID;

        public object SelectedValue { get; private set; }

        public CashierOrderForm()
        {
            InitializeComponent();

            displayAvailableProds();
            displayAllOrders();
            displayTotalPrice();
        }
        public void displayAvailableProds()
        {
            CashierOrderFormProdData allProds = new CashierOrderFormProdData();

            List<CashierOrderFormProdData> listData = allProds.availableProductsData();

            CashierOrderForm_menuTable.DataSource = listData;
        }

        public void displayAllOrders()
        {
            CashierOrdersData allOrders = new CashierOrdersData();
            List<CashierOrdersData> listData = allOrders.ordersListData();
            CashierOrderForm_orderTable.DataSource = listData;
        }

        public void displayTotalPrice()
        {
            IDGenerator();
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT SUM(prod_price) FROM orders WHERE customer_id = @cusID";
                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@cusID", idGen);
                        object result = cmd.ExecuteScalar();
                        totalPrice = Convert.ToSingle(result);

                        CashierOrderForm_orderPrice.Text = totalPrice.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool EmptyFields()
        {
            if (CashierOrderForm_type.SelectedIndex == -1 || CashierOrderForm_productID.SelectedIndex == -1
                || CashierOrderForm_prodName.Text == "" || CashierOrderForm_quantity.Value == 0
                || CashierOrderForm_price.Text == "")
            {
                return true;
            }
            return false;
        }

        private void CashierOrderForm_addBtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if(EmptyFields())
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        float getPrice = 0;
                        string selectOrder = "SELECT * FROM products WHERE prod_id = @prodID";

                        using(SqlCommand getOrder = new SqlCommand(selectOrder, connect))
                        {
                            getOrder.Parameters.AddWithValue("@prodID", CashierOrderForm_productID.Text.Trim());

                            using(SqlDataReader reader = getOrder.ExecuteReader())
                            {
                                if(reader.Read())
                                {
                                    object rawValue = reader["prod_price"];
                                    if(rawValue != DBNull.Value)
                                    {
                                        getPrice = Convert.ToSingle(rawValue);
                                    }
                                }
                            }
                        }

                        string insertOrder = "INSERT INTO orders (customer_id, prod_id, prod_name, prod_type, prod_price, qty, order_date)" +
                            "VALUES (@customerID, @prodID, @prodName, @prodType, @prodPrice, @qty, @orderDate)";

                        DateTime today = DateTime.Today;
                        using(SqlCommand cmd = new SqlCommand(insertOrder, connect))
                        {
                            cmd.Parameters.AddWithValue("@customerID", idGen);
                            cmd.Parameters.AddWithValue("@prodID", CashierOrderForm_productID.Text.Trim());
                            cmd.Parameters.AddWithValue("@prodName", CashierOrderForm_prodName.Text.Trim());
                            cmd.Parameters.AddWithValue("@prodType", CashierOrderForm_type.Text.Trim());
                            cmd.Parameters.AddWithValue("@qty", CashierOrderForm_quantity.Value);
                            cmd.Parameters.AddWithValue("@orderDate", today);

                            float totalPrice = getPrice * (int)CashierOrderForm_quantity.Value;
                            cmd.Parameters.AddWithValue("@prodPrice", totalPrice);

                            cmd.ExecuteNonQuery();

                            displayAllOrders();
                            displayTotalPrice();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Connection failed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        public void IDGenerator()
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
            {
                connect.Open();
                string selectID = "SELECT MAX(customer_id) FROM customers";

                using(SqlCommand cmd = new SqlCommand(selectID, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if(result != DBNull.Value)
                    {
                        int temp = Convert.ToInt32(result);
                        if (temp == 0) idGen = 1;
                        else idGen = temp + 1;
                    }
                    else
                    {
                        idGen = 1;
                    }
                    getCusID = idGen;
                }
            }
        }

        private void CashierOrderForm_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            CashierOrderForm_productID.SelectedIndex = -1;
            CashierOrderForm_productID.Items.Clear();
            CashierOrderForm_prodName.Text = "";
            CashierOrderForm_price.Text = "";

            string SelectedVailue = CashierOrderForm_type.SelectedItem as string;

            if (SelectedVailue != null)
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        connect.Open();

                        string selectData = $"SELECT * FROM products WHERE prod_type = '{SelectedVailue}' AND prod_status = @status AND date_delete IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string value = reader["prod_id"].ToString();

                                    CashierOrderForm_productID.Items.Add(value);
                                }
                            }
                        }
                    }

                }
                catch (Exception exx)
                {
                    MessageBox.Show("Error: " + exx, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CashierOrderForm_productID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedVailue = CashierOrderForm_productID.SelectedItem as string;

            if (SelectedVailue != null)
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        connect.Open();

                        string selectData = $"SELECT * FROM products WHERE prod_id = '{SelectedVailue}' AND prod_status = @status AND date_delete IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string prodName = reader["prod_name"].ToString();
                                    string prodPrice = reader["prod_price"].ToString();

                                    CashierOrderForm_prodName.Text = prodName;
                                    CashierOrderForm_price.Text = prodPrice;

                                }
                            }
                        }
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void CashierOrderForm_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(CashierOrderForm_amount.Text);
                    float getChange = (getAmount - totalPrice);

                    if(getChange <= -1)
                    {
                        CashierOrderForm_amount.Text = "";
                        CashierOrderForm_change.Text = "";
                    }
                    else 
                        CashierOrderForm_change.Text = getChange.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CashierOrderForm_payBtn_Click(object sender, EventArgs e)
        {
            if(CashierOrderForm_amount.Text == "" || CashierOrderForm_orderTable.Rows.Count < 0)
            {
                MessageBox.Show("Error when paying", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(MessageBox.Show("Are you sure paying?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(connect.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connect.Open();

                            IDGenerator();
                            displayTotalPrice();

                            string insertData = "INSERT INTO customers (customer_id, total_price, amount, change, date)" +
                                "VALUES(@cusID, @totalPrice, @amount, @change, @date)";

                            DateTime today = DateTime.Today;

                            using(SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@cusID", idGen);
                                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                                cmd.Parameters.AddWithValue("@amount", CashierOrderForm_amount.Text);
                                cmd.Parameters.AddWithValue("@change", CashierOrderForm_change.Text);
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Paid successfully!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }
    }
}
