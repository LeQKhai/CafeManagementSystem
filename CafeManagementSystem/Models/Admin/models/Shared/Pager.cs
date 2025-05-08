using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeManagementSystem.Models.Shared
{
    internal class Pager
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True";

        public List<(int PagerID, int Status)> GetAllPagers()
        {
            List<(int, int)> pagers = new List<(int, int)>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT PagerID, Status FROM Pagers";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pagers.Add((reader.GetInt32(0), reader.GetInt32(1)));
                    }
                }
            }
            return pagers;
        }

        public void CreatePager()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Pagers (PagerID, Status) VALUES ((SELECT ISNULL(MAX(PagerID), 0) + 1 FROM Pagers), 0)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePager(int pagerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Pagers WHERE PagerID = @PagerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PagerID", pagerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePagerStatus(int pagerId, int status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Pagers SET Status = @Status WHERE PagerID = @PagerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@PagerID", pagerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
