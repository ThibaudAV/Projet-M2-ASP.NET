using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    public class Panier
    {
        public Panier()
        {
            this.ContenuPaniers = new HashSet<ContenuPanier>();
        }
        public int PanierId { get; set; }

        //[ScaffoldColumn(false)]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ContenuPanier> ContenuPaniers { get; set; }



    }
}