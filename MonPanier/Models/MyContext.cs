using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MonPanier.Models
{
    //public class MagasinContext : DbContext
    //{
    //    // CRUD
    //    public DbSet<Produit> Produits { get; set; }
    //    public DbSet<Region> Regions { get; set; }
    //    public DbSet<Categorie> Categories { get; set; }
    //    //public DbSet<Magasin> Magasins { get; set; }
    //    public DbSet<ContenuPanier> ContenuPaniers { get; set; }
    //    public DbSet<Panier> Paniers { get; set; }

    //    public MagasinContext()
    //    : base("DefaultConnection")
    //       { }

    //    public bool ProduitExiste(string nom)
    //    {
    //        return Produits.Any(p => string.Compare(p.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0);
    //    }
    //}


    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe ApplicationUser ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }

        public ApplicationUser()
        {
            NomMagasin = "Magasin de " + UserName;
            DescriptionMagasin = "Bienvenu dans le magasin de "+UserName;
        }


        [Display(Name = "Nom du magasin")]
        public string NomMagasin { get; set; }

        [Display(Name = "Déscription")]
        public string DescriptionMagasin { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Produits")]
        public virtual ICollection<Produit> Produits { get; set; }

        //[Display(Name = "Panier")]
        //public int PanierId { get; set; }
        //public virtual Panier Panier { get; set; }

    }


    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("MyContext", throwIfV1Schema: false)
        {
        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        // CRUD
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        //public DbSet<Magasin> Magasins { get; set; }
        public DbSet<ContenuPanier> ContenuPaniers { get; set; }
        public DbSet<Panier> Paniers { get; set; }

    }


    
}