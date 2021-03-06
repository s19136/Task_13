﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task13.Entities;

namespace task13.Migrations
{
    [DbContext(typeof(SweetsDBContext))]
    [Migration("20200610141730_Notes")]
    partial class Notes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("task13.Entities.Confectionery", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdConfectionery");

                    b.ToTable("Confectionery");

                    b.HasData(
                        new
                        {
                            IdConfectionery = 1,
                            Name = "Chocolate cake",
                            Price = 13.33,
                            Type = "For head"
                        },
                        new
                        {
                            IdConfectionery = 2,
                            Name = "Cheesecake",
                            Price = 6.6600000000000001,
                            Type = "For soul"
                        });
                });

            modelBuilder.Entity("task13.Entities.Confectionery_Order", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdConfectionery", "IdOrder");

                    b.HasIndex("IdOrder");

                    b.ToTable("Confectionery_Order");

                    b.HasData(
                        new
                        {
                            IdConfectionery = 1,
                            IdOrder = 1,
                            Notes = "yum",
                            Quantity = 1
                        },
                        new
                        {
                            IdConfectionery = 2,
                            IdOrder = 1,
                            Notes = "eww",
                            Quantity = 1
                        },
                        new
                        {
                            IdConfectionery = 2,
                            IdOrder = 2,
                            Notes = "nice",
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("task13.Entities.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdCustomer");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            IdCustomer = 1,
                            Name = "John",
                            Surname = "Doe"
                        },
                        new
                        {
                            IdCustomer = 2,
                            Name = "Gustavus",
                            Surname = "Adolfus"
                        });
                });

            modelBuilder.Entity("task13.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdEmployee");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            IdEmployee = 1,
                            Name = "Jan",
                            Surname = "Kowalski"
                        },
                        new
                        {
                            IdEmployee = 2,
                            Name = "Steven",
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("task13.Entities.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("IdOrder");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdEmployee");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            IdOrder = 1,
                            DateAccepted = new DateTime(2020, 6, 10, 16, 17, 29, 605, DateTimeKind.Local).AddTicks(98),
                            DateFinished = new DateTime(2020, 6, 10, 16, 17, 29, 608, DateTimeKind.Local).AddTicks(6458),
                            IdCustomer = 1,
                            IdEmployee = 1,
                            Notes = "fast"
                        },
                        new
                        {
                            IdOrder = 2,
                            DateAccepted = new DateTime(2020, 6, 10, 16, 17, 29, 608, DateTimeKind.Local).AddTicks(7860),
                            DateFinished = new DateTime(2020, 6, 10, 16, 17, 29, 608, DateTimeKind.Local).AddTicks(7896),
                            IdCustomer = 2,
                            IdEmployee = 1,
                            Notes = "for Gustavus"
                        });
                });

            modelBuilder.Entity("task13.Entities.Confectionery_Order", b =>
                {
                    b.HasOne("task13.Entities.Confectionery", "Confectionery")
                        .WithMany("Confectionery_Orders")
                        .HasForeignKey("IdConfectionery")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task13.Entities.Order", "Order")
                        .WithMany("Confectionery_Orders")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("task13.Entities.Order", b =>
                {
                    b.HasOne("task13.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task13.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
