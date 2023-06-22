using Hub.API.Contracts;

namespace Hub.API.Assertions
{
    public class ApiAssertEventArgs
    {
        public ApiAssertEventArgs(IMeasuredResponse measuredResponse) => MeasuredResponse = measuredResponse;

        public ApiAssertEventArgs(IMeasuredResponse measuredResponse, string actionValue)
            : this(measuredResponse) => ActionValue = actionValue;

        public IMeasuredResponse MeasuredResponse { get; }
        public string ActionValue { get; }
    }
}
