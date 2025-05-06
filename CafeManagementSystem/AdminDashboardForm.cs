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

namespace CafeManagementSystem
{
    public partial class AdminDashboardForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");

        public AdminDashboardForm()
        {
            InitializeComponent();

            displayTotalCashier();
            displayTotalCustomers();
            displayTodayIncome();
            displayTotalIncome();
        }

        public void refreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayTotalCashier();
            displayTotalCustomers();
            displayTodayIncome();
            displayTotalIncome();
        }

        public void displayTotalCashier()
        {
            if(connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(id) FROM users WHERE role = @role AND status = @Status";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@role", "Cashier");
                        cmd.Parameters.AddWithValue("@status", "Active");

                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashbroad_totalCashiers.Text = count.ToString();
                        }

                        reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayTotalCustomers()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(id) FROM orders";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashbroad_totalCustomers.Text = count.ToString();
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayTodayIncome()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT SUM(total_price) FROM orders WHERE order_date = @order_date";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@order_date", today);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!Convert.IsDBNull(reader[0]))
                            {
                                decimal count = Convert.ToDecimal(reader[0]);
                                dashbroad_incomeToday.Text = count.ToString("N0") + " VND";
                            }
                            else
                            {
                                dashbroad_incomeToday.Text =  "0 VND";
                            }
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayTotalIncome()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT SUM(total_price) FROM orders";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!Convert.IsDBNull(reader[0]))
                            {
                                decimal total = Convert.ToDecimal(reader[0]);
                                dashbroad_incomeTotal.Text = total.ToString("N0") + " VND";
                            }
                            else
                            {
                                dashbroad_incomeTotal.Text = "0 VND";
                            }
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }


        //public void displayTotalIncome()
        //{
        //    if (connect.State == ConnectionState.Closed)
        //    {
        //        try
        //        {
        //            connect.Open();

        //            string selectData = "SELECT SUM(total_price) FROM orders";

        //            using (SqlCommand cmd = new SqlCommand(selectData, connect))
        //            {
        //                SqlDataReader reader = cmd.ExecuteReader();
        //                if (reader.Read())
        //                {
        //                    if (reader[0] is int)
        //                    {
        //                        int count = Convert.ToInt32(reader[0]);
        //                        dashbroad_incomeTotal.Text = count.ToString("N0") + " VND";
        //                    }
        //                    else
        //                    {
        //                        int count = 0;
        //                        dashbroad_incomeTotal.Text = count.ToString("N0") + " VND";
        //                    }

        //                }

        //                reader.Close();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        finally
        //        {
        //            connect.Close();
        //        }
        //    }
        //}
    }
}
