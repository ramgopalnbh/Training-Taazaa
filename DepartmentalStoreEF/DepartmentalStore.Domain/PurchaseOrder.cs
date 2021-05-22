using System;

namespace DepartmentalStore.Domain
{
    public class PurchaseOrder
    {
        
        public int OrderId { get; set; }
        public int  ProductId { get; set; }
        public int SupplierId { get; set; }
        public string OrderDate { get; set; }
        public int QuantityRequired { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
