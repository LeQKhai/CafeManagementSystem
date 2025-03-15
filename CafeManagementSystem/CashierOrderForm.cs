using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CafeManagementSystem
{
    public partial class CashierOrderForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");
        private object selectedValue;

        public object SelectedValue { get; private set; }

        public CashierOrderForm()
        {
            InitializeComponent();

            displayAvailableProds();
        }
        public void displayAvailableProds()
        {
            CashierOrderFormProdData allProds = new CashierOrderFormProdData();

            List<CashierOrderFormProdData> listData = allProds.availableProductsData();

            CashierOrderForm_menuTable.DataSource = listData;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CashierOrderForm_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            CashierOrderForm_productID.SelectedIndex = -1;
            CashierOrderForm_productID.Items.Clear();
            CashierOrderForm_prodName.Text = "";
            CashierOrderForm_price.Text = "";

            string SelectedVailue = CashierOrderForm_type.SelectedItem as string;

                    if (SelectedVailue != null)
                    {
                        try
                        {
                    using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        connect.Open();

                        string selectData = $"SELECT * FROM products WHERE prod_type = '{SelectedVailue}' AND prod_status = @status AND date_delete IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string value = reader["prod_id"].ToString();

                                    CashierOrderForm_productID.Items.Add(value);
                                }
                            }
                        }
                    }     
                       
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show("Error: " + exx, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
        }

        private void CashierOrderForm_productID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedVailue = CashierOrderForm_productID.SelectedItem as string;

            if (SelectedVailue != null)
            {
                    using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True"))
                    {
                        connect.Open();

                        string selectData = $"SELECT * FROM products WHERE prod_id = '{SelectedVailue}' AND prod_status = @status AND date_delete IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string prodName = reader["prod_name"].ToString();
                                    string prodPrice = reader["prod_price"].ToString();

                                CashierOrderForm_prodName.Text = prodName;
                                CashierOrderForm_price.Text = prodPrice;
                            
                            }
                        }
                    }
                }
            }
        }
    }
}
