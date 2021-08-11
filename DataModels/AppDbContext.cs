using EntityFrameworkCoreTesting.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Test1> Test1s { get; set; }
        public DbSet<Test2> Test2s { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Test1>().ToTable("EFCore_Test1");
            builder.Entity<Test2>().ToTable("EFCore_Test2");

            builder.Entity<Test2>()
                .HasOne(t2 => t2.Test1)
                .WithMany(t1 => t1.Test2s)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
