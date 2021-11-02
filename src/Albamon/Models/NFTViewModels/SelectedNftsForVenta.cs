using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Albamon.Models.NFTViewModels
{
    public class SelectedNftsForVentaViewModel
    {
        public string[] IdsToAdd { get; set; }
        [Display(Name = "Tipo")]
        public string TypeNFTSelected { get; set; }
        [Display(Name = "Precio")]
        public Double Price { get; set; }


    }
}
