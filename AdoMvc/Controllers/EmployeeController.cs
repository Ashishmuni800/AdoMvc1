using AdoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoMvc.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDb db = new EmployeeDb();
        // GET: Employee
        public ActionResult Index()
        {
            var data = db.GetEmployees();
            return View(data);
        }
    }
}