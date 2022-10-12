using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DataService.Controllers
{
    public class Customer
    {
        //Lấy Dữ Liệu Khách Hàng
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_customer";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        // Tạo Mới Khách Hàng
        public static void Create(string connectionString,string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_customer";
                    cmd.Parameters.AddWithValue("@id", customerid);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(birthdate));
                    cmd.Parameters.AddWithValue("@customeraddress", customeraddress);
                    cmd.Parameters.AddWithValue("@email", email);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
        
        // Cập Nhật Thông Tin Khách Hàng
        public static void Update(string connectionString,string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_customer";
                    cmd.Parameters.AddWithValue("@id", customerid);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(birthdate));
                    cmd.Parameters.AddWithValue("@customeraddress", customeraddress);
                    cmd.Parameters.AddWithValue("@email", email);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Tìm Kiếm Khách Hàng
        public static DataTable Search(string connectionString,string customerid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_customer @id = '{0}'", customerid), cnn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
            }
        }

        //Xóa Khách Hàng
        public static void Delete(string connectionString,string customerid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_customer";
                    cmd.Parameters.AddWithValue("@id", customerid);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
    }
}