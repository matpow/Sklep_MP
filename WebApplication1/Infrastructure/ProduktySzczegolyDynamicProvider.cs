using MvcSiteMapProvider;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Infrastructure
{
    public class KursySzczegolyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private SklepContext db = new SklepContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach ( Produkt Produkty in db.Produkt)
            {
                DynamicNode node = new DynamicNode();
                node.Title = Produkty.Nazwa_produktu;
                node.Key = "Produkt_" + Produkty.ProduktId;
                node.ParentKey = "Kategoria_" + Produkty.KategoriaId;
                node.RouteValues.Add("id", Produkty.ProduktId);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}