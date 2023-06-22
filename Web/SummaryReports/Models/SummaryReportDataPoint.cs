using System.Runtime.Serialization;

namespace Report.WebUI.Models
{
    [DataContract]
    public class SummaryReportDataPoint
    {
        public SummaryReportDataPoint(string version, int samples, int failCases, double average, double percentile90th, double percentile95th, double percentile99th, double throughPut)
        {
            Version = version;
            Samples = samples;
            FailCases = failCases;
            Average = average;
            Percentile90th = percentile90th;
            Percentile95th = percentile95th;
            Percentile99th = percentile99th;
            Throughput = throughPut;
        }

        [DataMember(Name = "version")]
        public string Version;

        [DataMember(Name = "samples")]
        public int? Samples = null;

        [DataMember(Name = "failCases")]
        public int? FailCases = null;

        [DataMember(Name = "average")]
        public double? Average = null;

        [DataMember(Name = "percentile90th")]
        public double? Percentile90th = null;

        [DataMember(Name = "percentile95th")]
        public double? Percentile95th = null;

        [DataMember(Name = "percentile99th")]
        public double? Percentile99th = null;

        [DataMember(Name = "throughput")]
        public double? Throughput = null;
    }
}
