using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CafeManagementSystem
{
    internal class OrderData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        public int OrderID { set; get; }
        public string TotalPrice { set; get; }
        public string Amount { set; get; }
        public string Change { set; get; }
        public string Date { set; get; }

        public List<OrderData> allOrdersData()
        {
            List<OrderData> listData = new List<OrderData>();

            if(connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM orders";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            OrderData cData = new OrderData();

                            cData.OrderID = (int)reader["order_id"];
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
