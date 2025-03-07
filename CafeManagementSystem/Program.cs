using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Gọi hàm đảm bảo database tồn tại trước khi chạy ứng dụng
            DatabaseSetup.EnsureDatabaseExists();
            Application.Run(new Form1());
        }
    }
}
