using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Albamon.Models;
using Microsoft.AspNetCore.Identity;

namespace Albamon.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conversion> Conversion { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<MonedaConvertida> MonedaConvertida { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Wallet> Wallet{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
 