﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Design
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

        [Range(1, Double.MaxValue, ErrorMessage = "Cantidad insuficiente de monedas")]
        public virtual int Cantidad
        {
            get;
            set;
        }

        public virtual int monedaId
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
