using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoMvc.Models;
using AdoMvc.ViewModel;

namespace AdoMvc.Controllers
{
    public class userController : Controller
    {
        private DepartmentDb dbj = new DepartmentDb();
        // GET: user
        public ActionResult Index()
        {
            var d = dbj.GetDepartments();
            return View(d);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department de)
        {
            dbj.CreateList(de);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            dbj.DeleteList(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var row = dbj.GetDepartments().Find(model => model.Id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id,Department dpt)
        {
            dbj.UpdateList(dpt);
            return RedirectToAction("Index");
        }

    }
}