using FluentNHibernate.Mapping;
using ProductApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProductApps.mappings
{
    public class ProductMap : ClassMap<Product>
    {

        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Category);
            Map(x => x.Price);
            Table("Products");

        }


    }

}