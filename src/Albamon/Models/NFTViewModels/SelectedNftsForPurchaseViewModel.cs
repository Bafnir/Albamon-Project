using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Albamon.Models.NFTViewModels
{
    public class SelectedNftsForPurchaseViewModel
    {
        public string[] IdsToAdd { get; set; }
        [Display(Name = "Type")]
        public string TypeNFTSelected { get; set; }
        [Display(Name = "Price")]
        public Double Price { get; set; }


    }
}
