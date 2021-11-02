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
        public virtual DateTime BuyDate { get; set; }

        [Required]
        public virtual Usuario User { get; set; }

        public virtual IList<PurchaseNFT> PurchaseNFTS { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Purchase purchase &&
                   PurchaseId == purchase.PurchaseId &&
                   TotalPrice == purchase.TotalPrice &&
                   BuyDate == purchase.BuyDate &&
                   EqualityComparer<Usuario>.Default.Equals(User, purchase.User);
        }
    }
}
