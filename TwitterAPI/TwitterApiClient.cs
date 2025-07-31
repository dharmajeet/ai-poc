using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAPI
{
    internal class TwitterApiClient
    {
       public string SearchPost(string tokenValue,string keywords)
        {

            string apiToken = tokenValue ?? string.Empty;
            var url = $"https://api.x.com/2/tweets/search/recent?query={keywords}";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
                    var response = client.GetStringAsync(url).Result;
                    // Parse JSON response.
                    return response;

                }
            }
            catch (System.AggregateException ex)
            {
                return ex.Message;
            }

        }

        public string SearchUsername(string tokenValue, string keywords)
        {

            string apiToken = tokenValue ?? string.Empty;
            var url = $"https://api.x.com/2/users/by/username/{keywords}?user.fields=created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiToken);
                    var response = client.GetStringAsync(url).Result;
                    // Parse JSON response.
                    return response;

                }
            }
            catch (System.AggregateException ex)
            {
                return ex.Message;
            }

        }
    }
}
