using RestSharp;

namespace Hub.API.Events
{
    public class ClientEventArgs
    {
        public ClientEventArgs(IRestClient client) => Client = client;

        public IRestClient Client { get; }
    }
}
