using DepartmentalStore.Data;
using DepartmentalStore.Domain;
using System;

namespace DepartmentalStoreEF
{
    class Program
    {
        public static DepartmetalStoreContext Context = new DepartmetalStoreContext();
        static void Main(string[] args)
        {
            AddAddress();
            AddCategory();
            AddInventory();
            AddProduct();
            AddProductCategory();
            AddPurchaseOrder();
            AddRole();
            AddStaff();
            AddSupplier();
            AddSupplierProduct();
            Console.WriteLine("Operation Successful...");
        }
        //Insert Values in Role Table
        public static void AddRole()
        {
            var Role1 = new Role { RoleName = "Registrar", Description = "Registration" };
            var Role2 = new Role { RoleName = "Guard", Description = "Protecting Store" };
            var Role3 = new Role { RoleName = "Sweeper", Description = "Cleaning Store" };
            var Role4 = new Role { RoleName = "Manager", Description = "Managing WorkFlow" };
            Context.AddRange(Role1, Role2, Role3, Role4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }


        //Insert Values in Staff Table
        public static void AddStaff()
        {
            var staff1 = new staff { RoleId = 4, AddressId = 4, FirstName = "Mohan", LastName = "Rajput", Email = "mohanrajput123@gmail.com" };
            var staff2 = new staff { RoleId = 5, AddressId = 5, FirstName = "Sohan", LastName = "Rajpoot", Email = "sohan123@gmail.com" };
            var staff3 = new staff { RoleId = 6, AddressId = 6, FirstName = "Vivek", LastName = "Kumar", Email = "vivek123@gmail.com" };
            var staff4 = new staff { RoleId = 7, AddressId = 7, FirstName = "Rajan", LastName = "Kumar", Email = "rajan123@gmail.com" };
            Context.AddRange(staff1, staff2, staff3, staff4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }


        //Insert Values in Category Table
        public static void AddCategory()
        {
            var category1 = new Category { CategoryName = "Stationary" };
            var category2 = new Category { CategoryName = "Electronics" };
            var category3 = new Category { CategoryName = "Men Wears" };
            var category4 = new Category { CategoryName = "Chocolates" };
            Context.AddRange(category1, category2, category3, category4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        //Insert Values in Address Table
        public static void AddAddress()
        {
            var Address1 = new Address { AddressLine1 = "Kasganj", AddressLine2 = "Chharra Road", City = "Kasganj", State = "Uttar Pradesh", Pincode = "207123" };
            var Address2 = new Address { AddressLine1 = "Ramgarh", AddressLine2 = "Lal Diggi", City = "Aligarh", State = "Uttar Pradesh", Pincode = "202130" };
            var Address3 = new Address { AddressLine1 = "Bareilly", AddressLine2 = "Mathura Road", City = "Bareilly", State = "Pradesh Pradesh", Pincode = "207302" };
            var Address4 = new Address { AddressLine1 = "Hanuman Chowk", AddressLine2 = "Marehra", City = "Etah", State = "Uttar Pradesh", Pincode = "204701" };
            Context.AddRange(Address1, Address2, Address3, Address4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }


        //Insert Values in Inventory Table
        public static void AddInventory()
        {
            var Inventory1 = new Inventory { ProductId = 1, Instock = true, Quantity = 15 };
            var Inventory2 = new Inventory { ProductId = 2, Instock = false, Quantity = 25 };
            var Inventory3 = new Inventory { ProductId = 3, Instock = true, Quantity = 40 };
            var Inventory4 = new Inventory { ProductId = 4, Instock = false, Quantity = 30 };
            Context.AddRange(Inventory1, Inventory2, Inventory3, Inventory4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
            
        }


        //Insert Values in Product Table
        public static void AddProduct()
        {
            var Product1 = new Product { Name = "Jeans", Manufacturer = "COBB", ShortCode = "Bottomwear", CostPrice = 2500, SellingPrice = 3500 };
            var Product2 = new Product { Name = "Shirts", Manufacturer = "Peter England", ShortCode = "Upperwear", CostPrice = 1500, SellingPrice = 2500 };
            var Product3 = new Product { Name = "Shoes", Manufacturer = "Adidas", ShortCode = "Footwear", CostPrice = 5500, SellingPrice = 7900 };
            var Product4 = new Product { Name = "Chocolates", Manufacturer = "DairyMilk", ShortCode = "Eatable", CostPrice = 150, SellingPrice = 600 };
            Context.AddRange(Product1, Product2, Product3, Product4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }

        }


        //Insert Values in ProductCategory Table
        public static void AddProductCategory()
        {
            var ProductCategory1 = new ProductCategory { Id = 1, CategoryId = 1 };
            var ProductCategory2 = new ProductCategory { Id = 2, CategoryId = 2 };
            var ProductCategory3 = new ProductCategory { Id = 3, CategoryId = 3 };
            var ProductCategory4 = new ProductCategory { Id = 4, CategoryId = 4 };
            Context.AddRange(ProductCategory1, ProductCategory2, ProductCategory3, ProductCategory4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }

        }

        //Insert Values in PurchaseOrder Table
        public static void AddPurchaseOrder()
        {
            var PurchaseOrder1 = new PurchaseOrder { ProductId = 1, SupplierId = 1, OrderDate = "2019-08-11", QuantityRequired = 90 };
            var PurchaseOrder2 = new PurchaseOrder { ProductId = 2, SupplierId = 2, OrderDate = "2012-05-22", QuantityRequired = 50 };
            var PurchaseOrder3 = new PurchaseOrder { ProductId = 3, SupplierId = 3, OrderDate = "2016-09-15", QuantityRequired = 30 };
            var PurchaseOrder4 = new PurchaseOrder { ProductId = 4, SupplierId = 4, OrderDate = "2015-09-29", QuantityRequired = 70 };
            Context.AddRange(PurchaseOrder1, PurchaseOrder2, PurchaseOrder3, PurchaseOrder4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }

        }



        //Insert Values in Supplier Table
        public static void AddSupplier()
        {
            var Supplier1 = new Supplier { SupplierName = "Maxico", SupplierPhoneNumber = "9876567897", Gender = 'M', Email = "maxico123@gmail.com", City = "San Francisco" };
            var Supplier2 = new Supplier { SupplierName = "Rexin", SupplierPhoneNumber = "8765456789", Gender = 'F', Email = "rexin123@gmail.com", City = "California" };
            var Supplier3 = new Supplier { SupplierName = "Adaan", SupplierPhoneNumber = "8754345676", Gender = 'F', Email = "adaan123@gmail.com", City = "New York" };
            var Supplier4 = new Supplier { SupplierName = "Maxin", SupplierPhoneNumber = "9867546789", Gender = 'M', Email = "maxin123@gmail.com", City = "Seattle" };
            Context.AddRange(Supplier1, Supplier2, Supplier3, Supplier4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }


        //Insert Values in SupplierProduct Table
        public static void AddSupplierProduct()
        {
            var SupplierProduct1 = new SupplierProduct { SupplierId = 1, Id = 1 };
            var SupplierProduct2 = new SupplierProduct { SupplierId = 2, Id = 2 };
            var SupplierProduct3 = new SupplierProduct { SupplierId = 3, Id = 3 };
            var SupplierProduct4 = new SupplierProduct { SupplierId = 4, Id = 4 };
            Context.AddRange(SupplierProduct1, SupplierProduct2, SupplierProduct3, SupplierProduct4);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        
    }
}
