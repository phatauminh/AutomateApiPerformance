namespace Report.WebUI.Models
{
    public static class SharedSettings
    {
        public const string ByVersion = "ByVersion";
        public const string ByTimeline = "ByTimelines";
        public static string Setting { get; set; }
        public static string Version { get; set; }

        public static bool IsPresent => Version != null && Setting == ByVersion || Setting == ByTimeline;
    }
}
