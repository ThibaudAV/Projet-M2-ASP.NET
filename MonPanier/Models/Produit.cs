using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }
        public Region Region { get; set; }
    }   

    public class ProduitsDBContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
    }
}