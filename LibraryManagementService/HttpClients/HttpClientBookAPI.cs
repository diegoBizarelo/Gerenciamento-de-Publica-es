using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryManagementService.HttpClients
{
    public class HttpClientBookAPI : HttpClientBaseAPI<BookView>
    {
        public HttpClientBookAPI(HttpClient httpClient) : base(httpClient)
        {

        }
    }
}
