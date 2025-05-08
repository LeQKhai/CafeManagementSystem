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

        private void adminDashboardForm1_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = true;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierOrderHistoryFrom1.Visible = false;
            adminAddPromotions1.Visible = false;

            AdminDashboardForm adForm = adminDashboardForm1 as AdminDashboardForm;
            if(adForm != null)
            {
                adForm.refreshData();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = false;
            cashierOrderHistoryFrom1.Visible = false;
            adminAddPromotions1.Visible = false;

            AdminAddUsers adAddUsers = adminAddUsers1 as AdminAddUsers;
            if(adAddUsers != null)
            {
                adAddUsers.refreshData();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = true;
            cashierOrderHistoryFrom1.Visible = false;
            adminAddPromotions1.Visible = false;

            AdminAddProducts adAddProds = adminAddProducts1 as AdminAddProducts;
            if (adAddProds != null)
            {
                adAddProds.refreshData();
            }
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierOrderHistoryFrom1.Visible = true;
            adminAddPromotions1.Visible = false;

            CashierOrderHistoryFrom orderHistoryForm = cashierOrderHistoryFrom1 as CashierOrderHistoryFrom;
            if (orderHistoryForm != null)
            {
                orderHistoryForm.refreshData();
            }
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierOrderHistoryFrom1.Visible = false;
            adminAddPromotions1.Visible = true;


            AdminAddPromotions promotionForm = adminAddPromotions1 as AdminAddPromotions;
            if (promotionForm != null)
            {
                promotionForm.refreshData();
            }
        }
    }
}
