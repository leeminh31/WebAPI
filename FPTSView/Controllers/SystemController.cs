using FPTS_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTS_API.Controllers
{
    public class SystemController : Controller
    {
        string connection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        // GET: System
        public ActionResult Index()
        {
            List<FPTS_API.Models.User> users = FPTS_API.Controllers.SystemAPIController.GetUser(connection);
            return View(users);
        }

        [HttpPost]
        public ActionResult Index (string username)
        {
            List < FPTS_API.Models.User > list = FPTS_API.Controllers.SystemAPIController.SearchUser(connection, username);
            return View (list);
        }

        public ActionResult CreateUser(string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            FPTS_API.Controllers.SystemAPIController.CreateUser(connection, username,password,createby,createon,modifiedby,modifiedon,fullname,email,userstatus);
            return Redirect(Url.Action("Index", "System"));
        }

        public ActionResult UpdateUser(string username, string password, string createby, string createon, string modifiedby, string modifiedon, string fullname, string email, string userstatus)
        {
            FPTS_API.Controllers.SystemAPIController.UpdateUser(connection, username, password, createby, createon, modifiedby, modifiedon, fullname, email, userstatus);
            return Redirect(Url.Action("Index", "System"));
        }

        public ActionResult DeleteUser(string username)
        {
            FPTS_API.Controllers.SystemAPIController.DeleteUser(connection, username);
            return Redirect(Url.Action("Index", "System"));
        }

        public ActionResult Customer()
        {
            List<FPTS_API.Models.Customer> customers = FPTS_API.Controllers.SystemAPIController.GetCustomer(connection);
            return View(customers);
        }

        [HttpPost]
        public ActionResult Customer(string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            List<FPTS_API.Models.Customer> customers = FPTS_API.Controllers.SystemAPIController.SearchCustomer(connection,customerid);
            return View(customers);
        }

        public ActionResult CreateCustomer(string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            FPTS_API.Controllers.SystemAPIController.CreateCustomer(connection, customerid,fullname,gender,birthdate,customeraddress,email);
            return Redirect(Url.Action("Customer", "System"));
        }

        public ActionResult UpdateCustomer(string customerid, string fullname, string gender, string birthdate, string customeraddress, string email)
        {
            FPTS_API.Controllers.SystemAPIController.UpdateCustomer(connection, customerid, fullname, gender, birthdate, customeraddress, email);
            return Redirect(Url.Action("Customer", "System"));
        }

        public ActionResult DeleteCustomer(string customerid)
        {
            FPTS_API.Controllers.SystemAPIController.DeleteCustomer(connection, customerid);
            return Redirect(Url.Action("Customer", "System"));
        }

        public ActionResult Supplier()
        {
            List<FPTS_API.Models.Supplier> suppliers = FPTS_API.Controllers.SystemAPIController.GetSupplier(connection);
            return View(suppliers);
        }

        [HttpPost]
        public ActionResult CreateSupplier(string supplierid, string suppliername, string supplieraddress)
        {
            FPTS_API.Controllers.SystemAPIController.CreateSupplier(connection, supplierid,suppliername,supplieraddress);
            return Redirect(Url.Action("Supplier", "System"));
        }

        [HttpPost]
        public ActionResult UpdateSupplier(string supplierid, string suppliername, string supplieraddress)
        {
            FPTS_API.Controllers.SystemAPIController.UpdateSupplier(connection, supplierid, suppliername, supplieraddress);
            return Redirect(Url.Action("Supplier", "System"));
        }

        [HttpPost]
        public ActionResult DeleteSupplier(string supplierid)
        {
            FPTS_API.Controllers.SystemAPIController.DeleteSupplier(connection, supplierid);
            return Redirect(Url.Action("Supplier", "System"));
        }

        [HttpPost]
        public ActionResult Supplier(string supplierid)
        {
            List<FPTS_API.Models.Supplier> suppliers = FPTS_API.Controllers.SystemAPIController.SearchSupplier(connection, supplierid);
            return View(suppliers);
        }

        public ActionResult UserGroup()
        {
            List<FPTS_API.Models.UserGroup> usergroups = FPTS_API.Controllers.SystemAPIController.GetUserGroup(connection);
            return View(usergroups);
        }

        [HttpPost]
        public ActionResult UserGroup(string username, string groupcode)
        {
            List<FPTS_API.Models.UserGroup> usergroups = FPTS_API.Controllers.SystemAPIController.SearchUserGroup(connection,username,groupcode);
            return View(usergroups);
        }

        [HttpPost]
        public ActionResult CreateUserGroup(string username, string groupcode, string createby, string createdate)
        {
            FPTS_API.Controllers.SystemAPIController.CreateUserGroup(connection, username, groupcode,createby,createdate);
            return Redirect(Url.Action("UserGroup", "System"));
        }

        [HttpPost]
        public ActionResult UpdateUserGroup(string username, string groupcode, string createby, string createdate)
        {
            FPTS_API.Controllers.SystemAPIController.UpdateUserGroup(connection, username, groupcode, createby, createdate);
            return Redirect(Url.Action("UserGroup", "System"));
        }

        [HttpPost]
        public ActionResult DeleteUserGroup(string username, string groupcode)
        {
            FPTS_API.Controllers.SystemAPIController.DeleteUserGroup(connection, username, groupcode);
            return Redirect(Url.Action("UserGroup", "System"));
        }
    }
}