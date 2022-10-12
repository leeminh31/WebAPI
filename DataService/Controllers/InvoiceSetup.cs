using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DataService.Controllers
{
    public class InvoiceSetup
    {
        //Lấy Dữ Liệu Dải Hóa Đơn
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_invoice_setup";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        //Tạo Mới Dải Hóa Đơn
        public static void Create(string connectionString,string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_invoicesetup";
                    cmd.Parameters.AddWithValue("@id", invoicesetupid);
                    cmd.Parameters.AddWithValue("@typename", typename);
                    cmd.Parameters.AddWithValue("@symbol", symbol);
                    cmd.Parameters.AddWithValue("@createby", createby);
                    cmd.Parameters.AddWithValue("@invoicestatus", invoicestatus);
                    cmd.Parameters.AddWithValue("@createon", Convert.ToDateTime(createdon));
                    cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(startdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Cập Nhật Dải Hóa Đơn
        public static void Update(string connectionString,string invoicesetupid, string typename, string symbol, string startdate, string createby, string invoicestatus, string createdon)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_invoicesetup";
                    cmd.Parameters.AddWithValue("@id", invoicesetupid);
                    cmd.Parameters.AddWithValue("@typename", typename);
                    cmd.Parameters.AddWithValue("@symbol", symbol);
                    cmd.Parameters.AddWithValue("@createby", createby);
                    cmd.Parameters.AddWithValue("@invoicestatus", invoicestatus);
                    cmd.Parameters.AddWithValue("@createon", Convert.ToDateTime(createdon));
                    cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(startdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Xóa Dải Hóa Đơn
        public static void Delete(string connectionString,string invoicesetupid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_invoicesetup";
                    cmd.Parameters.AddWithValue("@id", invoicesetupid);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public DataTable Search(string connectionString,string invoicesetupid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_invoicesetup @id = '{0}'", invoicesetupid), cnn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    return table;
                }
            }
        }
    }
}