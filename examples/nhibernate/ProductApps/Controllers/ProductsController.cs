using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ProductApps.Models;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using ProductApps.App_Start.configurations;

namespace ProductApps.Controllers
{
    public class ProductsController : ApiController
    {


        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();
            var container = new WindsorContainer();

            container.Register(
              Component
              .For(typeof(App_Start.configurations.IDbConnection))
              .ImplementedBy(typeof(App_Start.configurations.DBConnection))            
          );

            IDbConnection dbConnection = (DBConnection) container.Resolve(typeof(IDbConnection));
            using (var session = dbConnection.CreateSessionFactory().OpenSession())
            {   
                products = session.QueryOver<Product>()
                    .Where(p=>p.Name=="Xing")
                    .List<Product>();
            }     
            return products;       
        }


        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault<Product>(x => x.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}




    }
}
