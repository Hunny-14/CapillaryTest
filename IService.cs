using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public interface IService
    {
        public ServiceHealth ServiceHealth { get; set; }
        
        public void ProcessRequest() {
            //Implement serivce request logic here
        }
    }

    public enum ServiceHealth
    {
        UnHealthy =0,
        Trasitioning = 1,
        Healthy = 2
    }
}
