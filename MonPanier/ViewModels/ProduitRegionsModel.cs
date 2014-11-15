using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.ViewModels
{
    public class ProduitRegionsModel
    {
        //public Models.Produit Produit { get; set; }

        //public List<Region> Regions { get; set; }
        //public List<int> RegionsIds { get; set; }


        public Produit Produit { get; set; }
        public IEnumerable<SelectListItem> AllRegions { get; set; }

        private List<int> _selectedRegions;
        public List<int> SelectedRegions
        {
            get
            {
                if (_selectedRegions == null)
                {
                    _selectedRegions = Produit.Regions.Select(m => m.RegionId).ToList();
                }
                return _selectedRegions;
            }
            set { _selectedRegions = value; }
        }

    }
}