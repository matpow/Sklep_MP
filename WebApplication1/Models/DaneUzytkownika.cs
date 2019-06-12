using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DaneUzytkownika
    {
        public string email { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public string kod_pocztowy { get; set; }
    }
}