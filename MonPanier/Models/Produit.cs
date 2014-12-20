using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Models
{

    public class Produit
    {
        public Produit()
        {
            this.Regions = new HashSet<Region>();
        }

        public int ProduitId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nom { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Prix en €")]
        public float Prix { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de Validité")]
        public DateTime? DateValid { get; set; }

        [Required(ErrorMessage = "Please enter : Catégorie")]
        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }

        [Required]
        [Display(Name = "Quantité en unité")]
        public int Quantite { get; set; }

        [Display(Name = "En Ligne / Hors Ligne")]
        public Boolean EnLigne { get; set; }

        //[ScaffoldColumn(false)]
        //public int MagasinId { get; set; }
        //public virtual Magasin Magasin { get; set; }
        [ScaffoldColumn(false)]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Region> Regions { get; set; }


    }   

}