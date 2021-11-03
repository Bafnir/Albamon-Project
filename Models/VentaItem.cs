
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace Albamon.Models
{
    [Keyless]
    public class VentaItem
    {



        
        public virtual int Cantidad
        {
            get;
            set;
        }

        
        public virtual int NFTID
        {
            get;
            set;
        }
        [ForeignKey("VentaID")]
        public virtual Venta Venta
        {
            get;
            set;
        }
        
        public virtual NFT NFT
        {
            get;
            set;
        }
       
        public virtual int VentaID
        {
            get;
            set;
        }

      
    }

}