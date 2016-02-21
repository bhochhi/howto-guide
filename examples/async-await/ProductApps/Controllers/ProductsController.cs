using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using ProductApps.Models;

namespace ProductApps.Controllers
{
    public class ProductsController : ApiController
    {
        //demonastrating: How to make some block of code aynchronous. 
        //demonstrating: Each task runs on seperate thread from theard pool. 

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Debug.WriteLine("{0} is running on thread: {1}", "main", Thread.CurrentThread.ManagedThreadId);
            //a task will run and wait for this to complete before returning products
            Task.Run(async () =>
                {
                    Debug.WriteLine("{0} is running on thread: {1}", "First async", Thread.CurrentThread.ManagedThreadId);

                    await BuildProducts(products);
                    Debug.WriteLine("{0} is running on thread: {1}", "First async", Thread.CurrentThread.ManagedThreadId);


                }).GetAwaiter().GetResult();
            Debug.WriteLine("{0} is running on thread: {1}", "main", Thread.CurrentThread.ManagedThreadId);

            return products;
        }

        private async Task<List<Product>> BuildProducts(List<Product> products )
        {
           //Will this cause racecondition or thread safe?
            var task3 = Method1Asyc(1,"task3", products);
            var task2 = Method1Asyc(1109,"task2", products);
            var task1 = Method1Asyc(4,"task1", products);

            await Task.WhenAll(task1, task2, task3);
            return products;
        }

        public Task<List<Product>>  Method1Asyc(int delay,string name, List<Product> products)
        {
            return Task<List<Product>>.Factory.StartNew(() =>
            {
                Debug.WriteLine("{0} is running on thread: {1}",name,Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < delay; i++)
                {
                    products.Add(new Product { Name = name + " " + i });
                }
                return products;
            });
            
        }

    }
}
