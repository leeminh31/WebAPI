using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DataService.Controllers
{
    public class InvoiceLine
    {
        //Lấy Dữ Liệu Chi Tiết Hóa Đơn
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_invoice_line";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        //Tạo Mới Chi Tiết Hóa Đơn
        public static void Create(string connectionString,string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_invoice_line";
                    cmd.Parameters.AddWithValue("@id", invoiceid);
                    cmd.Parameters.AddWithValue("@invoiceid", invoicelineid);
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@createdate", Convert.ToDateTime(createdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Cập Nhật Thông Tin Chi Tiết Hóa Đơn
        public static void Update(string connectionString,string invoicelineid, string productname, string invoiceid, string quantity, string createdate, string price)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_invoice_line";
                    cmd.Parameters.AddWithValue("@id", invoicelineid);
                    cmd.Parameters.AddWithValue("@invoiceid", invoiceid);
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@createdate", Convert.ToDateTime(createdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Tìm Kiếm Chi Tiết Hóa Đơn
        public static DataTable Search(string connectionString,string invoicelineid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_invoiceline @id = '{0}'", invoicelineid), cnn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
            }
        }

        //Xóa Chi Tiết Hóa Đơn
        public static void Delete(string connectionString,string invoicelineid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_invoiceline";
                    cmd.Parameters.AddWithValue("@id", invoicelineid);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
    }
}