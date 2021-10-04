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
        public DbSet<NFT> NFT { get; set; }
        public DbSet<TypeNFT> TypeNFT { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<VentaItem> VentaItem { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
 