using City.MVC.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace City.MVC.Services.Concretes
{
    public class HttpService : IHttpService
    {
        private readonly IConfiguration configuration;
        private static string ApiBaseUrl;
        
        public HttpService(IConfiguration configuration  )
        {
            try
            {
                this.configuration = configuration;
                ApiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> Delete<T>(string uri)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            var result = Activator.CreateInstance(typeof(T));
            var client = new HttpClient(handler);

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.DeleteAsync(ApiBaseUrl + uri);

                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                await Task.FromResult(result);

            }
            catch (Exception)
            {
                throw;
            }

            handler.Dispose();
            client.Dispose();

            return (T)result;

        }

        public async Task<T> Get<T>(string uri)
        {
            HttpClientHandler handler = new HttpClientHandler();

            var result = Activator.CreateInstance(typeof(T));
            var client = new HttpClient(handler);

            var response = client.GetAsync(ApiBaseUrl + uri).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<T>(jsonContent);
            }

            return await Task.FromResult((T)result);




        }

        public async Task<T> Post<T>(string uri, object value)
        {
            HttpClientHandler handler = new HttpClientHandler();

            var result = Activator.CreateInstance(typeof(T));
            StringContent Content = null;
            var client = new HttpClient(handler);

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                if (value != null)
                {
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
                    response = client.PostAsync(ApiBaseUrl + uri, Content).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(jsonContent);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return (T)result;
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            HttpClientHandler handler = new HttpClientHandler();

            var result = Activator.CreateInstance(typeof(T));
            StringContent Content = null;
            var client = new HttpClient(handler);

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                if (value != null)
                {
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
                    response = client.PutAsync(ApiBaseUrl + uri, Content).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(jsonContent);
                }
                //else
                //{
                //    var errorContent = response.Content.ReadAsStringAsync().Result;
                //    var error = JsonConvert.DeserializeObject<ErrorModel>(errorContent);
                //    throw new Exception($"HTTP Error {response.StatusCode}: {error.ErrorMessage}");
                //}
            }
            catch (Exception)
            {
                throw;
            }
            return (T)result;
        }
        //public class ErrorModel
        //{
        //    public string ErrorCode { get; set; }
        //    public string ErrorMessage { get; set; }
        //}
    }
}
