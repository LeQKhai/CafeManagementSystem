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
    internal class CustomerData
    {
        SqlConnection cnStr = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateRegistered { get; set; }
        public int Point { get; set; }

        public List<CustomerData> GetCustomers()
        {
            List<CustomerData> customers = new List<CustomerData>();
            cnStr.Open();
            string selectData = "SELECT * FROM customers";
            using (SqlCommand cmd = new SqlCommand(selectData, cnStr))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerData cus = new CustomerData();
                    cus.ID = (int)reader["cus_id"];
                    cus.Name = reader["full_name"].ToString();
                    cus.Phone = reader["phone"].ToString();
                    cus.Email = reader["email"].ToString();
                    cus.Address = reader["address"].ToString();
                    cus.DateRegistered = Convert.ToDateTime(reader["date_registered"]);
                    cus.Point = (int)reader["points"];
                    customers.Add(cus);
                }
            }
            cnStr.Close();
            return customers;
        }

        public void AddCustomer(string name, string phone, string email, string address)
        {
            cnStr.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO customers (full_name, phone, email, address, date_registered) VALUES (@name, @phone, @email, @address, GETDATE())", cnStr))
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
            using (SqlCommand cmd = new SqlCommand("UPDATE customers SET full_name=@name, phone=@phone, email=@email, address=@address WHERE id=@id", cnStr))
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
