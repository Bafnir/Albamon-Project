using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Albamon.Models
{
    public class VentaItem
    {
        [Key]
        public int Dirección
        {
            get;
            set;
            
        }
        public int Saldo
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