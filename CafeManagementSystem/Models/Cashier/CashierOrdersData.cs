using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CafeManagementSystem
{
    internal class CashierOrdersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        public int CID { set; get; }
        public string ProdID { set; get; }
        public string ProdName { set; get; }
        public string ProdType { set; get; }
        public int Qty { set; get; }
        public string Price { set; get; }

        public List<CashierOrdersData> ordersListData()
        {
            List<CashierOrdersData> listData = new List<CashierOrdersData>();

            if(connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    int cusID = 0;
                    string selectCusData = "SELECT MAX(order_id) FROM order_details";
                    using (SqlCommand getOderDetailsData = new SqlCommand(selectCusData, connect))
                    {
                        object result = getOderDetailsData.ExecuteScalar();
                        if(result != DBNull.Value)
                        {
                            int temp = Convert.ToInt32(result);
                            if (temp == 0)
                                cusID = 1;
                            else 
                                cusID = temp;
                        }
                    }

                    string selectData = "SELECT * FROM order_details WHERE order_id = @orderID";
                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@orderID", cusID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                CashierOrdersData ordersData = new CashierOrdersData();

                                ordersData.CID = (int)reader["order_id"];
                                ordersData.ProdID = reader["prod_id"].ToString();
                                ordersData.ProdName = reader["prod_name"].ToString();
                                ordersData.ProdType = reader["prod_type"].ToString();
                                ordersData.Qty = (int)reader["qty"];
                                ordersData.Price = reader["prod_price"].ToString();

                                listData.Add(ordersData);
                            }
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
