using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    /// <summary>
    /// All requests that come on even minutes will only be processed
    /// </summary>
    class EvenMinuteStrategy : IPartiallyOpenStrategy
    {
        public bool CanProcess() {
            if(DateTime.Now.Minute % 2 == 0) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
