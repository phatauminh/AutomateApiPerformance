using Hub.Core.Infrastructure.IOC;
using System;

namespace Hub.Core.Plugins.Time
{
    public static class ExecutionTimePluginConfiguration
    {
        public static void Add()
        {
            ServicesCollection.Current.RegisterType<Plugin, ExecutionTimeUnderPlugin>(Guid.NewGuid().ToString());
        }
    }
}
