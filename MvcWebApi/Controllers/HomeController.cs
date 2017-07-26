using MvcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ReservationRepository repo = ReservationRepository.Current;

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid) { repo.Add(item);return RedirectToAction("Index"); }
            else{ return View("Index"); }
        }

        public ActionResult Remove(int id)
        {
            repo.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(Reservation Item)
        {
            if (ModelState.IsValid && repo.Update(Item)){return RedirectToAction("Index");}
               else { return View("Index"); }
        }
    }
    
}