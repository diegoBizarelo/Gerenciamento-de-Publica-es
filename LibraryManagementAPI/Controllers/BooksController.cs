using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using LibraryManagement.Interfaces.Service;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<AuthoresController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _bookService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var l = await _bookService.Get(id);
                return Ok(l);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/<AuthoresController>
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            //var b = BookViewToBook(book);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _bookService.Post(book);
                if (result != null)
                {
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest("deu merda");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private Book BookViewToBook(BookView book)
        {
            var b = new Book()
            {
                Id = Guid.NewGuid(),
                Title = book.Title,
                ISBN = book.ISBN,
                Year = (int) book.Year,
            };
            var bookAuthor = new List<BookAuthor>();
            foreach (var a in book.Authors)
            {
                var ba = new BookAuthor()
                {
                    AuthorId = a.Id,
                    BookId = b.Id,
                };
                bookAuthor.Add(ba);
            }
            b.BooksAuthors = bookAuthor;
            return b;
        }

        // PUT api/<AuthoresController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _bookService.Put(book);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE api/<AuthoresController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _bookService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
