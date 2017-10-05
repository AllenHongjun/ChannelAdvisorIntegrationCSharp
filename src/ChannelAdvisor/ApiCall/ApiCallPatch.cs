
using Aarvani.ChannelAdvisor.Entities;
using Aarvani.ChannelAdvisor.Services;
using Aarvani.ChannelAdvisor.ValuesType;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Net;

namespace Aarvani.ChannelAdvisor.ApiCall
{
    public sealed class ApiCallPatch<T> : ApiCall
    {

        private readonly string _url;

        private ApiCallPatch(): 
          base(ValuesType.CallType.PATCH)
        { }

        public ApiCallPatch(string url) : 
            base(CallType.PATCH)
        {

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Parameter cannot be null", "url");
            }

            _url = url;
        }

        public async Task<bool> Update(T t, int id) {

            AuthToken token = await AuthTokenService.GetNewToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ValuesType.ApiUrls.Mainurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer  " + token.access_token);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpResponseMessage result = new HttpResponseMessage();

                result = await client.PatchAsync((_url + "(" + id.ToString() + ")"), t); 

                if (result.IsSuccessStatusCode)
                {
                    //string jsonResult = result.Content.ReadAsStringAsync().Result;
                    // return JsonConvert.DeserializeObject<T>(jsonResult);
                    return true;
                }
                else
                {  
                    string msg = result.Content.ReadAsStringAsync().Result;
                    throw new Exception(msg);
                }
            }

        }


    }

    public static class HttpClientExtensions
    {   

        public static async Task<HttpResponseMessage> PatchAsync<T>(this HttpClient client, string requestUri, T value)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                throw new Exception(e.StackTrace);
               // Debug.WriteLine("ERROR: " + e.ToString());
            }

            return response;
        }
    }
}
