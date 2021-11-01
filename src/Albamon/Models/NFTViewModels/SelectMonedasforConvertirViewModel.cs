using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models.NFTViewModels
{
    public class SelectMonedasforConvertirViewModel
    {
        public IEnumerable<Moneda> Moneda { get; set; }
        //needed to populate a dropdownlist 
        public SelectList Monedas;
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
