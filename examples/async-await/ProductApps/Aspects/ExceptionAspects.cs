using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApps.Aspects
{
    public class ExceptionAspect : IInterceptor
    {
        public bool EatAll { get; set; }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} caught: {1}", e.GetType(), e.Message);
                if (!EatAll)
                {
                    throw;
                }
            }
        }
    }
}