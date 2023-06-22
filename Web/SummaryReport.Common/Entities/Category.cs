using System.Collections.Generic;

namespace Report.Common.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<SummaryReport> Reports { get; private set; } = new List<SummaryReport>();
    }
}
