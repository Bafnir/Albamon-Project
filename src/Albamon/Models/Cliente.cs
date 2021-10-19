using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
namespace Design
{
    public class Cliente : ApplicationUser
    {

        public virtual IList<Venta> Ventas { get; set; }
        public virtual IList<Conversion> Conversiones
        {
            get;
            set;
        }

    }
}
