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
        public ActionResult Szczegoly(int Id)
        {
            var produkt = db.Produkt.Find(Id);
            return View(produkt);
        }

        [ChildActionOnly]//ta akcja moze byc wywoalana tylko z poziomu innnej akcji
        public ActionResult _KategorieMenu()
        {

            var kategorie = db.Kategoria.ToList();
            
            return PartialView("_KategorieMenu", kategorie);
        }
        

    }
}