using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class PurchaseNFT
    {
        [Key]
        public virtual int Pid { get; set; }
        [Required]
        public virtual double Fee { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "You must provide a valid quantity")]
        public virtual int Quantity
        {
            get;
            set;
        }

        [ForeignKey("NftId")]
        public virtual NFT NFT { get; set; }
        public virtual int NftId { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }
        public virtual int PurchaseId { get; set; }


        public override bool Equals(object obj)
        {
            return obj is PurchaseNFT item &&
                   Pid == item.Pid &&
                   EqualityComparer<NFT>.Default.Equals(NFT, item.NFT) &&
                   Quantity == item.Quantity &&
                   NftId == item.NftId &&
                   EqualityComparer<Purchase>.Default.Equals(Purchase, item.Purchase) &&
                   PurchaseId == item.PurchaseId;
        }
    }


}


