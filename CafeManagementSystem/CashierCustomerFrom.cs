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
    public partial class CashierCustomerFrom : UserControl
    {
        public CashierCustomerFrom()
        {
            InitializeComponent();
            displayAllCustomers();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAllCustomers();
        }

        public void displayAllCustomers()
        {
            OrderData cData = new OrderData();
            List<OrderData> listData = cData.allOrdersData();

            CashierCustomerForm_customerTable.DataSource = listData;
        }
    }
}
