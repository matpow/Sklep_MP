using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę kategorii")]
        [StringLength(100)]
        public string NazwaKategorii { get; set; }
        [Required(ErrorMessage = "Wprowadz opis kategorii")]
        public string OpisKategorii { get; set; }
        public string NazwaPlikuIkony { get; set; }

        public virtual ICollection<Produkt> Kursy { get; set; } //Kolekcja ICollection<T> to kolekcja dziedzicząca po IEnumerable<T>.
        //W przeciwieństwie
        //do IEnumerable<T> pozwala dodawać oraz usuwać elementy kolekcji.Wykorzystywana
        //jest w Entity Framework do opisu relacji pomiędzy tabelami.
    }
}