using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public  class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ShortCode { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
        }

    }
}
