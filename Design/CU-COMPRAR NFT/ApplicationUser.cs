﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Design { 
    public class ApplicationUser : IdentityUser
    {
    public virtual String Wallet { get; set; }

    }
}