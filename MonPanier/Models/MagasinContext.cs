using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    public class MagasinContext : DbContext
    {
        // CRUD
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}