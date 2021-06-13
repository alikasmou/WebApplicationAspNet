using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ecommerce.Models
{
    public class Categories: BaseEntity<int>
    {

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        // ? => nullable
        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public Categories? Parent { get; set; }

        // Add Image Column to Migration
        public string CategoryImage { get; set; }

    }
}
