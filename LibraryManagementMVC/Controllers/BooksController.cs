using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.ViewModel;
using LibraryManagementService.HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClientBookAPI _http;

        public BooksController(HttpClientBookAPI httpApi)
        {
            _http = httpApi;
        }

        // GET: AuthorsController
        public async Task<ActionResult> Index()
        {
            var books = await _http.GetAll();
            return View(books);
        }

        // GET: AuthorsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var book = await _http.Get(id);
            return View(book);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookView b)
        {
            try
            {
                var author = await _http.Create(b);
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
            var book = await _http.Get(id);
            return View(book);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BookView book)
        {
            try
            {
                var a = await _http.Update(book);
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
            var b = await _http.Get(id);
            return View(b);
        }

        // POST: AuthorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(BookView book)
        {
            try
            {
                await _http.Delete(book.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
