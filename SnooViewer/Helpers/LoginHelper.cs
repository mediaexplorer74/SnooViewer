using SnooViewer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Web.Http;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Windows.Media.Protection.PlayReady;
using RedditSharp.Multi;
using SnooViewer.Api;
using SnooViewer.Api.Models;
using Windows.Storage;
using System.Text.Json;
using SnooViewer.Constants;

namespace SnooViewer.Helpers
{
    public class LoginHelper
    {
        
        private static HttpClient httpClient = new();//readonly HttpClient client = new HttpClient();
        public LoginHelper()//(string clientId, string clientSecret)
        {
            //this.clientId = clientId;
            //this.clientSecret = clientSecret;            
        }

        private TokenInfo data;

        public TokenInfo Data
        {
            get
            {
                if (ApplicationData.Current.LocalSettings.Values.TryGetValue("TokenInfo", out object value))
                    return data ??= JsonSerializer.Deserialize((string)value, ApiJsonContext.Default.TokenInfo);

                return null;
            }
            set
            {
                data = value;
                ApplicationData.Current.LocalSettings.Values["TokenInfo"] = JsonSerializer.Serialize(data, ApiJsonContext.Default.TokenInfo);
            }
        }

        public Task<TokenInfo> Login_Refresh(string refreshToken)
        {
            //Use the code to retrieve access Token and refresh token
            var nvc = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken)
                };

            //TODO
            //var req = new HttpRequestMessage(HttpMethod.Post, Constants.Constants.redditApiBaseUrl + "access_token") { Content = new FormUrlEncodedContent(nvc) };
            //req.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(this.clientId + ":" + this.clientSecret)));

            //return GetResult<TokenInfo>(req);
            return default;
        }

        /// <summary>
        /// Makes a generic POST request.
        /// </summary>
        /// <param name="url">The URL to make a request to.</param>
        /// <returns>The HTTP content.</returns>
        public static async Task<IHttpContent> MakePostRequestAsync(string url, IDictionary<string, string> headers, IDictionary<string, string> postData)
        {
            var message = MakeMessage(url, Windows.Web.Http.HttpMethod.Post, headers);
            message.Content = new HttpFormUrlEncodedContent(postData);

            var response = await httpClient.SendRequestAsync(message, HttpCompletionOption.ResponseHeadersRead);

            if (response.StatusCode == HttpStatusCode.ServiceUnavailable ||
                response.StatusCode == HttpStatusCode.BadGateway ||
                response.StatusCode == HttpStatusCode.GatewayTimeout ||
                response.StatusCode == HttpStatusCode.InternalServerError ||
                response.StatusCode == HttpStatusCode.BadRequest)
            {
                Debug.WriteLine("[ex] Exception: response.StatusCode =" + response.StatusCode);
                throw new Exception();//ServiceDownException();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("You are not authorized to send this request.");
            }

            return response.Content;
        }


        private static HttpRequestMessage MakeMessage(string url, HttpMethod method, IDictionary<string, string> headers)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("The URL cannot be null.");

            var message = new HttpRequestMessage(method, new Uri(url, UriKind.Absolute));

            message.Headers["User-Agent"] = $"Carpeddit v0.10.0.0 (by /u/itsWindows11)";

            foreach (var header in headers)
                message.Headers.Add(header);

            return message;
        }

        public async Task<TokenInfo> Login_Stage2(Uri callbackUri)
        {
            var regex = new Regex(Regex.Escape("#"));
            string updatedUriStr = regex.Replace(callbackUri.AbsoluteUri, "?", 1);
            var updatedUri = new Uri(updatedUriStr);
            var code = HttpUtility.ParseQueryString(updatedUri.Query).Get("code");

            /*
            //Use the code to retrieve access Token and refresh token
            var nvc = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("redirect_uri", "http://127.0.0.1:3000/reddit_callback")
                };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, Constants.Constants.redditApiBaseUrl + "access_token") { Content = new FormUrlEncodedContent(nvc) };

            req.Headers["User-Agent"] = $"Carpeddit v{Constants.AppVersion} (by /u/itsWindows11)";

            req.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(this.clientId + ":" + this.clientSecret)));
            
            //RnD
            //req.Headers.UserAgent = new AuthenticationHeaderValue("UserAgent", Convert.ToBase64String(Encoding.ASCII.GetBytes("SnooViewer")));

            return GetResult<AuthViewModel>(req);

            */

            var dictionary = new Dictionary<string, string>()
            {
                { "code", code },
                { "grant_type", "authorization_code" },
                { "redirect_uri", "http://127.0.0.1:3000/reddit_callback" }
            };

            var content = await MakePostRequestAsync("https://www.reddit.com/api/v1/access_token", new Dictionary<string, string>()
            {
                { "Authorization", "Basic " 
                + Convert.ToBase64String(Encoding.ASCII.GetBytes(Constants.Constants.clientId + ":" + Constants.Constants.clientSecret)) }
            }, dictionary);

            TokenInfo tokenInfo = JsonSerializer.Deserialize(await content.ReadAsStringAsync(), ApiJsonContext.Default.TokenInfo);
            tokenInfo.ExpirationTime = DateTimeOffset.Now.AddSeconds((double)tokenInfo.ExpiresIn);

            Data = tokenInfo;

            return tokenInfo;

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
            /*
            var productValue = new ProductInfoHeaderValue("SnooViewer", "1.0");
            var commentValue = new ProductInfoHeaderValue("(sahaRatul)");
            client.DefaultRequestHeaders.UserAgent.Add(productValue);
            client.DefaultRequestHeaders.UserAgent.Add(commentValue);
            */
            /*
            using (var response = await httpClient.SendAsync(msg))
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

                    //result = JToken.Parse(responseContent).ToObject<Response>();

                    return result;
                }
            }
            */
            return default;
        }
    }
}
