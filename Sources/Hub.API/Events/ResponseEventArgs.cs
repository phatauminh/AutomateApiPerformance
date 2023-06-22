using Hub.API.Contracts;

namespace Hub.API.Events
{
    public class ResponseEventArgs
    {
        public ResponseEventArgs(IMeasuredResponse response, string requestUri)
        {
            Response = response;
            RequestUri = requestUri;
        }

        public IMeasuredResponse Response { get; }
        public string RequestUri { get; }
    }
}
