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
    }
}
