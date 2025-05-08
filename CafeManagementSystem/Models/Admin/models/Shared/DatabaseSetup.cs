using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;


namespace CafeManagementSystem
{
    internal class DatabaseSetup
    {
        public static void EnsureDatabaseExists()
        {
            string masterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;";
            string dbName = "cafe";

            // Kiểm tra database đã tồn tại chưa
            using (SqlConnection conn = new SqlConnection(masterConnectionString))
            {
                conn.Open();
                string checkDbQuery = $"SELECT database_id FROM sys.databases WHERE name = '{dbName}'";
                using (SqlCommand cmd = new SqlCommand(checkDbQuery, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null) {
                        System.Diagnostics.Debug.WriteLine("ton tai");
                        return;// Database đã tồn tại, thoát luôn
                    } 
                }
            }

            // Nếu chưa có, tạo database
            string root = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string scriptPath = Path.Combine(root, "Resources");
            DirectoryInfo di = new DirectoryInfo(scriptPath);
            FileInfo[] rgFiles = di.GetFiles("*.sql");

            foreach (FileInfo fi in rgFiles)
            {
                FileInfo fileInfo = new FileInfo(fi.FullName);
                string script = fileInfo.OpenText().ReadToEnd();
                SqlConnection connection = new SqlConnection(masterConnectionString);
                Server server = new Server(new ServerConnection(connection));
                server.ConnectionContext.ExecuteNonQuery(script);
            }

            //Console.WriteLine(scriptPath);
            //if (File.Exists(scriptPath))
            //{
            //    string script = File.ReadAllText(scriptPath);
            //    using (SqlConnection conn = new SqlConnection(masterConnectionString))
            //    {
            //        conn.Open();
            //        using (SqlCommand cmd = new SqlCommand(script, conn))
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
        }
    }

}

