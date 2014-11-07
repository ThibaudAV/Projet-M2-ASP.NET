using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    public class MagasinInitializer : DropCreateDatabaseIfModelChanges<MagasinContext>
    {

        protected override void Seed(MagasinContext context)
        {
            var regions = new List<Region>
            {
                new Region { Nom = "Isère" },
                new Region{Nom = "PACA"},
                new Region{Nom = "Toto"},
                new Region{Nom = "Savoie"}
            };

            foreach (var temp in regions)
            {
                context.Regions.Add(temp);
            }
            context.SaveChanges();

            //var produits = new List<Produit>
            //{
            //    new Produit{Nom = "ttt",Type = "Fruit"},
            //    new Produit{Nom = "eee",Type = "Fruit"},
            //    new Produit{Nom = "rrr",Type = "Fruit"},
            //    new Produit{Nom = "ssss",Type = "Fruit"}
            //};

            //foreach (var temp in produits)
            //{
            //    context.Produits.Add(temp);
            //}
            //context.SaveChanges();

        }
    }
}