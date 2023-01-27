using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    //Singleton class for distributed system
    public class Service : IService
    {
        static Service instance;
        static object lockVariable =0;
        public ServiceHealth ServiceHealth { get; set; }

        Service(ServiceHealth serviceHealth) {     // Accepting ServiceHealth just for simplicity, in reality serviceHealth will be set by external factors (e.g by Service management system or manually by user).
            ServiceHealth = serviceHealth; 
        }

        public static Service GetInstance(ServiceHealth serviceHealth) {   //Singleton design for distributed system

            if (instance == null) {

                lock (lockVariable) {
                    if(instance == null) {
                        instance = new Service(serviceHealth);
                    }
                }

            }

            return instance;
        }
    }
}
