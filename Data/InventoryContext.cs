using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }

        public DbSet <Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connectionString"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)
                .WithMany(i => i.Products)
                .HasForeignKey(p => p.InventoryID);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Inventory)
                .WithMany(i => i.Suppliers)
                .HasForeignKey(s => s.InventoryID);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Inventory)
                .WithMany(i => i.Transactions)
                .HasForeignKey(t => t.InventoryID);
        }
    }

}
