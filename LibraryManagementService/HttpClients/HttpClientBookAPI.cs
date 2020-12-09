using LibraryManagement.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementService.HttpClients
{
    public class HttpClientBookAPI : HttpClientBaseAPI<BookView>
    {
        public HttpClientBookAPI(HttpClient httpClient) : base(httpClient)
        {

        }

        /*public async Task<BookView> GetAllAuthors()
        {
            var book = new BookView();
            var authors = new List<AuthorView>();
            
            using (var response = await _httpClient.GetAsync(""))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<AuthorView>>(apiResponse);
            }

            book.Authors = authors;

            return book;
        }*/
    }
}
