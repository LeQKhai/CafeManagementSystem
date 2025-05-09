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
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace CafeManagementSystem
{
    public partial class AdminManageCustomersForm : UserControl
    {
        string cnStr = @"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True";
        public AdminManageCustomersForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(cnStr))
            {
                try
                {
                    AdminManageCustomersData cusData = new AdminManageCustomersData();
                    List<AdminManageCustomersData> listData = cusData.GetCustomers();

                    dgvCustomers.DataSource = listData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void btnSaveCustomers_Click(object sender, EventArgs e)
        {
            if (!IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số có đúng 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng email (ví dụ: abc@example.com).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Customers (full_name, phone, email, address, date_registered) VALUES (@name, @phone, @email, @address, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Khách hàng đã được lưu thành công!");
                        LoadCustomers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu khách hàng: " + ex.Message);
                }
            }
        }

        private void btnUpdateCustomers_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];

                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE Customers SET full_name=@name, phone=@phone, email=@email, address=@address WHERE id=@id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", row.Cells["ID"].Value);
                            cmd.Parameters.AddWithValue("@name", row.Cells["Name"].Value);
                            cmd.Parameters.AddWithValue("@phone", row.Cells["Phone"].Value);
                            cmd.Parameters.AddWithValue("@email", row.Cells["Email"].Value);
                            cmd.Parameters.AddWithValue("@address", row.Cells["Address"].Value);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thông tin khách hàng đã được cập nhật!");
                            LoadCustomers();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật!");
            }
        }

        private void btnDeleteCustomers_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(row.Cells["ID"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM Customers WHERE id=@id";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", customerId);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Khách hàng đã được xóa!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                        }
                    }
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa!");
            }
        }

        private void AdminManageCustomersForm_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
