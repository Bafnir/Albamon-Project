using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public class Moneda
    {
        [Key]
        public virtual int MonedaId
        {
            get;
            set;
        }
        [Required]
        [StringLength(10, ErrorMessage = "Nombre de la moneda")]
        public virtual String Nombre
        {
            get;
            set;
        }
       
        [Range(1, int.MaxValue, ErrorMessage = "No posee la cantidad minima de 1 para comprar")]
        public virtual int CantidadCompra
        {
            get;
            set;
        }
        [Range(100, int.MaxValue, ErrorMessage = "Minima de cantidad de 100 para vender")]
        public virtual int CantidadVenta
        {
            get;
            set;
        }
        public virtual IList<MonedaConvertida> MonedasConvertidas
        {
            get;
            set;
        }
    }
}
