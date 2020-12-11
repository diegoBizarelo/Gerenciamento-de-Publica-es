using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementService.HttpClients;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;

namespace LibraryManagementMVC.Controllers
{
    public class AuthorsController : Controller
    {
        
        private readonly HttpClientAuthorsAPI _http;

        public AuthorsController(HttpClientAuthorsAPI httpApi)
        {
            _http = httpApi;
        }

        private BookView ConvertBook(Book b)
        {
            var authorView = new List<AuthorView>();
            foreach (var a in b.BooksAuthors)
            {
                authorView.Add(Convert(a.Author));
            }
            var bookView = new BookView()
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Year = b.Year,
                Authors = authorView,
            };
            return bookView;
        }
        private AuthorView Convert(Author a)
        {
            var authorView = new AuthorView()
            {
                Name = a.Name,
                LastName = a.LastName,
                BirthDay = a.BirthDay,
                Email = a.Email,
                Id = a.Id,
            };
            return authorView;
        }
        // GET: AuthorsController
        public async Task<ActionResult> Index()
        {
            var authors = await _http.GetAll();
            var authorsView = new List<AuthorView>();
            foreach (var a in authors)
            {
                authorsView.Add(Convert(a));
            }
            return View(authorsView);
        }

        // GET: AuthorsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var author = await _http.Get(id);
            var authorView = Convert(author);
            return View(authorView);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Author a)
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
            var authorView = Convert(author);
            return View(authorView);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Author author)
        {
            try
            {
                var a = await _http.Update(author);
                var authorView = Convert(a);
                return RedirectToAction(nameof(Details), new { id = authorView.Id });
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
            var authorView = Convert(a);
            return View(authorView);
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
