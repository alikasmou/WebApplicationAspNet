using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Vm
{
    public class CategoriesVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CategoryImage { get; set; }

        public string? ParentName { get; set; }


    }
}
