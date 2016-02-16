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

             Task.Run(async () =>
                {
                     await BuildProducts(products);

                });

            return products;

//            var container = new WindsorContainer();
//
//            container.Register(
//              Component
//              .For(typeof(App_Start.configurations.IDbConnection))
//              .ImplementedBy(typeof(App_Start.configurations.DBConnection))            
//          );
//
//            IDbConnection dbConnection = (DBConnection) container.Resolve(typeof(IDbConnection));
//            using (var session = dbConnection.CreateSessionFactory().OpenSession())
//            {   
//                IList<Product> productList = session.QueryOver<Product>()
//                    .Where(p=>p.Name=="Xing")
//                    .List<Product>();
//                throw new Exception("Testing AOP");
//                //return productList.AsEnumerable<Product>();
//            }            
        }

        private async Task<IList<Product>> BuildProducts(IList<Product> products )
        {

            var task1 = new Task(() =>
            {
                products.Add(new Product {Name = "Task1 product1"});
                products.Add(new Product {Name = "Task1 product2"});
                products.Add(new Product {Name = "Task1 product3"});
                products.Add(new Product {Name = "Task1 product4"});
            });
           
            var task2 = new Task(() =>
            {
                products.Add(new Product { Name = "task2 product1" });
                products.Add(new Product { Name = "task2 product2" });
                products.Add(new Product { Name = "task2 product3" });
                products.Add(new Product { Name = "task2 product4" });
            });
         
            var task3 = new Task(() =>
            {
                products.Add(new Product { Name = "task3 product1" });
                products.Add(new Product { Name = "task3 product2" });
                products.Add(new Product { Name = "task3 product3" });
                products.Add(new Product { Name = "task3 product4" });

            });
            task3.Start();
            task1.Start();
               task2.Start();
            await Task.WhenAll(task1, task2, task3);
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
