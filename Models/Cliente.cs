using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
namespace Albamon.Models
{
    public class Cliente : ApplicationUser
    {

        public virtual IList<Venta> Ventas { get; set; }
      
    }
}
