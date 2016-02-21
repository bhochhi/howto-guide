using System.Collections.Generic;
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
            List<Product> products = new List<Product>();
            Debug.WriteLine("{0} is running on thread: {1}", "main", Thread.CurrentThread.ManagedThreadId);

            Test();
            return products;
        }
        


        private static async Task DelayAsync()
        {
            Debug.WriteLine("{0} is running on thread: {1}", "inside DelayAsync", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000); //assume some async tasks
            Debug.WriteLine("{0} is running on thread: {1}", "inside DelayAsync after", Thread.CurrentThread.ManagedThreadId);
        }



        // This method causes a deadlock when called in a GUI or ASP.NET context.
        public static void Test()
        {
            Debug.WriteLine("{0} is running on thread: {1}", "inside Test()", Thread.CurrentThread.ManagedThreadId);

            // Start the delay.
            var delayTask = DelayAsync();

            // Wait for the delay to complete.
            delayTask.Wait();
            Debug.WriteLine("{0} is running on thread: {1}", "inside after Test()", Thread.CurrentThread.ManagedThreadId);

        }

    }
}
