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
        public virtual int ID
        {
            get;
            set;
        }
       
     

        public virtual string name
        {
            get;
            set;
        }

        [Required]
        public virtual double price
        {
            get;
            set;
        }

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
