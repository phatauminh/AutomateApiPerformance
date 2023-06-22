using Hub.API.Enums;

namespace Hub.API.JMeter.LoadTests.Models
{
    public class LoadTestEnvironment
    {
        public string Scenario { get; set; }
        public string Environment { get; set; }
        public string Version { get; set; }
        public ApiCategory Category { get; set; }
    }
}
