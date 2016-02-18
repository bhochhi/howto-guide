using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsyncAwaitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSynchronously();
            RunASynchronously();
            Console.Read();
        }


       

        private static void RunSynchronously()
        {
            Console.WriteLine("Running Synchronously...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var ecommerce = new Ecommerce();
            int prodId = ecommerce.CreateProduct();
            int shipId = ecommerce.CreateShippingLabel();
            int priceId = ecommerce.CreateProductPrice();
            Console.WriteLine("The product id: {0}\nThe shipping id: {1}\nThe priceId: {2}", prodId, shipId, priceId);
            Console.WriteLine("Total time to complete: {0} ms",sw.ElapsedMilliseconds);
          
        }

        private static void RunASynchronously()
        {
            Console.WriteLine("Running ASynchronously...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var ecommerce = new Ecommerce();

            Task prodIdTask = Task<int>.Factory.StartNew(ecommerce.CreateProduct);
            Task shipIdTask = Task<int>.Factory.StartNew(ecommerce.CreateShippingLabel);
            Task priceIdTask = Task<int>.Factory.StartNew(ecommerce.CreateProductPrice);
            Task.WaitAll(prodIdTask, shipIdTask, priceIdTask);
            Console.WriteLine("The product id: {0}\nThe shipping id: {1}\nThe priceId: {2}", prodIdTask, shipIdTask, priceIdTask);
            Console.WriteLine("Total time to complete: {0} ms",sw.ElapsedMilliseconds);
         
        }
    }

   


    class Ecommerce
    {
        private static Random ran = new Random(1);
        public int CreateProduct()
        {
            Console.WriteLine("Creating Product... ");
            Thread.Sleep(1000);
            Console.WriteLine("Completing product");
            return ran.Next(100) ;

        }

        public int CreateShippingLabel()
        {
            Console.WriteLine("Creating ShippingLabel... ");
            Thread.Sleep(500);
            Console.WriteLine("Completing ShippingLabel");
            return ran.Next(100);
        }

        public int CreateProductPrice()
        {
            Console.WriteLine("Creating ProductPrice... ");
            Thread.Sleep(200);
            Console.WriteLine("Completing ProductPrice");
            return ran.Next(100);
        }
    }
}
