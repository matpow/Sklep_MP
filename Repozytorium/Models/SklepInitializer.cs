using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Repozytorium.Models;
using Repozytorium.Migrations;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
//using System.Configuration;

namespace Repozytorium.Models
{
    public class SklepIinitializer : MigrateDatabaseToLatestVersion<SklepContext, Configuration>
    {       
        public static  void SeedSklepData(SklepContext context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId = 1, NazwaKategorii = "Odziez", OpisKategorii= "odziez sportowa" },
                new Kategoria() {KategoriaId = 2, NazwaKategorii = "Obuwie", OpisKategorii= "odziez sportowa" },
                new Kategoria() {KategoriaId = 3, NazwaKategorii = "Sprzet", OpisKategorii= "odziez sportowa" }
            };
            kategorie.ForEach(k => context.Kategoria.AddOrUpdate(k));
            context.SaveChanges();

            var Produkty = new List<Produkt>
            {
                new Produkt() { ProduktId = 1,KategoriaId=1,Nazwa_produktu="Kurtka 4f meska",Cena=399,Producent="4f"
                   ,DataDodania=DateTime.Now, Bestseller=true,OpisProduktu="kurtka sportowa zimowa wysokiej jakosci",NazwaPlikuObrazka="P1_kurtka4f.jpg"},
                new Produkt() { ProduktId = 2,KategoriaId=2,Nazwa_produktu="Buty nike mercurial",Cena=299,Producent="Nike"
                    ,DataDodania=DateTime.Now ,Bestseller=true,OpisProduktu="buty sportowe",NazwaPlikuObrazka="P2_butynike.jpg"},
                new Produkt() { ProduktId = 3,KategoriaId=3,Nazwa_produktu="Pilka nozna adidas",Cena=99,Producent="Adidas",
                    DataDodania = DateTime.Now,Bestseller=true,OpisProduktu="pilka nozna",NazwaPlikuObrazka = "P3_pilkaadidas.jpg"}
            };

            Produkty.ForEach(k => context.Produkt.AddOrUpdate(k));
            context.SaveChanges();
        }

        

        public static void SeedUzytkownicy(SklepContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@praktycznekursy.pl";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, DaneUzytkownika = new DaneUzytkownika() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}