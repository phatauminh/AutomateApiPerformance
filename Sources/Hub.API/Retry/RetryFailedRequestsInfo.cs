﻿using Hub.Core.Data;

namespace Hub.API.Retry
{
    public class RetryFailedRequestsInfo
    {
        public int MaxRetryAttempts { get; set; }
        public int PauseBetweenFailures { get; set; }
        public TimeUnit TimeUnit { get; set; }
    }
}
