using LibraryManagement.Interfaces.Service;
using LibraryManagement.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.HttpClients
{
    public class HttpClientAuthorsAPI
    {
        private readonly HttpClient _httpClient;

        public HttpClientAuthorsAPI()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44392/api/");

        }

        public async Task<IEnumerable<AuthorView>> GetAll()
        {
            var authors = new List<AuthorView>();
            
            using (var response = await _httpClient.GetAsync("authors"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<AuthorView>>(apiResponse);
            }
            
            return authors;
        }

        public async Task<AuthorView> Get(Guid id)
        {
            var author = new AuthorView();

            using (var response = await _httpClient.GetAsync($"authors/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                author = JsonConvert.DeserializeObject<AuthorView>(apiResponse);
            }

            return author;
        }

        public async Task<AuthorView> Create(AuthorView a)
        {
            var author = new AuthorView();
            StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PostAsync($"authors", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                author = JsonConvert.DeserializeObject<AuthorView>(apiResponse);
            }
            return author;
        }

        public async Task<AuthorView> Update(AuthorView a)
        {
            var author = new AuthorView();
            StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PutAsync($"authors", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                author = JsonConvert.DeserializeObject<AuthorView>(apiResponse);
            }
            return author;
        }

        public async Task<bool> Delete(Guid id)
        {
            var r = false;
            //StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.DeleteAsync($"authors/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                r = JsonConvert.DeserializeObject<bool>(apiResponse);
            }
            return r;
        }
    }
}
