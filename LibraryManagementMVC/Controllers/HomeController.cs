using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
using LibraryManagement.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.PostAsync("https://localhost:44392/api/Login", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TokenGenerate.Token = apiResponse;
                }
            }
            return RedirectToAction("Index", "Books");
        }
    }
}
