using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
    public class Produkt
    {
        [Key]
        public int ProduktId { get; set; }
        public int KategoriaId { get; set; }
        [Required]
        public string Nazwa_produktu { get; set; }
        [Required]
        public int Cena { get; set; }
        public enum Ocena {bardzo_słaby = 1,słaby =2 ,średni = 3,dobry=4,bardzo_dobry=5}
        public string Producent { get; set; }
        public DateTime DataDodania { get; set; }
        [StringLength(100)]
        public string NazwaPlikuObrazka { get; set; }
        public string OpisProduktu { get; set; }       
        public bool Bestseller { get; set; }
        public bool Ukryty { get; set; }
        public string OpisSkrocony { get; set; }
        public string Skrot { get; set; }
    }
}