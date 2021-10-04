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
    
    public virtual User User { get; set; }
    }
}
