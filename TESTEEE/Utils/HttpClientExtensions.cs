using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {

        private static MediaTypeHeaderValue _contentType = new MediaTypeHeaderValue("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"tem algum problema.. {response.ReasonPhrase}");
            }

            //converte o json para objeto
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result =  JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            });

            return result;
        }


        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client , string url , T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = _contentType;

            return client.PostAsync(url, content);
        }

             public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient client , string url , T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = _contentType;

            return client.PutAsync(url, content);
        }

    }
}
