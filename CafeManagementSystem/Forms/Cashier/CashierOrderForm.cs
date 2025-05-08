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
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace CafeManagementSystem
{
    public partial class CashierOrderForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        private object selectedValue;
        private int idGen = 0;
        private float totalPrice;
        float discount = 0;
        int usedPoints = 0;
        private int rowIndex = 0;
        public static int getOrderID;
        public static int cusID = -1;
        public static int points = 0;

        public object SelectedValue { get; private set; }

        public CashierOrderForm()
        {
            InitializeComponent();

            displayAvailableProds();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAvailableProds();
        }

        public void displayAvailableProds()
        {
            CashierOrderFormProdData allProds = new CashierOrderFormProdData();

            List<CashierOrderFormProdData> listData = allProds.availableProductsData();

            CashierOrderForm_menuTable.DataSource = listData;
        }

        public void displayTotalPrice(float discount)
        {
            float total = 0;

            foreach (DataGridViewRow row in CashierOrderForm_orderTable.Rows)
            {
                // Kiểm tra dòng hợp lệ (tránh dòng mới chưa nhập)
                if (row.Cells["total"].Value != null)
                {
                    float price = 0;
                    float.TryParse(row.Cells["total"].Value.ToString(), out price);
                    total += price;
                }
            }

            totalPrice = total - discount;
            CashierOrderForm_orderPrice.Text = totalPrice.ToString("N0");
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
                        string prodID = CashierOrderForm_productID.Text.Trim();
                        int qty = (int)CashierOrderForm_quantity.Value;

                        string selectQuery = "SELECT prod_name, prod_type, prod_price FROM products WHERE prod_id = @prodID";
                        string prodName = "", prodType = "";
                        float unitPrice = 0;

                        using (SqlCommand cmd = new SqlCommand(selectQuery, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodID", prodID);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    prodName = reader["prod_name"].ToString();
                                    prodType = reader["prod_type"].ToString();
                                    float.TryParse(reader["prod_price"].ToString(), out unitPrice);
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                        float total = unitPrice * qty;
                        DateTime today = DateTime.Today;
                       
                        CashierOrderForm_orderTable.Rows.Add(
                            prodID,         
                            prodName,
                            prodType,
                            unitPrice,
                            qty,
                            total
                        );
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
            displayTotalPrice(0);
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

        // enter tiền nhận vào -> tính tiền thừa
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
                        CashierOrderForm_change.Text = getChange.ToString("N0");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // handle nút thanh toán
        private void CashierOrderForm_payBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CashierOrderForm_amount.Text) || CashierOrderForm_orderTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền khách đưa và chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(connect.State == ConnectionState.Closed) connect.Open();

                try
                {
                    //int usedPoints = 0;
                    //String temp = tbPointsUse.Text.Trim();
                    //if(temp != "") usedPoints = int.Parse(tbPointsUse.Text.Trim());
                    

                    

                    DateTime today = DateTime.Today;
                    float amount = float.Parse(CashierOrderForm_amount.Text);
                    float change = float.Parse(CashierOrderForm_change.Text);


                    //discount = usedPoints * 1000f;
                    //totalPrice -= discount;
                    

                    // tạo order -> trả về order_id
                    string insertOrder = "INSERT INTO orders (cus_id, total_price, order_date, amount, change) " +
                                         "OUTPUT INSERTED.id " +
                                         "VALUES (@cus_id, @total_price, @order_date, @amount, @change)";

                    int insertedOrderID = 0;
                    using (SqlCommand cmd = new SqlCommand(insertOrder, connect))
                    {
                        cmd.Parameters.AddWithValue("@cus_id", cusID); 
                        cmd.Parameters.AddWithValue("@total_price", totalPrice);
                        cmd.Parameters.AddWithValue("@order_date", today);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@change", change);

                        insertedOrderID = (int)cmd.ExecuteScalar();
                    }

                    
                    // lặp qua DataGridView và tạo các order_details
                    foreach (DataGridViewRow row in CashierOrderForm_orderTable.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string prodID = row.Cells["prod_id"].Value.ToString();
                        int qty = Convert.ToInt32(row.Cells["qty"].Value);

                        string insertDetail = "INSERT INTO order_details (order_id, prod_id, qty) VALUES (@orderID, @prodID, @qty)";

                        using (SqlCommand detailCmd = new SqlCommand(insertDetail, connect))
                        {
                            detailCmd.Parameters.AddWithValue("@orderID", insertedOrderID);
                            detailCmd.Parameters.AddWithValue("@prodID", prodID);
                            detailCmd.Parameters.AddWithValue("@qty", qty);

                            detailCmd.ExecuteNonQuery();
                        }
                    }

                    // tích điểm
                    int earnedPoints = (int)(totalPrice / 10000);
                    int updatedPoints = points - usedPoints + earnedPoints;
                    string updateQuery = "UPDATE customers SET points = @points WHERE cus_id = @cusID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@points", updatedPoints);
                        cmd.Parameters.AddWithValue("@cusID", cusID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset UI
                    CashierOrderForm_orderPrice.Text = "";
                    CashierOrderForm_amount.Text = "";
                    CashierOrderForm_change.Text = "";
                    CashierOrderForm_orderTable.Rows.Clear();
                    cusID = -1;
                    points = 0;
                    discount = 0;
                    usedPoints = 0;
                    tbCusName.Text = "";
                    tbPhone.Text = "";
                    tbPoints.Text = "";
                    tbPointsUse.Text = "";
                    tbPointsUse.Enabled = false;

                    totalPrice = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

                displayTotalPrice(discount); 
            }
        }

        // click nút in hoá đơn
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

        // handle in hoá đơn
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            displayTotalPrice(0);

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

        private void CashierOrderForm_Load(object sender, EventArgs e)
        {
            CashierOrderForm_orderTable.Columns.Clear();

            CashierOrderForm_orderTable.Columns.Add("prod_id", "Product ID");
            CashierOrderForm_orderTable.Columns.Add("prod_name", "Product Name");
            CashierOrderForm_orderTable.Columns.Add("prod_type", "Product Type");
            CashierOrderForm_orderTable.Columns.Add("prod_price", "Unit Price");
            CashierOrderForm_orderTable.Columns.Add("qty", "Quantity");
            CashierOrderForm_orderTable.Columns.Add("total", "Total");
        }

        // click item -> hiển thị thông tin
        private void CashierOrderForm_menuTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải header
            {
                DataGridViewRow selectedRow = CashierOrderForm_menuTable.Rows[e.RowIndex];
                string selectedProductId = selectedRow.Cells["ProductID"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "SELECT * FROM products WHERE prod_id = @ProductId AND prod_status = @status";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ProductId", selectedProductId);
                    cmd.Parameters.AddWithValue("@status", "Available");

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string prodName = reader["prod_name"].ToString();
                        string prodPrice = reader["prod_price"].ToString();
                        string prodType = reader["prod_type"].ToString();

                        CashierOrderForm_prodName.Text = prodName;
                        CashierOrderForm_price.Text = prodPrice;
                        CashierOrderForm_type.SelectedItem = prodType;
                        CashierOrderForm_productID.SelectedItem = selectedProductId;
                    }

                }
            }
        }

        // enter phone tích điểm
        private void tbPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string phone = tbPhone.Text.Trim();

                if(phone.Length == 0)
                {
                    cusID = -1;
                    points = 0;
                    tbCusName.Text = "";
                    tbPoints.Text = "";
                    tbPointsUse.Text = "";
                    tbPointsUse.Enabled = false;
                    return;
                }

                // regex chỉ chứa số và dài 10-12 ký tự
                if (!Regex.IsMatch(phone, @"^\d{10,12}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPhone.Focus();
                    tbPhone.SelectAll();
                    return;
                }

                try
                {
                   using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "SELECT * FROM customers WHERE phone = @Phone";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Phone", phone);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            cusID = (int)reader["cus_id"];
                            points = (int)reader["points"];

                            tbCusName.Text = reader["full_name"].ToString();
                            tbPoints.Text = points.ToString();
                            tbPointsUse.Enabled = true;
                        }
                        else
                        {
                            cusID = -1;
                            points = 0;
                            tbCusName.Text = "";
                            tbPoints.Text = "";
                            tbPointsUse.Text = "";
                            tbPointsUse.Enabled = false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbPointsUse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    String temp = tbPointsUse.Text.Trim();
                    if (temp != "") usedPoints = int.Parse(tbPointsUse.Text.Trim());
                    else usedPoints = 0;

                    if (usedPoints < 20 && usedPoints > 0)
                    {
                        MessageBox.Show("Cần ít nhất 20 điểm cho mỗi đơn hàng thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (usedPoints < 0)
                    {
                        MessageBox.Show("Số điểm phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (usedPoints > points)
                    {
                        MessageBox.Show("Không đủ điểm để sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (usedPoints > totalPrice / 1000)
                    {
                        MessageBox.Show("Số điểm vượt quá tổng hoá đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    discount = usedPoints * 1000f;
                    displayTotalPrice(discount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid value!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbPromoCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string promoCode = tbPromoCode.Text.Trim();

                try
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();

                        string query = "SELECT * FROM promotions WHERE code = @Code AND is_active = 1 " +
                            "AND GETDATE() BETWEEN start_date AND end_date";
                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@Code", promoCode);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int discount_per = (int)reader["discount_percent"];
                                    
                                    tbPercent.Text = discount_per.ToString();
                                    discount = (totalPrice * discount_per)/100;
                                    displayTotalPrice(discount);
                                }
                                else
                                {
                                    MessageBox.Show("Mã khuyến mãi không đúng hoặc hết hạn sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tbPercent.Text = "";
                                    discount = 0;
                                }
                            }
                        }

                        connect.Close();
                    }      
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
