using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Vm
{
    public class ItemsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
