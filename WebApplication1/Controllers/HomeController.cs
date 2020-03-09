using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private SklepContext db = new SklepContext();

        public ActionResult Index()
        {
            var kategorie = db.Kategoria.ToList();

            var nowosci = db.Produkt.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(6).ToList();

            var bestsellery = db.Produkt.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList(); //Guid.NewGuid() - sortuje po unikalnym indentyfikatorze za kazdym razem innmy

            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestsellery 
            };

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var listaKategori = db.Kategoria.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

        public ActionResult Index2()
        {
            
            return View();
        }
    }
}