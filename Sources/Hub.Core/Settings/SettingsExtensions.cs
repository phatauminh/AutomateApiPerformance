using Hub.Core.Utilities;
using System;

namespace Hub.Core.Settings
{
    public static class SettingsExtensions
    {
        public static string NormalizeAppPath(this string appPath)
        {
            if (string.IsNullOrEmpty(appPath))
            {
                return appPath;
            }
            else if (appPath.StartsWith("AssemblyFolder", StringComparison.Ordinal))
            {
                var executionFolder = ExecutionDirectoryResolver.GetDriverExecutablePath();
                appPath = appPath.Replace("AssemblyFolder", executionFolder);
            }
            else if (appPath.StartsWith("RootFolder", StringComparison.Ordinal))
            {
                var executionFolder = ExecutionDirectoryResolver.GetRootPath();
                appPath = appPath.Replace("RootFolder", executionFolder);
            }

            return appPath;
        }
    }
}
