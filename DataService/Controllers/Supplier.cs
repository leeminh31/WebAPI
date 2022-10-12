using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DataService.Controllers
{
    public class Supplier
    {
        //Lấy Dữ Liệu Nhà Cung Cấp
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_supplier";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        //Tạo Mới Nhà Cung Cấp
        public static void Create(string connectionString,string supplierid, string suppliername, string supplieraddress)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_supplier";
                    cmd.Parameters.AddWithValue("@id", supplierid);
                    cmd.Parameters.AddWithValue("@suppliername", suppliername);
                    cmd.Parameters.AddWithValue("@supplieraddress", supplieraddress);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Cập Nhật Thông Tin Nhà Cung Cấp
        public static void Update(string connectionString,string supplierid, string suppliername, string supplieraddress)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_supplier";
                    cmd.Parameters.AddWithValue("@id", supplierid);
                    cmd.Parameters.AddWithValue("@suppliername", suppliername);
                    cmd.Parameters.AddWithValue("@supplieraddress", supplieraddress);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Tìm Kiếm Nhà Cung Cấp
        public static DataTable Search(string connectionString,string supplierid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_supplier @id = '{0}'", supplierid), cnn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
            }
        }

        //Xóa Nhà Cung Cấp
        public static void Delete(string connectionString,string supplierid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_supplier";
                    cmd.Parameters.AddWithValue("@id", supplierid);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
    }
}