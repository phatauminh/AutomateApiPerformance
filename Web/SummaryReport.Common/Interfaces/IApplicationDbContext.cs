using Microsoft.EntityFrameworkCore;
using Report.Common.Entities;
using System.Threading.Tasks;

namespace Report.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SummaryReport> SummaryReports { get; set; }
        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync();
    }
}
