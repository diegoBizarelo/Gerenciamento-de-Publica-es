using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using LibraryManagementService.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClientBookAPI _http;
        private readonly HttpClientAuthorsAPI _httpAuthor;
        private readonly IMapper _mapper;

        public BooksController(HttpClientBookAPI httpApi, HttpClientAuthorsAPI httpAuthor, IMapper mapper)
        {
            _http = httpApi;
            _httpAuthor = httpAuthor;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var books = await _http.GetAll();
            return View(books);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var book = await _http.Get(id);
            return View(book);
        }

        public async Task<ActionResult> Create()
        {
            var bookView = new BookView()
            {
                Year = null,
                //Authors = _mapper.Map<IList<Author>>(await _httpAuthor.GetAll()),
                Authors = await _httpAuthor.GetAll(),
            };
            return View(bookView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] string title, string ISBN, int year, IEnumerable<string> Authors)
        {
            var authors = new List<AuthorView>();

            foreach (var id in Authors)
            {
                var a = await _httpAuthor.Get(Guid.Parse(id));
                if (a != null)
                {
                    authors.Add(a);
                }
            }
            var bv = new BookView()
            {
                Title = title,
                ISBN = ISBN,
                Year = year,
                //Authors = _mapper.Map<IEnumerable<Author>>(authors),
            };
            try
            {
                var author = await _http.Create(bv);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var book = await _http.Get(id);
            return View(book);
        }

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

        public async Task<ActionResult> Delete(Guid id)
        {
            var b = await _http.Get(id);
            return View(b);
        }

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
