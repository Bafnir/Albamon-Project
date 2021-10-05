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
        public virtual int PurchaseId { get; set; }

        public virtual double TotalPrice { get; set; }

        [Required]

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IList<PurchaseNFT> PurchaseNFTS { get; set; }
    }
}
