using RestSharp;

namespace Hub.API.Events
{
    public class RequestEventArgs
    {
        public RequestEventArgs(IRestRequest request, string requestUri)
        {
            Request = request;
            RequestResource = requestUri;
        }

        public IRestRequest Request { get; }
        public string RequestResource { get; }
    }
}
