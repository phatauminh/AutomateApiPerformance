using Hub.Core.Data;

namespace Hub.API.Settings
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; }
        public int ClientTimeoutSeconds { get; set; }
        public int MaxRetryAttempts { get; set; }
        public int PauseBetweenFailures { get; set; }
        public TimeUnit TimeUnit { get; set; }
    }
}
