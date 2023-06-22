using Hub.API.Extensions;
using Hub.API.Retry;
using Hub.Core.Infrastructure.IOC;
using Hub.Core.Plugins;
using System;

namespace Hub.API
{
    public static class APIPluginsConfiguration
    {
        public static void AddApiExtensionsBddLogging()
        {
            ServicesCollection.Current.RegisterType<ApiClientExecutionPlugin, BddApiClientExecutionPlugin>(Guid.NewGuid().ToString());
        }

        //public static void AddAssertExtensionsBddLogging()
        //{
        //    var bddLoggingAssertExtensions = new BDDLoggingAssertExtensions();
        //    bddLoggingAssertExtensions.SubscribeToAll();
        //}

        //public static void AddApiAssertExtensionsDynamicTestCases()
        //{
        //    var dynamicTestCasesAssertExtensions = new DynamicTestCasesAssertExtensions();
        //    dynamicTestCasesAssertExtensions.SubscribeToAll();
        //}

        //public static void AddAssertExtensionsBugReporting()
        //{
        //    var dynamicTestCasesAssertExtensions = new BugReportingAssertExtensions();
        //    dynamicTestCasesAssertExtensions.SubscribeToAll();
        //}

        //public static void AddApiAuthenticationStrategies()
        //{
        //    ServicesCollection.Current.RegisterType<Plugin, ApiAuthenticationWorkflowPlugin>(Guid.NewGuid().ToString());
        //}

        public static void AddRetryFailedRequests()
        {
            ServicesCollection.Current.RegisterType<Plugin, RetryFailedRequestsWorkflowPlugin>(Guid.NewGuid().ToString());
        }

        public static void AddLogExecution()
        {
            ServicesCollection.Current.RegisterType<Plugin, LogWorkflowPlugin>(Guid.NewGuid().ToString());
        }
    }
}
