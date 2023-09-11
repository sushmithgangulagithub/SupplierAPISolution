using Microsoft.EntityFrameworkCore;
using SupplierAPI.Models;

namespace SupplierAPI.Contexts
{
    public class SupplierContext : DbContext
    {
        public SupplierContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Supplier>().HasKey(es => new { es.Id, es.Email });

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 101, Name = "Sushu", Email = "Sushu@gmail.com", Phone = "9346634344" },
                new Supplier { Id = 102, Name = "Kavya", Email = "Kavya@gmail.com", Phone = "9573368510" }

                );
            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Sunscreen", Description = "Protect from sun", Price = 36, SupplierId =101 },
               new Product { Id = 2, Name = "fairnesscream", Description = "whitening the skin", Price = 45, SupplierId = 102}

               );


        }

    }
}