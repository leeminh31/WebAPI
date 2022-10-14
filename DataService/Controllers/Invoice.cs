using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DataService.Controllers
{
    public class Invoice
    {
        //Lấy Dữ Liệu Hóa Đơn
        public static DataTable GetAll(string connectionString)
        {
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                string query = "select * from tb_invoice";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                adapter.Fill(table);
            }
            return table;
        }

        //Tạo Mới Hóa Đơn
        public static void Create(string connectionString, string invoiceid, string customerid, string supplierid, string invoicesetupid, string startdate)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insert_invoice";
                    cmd.Parameters.AddWithValue("@id", invoiceid);
                    cmd.Parameters.AddWithValue("@supplierid", supplierid);
                    cmd.Parameters.AddWithValue("@customerid", customerid);
                    cmd.Parameters.AddWithValue("@invoicesetupid", invoicesetupid);
                    cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(startdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Cập Nhật Thông Tin Hóa Đơn
        public static void Update(string connectionString,string customerid, string supplierid, string invoiceid, string invoicesetupid, string startdate)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_update_invoice";
                    cmd.Parameters.AddWithValue("@id", invoiceid);
                    cmd.Parameters.AddWithValue("@supplierid", supplierid);
                    cmd.Parameters.AddWithValue("@customerid", customerid);
                    cmd.Parameters.AddWithValue("@invoicesetupid", invoicesetupid);
                    cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(startdate));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //Xóa Hóa Đơn 
        public static void Delete(string connectionString,string invoiceid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_invoice";
                    cmd.Parameters.AddWithValue("@id", invoiceid);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public static DataTable Search(string connectionString, string invoiceid)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(String.Format("exec sp_search_invoice @id = '{0}'", invoiceid), cnn))
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