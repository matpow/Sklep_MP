using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Uzytkownik
    {
        public int UzytkownikID { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string email { get; set; }
    }
}