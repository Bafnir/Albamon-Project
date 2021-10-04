using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Design
{
    public class Venta

    {
        public Venta()
        {
            VentaItems = new List<VentaItem>();
        }

        public virtual int Precio
        {
            get;
            set;
        }

        public virtual int ID
        {
            get;
            set;
        }

        public virtual int Wallet_Signature
        {
            get;
            set;
        }
        [Key]
        public virtual int VentaID
        {
            get;
            set;
        }
        public virtual string ClienteID
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
        public virtual IList<VentaItem> VentaItems
        {
            get;
            set;
        }

     
    }

}
