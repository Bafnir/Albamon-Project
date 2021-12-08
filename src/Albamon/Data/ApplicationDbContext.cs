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
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseNFT> PurchaseNFT { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaItem> VentaItems { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<MonedaConvertida> MonedaConvertida { get; set; }
        public DbSet<Conversion> Conversion { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PurchaseNFT>()
            .HasKey(pi => new { pi.NftId, pi.PurchaseId });
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){ }       
    }
}
 