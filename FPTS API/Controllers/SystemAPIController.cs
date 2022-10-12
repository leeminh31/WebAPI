using FPTS_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.AccessControl;

namespace FPTS_API.Controllers
{
    public class SystemAPIController : ApiController
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        // Lấy Dữ Liệu User
        [HttpGet]
        public List<User> GetUser()
        {
            DataTable table = DataService.Controllers.User.GetAll(connection);
            List<User> list = new List<User>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                User User = new User();
                User.Username = table.Rows[i]["Username"].ToString();
                User.Password = table.Rows[i]["UserPassword"].ToString();
                User.CreateBy = table.Rows[i]["CreateBy"].ToString();
                User.ModifiedBy = table.Rows[i]["ModifiedBy"].ToString();
                User.Email = table.Rows[i]["Email"].ToString();
                User.Fullname = table.Rows[i]["Fullname"].ToString();
                User.UserStatus = table.Rows[i]["UserStatus"].ToString();
                User.CreateOn = Convert.ToDateTime(table.Rows[i]["CreateOn"].ToString());
                User.ModifiedOn = DateTime.Now;
                list.Add(User);
            }
            return list;
        }

        // Lấy Dữ Liệu UserGroup
        [HttpGet]
        public List<UserGroup> GetUserGroup()
        {
            DataTable table = DataService.Controllers.UserGroup.GetAll(connection);
            List<UserGroup> list = new List<UserGroup>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                UserGroup UserGroup = new UserGroup();
                UserGroup.Username = table.Rows[i]["Username"].ToString();
                UserGroup.GroupCode = table.Rows[i]["GroupCode"].ToString();
                UserGroup.CreateBy = table.Rows[i]["CreateBy"].ToString();
                UserGroup.CreateDate = Convert.ToDateTime(table.Rows[i]["CreateDate"].ToString());
                list.Add(UserGroup);
            }
            return list;
        }

        // Lấy Dữ Liệu Customer
        [HttpGet]
        public List<Customer> GetCustomer()
        {
            DataTable table = DataService.Controllers.Customer.GetAll(connection);
            List<Customer> list = new List<Customer>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Customer Customer = new Customer();
                Customer.CustomerID = Convert.ToInt32(table.Rows[i]["CustomerID"].ToString());
                Customer.Fullname = table.Rows[i]["Fullname"].ToString();
                Customer.Gender = table.Rows[i]["Gender"].ToString();
                Customer.CustomerAddress = table.Rows[i]["CustomerAddress"].ToString();
                Customer.Email = table.Rows[i]["Email"].ToString();
                Customer.BirthDate = Convert.ToDateTime(table.Rows[i]["BirthDate"].ToString());
                list.Add(Customer);
            }
            return list;
        }

        // Lấy Dữ Liệu Supplier
        [HttpGet]
        public List<Supplier> GetSupplier()
        {
            DataTable table = DataService.Controllers.Supplier.GetAll(connection);
            List<Supplier> list = new List<Supplier>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Supplier Supplier = new Supplier();
                Supplier.SupplierID = Convert.ToInt32(table.Rows[i]["SupplierID"].ToString());
                Supplier.SupplierName = table.Rows[i]["SupplierName"].ToString();
                Supplier.SupplierAddress = table.Rows[i]["SupplierAddress"].ToString();
                list.Add(Supplier);
            }
            return list;
        }
    }
}
