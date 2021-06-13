using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Items:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brands Brands { get; set; }

        // Leave enum for performance and feed back
        // public Color Color {get; set;}

    }
}
