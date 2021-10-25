using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albamon.Models
{
   public class MonedaConvertida
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        [ForeignKey("MonedaId")]
        public virtual Moneda Moneda
        {
            get;
            set;
        }
        public virtual int MonedaId
        {
            get;
            set;
        }


        [Range(1, Double.MaxValue, ErrorMessage = "Cantidad insuficiente de monedas")]
        public virtual int Cantidad
        {
            get;
            set;
        }
        [ForeignKey("ConversionId")]
        public virtual Conversion Conversion
        {
            get;
            set;
        }

        public virtual int ConversionId
        {
            get;
            set;
        }
    }
}
