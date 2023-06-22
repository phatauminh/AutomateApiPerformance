using Hub.API.Assertions;
using Hub.API.Extensions;
using Hub.API.Services;
using Hub.API.Settings;
using Hub.Core.Data;
using Hub.Core.Infrastructure.IOC;
using Hub.Core.Plugins;
using Hub.Core.Settings;
using Hub.Core.Utilities;
using System;

namespace Hub.API
{
    public class App
    {
        public bool ShouldReuseRestClient { get; set; } = true;
        public bool ShouldReuseDatabaseClient { get; set; } = true;

        public LoadTestService LoadTestService => new LoadTestService();

        public void AddApiClientExecutionPlugin<TExecutionExtension>()
            where TExecutionExtension : ApiClientExecutionPlugin
        {
            ServicesCollection.Current.RegisterType<ApiClientExecutionPlugin, TExecutionExtension>(Guid.NewGuid().ToString());
        }

        public void AddPlugin<TExecutionExtension>()
            where TExecutionExtension : Plugin
        {
            ServicesCollection.Current.RegisterType<Plugin, TExecutionExtension>(Guid.NewGuid().ToString());
        }

        public void AddAssertionsEventHandler<TComponentsEventHandler>()
            where TComponentsEventHandler : AssertExtensionsEventHandlers
        {
            var elementEventHandler = (TComponentsEventHandler)Activator.CreateInstance(typeof(TComponentsEventHandler));
            elementEventHandler.SubscribeToAll();
        }

        public void RemoveAssertionsEventHandler<TComponentsEventHandler>()
            where TComponentsEventHandler : AssertExtensionsEventHandlers
        {
            var elementEventHandler = (TComponentsEventHandler)Activator.CreateInstance(typeof(TComponentsEventHandler));
            elementEventHandler.UnsubscribeToAll();
        }

        public ApiClientService GetApiClientService(string url = null, bool sharedCookies = true, int? maxRetryAttempts = null, int? pauseBetweenFailures = null, TimeUnit timeUnit = TimeUnit.Seconds)
        {
            if (!ShouldReuseRestClient)
            {
                ServicesCollection.Current.UnregisterSingleInstance<ApiClientService>();
            }

            bool isClientRegistered = ServicesCollection.Current.IsRegistered<ApiClientService>();
            var client = ServicesCollection.Current.Resolve<ApiClientService>();

            if (!isClientRegistered || client == null)
            {
                client = new ApiClientService();
                if (string.IsNullOrEmpty(url))
                {
                    var apiSettingsConfig = ConfigurationService.GetSection<ApiSettings>();
                    if (apiSettingsConfig == null)
                    {
                        throw new SettingsNotFoundException("apiSettings");
                    }

                    client.WrappedClient.BaseUrl = new Uri(apiSettingsConfig.BaseUrl);
                }
                else
                {
                    client.WrappedClient.BaseUrl = new Uri(url);
                }

                if (sharedCookies)
                {
                    client.WrappedClient.CookieContainer = new System.Net.CookieContainer();
                }

                if (maxRetryAttempts.HasValue)
                    client.MaxRetryAttempts = maxRetryAttempts.Value;

                if (pauseBetweenFailures.HasValue)
                    client.PauseBetweenFailures = TimeSpanConverter.Convert(pauseBetweenFailures.Value, timeUnit);

                ServicesCollection.Current.RegisterInstance(client);
            }

            return client;
        }
    }
}
