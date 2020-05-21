using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Infrastructure
{
    public class KoszykManager
    {

        private SklepContext db;
        private ISessionManager session;


        public KoszykManager(ISessionManager session, SklepContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if(session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz)==null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz) as List<PozycjaKoszyka>;
            }

            return koszyk;
        }

        public void DodajDoKoszyka(int produktID)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Produkt.ProduktId == produktID);

            if (pozycjaKoszyka != null)
                pozycjaKoszyka.Ilosc++;
            else
            {
                var produktDoDodania = db.Produkt.Where(k => k.ProduktId == produktID).SingleOrDefault();

                if(produktDoDodania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Produkt = produktDoDodania,
                        Ilosc = 1,
                        Wartosc = produktDoDodania.Cena
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }

            session.Set(Consts.KoszykSessionKlucz, koszyk);
        }

        public int UsunZKoszyka(int produktID)
        {

            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Produkt.ProduktId == produktID);

            if(pozycjaKoszyka != null)
            {
                if(pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Wartosc));
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(k => k.Ilosc);
            return ilosc;
        }

        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userID)
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            //noweZamowienie.UserId = userID;
            db.Zamowienie.Add(noweZamowienie);

            if (noweZamowienie.PozycjeZamowienia == null)
                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();
            decimal koszykWartosc = 0;

            foreach(var koszykElement in koszyk)
            {

                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    ProduktId = koszykElement.Produkt.ProduktId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Produkt.Cena
                };

                koszykWartosc += (koszykElement.Ilosc = koszykElement.Produkt.Cena);
                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowienia);

            }

            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db.SaveChanges();

            return noweZamowienie;


        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.KoszykSessionKlucz, null);
        }


    }
}