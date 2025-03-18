using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CafeManagementSystem
{
    public partial class AdminAddProducts : UserControl
    {
        SqlConnection connect= new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        public AdminAddProducts()
        {
            InitializeComponent();

            displayData();

        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayData();
        }

        public bool emptyFields()
        {
            if (adminAddProducts_id.Text == "" || adminAddProducts_name.Text == "" || adminAddProducts_type.SelectedIndex == -1 || adminAddProducts_stock.Text == ""
                || adminAddProducts_price.Text == ""|| adminAddProducts_status.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void displayData()
        {
            AdminAddProductsData prodData = new AdminAddProductsData();
            List<AdminAddProductsData> listData = prodData.productsListData();

            dataGridView1.DataSource = listData;
            dataGridView1.Rows[0].Selected = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminAddUsers_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void adminAddUsers_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void adminAddProducts_addBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Hãy điền đầy đủ tất cả thông tin!", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectProID = "SELECT * FROM products WHERE prod_id= @prodID";

                        using (SqlCommand selectPID = new SqlCommand(selectProID, connect))
                        {
                            selectPID.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(selectPID);

                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                //string usern = adminAddUsers_username.Text.Substring(0, 1).ToUpper() + adminAddUsers_username.Text.Substring(1);
                                MessageBox.Show("Mã sản phẩm: "+ adminAddProducts_id.Text.Trim()+ " đã tồn tại", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                try
                                {
                                    string insertData = "INSERT INTO products (prod_id, prod_name, prod_type," +
                                      "prod_stock, prod_price, prod_status, prod_image, date_insert) VALUES(@prodID, @prodName, @prodType, @prodStock, @prodPrice, @prodStatus, @prodImage, @dateInsert)";



                                    DateTime today = DateTime.Today;
                                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                                    string userDir = Path.Combine(basePath, "Product_Directory");
                                    string path = Path.Combine(userDir, adminAddProducts_id.Text.Trim() + ".jpg");

                                    string directoryPath = Path.GetDirectoryName(path);

                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);

                                    }

                                    File.Copy(adminAddProducts_imageView.ImageLocation, path, true);



                                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                    {
                                        cmd.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());
                                        cmd.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                                        cmd.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                                        cmd.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                                        cmd.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                                        cmd.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                                        cmd.Parameters.AddWithValue("@prodImage", path);
                                        cmd.Parameters.AddWithValue("@dateInsert", today);

                                        cmd.ExecuteNonQuery();

                                        clearFields();

                                        MessageBox.Show("Thêm hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        displayData();

                                    }
                                }
                                catch (System.ArgumentException ex)
                                {
                                    MessageBox.Show("Phải thêm ảnh", "Đã xảy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kết nối thất bại: " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally { connect.Close(); }
                }
            }
        }

        private void adminAddProducts_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png|*.jpg; *.png)";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    adminAddProducts_imageView.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearFields()
        {
            adminAddProducts_id.Text = "";
            adminAddProducts_name.Text = "";
            adminAddProducts_type.SelectedIndex = -1;
            adminAddProducts_stock.Text = "";
            adminAddProducts_price.Text = "";
            adminAddProducts_status.SelectedIndex = -1;
            adminAddProducts_imageView.Image = null;

        }

        private void adminAddProducts_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                adminAddProducts_id.Text= row.Cells[1].Value.ToString();
                adminAddProducts_name.Text = row.Cells[2].Value.ToString();
                adminAddProducts_type.Text = row.Cells[3].Value.ToString();
                adminAddProducts_stock.Text = row.Cells[4].Value.ToString();
                adminAddProducts_price.Text = row.Cells[5].Value.ToString();
                adminAddProducts_status.Text = row.Cells[6].Value.ToString();

                string imagepath = row.Cells[7].Value.ToString();

                try
                {
                    if (imagepath != null)
                    {
                        adminAddProducts_imageView.Image = Image.FromFile(imagepath);
                    }
                    else
                    {
                        adminAddProducts_imageView.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hình ảnh: " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void adminAddProducts_updateBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Hãy điền đầy đủ tất cả thông tin!", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn cập nhật Product ID: " + adminAddProducts_id.Text.Trim()
                    + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE products SET prod_name= @prodName, prod_type= @prodType, prod_stock= @prodStock, prod_price= @prodPrice, " +
                                "prod_status= @prodStatus, date_update= @dateUpdate WHERE prod_id= @prodID";

                            DateTime today = DateTime.Now;

                            using (SqlCommand updateD = new SqlCommand(updateData, connect))
                            {
                                updateD.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                                updateD.Parameters.AddWithValue("@dateUpdate", today);
                                updateD.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                                updateD.ExecuteNonQuery();

                                clearFields();

                                MessageBox.Show("Cập nhật hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayData();


                            }

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Kết nối thất bại " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }

                    }
                }

            }
        }

        private void adminAddProducts_deleteBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Hãy điền đầy đủ tất cả thông tin!", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa Product ID: " + adminAddProducts_id.Text.Trim()
                    + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE products SET date_delete= @dateDelete WHERE prod_id= @prodID";

                            DateTime today = DateTime.Now;

                            using (SqlCommand updateD = new SqlCommand(updateData, connect))
                            {
                                updateD.Parameters.AddWithValue("@dateDelete", today);
                                updateD.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                                updateD.ExecuteNonQuery();

                                clearFields();

                                MessageBox.Show("Xóa hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayData();


                            }

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Kết nối thất bại " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
