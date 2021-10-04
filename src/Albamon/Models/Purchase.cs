using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class Purchase
    {
        [Key]
        public virtual int purchaseID { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Double Price { get; set; }

        public virtual IList<PurchaseNFT> PurchaseNFT { get; set; }
    }
}
