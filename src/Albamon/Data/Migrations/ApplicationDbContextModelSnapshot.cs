﻿// <auto-generated />
using System;
using Albamon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Albamon.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Albamon.Models.Conversion", b =>
                {
                    b.Property<int>("ConversionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaConversion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WalletDireccion")
                        .HasColumnType("int");

                    b.HasKey("ConversionId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("WalletDireccion");

                    b.ToTable("Conversion");
                });

            modelBuilder.Entity("Albamon.Models.Moneda", b =>
                {
                    b.Property<int>("MonedaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadCompra")
                        .HasColumnType("int");

                    b.Property<int>("CantidadVenta")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MonedaId");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("Albamon.Models.MonedaConvertida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ConversionId")
                        .HasColumnType("int");

                    b.Property<int>("MonedaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConversionId");

                    b.HasIndex("MonedaId");

                    b.ToTable("MonedaConvertida");
                });

            modelBuilder.Entity("Albamon.Models.NFT", b =>
                {
                    b.Property<int>("NftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Attack")
                        .HasColumnType("float");

                    b.Property<double>("Health")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeNFTId")
                        .HasColumnType("int");

                    b.HasKey("NftId");

                    b.HasIndex("TypeNFTId");

                    b.ToTable("NFT");
                });

            modelBuilder.Entity("Albamon.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Fees")
                        .HasColumnType("float");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PurchaseId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("Albamon.Models.PurchaseNFT", b =>
                {
                    b.Property<int>("NftId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<int>("Pid")
                        .HasColumnType("int");

                    b.HasKey("NftId", "PurchaseId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseNFTS");
                });

            modelBuilder.Entity("Albamon.Models.TypeNFT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TypeNFT");
                });

            modelBuilder.Entity("Albamon.Models.Venta", b =>
                {
                    b.Property<int>("VentaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("WalletDireccion")
                        .HasColumnType("int");

                    b.HasKey("VentaID");

                    b.HasIndex("ClienteId");

                    b.HasIndex("WalletDireccion");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Albamon.Models.VentaItem", b =>
                {
                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("NFTID")
                        .HasColumnType("int");

                    b.Property<int>("VentaID")
                        .HasColumnType("int");

                    b.HasIndex("NFTID");

                    b.HasIndex("VentaID");

                    b.ToTable("VentaItems");
                });

            modelBuilder.Entity("Albamon.Models.Wallet", b =>
                {
                    b.Property<int>("Direccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTransaccion")
                        .HasColumnType("int");

                    b.Property<int>("Saldo")
                        .HasColumnType("int");

                    b.HasKey("Direccion");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Albamon.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Wallet")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Albamon.Models.Admin", b =>
                {
                    b.HasBaseType("Albamon.Models.ApplicationUser");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Albamon.Models.Cliente", b =>
                {
                    b.HasBaseType("Albamon.Models.ApplicationUser");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Albamon.Models.Usuario", b =>
                {
                    b.HasBaseType("Albamon.Models.ApplicationUser");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NftId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasIndex("NftId");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("Albamon.Models.Conversion", b =>
                {
                    b.HasOne("Albamon.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Albamon.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletDireccion");

                    b.Navigation("Cliente");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Albamon.Models.MonedaConvertida", b =>
                {
                    b.HasOne("Albamon.Models.Conversion", "Conversion")
                        .WithMany("MonedasConvertidas")
                        .HasForeignKey("ConversionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Albamon.Models.Moneda", "Moneda")
                        .WithMany("MonedasConvertidas")
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversion");

                    b.Navigation("Moneda");
                });

            modelBuilder.Entity("Albamon.Models.NFT", b =>
                {
                    b.HasOne("Albamon.Models.TypeNFT", "TypeNFT")
                        .WithMany("NFTS")
                        .HasForeignKey("TypeNFTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeNFT");
                });

            modelBuilder.Entity("Albamon.Models.Purchase", b =>
                {
                    b.HasOne("Albamon.Models.Usuario", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Albamon.Models.PurchaseNFT", b =>
                {
                    b.HasOne("Albamon.Models.NFT", "NFT")
                        .WithMany("PurchaseNFTS")
                        .HasForeignKey("NftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Albamon.Models.Purchase", "Purchase")
                        .WithMany("PurchaseNFTS")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NFT");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Albamon.Models.Venta", b =>
                {
                    b.HasOne("Albamon.Models.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Albamon.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletDireccion");

                    b.Navigation("Cliente");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Albamon.Models.VentaItem", b =>
                {
                    b.HasOne("Albamon.Models.NFT", "NFT")
                        .WithMany()
                        .HasForeignKey("NFTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Albamon.Models.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NFT");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Albamon.Models.Usuario", b =>
                {
                    b.HasOne("Albamon.Models.NFT", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("NftId");
                });

            modelBuilder.Entity("Albamon.Models.Conversion", b =>
                {
                    b.Navigation("MonedasConvertidas");
                });

            modelBuilder.Entity("Albamon.Models.Moneda", b =>
                {
                    b.Navigation("MonedasConvertidas");
                });

            modelBuilder.Entity("Albamon.Models.NFT", b =>
                {
                    b.Navigation("PurchaseNFTS");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Albamon.Models.Purchase", b =>
                {
                    b.Navigation("PurchaseNFTS");
                });

            modelBuilder.Entity("Albamon.Models.TypeNFT", b =>
                {
                    b.Navigation("NFTS");
                });

            modelBuilder.Entity("Albamon.Models.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
