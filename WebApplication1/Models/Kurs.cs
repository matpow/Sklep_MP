using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Kurs
    {
        [Required]
        public string Nazwa_Kursu { get; set; }
        [Required]
        public int Cena { get; set; }
        public enum Ocena {bardzo_słaby = 1,słaby =2 ,średni = 3,dobry=4,bardzo_dobry=5}
        public string AutorKursu { get; set; }
        public DateTime DataDodania { get; set; }
        [StringLength(100)]
        public string NazwaPlikuObrazka { get; set; }
        public string OpisKursu { get; set; }
        public decimal CenaKursu { get; set; }
        public bool Bestseller { get; set; }
        public bool Ukryty { get; set; }
        public string OpisSkrocony { get; set; }

    }
}