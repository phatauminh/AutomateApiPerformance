using Hub.API.Enums;
using Report.Common.Entities;
using Report.Common.Interfaces;
using Report.WebUI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.WebUI.Providers
{
    public class SummaryReportProvider : BaseProvider,ISummaryReportProvider
    {
        public SummaryReportProvider(IApplicationDbContext context) : base(context) { }

        public override async Task<List<SummaryReport>> GetSummaryReports(string scenario, ApiCategory apiCategory) => await base.GetSummaryReports(scenario, apiCategory);

        public override async Task<List<string>> GetVersions() => await base.GetVersions();

    }
}
