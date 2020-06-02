using MyTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTestApplication.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(),"CountryId", "CountryName" );
            return View();
        }

        public List<tbl_country> GetCountryList()
        {
            MyTestApplicationDBEntities1 db = new MyTestApplicationDBEntities1();
            List<tbl_country> countries = db.tbl_country.ToList();

            return countries;
        }
        public ActionResult GetStateList(int CountryId)
        {
            MyTestApplicationDBEntities1 db = new MyTestApplicationDBEntities1();

            List<tbl_state> stateList = db.tbl_state.Where(x=> x.CountryId == CountryId).ToList();
            ViewBag.StateOptions = new SelectList(stateList, "StateId", "StateName");
            return PartialView("StateOptionsPartial");
        }

        public JsonResult GetSuggestion(string text)
        {
            MyTestApplicationDBEntities1 db = new MyTestApplicationDBEntities1();
           
            List<string> list = new List<string>();
            list = db.tbl_myShop.Where(x => x.ItemName.ToLower().Contains(text.ToLower())).Select(x => x.ItemName).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}