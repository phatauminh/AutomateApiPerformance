using Hub.Core.Utilities;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Hub.Core.Settings
{
    public sealed class ConfigurationService
    {
        private static IConfigurationRoot _subRoot;

        public static IConfigurationRoot MainRoot
        {
            get => new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        }

        public static string Environment
        {
            get => MainRoot.GetSection("Env").Value;
        }

        static ConfigurationService()
        {
            _subRoot = InitializeConfiguration();
        }

        public static TSection GetSection<TSection>()
          where TSection : class, new()
        {
            string sectionName = MakeFirstLetterToLower(typeof(TSection).Name);
            return _subRoot.GetSection(sectionName).Get<TSection>();
        }

        private static string MakeFirstLetterToLower(string text)
        {
            return char.ToLower(text[0]) + text.Substring(1);
        }

        private static IConfigurationRoot InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder();
            var executionDir = ExecutionDirectoryResolver.GetDriverExecutablePath();
            var filesInExecutionDir = Directory.GetFiles(executionDir);

            var settingsFile =
                    filesInExecutionDir.FirstOrDefault(x => x.Contains($"appSettings.{Environment}") && x.EndsWith(".json"));

            if (settingsFile != null)
            {
                builder.AddJsonFile(settingsFile, optional: true, reloadOnChange: true);
            }

            builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
