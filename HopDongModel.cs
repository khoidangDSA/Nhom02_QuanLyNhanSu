using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.Models
{
    public class HopDongModel
    {
        private string connectionString = "Server=YOUR_SERVER;Database=QuanLyNhanSuDB;Trusted_Connection=True;";

        public DataTable GetAllHopDong()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HopDong";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetHopDongSapHetHan(int minDays = 15, int maxDays = 30)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT MaHopDong, MaNhanVien, LoaiHopDong, NgayKetThuc, 
                           DATEDIFF(day, GETDATE(), NgayKetThuc) AS SongayConLai
                    FROM HopDong
                    WHERE TrangThai = N'Hiệu lực' 
                      AND DATEDIFF(day, GETDATE(), NgayKetThuc) BETWEEN @MinDays AND @MaxDays";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MinDays", minDays);
                cmd.Parameters.AddWithValue("@MaxDays", maxDays);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool ThemHopDong(HopDong hd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO HopDong (MaHopDong, MaNhanVien, LoaiHopDong, NgayKy, NgayBatDau, NgayKetThuc, MucLuongBase, PhuCap, TrangThai)
                                 VALUES (@MaHD, @MaNV, @LoaiHD, @NgayKy, @NgayBD, @NgayKT, @Luong, @PhuCap, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", hd.MaHopDong);
                cmd.Parameters.AddWithValue("@MaNV", hd.MaNhanVien);
                cmd.Parameters.AddWithValue("@LoaiHD", hd.LoaiHopDong);
                cmd.Parameters.AddWithValue("@NgayKy", hd.NgayKy);
                cmd.Parameters.AddWithValue("@NgayBD", hd.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKT", hd.NgayKetThuc);
                cmd.Parameters.AddWithValue("@Luong", hd.MucLuongBase);
                cmd.Parameters.AddWithValue("@PhuCap", hd.PhuCap);
                cmd.Parameters.AddWithValue("@TrangThai", hd.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
