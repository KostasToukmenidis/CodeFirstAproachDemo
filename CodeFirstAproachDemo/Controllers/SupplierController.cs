using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstAproachDemo.Models;

namespace CodeFirstAproachDemo.Controllers
{
    public class SupplierController : Controller
    {
        private GunStoreDbContext _context;

        public SupplierController()
        {
            _context = new GunStoreDbContext();
        }

        // GET: Supplier
        public ActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            ViewBag.Suppliers = suppliers;

            return View();
        }

        [HttpPost]  //This Action is called when saveSupplier button of supplierModal is hit
        public ActionResult SaveSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;

            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);

            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet); //If there is not a supplier with the passed id i handle it in the client side
        }

        //[HttpPost]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);

        //    if (supplier == null)
        //        return HttpNotFound();

        //    _context.Suppliers.Remove(supplier);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id ==id);

            if (supplier == null)
                return HttpNotFound();

            return View("Index", supplier);
        }

    }
}