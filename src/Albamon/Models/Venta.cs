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
        public Venta()
        {
            throw new System.NotImplementedException();
        }

        public int Precio
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public int Wallet_Signature
        {
            get;
            set;
        }
        [Key]
        public int VentaID
        {
            get;
            set;
        }
        public string ClienteID
        {
            get;
            set;
        }

       
        public Wallet Wallet
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

        public void Equals()
        {
            throw new System.NotImplementedException();
        }
    }

}
