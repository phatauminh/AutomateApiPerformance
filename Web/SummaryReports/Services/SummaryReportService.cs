using Hub.API.Enums;
using Report.Common.Helpers;
using Report.WebUI.Interfaces;
using Report.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebUI.Services
{
    public class SummaryReportService : ISummaryReportService
    {
        private readonly ISummaryReportProvider _provider;
        public SummaryReportService(ISummaryReportProvider provider)
        {
            _provider = provider;
        }

        public async Task<SummaryReportWrapper> GetSummaryReportDataPoints(string scenario, int numberOf, ApiCategory apiCategory)
        {
            var reports = await _provider.GetSummaryReports(scenario, apiCategory);

            var datapoints = reports.GetTopReports(numberOf).Select(x => 
                    new SummaryReportDataPoint
                    (
                        x.Version,
                        x.Samples,
                        x.FailCases,
                        Math.Round(x.Average, 2),
                        x.Percentile90th,
                        x.Percentile95th,
                        x.Percentile99th,
                        x.Throughput
                     )
                    );

            return new SummaryReportWrapper {
                Title = apiCategory.ToString(),
                SummaryReportDataPoints = datapoints
            };
        }

        public async Task<List<string>> GetVersions()
        {
            return await _provider.GetVersions();
        }
    }
}
