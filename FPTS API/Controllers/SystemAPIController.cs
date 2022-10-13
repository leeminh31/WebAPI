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

        public static void CreateUser(string connection,string create, string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            if (create == "Create")
            {
                DataService.Controllers.User.Create(connection, username, password, createby, createon, modifiedby, modifiedon, fullname, email, userstatus);
            }
        }

        public static void UpdateUser(string connection,string update, string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            if (update == "Update")
            {
                DataService.Controllers.User.Update(connection, username, password, createby, createon, modifiedby, modifiedon, fullname, email, userstatus);
            }
        }

        public static void DeleteUser(string connection,string delete, string username)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.User.Delete(connection, username);
            }
        }

        public static void SearchUser(string connection,string search, string username)
        {
            if (search == "Search")
            {
                DataService.Controllers.User.Search(connection, username);
            }
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

        public static void CreateUserGroup(string connection,string create, string username, string groupcode, string createby, string createdate)
        { 
            if(create == "Create")
            {
                DataService.Controllers.UserGroup.Create(connection, username, groupcode, createby, createdate);
            }
        }

        public static void UpdateUserGroup(string connection, string update, string username, string groupcode, string createby, string createdate)
        {
            if (update == "Update")
            {
                DataService.Controllers.UserGroup.Update(connection, username, groupcode, createby, createdate);
            }
        }

        public static void DeleteUserGroup(string connection, string delete, string username, string groupcode, string createby, string createdate)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.UserGroup.Delete(connection, username, groupcode);
            }
        }

        public static void SearchUserGroup(string connection, string search, string username, string groupcode, string createby, string createdate)
        {
            if (search == "Search")
            {
                DataService.Controllers.UserGroup.Search(connection, username, groupcode);
            }
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

        public static void CreateCustomer(string connection, string create, string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            if (create == "Create")
            {
                DataService.Controllers.Customer.Create(connection, customerid, fullname, gender, birthdate, customeraddress, email);
            }
        }

        public static void UpdateCustomer(string connection, string update, string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            if (update == "Update")
            {
                DataService.Controllers.Customer.Update(connection, customerid, fullname, gender, birthdate, customeraddress, email);
            }
        }

        public static void DeleteCustomer(string connection, string delete, string customerid)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.Customer.Delete(connection, customerid);
            }
        }

        public static void SearchCustomer(string connection, string search, string customerid)
        {
            if (search == "Search")
            {
                DataService.Controllers.Customer.Search(connection, customerid);
            }
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

        public static void CreateSupplier(string connection, string create, string supplierid, string suppliername, string supplieraddress)
        {
            if (create == "Create")
            {
                DataService.Controllers.Supplier.Create(connection, supplierid, suppliername, supplieraddress);
            }
        }

        public static void UpdateSupplier(string connection, string update, string create, string supplierid, string suppliername, string supplieraddress)
        {
            if (update == "Update")
            {
                DataService.Controllers.Supplier.Update(connection, supplierid, suppliername, supplieraddress);
            }
        }

        public static void SearchSupplier(string connection, string search, string supplierid, string suppliername, string supplieraddress)
        {
            if (search == "Search")
            {
                DataService.Controllers.Supplier.Search(connection, supplierid);
            }
        }

        public static void DeleteSupplier(string connection, string delete, string supplierid, string suppliername, string supplieraddress)
        {
            if (delete == "Delete")
            {
                DataService.Controllers.Supplier.Delete(connection, supplierid);
            }
        }
    }
}
