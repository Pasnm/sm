﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230512061431_StudentManagement.Models.Ori")]
    partial class StudentManagementModelsOri
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagement.Models.Class", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            CId = 1,
                            ClassName = "Mathematics"
                        },
                        new
                        {
                            CId = 2,
                            ClassName = "Physics"
                        },
                        new
                        {
                            CId = 3,
                            ClassName = "Chemistry"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Lecturer", b =>
                {
                    b.Property<long>("LId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LId"));

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassCId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LId");

                    b.HasIndex("ClassCId");

                    b.ToTable("Lecturers");

                    b.HasData(
                        new
                        {
                            LId = 11L,
                            CId = 1,
                            Email = "john.doe@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            LId = 12L,
                            CId = 2,
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith"
                        },
                        new
                        {
                            LId = 13L,
                            CId = 3,
                            Email = "bob.johnson@example.com",
                            Name = "Bob Johnson"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Students", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SId"));

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassCId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SId");

                    b.HasIndex("ClassCId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            SId = 1000,
                            CId = 1,
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            SId = 1001,
                            CId = 2,
                            DateOfBirth = new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "janedoe@example.com",
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            SId = 1003,
                            CId = 3,
                            DateOfBirth = new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "charlie.brown@example.com",
                            FirstName = "Charlie",
                            LastName = "Brown"
                        },
                        new
                        {
                            SId = 1004,
                            CId = 1,
                            DateOfBirth = new DateTime(2003, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "david.davis@example.com",
                            FirstName = "David",
                            LastName = "Davis"
                        },
                        new
                        {
                            SId = 1005,
                            CId = 2,
                            DateOfBirth = new DateTime(2004, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.moore@example.com",
                            FirstName = "Emily",
                            LastName = "Moore"
                        },
                        new
                        {
                            SId = 1006,
                            CId = 3,
                            DateOfBirth = new DateTime(2005, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "frank.adams@example.com",
                            FirstName = "Frank",
                            LastName = "Adams"
                        },
                        new
                        {
                            SId = 1007,
                            CId = 1,
                            DateOfBirth = new DateTime(2006, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "grace.wright@example.com",
                            FirstName = "Grace",
                            LastName = "Wright"
                        },
                        new
                        {
                            SId = 1008,
                            CId = 2,
                            DateOfBirth = new DateTime(2007, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "henry.scott@example.com",
                            FirstName = "Henry",
                            LastName = "Scott"
                        },
                        new
                        {
                            SId = 1009,
                            CId = 3,
                            DateOfBirth = new DateTime(2008, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "isabella.taylor@example.com",
                            FirstName = "Isabella",
                            LastName = "Taylor"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Lecturer", b =>
                {
                    b.HasOne("StudentManagement.Models.Class", null)
                        .WithMany("Lecturer")
                        .HasForeignKey("ClassCId");
                });

            modelBuilder.Entity("StudentManagement.Models.Students", b =>
                {
                    b.HasOne("StudentManagement.Models.Class", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassCId");
                });

            modelBuilder.Entity("StudentManagement.Models.Class", b =>
                {
                    b.Navigation("Lecturer");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
