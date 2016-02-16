using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApps.Models
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual decimal Price { get; set; }
    }
}