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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CafeManagementSystem
{
    public partial class AdminAddUsersForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");

        public AdminAddUsersForm()
        {
            InitializeComponent();

            displayAddUsersData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAddUsersData();
        }

        public void displayAddUsersData()
        {
            UserData usersData = new UserData();
            List<UserData> listData = usersData.UsersListData();

            dataGridView1.DataSource = listData;
            dataGridView1.Rows[0].Selected = false;
        }
        public bool emptyFields()
        {
            if (adminAddUsers_username.Text == "" || adminAddUsers_password.Text == "" || adminAddUsers_role.Text == "" || adminAddUsers_status.Text == ""
                || adminAddUsers_imageView == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void adminAddUsers_addBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Hãy điền đầy đủ tất cả thông tin!", "Đã xảy ra lỗi!" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectUsern = "SELECT * FROM users WHERE username= @usern";

                        using (SqlCommand checkUsern = new SqlCommand(selectUsern, connect))
                        {
                            checkUsern.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsern);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 1)
                            {
                                string usern = adminAddUsers_username.Text.Substring(0, 1).ToUpper() + adminAddUsers_username.Text.Substring(1);
                                MessageBox.Show(usern + " đã tồn tại!", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                try
                                {
                                    string insertData = "INSERT INTO users (username, password, profile_image, role, status, date_reg)" +
                                "VALUES(@usern, @pass, @image, @role, @status, @date)";

                                    DateTime today = DateTime.Today;
                                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                                    string userDir = Path.Combine(basePath, "User_Directory");
                                    string path = Path.Combine(userDir, adminAddUsers_username.Text.Trim() + ".jpg");

                                    string directoryPath = Path.GetDirectoryName(path);

                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);

                                    }

                                    File.Copy(adminAddUsers_imageView.ImageLocation, path, true);

                                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                    {
                                        cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                                        cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                                        cmd.Parameters.AddWithValue("@image", path);
                                        cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                                        cmd.Parameters.AddWithValue("@status", adminAddUsers_status.Text.Trim());
                                        cmd.Parameters.AddWithValue("@date", today);

                                        cmd.ExecuteNonQuery();

                                        clearFields();

                                        MessageBox.Show("Thêm hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        displayAddUsersData();

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png|*.jpg; *.png)";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    adminAddUsers_imageView.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int id = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //userData.ID = (int)reader["id"];
            //userData.Username = reader["username"].ToString();
            //userData.Password = reader["password"].ToString();
            //userData.Role = reader["role"].ToString();
            //userData.Status = reader["status"].ToString();
            //userData.Image = reader["profile_image"].ToString();
            //userData.DateRegistered = reader["date_reg"].ToString();

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            id= (int)row.Cells[0].Value;
            adminAddUsers_username.Text = row.Cells[1].Value.ToString();
            adminAddUsers_password.Text = row.Cells[2].Value.ToString();
            adminAddUsers_role.Text = row.Cells[3].Value.ToString();
            adminAddUsers_status.Text = row.Cells[4].Value.ToString();

            string imagePath = row.Cells[5].Value.ToString();
            try
            {
                if (imagePath != null && imagePath != "")
                {
                        adminAddUsers_imageView.Image = Image.FromFile(imagePath);
                }
                else
                {
                    string root = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string filename = Path.Combine(root, "Assets", "no-image.png");
                    adminAddUsers_imageView.Image = Image.FromFile(filename);
                }
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show("Không có ảnh " + ex, "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void adminAddUsers_updateBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Hãy điền đầy đủ tất cả thông tin!", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật Username: " + adminAddUsers_username.Text.Trim()
                    + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) 
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE users SET username= @usern, password= @pass, role= @role, status= @status, profile_image = @path WHERE id= @id ";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                                string userDir = Path.Combine(basePath, "User_Directory");
                                string path = Path.Combine(userDir, adminAddUsers_username.Text.Trim() + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);

                                }

                                File.Copy(adminAddUsers_imageView.ImageLocation, path, true);


                                cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", adminAddUsers_status.Text.Trim());
                                cmd.Parameters.AddWithValue("@path", path);
                                cmd.Parameters.AddWithValue("@id", id);

                                cmd.ExecuteNonQuery();

                                clearFields();

                                MessageBox.Show("Thêm hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayAddUsersData();


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

        public void clearFields()
        {
            adminAddUsers_username.Text = "";
            adminAddUsers_password.Text = "";
            adminAddUsers_role.SelectedIndex = -1;
            adminAddUsers_status.SelectedIndex = -1;
            adminAddUsers_imageView.Image = null;
        }

        private void adminAddUsers_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void adminAddUsers_deleteBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Hãy điền đầy đủ tất cả thông tin!", "Đã xảy ra lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Username: " + adminAddUsers_username.Text.Trim()
                    + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM users WHERE id= @id ";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", id);

                                cmd.ExecuteNonQuery();

                                clearFields();

                                MessageBox.Show("Xóa hoàn tất!", "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayAddUsersData();


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

        private void AdminAddUsers_Load(object sender, EventArgs e)
        {

        }

        private void adminAddUsers_imageView_Click(object sender, EventArgs e)
        {

        }
    }
}
