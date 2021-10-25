using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Albamon.Models
{
    public class Venta

    {


        [Key]
        public virtual int VentaID
        {
            get;
            set;
        }
        public virtual int Price
        {
            get;
            set;
        }



        public virtual Wallet Wallet
        {
            get;
            set;
        }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente
        {
            get;
            set;
        }

        [NotMapped]
        public virtual IList<VentaItem> VentaItems
        {
            get;
            set;
        }


    }

}
