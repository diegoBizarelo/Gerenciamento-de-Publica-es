using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementService.HttpClients
{
    public class HttpClientBookAPI : HttpClientBaseAPI<Book>
    {
        public HttpClientBookAPI(HttpClient httpClient) : base(httpClient)
        {

        }

        /*public override async Task<Book> Create(Book b)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PostAsync("", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                _obj = JsonConvert.DeserializeObject<Book>(apiResponse);
            }
            return _obj;
        }*/
    }
}
