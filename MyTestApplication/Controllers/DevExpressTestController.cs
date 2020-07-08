using DevExpress.Web.Mvc;
using MyTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTestApplication.Controllers
{
    public class DevExpressTestController : Controller
    {
        // GET: DevExpressTest
        public ActionResult Index()
        {
            return View();
        }

        MyTestApplication.Models.MyTestApplicationDBEntities1 db = new MyTestApplication.Models.MyTestApplicationDBEntities1();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.tbl_Order;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] tbl_Order item)
        {
            var model = db.tbl_Order;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] tbl_Order item)
        {
            var model = db.tbl_Order;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 ID)
        {
            var model = db.tbl_Order;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}