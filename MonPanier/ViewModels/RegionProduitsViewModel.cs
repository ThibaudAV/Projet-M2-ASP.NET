using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonPanier.ViewModels
{
    public class RegionProduitsViewModel
    {
        public virtual IEnumerable<Produit> Produits { get; set; }
        public Models.Region Region { get; set; }
    }
}