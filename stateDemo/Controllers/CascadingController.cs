using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stateDemo.Models;
namespace stateDemo.Controllers
{
    public class CascadingController : Controller
    {
        // GET: Cascading
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(GetTbl_Countries(), "cid", "cname");
            return View();
        }
        public List<tbl_Country> GetTbl_Countries()
        {
            PersonDbEntities personDbEntities = new PersonDbEntities();
            List<tbl_Country> tbl_Countries = personDbEntities.tbl_Country.ToList();
            return tbl_Countries;
        }
        public ActionResult GetStateList(int id)
        {
            PersonDbEntities personDbEntities = new PersonDbEntities();
            List<tbl_State> tbl_Countries = personDbEntities.tbl_State.Where(x=>x.cid== id).ToList();
            ViewBag.StateList = new SelectList(tbl_Countries, "sid", "sname");
            return PartialView("displayState");
        }
        public ActionResult GetCityList(int id)
        {
            PersonDbEntities personDbEntities = new PersonDbEntities();
            List<tbl_City> tbl_Countries = personDbEntities.tbl_City.Where(x => x.Sid == id).ToList();
            ViewBag.CityList = new SelectList(tbl_Countries, "cityid", "Cityname");
            return PartialView("View");
        }
    }
}