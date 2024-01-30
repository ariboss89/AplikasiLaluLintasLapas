﻿// <auto-generated />
using System;
using AplikasiLaluLintasLapas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AplikasiLaluLintasLapas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240125164306_AddPerkaraToWbpTabel")]
    partial class AddPerkaraToWbpTabel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AplikasiLaluLintasLapas.Models.Aplusan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Asimilasi")
                        .HasColumnType("int");

                    b.Property<int>("BonKejaksaan")
                        .HasColumnType("int");

                    b.Property<int>("BonKerja")
                        .HasColumnType("int");

                    b.Property<int>("BonLain")
                        .HasColumnType("int");

                    b.Property<int>("BonPolisi")
                        .HasColumnType("int");

                    b.Property<int>("Cuti")
                        .HasColumnType("int");

                    b.Property<string>("DariRupam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DinasLuar")
                        .HasColumnType("int");

                    b.Property<int>("Hadir")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Izin")
                        .HasColumnType("int");

                    b.Property<int>("JumlahKeseluruhan")
                        .HasColumnType("int");

                    b.Property<int>("JumlahWBP")
                        .HasColumnType("int");

                    b.Property<string>("KeRupam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Narapidana")
                        .HasColumnType("int");

                    b.Property<int>("NarapidanaPria")
                        .HasColumnType("int");

                    b.Property<int>("NarapidanaWanita")
                        .HasColumnType("int");

                    b.Property<int>("Pengawalan")
                        .HasColumnType("int");

                    b.Property<int>("Personil")
                        .HasColumnType("int");

                    b.Property<int>("RSUD")
                        .HasColumnType("int");

                    b.Property<int>("Sakit")
                        .HasColumnType("int");

                    b.Property<int>("SidangNarapidana")
                        .HasColumnType("int");

                    b.Property<int>("SidangTahanan")
                        .HasColumnType("int");

                    b.Property<int>("Tahanan")
                        .HasColumnType("int");

                    b.Property<int>("TahananPria")
                        .HasColumnType("int");

                    b.Property<int>("TahananWanita")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tidak")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aplusans");
                });

            modelBuilder.Entity("AplikasiLaluLintasLapas.Models.BonKerja", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Jumlah")
                        .HasColumnType("int");

                    b.Property<string>("NamaKaRupam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NipKaRupam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Petugas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.Property<string>("TtdKaKpr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TtdKaRupam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TtdKaRutan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TtdKaYantah")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTtdKaKpr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTtdKaRupam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTtdKaRutan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTtdKasiYantah")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BonKerjas");
                });

            modelBuilder.Entity("AplikasiLaluLintasLapas.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("config_key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("config_value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("AplikasiLaluLintasLapas.Models.DtBonKerja", b =>
                {
                    b.Property<int>("IdDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetail"));

                    b.Property<string>("Blok")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdBonKerja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisBonKerja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaWBP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDetail");

                    b.ToTable("DtBonKerjas");
                });

            modelBuilder.Entity("AplikasiLaluLintasLapas.Models.Wbp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BlokTahanan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JenisKelamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasaTahanan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perkara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wbps");
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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
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

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AplikasiLaluLintasLapas.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Kontak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTTd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
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
#pragma warning restore 612, 618
        }
    }
}
