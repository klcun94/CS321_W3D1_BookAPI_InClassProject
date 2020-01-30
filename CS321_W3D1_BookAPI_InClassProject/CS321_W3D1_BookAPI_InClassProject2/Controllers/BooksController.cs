using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI_InClassProject.Models;
using CS321_W3D1_BookAPI_InClassProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI_InClassProject2.Controllers
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

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Book currentbook = _bookService.Get(id);
            if (currentbook == null)
                return NotFound();
            return Ok(currentbook);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            try
            {
                _bookService.Post(newBook);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddBook", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { newBook.Id }, newBook);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book newBook)
        {
            var book = _bookService.Update(newBook);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book == null) return NotFound();
            _bookService.Delete(book);
            return NoContent();
        }
    }
}
