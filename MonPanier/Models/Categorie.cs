using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
    }
}