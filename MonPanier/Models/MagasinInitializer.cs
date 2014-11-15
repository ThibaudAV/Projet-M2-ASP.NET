using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    //public class MagasinInitializer : DropCreateDatabaseIfModelChanges<MagasinContext>
    // CreateDatabaseIfNotExists
    // DropCreateDatabaseAlways
    public class MagasinInitializer : DropCreateDatabaseAlways<MyContext>
    {

        protected override void Seed(MyContext context)
        {

            // On crée un nouvelle user Admin
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
            var RoleManager = new RoleManager<IdentityRole>(new 
                                          RoleStore<IdentityRole>(context));
            string email = "admin@admin.fr";
            string name = "Admin";
            string password = "123456";
 
            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
            }
            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = email;
            user.Email = email;
            var adminresult = UserManager.Create(user, password);
    
            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }
            base.Seed(context);




            // Regions
            var regions = new List<Region>
            {
                new Region{Numero =1, Nom = "Picardie", Produits = new List<Produit>()},
                new Region{Numero =2, Nom = "Haute-Normandie", Produits = new List<Produit>()},
                new Region{Numero =3, Nom = "Basse-Normandie", Produits = new List<Produit>()},
                new Region{Numero =4, Nom = "Île-de-France", Produits = new List<Produit>()},
                new Region{Numero =5, Nom = "Bretagne", Produits = new List<Produit>()},
                new Region{Numero =6, Nom = "Champagne-Ardenne", Produits = new List<Produit>()},
                new Region{Numero =7, Nom = "Alsace", Produits = new List<Produit>()},
                new Region{Numero =8, Nom = "Pays de la Loire", Produits = new List<Produit>()},
                new Region{Numero =9, Nom = "Centre", Produits = new List<Produit>()},
                new Region{Numero =10, Nom = "Bourgogne", Produits = new List<Produit>()},
                new Region{Numero =11, Nom = "Rhône-Alpes", Produits = new List<Produit>()},
                new Region{Numero =12, Nom = "Aquitaine", Produits = new List<Produit>()},
                new Region{Numero =13, Nom = "Provence-Alpes-Côte d'Azur", Produits = new List<Produit>()},
                new Region{Numero =14, Nom = "Corse", Produits = new List<Produit>()},
                new Region{Numero =15, Nom = "Midi-Pyrénées", Produits = new List<Produit>()},
                new Region{Numero =16, Nom = "Languedoc-Roussillon", Produits = new List<Produit>()},
                new Region{Numero =17, Nom = "Lorraine", Produits = new List<Produit>()},
                new Region{Numero =18, Nom = "Poitou-Charentes", Produits = new List<Produit>()},
                new Region{Numero =19, Nom = "Limousin", Produits = new List<Produit>()},
                new Region{Numero =20, Nom = "Auvergne", Produits = new List<Produit>()},
                new Region{Numero =21, Nom = "Nord-Pas-de-Calais", Produits = new List<Produit>()},
                new Region{Numero =22, Nom = "Franche-Comté", Produits = new List<Produit>()}
            };

            foreach (var temp in regions)
            {
                context.Regions.Add(temp);
            }
            context.SaveChanges();

            // Categories
            var categories = new List<Categorie>
            {
                new Categorie{Nom = "Fruit"},
                new Categorie{Nom = "Legume"},
                new Categorie{Nom = "Féculant"},
                new Categorie{Nom = "Noix"},
                new Categorie{Nom = "Autres"},
            };
            foreach (var temp in categories)
            {
                context.Categories.Add(temp);
            }
            context.SaveChanges();



            // Produits
            //var produits = new List<Produit>
            //{
            //    new Produit{Nom = "Pomme",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01") , Regions = new List<Region>()},
            //    new Produit{Nom = "Noix",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "Pomme de terre",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "Tomate",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "Pates",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "qsd",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "qefes fe zef ",CategorieId = 3, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "sssss",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "sssss",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "qef qsef qsef s",CategorieId = 3, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "sss",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 3, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "sssssss",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "fdghgwdsgfxdgwsf",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttt",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttsdghfdsgdst",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "tsdfgds xgrstdhxwdfgtt",CategorieId = 3, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "tsdrgsdfdhdrstgt",CategorieId = 4, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttqsrfqst",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "ttsfeq fqse t",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //};

            //foreach (var temp in produits)
            //{
            //    context.Produits.Add(temp);
            //}
            //context.SaveChanges();

            // On ajoute les regions a des produits
            //AddOrUpdateRegon(context, "Pomme", "Alsace");
            //AddOrUpdateRegon(context, "Pomme", "Aquitaine");
            //AddOrUpdateRegon(context, "Pomme", "Auvergne");
            //AddOrUpdateRegon(context, "Pomme", "Basse-Normandie");
            //AddOrUpdateRegon(context, "Pomme", "Bourgogne");
            //AddOrUpdateRegon(context, "Pomme", "Bretagne");
            //AddOrUpdateRegon(context, "Noix", "Centre");
            //AddOrUpdateRegon(context, "Noix", "Champagne-Ardenne");
            //AddOrUpdateRegon(context, "Noix", "Corse");
            //AddOrUpdateRegon(context, "Noix", "Franche-Comté");
            //AddOrUpdateRegon(context, "Noix", "Haute-Normandie");
            //AddOrUpdateRegon(context, "Pomme", "Île-de-France");
            //AddOrUpdateRegon(context, "Tomate", "Languedoc-Roussillon");
            //AddOrUpdateRegon(context, "Tomate", "Limousin");
            //AddOrUpdateRegon(context, "Tomate", "Lorraine");
            //AddOrUpdateRegon(context, "Tomate", "Midi-Pyrénées");
            //AddOrUpdateRegon(context, "Tomate", "Nord-Pas-de-Calais");
            //AddOrUpdateRegon(context, "Pates", "Pays de la Loire");
            //AddOrUpdateRegon(context, "Pates", "Picardie");
            //AddOrUpdateRegon(context, "Pates", "Poitou-Charentes");
            //AddOrUpdateRegon(context, "Pates", "Provence-Alpes-Côte d'Azur");
            //AddOrUpdateRegon(context, "Pates", "Rhône-Alpes");

            //AddOrUpdateRegon(context, "Noix", "Île-de-France");
            //AddOrUpdateRegon(context, "Noix", "Languedoc-Roussillon");
            //AddOrUpdateRegon(context, "Noix", "Limousin");
            //AddOrUpdateRegon(context, "Noix", "Lorraine");
            //AddOrUpdateRegon(context, "Noix", "Midi-Pyrénées");
            //AddOrUpdateRegon(context, "Pates", "Nord-Pas-de-Calais");
            //AddOrUpdateRegon(context, "Tomate", "Pays de la Loire");
            //AddOrUpdateRegon(context, "Tomate", "Picardie");
            //AddOrUpdateRegon(context, "Tomate", "Poitou-Charentes");
            //AddOrUpdateRegon(context, "Tomate", "Provence-Alpes-Côte d'Azur");
            //AddOrUpdateRegon(context, "Tomate", "Rhône-Alpes");

            //context.SaveChanges();

        }

        void AddOrUpdateRegon(MyContext context, string NomProduit, string NomRegion)
        {
            var pro = context.Produits.Single(c => c.Nom == NomProduit);
            var reg = context.Regions.Single(i => i.Nom == NomRegion);
            if (reg != null)
                reg.Produits.Add(pro);

            //if (inst == null)
            //    crs.Regions.Add(context.Regions.Single(i => i.Nom == NomRegion));
        }
    }
}