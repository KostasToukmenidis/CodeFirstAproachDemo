using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstAproachDemo.Models;

namespace CodeFirstAproachDemo.Controllers
{
    public class WeaponTypeController : Controller
    {
        private readonly GunStoreDbContext _context;

        public WeaponTypeController()
        {
            _context = new GunStoreDbContext();
        }
        
        // GET: WeaponType
        public ActionResult Index()
        {
            var weaponTypes = _context.WeaponTypes.ToList();
            
            return View(weaponTypes);
        }

        public ActionResult Create()
        {
            return View(new WeaponType{ Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(WeaponType _weaponType)
        {
            if (!ModelState.IsValid) return View("Create", _weaponType);

            if (_weaponType.Id > 0)
                _context.Entry(_weaponType).State = EntityState.Modified; // This one is used in the tutorial
            else
                _context.WeaponTypes.Add(_weaponType);
            
            //Instead of using this if and else statment i can use this AddOrUpdate wich does the same thing
            //_context.WeaponTypes.AddOrUpdate(_weaponType);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var type = _context.WeaponTypes.SingleOrDefault(c => c.Id == id);

            if (type == null)
                return HttpNotFound();

            return View("Create", type);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //Both do the same thing in this case
            var wepType = _context.WeaponTypes.Find(id);
            var type = _context.WeaponTypes.SingleOrDefault(c => c.Id == id);

            if (type == null)
                return HttpNotFound();
            
            _context.WeaponTypes.Remove(type);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}