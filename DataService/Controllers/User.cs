using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DataService.Controllers
{
    public class User
    {
        // Lấy Dữ Liệu Người Dùng
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_user";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        //Tạo Mới Người Dùng
        public static void Create(string connectionString,string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_user";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@createby", createby);
                    cmd.Parameters.AddWithValue("@createon", Convert.ToDateTime(createon));
                    cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
                    cmd.Parameters.AddWithValue("@userstatus", userstatus);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@modifiedon", Convert.ToDateTime(modifiedon));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Cập Nhật Thông Tin Người Dùng
        public static void Update(string connectionString,string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_user";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@createby", createby);
                    cmd.Parameters.AddWithValue("@createon", Convert.ToDateTime(createon));
                    cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
                    cmd.Parameters.AddWithValue("@userstatus", userstatus);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@modifiedon", Convert.ToDateTime(modifiedon));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Tìm Kiếm Người Dùng
        public static DataTable Search(string connectionString,string username)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_user @username = '{0}'", username), cnn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
            }
        }

        //Xóa Người Dùng
        public static void Delete(string connectionString,string username)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_user";
                    cmd.Parameters.AddWithValue("@username", username);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
    }
}