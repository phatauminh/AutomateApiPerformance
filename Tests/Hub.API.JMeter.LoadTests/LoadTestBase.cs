using Hub.API.Enums;
using Hub.API.JMeter.LoadTests.Mappers;
using Hub.API.JMeter.LoadTests.Models;
using Hub.API.Settings;
using Hub.Core.Settings;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Report.Common;
using Report.Common.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.JMeter.LoadTests
{
    public abstract class LoadTestBase
    {
        protected ResponseResultToLoadTestReportMapper _responseResultToLoadTestReport;
        private string _csvResultDirectory;
        private string _htmlReportDirectory;

        private LoadTestSettings _loadTestSettings;

        private string WorkingDirectory = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "LoadTestRegression\\Jmeter\\apache-jmeter-5.4.3\\bin")}";
        private  IApplicationDbContext _context;
        private  IServiceCollection _services = new ServiceCollection();

        public LoadTestBase()
        {
            InitializeInstance();
        }

        [SetUp]
        public void SetUp()
        {
            var scenarioDirectory = Path.Combine(GetScenarioDirectory(TestContext.CurrentContext.Test.Name));
            _csvResultDirectory = Path.Combine(scenarioDirectory, "csv_result.csv");
            _htmlReportDirectory = Path.Combine(scenarioDirectory, $"htmp_report");
        }

        public ConsoleOutput ExecuteTestPlan(string testPlan)
        {
            try
            {
                var command = @$"jmeter -n -t ""{testPlan}"" -l ""{_csvResultDirectory}"" -e -o ""{_htmlReportDirectory}""";

                var procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.WorkingDirectory = WorkingDirectory;

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                using (var process = new Process())
                {
                    process.StartInfo = procStartInfo;

                    process.Start();

                    var outputString = process.StandardOutput.ReadToEnd();

                    process.WaitForExit();

                    var result = new ConsoleOutput
                    {
                        ExitCode = process.ExitCode,
                        OutputString = outputString
                    };

                    process.Close();
                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected string GetTestPlanDirectory(ApiCategory testPlanFolder) => $"{Directory.GetCurrentDirectory()}\\TestsPlan\\{testPlanFolder}";
        protected string GetScenarioDirectory(string scenario)
        {
            var ticks = DateTime.Now.Ticks;

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), _loadTestSettings.Directory);

            var directory = $"{path}\\{scenario}\\{ticks}";

            if (!File.Exists(directory))
                Directory.CreateDirectory(directory);

            return directory;
        }

        protected LoadTestEnvironment GetEnvironment()
        {
            return new LoadTestEnvironment
            {
                Environment = ConfigurationService.Environment,
                Version = _loadTestSettings.Version,
                Scenario = TestContext.CurrentContext.Test.Name,
                Category = GetApiCategory()
            };
        }

        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                await StoreToDatabase();
            }
        }

        private async Task StoreToDatabase()
        {
            var environment = GetEnvironment();
            var listGroupResponseResult = (File.ReadAllLines($"{_csvResultDirectory}")
                                  .Skip(1)
                                  .Select(v => ResponseResult.FromCsv(v))
                                  .ToList()).GroupBy(x => x.Label);

            foreach (var groupResponseResult in listGroupResponseResult)
            {
                var report = _responseResultToLoadTestReport.Map(groupResponseResult, environment);
                _context.SummaryReports.Add(report);
                await _context.SaveChangesAsync();
            }
        }

        private void InitializeInstance()
        {
            _loadTestSettings = ConfigurationService.GetSection<LoadTestSettings>();
            _responseResultToLoadTestReport = new ResponseResultToLoadTestReportMapper();
            _services.AddInfrastructure(ConfigurationService.MainRoot);
            _context = _services.BuildServiceProvider().GetService<IApplicationDbContext>();
        }

        protected virtual ApiCategory GetApiCategory() => ApiCategory.NotSet;
    }
}
