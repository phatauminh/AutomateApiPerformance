using Hub.API.Events;
using Hub.Core.Logging;
using RestSharp;
using System;
using System.Text;
using System.Text.Json;

namespace Hub.API.Extensions
{
    public class BddApiClientExecutionPlugin : ApiClientExecutionPlugin
    {
        protected override void OnRequestTimeout(object sender, ClientEventArgs client) => Logger.LogInformation($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}>>> Request was not executed in the specified timeout.");

        protected override void OnMakingRequest(object sender, RequestEventArgs requestEventArgs)
        {
            var sb = new StringBuilder();
            sb.Append($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}>>> Request {requestEventArgs.Request.Method} making against resource {requestEventArgs.RequestResource}");
            if (requestEventArgs.Request.Parameters != null && requestEventArgs.Request.Parameters.Count > 0)
            {
                sb.AppendLine(" with parameters: ");

                foreach (var param in requestEventArgs.Request.Parameters)
                {
                    if (param.Type == ParameterType.RequestBody && param.DataFormat == DataFormat.Json)
                        sb.Append($" - Request Source: {JsonSerializer.Serialize(param.Value)}");
                    else
                        sb.Append($"{param.Name}={param.Value}");
                }
            }

            Logger.LogInformation(sb.ToString().TrimEnd());
        }

        protected override void OnRequestMade(object sender, ResponseEventArgs responseEventArgs)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}>>> Response of request {responseEventArgs.Response.Request.Method} against resource {responseEventArgs.RequestUri}");
            stringBuilder.AppendLine($" - StatusCode: {responseEventArgs.Response.StatusCode}");
            stringBuilder.AppendLine($" - Content: {responseEventArgs.Response.Content}");
            stringBuilder.AppendLine($" - Execution Time: {responseEventArgs.Response.ExecutionTime}");

            Logger.LogInformation(stringBuilder.ToString());
        }

        protected override void OnRequestFailed(object sender, ResponseEventArgs responseEventArgs) => Logger.LogInformation($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}>>> Request Failed {responseEventArgs.Response.Request.Method} on URL {responseEventArgs.RequestUri} - {responseEventArgs.Response.StatusCode} {responseEventArgs.Response.ErrorMessage}");
    }
}
