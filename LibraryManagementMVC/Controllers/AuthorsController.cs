using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryManagement.HttpClients;
using LibraryManagement.Interfaces.Service;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LibraryManagementMVC.Controllers
{
    public class AuthorsController : Controller
    {
        
        private readonly HttpClientAuthorsAPI _http;

        public AuthorsController(HttpClientAuthorsAPI httpApi)
        {
            _http = httpApi;
        }

        // GET: AuthorsController
        public async Task<ActionResult> Index()
        {
            var authors = await _http.GetAll();
            return View(authors);
        }

        // GET: AuthorsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var author = await _http.Get(id);
            return View(author);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorView a)
        {
            try
            {
                var author = await _http.Create(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var author = await _http.Get(id);
            return View(author);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AuthorView author)
        {
            try
            {
                var a = await _http.Update(author);
                return RedirectToAction(nameof(Details), new { id = a.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var a = await _http.Get(id);
            return View(a);
        }

        // POST: AuthorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AuthorView author)
        {
            try
            {
                await _http.Delete(author.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
