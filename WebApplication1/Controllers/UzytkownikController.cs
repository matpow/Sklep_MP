using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;

namespace WebApplication1.Controllers
{
    public class UzytkownikController : Controller
    {
        // GET: Uzytkownik
        public ActionResult DodajLubUsun(int id = 0)
        {
            Uzytkownik userModel = new Uzytkownik();
            return View(userModel);
        }
    }
}