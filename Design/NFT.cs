using Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Design
{
    public class NFT
    {

    [Key]
    public virtual int NftId { get; set; }

    [Required,StringLength(80, ErrorMessage = "Longitud de string excedida")]
    public virtual string Name { get; set; }

    [Required]
    public virtual double Price { get; set; }

        [Required]
        public virtual double Health { get; set; }

        [Required]
        public virtual double Attack { get; set; }


        [Required]
    public virtual string Rarity { get; set; }

    [Required]
    public virtual TypeNFT TypeNFT { get; set; }

    public virtual IList<PurchaseNFT> PurchaseNFTS { get; set; }
        [Required]
        [NotMapped]
        public virtual TypeNFT Type
        {
            get;
            set;
        }
        [NotMapped]
        public virtual IList<VentaItem> VentaItem
        {
            get;
            set;
        }

    }
}
