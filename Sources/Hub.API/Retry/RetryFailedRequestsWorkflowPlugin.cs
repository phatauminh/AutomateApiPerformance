using Hub.API.Services;
using Hub.Core.Plugins;
using Hub.Core.Utilities;
using System;
using System.Reflection;

namespace Hub.API.Retry
{
    public class RetryFailedRequestsWorkflowPlugin : Plugin
    {
        protected override void PostTestInit(object sender, PluginEventArgs e)
        {
            RetryFailedRequestsInfo retryFailedRequestsInfo = GetRetryFailedRequestsInfo(e.TestMethodMemberInfo);

            if (retryFailedRequestsInfo != null)
            {
                var client = e.Container.Resolve<ApiClientService>();
                client.PauseBetweenFailures = TimeSpanConverter.Convert(retryFailedRequestsInfo.PauseBetweenFailures, retryFailedRequestsInfo.TimeUnit);
                client.MaxRetryAttempts = retryFailedRequestsInfo.MaxRetryAttempts;
            }
        }

        private RetryFailedRequestsInfo GetRetryFailedRequestsInfo(MemberInfo memberInfo)
        {
            RetryFailedRequestsInfo methodRetryFailedRequestsInfo = GetRetryFailedRequestsInfoByMethodInfo(memberInfo);
            RetryFailedRequestsInfo classRetryFailedRequestsInfo = GetRetryFailedRequestsInfoByType(memberInfo.DeclaringType);

            if (methodRetryFailedRequestsInfo != null)
            {
                return methodRetryFailedRequestsInfo;
            }
            else if (classRetryFailedRequestsInfo != null)
            {
                return classRetryFailedRequestsInfo;
            }

            return null;
        }

        private RetryFailedRequestsInfo GetRetryFailedRequestsInfoByType(Type currentType)
        {
            if (currentType == null)
            {
                throw new ArgumentNullException();
            }

            var retryFailedRequestsClassAttribute = currentType.GetCustomAttribute<RetryFailedRequestsAttribute>(true);
            return retryFailedRequestsClassAttribute?.RetryFailedRequestsInfo;
        }

        private RetryFailedRequestsInfo GetRetryFailedRequestsInfoByMethodInfo(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException();
            }

            var retryFailedRequestsMethodAttribute = memberInfo.GetCustomAttribute<RetryFailedRequestsAttribute>(true);
            return retryFailedRequestsMethodAttribute?.RetryFailedRequestsInfo;
        }
    }
}
