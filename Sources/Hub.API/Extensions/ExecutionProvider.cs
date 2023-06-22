using Hub.API.Contracts;
using Hub.API.Events;
using RestSharp;
using System;

namespace Hub.API.Extensions
{
    public class ExecutionProvider : IExecutionProvider
    {
        public event EventHandler<ClientEventArgs> OnClientInitializedEvent;
        public event EventHandler<ClientEventArgs> OnRequestTimeoutEvent;
        public event EventHandler<RequestEventArgs> OnMakingRequestEvent;
        public event EventHandler<ResponseEventArgs> OnRequestMadeEvent;
        public event EventHandler<ResponseEventArgs> OnRequestFailedEvent;

        public void OnClientInitialized(IRestClient client) => OnClientInitializedEvent?.Invoke(this, new ClientEventArgs(client));
        public void OnRequestTimeout(IRestClient client) => OnRequestTimeoutEvent?.Invoke(this, new ClientEventArgs(client));
        public void OnMakingRequest(IRestRequest request, string requestUri) => OnMakingRequestEvent?.Invoke(this, new RequestEventArgs(request, requestUri));
        public void OnRequestMade(IMeasuredResponse response, string requestUri) => OnRequestMadeEvent?.Invoke(this, new ResponseEventArgs(response, requestUri));
        public void OnRequestFailed(IMeasuredResponse response, string requestUri) => OnRequestFailedEvent?.Invoke(this, new ResponseEventArgs(response, requestUri));
    }
}
