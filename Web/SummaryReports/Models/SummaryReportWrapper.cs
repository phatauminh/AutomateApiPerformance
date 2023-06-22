using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Report.WebUI.Models
{

    [DataContract]
    public class SummaryReportWrapper
    {
        [DataMember(Name = "title")]
        public string Title { get; set;}

        [DataMember(Name = "summaryReportDataPoints")]
        public IEnumerable<SummaryReportDataPoint> SummaryReportDataPoints { get; set;}
    }
}
