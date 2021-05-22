using DepartmentalStore.Data;
using DepartmentalStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepartmentalStoreEF
{
    public class DatabaseQueries
    {
        public static DepartmetalStoreContext context = new DepartmetalStoreContext();
        public static void StaffQueryUsingName()
        {
            var staffdata = context.staff.Where(x => x.FirstName == "Mohan").ToList();
            foreach (var sd in staffdata)
            {
                Console.WriteLine(sd.staffId + " " + sd.RoleId + " " + sd.AddressId + " " + sd.FirstName + " " + sd.LastName + " " + sd.Email);
            }
        }
        public static void StaffQueryUsingEmail()
        {
            var staffdata = context.staff.Where(x => x.Email == "sohan123@gmail.com").ToList();
            foreach (var sd in staffdata)
            {
                Console.WriteLine(sd.staffId + " " + sd.RoleId + " " + sd.AddressId + " " + sd.FirstName + " " + sd.LastName + " " + sd.Email);
            }
        }

        public static void StaffQueryUsingRole()
        {
            var staffdata = context.staff.Where(x => x.RoleId == 1).ToList();
            foreach (var sd in staffdata)
            {
                Console.WriteLine(sd.staffId + " " + sd.RoleId + " " + sd.AddressId + " " + sd.FirstName + " " + sd.LastName + " " + sd.Email);
            }
        }
        public static void ProductQueryUsingName()
        {
            var products = context.Product.Where(x => x.Name == "Jeans").ToList();
            foreach (var product in products)
            {
                Console.WriteLine(product.Id + " " + product.Name + " " + product.Manufacturer + " " + product.ShortCode + " " + product.CostPrice + " " + product.SellingPrice);
            }
        }

        public static void ProductQueryBasedOnOutstock()
        {
            var pis = (from p in context.Product
                       join i in context.Inventory on p.Id equals i.ProductId
                       where i.Instock == false
                       select p).ToList();

            foreach (var product in pis)
            {
                Console.WriteLine(product.Id + " " + product.Name);
            }
        }

        public static void ProductQueryBasedOnSellingPrice()
        {
            Console.WriteLine("Greater Than");
            var data = context.Product.Where(x => x.SellingPrice > 1500).ToList();
            foreach (var product in data)
            {
                Console.WriteLine(product.Id + " " + product.Name + " " + product.Manufacturer + " " + product.ShortCode + " " + product.CostPrice + " " + product.SellingPrice);
            }
            Console.WriteLine("Less Than");
            var data1 = context.Product.Where(x => x.SellingPrice < 1500).ToList();
            foreach (var product in data1)
            {
                Console.WriteLine(product.Id + " " + product.Name + " " + product.Manufacturer + " " + product.ShortCode + " " + product.CostPrice + " " + product.SellingPrice);
            }

            Console.WriteLine("between");
            var data2 = context.Product.Where(x => x.SellingPrice > 1000 && x.SellingPrice < 20000).ToList();
            foreach (var product in data2)
            {
                Console.WriteLine(product.Id + " " + product.Name + " " + product.Manufacturer + " " + product.ShortCode + " " + product.CostPrice + " " + product.SellingPrice);
            }
        }



        public static void NumberOfProductOutOfStock()
        {
            var pis = (from p in context.Product
                       join i in context.Inventory on p.Id equals i.ProductId
                       where i.Instock == false
                       select p).Count();
            Console.WriteLine("Number of product Out of stock: " + pis);

        }

        public static void QueryProduct()
        {
            //var productbycategory = from p in context.Product
            //                        join pc in context.Productcategory on p.ProductId equals pc.ProductId
            //                        join cat in context.Category on pc.CategoryId equals cat.CategoryId
            //                        select new { p.ProductName, cat.CategoryName };


            //foreach (var val in productbycategory)
            //{
            //    Console.WriteLine("Product Name: {0} \t Category Name: {1}", val.ProductName, val.CategoryName);
            //}
            Console.WriteLine("Query2 : Query on Staff - using Department");
            var res = context.Product.Join(context.Category,
                             e1 => e1.Id,
                             e3 => e3.CategoryId,
                             (e1, e3) => new {
                                 name = e1.Name,
                                 cat = e3.CategoryName
                             });
            Console.WriteLine("Name" + "\t\t" + "DepartmentName \n");
            foreach (var i in res)
            {
                Console.WriteLine($"{i.name} \t\t {i.cat}");
            }
        }
        public static void ListOfSuppliers()
        {
            Console.WriteLine("By Name");
            var suppliers = context.Supplier.Where(x => x.SupplierName == "Max");
            foreach (var supplier in suppliers)
            {
                Console.WriteLine(supplier.SupplierId + " " + supplier.SupplierName);
            }

            Console.WriteLine("Email Address");
            var suppliers2 = context.Supplier.Where(x => x.Email == "maxin123@gmail.com");
            foreach (var supplier in suppliers2)
            {
                Console.WriteLine(supplier.SupplierId + " " + supplier.SupplierName);
            }
            Console.WriteLine("City");
            var suppliers3 = context.Supplier.Where(x => x.City == "California");
            foreach (var supplier in suppliers3)
            {
                Console.WriteLine(supplier.SupplierId + " " + supplier.SupplierName);
            }

        }

        //public static void QueryProductUsingCategory()
        //{
        //    var pcs = from s in context.Product
        //              join c in context.Category on s.ProductId equals c.CategoryId
        //              where c.CategoryName == "Electronics"
        //              select s;

        //    foreach (var pc in pcs)
        //    {
        //        Console.WriteLine(pc.ProductId);
        //    }
        //}

        public static void NumberofProductswithinacategory()
        {
            var result = (from p in context.Category
                          join c in context.productCategory
                          on p.CategoryId equals c.CategoryId
                          group p by c.CategoryId into x
                          select new
                          {
                              Count = x.Count<Category>(),
                              Category_Id = x.Key
                          }).ToList();
            foreach (var i in result)
            {
                Console.WriteLine("Category_ID : " + i.Category_Id + " " + "Count: " + i.Count);

            }
        }
    }
}
