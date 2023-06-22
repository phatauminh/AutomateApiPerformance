using Hub.API.Enums;
using Report.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.WebUI.Interfaces
{
    public interface ISummaryReportService
    {
        Task<SummaryReportWrapper> GetSummaryReportDataPoints(string scenario, int numberOf, ApiCategory apiCategory);
        Task<List<string>> GetVersions();
    }
}
