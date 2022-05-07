using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chromedia.Infrastructure.Helpers
{
    public static class HttpHelper
    {
        public static async Task<T> GetAsync<T>(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
