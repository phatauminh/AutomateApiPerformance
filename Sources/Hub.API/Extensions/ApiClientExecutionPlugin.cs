using Hub.API.Events;

namespace Hub.API.Extensions
{
    public class ApiClientExecutionPlugin
    {
        public void Subscribe(IExecutionProvider provider)
        {
            provider.OnClientInitializedEvent += OnClientInitialized;
            provider.OnRequestTimeoutEvent += OnRequestTimeout;
            provider.OnMakingRequestEvent += OnMakingRequest;
            provider.OnRequestMadeEvent += OnRequestMade;
            provider.OnRequestFailedEvent += OnRequestFailed;
        }

        public void Unsubscribe(IExecutionProvider provider)
        {
            provider.OnClientInitializedEvent -= OnClientInitialized;
            provider.OnRequestTimeoutEvent -= OnRequestTimeout;
            provider.OnMakingRequestEvent -= OnMakingRequest;
            provider.OnRequestMadeEvent -= OnRequestMade;
            provider.OnRequestFailedEvent -= OnRequestFailed;
        }

        protected virtual void OnClientInitialized(object sender, ClientEventArgs client)
        {
        }

        protected virtual void OnRequestTimeout(object sender, ClientEventArgs client)
        {
        }

        protected virtual void OnMakingRequest(object sender, RequestEventArgs client)
        {
        }

        protected virtual void OnRequestMade(object sender, ResponseEventArgs client)
        {
        }

        protected virtual void OnRequestFailed(object sender, ResponseEventArgs client)
        {
        }
    }
}
