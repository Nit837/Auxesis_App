using Auxesis_App.BalanceModel;
using Auxesis_App.Model;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Auxesis_App.Service
{
    public class WebService
    {
        //public async Task<Root> LoginUser(Users user)
        //{
        //    Root login = new Root();
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri(App.BaseUrl);
        //        httpClient.DefaultRequestHeaders.Accept.Clear();
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var json = JsonConvert.SerializeObject(user);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = httpClient.PostAsync("/api/user/login?_format=json", content).Result;
        //        if (response.IsSuccessStatusCode == true)
        //        {
        //            var responsebody = response.Content.ReadAsStringAsync().Result;
        //            login = JsonConvert.DeserializeObject<Root>(responsebody);
        //            return login;
        //        }
        //        else
        //        {

        //        }
        //    }
        //    return login;
        //}
        public async Task<LoginResponse> Login(Users user)
        {
            LoginResponse login;
            LoginCookieData cokkie;
            var CookieContainer = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                CookieContainer = CookieContainer
            };
            var _client = new HttpClient(handler);
            using (HttpClient httpClient = new HttpClient(new NativeMessageHandler()))
            {
                string data = JsonConvert.SerializeObject(user);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                //var response = await httpClient.PostAsync(Config.Login, content);
                var response = await _client.PostAsync(App.BaseUrl + "/api/user/login?_format=json", content);
                if (response.IsSuccessStatusCode == true)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = CookieContainer.GetCookies(new Uri(App.BaseUrl + "/api/user/login?_format=json"));
                    Datamanager dataManager = new Datamanager();
                    foreach (Cookie cookie in result)
                    {
                        cokkie = new LoginCookieData()
                        {
                            cookieName = cookie.Name,
                            cookieValue = cookie.Value,
                            Comment = cookie.Comment,
                            CommentUri = cookie.CommentUri,
                            Path = cookie.Path,
                            Port = cookie.Port,
                            Discard = cookie.Discard,
                            Expires = cookie.Expires,
                            HttpOnly = cookie.HttpOnly,
                            Version = cookie.Version,
                            Domain = cookie.Domain,
                            Expired = cookie.Expired,
                            Secure = cookie.Secure,
                        };
                        int results = await dataManager.SaveUserDetailAsync(cokkie);
                    }
                    App.Wrongcredentialresponse = json.ToString();
                    login = JsonConvert.DeserializeObject<LoginResponse>(json);
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    login = JsonConvert.DeserializeObject<LoginResponse>(json);
                }
            }
            return login;
        }
        public async Task<Root> GetUserAccountBalance()
        {
            Root getbalance;
            using (HttpClient httpClient = new HttpClient(new NativeMessageHandler()))
            {
                var url = string.Format(App.BaseUrl + "/api/account-balance?_format=json");
                var response = await httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                getbalance = JsonConvert.DeserializeObject<Root>(json);
            }
            return getbalance;
        }
        public async Task<int> LoginStatus()
        {
            int result;
            using (HttpClient httpClient = new HttpClient(new NativeMessageHandler()))
            {
                var url = string.Format(App.BaseUrl + "/user/login_status?_format=json");
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode == true)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = Convert.ToInt32(response.StatusCode);
                }
                else
                    result = 0;
            }
            return result;
        }
        public async Task<bool> Logout(string logouttoken)
        {
            bool result = false;
            using (HttpClient httpClient = new HttpClient(new NativeMessageHandler()))
            {
                string data = JsonConvert.SerializeObject(logouttoken);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var url = string.Format(App.BaseUrl + "/api/user/logout? format=json&token=" + logouttoken);
                var response = await httpClient.PostAsync(url, content);
                Datamanager dataManager = new Datamanager();
                if (response.IsSuccessStatusCode == true)
                {
                    result = true;
                    dataManager.DeleteCookieData();
                }
                else
                    result = false;
            }
            return result;
        }
    }
}
