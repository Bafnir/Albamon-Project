using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albamon.Models
{
    public class Conversion
    {
        [Key]
        public int ConversionId
        {
            get;
            set;
        }



        public DateTime FechaConversion
        {
            get;
            set;
        }


        public virtual IList<MonedaConvertida> MonedasConvertidas
        {
            get;
            set;
        }
        public Conversion()
        {

            MonedasConvertidas = new List<MonedaConvertida>();
        }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente
        {
            get;
            set;
        }

        
        public string ClienteId
        {
            get;
            set;
        }

        [Display(Name = "Wallet")]
        [Required()]
        public Wallet Wallet
        {
            get;
            set;
        }
    }
}
