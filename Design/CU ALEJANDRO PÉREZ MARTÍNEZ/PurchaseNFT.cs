using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Design
{
    public class PurchaseNFT
    {
    [Key]
    public virtual int Pid { get; set; }
    [Required]    
    public virtual double Fee { get; set; }
    [ForeignKey("NftId")]
    public virtual NFT NFT { get; set; }
    public virtual int NftId { get; set; }

    [ForeignKey("PurchaseId")]
    public virtual Purchase Purchase { get; set; }
    public virtual int PurchaseId { get; set; }
    }
}
