using Hub.Core.Data;
using System;

namespace Hub.Core.Utilities
{
    public static class TimeSpanConverter
    {
        public static TimeSpan Convert(int time, TimeUnit timeUnit)
        {
            TimeSpan result = default;

            switch (timeUnit)
            {
                case TimeUnit.Milliseconds:
                    result = TimeSpan.FromMilliseconds(time);
                    break;
                case TimeUnit.Seconds:
                    result = TimeSpan.FromSeconds(time);
                    break;
                case TimeUnit.Minutes:
                    result = TimeSpan.FromMinutes(time);
                    break;
            }

            return result;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
