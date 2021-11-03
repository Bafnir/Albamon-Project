using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Albamon.Models
{
    public class Wallet
    {
        [Key]
        public virtual int Direccion
        {
            get;
            set;

        }
        public virtual int Saldo
        {
            get;
            set;

        }
        public virtual int IdTransaccion
        {
            get;
            set;
        }

       
    }
}