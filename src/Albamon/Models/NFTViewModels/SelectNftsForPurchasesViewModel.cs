using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Albamon.Models.NFTViewModels
{
    public class SelectNftsForPurchasesViewModel
    {
        public IEnumerable<NFT> NFTS { get; set; }
        //needed to populate a dropdownlist 
        public SelectList TypeNFT;
        //needed to store the genre selected by the user
        [Display(Name = "Type")]
        public string TypeNFTSelected { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
