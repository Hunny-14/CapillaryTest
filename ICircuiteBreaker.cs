using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public interface ICircuiteBreaker
    {
        public State State { get; }
    }

    public enum State
    {
        Closed = 0,
        Open = 1,
        PartiallyOpen = 2
    }
}
