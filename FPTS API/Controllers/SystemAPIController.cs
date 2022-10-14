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
using System.Configuration;

namespace FPTS_API.Controllers
{
    public class SystemAPIController : ApiController
    {
        // Lấy Dữ Liệu User
        [HttpGet]
        public static List<User> GetUser(string connection)
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

        public static void CreateUser(string connection,string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            DataService.Controllers.User.Create(connection, username, password, createby, createon, modifiedby, modifiedon, fullname, email, userstatus);
        }

        public static void UpdateUser(string connection,string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            DataService.Controllers.User.Update(connection, username, password, createby, createon, modifiedby, modifiedon, fullname, email, userstatus);
        }

        public static void DeleteUser(string connection,string username)
        {
            DataService.Controllers.User.Delete(connection, username);
        }

        public static List<User> SearchUser(string connection,string username)
        {
            DataTable table = DataService.Controllers.User.Search(connection, username);
            List<User> list = new List<User>();
            foreach(DataRow row in table.Rows)
            {
                User user = new User();
                user.Username = row["Username"].ToString();
                user.Email = row["Email"].ToString();
                user.UserStatus = row["UserStatus"].ToString();
                user.CreateOn = Convert.ToDateTime(row["CreateOn"].ToString());
                user.CreateBy = row["CreateBy"].ToString();
                user.Fullname = row["Fullname"].ToString();
                user.Password = row["UserPassword"].ToString();
                user.ModifiedBy = row["ModifiedBy"].ToString();
                user.ModifiedOn = DateTime.Now;
                list.Add(user);
            }
            return list;
        }

        // Lấy Dữ Liệu UserGroup
        [HttpGet]
        public static List<UserGroup> GetUserGroup(string connection)
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

        public static void CreateUserGroup(string connection,string username, string groupcode, string createby, string createdate)
        { 
            DataService.Controllers.UserGroup.Create(connection, username, groupcode, createby, createdate);
        }

        public static void UpdateUserGroup(string connection, string username, string groupcode, string createby, string createdate)
        {
            DataService.Controllers.UserGroup.Update(connection, username, groupcode, createby, createdate);
        }

        public static void DeleteUserGroup(string connection, string username, string groupcode)
        {
            DataService.Controllers.UserGroup.Delete(connection, username, groupcode);
        }

        public static List<UserGroup> SearchUserGroup(string connection, string username, string groupcode)
        {
            DataTable table = DataService.Controllers.UserGroup.Search(connection, username, groupcode);
            List<UserGroup> list = new List<UserGroup>();
            foreach(DataRow row in table.Rows)
            {
                UserGroup user = new UserGroup();
                user.CreateBy = row["CreateBy"].ToString();
                user.CreateDate = Convert.ToDateTime(row["CreateDate"].ToString());
                user.Username = row["Username"].ToString();
                user.GroupCode = row["GroupCode"].ToString();
                list.Add(user);
            }
            return list;
        }

        // Lấy Dữ Liệu Customer
        [HttpGet]
        public static List<Customer> GetCustomer(string connection)
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

        public static void CreateCustomer(string connection, string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            DataService.Controllers.Customer.Create(connection, customerid, fullname, gender, birthdate, customeraddress, email);
        }

        public static void UpdateCustomer(string connection, string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            DataService.Controllers.Customer.Update(connection, customerid, fullname, gender, birthdate, customeraddress, email);
        }

        public static void DeleteCustomer(string connection, string customerid)
        {
            DataService.Controllers.Customer.Delete(connection, customerid);
        }

        public static List<Customer> SearchCustomer(string connection, string customerid)
        {
            DataTable table = DataService.Controllers.Customer.Search(connection, customerid);
            List<Customer> list = new List<Customer>();
            foreach(DataRow row in table.Rows)
            {
                Customer customer = new Customer();
                customer.CustomerAddress = row["CustomerAddress"].ToString();
                customer.Email = row["Email"].ToString();
                customer.CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
                customer.Gender = row["Gender"].ToString();
                customer.BirthDate = Convert.ToDateTime(row["BirthDate"].ToString());
                customer.Fullname = row["Fullname"].ToString();
                list.Add(customer);
            }
            return list;
        }

        // Lấy Dữ Liệu Supplier
        [HttpGet]
        public static List<Supplier> GetSupplier(string connection)
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

        public static void CreateSupplier(string connection, string supplierid, string suppliername, string supplieraddress)
        {
            DataService.Controllers.Supplier.Create(connection, supplierid, suppliername, supplieraddress);
        }

        public static void UpdateSupplier(string connection, string supplierid, string suppliername, string supplieraddress)
        {
            DataService.Controllers.Supplier.Update(connection, supplierid, suppliername, supplieraddress);
        }

        public static List<Supplier> SearchSupplier(string connection, string supplierid)
        {
            DataTable table = DataService.Controllers.Supplier.Search(connection, supplierid);
            List<Supplier> list = new List<Supplier>();
            foreach(DataRow row in table.Rows)
            {
                Supplier supplier = new Supplier();
                supplier.SupplierAddress = row["SupplierAddress"].ToString();
                supplier.SupplierID = Convert.ToInt32(row["SupplierID"].ToString());
                supplier.SupplierName = row["SupplierName"].ToString();
                list.Add(supplier);
            }
            return list;
        }

        public static void DeleteSupplier(string connection, string supplierid)
        {
            DataService.Controllers.Supplier.Delete(connection, supplierid);
        }
    }
}
