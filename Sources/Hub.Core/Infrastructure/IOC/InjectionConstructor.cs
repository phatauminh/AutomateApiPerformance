namespace Hub.Core.Infrastructure.IOC
{
    public class InjectionConstructor
    {
        public InjectionConstructor(params object[] parameters) => Parameters = parameters;

        public object[] Parameters { get; set; }
    }
}
