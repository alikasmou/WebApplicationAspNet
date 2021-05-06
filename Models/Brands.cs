using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    // Brands: (inherients from Base Entity class and its id value type is <int>)
    public class Brands: BaseEntity<int>
    {

        // Very Important to set the method to connect 
        // Model with database in DbContext
        // Dbset<Brands> Brands{get; set;}
        // Then make add migratoin CreateBrandsTable
        // and update database
        public string BrnadName { get; set; }

        public string Description { get; set; }

        public string ImageId { get; set; }

    }
}
