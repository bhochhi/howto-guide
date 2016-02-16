using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ProductApps.Models;

namespace ProductApps.Controllers
{
    public class ProductsController : ApiController
    {


        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            //a task will run and wait for this to complete before returning products
             Task.Run(async () =>
                {
                     await BuildProducts(products);

                }).GetAwaiter().GetResult();

            return products;
        }

        private async Task<List<Product>> BuildProducts(List<Product> products )
        {
           
            var task3 = Method1Asyc(1,"task3", products);
            var task2 = Method1Asyc(1109,"task2", products);
            var task1 = Method1Asyc(4,"task1", products);

            //            await Task.WhenAll(task1, task2, task3);
            await Task.WhenAny(task1, task2, task3); //unable to verify WhenAny is waiting only for the first one that complete. Everytime I see all tasks completed.

//           
//            products.AddRange(task3.Result);
//            products.AddRange(task2.Result);
//            products.AddRange(task1.Result);
            return products;
        }

        public Task<List<Product>>  Method1Asyc(int delay,string name, List<Product> products)
        {

//            await Task.Delay(delay);

            return Task<List<Product>>.Factory.StartNew(() =>
            {
//                List<Product> products = new List<Product>();
                for (int i = 0; i < delay; i++)
                {
                    products.Add(new Product { Name = name + " " + i });
                }
                return products;
            });

           
//            return products;
        }

    }
}
