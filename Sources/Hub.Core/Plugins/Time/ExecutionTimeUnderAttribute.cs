using Hub.Core.Data;
using Hub.Core.Utilities;
using System;

namespace Hub.Core.Plugins.Time
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ExecutionTimeUnderAttribute : Attribute
    {
        public ExecutionTimeUnderAttribute(int timeout = 1, TimeUnit timeUnit = TimeUnit.Seconds) =>
            Timeout = TimeSpanConverter.Convert(timeout, timeUnit);

        public TimeSpan Timeout { get; }
    }
}
