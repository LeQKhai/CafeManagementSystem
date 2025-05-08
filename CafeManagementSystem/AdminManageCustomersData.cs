using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.CodeDom;

namespace CafeManagementSystem
{
    internal class AdminManageCustomersData
    {
        SqlConnection cnStr = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateRegistered { get; set; }

        public List<AdminManageCustomersData> GetCustomers()
        {
            List<AdminManageCustomersData> customers = new List<AdminManageCustomersData>();
            cnStr.Open();
            string selectData = "SELECT * FROM customers";
            using (SqlCommand cmd = new SqlCommand(selectData, cnStr))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AdminManageCustomersData cus = new AdminManageCustomersData();
                    cus.ID = (int)reader["id"];
                    cus.Name = reader["name"].ToString();
                    cus.Phone = reader["phone"].ToString();
                    cus.Email = reader["email"].ToString();
                    cus.Address = reader["address"].ToString();
                    cus.DateRegistered = Convert.ToDateTime(reader["date_registered"]);
                    customers.Add(cus);
                }
            }
            cnStr.Close();
            return customers;
        }

        public void AddCustomer(string name, string phone, string email, string address)
        {
            cnStr.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO customers (name, phone, email, address, date_registered) VALUES (@name, @phone, @email, @address, GETDATE())", cnStr))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.ExecuteNonQuery();
            }
            cnStr.Close();
        }

        public void UpdateCustomer(int id, string name, string phone, string email, string address)
        {
            cnStr.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE customers SET name=@name, phone=@phone, email=@email, address=@address WHERE id=@id", cnStr))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.ExecuteNonQuery();
            }
            cnStr.Close();
        }
    }
}
