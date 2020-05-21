using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProduktyController : Controller
    {

        private SklepContext db = new SklepContext();

        // GET: Produkty
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista(string NazwaKategorii)
        {

            return View();
        }
        public ActionResult Szczegoly(int id)
        {
            var produkt = db.Produkt.Find(id);
            return View(produkt);
        }

        [ChildActionOnly]//ta akcja moze byc wywoalana tylko z poziomu innnej akcji
        [OutputCache(Duration = 60000)]
        public ActionResult _KategorieMenu()
        {
            
            var kategorie = db.Kategoria.ToList();
            
            return PartialView("_KategorieMenu", kategorie);
        }

        public ActionResult ProduktyPodpowiedzi(string term)
        {
            var produkty = db.Produkt.Where(a => !a.Ukryty && a.Nazwa_produktu.ToLower().Contains(term.ToLower()))
                            .Take(5).Select(a => new { label = a.Nazwa_produktu });
            return Json(produkty, JsonRequestBehavior.AllowGet);
        }
        

    }
}