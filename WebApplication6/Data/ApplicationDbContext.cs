using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data.Entity;

using System;

namespace WebApplication6.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string >
    {
        public DbSet<Laba> Labas { get; set; }

        public DbSet<LabaCase> LabaCases { get; set; }

        public DbSet<Requirment> Requirments { get; set; }

        public DbSet<TestCase> TestCases { get; set; }

        public DbSet<Specification> Specifications{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().
        //        .HasOptional<Standard>(s => s.Standard)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<LabaCase>()
        //    //    //.HasOne(e=>e.TestCase)
        //    //    .HasRequired(c => c.TestCase )
        //    //    .WithMany()
        //    //    .WillC(false);

        //    //modelBuilder.Entity<Side>()
        //    //    .HasRequired(s => s.Stage)
        //    //    .WithMany()
        //    //    .WillCascadeOnDelete(false);

        //    base.OnModelCreating(builder);
        //}
    }
}
