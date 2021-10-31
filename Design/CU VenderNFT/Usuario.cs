
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
namespace Design

{
    public class Usuario : ApplicationUser
    {
        public virtual int Nombre
        {
            get;
            set;
            
        }

        public virtual int Apellidos
        {
            get;
            set;
           
        }

        public virtual int DNI
        {
            get;
            set;
            
        }

        public virtual IList<NFT> NFTS { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }
    }
}
