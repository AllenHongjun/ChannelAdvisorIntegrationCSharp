using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

using Aarvani.ChannelAdvisor.ValuesType;
using System.Threading.Tasks;
using Aarvani.ChannelAdvisor.Services;
using Aarvani.ChannelAdvisor.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Aarvani.ChannelAdvisor.ApiCall
{
    public sealed class ApiCallGet<T> : ApiCall
    {

        private readonly string _url;

        private ApiCallGet(): 
          base(ValuesType.CallType.GET)
        {}

        public ApiCallGet(string url) : 
            base(CallType.GET)
        {

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Parameter cannot be null", "url");
            }

            _url = url;
        }

        public async Task<T> Get(int id)
        {

            AuthToken token = await AuthTokenService.GetNewToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ValuesType.ApiUrls.Mainurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpResponseMessage result = new HttpResponseMessage();

                result = await client.GetAsync(_url+"("+id.ToString()+")");

                if (result.IsSuccessStatusCode)
                {
                    string jsonResult = result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(jsonResult);
                } 
                else
                {
                    string msg = result.Content.ReadAsStringAsync().Result;
                    throw new Exception(msg);
                }
            }

        }

        public async Task<IEnumerable<T>> Get(string query) {

            AuthToken token = await AuthTokenService.GetNewToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ValuesType.ApiUrls.Mainurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);

                HttpResponseMessage result = new HttpResponseMessage();

                result = await client.GetAsync(_url + query);

                if (result.IsSuccessStatusCode)
                {
                    string jsonResult = result.Content.ReadAsStringAsync().Result;
                    var odata = JsonConvert.DeserializeObject<ODataResponse<T>>(jsonResult);
                    return odata.value;
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
