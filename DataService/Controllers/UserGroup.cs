using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DataService.Controllers
{
    public class UserGroup
    {
        // Lấy Dữ Liệu Nhóm Người Dùng
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_user_group";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        // Tạo Mới Nhóm Người Dùng
        public static void Create(string connectionString,string username, string groupcode, string createby, string createdate)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_usergroup";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@groupcode", groupcode);
                    cmd.Parameters.AddWithValue("@createby", createby);
                    cmd.Parameters.AddWithValue("@createdate", Convert.ToDateTime(createdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Cập Nhật Nhóm Người Dùng
        public static void Update(string connectionString,string username, string groupcode, string createby, string createdate)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_usergroup";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@groupcode", groupcode);
                    cmd.Parameters.AddWithValue("@createby", createby);
                    cmd.Parameters.AddWithValue("@createdate", Convert.ToDateTime(createdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Tìm Kiếm Nhóm Người Dùng
        public static DataTable Search(string connectionString,string username, string groupcode)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_usergroup @username = '{0}', @groupcode = '{1}'", username, groupcode), cnn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
            }
        }

        //Xóa Nhóm Người Dùng
        public static void Delete(string connectionString,string username, string groupcode)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_usergroup";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@groupcode", groupcode);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
    }
}