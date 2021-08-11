using EntityFrameworkCoreTesting.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels
{
    /// <summary>
    /// The app database context class. 
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Database set for Test1.
        /// </summary>
        public DbSet<Test1> Test1s { get; set; }
        /// <summary>
        /// Database set for Test2.
        /// </summary>
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

            //if a column property accessor is private, EF Core needs to be informed of it, https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/november/data-points-backing-field-and-owned-entity-changes-in-ef-core-3-0
            //Seems to be working with how it is done in this test project. 

            builder.Entity<Test1>()
                .HasData(new List<Test1>()
                {
                    new Test1(1,"Product","123"),
                    new Test1(2,"Entity","Q"),
                    new Test1(3,"Car","Wif"),
                    new Test1(4,"Hope","Were"),
                    new Test1(5,"Fear","Dash"),
                    new Test1(6,"Bus","Crash"),
                    new Test1(7,"EF Core","C Sharp"),
                }
            );

            builder.Entity<Test2>()
                .HasData(new List<Test2>()
                {
                    new Test2("T1-1",1),
                    new Test2("T2-1",1),
                    new Test2("T3-1",1),
                    new Test2("T4-2",2),
                    new Test2("T5-2",2),
                    new Test2("T6-2",2),
                    new Test2("T7-3",3),
                    new Test2("T8-4",4),
                    new Test2("T9-4",4),
                    new Test2("T10-4",4),
                    new Test2("T11-4",4),
                    new Test2("T12-5",5),
                    new Test2("T13-5",5),
                    new Test2("T14-6",6),
                    new Test2("T15-7",7),
                    new Test2("T16-7",7),
                }
            );

        }
    }
}
