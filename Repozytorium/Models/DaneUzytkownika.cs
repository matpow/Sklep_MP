using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class DaneUzytkownika
    {
        public string login { get; set; }
        public string haslo { get; set; }
        public string email { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public string kod_pocztowy { get; set; }
    }
}