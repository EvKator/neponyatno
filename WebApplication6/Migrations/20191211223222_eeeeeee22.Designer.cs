﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication6.Data;

namespace WebApplication6.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191211223222_eeeeeee22")]
    partial class eeeeeee22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.Laba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LabaStatus");

                    b.Property<DateTime>("LastUpdateAt");

                    b.Property<long?>("Mark");

                    b.Property<int?>("SpecificationId");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.HasIndex("StudentId");

                    b.ToTable("Labas");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.LabaCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LabaId");

                    b.Property<int?>("RequirmentId");

                    b.Property<bool?>("RightAnswer");

                    b.Property<int?>("TestCaseId");

                    b.Property<int>("TestCaseType");

                    b.HasKey("Id");

                    b.HasIndex("LabaId");

                    b.HasIndex("RequirmentId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("LabaCases");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.Requirment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("SpecificationId");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.ToTable("Requirments");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastUpdateAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("QuestionsPerStudent");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.TestCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(2046);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("RequirmentId");

                    b.Property<int>("TestCaseType");

                    b.HasKey("Id");

                    b.HasIndex("RequirmentId");

                    b.ToTable("TestCases");
                });

            modelBuilder.Entity("WebApplication6.Models.LabaCaseDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RequirmentId");

                    b.Property<int?>("TestCaseId");

                    b.HasKey("Id");

                    b.HasIndex("RequirmentId");

                    b.HasIndex("TestCaseId");

                    b.ToTable("LabaCaseDto");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication6.Data.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.Laba", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.Specification", "Specification")
                        .WithMany("Labas")
                        .HasForeignKey("SpecificationId");

                    b.HasOne("WebApplication6.Data.Entity.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.LabaCase", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.Laba", "Laba")
                        .WithMany("LabaCases")
                        .HasForeignKey("LabaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication6.Data.Entity.Requirment", "Requirment")
                        .WithMany()
                        .HasForeignKey("RequirmentId");

                    b.HasOne("WebApplication6.Data.Entity.TestCase", "TestCase")
                        .WithMany()
                        .HasForeignKey("TestCaseId");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.Requirment", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.Specification", "Specification")
                        .WithMany("Requirments")
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.Specification", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.ApplicationUser", "Author")
                        .WithMany("CreatedSpecifications")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("WebApplication6.Data.Entity.TestCase", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.Requirment", "Requirment")
                        .WithMany("TestCases")
                        .HasForeignKey("RequirmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication6.Models.LabaCaseDto", b =>
                {
                    b.HasOne("WebApplication6.Data.Entity.Requirment", "Requirment")
                        .WithMany()
                        .HasForeignKey("RequirmentId");

                    b.HasOne("WebApplication6.Data.Entity.TestCase", "TestCase")
                        .WithMany()
                        .HasForeignKey("TestCaseId");
                });
#pragma warning restore 612, 618
        }
    }
}
