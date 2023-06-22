namespace Hub.Core.Infrastructure.IOC
{
    public class OverrideParameter
    {
        public OverrideParameter(string parameterName, object parameterValue)
        {
            ParameterName = parameterName;
            ParameterValue = parameterValue;
        }

        public string ParameterName { get; set; }

        public object ParameterValue { get; set; }
    }
}
