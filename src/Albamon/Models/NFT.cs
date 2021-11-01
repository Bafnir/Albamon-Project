using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class NFT
    {
        [Key]
        public virtual int NftId { get; set; }

        [Required, StringLength(80, ErrorMessage = "Longitud de string excedida")]
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

        public virtual IList<Usuario> Usuarios { get; set; }

        public override bool Equals(object obj)
        {
            return obj is NFT nft &&
                   NftId == nft.NftId &&
                   Name == nft.Name &&
                   Price == nft.Price &&
                   Health == nft.Health &&
                   Attack == nft.Attack &&
                   Rarity == nft.Rarity &&
                   EqualityComparer<TypeNFT>.Default.Equals(TypeNFT, nft.TypeNFT);
        }

    }
}
