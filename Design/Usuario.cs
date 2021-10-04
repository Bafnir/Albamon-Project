
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
namespace Albamon.Models

{
    public class Usuario : IdentityUser
    {
        public int Nombre
        {
            get;
            set;
            
        }

        public int Apellidos
        {
            get;
            set;
           
        }

        public int DNI
        {
            get;
            set;
            
        }
    }
}
