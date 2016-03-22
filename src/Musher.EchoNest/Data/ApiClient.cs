using Musher.EchoNest.Exceptions;
using Musher.EchoNest.Responses;
using RestSharp;

namespace Musher.EchoNest.Data
{
    /// <summary>
    /// Wrapper for the RestSharp client
    /// </summary>
    public class ApiClient
    {
        readonly string _apiUrl;
        readonly string _apiKey;

        public ApiClient(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
        }

        public T Execute<T>(RestRequest request) where T : BaseResponse, new()
        {
            var response = Request<T>(request);

            if (response.Status.Code != ResponseStatusCode.Success)
            {
                throw new EchoNestException(response.Status.Message);
            }

            return response;
        }

        public RestRequest CreateRequest(string endPoint, Method method = Method.GET)
        {
            return new RestRequest(endPoint, method)
            {
                RequestFormat = DataFormat.Json,
                RootElement = "response"
            };
        }

        private T Request<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(_apiUrl);
            client.DefaultParameters.Add(new Parameter
            {
                Type = ParameterType.QueryString,
                Name = "api_key",
                Value = _apiKey
            });
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw new EchoNestException(response.ErrorMessage, response.ErrorException);
            }

            return response.Data;
        }
    }
}
