using System.Collections.Generic;
using System.Linq;

namespace Report.Common.Helpers
{
    public static class EnumrableHelper
    {
        public static IEnumerable<T> GetTopReports<T>(this ICollection<T> reports, int numberOf)
        {
            if (reports.Count > numberOf)
                return reports.Skip(reports.Count - numberOf);

            return reports;
        }
    }
}
