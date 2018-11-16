using System;
using System.Collections.Generic;
using System.Net;
#if FEATURE_TYPE_INFO
using System.Net.Http;
using System.Net.Http.Headers;
#else

#endif

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

#if FEATURE_TYPE_INFO
        private HttpClient HttpClient { get; set; }
#else
        private WebClient WebClient { get; set; }
#endif

        public DividoRequestor(string apiKey, string baseUrl, string apiVersion)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
            ApiVersion = apiVersion;
#if FEATURE_TYPE_INFO

            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Orc.Divido .Net Client");
#else
            WebClient = new WebClient();
#endif
        }

        public T Get<T>(string endpoint, Dictionary<string, string> parameters) where T : _BaseDividoResponse, new()
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var url = CreateUrlWithQuery(endpoint, parameters);
#if FEATURE_TYPE_INFO

            var streamTask = HttpClient.GetStreamAsync(url).Result;
#else
            var streamTask = WebClient.OpenRead(url);
#endif

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
#if FEATURE_TYPE_INFO
            var content = new FormUrlEncodedContent(parameters);
            var streamTask = HttpClient.PostAsync(url, content).Result.Content.ReadAsStreamAsync().Result;
#else
            var nvc = new System.Collections.Specialized.NameValueCollection();
            foreach (var kvp in parameters)
            {
                nvc.Add(kvp.Key.ToString(), kvp.Value.ToString());
            }
            var byteArray = WebClient.UploadValues(url, nvc);
            System.IO.Stream streamTask = new System.IO.MemoryStream(byteArray);
#endif



            var data = serializer.ReadObject(streamTask) as T;
            data.RequestUrl = url;
#if FEATURE_TYPE_INFO
            data.RequestData = content.ToString();
#endif
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

        private Dictionary<string, string> AddMerchant(Dictionary<string, string> parameters)
        {
            parameters = new Dictionary<string, string>(parameters);

            parameters.Add("merchant", ApiKey);

            return parameters;
        }

        private string CreateUrlWithQuery(string endpoint, Dictionary<string, string> parameters, bool injectMerchant = true)
        {
            parameters = new Dictionary<string, string>(parameters);

            if (injectMerchant)
            {
                parameters = AddMerchant(parameters);
            }

            var queryString = ToQueryString(parameters);
            return CreateUrl(endpoint) + queryString;
        }

        private string CreateUrl(string endpoint)
        {
            var path = string.Format("{0}/{1}/{2}", BaseUrl, ApiVersion, endpoint);

            return path;
        }

        private string ToQueryString(Dictionary<string, string> parameters)
        {
            List<string> entries = new List<string>();
            foreach (var key in parameters.Keys)
            {
                var value = parameters[key];
                if (value != null)
                {
                    entries.Add(string.Format("{0}={1}", UrlEncode(key), UrlEncode(value)));
                }
            }

            return "?" + string.Join("&", entries);
        }

        private string UrlEncode(string str)
        {
#if FEATURE_TYPE_INFO
            return WebUtility.UrlEncode(str);
#else
            return System.Net.WebUtility.HtmlEncode(str);
#endif
        }
    }
}
