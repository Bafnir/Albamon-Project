using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class PurchaseNFT
    {

        [Key]
        public virtual int PurchaseID { get; set; }

        [Required]
        public virtual NFT NFT { get; set; }

        [Required]
        public virtual Purchase Purchase { get; set; } 

        [Required]
        public virtual Double Fee { get; set; }




    }
}
