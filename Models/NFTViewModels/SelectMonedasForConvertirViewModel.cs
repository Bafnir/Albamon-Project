using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models.NFTViewModels
{
    public class SelectMonedasForConvertirViewModel
    {
        public IEnumerable<Moneda> monedas { get; set; }
        //needed to populate a dropdownlist 
        public SelectList Typemoneda;
        //needed to store the coin selected by the user
        [Display(Name = "Nombre")]
        public string TypeMonedaSelected { get; set; }

        [Display(Name = "Precio")]
        public Double Price { get; set; }
    }

}
