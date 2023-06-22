using Hub.Core.Assertions;
using Hub.Core.Infrastructure.IOC;

namespace Hub.Core.Infrastructure
{
    public class NUnitPluginConfiguration
    {
        public static void Add()
        {
            ServicesCollection.Current.RegisterType<IAssert, NUnitAssert>();
            ServicesCollection.Current.RegisterType<ICollectionAssert, NUnitCollectionAssert>();
        }
    }
}
