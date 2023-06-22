using System;

namespace Hub.Core.Plugins.Time
{
    public class ExecutionTimeoutException : Exception
    {
        public ExecutionTimeoutException()
        {
        }

        public ExecutionTimeoutException(string message)
            : base(message)
        {
        }

        public ExecutionTimeoutException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
