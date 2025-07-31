using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;



namespace TwitterAPI
{
    internal class TwitterAuth
    {
        public static AuthToken GetToken()
        {
            var oauth_consumer_key = "uAW7MsmtFwqUyl1T3zyqZgMvA";
            var oauth_consumer_secret = "";
            //Oauth Keys (Replace with values that are obtained from registering the application
            var oauth_url = "https://api.twitter.com/oauth2/token";
            var headerFormat = "Basic {0}";
            var authHeader = string.Format(headerFormat,
            Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oauth_consumer_key) + ":" +
            Uri.EscapeDataString((oauth_consumer_secret)))
            ));

            var postBody = "grant_type=client_credentials";

            ServicePointManager.Expect100Continue = false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(oauth_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }

            request.Headers.Add("Accept-Encoding", "gzip");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);

            var token = "";
            using (var reader = new StreamReader(responseStream))
            {
                token = reader.ReadToEnd();

            }

            AuthToken? authToken = JsonConvert.DeserializeObject<AuthToken>(token);
            return authToken ?? new AuthToken();

        }
    }
}

public class AuthToken
{
    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
}

