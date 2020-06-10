using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task13.Entities
{
    public class SweetsDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<Confectionery_Order> Confectionery_Orders { get; set; }
        public SweetsDBContext()
        {

        }

        public SweetsDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(60);

                entity.ToTable("Employee");

                entity.HasMany(d => d.Orders)
                      .WithOne(p => p.Employee)
                      .HasForeignKey(p => p.IdEmployee)
                      .IsRequired();

                var data = new List<Employee>();
                data.Add(new Employee { IdEmployee = 1, Name = "Jan", Surname = "Kowalski"});
                data.Add(new Employee { IdEmployee = 2, Name = "Steven", Surname = "Smith"});
                entity.HasData(data);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);
                entity.Property(e => e.IdCustomer).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(60);

                entity.ToTable("Customer");

                entity.HasMany(d => d.Orders)
                      .WithOne(p => p.Customer)
                      .HasForeignKey(p => p.IdCustomer)
                      .IsRequired();

                var data = new List<Customer>();
                data.Add(new Customer { IdCustomer = 1, Name = "John", Surname = "Doe"});
                data.Add(new Customer { IdCustomer = 2, Name = "Gustavus", Surname = "Adolfus"});
                entity.HasData(data);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.Property(e => e.IdOrder).ValueGeneratedOnAdd();
                entity.Property(e => e.DateAccepted).IsRequired();
                entity.Property(e => e.DateFinished).IsRequired();
                entity.Property(e => e.Notes).IsRequired().HasMaxLength(255);

                entity.ToTable("Order");

                entity.HasMany(d => d.Confectionery_Orders)
                      .WithOne(p => p.Order)
                      .HasForeignKey(p => p.IdOrder)
                      .IsRequired();

                var data = new List<Order>();
                data.Add(new Order { IdOrder = 1, IdCustomer = 1, IdEmployee = 1, DateAccepted = DateTime.Now, DateFinished = DateTime.Now, Notes = "fast" });
                data.Add(new Order { IdOrder = 2, IdCustomer = 2, IdEmployee = 1, DateAccepted = DateTime.Now, DateFinished = DateTime.Now, Notes = "for Gustavus" });
                entity.HasData(data);
            });

            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConfectionery);
                entity.Property(e => e.IdConfectionery).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Type).IsRequired().HasMaxLength(40);

                entity.ToTable("Confectionery");

                entity.HasMany(d => d.Confectionery_Orders)
                      .WithOne(p => p.Confectionery)
                      .HasForeignKey(p => p.IdConfectionery)
                      .IsRequired();

                var data = new List<Confectionery>();
                data.Add(new Confectionery { IdConfectionery = 1, Name = "Chocolate cake", Price = 13.33, Type = "For head" });
                data.Add(new Confectionery { IdConfectionery = 2, Name = "Cheesecake", Price = 6.66, Type = "For soul" });
                entity.HasData(data);
            });

            modelBuilder.Entity<Confectionery_Order>(entity =>
            {
                entity.HasKey(e => new { e.IdConfectionery, e.IdOrder});
                entity.Property(e => e.Notes).IsRequired().HasMaxLength(255);
                entity.ToTable("Confectionery_Order");

                var data = new List<Confectionery_Order>();
                data.Add(new Confectionery_Order { IdConfectionery = 1, IdOrder = 1, Quantity = 1, Notes = "yum" });
                data.Add(new Confectionery_Order { IdConfectionery = 2, IdOrder = 1, Quantity = 1, Notes = "eww" });
                data.Add(new Confectionery_Order { IdConfectionery = 2, IdOrder = 2, Quantity = 2, Notes = "nice" });
                entity.HasData(data);
            });
        }
    }
}
