
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

        public virtual int DNI
        {
            get;
            set;
            
        }
    }
}
