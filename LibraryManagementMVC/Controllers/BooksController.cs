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
        private IMapper _mapper;

        public BooksController(HttpClientBookAPI httpApi, HttpClientAuthorsAPI httpAuthor, IMapper mapper)
        {
            _http = httpApi;
            _httpAuthor = httpAuthor;
            _mapper = mapper;
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
        private Book ConvertBook(BookView b)
        {
            var authorView = new List<Guid>();
            var bookAuthors = new List<BookAuthor>();

            foreach (var a in b.Authors)
            {
                var BA = new BookAuthor()
                {
                    AuthorId = a.Id,
                };
                bookAuthors.Add(BA);
            }

            var book = new Book()
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Year = (int)b.Year,
                BooksAuthors = bookAuthors,
            };

            return book;
        }
        public async Task<ActionResult> Index()
        {
            var books = await _http.GetAll();
            var booksView = new List<BookView>();
            foreach (var b in books)
            {
                booksView.Add(ConvertBook(b));
            }
            return View(booksView);
        }
        public async Task<ActionResult> Details(Guid id)
        {
            var book = await _http.Get(id);
            var bookView = ConvertBook(book);
            return View(bookView);
        }
        public async Task<ActionResult> Create()
        {
            var authors = await _httpAuthor.GetAll();
            var authosView = new List<AuthorView>();
            foreach (var a in authors)
            {
                authosView.Add(Convert(a));
            }
            var bookView = new BookView()
            {
                Year = null,
                Authors = authosView,
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
                var av = Convert(a);
                if (a != null)
                {
                    authors.Add(av);
                }
            }
            var bv = new BookView()
            {
                Title = title,
                ISBN = ISBN,
                Year = year,
                Authors = authors,
            };
            try
            {
                var author = await _http.Create(ConvertBook(bv));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var book = await _http.Get(id);
            var bookView = ConvertBook(book);
            var authors = await _httpAuthor.GetAll();
            var authosView = new List<AuthorView>();
            foreach (var a in authors)
            {
                var aView = Convert(a);
                foreach (var au in bookView.Authors)
                {
                    if (aView.Id == au.Id)
                    {
                        aView.Select = true;
                    }
                }
                authosView.Add(aView);
            }
            bookView.Authors = authosView;
            return View(bookView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] Guid Id, string title, string ISBN, int year, IEnumerable<string> Authors)
        {
            var authors = new List<AuthorView>();

            foreach (var id in Authors)
            {
                var a = await _httpAuthor.Get(Guid.Parse(id));
                var av = Convert(a);
                if (a != null)
                {
                    authors.Add(av);
                }
            }
            var bv = new BookView()
            {
                Id = Id,
                Title = title,
                ISBN = ISBN,
                Year = year,
                Authors = authors,
            };
            try
            {
                var sendbook = ConvertBook(bv);
                var a = await _http.Update(sendbook);
                return RedirectToAction(nameof(Details), new { id = a.Id });
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var book = await _http.Get(id);
            var bookView = ConvertBook(book);
            return View(bookView);
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
