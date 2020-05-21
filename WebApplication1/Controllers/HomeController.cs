using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;
using Repozytorium.ViewModels;
using MvcSiteMapProvider.Caching;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private SklepContext db = new SklepContext();

        public ActionResult Index()
        {

            ICacheProvider cache = new DefaultCacheProvider();
            List<Produkt> nowosci;

            if(cache.IsSet(Consts.NowosciCacheKey))
            {
                nowosci = cache.Get(Consts.NowosciCacheKey) as List<Produkt>;
            }
            else
            {
                nowosci = db.Produkt.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(6).ToList();
                cache.Set(Consts.NowosciCacheKey, nowosci, 60);
            }

            var kategorie = db.Kategoria.ToList();

            

            var bestsellery = db.Produkt.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList(); //Guid.NewGuid() - sortuje po unikalnym indentyfikatorze za kazdym razem innmy

            var powiazane = db.Produkt.Take(5).ToList();

            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestsellery,
                Powiazane = powiazane
                
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