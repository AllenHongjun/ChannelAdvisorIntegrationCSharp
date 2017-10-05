using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

using Aarvani.ChannelAdvisor.ValuesType;
using System.Threading.Tasks;
using Aarvani.ChannelAdvisor.Services;
using Aarvani.ChannelAdvisor.Entities;
using System.Net;

namespace Aarvani.ChannelAdvisor.ApiCall
{
    public sealed class ApiCallPost<T> : ApiCall
    {

        private readonly string _url;
        
        private ApiCallPost()
            :base(CallType.POST)
        {

        }

        public ApiCallPost(string url ) : 
            base(CallType.POST)
        {

            if (string.IsNullOrEmpty(url)){
                throw new ArgumentException("Parameter cannot be null", "url");
            }

            _url = url;
        }

        public async Task<T> Post(T t) {

            AuthToken token = await AuthTokenService.GetNewToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =  new Uri(ValuesType.ApiUrls.Mainurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + token.access_token);

                HttpResponseMessage result = new HttpResponseMessage();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                result = await client.PostAsJsonAsync(_url,t);

                if (result.IsSuccessStatusCode)
                {
                    string jsonResult = result.Content.ReadAsStringAsync().Result;
                    return  JsonConvert.DeserializeObject<T>(jsonResult);
                }
                else
                {
                    string msg = result.Content.ReadAsStringAsync().Result;
                    throw new Exception(msg);
                }
            }

        }


    }
}
