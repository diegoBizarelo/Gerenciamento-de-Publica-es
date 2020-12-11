using LibraryManagement.Interfaces.Service;
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
    public class HttpClientAuthorsAPI : HttpClientBaseAPI<Author>
    {
        public HttpClientAuthorsAPI(HttpClient httpClient) : base(httpClient)
        {

        }
    }
}
