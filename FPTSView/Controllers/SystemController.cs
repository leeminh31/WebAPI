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

        public ActionResult Customer()
        {
            List<FPTS_API.Models.Customer> customers = FPTS_API.Controllers.SystemAPIController.GetCustomer(connection);
            return View(customers);
        }

        public ActionResult Supplier()
        {
            List<FPTS_API.Models.Supplier> suppliers = FPTS_API.Controllers.SystemAPIController.GetSupplier(connection);
            return View(suppliers);
        }

        public ActionResult UserGroup()
        {
            List<FPTS_API.Models.UserGroup> usergroups = FPTS_API.Controllers.SystemAPIController.GetUserGroup(connection);
            return View(usergroups);
        }
    }
}