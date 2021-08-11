﻿// <auto-generated />
using EntityFrameworkCoreTesting.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCoreTesting.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210811072357_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCoreTesting.DataModels.Models.Test1", b =>
                {
                    b.Property<int>("Test1Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Test1Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Test1Other")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Test1Id");

                    b.ToTable("EFCore_Test1");

                    b.HasData(
                        new
                        {
                            Test1Id = 1,
                            Test1Name = "Product",
                            Test1Other = "123"
                        },
                        new
                        {
                            Test1Id = 2,
                            Test1Name = "Entity",
                            Test1Other = "Q"
                        },
                        new
                        {
                            Test1Id = 3,
                            Test1Name = "Car",
                            Test1Other = "Wif"
                        },
                        new
                        {
                            Test1Id = 4,
                            Test1Name = "Hope",
                            Test1Other = "Were"
                        },
                        new
                        {
                            Test1Id = 5,
                            Test1Name = "Fear",
                            Test1Other = "Dash"
                        },
                        new
                        {
                            Test1Id = 6,
                            Test1Name = "Bus",
                            Test1Other = "Crash"
                        },
                        new
                        {
                            Test1Id = 7,
                            Test1Name = "EF Core",
                            Test1Other = "C Sharp"
                        });
                });

            modelBuilder.Entity("EntityFrameworkCoreTesting.DataModels.Models.Test2", b =>
                {
                    b.Property<string>("Test2Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Test1Id")
                        .HasColumnType("int");

                    b.HasKey("Test2Id");

                    b.HasIndex("Test1Id");

                    b.ToTable("EFCore_Test2");

                    b.HasData(
                        new
                        {
                            Test2Id = "T1-1",
                            Test1Id = 1
                        },
                        new
                        {
                            Test2Id = "T2-1",
                            Test1Id = 1
                        },
                        new
                        {
                            Test2Id = "T3-1",
                            Test1Id = 1
                        },
                        new
                        {
                            Test2Id = "T4-2",
                            Test1Id = 2
                        },
                        new
                        {
                            Test2Id = "T5-2",
                            Test1Id = 2
                        },
                        new
                        {
                            Test2Id = "T6-2",
                            Test1Id = 2
                        },
                        new
                        {
                            Test2Id = "T7-3",
                            Test1Id = 3
                        },
                        new
                        {
                            Test2Id = "T8-4",
                            Test1Id = 4
                        },
                        new
                        {
                            Test2Id = "T9-4",
                            Test1Id = 4
                        },
                        new
                        {
                            Test2Id = "T10-4",
                            Test1Id = 4
                        },
                        new
                        {
                            Test2Id = "T11-4",
                            Test1Id = 4
                        },
                        new
                        {
                            Test2Id = "T12-5",
                            Test1Id = 5
                        },
                        new
                        {
                            Test2Id = "T13-5",
                            Test1Id = 5
                        },
                        new
                        {
                            Test2Id = "T14-6",
                            Test1Id = 6
                        },
                        new
                        {
                            Test2Id = "T15-7",
                            Test1Id = 7
                        },
                        new
                        {
                            Test2Id = "T16-7",
                            Test1Id = 7
                        });
                });

            modelBuilder.Entity("EntityFrameworkCoreTesting.DataModels.Models.Test2", b =>
                {
                    b.HasOne("EntityFrameworkCoreTesting.DataModels.Models.Test1", "Test1")
                        .WithMany("Test2s")
                        .HasForeignKey("Test1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test1");
                });

            modelBuilder.Entity("EntityFrameworkCoreTesting.DataModels.Models.Test1", b =>
                {
                    b.Navigation("Test2s");
                });
#pragma warning restore 612, 618
        }
    }
}
