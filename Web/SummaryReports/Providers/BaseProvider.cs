using Hub.API.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Report.Common.Entities;
using Report.Common.Interfaces;
using Report.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebUI.Providers
{
    public abstract class BaseProvider
    {
        private readonly IApplicationDbContext _context;
        private static string Enviroment = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetSection("Env").Value;
        public BaseProvider(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<SummaryReport>> GetSummaryReports(string scenario, ApiCategory categoryId)
        {
            var itemsInCategory = await _context.Categories.Include(c => c.Reports).FirstOrDefaultAsync(c => c.Id == (int)categoryId);

            if (SharedSettings.Setting == SharedSettings.ByTimeline)
                return itemsInCategory.Reports.Where(x => x.LoadTestScenario == scenario && x.Environment == Enviroment).OrderBy(x => x.CreatedDateTime).ToList();
            else
                return itemsInCategory.Reports.Where(x => x.LoadTestScenario == scenario && x.Environment == Enviroment && x.Version == SharedSettings.Version).OrderBy(x => x.CreatedDateTime).ToList();
        }

        public virtual async Task<List<string>> GetVersions()
        {
            var myList = await _context.SummaryReports.Where(x => x.Environment == Enviroment).ToListAsync();
            var group = myList.GroupBy(d => d.Version).Select(group => group.First()).Select(x => x.Version);

            return group.ToList();
        }
    }
}
