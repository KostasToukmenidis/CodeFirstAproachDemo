using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstAproachDemo.Models;
using CodeFirstAproachDemo.ViewModels;
using System.Data.Entity;
using System.Net;

namespace CodeFirstAproachDemo.Controllers
{
    public class WeaponController : Controller
    {
        GunStoreDbContext _context;

        public WeaponController()
        {
            _context = new GunStoreDbContext();
        }

        public ActionResult Create()
        {
            var weaponTypes = _context.WeaponTypes.ToList();

            var viewModel = new WeaponViewModel()
            {
                Weapon = new Weapon( ),
                WeaponTypes = weaponTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(WeaponViewModel _weapon)  //Because i am using WeaponViewModel in my view if i use anything other than weapon as my parameter
        {                                                    //name it wont map correctly to my passed values but only when parameter is of type Weapon, but if 
            if (!ModelState.IsValid) return View("Create");  //parameter is of type WeaponViewModel i have to use anything other than weapon as parameter to map
                                                             //correctly to my view
            if (_weapon.Weapon.Id > 0)
                _context.Entry(_weapon.Weapon).State = EntityState.Modified;
            else
                _context.Weapons.Add(_weapon.Weapon); 

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var weapon = _context.Weapons.Find(id);

            if (weapon == null)
                return HttpNotFound();

            WeaponViewModel viewModel = new WeaponViewModel
            {
                Weapon = weapon,
                WeaponTypes = _context.WeaponTypes.ToList()
            };

            return View("Create", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var weapon = _context.Weapons.Find(id);

            if (weapon == null)
                return HttpNotFound();
           
            _context.Weapons.Remove(weapon);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Weapon
        public ActionResult Index()
        {
            //Eager loading achieved with Include(), all weapons in the database will be loaded with their weaponTypes
            var weapons = _context.Weapons.Include(w => w.WeaponType).ToList(); // using.System.Data.Entity

            return View(weapons);
        }

        //EF disposes objects automaticly but in tutorial he uses this method wich is usefull in some cases
        //protected override void Dispose(bool disposing)
        //{
        //    if(disposing)
        //        _conext.Dispose();

        //    base.Dispose(disposing);
        //}

        //public ActionResult Create(WeaponViewModel _weapon)
        //{
        //    if (!ModelState.IsValid) return View("Create");


        //    //In tutorial he can pass in WeaponViewModel obj as parameter but in my project doesn't work
        //    _conext.Weapons.Add(_weapon.Weapon);
        //    _conext.SaveChanges();

        //    return RedirectToAction("Index");
        //}
    }
}