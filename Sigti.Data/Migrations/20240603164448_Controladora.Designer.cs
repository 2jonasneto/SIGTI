﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sigti.Data.Base;

#nullable disable

namespace Sigti.Data.Migrations
{
    [DbContext(typeof(SigtiContext))]
    [Migration("20240603164448_Controladora")]
    partial class Controladora
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("Sigti.Core.Entities.AcessoControladora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid>("ControladoraId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DigitalId")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<Guid>("LocalizacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<Guid>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ControladoraId");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("SetorId");

                    b.ToTable("AcessoControladoras");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Computador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anydesk")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Disco")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("Grupos")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<Guid>("LocalizacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Memoria")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("Varchar(300)");

                    b.Property<string>("Patrimonio")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Processador")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<Guid>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SistemaOperacional")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("UltimoUsuarioLogado")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("SetorId");

                    b.ToTable("Computadores");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Controladora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<Guid>("LocalizacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<Guid>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("SetorId");

                    b.ToTable("Controladoras");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Impressora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Alugado")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Conexao")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<Guid>("LocalizacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("Varchar(300)");

                    b.Property<string>("Patrimonio")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<Guid>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("SetorId");

                    b.ToTable("Impressoras");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Localizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Localizacoes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"),
                            Ativo = true,
                            DataModificacao = new DateTime(2024, 6, 3, 13, 44, 48, 385, DateTimeKind.Local).AddTicks(8045),
                            Descricao = "",
                            ModificadoPor = "SYSTEM",
                            Nome = "MATRIZ"
                        });
                });

            modelBuilder.Entity("Sigti.Core.Entities.Setor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<Guid>("LocalizacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModificadoPor")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Setores");

                    b.HasData(
                        new
                        {
                            Id = new Guid("38f56217-8b66-4b4b-9d40-563f350e8cb4"),
                            Ativo = true,
                            DataModificacao = new DateTime(2024, 6, 3, 13, 44, 48, 385, DateTimeKind.Local).AddTicks(8445),
                            Descricao = "",
                            LocalizacaoId = new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"),
                            ModificadoPor = "SYSTEM",
                            Nome = "GERAL"
                        });
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

            modelBuilder.Entity("Sigti.Core.Entities.AcessoControladora", b =>
                {
                    b.HasOne("Sigti.Core.Entities.Controladora", "Controladora")
                        .WithMany("AcessoControladoras")
                        .HasForeignKey("ControladoraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sigti.Core.Entities.Localizacao", "Localizacao")
                        .WithMany("AcessoControladoras")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sigti.Core.Entities.Setor", "Setor")
                        .WithMany("AcessoControladoras")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Controladora");

                    b.Navigation("Localizacao");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Computador", b =>
                {
                    b.HasOne("Sigti.Core.Entities.Localizacao", "Localizacao")
                        .WithMany("Computadores")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sigti.Core.Entities.Setor", "Setor")
                        .WithMany("Computadores")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Controladora", b =>
                {
                    b.HasOne("Sigti.Core.Entities.Localizacao", "Localizacao")
                        .WithMany("Controladoras")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sigti.Core.Entities.Setor", "Setor")
                        .WithMany("Controladoras")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Impressora", b =>
                {
                    b.HasOne("Sigti.Core.Entities.Localizacao", "Localizacao")
                        .WithMany("Impressoras")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sigti.Core.Entities.Setor", "Setor")
                        .WithMany("Impressoras")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Setor", b =>
                {
                    b.HasOne("Sigti.Core.Entities.Localizacao", "Localizacao")
                        .WithMany("Setores")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Controladora", b =>
                {
                    b.Navigation("AcessoControladoras");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Localizacao", b =>
                {
                    b.Navigation("AcessoControladoras");

                    b.Navigation("Computadores");

                    b.Navigation("Controladoras");

                    b.Navigation("Impressoras");

                    b.Navigation("Setores");
                });

            modelBuilder.Entity("Sigti.Core.Entities.Setor", b =>
                {
                    b.Navigation("AcessoControladoras");

                    b.Navigation("Computadores");

                    b.Navigation("Controladoras");

                    b.Navigation("Impressoras");
                });
#pragma warning restore 612, 618
        }
    }
}
