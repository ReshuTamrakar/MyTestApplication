using MyTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTestApplication.Controllers
{
    public class DataGridController : Controller
    {
        // GET: DataGrid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StatePersistence()
        {
            MyTestApplicationDBEntities1 db = new MyTestApplicationDBEntities1();
            List<tbl_Order> _Orders = db.tbl_Order.ToList();

            return View(_Orders);
        }
    }
}