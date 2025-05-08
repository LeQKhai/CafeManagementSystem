using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem
{
    internal class PromotionData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLlocaldb;Database=cafe;Integrated Security=True");

        public string Code { get; set; }
        public int Percent { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public PromotionData()
        {
            
        }

        public List<PromotionData> ListPromotionData()
        {
            List<PromotionData> listData = new List<PromotionData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM promotions ORDER BY start_date ASC";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            PromotionData promo = new PromotionData();
                            promo.Code = reader["code"].ToString();
                            promo.Percent = Convert.ToInt32(reader["discount_percent"]);
                            promo.Description = reader["description"].ToString();
                            promo.StartDate = Convert.ToDateTime(reader["start_date"]);
                            promo.EndDate = Convert.ToDateTime(reader["end_date"]);
                            promo.IsActive = Convert.ToBoolean(reader["is_active"]);

                            listData.Add(promo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Kết nối thất bại: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }


        public bool AddPromotion()
        {
            try
            {
                using (connect)
                {
                    if(connect.State == ConnectionState.Closed) connect.Open();
                    string query = "INSERT INTO promotions (code, discount_percent, description, start_date, end_date, is_active) " +
                                   "VALUES (@Code, @Percent, @Desc, @Start, @End, @Active)";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@Code", Code);
                        cmd.Parameters.AddWithValue("@Percent", Percent);
                        cmd.Parameters.AddWithValue("@Desc", Description);
                        cmd.Parameters.AddWithValue("@Start", StartDate);
                        cmd.Parameters.AddWithValue("@End", EndDate);
                        cmd.Parameters.AddWithValue("@Active", IsActive);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khuyến mãi: " + ex.Message);
                return false;
            }
        }


        public bool UpdatePromotion()
        {
            bool result = false;
            try
            {
                connect.Open();
                string query = "UPDATE promotions SET discount_percent = @Percent, description = @Description, " +
                               "start_date = @StartDate, end_date = @EndDate, is_active = @IsActive WHERE code = @Code";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Code", Code);
                    cmd.Parameters.AddWithValue("@Percent", Percent);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật khuyến mãi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            return result;
        }

        
        public bool DeletePromotion(string code)
        {
            bool result = false;
            try
            {
                connect.Open();
                string query = "DELETE FROM promotions WHERE code = @Code";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Code", code);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xoá khuyến mãi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            return result;
        }

    }
}
