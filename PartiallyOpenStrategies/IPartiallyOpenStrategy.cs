using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public interface IPartiallyOpenStrategy
    {
        public bool CanProcess();
    }
}
