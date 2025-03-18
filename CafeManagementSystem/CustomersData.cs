using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CafeManagementSystem
{
    internal class CustomersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        public int CustomerID { set; get; }
        public string TotalPrice { set; get; }
        public string Amount { set; get; }
        public string Change { set; get; }
        public string Date { set; get; }

        public List<CustomersData> allCustomersData()
        {
            List<CustomersData> listData = new List<CustomersData>();

            if(connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM customers";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CustomersData cData = new CustomersData();

                            cData.CustomerID = (int)reader["customer_id"];
                            cData.TotalPrice = reader["total_price"].ToString();
                            cData.Amount = reader["amount"].ToString();
                            cData.Change = reader["change"].ToString();
                            cData.Date = reader["date"].ToString();

                            listData.Add(cData);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex);
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
