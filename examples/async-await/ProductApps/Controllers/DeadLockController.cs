﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using ProductApps.Models;

namespace ProductApps.Controllers
{
    public class DeadLockController : ApiController
    {
        //demonastrating: deadlock.

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var task = DelayAsync();
            return task.Result;
        }



        private async Task<IList<Product>> DelayAsync()
        {
            var prods = new List<Product>();
            await Task.Delay(2000); //creates new task and delays 2 sec.
            prods.Add(new Product { Name = "prod1" });
            return prods;
        }


        

    }
}
