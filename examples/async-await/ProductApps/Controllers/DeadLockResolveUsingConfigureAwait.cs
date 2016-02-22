using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using ProductApps.Models;

namespace ProductApps.Controllers
{
    public class DeadLockResolveUsingConfigureAwaitController : ApiController
    {
        //demonastrating: deadlock prevention using Async all the way.

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = DelayAsync().Result;
            products.Add(new Product {Name = "prod2"});
            return products;
        }
        


        private async Task<IList<Product>> DelayAsync()
        {
            var prods = new List<Product>();
            await Task.Delay(2000).ConfigureAwait(false); //saying use any available background thread to complete remainig of this method after this task completes
            prods.Add(new Product {Name = "prod1"});
            return prods;
        }
    }
}
