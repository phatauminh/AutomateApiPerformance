using Hub.Core.Infrastructure.IOC;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Hub.Core.Plugins
{
    public class PluginEventArgs : EventArgs
    {
        public PluginEventArgs()
        {
        }

        public PluginEventArgs(TestOutcome testOutcome,
            string testName,
            MemberInfo testMethodMemberInfo,
            Type testClassType,
            List<object> arguments,
            string consoleOutputMessage,
            string consoleOutputStackTrace,
            Exception exception,
            List<string> categories,
            List<string> authors,
            List<string> descriptions)
            : this(testOutcome,
                testClassType,
                arguments,
                consoleOutputMessage,
                consoleOutputStackTrace)
        {
            TestMethodMemberInfo = testMethodMemberInfo;
            TestName = testName;
            TestFullName = $"{TestClassName}.{TestName}";
            Exception = exception;
            Categories = categories;
            Authors = authors;
            Descriptions = descriptions;
        }

        public PluginEventArgs(
            TestOutcome testOutcome,
            Type testClassType,
            List<object> arguments,
            string consoleOutputMessage = null,
            string consoleOutputStackTrace = null)
        {
            TestOutcome = testOutcome;
            TestClassType = testClassType;
            Arguments = arguments;
            TestClassName = testClassType.FullName;
            ConsoleOutputMessage = consoleOutputMessage;
            ConsoleOutputStackTrace = consoleOutputStackTrace;
            Container = ServicesCollection.Current.FindCollection(testClassType.FullName);
        }

        public ServicesCollection Container { get; set; }

        public Exception Exception { get; }

        public MemberInfo TestMethodMemberInfo { get; }

        public Type TestClassType { get; }
        public List<object> Arguments { get; }

        public TestOutcome TestOutcome { get; }

        public string TestName { get; }

        public string TestClassName { get; }

        public string TestFullName { get; }

        public string ConsoleOutputMessage { get; }

        public string ConsoleOutputStackTrace { get; }

        public List<string> Categories { get; }

        public List<string> Authors { get; }

        public List<string> Descriptions { get; }
    }
}
