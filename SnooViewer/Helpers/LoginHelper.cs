using Newtonsoft.Json.Linq;
using SnooViewer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Windows.Media.Protection.PlayReady;

namespace SnooViewer.Helpers
{
    public class LoginHelper
    {
        private readonly string clientId = "-3Mzr-d-7Jyw5h3osr5KPw";
        private readonly string clientSecret = "-iSfUYiyL2oDNa6PS6Ff5oHbq28_8w";
        readonly HttpClient client = new HttpClient();
        public LoginHelper(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;            
        }

        public Task<AuthViewModel> Login_Refresh(string refreshToken)
        {
            //Use the code to retrieve access Token and refresh token
            var nvc = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken)
                };

            var req = new HttpRequestMessage(HttpMethod.Post, Constants.Constants.redditApiBaseUrl + "access_token") { Content = new FormUrlEncodedContent(nvc) };
            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(this.clientId + ":" + this.clientSecret)));
            
            return GetResult<AuthViewModel>(req);
        }

        public Task<AuthViewModel> Login_Stage2(Uri callbackUri)
        {
            var regex = new Regex(Regex.Escape("#"));
            var updatedUriStr = regex.Replace(callbackUri.AbsoluteUri, "?", 1);
            var updatedUri = new Uri(updatedUriStr);
            var code = HttpUtility.ParseQueryString(updatedUri.Query).Get("code");

            //Use the code to retrieve access Token and refresh token
            var nvc = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("redirect_uri", "http://127.0.0.1:3000/reddit_callback")
                };

            var req = new HttpRequestMessage(HttpMethod.Post, Constants.Constants.redditApiBaseUrl + "access_token") { Content = new FormUrlEncodedContent(nvc) };
            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(this.clientId + ":" + this.clientSecret)));

            //RnD
            //req.Headers.UserAgent = new AuthenticationHeaderValue("UserAgent", Convert.ToBase64String(Encoding.ASCII.GetBytes("SnooViewer")));

            return GetResult<AuthViewModel>(req);
        }

        /// <summary>
        /// Private method for retrieving result and converting to .NET Type
        /// </summary>
        /// <typeparam name="Response">TResponse</typeparam>
        /// <param name="msg">HttpRequestMessage</param>
        /// <returns></returns>
        private async Task<Response> GetResult<Response>(HttpRequestMessage msg)
        {
            //RnD
            //client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SnooViewer by sahaRatul", "v1"));
            var productValue = new ProductInfoHeaderValue("SnooViewer", "1.0");
            var commentValue = new ProductInfoHeaderValue("(sahaRatul)");
            client.DefaultRequestHeaders.UserAgent.Add(productValue);
            client.DefaultRequestHeaders.UserAgent.Add(commentValue);

            //client.Headers.UserAgent.Add(productValue);
            //client.Headers.UserAgent.Add(commentValue);

            using (var response = await client.SendAsync(msg))
            {
                using (var content = response.Content)
                {
                    string responseContent = await content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        //throw new Exception(responseContent);
                        Debug.WriteLine("[error] " + responseContent);
                    }

                    Response result = default;

                    try
                    {
                        if (typeof(IConvertible).IsAssignableFrom(typeof(Response)))
                        {
                            result = (Response)Convert
                                .ChangeType(responseContent, typeof(Response));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("[ex] Blocked? Details: " + ex.Message);
                    }

                    result = JToken.Parse(responseContent).ToObject<Response>();

                    return result;
                }
            }
        }
    }
}
