using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementService.HttpClients
{
    public class HttpClientBaseAPI<T>
    {
        protected readonly HttpClient _httpClient;
        protected T _obj;
        public HttpClientBaseAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var r = new List<T>();

            using (var response = await _httpClient.GetAsync(""))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                r = JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }

            return r;
        }

        public virtual async Task<T> Get(Guid id)
        {
            using (var response = await _httpClient.GetAsync($"{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                _obj = JsonConvert.DeserializeObject<T>(apiResponse);
            }

            return _obj;
        }

        public virtual async Task<T> Create(T a)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PostAsync("", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                _obj = JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return _obj;
        }

        public virtual async Task<T> Update(T a)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PutAsync("", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                _obj = JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return _obj;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var r = false;
            using (var response = await _httpClient.DeleteAsync($"{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                r = JsonConvert.DeserializeObject<bool>(apiResponse);
            }
            return r;
        }
    }
}
