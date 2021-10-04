using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class User
    {
    [Key]
    public virtual String Wallet { get; set; }

    public virtual IList<Purchase> Purchases { get; set; }

    public virtual IList<NFT> NFTSowned { get; set; }
    }
}
