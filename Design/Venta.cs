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

        public int price
        {
            get => default;
            set
            {
            }
        }

        public int ID
        {
            get => default;
            set
            {
            }
        }

        public int signature
        {
            get => default;
            set
            {
            }
        }
        [Key]
        public int VentaID
        {
            get => default;
            set
            {
            }
        }
        public string ClienteID
        {
            get;
            set;
        }

        [Display(Name = "Payment Method")]
        [Required()]
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

        public void Equals()
        {
            throw new System.NotImplementedException();
        }
    }

}
