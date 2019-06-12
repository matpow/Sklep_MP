using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PozycjaKoszyka
    {
        public Kurs Kurs { get; set; }
        public int Ilosc { get; set; }
        public decimal Wartosc { get; set; }
    }
}