using Repozytorium.Models;
using Repozytorium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers
{
    public class KoszykController : Controller
    {
        // GET: Koszyk

        private KoszykManager koszykManager;
        private ISessionManager sessionManager { get; set; }
        private SklepContext db;

        public KoszykController()
        {
            db = new SklepContext();
            sessionManager = new SessionManager();
            koszykManager = new KoszykManager(sessionManager,db);
        }




        public ActionResult Koszyk()
        {
            var pozycjeKoszyka = koszykManager.PobierzKoszyk();
            var cenaCalkowita = koszykManager.PobierzWartoscKoszyka();
            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                PozycjeKoszyka = pozycjeKoszyka,
                CenaCalkowita = cenaCalkowita
            };
            return View(koszykVM);
        }
        public ActionResult DodajDoKoszyka(int id)
        {
            koszykManager.DodajDoKoszyka(id);

            return RedirectToAction("Koszyk");
        }

        public int PobierzIloscElementowKoszyka()
        {
           return koszykManager.PobierzIloscPozycjiKoszyka();
        }

        public decimal PobierzCeneCalkowita()
        {
            return koszykManager.PobierzWartoscKoszyka();
        }

    }
}