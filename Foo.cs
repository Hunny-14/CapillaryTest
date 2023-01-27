using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public class Foo : ICircuiteBreaker
    {
        public State State
        {
            get {

                switch (Service.ServiceHealth) {
                    case ServiceHealth.Healthy:
                        return State.Open;
                    case ServiceHealth.UnHealthy:
                        return State.Closed;
                    case ServiceHealth.Trasitioning:
                        return State.PartiallyOpen;
                    default:
                        return State.Closed;
                }
                
            }
        }

        public IService Service;
        public IPartiallyOpenStrategy PartiallyOpenStrategy;

        public Foo(IPartiallyOpenStrategy partiallyOpenStrategy , ServiceHealth serviceHealth) {
            Service = ServiceFactory.GetService(serviceHealth);   // Accepting ServiceHealth just for simplicity, in reality serviceHealth will be set by external factors (e.g by Service management system or manually by user).
            PartiallyOpenStrategy = partiallyOpenStrategy;
        }

        public bool ProcessRequest() {
            if(State == State.Closed) {
                return false;
            }
            else if(State == State.Open) {
                Service.ProcessRequest();
                return true;
            }
            else {
                if (PartiallyOpenStrategy.CanProcess()) {
                    Service.ProcessRequest();
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        public void ChangeServiceHealth(ServiceHealth serviceHealth) {
            Service.ServiceHealth = serviceHealth;
        }
    }
}
