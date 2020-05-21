using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repozytorium.Models;

namespace Repozytorium.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; } //IEnumerable - interfejs ktory zwraca dowolna kolekcje(najlepsza praktyka)
        public IEnumerable<Produkt> Nowosci { get; set; }
        public IEnumerable<Produkt> Bestsellery { get; set; }
        public IEnumerable<Produkt> Powiazane { get; set; }
    }
}