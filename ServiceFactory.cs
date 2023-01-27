using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public class ServiceFactory
    {
        public static IService GetService(ServiceHealth serviceHealth) {
            return Service.GetInstance(serviceHealth);
        }
    }

}
