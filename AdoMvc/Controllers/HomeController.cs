using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoMvc.Models;

namespace AdoMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetCountries()
        {
            countyDb dbj = new countyDb();
            var countries = dbj.GetCountry();
            return Json(countries,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStates(int id)
        {
            StateDb sdb = new StateDb();
            var states = sdb.GetStates(id);
            return Json(states,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCities(int id)
        {
            CityDb cdb = new CityDb();
            var cities = cdb.GetCity(id);
            return Json(cities,JsonRequestBehavior.AllowGet);
        }
    }
}