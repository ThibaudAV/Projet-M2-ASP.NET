using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonPanier.ViewModels
{
    public class ProduitRegionViewModel
    {
        public Models.Produit Produits { get; set; }
        public Models.Region Regions { get; set; }
    }
}