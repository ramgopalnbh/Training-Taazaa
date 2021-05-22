using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class ProductCategory
    {
        public long CategoryId { get; set;}
        public long Id { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
