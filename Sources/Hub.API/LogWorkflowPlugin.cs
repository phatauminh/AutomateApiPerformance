using Hub.Core.Logging;
using Hub.Core.Plugins;
using System;

namespace Hub.API
{
    public class LogWorkflowPlugin : Plugin
    {
        protected override void PreTestInit(object sender, PluginEventArgs e)
        {
            Logger.LogInformation($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}>>> Start Test {e.TestClassType.Name}.{e.TestMethodMemberInfo.Name}");
        }

        protected override void PreTestCleanup(object sender, PluginEventArgs e)
        {
            Logger.LogInformation($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}>>> End Test {e.TestClassType.Name}.{e.TestMethodMemberInfo.Name}");
        }
    }
}
