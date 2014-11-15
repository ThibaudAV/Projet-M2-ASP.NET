using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    public class Region
    {
        public Region()
        {
            this.Produits = new HashSet<Produit>();
        }

        public int RegionId { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Numero { get; set; }


        public virtual ICollection<Produit> Produits { get; set; }

    }
}