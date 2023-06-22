using Hub.Core.Infrastructure;
using Hub.Core.Infrastructure.IOC;
using Hub.Core.Plugins.Time;

namespace Hub.API.Infrastructure.NUnit
{
    public abstract class APITest : NUnitBaseTest
    {
        private static readonly object _lockObject = new object();
        private static bool _arePluginsAlreadyInitialized;

        public App App => ServicesCollection.Current.FindCollection(TestContext.Test.ClassName).Resolve<App>();

        public override void Configure()
        {
            lock (_lockObject)
            {
                if (!_arePluginsAlreadyInitialized)
                {
                    NUnitPluginConfiguration.Add();
                    ExecutionTimePluginConfiguration.Add();
                    //DynamicTestCasesPlugin.Add();
                    //AllurePluginConfiguration.Add();
                    //ScreenshotsPluginConfiguration.AddNUnit();
                    //DatabasePluginConfiguration.Add();
                    //BugReportingPlugin.Add();

                    //APIPluginsConfiguration.AddAssertExtensionsBddLogging();
                    //APIPluginsConfiguration.AddApiAssertExtensionsDynamicTestCases();
                    //APIPluginsConfiguration.AddAssertExtensionsBugReporting();
                    //APIPluginsConfiguration.AddApiAuthenticationStrategies();
                    APIPluginsConfiguration.AddRetryFailedRequests();
                    APIPluginsConfiguration.AddLogExecution();
                    APIPluginsConfiguration.AddApiExtensionsBddLogging();

                    _arePluginsAlreadyInitialized = true;
                }
            }
        }
    }
}
