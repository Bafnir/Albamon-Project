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
        public DbSet<PurchaseNFT> PurchaseNFTS { get; set; }

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
 