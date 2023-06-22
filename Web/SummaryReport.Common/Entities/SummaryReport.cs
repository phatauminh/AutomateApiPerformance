using System;

namespace Report.Common.Entities
{
    public class SummaryReport
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string LoadTestScenario { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public int Samples { get; set; }
        public int FailCases { get; set; }
        public string ErrorPercentage { get; set; }
        public double Average { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Median { get; set; }
        public double Percentile90th { get; set; }
        public double Percentile95th { get; set; }
        public double Percentile99th { get; set; }
        public double Throughput { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
