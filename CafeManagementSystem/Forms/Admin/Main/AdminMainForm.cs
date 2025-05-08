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
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
            username.Text = Form1.login;
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Form1 loginform = new Form1();
                loginform.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = true;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierCustomerFrom1.Visible = false;

            AdminDashboardForm adForm = adminDashboardForm1 as AdminDashboardForm;
            if(adForm != null)
            {
                adForm.refreshData();
            }
        }

        private void adminDashboardForm1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = false;
            cashierCustomerFrom1.Visible = false;

            AdminAddUsersForm adAddUsers = adminAddUsers1 as AdminAddUsersForm;
            if(adAddUsers != null)
            {
                adAddUsers.refreshData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = true;
            cashierCustomerFrom1.Visible = false;

            AdminAddProducts adAddProds = adminAddProducts1 as AdminAddProducts;
            if(adAddProds != null)
            {
                adAddProds.refreshData();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierCustomerFrom1.Visible = true;

            CashierOrderHistoryFrom cusForm = cashierCustomerFrom1 as CashierOrderHistoryFrom;
            if(cusForm != null)
            {
                cusForm.refreshData();
            }
        }
    }
}
