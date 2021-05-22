using DepartmentalStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Data
{
    public class DepartmetalStoreContext : DbContext 
    {
        public DbSet<staff> staff { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> productCategory { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProduct> SupplierProduct { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; DataBase = DepartmentalStoreEF ; Username = postgres; Password = root");
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure Role
            modelBuilder.Entity<Role>().Property(x => x.RoleId).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<Role>().Property(x => x.RoleName).HasMaxLength(64);
            modelBuilder.Entity<Role>().Property(x => x.Description).HasMaxLength(512);

            //Configure Address
            modelBuilder.Entity<Address>().Property(x => x.AddressId).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.AddressLine1).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.AddressLine2).HasMaxLength(128);
            modelBuilder.Entity<Address>().Property(x => x.City).HasMaxLength(32);
            modelBuilder.Entity<Address>().Property(x => x.State).HasMaxLength(32);
            modelBuilder.Entity<Address>().Property(x => x.Pincode).HasMaxLength(16);

            //Configure Categories
            modelBuilder.Entity<Category>().Property(x => x.CategoryId).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).HasMaxLength(128);


            //Configure Inventory
            modelBuilder.Entity<Inventory>().Property(x => x.InventoryId).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<Inventory>().Property(x => x.ProductId).HasMaxLength(128);
            modelBuilder.Entity<Inventory>().Property(x => x.Instock).HasMaxLength(128);
            modelBuilder.Entity<Inventory>().Property(x => x.Quantity).HasMaxLength(32).IsRequired();



            //Configure Product
            modelBuilder.Entity<Product>().Property(x => x.Id).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.ShortCode).HasMaxLength(128);
            modelBuilder.Entity<Product>().Property(x => x.Manufacturer).HasMaxLength(64);
            modelBuilder.Entity<Product>().Property(x => x.CostPrice).HasMaxLength(512);
            modelBuilder.Entity<Product>().Property(x => x.SellingPrice).HasMaxLength(512);


            //Configure ProductCategory
            modelBuilder.Entity<ProductCategory>().Property(x => x.Id).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<ProductCategory>().Property(x => x.CategoryId).HasMaxLength(128).IsRequired();




            //Configure PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>().HasKey(x => x.OrderId);
            modelBuilder.Entity<PurchaseOrder>().Property(x => x.ProductId).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<PurchaseOrder>().Property(x => x.SupplierId).HasMaxLength(128);
            modelBuilder.Entity<PurchaseOrder>().Property(x => x.QuantityRequired).HasMaxLength(512);
            modelBuilder.Entity<PurchaseOrder>().Property(x => x.OrderDate).HasMaxLength(512);



            //Configure Staff
            modelBuilder.Entity<staff>().Property(x => x.staffId).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<staff>().Property(x => x.AddressId).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<staff>().Property(x => x.RoleId).HasMaxLength(32);
            modelBuilder.Entity<staff>().Property(x => x.FirstName).HasMaxLength(128);
            modelBuilder.Entity<staff>().Property(x => x.LastName).HasMaxLength(128);
            modelBuilder.Entity<staff>().Property(x => x.Email).HasMaxLength(128);





            //Configure Supplier
            modelBuilder.Entity<Supplier>().Property(x => x.SupplierId).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<Supplier>().Property(x => x.SupplierName).HasMaxLength(128);
            modelBuilder.Entity<Supplier>().Property(x => x.SupplierPhoneNumber).HasMaxLength(128);
            modelBuilder.Entity<Supplier>().Property(x => x.Email).HasMaxLength(32);
            modelBuilder.Entity<Supplier>().Property(x => x.Gender).HasMaxLength(32);
            modelBuilder.Entity<Supplier>().Property(x => x.City).HasMaxLength(16);



            //Configure SupplierProduct
            modelBuilder.Entity<SupplierProduct>().Property(x => x.Id).HasMaxLength(32).IsRequired();
            modelBuilder.Entity<SupplierProduct>().Property(x => x.SupplierId).HasMaxLength(128).IsRequired();


            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.Id, pc.CategoryId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
