using AITest.Models;
using AITest.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        [Route("GetBooks")]
        public IActionResult Get()
        {
            var books = _bookRepo.GetBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(Guid id)
        {
            var books = _bookRepo.GetBooks(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookRepo.AddNewBook(book);
            return Ok();
        }

       
        

    }
}
