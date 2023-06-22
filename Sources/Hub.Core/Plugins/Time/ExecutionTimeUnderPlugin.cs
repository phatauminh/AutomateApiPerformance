using System;
using System.Collections.Generic;
using System.Reflection;

namespace Hub.Core.Plugins.Time
{
    public class ExecutionTimeUnderPlugin : Plugin
    {
        private static readonly Dictionary<string, DateTime> _testsExecutionTimes = new Dictionary<string, DateTime>();

        protected override void PostTestInit(object sender, PluginEventArgs e)
        {
            TimeSpan executionTimeout = GetExecutionTimeout(e.TestMethodMemberInfo);
            string testFullName = GetTestFullName(e);
            if (executionTimeout != TimeSpan.MaxValue)
            {
                DateTime startTime = DateTime.Now;
                if (!_testsExecutionTimes.ContainsKey(testFullName))
                {
                    _testsExecutionTimes.Add(testFullName, startTime);
                }
                else
                {
                    _testsExecutionTimes[testFullName] = startTime;
                }
            }
        }

        protected override void PostTestCleanup(object sender, PluginEventArgs e)
        {
            TimeSpan executionTimeout = GetExecutionTimeout(e.TestMethodMemberInfo);
            string testFullName = GetTestFullName(e);
            if (executionTimeout != TimeSpan.MaxValue)
            {
                DateTime endTime = DateTime.Now;
                if (_testsExecutionTimes.ContainsKey(testFullName))
                {
                    var startTime = _testsExecutionTimes[testFullName];
                    var totalExecutionTime = endTime - startTime;
                    _testsExecutionTimes.Remove(testFullName);
                    if (totalExecutionTime > executionTimeout)
                    {
                        throw new ExecutionTimeoutException($"The test {testFullName} was executed for {totalExecutionTime}. The specified limit was {executionTimeout}.");
                    }
                }
            }
        }

        private string GetTestFullName(PluginEventArgs e) => $"{e.TestMethodMemberInfo.DeclaringType.FullName}.{e.TestMethodMemberInfo.Name}";

        private TimeSpan GetExecutionTimeout(MemberInfo memberInfo)
        {
            TimeSpan methodTimeout = GetTimeoutByMethodInfo(memberInfo);
            TimeSpan classTimeout = GetTimeoutInfoByType(memberInfo.DeclaringType);

            if (methodTimeout != TimeSpan.MaxValue)
            {
                return methodTimeout;
            }

            if (classTimeout != TimeSpan.MaxValue)
            {
                return classTimeout;
            }

            return TimeSpan.MaxValue;
        }

        private TimeSpan GetTimeoutInfoByType(Type currentType)
        {
            if (currentType == null)
            {
                throw new ArgumentNullException();
            }

            var executionTimeUnderAttribute = currentType.GetCustomAttribute<ExecutionTimeUnderAttribute>(true);
            if (executionTimeUnderAttribute != null)
            {
                return executionTimeUnderAttribute.Timeout;
            }

            return TimeSpan.MaxValue;
        }

        private TimeSpan GetTimeoutByMethodInfo(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException();
            }

            var executionTimeUnderAttribute = memberInfo.GetCustomAttribute<ExecutionTimeUnderAttribute>(true);
            if (executionTimeUnderAttribute != null)
            {
                return executionTimeUnderAttribute.Timeout;
            }

            return TimeSpan.MaxValue;
        }
    }
}
