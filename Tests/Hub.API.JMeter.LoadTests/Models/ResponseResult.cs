using System;

namespace Hub.API.JMeter.LoadTests.Models
{
    public class ResponseResult
    {
        public string Scenario { get; set; }
        public string Environment { get; set; }
        public long TimeStamp { get; set; }
        public double Elapsed { get; set; }
        public string Label { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ThreadName { get; set; }
        public string DataType { get; set; }
        public bool IsSuccess { get; set; }
        public string FailureMessage { get; set; }
        public int Bytes { get; set; }
        public int SentBytes { get; set; }
        public int GroupThreads { get; set; }
        public int AllThreads { get; set; }
        public string Url { get; set; }
        public double Latency { get; set; }
        public double IdleTIme { get; set; }
        public double Connect { get; set; }

        public static ResponseResult FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new ResponseResult
            {
                TimeStamp = Convert.ToInt64(values[0]),
                Elapsed = Convert.ToDouble(values[1]),
                Label = values[2],
                ResponseCode = values[3],
                ResponseMessage = values[4],
                ThreadName = values[5],
                DataType = values[6],
                IsSuccess = Convert.ToBoolean(values[7]),
                FailureMessage = values[8],
                Bytes = Convert.ToInt32(values[9]),
                SentBytes = Convert.ToInt32(values[10]),
                GroupThreads = Convert.ToInt32(values[11]),
                AllThreads = Convert.ToInt32(values[12]),
                Url = values[13],
                Latency = Convert.ToDouble(values[14]),
                IdleTIme = Convert.ToDouble(values[15]),
                Connect = Convert.ToDouble(values[16])
            };
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
