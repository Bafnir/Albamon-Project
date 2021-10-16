using Albamon.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Albamon.Models
{
    public class TypeNFT
    {

        [Key]
        public virtual int Id { get; set; }
        public virtual int TypeID { get; set; }
        public virtual IList<NFT> NFTS { get; set; }
        [Required]
        public virtual string description { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual int Tier { get; set; }
    }
}
