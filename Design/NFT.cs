using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class NFT
    {

    [Key]
    public virtual int ID { get; set; }

    [Required,StringLength(80, ErrorMessage = "Longitud de string excedida")]
    public virtual string name { get; set; }

    [Required]
    public virtual double price { get; set; }

    [Required]
    public virtual TypeNFT Type { get; set; }

    }
}
