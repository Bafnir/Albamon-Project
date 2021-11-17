using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Design
{
    public class Purchase
    {

        [Key]
        public virtual int PurchaseId { get; set; }

        public virtual double TotalPrice { get; set; }

        [Required]
        public virtual double Fees { get; set; }

        [Required]
        public virtual DateTime BuyDate { get; set; }

        [Required]

        public virtual Usuario Usuario { get; set; }

        public virtual IList<PurchaseNFT> PurchaseNFTS { get; set; }
    }
}
