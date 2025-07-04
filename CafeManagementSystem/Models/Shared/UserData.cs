﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CafeManagementSystem
{
    internal class UserData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");

        public int ID { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public string Image { get; set; }
        public string DateRegistered { get; set; }

        public List<UserData> UsersListData()
        {
            List<UserData> listData = new List<UserData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM users";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read()) { 
                           UserData userData = new UserData();
                            userData.ID = (int)reader["id"];
                            userData.Username = reader["username"].ToString();
                            userData.Password = reader["password"].ToString();
                            userData.Role = reader["role"].ToString();
                            userData.Status = reader["status"].ToString();
                            userData.Image = reader["profile_image"].ToString();
                            userData.DateRegistered = reader["date_reg"].ToString();

                            listData.Add(userData);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Kết nối thất bại: " + ex);
                }
                finally
                { 
                    connect.Close();
                }
            }
            return listData;
        }
    }
}
