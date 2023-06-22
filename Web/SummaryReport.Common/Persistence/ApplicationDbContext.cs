using Microsoft.EntityFrameworkCore;
using Report.Common.Entities;
using Report.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Common.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Entities.SummaryReport> SummaryReports { get; set; }
        public DbSet<Category> Categories { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync(new CancellationToken());
        }

    }
}
