using Hub.API.Enums;
using Report.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.WebUI.Interfaces
{
    public interface ISummaryReportProvider
    {
        Task<List<SummaryReport>> GetSummaryReports(string scenario, ApiCategory apiCategory);
        Task<List<string>> GetVersions();
    }
}
