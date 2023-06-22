using Hub.API.JMeter.LoadTests.Models;
using Hub.Core.Utilities;
using Report.Common.Entities;
using System;
using System.Linq;

namespace Hub.API.JMeter.LoadTests.Mappers
{
    public class ResponseResultToLoadTestReportMapper
    {
        public SummaryReport Map(IGrouping<string, ResponseResult> groupResponseResult, LoadTestEnvironment environment)
        {
            var label = groupResponseResult.Key;
            var samples = groupResponseResult.Count();
            var failCases = groupResponseResult.Where(x => x.IsSuccess == false).Count();
            var errorPercentage = $"{failCases / samples * 100}%";
            var avg = groupResponseResult.Select(x => x.Elapsed).Average();
            var min = groupResponseResult.Select(x => x.Elapsed).Min();
            var max = groupResponseResult.Select(x => x.Elapsed).Max();
            var median = GetMedian(groupResponseResult.Select(x => x.Elapsed).ToArray());

            var per90th = Percentile(groupResponseResult.Select(x => x.Elapsed).ToArray(), 0.90);
            var per95th = Percentile(groupResponseResult.Select(x => x.Elapsed).ToArray(), 0.95);
            var per99th = Percentile(groupResponseResult.Select(x => x.Elapsed).ToArray(), 0.99);

            var firstTimeStamp = groupResponseResult.Select(x => x.TimeStamp).First();
            var lastTimeStamp = groupResponseResult.Select(x => x.TimeStamp).Last();

            var startDate = TimeSpanConverter.UnixTimeStampToDateTime(Convert.ToDouble(firstTimeStamp.ToString().Substring(0, 10)));
            var endDate = TimeSpanConverter.UnixTimeStampToDateTime(Convert.ToDouble(lastTimeStamp.ToString().Substring(0, 10)));

            var throughPut = samples / (lastTimeStamp + groupResponseResult.Select(x => x.Elapsed).Last() - firstTimeStamp) * 1000;

            var duration = endDate - startDate;

            return new SummaryReport
            {
                LoadTestScenario = environment.Scenario,
                Environment = environment.Environment,
                Version = environment.Version,
                CategoryId = (int)environment.Category,
                Samples = samples,
                Average = avg,
                ErrorPercentage = errorPercentage,
                FailCases = failCases,
                Max = max,
                Median = median,
                Min = min,
                Percentile90th = per90th,
                Percentile95th = per95th,
                Percentile99th = per99th,
                Throughput = throughPut,
                Duration = duration,
                CreatedDateTime = DateTime.Now
            };
        }

        private double Percentile(double[] sequence, double excelPercentile)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            double n = (N + 1) * excelPercentile;
            if (n == 1d) return sequence[0];
            else if ((int)n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }

        private double GetMedian(double[] sourceNumbers)
        {
            if (sourceNumbers == null || sourceNumbers.Length == 0)
                throw new Exception("Median of empty array not defined.");

            double[] sortedPNumbers = (double[])sourceNumbers.Clone();
            Array.Sort(sortedPNumbers);

            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? sortedPNumbers[mid] : (sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2;
            return median;
        }
    }
}
