using Aarvani.ChannelAdvisor.ValuesType;

namespace Aarvani.ChannelAdvisor.ApiCall
{
    public abstract class ApiCall
    {
        public CallType CallType { get; private set; }
        
        public ApiCall(CallType callType)
        {
            this.CallType = callType;
        }


    //     using (HttpClient client = new HttpClient())
    //            {
    //                client.BaseAddress = new Uri(_service_link);
    //client.DefaultRequestHeaders.Accept.Clear();
    //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //                HttpResponseMessage result = await client.PostAsJsonAsync("api/accounts/createuser", login);

    //                if (result.IsSuccessStatusCode)
    //                {
    //                    LoginReturn tokenDetails = await GetBearerTokenDetails(login);
    //_loginReturn.Status = LoginStatus.OK;
    //                    _loginReturn.CustomerID = login.CustomerID;
    //                    _loginReturn.BearerToken = tokenDetails.BearerToken;
    //                    _loginReturn.Expires = tokenDetails.Expires;

    //                    return _loginReturn;
    //                }
    //                else
    //                {
    //                    string msg = result.Content.ReadAsStringAsync().Result;
    //                    if (msg.Contains("is already taken"))
    //                    {
    //                        _loginReturn.Message = "Account with that email already exists. If you have forgotten your password please reset your password.";
    //                        return _loginReturn;
    //                    }
    //                    else
    //                        throw new Exception(msg);
    //                }
    //            }


        
    }
}
