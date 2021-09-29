using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class TypeNFT
    {

    [Key]
    public virtual int Id { get; set; }

    [Required]
    public virtual string description { get; set; }

    public virtual IList<NFT> NFTS { get; set; }
    }
}
