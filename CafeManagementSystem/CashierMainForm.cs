using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class CashierMainForm: Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
            username.Text = Form1.login;
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Tin nhắn xác nhận.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Tin nhắn xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }    

        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = true;
            adminAddProducts1.Visible = false;
            cashierOrderForm1.Visible = false;
            cashierCustomerFrom1.Visible = false;

            AdminDashboardForm adForm = adminDashboardForm1 as AdminDashboardForm;
            if (adForm != null)
            {
                adForm.refreshData();
            }
        }

        private void addProducts_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddProducts1.Visible = true;
            cashierOrderForm1.Visible = false;
            cashierCustomerFrom1.Visible = false;

            AdminAddProducts adAddProds = adminAddProducts1 as AdminAddProducts;
            if (adAddProds != null)
            {
                adAddProds.refreshData();
            }
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierOrderForm1.Visible = true;
            cashierCustomerFrom1.Visible = false;

            CashierOrderForm orderForm = cashierOrderForm1 as CashierOrderForm;
            if (orderForm != null)
            {
                orderForm.refreshData();
            }
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierOrderForm1.Visible = false;
            cashierCustomerFrom1.Visible = true;

            CashierCustomerFrom cusForm = cashierCustomerFrom1 as CashierCustomerFrom;
            if (cusForm != null)
            {
                cusForm.refreshData();
            }
        }
    }
}
