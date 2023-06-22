using Hub.API.Enums;
using Hub.Core.Logging;
using NUnit.Framework;

namespace Hub.API.JMeter.LoadTests.Tests
{
    [TestFixture]
    public class FindPaymentPlanLoadTests : LoadTestBase
    {
        private readonly string scenario1 = "\\Scenario 1 - FindPaymentPlan - 5 users hit to server sec in duration of 10 mins.jmx";
        private readonly string scenario2 = "\\Scenario 2 - FindPaymentPlan - 100 users hit to server then ramp-up and ramp-down by 25 users.jmx";

        [Test]
        public void Find_Payment_Plan_5_Users_Hit_To_Server_In_Duration_Of_10_Mins()
        {
            var testPlan = $"{GetTestPlanDirectory(ApiCategory.FindPaymentPlan)}{scenario1}";

            var result = ExecuteTestPlan(testPlan);

            Logger.LogInformation($"Response: {result.OutputString}");

            Assert.AreEqual(0, result.ExitCode);
        }

        [Test]
        public void Find_Payment_Plan_100_Users_Hit_To_Server_Ramp_Up_Ramp_Down_To_25_Users()
        {
            var testPlan = $"{GetTestPlanDirectory(ApiCategory.FindPaymentPlan)}{scenario2}";

            var result = ExecuteTestPlan(testPlan);

            Logger.LogInformation($"Response: {result.OutputString}");

            Assert.AreEqual(0, result.ExitCode);
        }

        protected override ApiCategory GetApiCategory() => ApiCategory.FindPaymentPlan;
    }
}
