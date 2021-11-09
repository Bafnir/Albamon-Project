using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Albamon.Models.NFTViewModels
{
    public class SelectNftsForVentasViewModel
    {
        public IEnumerable<NFT> NFTS { get; set; }
        //needed to populate a dropdownlist 
        public SelectList TypeNFTs;
        //needed to store the type selected by the user
        [Display(Name = "Tipo NFT")]
        public string TypeNFTSelected { get; set; }

        [Display(Name = "Precio")]
        public Double Price { get; set; }

    }
}
