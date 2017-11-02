using Aarvani.ChannelAdvisor.Entities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Aarvani.ChannelAdvisor.Services
{
    public static  class AuthTokenService
    {   
        private static readonly string  refreshToken = "refreshToken";
        private static readonly string applicationid = "applicationid";
        private static readonly string sharesecret = "sharesecret";
        /*attention convert to base-64 before check doc https://developer.channeladvisor.com/authorization/oauth-2-0-authorization-flow */
        private static readonly string encryptedApplicationidAndShareSecret = "encryptedApplicationidAndShareSecret";
        private static AuthToken _token;

        public static AuthToken Token { get { return _token; } }
        
        public static async Task<AuthToken> GetNewToken()
        {
            AuthToken auth = new AuthToken();

            if (_token == null || _token.IsExpireded())
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ValuesType.ApiUrls.Mainurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    string encryptedApplicationidAndShareSecret = Base64Encode(applicationid +":"+ sharesecret);
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + encryptedApplicationidAndShareSecret);

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    HttpResponseMessage result = new HttpResponseMessage();

                    var stringContent = new StringContent("grant_type=refresh_token&refresh_token=" + refreshToken);

                    result = await client.PostAsync(ValuesType.ApiUrls.Token, stringContent);

                    if (result.IsSuccessStatusCode)
                    {
                        string jsonResult = result.Content.ReadAsStringAsync().Result;
                        _token = JsonConvert.DeserializeObject<AuthToken>(jsonResult);
                        return _token;
                    }
                    else
                    {
                        string msg = result.Content.ReadAsStringAsync().Result;
                        throw new Exception(msg);
                    }
                }

            }

            return _token;

        }
        
         public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}
