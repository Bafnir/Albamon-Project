using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Albamon.Models;

namespace Albamon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<NFT> NFT { get; set; }
        public DbSet<TypeNFT> TypeNFT { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
 