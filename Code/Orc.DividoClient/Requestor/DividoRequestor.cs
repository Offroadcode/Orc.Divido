using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using Orc.Divido.Models;
using Orc.Divido.Models.DividoResponses;

namespace Orc.Divido.Requestor
{
    public class DividoRequestor : IDividoRequestor
    {
        private string ApiKey { get; set; }
        private string BaseUrl { get; set; }
        private string ApiVersion { get; set; }
        private HttpClient HttpClient { get; set; }

        public DividoRequestor(string apiKey, string baseUrl, string apiVersion)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
            ApiVersion = apiVersion;

            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                Proxy = new FiddlerProxy()
            };

            

            HttpClient = new HttpClient(httpClientHandler);
            
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Orc.Divido .Net Client");

        }

        public T Get<T>(string endpoint, Dictionary<string, string> parameters) where T : _BaseDividoResponse, new()
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            var url = CreateUrlWithQuery(endpoint, parameters);

            var streamTask = HttpClient.GetStreamAsync(url).Result;

            var data = serializer.ReadObject(streamTask) as T;
            data.RequestUrl = url;
            ValidateResponse(data);

            return data;
        }

        public T Post<T>(string endpoint, Dictionary<string, string> parameters) where T : _BaseDividoResponse, new()
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            var url = CreateUrl(endpoint);

            parameters = AddMerchant(parameters);
            parameters = Calculators.PostDataCalculator.FinalizeKeys(parameters);
            
            var content = new FormUrlEncodedContent(parameters);
            
            
            var streamTask = HttpClient.PostAsync(url, content).Result.Content.ReadAsStreamAsync().Result;

            var data = serializer.ReadObject(streamTask) as T;
            data.RequestUrl = url;
            data.RequestData = content.ToString();
            ValidateResponse(data);

            return data;
        }

        private void ValidateResponse(_BaseDividoResponse data)
        {
            if (data.Status == "error")
            {
                throw new DividoApiException(data.ErrorMessage);
            }
        }

        private Dictionary<string, string> AddMerchant( Dictionary<string, string> parameters)
        {
            parameters = new Dictionary<string, string>(parameters);

            parameters.Add("merchant", ApiKey);
            
            return parameters;
        }
        private string CreateUrlWithQuery(string endpoint, Dictionary<string, string> parameters, bool injectMerchant=true)
        {
            parameters = new Dictionary<string, string>(parameters);
            
            if (injectMerchant)
            {
                parameters = AddMerchant(parameters);
            }
            var queryString = ToQueryString(parameters);
            return CreateUrl(endpoint)+queryString;
        }
        private string CreateUrl(string endpoint)
        {
            var path = string.Format("{0}/{1}/{2}", BaseUrl, ApiVersion, endpoint);

            return path;
        }

        private string ToQueryString(Dictionary<string, string> parameters)
        {
            List<string> entries = new List<string>();
            foreach(var key in parameters.Keys)
            {
                var value = parameters[key];
                if (value != null)
                {
                    entries.Add(string.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value)));
                }
            }
          
            return "?" + string.Join("&", entries);
        }
    }
    public class FiddlerProxy : IWebProxy
    {
        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://localhost:8888");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public ICredentials Credentials { get; set; }
    }
}
