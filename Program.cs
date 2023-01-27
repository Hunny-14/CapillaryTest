using System;
using System.Threading;

namespace CircuitBreaker
{
    class Program
    {
        static void Main(string[] args) {

            //Circuit Closed
            var foo = new Foo(new EvenMinuteStrategy(), ServiceHealth.UnHealthy);

            bool isRequestAccepted = foo.ProcessRequest();

            LogRequest(isRequestAccepted, foo);

            //Ciruit Open
            foo.ChangeServiceHealth(ServiceHealth.Healthy);
            isRequestAccepted = foo.ProcessRequest();

            LogRequest(isRequestAccepted, foo);


            //Circuit Partially Open
            foo.ChangeServiceHealth(ServiceHealth.Trasitioning);

            for(int i = 0; i < 5; ++i) {
                isRequestAccepted = foo.ProcessRequest();

                LogRequest(isRequestAccepted, foo);
                Thread.Sleep(60000);
            }
            
        }

        static void LogRequest(bool accepted, Foo foo) {
            if (accepted) {
                Console.WriteLine("Request accepted , service is " + foo.State.ToString());
            }
            else {
                Console.WriteLine("Request not accepted , service is " + foo.State.ToString());
            }
        }
    }
}
