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

        [Display(Name = "Total price:")]
        public virtual double TotalPrice { get; set; }

        [Required]
        [Display(Name = "Gas fee:")]
        public virtual double Fees { get; set; }

        [Required]
        [Display(Name = "Purchase date:")]
        public virtual DateTime BuyDate { get; set; }

        [Required]
        public virtual Usuario User { get; set; }

        public virtual IList<PurchaseNFT> PurchaseNFTS { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Purchase purchase &&
                   PurchaseId == purchase.PurchaseId &&
                   TotalPrice == purchase.TotalPrice &&
                   (this.BuyDate.Subtract(purchase.BuyDate) < new TimeSpan(0, 1, 0)) &&
                   Fees == purchase.Fees &&
                   User.Equals(purchase.User);          
        }
    }
}
