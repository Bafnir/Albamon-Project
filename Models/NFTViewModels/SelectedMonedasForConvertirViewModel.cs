using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models.NFTViewModels
{
    public class SelectedMonedasForConvertirViewModel
    {
        public string[] IdsToAdd { get; set; }
        [Display(Name = "Nombre")]
        public string TypeMonedaSelected { get; set; }
        [Display(Name = "Precio")]
        public Double Price { get; set; }

    }
}
