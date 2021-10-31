using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Albamon.Models.NFTViewModels
{
    public class SelectedMoviesForPurchaseViewModel
    {
        public string[] IdsToAdd { get; set; }
        [Display(Name = "Type")]
        public string TypeNFTSelected { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }


    }
}
