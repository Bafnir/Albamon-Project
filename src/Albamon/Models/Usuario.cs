
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
namespace Albamon.Models

{
    public class Usuario : ApplicationUser
    {
        public virtual string Nombre
        {
            get;
            set;
            
        }

        public virtual string Apellidos
        {
            get;
            set;
           
        }

        public virtual string DNI
        {
            get;
            set;
            
        }
        public virtual double Saldo { get; set; }

        public virtual IList<Purchase> Purchases
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   Nombre == usuario.Nombre &&
                   Apellidos == usuario.Apellidos &&
                   Id == usuario.Id &&
                   UserName == usuario.UserName &&
                   PhoneNumber == usuario.PhoneNumber;
        }
    }

}
