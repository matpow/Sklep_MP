using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Repozytorium.Models;

namespace Repozytorium.Models
{
    public class SklepContext : IdentityDbContext<ApplicationUser>
    {
        public SklepContext() 
            : base("Sklep_MP")
        {
        }

        static  SklepContext()
        {
            Database.SetInitializer<SklepContext>(new SklepIinitializer());
        }


        public static SklepContext Create()
        {
            return new SklepContext();
        }

        public virtual DbSet<Produkt> Produkt { get; set; }
        //public virtual DbSet<Kategoria> Kategorie { get; set; }
        public  virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public  virtual DbSet<Kategoria> Kategoria { get; set; }
        public  DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }
        public  virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
           // modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);

            // using System.Data.Entity.ModelConfiguration.Conventions;
            // Wyłącza konwencję, która automatycznie tworzy liczbę mnogą dla nazw tabel w bazie danych
            // Zamiast Kategorie zostałaby stworzona tabela o nazwie Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
        }
    }
}