using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data.Migrations;

namespace ecommerce.Models
{
    // Brands: (inherients from Base Entity class and its id value type is <int>)
    public class Brands: BaseEntity<int>
    {

        public string BrnadName { get; set; }

        public string Description { get; set; }

        public string ImageId { get; set; }

    }
}
