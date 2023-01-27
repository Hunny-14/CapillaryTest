using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.PartiallyOpenStrategies
{
    /// <summary>
    /// Every Fifth request will be processed
    /// </summary>
    public class OneInFiveStrategy : IPartiallyOpenStrategy
    {
        int requestCounter;

        public OneInFiveStrategy() {
            requestCounter = 0;
        }

        public bool CanProcess() {
            requestCounter += 1;

            if(requestCounter % 5 != 0) {
                return false;
            }

            requestCounter %= 5;    //To keeo requestCount between 0 to 4;
            return true;
        }
    }
}
