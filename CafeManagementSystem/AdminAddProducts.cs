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
        SqlConnection connect= new SqlConnection(@"");
        public AdminAddProducts()
        {
            InitializeComponent();
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
                                string insertData = "INSERT INTO products (prod_id, prod_name, prod_type," + 
                                      "prod_stock, prod_price, prod_status, prod_image, date_insert) VALUES(@prodID, @prodName, @prodType, @prodStock, @prodPrice, @prodStatus, @prodImage, @dateInsert)";



                                DateTime today = DateTime.Today;

                                //string path = Path.Combine(@"E:\CafeManagementSystem\CafeManagementSystem\User_Directory\"
                                //+ adminAddUsers_username.Text.Trim() + ".jpg");

                                //string directoryPath = Path.GetDirectoryName(path);

                                //if (!Directory.Exists(directoryPath))
                                //{
                                //    Directory.CreateDirectory(directoryPath);

                                //}

                                //File.Copy(adminAddUsers_imageView.ImageLocation, path, true);



                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                                    cmd.Parameters.AddWithValue("@prodImage", "image path");
                                    cmd.Parameters.AddWithValue("@dateInsert", today);

                                    cmd.ExecuteNonQuery();

                                    //clearFields();

                                    //MessageBox.Show("Thêm hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //displayAddUsersData();

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
    }
}
