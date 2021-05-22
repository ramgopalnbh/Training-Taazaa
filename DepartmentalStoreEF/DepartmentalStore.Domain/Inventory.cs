using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Inventory
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public bool Instock { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }

    }
}
