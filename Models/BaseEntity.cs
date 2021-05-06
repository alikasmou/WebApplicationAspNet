using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ecommerce.Models
{
    public class BaseEntity<X>
    {
        public X Id { set; get;  }

        public DateTime CreateDate { set; get; }
        public DateTime LastModify { get; set; }
        public bool IsDelete { get; set; }  

    }
}
