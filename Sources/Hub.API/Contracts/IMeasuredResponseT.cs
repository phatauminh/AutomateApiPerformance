using RestSharp;

namespace Hub.API.Contracts
{
    public interface IMeasuredResponse<TReturnType> : IRestResponse<TReturnType>, IMeasuredResponse
         where TReturnType : new()
    {
    }
}
