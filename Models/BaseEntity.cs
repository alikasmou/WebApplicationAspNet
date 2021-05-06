using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ecommerce.Models
{
    public class BaseEntity<X>
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            IsDelete = false;
        }

        [Key]
        public X Id { set; get;  }
        public DateTime CreateDate { set; get; }
        public DateTime LastModify { get; set; }
        public bool IsDelete { get; set; }  

    }
}
