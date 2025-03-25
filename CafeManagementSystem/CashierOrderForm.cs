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
using System.Drawing.Printing;

namespace CafeManagementSystem
{
    public partial class CashierOrderForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        private object selectedValue;
        private int idGen = 0;
        private float totalPrice;
        private int rowIndex = 0;
        public static int getCusID;

        public object SelectedValue { get; private set; }

        public CashierOrderForm()
        {
            InitializeComponent();

            displayAvailableProds();
            //displayAllOrders();
            displayTotalPrice();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAvailableProds();
            //displayAllOrders();
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
            //IDGenerator();
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT SUM(prod_price) FROM order_details WHERE order_id = @orderID";
                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@orderID", idGen);
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalPrice = Convert.ToSingle(result);

                            CashierOrderForm_orderPrice.Text = totalPrice.ToString();
                        }
                    }
                }
                catch (SqlException ex)
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

                        string insertOrder = "INSERT INTO order_details (order_id, prod_id, prod_name, prod_type, prod_price, qty, order_date)" +
                            "VALUES (@orderID, @prodID, @prodName, @prodType, @prodPrice, @qty, @orderDate)";

                        DateTime today = DateTime.Today;
                        using(SqlCommand cmd = new SqlCommand(insertOrder, connect))
                        {
                            cmd.Parameters.AddWithValue("@orderID", idGen);
                            cmd.Parameters.AddWithValue("@prodID", CashierOrderForm_productID.Text.Trim());
                            cmd.Parameters.AddWithValue("@prodName", CashierOrderForm_prodName.Text.Trim());
                            cmd.Parameters.AddWithValue("@prodType", CashierOrderForm_type.Text.Trim());
                            cmd.Parameters.AddWithValue("@qty", CashierOrderForm_quantity.Value);
                            cmd.Parameters.AddWithValue("@orderDate", today);

                            float totalPrice = getPrice * (int)CashierOrderForm_quantity.Value;
                            cmd.Parameters.AddWithValue("@prodPrice", totalPrice);

                            cmd.ExecuteNonQuery();

                            displayAllOrders();
                            
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            displayTotalPrice();
        }

        public void IDGenerator()
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
            {
                connect.Open();
                string selectID = "SELECT MAX(order_id) FROM order_details";

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
                if(MessageBox.Show("Are you sure?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(connect.State == ConnectionState.Closed)
                    {
                        try
                        {
                            connect.Open();

                            IDGenerator();

                            string insertData = "INSERT INTO orders (order_id, total_price, amount, change, date)" +
                                "VALUES(@orderID, @totalPrice, @amount, @change, @date)";

                            DateTime today = DateTime.Today;

                            using(SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@orderID", idGen);
                                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                                cmd.Parameters.AddWithValue("@amount", CashierOrderForm_amount.Text);
                                cmd.Parameters.AddWithValue("@change", CashierOrderForm_change.Text);
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Paid successfully!", "Infomation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CashierOrderForm_orderPrice.Text = "";
                                CashierOrderForm_amount.Text = "";
                                CashierOrderForm_change.Text = "";
                                CashierOrderForm_orderTable.DataSource = null;
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
            displayTotalPrice();
        }


        private void CashierOrderForm_receiptBtn_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            displayTotalPrice();

            float y = 0;
            int count = 0;
            int colWidth = 120;
            int headerMargin = 10;
            int tableMargin = 20;

            Font font = new Font("Arial", 12);
            Font bold = new Font("Arial", 12, FontStyle.Bold);
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font labelFont = new Font("Arial", 14, FontStyle.Bold);

            float margin = e.MarginBounds.Top;

            StringFormat alignCenter = new StringFormat();
            alignCenter.Alignment = StringAlignment.Center;
            alignCenter.LineAlignment = StringAlignment.Center;

            string headerText = "Cafe Shop";
            y = (margin + count * headerFont.GetHeight(e.Graphics) + headerMargin);
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left
                + (CashierOrderForm_orderTable.Columns.Count / 2) * colWidth, y, alignCenter);

            count++;
            y += tableMargin;

            string[] header = { "OID", "ProdID", "ProdName", "ProdType", "Qty", "Price" };

            for (int i = 0; i < header.Length; i++)
            {
                y = margin + count * bold.GetHeight(e.Graphics) + tableMargin;
                e.Graphics.DrawString(header[i], bold, Brushes.Black, e.MarginBounds.Left + i * colWidth, y, alignCenter);
            }
            count++;

            float rSpace = e.MarginBounds.Bottom - y;

            while (rowIndex < CashierOrderForm_orderTable.Rows.Count)
            {
                DataGridViewRow row = CashierOrderForm_orderTable.Rows[rowIndex];

                for (int i = 0; i < CashierOrderForm_orderTable.Columns.Count; i++)
                {
                    object cellValue = row.Cells[i].Value;
                    string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    y = margin + count * font.GetHeight(e.Graphics) + tableMargin;
                    e.Graphics.DrawString(cell, font, Brushes.Black, e.MarginBounds.Left + i * colWidth, y, alignCenter);
                }
                count++;
                rowIndex++;

                if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            int labelMargin = (int)Math.Min(rSpace, 200);

            DateTime today = DateTime.Now;

            float labelX = e.MarginBounds.Right - e.Graphics.MeasureString("------------------------------", labelFont).Width;

            y = e.MarginBounds.Bottom - labelMargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("Total Price: \t$" + totalPrice + "\nAmount: \t$"
                + CashierOrderForm_amount.Text + "\n\t\t------------\nChange: \t$" + CashierOrderForm_change.Text, labelFont, Brushes.Black, labelX, y);

            labelMargin = (int)Math.Min(rSpace, -40);

            string labelText = today.ToString();
            y = e.MarginBounds.Bottom - labelMargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(labelText, labelFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString("------------------------------", labelFont).Width, y);
        }
    }
}
